using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFallingBlockPuzzle
{
    class Blocks
    {
        /// <summary>
        /// 
        /// </summary>
        public enum Types
        {
            I,
            O,
            T,
            J,
            L,
            S,
            Z,
            V
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Defs.Blocks[,] GetBlocks(Types type)
        {
            Defs.Blocks i = Defs.Blocks.Block_0;
            Defs.Blocks o = Defs.Blocks.EmptyBlock;
            switch (type)
            {
                case Types.I:
                    i = Defs.Blocks.Block_0;
                    return new Defs.Blocks[,] {
                        { o, o, o, o },
                        { o, o, o, o },
                        { i, i, i, i },
                        { o, o, o, o },
                    };
                case Types.O:
                    i = Defs.Blocks.Block_1;
                    return new Defs.Blocks[,] {
                        { o, o, o, o },
                        { o, i, i, o },
                        { o, i, i, o },
                        { o, o, o, o },
                    };
                case Types.T:
                    i = Defs.Blocks.Block_2;
                    return new Defs.Blocks[,] {
                        { o, o, o, o },
                        { i, i, i, o },
                        { o, i, o, o },
                        { o, o, o, o },
                    };
                case Types.J:
                    i = Defs.Blocks.Block_3;
                    return new Defs.Blocks[,] {
                        { o, o, o, o },
                        { i, o, o, o },
                        { i, i, i, o },
                        { o, o, o, o },
                    };
                case Types.L:
                    i = Defs.Blocks.Block_4;
                    return new Defs.Blocks[,] {
                        { o, o, o, o },
                        { o, o, i, o },
                        { i, i, i, o },
                        { o, o, o, o },
                    };
                case Types.S:
                    i = Defs.Blocks.Block_5;
                    return new Defs.Blocks[,] {
                        { o, o, o, o },
                        { o, i, i, o },
                        { i, i, o, o },
                        { o, o, o, o },
                    };
                case Types.Z:
                    i = Defs.Blocks.Block_6;
                    return new Defs.Blocks[,] {
                        { o, o, o, o },
                        { i, i, o, o },
                        { o, i, i, o },
                        { o, o, o, o },
                    };
                case Types.V:
                    i = Defs.Blocks.Block_7;
                    return new Defs.Blocks[,] {
                        { o, o, o, o },
                        { o, i, o, o },
                        { o, i, i, o },
                        { o, o, o, o },
                    };
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Defs.Blocks[,] GetRandomBlocks()
        {
            var random = new Random();

            var table = new Types[] {
                Types.I, Types.O, Types.T,
                Types.J, Types.L, Types.S,
                Types.Z, Types.V
            };

            return GetBlocks(table[random.Next(table.Length)]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public static Defs.Blocks[,] ReplaceBlock(Defs.Blocks[,] target, Defs.Blocks src, Defs.Blocks dest)
        {
            var copied = (Defs.Blocks[,])target.Clone();
            for (int y = 0; y < copied.GetLength(0); ++y)
            {
                for (int x = 0, max = copied.GetLength(1); x < max; ++x)
                {
                    copied[y, x] = (copied[y, x] == src) ? dest : copied[y, x];
                }
            }
            return copied;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Defs.Blocks[,] RotateBlock(Defs.Blocks[,] target)
        {
            var copied = (Defs.Blocks[,])target.Clone();
            for (int y = 0; y < copied.GetLength(0); ++y)
            {
                for (int x = 0, max = copied.GetLength(1); x < max; ++x)
                {
                    copied[y, x] = target[copied.GetLength(1) - x - 1, y];
                }
            }
            return copied;
        }
    }
}
