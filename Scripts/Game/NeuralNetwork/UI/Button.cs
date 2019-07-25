using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    class Button
    {
        public Vector2f Position { get; set; }
        public Vector2f Size { get; set; }
        public Font Font { get; set; }
        public string Caption { get; set; }
        public bool Enabled { get; set; }
        public bool IsPressed { get; set; }

        public List<Action> ButtonPressedEvents { get; set; }
        public List<Action> ButtonReleasedEvents { get; set; }

        private byte alpha;

        public Button(Vector2f position, Vector2f size, string caption)
        {
            this.Font = new Font("Resources\\Fonts\\NANUMGOTHICLIGHT.TTF");
            this.Position = position;
            this.Size = size;
            this.Caption = caption;

            Enabled = true;
            IsPressed = false;
            alpha = 150;

            ButtonPressedEvents = new List<Action>();
            ButtonReleasedEvents = new List<Action>();

            events.MouseMovedEvents.Add(OnMouseMoved);
            events.MouseReleasedEvents.Add(OnMouseReleased);
            events.MousePressedEvents.Add(OnMousePressed);
        }

        public void Update()
        {

        }

        public void Display()
        {
            RectangleShape rect = new RectangleShape(Size);
            rect.Origin = this.Size / 2;
            rect.Position = this.Position;
            rect.FillColor = new Color(255, 255, 255, alpha);
            window.Draw(rect);

            Text text = new Text(Caption, Font);
            text.Origin = new Vector2f(text.GetGlobalBounds().Width *0.52f, text.GetGlobalBounds().Height*0.9f);
            text.Position = rect.Position;
            text.FillColor = Color.Black;
            window.Draw(text);
        }

        private void OnMousePressed(Vector2f mousePos)
        {
            if (OnTheButton(mousePos))
            {
                IsPressed = true;
                alpha = 100;

                foreach (var evnt in ButtonPressedEvents)
                    evnt();

            }
        }

        private void OnMouseReleased(Vector2f mousePos)
        {
            if (!IsPressed) return;
            IsPressed = false;

            if (OnTheButton(mousePos))
            {
                alpha = 255;

                foreach (var evnt in ButtonReleasedEvents)
                    evnt();
            }
            else
            {
                alpha = 150;
            }
        }

        private void OnMouseMoved(Vector2f mousePos)
        {
            if (IsPressed) return;

            if (OnTheButton(mousePos))
            {
                alpha = 255;
            }
            else
            {
                alpha = 150;
            }
        }

        private bool OnTheButton(Vector2f mousePos)
        {
            if (mousePos.X > Position.X - Size.X / 2 &&
                mousePos.X < Position.X + Size.X / 2 &&
                mousePos.Y > Position.Y - Size.Y / 2 &&
                mousePos.Y < Position.Y + Size.Y / 2)
                return true;
            else
                return false;
        }
    }
}