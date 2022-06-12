using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    class Hero : Character, IPlayable
    {
        public int count = 0;
        public Hero() : base()
        {
            image = new Image("Images/skull.png");
            lives = 10;
            count = 0;
            spawnPosition = new Vector2f(600, 500);
            speed = 6.5f;
            body = new Body(image, 13, 65, 65, 10, new Vector2i(38, 54));
            body.Position = spawnPosition;
            body.SetPosition(Direction.up, Direction.left, Direction.down, Direction.right);
            face = body;
            body.direction = Direction.left;
        }
    }
}
