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

        public static void Draw(Field field, bool withWall, int leftPadding)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            for (int y = 0; y < field.Height; ++y)
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

                for (int x = 0; x < field.Width; ++x)
                {
                    System.Console.Write("{0}", field.Blocks[y][x] == 0 ? "　" : Wall.ToString());
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

                for (int x = 0; x < field.Width + 2; ++x)
                {
                    System.Console.Write(Wall);

                }
                System.Console.WriteLine();
            }

            Console.ForegroundColor = defaultForegroundColor;
        }
    }
}
