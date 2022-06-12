using System;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ZelenskiyGame
{
    class Logic
    {
        public PhysicalObjectsList list;
        public NPCFactory factory;
        protected RenderWindow window;
        public Hero hero;
        public Logic(RenderWindow window)
        {
            this.window = window;
            list = new PhysicalObjectsList(window);
            hero = new Hero();
            list.Add(hero);
            factory = new NPCFactory();
        }
        public void Update()
        {
            list.Create();
        }
    }
}
