using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    static class Movement
    {
        public static void Move(Body body, float speed)
        {
            float x = body.Position.X;
            float y = body.Position.Y;
            switch (body.direction)
            {
                case Direction.left:
                    MoveLeft(x, y, body, speed);
                    break;
                case Direction.up:
                    MoveUp(x, y, body, speed);
                    break;
                case Direction.down:
                    MoveDown(x, y, body, speed);
                    break;
                case Direction.right:
                    MoveRight(x, y, body, speed);
                    break;
            }
            body.stepCounter++;
        }
        private static void MoveUp(float x, float y, Body body, float speed)
        {
            body.Position = new Vector2f(x, y - speed);
            body.MoveUp();
            body.direction = Direction.up;
        }
        private static void MoveDown(float x, float y, Body body, float speed)
        {
            body.Position = new Vector2f(x, y + speed);
            body.MoveDown();
            body.direction = Direction.down;
        }
        private static void MoveRight(float x, float y, Body body, float speed)
        {
            body.Position = new Vector2f(x + speed, y);
            body.MoveRight();
            body.direction = Direction.right;
        }
        private static void MoveLeft(float x, float y, Body body, float speed)
        {
            body.Position = new Vector2f(x - speed, y);
            body.MoveLeft();
            body.direction = Direction.left;
        }
    }
}
