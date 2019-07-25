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
        public int[][] Data { get; set; }

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;

            Data = new int[Rows][];
            for (int x = 0; x < Rows; x++)
                Data[x] = new int[Cols];

            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    Data[x][y] = 0;
        }

        public void Randomize(int min = 0, int max = 10)
        {
            Random rnd = new Random();
            for (int x = 0; x < Rows; x++)
                for (int y = 0; y < Cols; y++)
                    Data[x][y] = rnd.Next(min, max);
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

        public void Map(Func<int, int> func)
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
                    int sum = 0;
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
