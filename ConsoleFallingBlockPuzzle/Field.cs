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
        public char Wall { get; set; }

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
            Wall = '■';

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
        public void Draw(bool withWall, int leftPadding)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            for (int y = 0; y < Height; ++y)
            {
                for (int p = 0; p < leftPadding; ++p)
                {
                    System.Console.Write("　");
                }

                if (withWall)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    System.Console.Write(Wall);
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                for (int x = 0; x < Width; ++x)
                {
                    System.Console.Write("{0}", Blocks[y][x] == 0 ? "　" : Wall.ToString());
                }

                if (withWall)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    System.Console.Write(Wall);
                }

                System.Console.WriteLine();
            }

            for (int p = 0; p < leftPadding; ++p)
            {
                System.Console.Write("　");
            }

            if (withWall)
            {
                Console.ForegroundColor = ConsoleColor.Gray;

                for (int x = 0; x < Width + 2; ++x)
                {
                    System.Console.Write(Wall);

                }
                System.Console.WriteLine();
            }

            Console.ForegroundColor = defaultForegroundColor;
        }
    }
}
