using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetwork.Data;

namespace NeuralNetwork
{
    class Game
    {
        Perceptron p;
        public Game()
        {
            Initialize();
            Run();
        }

        private void Run()
        {
            while (window.IsOpen)
            {
                events.HandleEvents();
                Update();
                Display();
            }
        }

        private void Initialize()
        {
            p = new Perceptron();
            float[] inputs = { -1, 0.5f };
            int guess = p.Guess(inputs);
            Console.Write("Guess : " + guess + " ");
        }

        private void Update()
        {

        }

        private void Display()
        {


            window.Display();
            window.Clear(new Color(36, 36, 36));
        }

    }
}