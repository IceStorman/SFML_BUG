using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    class Game
    {
        RenderWindow window;
        Controller controller;
        Logic logic;
        public Game()
        {
            window = new RenderWindow(new VideoMode(1200, 800), "Game");
            window.Closed += WindowCloser;
            window.KeyPressed += WindowKeyPresser;
            window.Resized += NoResize;
            logic = new Logic(window);
            CreateHeroes();
        }
        private void CreateHeroes()
        {
            PlayerKeys playerKeys = new PlayerKeys();
            playerKeys = PlayerKeysCreator.CreateCustomPlayerKeys('S', 'W', 'A', 'D', 'F');
            controller = new Controller(logic.hero, playerKeys);

        }
        public void Play()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Black);
                logic.Update();
                window.Display();
            }
        }
        private void NoResize(object sender, SizeEventArgs e)
        {
            window.Size = new Vector2u(1200, 800);
        }
        private void WindowKeyPresser(object sender, KeyEventArgs e)
        {
            controller.Controll(e);
        }

        private void WindowCloser(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
