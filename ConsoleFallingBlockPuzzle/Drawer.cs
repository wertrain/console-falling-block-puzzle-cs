using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFallingBlockPuzzle
{
    class Drawer
    {
        /// <summary>
        /// 
        /// </summary>
        public static char Wall { get; set; } = '■';

        /// <summary>
        /// 
        /// </summary>
        public static char NormalBlock { get; set; } = '■';

        /// <summary>
        /// 
        /// </summary>
        public static char EmptyBlock { get; set; } = '　';

        /// <summary>
        /// 
        /// </summary>
        public static char PaddingSpace { get; set; } = '　';

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="withWall"></param>
        /// <param name="leftPadding"></param>
        public static void Draw(Field field, bool withWall, int leftPadding)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            for (int y = 0; y < field.Height; ++y)
            {
                for (int p = 0; p < leftPadding; ++p)
                {
                    System.Console.Write(PaddingSpace.ToString());
                }

                if (withWall)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    System.Console.Write(Wall);
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                for (int x = 0; x < field.Width; ++x)
                {
                    System.Console.Write("{0}", field.Blocks[y][x] == 0 ? EmptyBlock.ToString() : NormalBlock.ToString());
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
                System.Console.Write(PaddingSpace.ToString());
            }

            if (withWall)
            {
                Console.ForegroundColor = ConsoleColor.Gray;

                for (int x = 0; x < field.Width + 2; ++x)
                {
                    System.Console.Write(Wall);

                }
                System.Console.WriteLine();
            }

            Console.ForegroundColor = defaultForegroundColor;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="block"></param>
        /// <param name="leftPadding"></param>
        public static void Draw(int[,] block, int leftPadding)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            for (int y = 0; y < block.GetLength(0); ++y)
            {
                for (int p = 0; p < leftPadding; ++p)
                {
                    System.Console.Write(PaddingSpace.ToString());
                }

                for (int x = 0, max = block.GetLength(1); x < max; ++x)
                {
                    System.Console.Write("{0}", block[y, x] == 0 ? EmptyBlock.ToString() : NormalBlock.ToString());
                }
                System.Console.WriteLine();
            }
            Console.ForegroundColor = defaultForegroundColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="block"></param>
        /// <param name="leftPadding"></param>
        public static void Draw(int[,] screen)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            for (int y = 0; y < screen.GetLength(0); ++y)
            {
                for (int x = 0, max = screen.GetLength(1); x < max; ++x)
                {
                    System.Console.Write("{0}", screen[y, x] == 0 ? EmptyBlock.ToString() : NormalBlock.ToString());
                }
                System.Console.WriteLine();
            }
            Console.ForegroundColor = defaultForegroundColor;
        }
    }
}
