using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFallingBlockPuzzle
{
    class Game
    {
        public int[,] Screen { get; private set; }

        private Field Field { get; set; }

        public Game()
        {
            Screen = new int[48, 32];
        }
    }
}
