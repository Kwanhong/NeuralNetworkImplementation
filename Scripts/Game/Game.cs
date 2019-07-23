using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkSystem.Consts;
using static NeuralNetworkSystem.Data;

namespace NeuralNetworkSystem
{
    class Game
    {
        public void Run()
        {
            while (window.IsOpen)
            {
                events.HandleEvents();
                Update();
                Display();

                LateUpdate();
            }
        }

        public void Initialize()
        {
            window.SetFramerateLimit(60);

        }

        private void Update()
        {

        }

        private void LateUpdate()
        {
        }

        private void Display()
        {

            window.Display();
            window.Clear(new Color(36, 36, 36));
        }

    }
}