using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static NeuralNetworkImplementation.Consts;
using static NeuralNetworkImplementation.Data;

namespace NeuralNetworkImplementation
{
    class Matrix
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int[][] matrix;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;

            matrix = new int[Rows][];
            for (int x = 0; x < Rows; x++)
                matrix[x] = new int[Cols];

            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    matrix[x][y] = 0;
        }

        public void Multiply(int scalar)
        {
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    matrix[x][y] *= scalar;
        }

        public Matrix Multiply(Matrix other)
        {
            if (this.Cols != other.Rows) return this;

            var a = this;
            var b = other;
            var result = new Matrix(a.Rows, b.Cols);

            for (int x = 0; x < result.Rows; x++)
            {
                for (int y = 0; y < result.Cols; y++)
                {
                    int sum = 0;
                    for (int i = 0; i < a.Cols; i++)
                        sum += a.matrix[x][i] * b.matrix[i][y];
                    result.matrix[x][y] = sum;
                }
            }

            return result;
        }

        public void Add(int scalar)
        {
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    matrix[x][y] += scalar;
        }

        public void Add(Matrix other)
        {
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    matrix[x][y] += other.matrix[x][y];
        }

    }
}
