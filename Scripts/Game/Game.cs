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
        enum Which { Black, White };
        NeuralNetwork brain;
        Color color;
        Which which = Which.Black;
        Button black;
        Button white;

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
            PickColor();
            events.MouseReleasedEvents.Add(MouseClick);
            brain = new NeuralNetwork(3, 3, 2);

            Vector2f pos = new Vector2f(125, 125);
            Vector2f siz = new Vector2f(250, 250);
            black = new Button(pos, siz, "BLACK");
            black.Style.textColor = Color.Black;
            pos = new Vector2f(375, 125);
            white = new Button(pos, siz, "WHITE");
            white.Style.textColor = Color.White;
        }

        private void Update()
        {
            which = PredictColor(color);
        }

        private void Display()
        {
            black.Style.fillColor = color;
            black.Display();
            white.Style.fillColor = color;
            white.Display();

            CircleShape circle = new CircleShape(30);
            if (which == Which.Black)
            {
                circle.Position = new Vector2f(140, 120);
                circle.FillColor = Color.Black;
                window.Draw(circle);
            }
            else
            {
                circle.Position = new Vector2f(300, 120);
                circle.FillColor = Color.White;
                window.Draw(circle);
            }

            window.Display();
            window.Clear(winBackColor);
        }

        private void LateUpdate()
        {
        }

        private Which PredictColor(Color color)
        {
            var inputs = new float[] { color.R / 255, color.G / 255, color.B / 255 };
            var ouptuts = brain.Predict(inputs);

            if (ouptuts[0] > ouptuts[1])
                return Which.Black;
            else
                return Which.White;
        }

        private void PickColor()
        {
            color = new Color
            (
                (byte)Random(255),
                (byte)Random(255),
                (byte)Random(255)
            );
        }

        private void MouseClick(Vector2f mousePos, Mouse.Button button)
        {
            PickColor();
        }
    }
}