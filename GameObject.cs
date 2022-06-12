using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    abstract class GameObject
    {
        public Drawable face;
        public virtual void Draw(RenderWindow window)
        {
            window.Draw(face);
        }
    }
}
