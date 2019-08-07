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
        public List<Action<Vector2f, Mouse.Button>> MousePressedEvents { get; set; }
        public List<Action<Vector2f, Mouse.Button>> MouseReleasedEvents { get; set; }
        public List<Action<Vector2f>> MouseMovedEvents { get; set; }
        public List<Action<Vector2f, float>> MouseScrolledEvents { get; set; }

        public void InitializeOnce()
        {
            window.Closed += OnClosed;
            window.KeyPressed += OnKeyPressed;
            window.MouseButtonPressed += OnMousePressed;
            window.MouseButtonReleased += OnMouseReleased;
            window.MouseMoved += OnMouseMoved;
            window.MouseWheelScrolled += OnMouseScrolled;
            Initialize();
        }

        public void Initialize()
        {
            MousePressedEvents = new List<Action<Vector2f, Mouse.Button>>();
            MouseReleasedEvents = new List<Action<Vector2f, Mouse.Button>>();
            MouseMovedEvents = new List<Action<Vector2f>>();
            MouseScrolledEvents = new List<Action<Vector2f, float>>();
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
                events.Initialize();
                game.Initialize();
            }
        }

        public void OnMousePressed(object sender, MouseButtonEventArgs e)
        {
            if (MousePressedEvents == null) return;

            foreach (var evnt in MousePressedEvents)
                evnt(new Vector2f(e.X, e.Y), e.Button);
        }
        public void OnMouseReleased(object sender, MouseButtonEventArgs e)
        {
            if (MouseReleasedEvents == null) return;

            foreach (var evnt in MouseReleasedEvents)
                evnt(new Vector2f(e.X, e.Y), e.Button);
        }
        public void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            if (MouseMovedEvents == null) return;

            foreach (var evnt in MouseMovedEvents)
                evnt(new Vector2f(e.X, e.Y));
        }
        public void OnMouseScrolled(object sender, MouseWheelScrollEventArgs e)
        {
            if (MouseScrolledEvents == null) return;

            foreach (var evnt in MouseScrolledEvents)
                evnt(new Vector2f(e.X, e.Y), e.Delta);
        }
    }
}