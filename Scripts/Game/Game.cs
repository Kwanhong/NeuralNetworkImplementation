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

        public void InitializeOnce()
        {
            window.SetFramerateLimit(winFrameLimit);
            Initialize();
        }

        public void Initialize()
        {
            brain = new NeuralNetwork(2, 4, 1);
        }

        private void Update()
        {
            for (int i = 0; i < 1000; i++)
            {
                var data = Random(trainingData);
                brain.Train(data.inputs, data.targets);
            }
        }

        private void Display()
        {
            var res = 10;
            var cols = winSizeX / res;
            var rows = winSizeY / res;
            for (var i = 0; i < cols; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    var x1 = (float)i / cols;
                    var x2 = (float)j / rows;
                    var inputs = new float[] { x1, x2 };
                    var y = brain.Predict(inputs)[0];

                    var brightness = (byte)(y * 255f);
                    RectangleShape rect = new RectangleShape(new Vector2f(res, res));
                    rect.Position = new Vector2f(res * i, res * j);
                    rect.FillColor = new Color(brightness, brightness, brightness);
                    window.Draw(rect);
                }
            }


            window.Display();
            window.Clear(winBackColor);
        }

        private void LateUpdate()
        {
        }
    }
}