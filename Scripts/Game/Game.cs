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
        Point[] points = new Point[1000];

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

            brain = new Perceptron(3);

            for (int i = 0; i < points.Length; i++)
                points[i] = new Point();
        }

        private void Update()
        {

        }

        private void LateUpdate()
        {
            TrainPerceptron();
        }

        public void TrainPerceptron()
        {
            Point trainning = points[trainningIndex];
            float[] inputs = { trainning.X, trainning.Y, trainning.Bias };
            int target = trainning.Label;
            brain.Train(inputs, target);

            trainningIndex++;
            if (trainningIndex >= points.Length)
                trainningIndex = 0;

        }

        private void Display()
        {
            DisplayLine();
            DisplayPoints();

            window.Display();
            window.Clear(new Color(36, 36, 36));
        }

        private void DisplayPoints()
        {
            foreach (Point point in points)
            {
                point.Display();

                float[] inputs = { point.X, point.Y, point.Bias};
                int target = point.Label;
                int guess = brain.Guess(inputs);

                CircleShape circle = new CircleShape(2);
                circle.Origin = new Vector2f(circle.Radius, circle.Radius);
                circle.Position = new Vector2f(point.PixelX, point.PixelY);
                circle.OutlineThickness = 1;
                circle.OutlineColor = new Color(100, 100, 100);

                if (guess == target) circle.FillColor = new Color(0, 255, 0,150);
                else circle.FillColor = new Color(255, 0, 0,200);

                window.Draw(circle);
            }
        }

        private void DisplayLine()
        {
            VertexArray line = new VertexArray(PrimitiveType.Lines, 2);
            
            Point p1 = new Point(-1, Function(-1));
            Point p2 = new Point(1, Function(1));
            line[0] = new Vertex(new Vector2f(p1.PixelX, p1.PixelY), new Color(150,150,150));
            line[1] = new Vertex(new Vector2f(p2.PixelX, p2.PixelY),new Color(150,150,150));
            window.Draw(line);

            Point p3 = new Point(-1, brain.GuessY(-1));
            Point p4 = new Point(1, brain.GuessY(1));
            line[0] = new Vertex(new Vector2f(p3.PixelX, p3.PixelY),new Color(150,150,150));
            line[1] = new Vertex(new Vector2f(p4.PixelX, p4.PixelY),new Color(150,150,150));
            window.Draw(line);
        }

        public float Function(float x)
        {
            return 0.3f * x + 0.2f;
        }

    }
}