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

        public static int FieldScreenOffsetY { get; } = 4;

        public Game()
        {
            Screen = new Defs.Blocks[32, 32];
            PreviousScreen = new Defs.Blocks[32, 32];
            Field = new Field(10, 26);

            var blocks = Blocks.ReplaceBlock(Blocks.GetBlocks(Blocks.Types.I), Defs.Blocks.EmptyBlock, Defs.Blocks.EmptyField);
            Field.SpawnBlock(blocks);

            NextBlocks = Blocks.GetRandomBlocks();
            MergeToScreen(NextBlocks, 1, 1);
            MergeToScreen(Field.FieldBlocks, 6, 1, FieldScreenOffsetY);
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
                Input.Instance.Update();

                //Drawer.Clear();
                var currentElapsed = stopwatch.Elapsed.TotalMilliseconds;
                var delta = currentElapsed - prevElapsed;
                prevElapsed = currentElapsed;

                Field.RotateBlocks = Input.Instance.IsKeyTrigger(Input.KeyCode.Z);
                Field.ReverseRotateBlocks = Input.Instance.IsKeyTrigger(Input.KeyCode.X);
                Field.MoveLeftBlocks = Input.Instance.IsKeyPress(Input.KeyCode.Left);
                Field.MoveRightBlocks = Input.Instance.IsKeyPress(Input.KeyCode.Right);
                Field.MoveDownBlocks = Input.Instance.IsKeyPress(Input.KeyCode.Down);
                Field.FallenBlocks = Input.Instance.IsKeyTrigger(Input.KeyCode.Up);

                Field.Step(delta);

                MergeToScreen(Field.FieldBlocks, 6, 1, FieldScreenOffsetY);
                if (!Field.HasActiveBlock)
                {
                    var blocks = Blocks.ReplaceBlock(NextBlocks, Defs.Blocks.EmptyBlock, Defs.Blocks.EmptyField);
                    if (Field.SpawnBlock(blocks))
                    {
                        NextBlocks = Blocks.GetRandomBlocks();
                        MergeToScreen(Blocks.GetRandomBlocks(), 1, 1);
                    }
                    else
                    {
                        break;
                    }
                }
                Drawer.DrawDifference(Screen, PreviousScreen);
                PreviousScreen = (Defs.Blocks[,])Screen.Clone();

                int x = Screen.GetLength(1), y = 2;
                Drawer.DrawText(x + 1, y++, "SCORE: {0}", 100);

                System.Threading.Thread.Sleep(1000 / 10);
            }
            while (inputKey.Key != ConsoleKey.Q);

            stopwatch.Stop();

            Drawer.Clear();
        }
    }
}
