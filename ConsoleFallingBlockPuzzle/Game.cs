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
        private Defs.Blocks[,] NextBlocks;

        public Game()
        {
            Screen = new Defs.Blocks[32, 32];
            PreviousScreen = new Defs.Blocks[32, 32];
            Field = new Field(10, 30);

            var blocks = Blocks.ReplaceBlock(Blocks.GetBlocks(Blocks.Types.I), Defs.Blocks.EmptyBlock, Defs.Blocks.EmptyField);
            Field.SpawnBlock(blocks);

            NextBlocks = Blocks.GetRandomBlocks();
            MergeToScreen(Blocks.GetRandomBlocks(), 1, 1);
            MergeToScreen(Field.FieldBlocks, 6, 1, 6);
        }

        public void ApplyScreen()
        {

        }

        private void MergeToScreen(Defs.Blocks[,] target, int posX, int posY)
        {
            MergeToScreen(target, posX, posY, 0);
        }

        private void MergeToScreen(Defs.Blocks[,] target, int posX, int posY, int offsetY)
        {
            for (int y = offsetY; y < target.GetLength(0); ++y)
            {
                for (int x = 0, max = target.GetLength(1); x < max; ++x)
                {
                    Screen[y + posY - offsetY, x + posX] = target[y, x];
                }
            }
        }

        public void Update()
        {
            var inputKey = new ConsoleKeyInfo();

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            double prevElapsed = 0;
            do
            {
                //Drawer.Clear();
                var currentDelta = stopwatch.Elapsed.TotalMilliseconds;
                var delta = currentDelta - prevElapsed;
                prevElapsed = currentDelta;

                Field.Step(delta);

                MergeToScreen(Field.FieldBlocks, 6, 1, 8);
                if (!Field.HasActiveBlock)
                {
                    var blocks = Blocks.ReplaceBlock(NextBlocks, Defs.Blocks.EmptyBlock, Defs.Blocks.EmptyField);
                    Field.SpawnBlock(blocks);

                    NextBlocks = Blocks.GetRandomBlocks();
                    MergeToScreen(Blocks.GetRandomBlocks(), 1, 1);
                }
                Drawer.DrawDifference(Screen, PreviousScreen);
                PreviousScreen = (Defs.Blocks[,])Screen.Clone();

                System.Threading.Thread.Sleep(1000 / 10);
            }
            while (inputKey.Key != ConsoleKey.Q);

            stopwatch.Stop();
        }
    }
}
