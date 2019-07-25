using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    class Event
    {
        public List<Action<Vector2f>> MousePressedEvents { get; set; }
        public List<Action<Vector2f>> MouseReleasedEvents { get; set; }
        public List<Action<Vector2f>> MouseMovedEvents { get; set; }

        public void Initialize()
        {
            window.Closed += OnClosed;
            window.KeyPressed += OnKeyPressed;
            window.MouseButtonPressed += OnMousePressed;
            window.MouseButtonReleased += OnMouseReleased;
            window.MouseMoved += OnMouseMoved;

            MousePressedEvents = new List<Action<Vector2f>>();
            MouseReleasedEvents = new List<Action<Vector2f>>();
            MouseMovedEvents = new List<Action<Vector2f>>();
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

        public void OnMousePressed(object sender, MouseButtonEventArgs e)
        {
            if (MousePressedEvents == null) return;

            foreach (var evnt in MousePressedEvents)
                evnt(new Vector2f(e.X, e.Y));
        }
        public void OnMouseReleased(object sender, MouseButtonEventArgs e)
        {
            if (MouseReleasedEvents == null) return;

            foreach (var evnt in MouseReleasedEvents)
                evnt(new Vector2f(e.X, e.Y));
        }
        public void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            if (MouseMovedEvents == null) return;

            foreach (var evnt in MouseMovedEvents)
                evnt(new Vector2f(e.X, e.Y));
        }
    }
}