using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFallingBlockPuzzle
{
    class Input
    {
        /// <summary>
        /// 
        /// </summary>
        private Input()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public enum KeyCode : int
        {

            /// <summary>
            /// 
            /// </summary>
            Left = 37,

            /// <summary>
            /// 
            /// </summary>
            Up = 38,

            /// <summary>
            /// 
            /// </summary>
            Right = 39,

            /// <summary>
            /// 
            /// </summary>
            Down = 40,
        }

        /// <summary>
        /// 
        /// </summary>
        public static Input Instance { get; private set; } = new Input();

        /// <summary>
        /// 
        /// </summary>
        private int[] KeyPressTable { get; set; } = new int[256];

        /// <summary>
        /// 
        /// </summary>
        private int[] KeyReleaseTable { get; set; } = new int[256];

        /// <summary>
        /// 
        /// </summary>
        private int[] KeyTriggerTable { get; set; } = new int[256];

        /// <summary>
        /// 
        /// </summary>
        private int[] PreviousKeyPressTable { get; set; } = new int[256];

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            for (int i = 0; i < 256; ++i)
            {
                KeyTriggerTable[i] = 0;
                KeyReleaseTable[i] = 0;
            }

            Array.Copy(KeyPressTable, PreviousKeyPressTable, KeyPressTable.Length);

            KeyPressTable[(int)KeyCode.Left] = (byte)GetKeyState((int)KeyCode.Left);
            KeyPressTable[(int)KeyCode.Up] = (byte)GetKeyState((int)KeyCode.Up);
            KeyPressTable[(int)KeyCode.Right] = (byte)GetKeyState((int)KeyCode.Right);
            KeyPressTable[(int)KeyCode.Down] = (byte)GetKeyState((int)KeyCode.Down);

            for (int i = 0; i < 256; ++i)
            {
                KeyTriggerTable[i] = (byte)((~PreviousKeyPressTable[i]) & KeyPressTable[i]);
                KeyReleaseTable[i] = (PreviousKeyPressTable[i] & (~KeyPressTable[i])) > 0 ? 1 : 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyTrigger(KeyCode key)
        {
            return KeyTriggerTable[(int)key] > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyPress(KeyCode key)
        {
            return KeyPressTable[(int)key] > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyRelease(KeyCode key)
        {
            return KeyReleaseTable[(int)key] > 0;
        }

        /// <summary>
        /// Gets the key state of a key.
        /// </summary>
        /// <param name="key">Virtuak-key code for key.</param>
        /// <returns>The state of the key.</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
    }
}
