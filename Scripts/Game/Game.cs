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
        Button clear;
        ConsoleBox console;

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

        public void InitializeOnce(){
            window.SetFramerateLimit(winFrameLimit);
            Initialize();
        }

        public void Initialize()
        {
            Vector2f pos  = new Vector2f(winSizeX * 0.5f, winSizeY * 0.45f);
            Vector2f siz  = new Vector2f(577, 512);
            console = new ConsoleBox(pos, siz);

            pos = new Vector2f(winSizeX * 0.44f, winSizeY * 0.94f);
            siz = new Vector2f(120, 50);
            clear = new Button(pos, siz, "CLEAR");
            clear.ButtonReleasedEvents.Add(console.Clear);

            pos = new Vector2f(winSizeX * 0.66f, winSizeY * 0.94f);
            siz = new Vector2f(120, 50);
            think = new Button(pos, siz, "THINK");
            think.ButtonReleasedEvents.Add(Think);

            pos = new Vector2f(winSizeX * 0.88f, winSizeY * 0.94f);
            siz = new Vector2f(120, 50);
            train = new Button(pos, siz, "TRAIN");
            train.ButtonReleasedEvents.Add(Train);

        }

        private void Update()
        {
            console.Update();
        }

        private void LateUpdate()
        {

        }

        private void Display()
        {
            console.Display();
            clear.Display();
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
                    console.Write(element);
                console.Endline();
            }
            console.Endline();
            console.SetView(ConsoleBox.ViewMode.Bott);
        }

        private void Think()
        {
            brain = new NeuralNetwork(2, 2, 1);
            var inputs = new float[] { 1, 0 };
            var outputs = brain.FeedForward(inputs);

            foreach (var element in outputs)
                console.Write(element + " ");
            console.Endline(2);
            console.SetView(ConsoleBox.ViewMode.Bott);
        }

    }
}