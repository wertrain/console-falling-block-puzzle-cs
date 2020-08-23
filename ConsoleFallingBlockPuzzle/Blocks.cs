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
        public static int [,] GetBlocks(Types type)
        {
            int i = 0;
            switch (type)
            {
                case Types.I:
                    i = 1;
                    return new int[,] { 
                        { 0, 0, 0, 0 },
                        { 0, 0, 0, 0 }, 
                        { i, i, i, i },
                        { 0, 0, 0, 0 },
                    };
                case Types.O:
                    i = 2;
                    return new int[,] {
                        { 0, 0, 0, 0 },
                        { 0, i, i, 0 },
                        { 0, i, i, 0 },
                        { 0, 0, 0, 0 },
                    };
                case Types.T:
                    i = 3;
                    return new int[,] {
                        { 0, 0, 0, 0 },
                        { i, i, i, 0 },
                        { 0, i, 0, 0 },
                        { 0, 0, 0, 0 },
                    };
                case Types.J:
                    i = 4;
                    return new int[,] {
                        { 0, 0, 0, 0 },
                        { i, 0, 0, 0 },
                        { i, i, i, 0 },
                        { 0, 0, 0, 0 },
                    };
                case Types.L:
                    i = 4;
                    return new int[,] {
                        { 0, 0, 0, 0 },
                        { 0, 0, i, 0 },
                        { i, i, i, 0 },
                        { 0, 0, 0, 0 },
                    };
                case Types.S:
                    i = 5;
                    return new int[,] {
                        { 0, 0, 0, 0 },
                        { 0, i, i, 0 },
                        { i, i, 0, 0 },
                        { 0, 0, 0, 0 },
                    };
                case Types.Z:
                    i = 6;
                    return new int[,] {
                        { 0, 0, 0, 0 },
                        { i, i, 0, 0 },
                        { 0, i, i, 0 },
                        { 0, 0, 0, 0 },
                    };
                case Types.V:
                    i = 7;
                    return new int[,] {
                        { 0, 0, 0, 0 },
                        { 0, i, 0, 0 },
                        { 0, i, i, 0 },
                        { 0, 0, 0, 0 },
                    };
            }
            return null;
        }
    }
}
