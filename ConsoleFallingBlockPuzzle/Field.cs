using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFallingBlockPuzzle
{
    class Field
    {
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
        public Defs.Blocks[,] Blocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private List<Defs.Blocks[,]> BlocksList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Field(int width, int height)
        {
            Width = width;
            Height = height;

            Blocks = new Defs.Blocks[Height, Width];
            for (int y = 0; y < Blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = Blocks.GetLength(1); x < max; ++x)
                {
                    Blocks[y, x] = Defs.Blocks.EmptyField;
                }
            }
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
                    Blocks[y + posY, x + posX] = blocks[y, x];
                }
            }
            BlocksList.Add(blocks);
        }
    }
}
