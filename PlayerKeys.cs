using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;

namespace ZelenskiyGame
{
    public static class InputKeyCreator
    {
        public static KeyEventArgs CreateKey(this Keyboard.Key newKey)
        {
            KeyEvent keyEvent = new KeyEvent();
            keyEvent.Code = newKey;
            KeyEventArgs key = new KeyEventArgs(keyEvent);
            key.Code = newKey;
            return key;
        }
    }

    public struct PlayerKeys
    {
        public KeyEventArgs up;
        public KeyEventArgs down;
        public KeyEventArgs left;
        public KeyEventArgs right;
        public KeyEventArgs shoot;
    }

    public static class PlayerKeysCreator
    {
        public static PlayerKeys CreateCustomPlayerKeys(params char[] keys)
        {
            if (keys.Length < 5)
                throw new ArgumentOutOfRangeException("low number of keys");

            PlayerKeys result = new PlayerKeys();
            result.down = keys[0].ToKeyboardKey().CreateKey();
            result.up = keys[1].ToKeyboardKey().CreateKey();
            result.left = keys[2].ToKeyboardKey().CreateKey();
            result.right = keys[3].ToKeyboardKey().CreateKey();
            result.shoot = keys[4].ToKeyboardKey().CreateKey();

            return result;
        }


        private static bool isCorrectCharToConvert(char c)
        {
            return char.IsLetterOrDigit(c);
        }

        private static Keyboard.Key XXX(Keyboard.Key StartKey, char StartChar, char c)
        {
            return (Keyboard.Key)(StartKey + (c - StartChar));
        }

        private static Keyboard.Key ToKeyboardKey(this char c)
        {
            if (!isCorrectCharToConvert(c))
                throw new ArgumentException("Not supported key");

            if(char.IsDigit(c))
            {
                return XXX(Keyboard.Key.Num0, '0', c);
            }
            if ( char.IsUpper(c))
                return XXX(Keyboard.Key.A, 'A', c);
            if(char.IsLower(c))
                return XXX(Keyboard.Key.A, 'a', c);

            throw new Exception("How U get there?!!!");
        }
    }
}
