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

            /// <summary>
            /// 
            /// </summary>
            A = 65,

            /// <summary>
            /// 
            /// </summary>
            S = 83,

            /// <summary>
            /// 
            /// </summary>
            X = 88,

            /// <summary>
            /// 
            /// </summary>
            Z = 90
        }

        /// <summary>
        /// 
        /// </summary>
        public static Input Instance { get; private set; } = new Input();

        /// <summary>
        /// 
        /// </summary>
        private const int KeyTableSize = 256;

        /// <summary>
        /// 
        /// </summary>
        private int[] KeyPressTable { get; set; } = new int[KeyTableSize];

        /// <summary>
        /// 
        /// </summary>
        private int[] KeyReleaseTable { get; set; } = new int[KeyTableSize];

        /// <summary>
        /// 
        /// </summary>
        private int[] KeyTriggerTable { get; set; } = new int[KeyTableSize];

        /// <summary>
        /// 
        /// </summary>
        private int[] PreviousKeyPressTable { get; set; } = new int[KeyTableSize];

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            Array.Copy(KeyPressTable, PreviousKeyPressTable, KeyPressTable.Length);

            for (int i = 0; i < KeyTableSize; ++i)
            {
                KeyPressTable[i] = 0;
                KeyTriggerTable[i] = 0;
                KeyReleaseTable[i] = 0;
            }

            foreach (KeyCode value in Enum.GetValues(typeof(KeyCode)))
            {
                KeyPressTable[(int)value] = (byte)GetAsyncKeyState((int)value);
            }

            for (int i = 0; i < KeyTableSize; ++i)
            {
                KeyTriggerTable[i] = (byte)((~PreviousKeyPressTable[i]) & KeyPressTable[i]);
                KeyReleaseTable[i] = (PreviousKeyPressTable[i] & (~KeyPressTable[i]));
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
        private static extern int GetAsyncKeyState(int nVirtKey);
    }
}
