using System;
using static NeuralNetworkSystem.Data;

namespace NeuralNetworkSystem
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
