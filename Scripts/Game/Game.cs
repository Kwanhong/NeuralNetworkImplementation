using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetwork.Consts;
using static NeuralNetwork.Data;

namespace NeuralNetwork
{
    class Game
    {
        int trainningIndex = 0;
        Perceptron brain;
        Point[] points = new Point[100];

        public Game()
        {
            Initialize();
        }

        public void Run()
        {
            while (window.IsOpen)
            {
                events.HandleEvents();
                Update();
                Display();
            }
        }

        public void Initialize()
        {
            window.SetFramerateLimit(30);
            
            brain = new Perceptron();
            float[] inputs = { -1, 0.5f };
            int guess = brain.Guess(inputs);
            Console.Write("Guess : " + guess);

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point();
            }
        }

        private void Update()
        {

        }

        private void Display()
        {
            foreach (Point point in points)
            {
                point.Display();

                float[] inputs = { point.X, point.Y };
                int target = point.Label;
                int guess = brain.Guess(inputs);

                CircleShape circle = new CircleShape(2);
                circle.Origin = new Vector2f(circle.Radius, circle.Radius);
                circle.Position = new Vector2f(point.X, point.Y);

                circle.OutlineThickness = 1;
                circle.OutlineColor = new Color(100, 100, 100);

                if (guess == target) circle.FillColor = new Color(0, 255, 0);
                else circle.FillColor = new Color(255, 0, 0);

                window.Draw(circle);
            }

            TrainPerceptron();

            VertexArray line = new VertexArray(PrimitiveType.Lines, 2);
            line[0] = new Vertex(new Vector2f(0, 0));
            line[1] = new Vertex(new Vector2f(winSizeX, winSizeY));
            window.Draw(line);

            window.Display();
            window.Clear(new Color(36, 36, 36));
        }

        public void TrainPerceptron()
        {
            Point trainning = points[trainningIndex];
            float[] inputs = { trainning.X, trainning.Y };
            int target = trainning.Label;
            brain.Train(inputs, target);
            
            trainningIndex++;
            if (trainningIndex >= points.Length)
                trainningIndex = 0;

        }
    }
}