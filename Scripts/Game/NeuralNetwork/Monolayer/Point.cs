using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkImplementation.Data;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Utility;

namespace NeuralNetworkImplementation
{
    class Point
    {
        public int Label { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Bias { get => 1; }
        public float PixelX
        {
            get => Map(X, -1, 1, 0, winSizeX);
        }
        public float PixelY
        {
            get => Map(Y, -1, 1, winSizeY, 0);
        }

        public Point()
        {
            X = Random(-1f, 1f);
            Y = Random(-1f, 1f);

            float lineY = Function(X);
            
            if (Y > lineY)
                Label = 1;
            else
                Label = -1;
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
            
            float lineY = Function(X);

            if (Y > lineY)
                Label = 1;
            else
                Label = -1;
        }

        public void Display()
        {
            CircleShape point = new CircleShape(5);
            point.Origin = new Vector2f(point.Radius, point.Radius);

            point.Position = new Vector2f(PixelX, PixelY);
            point.OutlineThickness = 1;
            point.OutlineColor = new Color(70, 70, 70);

            if (Label == -1) {
                point.FillColor = new Color(20, 20, 20);
            }
            else {
                point.FillColor = new Color(100, 100, 100);
            }

            window.Draw(point);
        }
    }
}