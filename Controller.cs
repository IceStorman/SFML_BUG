using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    class Controller
    {
        public Controller(Hero HeroToControll, PlayerKeys PlayerInput)
        {
            hero = HeroToControll;
            InputKeys = PlayerInput;
            MoveDirection = new Dictionary<KeyEventArgs, Direction>()
            {
                {PlayerInput.up, Direction.up },
                {PlayerInput.down, Direction.down },
                {PlayerInput.left, Direction.left },
                {PlayerInput.right, Direction.right }
            };
        }

        private PlayerKeys InputKeys;
        private Hero hero;
        private Dictionary<KeyEventArgs, Direction> MoveDirection;
        
        public void Controll(KeyEventArgs e)
        {
            if (hero == null)
                return;

            CheckInputForMove(e, hero);

            if (e == InputKeys.shoot)
                hero.Shoot();
        }
        private void CheckInputForMove(KeyEventArgs key, Hero hero)
        {
            foreach((KeyEventArgs inputKey, Direction direction) in MoveDirection)
            {
                if (Keyboard.IsKeyPressed(inputKey.Code))
                {
                    hero.body.direction = direction;
                }
            }

            //if (!MoveDirection.ContainsKey(key))
            //    return;

            //hero.body.direction = MoveDirection[key];

            hero.Move();
        }
    }
}
