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
        Button think;
        Button train;

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

            Vector2f pos = new Vector2f(winSizeX * 0.65f, winSizeY * 0.94f);
            Vector2f siz = new Vector2f(120, 50);
            think = new Button(pos, siz, "THINK");

            think.ButtonReleasedEvents.Add(Think);
            
            pos = new Vector2f(winSizeX * 0.85f, winSizeY * 0.94f);
            siz = new Vector2f(120, 50);
            train = new Button(pos, siz, "TRAIN");

            train.ButtonReleasedEvents.Add(Train);
        }

        private void Update()
        {

        }

        private void LateUpdate()
        {

        }

        private void Display()
        {
            think.Display();
            train.Display();

            window.Display();
            window.Clear(winBackColor);
        }

        private void Train()
        {
            brain = new NeuralNetwork(2, 2, 1);

            for (var i = 0; i < 10000; i++)
            {
                foreach (var data in trainingData)
                    brain.Train(data.inputs, data.targets);
            }

            foreach (var data in trainingData)
            {
                foreach (var element in brain.FeedForward(data.inputs))
                    Console.Write(element);
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        private void Think()
        {
            brain = new NeuralNetwork(2, 2, 1);
            var inputs = new float[] { 1, 0 };
            var outputs = brain.FeedForward(inputs);

            foreach (var element in outputs)
                Console.Write(element + " ");
            Console.WriteLine();
        }

    }
}