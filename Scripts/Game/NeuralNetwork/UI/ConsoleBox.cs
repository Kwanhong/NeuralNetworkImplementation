using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    public class ConsoleBox
    {
        public const uint MaxCharSize = 75;
        public const uint MinCharSize = 5;
        public enum ViewMode { Left, Right, Top, Bott }
        public Vector2f Position { get; set; }
        public Vector2f Origin { get; set; }
        public Vector2f Size { get; set; }
        public Color BackColor { get; set; }
        public Color TextColor { get; set; }
        public string String
        {
            get => str; set
            {
                str = value;
                if (text != null)
                {
                    text.DisplayedString = str;
                    ResetTextBox();
                }
            }
        }
        private Text text;
        private string str;
        private Font font;
        private RenderTexture texture;
        private View view;
        private bool isDragging;
        private Vector2f delta;
        private Vector2f textBox;

        public ConsoleBox(Vector2f position, Vector2f size)
        {
            this.Position = position;
            this.Size = size;
            this.Origin = size / 2;

            this.font = new Font("Resources\\Fonts\\NANUMGOTHICLIGHT.TTF");
            this.text = new Text(String, font);
            this.text.CharacterSize = 15;
            this.BackColor = new Color(50, 50, 50);
            this.TextColor = Color.White;
            this.texture = new RenderTexture((uint)Size.X, (uint)Size.Y);
            this.view = new View(new FloatRect(0, 0, Size.X, Size.Y));
            this.String = "";

            this.isDragging = false;

            events.MouseMovedEvents.Add(OnMouseMoved);
            events.MouseReleasedEvents.Add(OnMouseReleased);
            events.MousePressedEvents.Add(OnMousePressed);
            events.MouseScrolledEvents.Add(OnMouseScrolled);
        }

        public void Update()
        {
            var newView = view.Center;

            if (textBox.X < this.Size.X)
            {
                if (newView.X - textBox.X < -Origin.X)
                    newView.X = textBox.X - Origin.X;

                if (newView.X > Origin.X)
                    newView.X = Origin.X;
            }
            else
            {
                if (newView.X - textBox.X > -Origin.X)
                    newView.X = textBox.X - Origin.X;

                if (newView.X < Origin.X)
                    newView.X = Origin.X;
            }

            if (textBox.Y < this.Size.Y)
            {
                if (newView.Y - textBox.Y < -Origin.Y)
                    newView.Y = textBox.Y - Origin.Y;

                if (newView.Y > Origin.Y)
                    newView.Y = Origin.Y;
            }
            else
            {
                if (newView.Y < Origin.Y)
                    newView.Y = Origin.Y;

                if (newView.Y - textBox.Y > -Origin.Y)
                    newView.Y = textBox.Y - Origin.Y;
            }

            view.Center = newView;
        }

        public void Display()
        {
            texture.SetView(view);
            texture.Clear(BackColor);

            text.Position = this.Position - this.Origin + new Vector2f(0, 30);
            text.FillColor = this.TextColor;
            texture.Draw(text);

            texture.Display();

            Sprite rect = new Sprite(texture.Texture);
            rect.Origin = this.Origin;
            rect.Position = this.Position;
            window.Draw(rect);

            Vector2f tbSize = new Vector2f(this.Size.X, 30);
            Vector2f tbOrigin = tbSize / 2;
            Vector2f tbPosition = this.Position - this.Origin + new Vector2f(this.Origin.X, tbOrigin.Y);
            Color tbColor = new Color(43, 43, 43);
            RectangleShape toolBar = new RectangleShape(tbSize);
            toolBar.Origin = tbOrigin;
            toolBar.Position = tbPosition;
            toolBar.FillColor = tbColor;
            window.Draw(toolBar);

            Text tbText = new Text("CONSOLE", font);
            tbText.CharacterSize = 14;
            tbText.Position = toolBar.Position + new Vector2f(5, 5);
            tbText.Origin = toolBar.Origin;
            tbText.FillColor = new Color(125, 125, 125);
            window.Draw(tbText);
        }

        public void Write(object str)
        {
            this.String += str;
        }

        public void WriteLine(object str)
        {
            this.String += str + "\n";
        }

        public void Endline(int times = 1)
        {
            for (int i = 0; i < times; i++)
                this.String += "\n";
        }

        public void Clear()
        {
            SetView(ViewMode.Left);
            SetView(ViewMode.Top);
            this.String = "";
        }

        public void SetView(ViewMode viewMode)
        {
            switch (viewMode)
            {
                case ViewMode.Left:
                    if (textBox.X > this.Size.X)
                        view.Center = new Vector2f(Origin.X, view.Center.Y);
                    break;
                case ViewMode.Right:
                    if (textBox.X > this.Size.X)
                        view.Center = new Vector2f(textBox.X - Origin.X, view.Center.Y);
                    break;
                case ViewMode.Top:
                    if (textBox.Y > this.Size.Y)
                        view.Center = new Vector2f(view.Center.X, Origin.Y);
                    break;
                case ViewMode.Bott:
                    if (textBox.Y > this.Size.Y)
                        view.Center = new Vector2f(view.Center.X, textBox.Y - Origin.Y);
                    break;
            }
        }

        private void OnMousePressed(Vector2f mousePos)
        {
            if (!OnTheConsole(mousePos)) return;

            isDragging = true;
            delta = -mousePos - view.Center;
        }

        private void OnMouseMoved(Vector2f mousePos)
        {
            if (!isDragging) return;
            var newView = -mousePos - delta;
            view.Center = newView;
        }

        private void OnMouseReleased(Vector2f mousePos)
        {
            if (!isDragging) return;
            isDragging = false;
        }

        private bool OnTheConsole(Vector2f mousePos)
        {
            if (mousePos.X > Position.X - Origin.X &&
                mousePos.X < Position.X + Origin.X &&
                mousePos.Y > Position.Y - Origin.Y &&
                mousePos.Y < Position.Y + Origin.Y)
                return true;
            else
                return false;
        }

        private void OnMouseScrolled(Vector2f mousePos, float delta)
        {
            if (!OnTheConsole(mousePos)) return;
            
            text.CharacterSize += (uint)(delta);
            if (delta > 0 && text.CharacterSize > MaxCharSize)
                text.CharacterSize = MaxCharSize;
            if (delta < 0 && text.CharacterSize < MinCharSize)
                text.CharacterSize = MinCharSize;

            ResetTextBox();
        }

        private void ResetTextBox()
        {
            this.textBox = new Vector2f
            (
               text.GetGlobalBounds().Width + 30,
               text.GetGlobalBounds().Height + 60 - text.CharacterSize * 1.6f
            );
        }
    }
}