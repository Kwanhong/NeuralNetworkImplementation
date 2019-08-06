using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    class Matrix
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public float[][] Data { get; set; }

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;

            Data = new float[Rows][];
            for (int x = 0; x < Rows; x++)
                Data[x] = new float[Cols];

            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    Data[x][y] = 0;
        }

        public Matrix(float[][] data)
        {
            this.Rows = data.Length;
            this.Cols = data[0].Length;
            this.Data = data;
        }

        public Matrix(float[] data)
        {
            this.Rows = data.Length;
            this.Cols = data[0].Length;
            
            this.Data = new float[0][];
            this.Data[0] = data;
        }

        public void Randomize(float min = -1, float max = 1)
        {
            Random rnd = new Random();
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    Data[x][y] = Utility.Map((float)rnd.NextDouble(), 0, 1, min, max);
        }

        public void Multiply(int scalar)
        {
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    Data[x][y] *= scalar;
        }

        public void Add(int scalar)
        {
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    Data[x][y] += scalar;
        }

        public void Add(Matrix other)
        {
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    Data[x][y] += other.Data[x][y];
        }

        public void Map(Func<float, float> func)
        {
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Cols; y++)
                {
                    var val = this.Data[x][y];
                    this.Data[x][y] = func(val);
                }
            }
        }

        public float[] ToArray()
        {
            List<float> list = new List<float>();
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    list.Add(Data[x][y]);
            return list.ToArray();
        }

        public static Matrix Multiply(Matrix one, Matrix other)
        {
            if (one.Cols != other.Rows) return one;

            var a = one;
            var b = other;
            var result = new Matrix(a.Rows, b.Cols);

            for (int x = 0; x < result.Rows; x++)
            {
                for (int y = 0; y < result.Cols; y++)
                {
                    float sum = 0;
                    for (int i = 0; i < a.Cols; i++)
                        sum += a.Data[x][i] * b.Data[i][y];
                    result.Data[x][y] = sum;
                }
            }

            return result;
        }

        public static Matrix Transpose(Matrix target)
        {
            var result = new Matrix(target.Cols, target.Rows);
            for (int x = 0; x < target.Rows; x++)
                for (int y = 0; y < target.Cols; y++)
                    result.Data[y][x] = target.Data[x][y];

            return result;
        }

    }
}
