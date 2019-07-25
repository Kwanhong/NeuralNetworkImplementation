using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Utility;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    class Game
    {
        NeuralNetwork brain;
        Button button;

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

            Vector2f pos = new Vector2f(winSizeX * 0.9f, winSizeY * 0.94f);
            Vector2f siz = new Vector2f(100, 50);
            button = new Button(pos, siz, "RUN");

            button.ButtonReleasedEvents.Add(Think);
        }

        private void Update()
        {

        }

        private void LateUpdate()
        {

        }

        private void Display()
        {
            button.Display();

            window.Display();
            window.Clear(winBackColor);
        }

        private void Think()
        {
            brain = new NeuralNetwork(2, 2, 1);
            var input = new Matrix(ColVec(1, 0));
            var output = brain.FeedForward(Matrix.Transpose(input));

            foreach (var element in output)
                Console.Write(element + " ");
            Console.WriteLine();
        }

    }
}