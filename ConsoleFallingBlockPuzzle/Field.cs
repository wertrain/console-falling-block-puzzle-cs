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
        public int[,] Blocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Field(int width, int height)
        {
            Width = width;
            Height = height;

            Blocks = new int[Height, Width];
            for (int y = 0; y < Blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = Blocks.GetLength(1); x < max; ++x)
                {
                    Blocks[y, x] = 0;
                }
            }
        }
    }
}
