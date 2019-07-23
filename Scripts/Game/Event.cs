using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetwork.Data;

namespace NeuralNetwork
{
    class Event
    {
        public void Initialize()
        {
            window.Closed += OnClosed;
            window.KeyPressed += OnKeyPressed;
            window.MouseButtonPressed += OnMouseButtonPressed;
        }

        public void HandleEvents()
        {
            window.DispatchEvents();
        }

        public void OnClosed(object sender, EventArgs e)
        {
            window.Close();
        }

        public void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
            else if (e.Code == Keyboard.Key.F5)
            {
                game.Initialize();
            }
        }

        public void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            game.TrainPerceptron();
        }
    }
}