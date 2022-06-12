using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    class Body : Sprite
    {
        public Vector2i size;
        //------------------------Sprite-----------------------------//
        protected int startingPositionX; //top left corner of the current texture
        protected int textureLength; //distance from the top left corner of the current texture to the top left corner of the next texture
        protected int textureHeight; 
        public int stepCounter;
        public int upGap;
        protected int spriteStep;
        public List<Direction> directions;
        public Direction direction;
        //----------------------------------------------------------//
        public Body(Image image)
        {
            Texture = new Texture(image);
            this.startingPositionX = 0;
            this.textureLength = 0;
            this.upGap = 0;
            this.textureHeight = 0;
            this.size = (Vector2i)(image.Size);
            TextureRect = new IntRect(new Vector2i(startingPositionX, textureHeight), size);
            directions = new List<Direction>();
        }

        public Body(Image image, int start, int Lenght, int Height, int upGap, Vector2i size)
        {
            Texture = new Texture(image);
            this.startingPositionX = start;
            this.textureLength = Lenght;
            this.upGap = upGap;
            this.textureHeight = Height;
            this.size = size;
            TextureRect = new IntRect(new Vector2i(startingPositionX, textureHeight), size);
            directions = new List<Direction>();
        }

        public void SetPosition(Direction one, Direction two, Direction three, Direction four)
        {
            directions.Add(one);
            directions.Add(two);
            directions.Add(three);
            directions.Add(four);
        }

        public void MoveUp()
        {
            if (spriteStep >= Texture.Size.X)
                spriteStep = 0;
            TextureRect = new IntRect(new Vector2i(startingPositionX + spriteStep, upGap + textureHeight * directions.IndexOf(Direction.up)), size);
            spriteStep += textureLength;
        }
        public void MoveDown()
        {
            if (spriteStep >= Texture.Size.X)
                spriteStep = 0;
            TextureRect = new IntRect(new Vector2i(startingPositionX + spriteStep, upGap + textureHeight * directions.IndexOf(Direction.down)), size);
            spriteStep += textureLength;
        }
        public void MoveRight()
        {
            if (spriteStep >= Texture.Size.X)
                spriteStep = 0;
            TextureRect = new IntRect(new Vector2i(startingPositionX + spriteStep, upGap + textureHeight * directions.IndexOf(Direction.right)), size);
            spriteStep += textureLength;
        }
        public void MoveLeft()
        {
            if (spriteStep >= Texture.Size.X)
                spriteStep = 0;
            TextureRect = new IntRect(new Vector2i(startingPositionX + spriteStep, upGap + textureHeight * directions.IndexOf(Direction.left)), size);
            spriteStep += textureLength;
        }
    }
}
