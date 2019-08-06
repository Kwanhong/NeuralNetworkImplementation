using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkImplementation.Consts;

namespace NeuralNetworkImplementation
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
        public static Event events;
        public static Game game;

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
        public static TrainingDatum[] trainingData = new TrainingDatum[]
        {
            new TrainingDatum
            (
                inputs : new float[] { 0, 1 },
                targets : new float[] { 1 }
            ),
            new TrainingDatum
            (
                inputs : new float[] { 1, 0 },
                targets : new float[] { 1 }
            ),
            new TrainingDatum
            (
                inputs : new float[] { 0, 0 },
                targets : new float[] { 0 }
            ),
            new TrainingDatum
            (
                inputs : new float[] { 1, 1 },
                targets : new float[] { 0 }
            )
        };
    }
}