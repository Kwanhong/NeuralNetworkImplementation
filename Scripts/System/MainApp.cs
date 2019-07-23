using System;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
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
