using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetwork.Data;
using static NeuralNetwork.Utility;

namespace NeuralNetwork
{
    class Perceptron
    {
        float[] weights = new float[2];

        public Perceptron()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = Random(-1f, 1f);
            }
        }

        public int Guess(float[] inputs)
        {
            float sum = 0;
            for (int i = 0; i < weights.Length; i++)
            { 
                sum += inputs[i] * weights[i];
            }
            return Sign(sum);
        }

        private int Sign(float value)
        {
            if (value >= 0) return 1;
            else return -1;
        }
    }
}