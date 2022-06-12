using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    abstract class Character : PhysicalObject, IsMoveable
    {
        public PhysicalObjectsList ChildrenList;
        public float speed;
        protected Vector2f spawnPosition;
        public Character() : base()
        {
            ChildrenList = new PhysicalObjectsList();
            face = body;
        }

        public void Move()
        {
            Movement.Move(body, speed);
        }

        public void Shoot()
        {
            Fireball fireball = new Fireball(this);
            ChildrenList.Add(fireball);
        }

        public void ChildrenCheck()
        {
            for (int i = 0; i < ChildrenList.Count; i++)
            {
                if (ChildrenList.AlivenessCheckByIndex(i))
                {
                    ChildrenList.RemoveByIndex(i);
                    i--;
                }
            }
        }
    }
}
