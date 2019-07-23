using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    class Game
    {
        NeuralNetwork brain;

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
            window.SetFramerateLimit(winFrameLimit);

            var a = new Matrix(2, 3);
            var b = new Matrix(3, 2);
            a.Add(2);
            b.Add(3);
            var c = a.Multiply(b);

            brain = new NeuralNetwork(3, 3, 1);
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
            window.Clear(winBackColor);
        }

    }
}