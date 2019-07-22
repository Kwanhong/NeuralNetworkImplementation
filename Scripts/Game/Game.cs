using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetwork.Data;

namespace NeuralNetwork
{
    class Game
    {
        public Game()
        {
            Initialize();
            Run();
        }

        private void Initialize()
        {
            window.Closed += OnClosed;
            window.KeyPressed += OnKeyPressed;
        }

        private void Run()
        {
            while (window.IsOpen)
            {
                HandleEvents();
                Update();
                Display();
            }
        }

        private void Update()
        {

        }

        private void Display()
        {
            window.Display();
            window.Clear(new Color(36, 36, 36));
        }

        private void HandleEvents()
        {
            window.DispatchEvents();
        }

        private void OnClosed(object sender, EventArgs e)
        {
            window.Close();
        }

        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }
    }
}