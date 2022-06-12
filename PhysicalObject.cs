using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    abstract class PhysicalObject:GameObject
    {
        public int lives;
        protected Image image;
        public Body body;
        public bool IsAlive = true;

        public PhysicalObject()
        {
            face = body;
        }
        protected void Remove()//deleting
        {
            IsAlive = false;
        }
        public void RestInPeace()//unique death for each single object
        {
            Remove();
        }
        public Box GetBox()
        {
            Box result;
            result.bottom = body.size.Y + body.Position.Y;
            result.top = body.Position.Y;
            result.left = body.Position.X;
            result.right = body.size.X + body.Position.X;
            return result;
        }
        public virtual void OnCollisionReact(PhysicalObject i)
        {
        }
        public virtual void BorderReact()
        {

        }
    }
}
