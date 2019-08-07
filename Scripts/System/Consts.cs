using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace NeuralNetworkImplementation
{
    static class Consts
    {
        public const int winFrameLimit = 60;
        public const uint winSizeX = 600;
        public const uint winSizeY = 600;
        public static Color winBackColor = new Color(32, 32, 32);
        public static VideoMode winMode = new VideoMode(winSizeX, winSizeY);
        public static string winTitle = "NEURAL NETWORK";
        public static Styles winStyle = Styles.Resize;
        public static ContextSettings winSettings = new ContextSettings(1, 1, 8);
    }
}