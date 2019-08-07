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
        Button pass;

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
            brain = new NeuralNetwork(3, 3, 2);

            Vector2f pos = new Vector2f(125, 125);
            Vector2f siz = new Vector2f(250, 250);
            black = new Button(pos, siz, "BLACK\n");
            black.Style.textColor = Color.Black;
            black.Style.FontName = "NANUMGOTHICEXTRABOLD";
            black.ButtonReleasedEvents.Add(ChooseBlack);

            pos = new Vector2f(375, 125);
            white = new Button(pos, siz, "WHITE\n");
            white.Style.textColor = Color.White;
            white.Style.FontName = "NANUMGOTHICEXTRABOLD";
            white.ButtonReleasedEvents.Add(ChooseWhite);

            pos = new Vector2f(250, 375);
            siz = new Vector2f(500, 250);
            pass = new Button(pos, siz, "PASS");
            pass.Style.textColor = Color.White;
            pass.Style.FontName = "NANUMGOTHICEXTRABOLD";
            pass.ButtonReleasedEvents.Add(PickColor);
            pass.Style.fillColor = winBackColor;

        }

        private void Update()
        {
            which = PredictColor(color);
        }

        private void Display()
        {
            pass.Display();
            black.Style.fillColor = color;
            black.Display();
            white.Style.fillColor = color;
            white.Display();

            CircleShape circle = new CircleShape(20, 6);
            circle.Origin = new Vector2f(circle.Radius, circle.Radius);
            if (which == Which.Black)
            {
                circle.Position = new Vector2f(125, 150);
                circle.FillColor = Color.Black;
                window.Draw(circle);
            }
            else
            {
                circle.Position = new Vector2f(375, 150);
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
            var inputs = new float[] { color.R / 255f, color.G / 255f, color.B / 255f };
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

        private void ChooseBlack()
        {
            var inputs = new float[] { color.R / 255f, color.G / 255f, color.B / 255f };
            var targets = new float[] { 1, 0 };
            brain.Train(inputs, targets);
            PickColor();
        }

        private void ChooseWhite()
        {
            var inputs = new float[] { color.R / 255f, color.G / 255f, color.B / 255f };
            var targets = new float[] { 0, 1 };
            brain.Train(inputs, targets);
            PickColor();
        }
    }
}