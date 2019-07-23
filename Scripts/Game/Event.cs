using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetwork.Data;

namespace NeuralNetwork
{
    class Event
    {
        public Event()
        {
            Initialize();
        }

        public void Initialize()
        {
            window.Closed += OnClosed;
            window.KeyPressed += OnKeyPressed;
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
        }
    }
}