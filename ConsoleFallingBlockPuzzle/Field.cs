using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFallingBlockPuzzle
{
    class Field
    {
        class BlocksObject
        {
            /// <summary>
            /// 
            /// </summary>
            public int X { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int Y { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public Defs.Blocks[,] Blocks { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="blocks"></param>
            public BlocksObject(Defs.Blocks[,] blocks, int x, int y)
            {
                Blocks = blocks;
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Defs.Blocks[,] FieldBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private List<Defs.Blocks[,]> BlocksList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private BlocksObject ActiveBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Field(int width, int height)
        {
            Width = width;
            Height = height;

            FieldBlocks = new Defs.Blocks[Height, Width];
            for (int y = 0; y < FieldBlocks.GetLength(0); ++y)
            {
                for (int x = 0, max = FieldBlocks.GetLength(1); x < max; ++x)
                {
                    FieldBlocks[y, x] = Defs.Blocks.EmptyField;
                }
            }

            BlocksList = new List<Defs.Blocks[,]>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blocks"></param>
        public void SpawnBlock(Defs.Blocks[,] blocks)
        {
            int posY = 0, posX = 2;
            for (int y = 0; y < blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = blocks.GetLength(1); x < max; ++x)
                {
                    FieldBlocks[y + posY, x + posX] = blocks[y, x];
                }
            }

            ActiveBlocks = new BlocksObject(blocks, 2, 0);
            BlocksList.Add(blocks);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Step()
        {
            for (int y = 0; y < ActiveBlocks.Blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = ActiveBlocks.Blocks.GetLength(1); x < max; ++x)
                {
                    FieldBlocks[y + ActiveBlocks.Y, x + ActiveBlocks.X] = Defs.Blocks.EmptyField;
                }
            }

            for (int y = 0; y < ActiveBlocks.Blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = ActiveBlocks.Blocks.GetLength(1); x < max; ++x)
                {
                    if (FieldBlocks[y + ActiveBlocks.Y + 1, x + ActiveBlocks.X] != Defs.Blocks.EmptyField)
                    {
                        return;
                    }
                }
            }

            ++ActiveBlocks.Y;

            for (int y = 0; y < ActiveBlocks.Blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = ActiveBlocks.Blocks.GetLength(1); x < max; ++x)
                {
                    FieldBlocks[y + ActiveBlocks.Y, x + ActiveBlocks.X] = ActiveBlocks.Blocks[y, x];
                }
            }
        }
    }
}
