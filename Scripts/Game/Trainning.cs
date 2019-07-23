using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetwork.Data;
using static NeuralNetwork.Consts;
using static NeuralNetwork.Utility;

namespace NeuralNetwork
{
    class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int Label { get; set; }

        public Point()
        {
            X = Random((float)winSizeX);
            Y = Random((float)winSizeY);

            if (X > Y)
                Label = 1;
            else
                Label = -1;
        }

        public void Display()
        {
            CircleShape point = new CircleShape(4);
            point.Origin = new Vector2f(point.Radius, point.Radius);
            point.Position = new Vector2f(X, Y);
            point.OutlineThickness = 1;
            point.OutlineColor = new Color(100, 100, 100);
            if (Label == -1) point.FillColor = new Color(20, 20, 20);
            else point.FillColor = new Color(70, 70, 70);

            window.Draw(point);
        }
    }
}