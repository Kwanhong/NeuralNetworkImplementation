using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Utility;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    public struct TrainingDatum
    {
        public TrainingDatum(float[] inputs, float[] targets)
        {
            this.inputs = inputs;
            this.targets = targets;
        }
        public float[] inputs;
        public float[] targets;
    }
    
    class NeuralNetwork
    {
        int InputNodes { get; set; }
        int HiddenNodes { get; set; }
        int OutputNodes { get; set; }

        Matrix weightsIH;
        Matrix weightsHO;
        Matrix biasH;
        Matrix biasO;

        float learningRate;

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

            learningRate = 0.1f;
        }

        public float[] Predict(float[] inputArr)
        {
            var inputs = new Matrix(inputArr);
            var hidden = Matrix.Multiply(weightsIH, inputs);
            hidden.Add(biasH);
            hidden.Map(Sigmoid);

            var output = Matrix.Multiply(weightsHO, hidden);
            output.Add(biasO);
            output.Map(Sigmoid);

            return output.ToArray();
        }

        public void Train(float[] inputArr, float[] targetArr)
        {
            var inputs = new Matrix(inputArr);
            var targets = new Matrix(targetArr);



            var hiddens = Matrix.Multiply(weightsIH, inputs);
            hiddens.Add(biasH);
            hiddens.Map(Sigmoid);

            var outputs = Matrix.Multiply(weightsHO, hiddens);
            outputs.Add(biasO);
            outputs.Map(Sigmoid);



            var ouputErrors = Matrix.Subtract(targets, outputs);

            var outputGradient = Matrix.Map(outputs, DeSigmoid);
            outputGradient.Multiply(ouputErrors);
            outputGradient.Multiply(learningRate);

            var t_hiddens = Matrix.Transpose(hiddens);
            var d_weightsHO = Matrix.Multiply(outputGradient, t_hiddens);
            weightsHO.Add(d_weightsHO);
            biasO.Add(outputGradient);



            var t_weightsHO = Matrix.Transpose(weightsHO);
            var hiddenErrors = Matrix.Multiply(t_weightsHO, ouputErrors);

            var hiddenGradient = Matrix.Map(hiddens, DeSigmoid);
            hiddenGradient.Multiply(hiddenErrors);
            hiddenGradient.Multiply(learningRate);

            var t_inputs = Matrix.Transpose(inputs);
            var d_weightsIH = Matrix.Multiply(hiddenGradient, t_inputs);
            weightsIH.Add(d_weightsIH);
            biasH.Add(hiddenGradient);

        }
    }
}