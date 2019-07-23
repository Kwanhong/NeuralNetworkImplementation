using System;
using static NeuralNetwork.Data;

namespace NeuralNetwork
{
    static class MainApp
    {
        static void Main(string[] args)
        {
            events = new Event();
            game = new Game();
            events.Initialize();
            game.Initialize();

            game.Run();
        }
    }
}
