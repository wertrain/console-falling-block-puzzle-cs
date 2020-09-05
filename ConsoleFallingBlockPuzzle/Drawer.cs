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
        private static char Wall { get; set; } = '■';

        /// <summary>
        /// 
        /// </summary>
        private static char NormalBlock { get; set; } = '■';

        /// <summary>
        /// 
        /// </summary>
        private static char EmptyBlock { get; set; } = '■';

        /// <summary>
        /// 
        /// </summary>
        private static char PaddingSpace { get; set; } = '■';

        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<Defs.Blocks, ConsoleColor> ColorTable { get; } = new Dictionary<Defs.Blocks, ConsoleColor>
        {
            { Defs.Blocks.Space,       ConsoleColor.Black       },
            { Defs.Blocks.EmptyField,  ConsoleColor.DarkGray    },
            { Defs.Blocks.EmptyBlock,  ConsoleColor.Gray        },
            { Defs.Blocks.Block_0,     ConsoleColor.DarkBlue    },
            { Defs.Blocks.Block_1,     ConsoleColor.Yellow      },
            { Defs.Blocks.Block_2,     ConsoleColor.DarkMagenta },
            { Defs.Blocks.Block_3,     ConsoleColor.Blue        },
            { Defs.Blocks.Block_4,     ConsoleColor.Magenta     },
            { Defs.Blocks.Block_5,     ConsoleColor.Green       },
            { Defs.Blocks.Block_6,     ConsoleColor.Red         },
            { Defs.Blocks.Block_7,     ConsoleColor.DarkRed     },
        };

        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<Defs.Blocks, char> BlockTable { get; } = new Dictionary<Defs.Blocks, char>
        {
            { Defs.Blocks.Space,       PaddingSpace },
            { Defs.Blocks.EmptyField,  EmptyBlock   },
            { Defs.Blocks.EmptyBlock,  EmptyBlock   },
            { Defs.Blocks.Block_0,     NormalBlock  },
            { Defs.Blocks.Block_1,     NormalBlock  },
            { Defs.Blocks.Block_2,     NormalBlock  },
            { Defs.Blocks.Block_3,     NormalBlock  },
            { Defs.Blocks.Block_4,     NormalBlock  },
            { Defs.Blocks.Block_5,     NormalBlock  },
            { Defs.Blocks.Block_6,     NormalBlock  },
            { Defs.Blocks.Block_7,     NormalBlock  },
        };

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
                    System.Console.Write("{0}", field.FieldBlocks[y, x] == 0 ? EmptyBlock.ToString() : NormalBlock.ToString());
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
        public static void Draw(Defs.Blocks[,] block, int leftPadding)
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
        public static void Draw(Defs.Blocks[,] screen)
        {
            var defaultForegroundColor = Console.ForegroundColor;
            for (int y = 0; y < screen.GetLength(0); ++y)
            {
                for (int x = 0, max = screen.GetLength(1); x < max; ++x)
                {
                    Defs.Blocks block = screen[y, x];
                    Console.ForegroundColor = ColorTable[block];
                    System.Console.Write("{0}", BlockTable[block]);
                }
                System.Console.WriteLine();
            }
            Console.ForegroundColor = defaultForegroundColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="previousScreen"></param>
        public static void DrawDifference(Defs.Blocks[,] screen, Defs.Blocks[,] previousScreen)
        {
            var defaultForegroundColor = Console.ForegroundColor;
            for (int y = 0; y < screen.GetLength(0); ++y)
            {
                for (int x = 0, max = screen.GetLength(1); x < max; ++x)
                {
                    Defs.Blocks block = screen[y, x];
                    Defs.Blocks drawnBlock = previousScreen[y, x];
                    if (drawnBlock == block) continue;

                    Console.CursorLeft = x * 2;
                    Console.CursorTop = y;
                    Console.ForegroundColor = ColorTable[block];
                    System.Console.Write("{0}", BlockTable[block]);
                }
                Console.WindowTop = 0;
            }
            Console.ForegroundColor = defaultForegroundColor;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }
    }
}
