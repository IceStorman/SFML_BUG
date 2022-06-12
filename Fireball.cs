using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    class Fireball : PhysicalObject, IsMoveable
    {
        public Character sender;
        public int damage = 1;
        public float speed = 5.5f;

        public Fireball(Character character) : base()
        {
            image = new Image("Images/Fireball.png");
            sender = character;
            body = new Body(image);
            body.Position = character.body.Position;
            body.direction = character.body.direction;
            face = body;
        }

        public void Move()
        {
            Movement.Move(body, speed);
        }

        public override void BorderReact()
        {
            RestInPeace();
            base.BorderReact();
        }

        public override void Draw(RenderWindow window)
        {
            Move();
            base.Draw(window);
        }

        public override void OnCollisionReact(PhysicalObject i)
        {
            if (i is NPC && i != sender)
            {
                i.lives -= damage;
                if (sender is Hero)
                    ((Hero)sender).count += ((NPC)i).point;
                RestInPeace();
            }
            else if (i != sender)
            {
                i.RestInPeace();
                RestInPeace();
            }
        }
    }
}
