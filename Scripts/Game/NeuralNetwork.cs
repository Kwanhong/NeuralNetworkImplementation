using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    class NeuralNetwork
    {
        int InputNodes;
        int HiddenNodes;
        int OutputNodes;

        public NeuralNetwork(int inputCnt, int hidenCnt, int outputCnt)
        {
            InputNodes = inputCnt;
            HiddenNodes = hidenCnt;
            OutputNodes = outputCnt;
        }

        public int FeedForward()
        {
            return guess;
        }
    }
}