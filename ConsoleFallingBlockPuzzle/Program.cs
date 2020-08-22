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
            var field = new Field(10, 30);
            Drawer.Draw(field, true, 10);
        }
    }
}
