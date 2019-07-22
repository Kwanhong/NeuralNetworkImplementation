using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetwork.Consts;

namespace NeuralNetwork
{
    static class Data
    {
        public static RenderWindow window = new RenderWindow
        (
            winMode,
            winTitle,
            winStyle,
            winSettings
        );
    }
}