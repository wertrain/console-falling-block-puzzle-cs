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
        private List<List<int>> Blocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Field(int width, int height)
        {
            Width = width;
            Height = height;

            Blocks = new List<List<int>>(Height);
            for (int y = 0; y < Height; ++y)
            {
                Blocks.Add(new List<int>(Width));

                for (int x = 0; x < Width; ++x)
                {
                    Blocks[y].Add(0);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Draw()
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    System.Console.Write("■", Blocks[y][x]);
                }
                System.Console.WriteLine();
            }
            Console.ForegroundColor = defaultForegroundColor;
        }
    }
}
