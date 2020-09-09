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
    }
}
