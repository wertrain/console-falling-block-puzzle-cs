using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFallingBlockPuzzle
{
    class Field
    {
        class BlocksObject
        {
            /// <summary>
            /// 
            /// </summary>
            public int X { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int Y { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public Defs.Blocks[,] Blocks { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="blocks"></param>
            public BlocksObject(Defs.Blocks[,] blocks, int x, int y)
            {
                Blocks = blocks;
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Defs.Blocks[,] FieldBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private List<Defs.Blocks[,]> BlocksList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private BlocksObject ActiveBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private double ElapsedTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HasActiveBlock { get { return ActiveBlocks != null; } }

        /// <summary>
        /// 
        /// </summary>
        public bool RotateBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool MoveLeftBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool MoveRightBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool MoveDownBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FallenBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Field(int width, int height)
        {
            Width = width;
            Height = height;

            FieldBlocks = new Defs.Blocks[Height, Width];
            for (int y = 0; y < FieldBlocks.GetLength(0); ++y)
            {
                for (int x = 0, max = FieldBlocks.GetLength(1); x < max; ++x)
                {
                    FieldBlocks[y, x] = Defs.Blocks.EmptyField;
                }
            }

            BlocksList = new List<Defs.Blocks[,]>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blocks"></param>
        public void SpawnBlock(Defs.Blocks[,] blocks)
        {
            int posY = 0, posX = 2;
            for (int y = 0; y < blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = blocks.GetLength(1); x < max; ++x)
                {
                    FieldBlocks[y + posY, x + posX] = blocks[y, x];
                }
            }

            ActiveBlocks = new BlocksObject(blocks, 2, 0);
            BlocksList.Add(blocks);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blocks"></param>
        /// <param name="blockX"></param>
        /// <param name="blockY"></param>
        public void FixBlock(Defs.Blocks[,] blocks, int blockX, int blockY)
        {
            for (int y = 0; y < blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = blocks.GetLength(1); x < max; ++x)
                {
                    if (ActiveBlocks.Blocks[y, x] == Defs.Blocks.EmptyField)
                    {
                        continue;
                    }

                    if (y + blockY > FieldBlocks.GetLength(0) - 1 || x + blockX > FieldBlocks.GetLength(1) - 1)
                    {
                        continue;
                    }

                    FieldBlocks[y + blockY, x + blockX] = blocks[y, x];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blocks"></param>
        /// <param name="blockX"></param>
        /// <param name="blockY"></param>
        public void ClearBlock(Defs.Blocks[,] blocks, int blockX, int blockY)
        {
            for (int y = 0; y < blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = blocks.GetLength(1); x < max; ++x)
                {
                    if (blocks[y, x] == Defs.Blocks.EmptyField)
                    {
                        continue;
                    }

                    if (y + blockY > FieldBlocks.GetLength(0) - 1 || x + blockX > FieldBlocks.GetLength(1) - 1)
                    {
                        continue;
                    }

                    FieldBlocks[y + blockY, x + blockX] = Defs.Blocks.EmptyField;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blocks"></param>
        /// <param name="blockX"></param>
        /// <param name="blockY"></param>
        /// <returns></returns>
        public bool IsHitBlock(Defs.Blocks[,] blocks, int blockX, int blockY)
        {
            for (int y = 0; y < blocks.GetLength(0); ++y)
            {
                for (int x = 0, max = blocks.GetLength(1); x < max; ++x)
                {
                    if (blocks[y, x] == Defs.Blocks.EmptyField)
                    {
                        continue;
                    }

                    if (y + blockY > FieldBlocks.GetLength(0) - 1)
                    {
                        return true;
                    }

                    if (x + blockX > FieldBlocks.GetLength(1) - 1)
                    {
                        return true;
                    }

                    if (x + blockX < 0)
                    {
                        return true;
                    }

                    if (FieldBlocks[y + blockY, x + blockX] != Defs.Blocks.EmptyField)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        private int ClearLine()
        {
            int count = 0;

            for (int y = 0; y < FieldBlocks.GetLength(0); ++y)
            {
                bool line = true;

                for (int x = 0, max = FieldBlocks.GetLength(1); x < max; ++x)
                {
                    if (FieldBlocks[y, x] == Defs.Blocks.EmptyField)
                    {
                        line = false;
                        break;
                    }
                }

                if (line)
                {
                    ++count;

                    for (int x = 0, max = FieldBlocks.GetLength(1); x < max; ++x)
                    {
                        FieldBlocks[y, x] = Defs.Blocks.EmptyField;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CloseUpBlocks()
        {
            for (int y = FieldBlocks.GetLength(0) - 1; y >= 0; --y)
            {
                bool line = true;

                for (int x = 0, max = FieldBlocks.GetLength(1); x < max; ++x)
                {
                    if (FieldBlocks[y, x] != Defs.Blocks.EmptyField)
                    {
                        line = false;
                        break;
                    }
                }

                if (line)
                {
                    for (int yy = y; yy >= 1; --yy)
                    {
                        for (int x = 0, max = FieldBlocks.GetLength(1); x < max; ++x)
                        {
                            FieldBlocks[yy, x] = FieldBlocks[yy - 1, x];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Step(double deltaTime)
        {
            ElapsedTime += deltaTime;

            if (ActiveBlocks == null) return;

            ClearBlock(ActiveBlocks.Blocks, ActiveBlocks.X, ActiveBlocks.Y);

            if (RotateBlocks)
            {
                var rotateBlocks = Blocks.RotateBlock(ActiveBlocks.Blocks);

                if (!IsHitBlock(rotateBlocks, ActiveBlocks.X, ActiveBlocks.Y))
                {
                    ActiveBlocks.Blocks = rotateBlocks;
                }

                RotateBlocks = false;
            }

            if (MoveLeftBlocks)
            {
                if (!IsHitBlock(ActiveBlocks.Blocks, ActiveBlocks.X - 1, ActiveBlocks.Y))
                {
                    --ActiveBlocks.X;
                }

                MoveLeftBlocks = false;
            }

            if (MoveRightBlocks)
            {
                if (!IsHitBlock(ActiveBlocks.Blocks, ActiveBlocks.X + 1, ActiveBlocks.Y))
                {
                    ++ActiveBlocks.X;
                }

                MoveRightBlocks = false;
            }

            if (MoveDownBlocks)
            {
                if (!IsHitBlock(ActiveBlocks.Blocks, ActiveBlocks.X, ActiveBlocks.Y + 1))
                {
                    ++ActiveBlocks.Y;
                }

                MoveDownBlocks = false;
            }

            bool inactiveBlocks = false;

            if (FallenBlocks)
            {
                while (!IsHitBlock(ActiveBlocks.Blocks, ActiveBlocks.X, ActiveBlocks.Y + 1))
                {
                    ++ActiveBlocks.Y;
                }
                inactiveBlocks = true;

                FallenBlocks = false;
            }
            else if (ElapsedTime > 500)
            {
                ElapsedTime = 0;

                if (!IsHitBlock(ActiveBlocks.Blocks, ActiveBlocks.X, ActiveBlocks.Y + 1))
                {
                    ++ActiveBlocks.Y;
                }
                else
                {
                    inactiveBlocks = true;
                }
            }

            FixBlock(ActiveBlocks.Blocks, ActiveBlocks.X, ActiveBlocks.Y);

            if (inactiveBlocks)
            {
                ActiveBlocks = null;
            }

            int lineCount = ClearLine();

            if (lineCount > 0)
            {
                CloseUpBlocks();
            }
        }
    }
}
