using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFallingBlockPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var field = new Field(10, 30);
            //Drawer.Draw(field, true, 10);

            //var block = Blocks.GetBlocks(Blocks.Types.L);
            //Drawer.Draw(block, 0);

            var game = new Game();
            game.Update();
            //Drawer.Draw(game.Screen);
        }
    }
}
