using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace NeuralNetwork
{
    static class Consts
    {
        public const uint winSizeX = 800;
        public const uint winSizeY = 600;
        public static VideoMode winMode = new VideoMode(winSizeX, winSizeY);
        public static string winTitle = "NEURAL NETWORK";
        public static Styles winStyle = Styles.Resize;
        public static ContextSettings winSettings = new ContextSettings(1, 1, 8);
    }
}