using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkImplementation.Data;
using static NeuralNetworkImplementation.Utility;

namespace NeuralNetworkImplementation
{
    class Perceptron
    {
        float[] weights;
        float learningRate = 0.01f;

        public Perceptron(int count)
        {
            weights = new float[count];
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

        public float GuessY(float x) {
            float w0 = weights[0];
            float w1 = weights[1];
            float w2 = weights[2];
            
            return -(w2/w1) - (w0/w1) * x;
        }

        public void Train(float[] inputs, int target) {
            int guess = Guess(inputs);
            int error = target - guess;

            for (int i = 0; i  < weights.Length; i++) {
                weights[i] += error * inputs[i] * learningRate; 
            }
        }

        private int Sign(float value)
        {
            if (value >= 0) return 1;
            else return -1;
        }
    }
}