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

        public void FixBlock(Defs.Blocks[,] blocks, int blockX, int blockY)
        {
            for (int y = 0; y < blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = blocks.GetLength(1); x < max; ++x)
                {
                    if (ActiveBlocks.Blocks[y, x] == Defs.Blocks.EmptyField)
                    {
                        continue;
                    }

                    if (y + blockY > FieldBlocks.GetLength(0) - 1 || x + blockX > FieldBlocks.GetLength(1) -1)
                    {
                        continue;
                    }

                    FieldBlocks[y + blockY, x + blockX] = blocks[y, x];
                }
            }
        }

        public void ClearBlock(Defs.Blocks[,] blocks, int blockX, int blockY)
        {
            for (int y = 0; y < blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = blocks.GetLength(1); x < max; ++x)
                {
                    if (blocks[y, x] == Defs.Blocks.EmptyField)
                    {
                        continue;
                    }

                    if (y + blockY > FieldBlocks.GetLength(0) || x + blockX > FieldBlocks.GetLength(0))
                    {
                        continue;
                    }

                    FieldBlocks[y + blockY, x + blockX] = Defs.Blocks.EmptyField;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Step()
        {
            if (ActiveBlocks == null) return;

            ClearBlock(ActiveBlocks.Blocks, ActiveBlocks.X, ActiveBlocks.Y);

            for (int y = 0; y < ActiveBlocks.Blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = ActiveBlocks.Blocks.GetLength(1); x < max; ++x)
                {
                    if (ActiveBlocks.Blocks[y, x] == Defs.Blocks.EmptyField)
                    {
                        continue;
                    }

                    if (y + ActiveBlocks.Y + 1 > FieldBlocks.GetLength(0) - 1)
                    {
                        FixBlock(ActiveBlocks.Blocks, ActiveBlocks.X, ActiveBlocks.Y);
                        ActiveBlocks = null;
                        return;
                    }

                    if (FieldBlocks[y + ActiveBlocks.Y + 1, x + ActiveBlocks.X] != Defs.Blocks.EmptyField)
                    {
                        FixBlock(ActiveBlocks.Blocks, ActiveBlocks.X, ActiveBlocks.Y);
                        ActiveBlocks = null;
                        return;
                    }
                }
            }

            ++ActiveBlocks.Y;

            FixBlock(ActiveBlocks.Blocks, ActiveBlocks.X, ActiveBlocks.Y);
        }
    }
}
