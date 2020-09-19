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
        /// A positional bit flag indicating the part of a key state denoting
        /// key pressed.
        /// </summary>
        private const int KeyPressed = 0x8000;

        /// <summary>
        /// 
        /// </summary>
        private byte[] KeyPressTable { get; set; } = new byte[256];

        /// <summary>
        /// 
        /// </summary>
        private byte [] KeyReleaseTable { get; set; } = new byte[256];

        /// <summary>
        /// 
        /// </summary>
        private byte[] KeyTriggerTable { get; set; } = new byte[256];

        /// <summary>
        /// 
        /// </summary>
        private byte[] PreviousKeyPressTable { get; set; } = new byte[256];

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            Array.Copy(KeyPressTable, PreviousKeyPressTable, KeyPressTable.Length);

            GetKeyboardState(KeyPressTable);

            for (int i = 0; i < 256; ++i)
            {
                KeyTriggerTable[i] = (byte)((~PreviousKeyPressTable[i]) & KeyPressTable[i]);
                KeyReleaseTable[i] = (byte)(PreviousKeyPressTable[i] & (~KeyPressTable[i]));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyTrigger(KeyCode key)
        {
            return (KeyTriggerTable[((int)key & 0xFF)] & 0x80) > 0;
        }

        /// <summary>
        /// Returns a value indicating if a given key is pressed.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>
        /// <c>true</c> if the key is pressed, otherwise <c>false</c>.
        /// </returns>
        public static bool IsKeyDown(KeyCode key)
        {
            return (GetKeyState((int)key) & KeyPressed) != 0;
        }
        
        /// <summary>
        /// Gets the key state of a key.
        /// </summary>
        /// <param name="key">Virtuak-key code for key.</param>
        /// <returns>The state of the key.</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);
    }
}
