using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFallingBlockPuzzle
{
    class Game
    {
        public Defs.Blocks[,] Screen { get; private set; }
        public Defs.Blocks[,] PreviousScreen { get; private set; }

        private Field Field { get; set; }

        public Game()
        {
            Screen = new Defs.Blocks[25, 32];
            PreviousScreen = new Defs.Blocks[25, 32];
            Field = new Field(10, 24);

            var blocks = Blocks.ReplaceBlock(Blocks.GetBlocks(Blocks.Types.L), Defs.Blocks.EmptyBlock, Defs.Blocks.EmptyField);
            Field.SpawnBlock(blocks);

            Field.Step();
            Field.Step();
            Field.Step();

            MergeToScreen(Blocks.RotateBlock(Blocks.GetBlocks(Blocks.Types.L)), 1, 1);
            MergeToScreen(Field.FieldBlocks, 6, 1);
        }

        public void ApplyScreen()
        {

        }

        private void MergeToScreen(Defs.Blocks[,] target, int posX, int posY)
        {
            for (int y = 0; y < target.GetLength(0); ++y)
            {
                for (int x = 0, max = target.GetLength(1); x < max; ++x)
                {
                    Screen[y + posY, x + posX] = target[y, x];
                }
            }
        }

        public void Update()
        {
            var inputKey = new ConsoleKeyInfo();
            do
            {
                //Drawer.Clear();

                Field.Step();
                MergeToScreen(Field.FieldBlocks, 6, 1);
                Drawer.DrawDifference(Screen, PreviousScreen);
                PreviousScreen = (Defs.Blocks[,])Screen.Clone();

                inputKey = Console.ReadKey();
            }
            while (inputKey.Key != ConsoleKey.Q);
            
        }
    }
}
