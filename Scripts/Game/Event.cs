using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkSystem.Data;

namespace NeuralNetworkSystem
{
    class Event
    {
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
            else if (e.Code == Keyboard.Key.F5)
            {
                game.Initialize();
            }
        }
    }
}