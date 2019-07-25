using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Utility;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    class NeuralNetwork
    {
        int InputNodes { get; set; }
        int HiddenNodes { get; set; }
        int OutputNodes { get; set; }

        Matrix weightsIH;
        Matrix weightsHO;
        Matrix biasH;
        Matrix biasO;

        public NeuralNetwork(int inputNodes, int hidenNodes, int outpuNodes)
        {
            this.InputNodes = inputNodes;
            this.HiddenNodes = hidenNodes;
            this.OutputNodes = outpuNodes;

            weightsIH = new Matrix(this.HiddenNodes, this.InputNodes);
            weightsHO = new Matrix(this.OutputNodes, this.HiddenNodes);
            weightsIH.Randomize(-1, 1);
            weightsHO.Randomize(-1, 1);

            biasH = new Matrix(this.HiddenNodes, 1);
            biasO = new Matrix(this.OutputNodes, 1);
            biasH.Add(1);
            biasO.Add(1);
        }

        public float[] FeedForward(Matrix input)
        {
            Func<float, float> sigmoid = Sigmoid;

            var hidden = Matrix.Multiply(weightsIH, input);
            hidden.Add(biasH);
            hidden.Map(sigmoid);

            var output = Matrix.Multiply(weightsHO, hidden);
            output.Add(biasO);
            hidden.Map(sigmoid);

            return output.ToArray();
        }
    }
}