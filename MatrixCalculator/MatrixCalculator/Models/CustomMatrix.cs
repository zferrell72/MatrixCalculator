using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator.Models
{
    class CustomMatrix
    {
        private double[,] theMatrix;
        private int size;

        public CustomMatrix(int dimension)
        {
            InitializeMatrix(dimension);
        }

        public void PopulateMatrix(double[,] array)
        {
            theMatrix = array;
        }

        public void InitializeMatrix(int dimension)
        {
            size = dimension;
            theMatrix = new double[dimension, dimension];
        }

        public CustomMatrix Subtract(CustomMatrix otherMatrix)
        {
            CustomMatrix result = new CustomMatrix(size);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    double newValue = theMatrix[row, col] - otherMatrix.GetValue(row, col);
                    result.SetValue(row, col, newValue);
                }
            }

            return result;
        }


        public CustomMatrix Add(CustomMatrix otherMatrix)
        {
            CustomMatrix resultMatrix = new CustomMatrix(size);

            for(int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    double newResult = theMatrix[row, column] + otherMatrix.GetValue(row, column);
                    resultMatrix.SetValue(row, column, newResult);
                }
            }

            return resultMatrix;
        }



        public CustomMatrix Scale(double scalar)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    theMatrix[row, col] *= scalar;
                }
            }

            return this;
        }

        public CustomMatrix Multiply(CustomMatrix otherMatrix)
        {
            CustomMatrix resultMatrix = new CustomMatrix(size);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    double value = 0;
                    for (int counter = 0; counter < size; counter++)
                    {
                        value += this.GetValue(row, counter) * otherMatrix.GetValue(counter, col);
                        Console.WriteLine(value);
                    }
                    resultMatrix.SetValue(row, col, value);
                }
            }

            return resultMatrix;
        }

        public CustomMatrix Inverse()
        {
            CustomMatrix resultMatrix = null;
            double determinate = Determinate(this);
            if (!determinate.Equals(0d))
            {

                CustomMatrix preTransposeAdjoint = new CustomMatrix(this.size);
                Adjoint(this, preTransposeAdjoint);
                CustomMatrix adjoint = preTransposeAdjoint.Transpose(new CustomMatrix(preTransposeAdjoint.size));

                resultMatrix = adjoint.Scale(1 / determinate);

            }
            else
            {
                // There is no inverse
                resultMatrix = this;
            }
            return resultMatrix;
        }

        public CustomMatrix Transpose(CustomMatrix resultMatrix)
        {
            for (int row = 0; row < resultMatrix.size; row++)
            {
                for (int col = 0; col < resultMatrix.size; col++)
                {
                    resultMatrix.SetValue(col, row, this.GetValue(row, col));
                }
            }

            return resultMatrix;
        }

        public double Adjoint(CustomMatrix currentMatrix, CustomMatrix resultMatrix)
        {
            double det = 0;
            if (currentMatrix.size == 2)
            {
                resultMatrix.SetValue(0, 0, currentMatrix.GetValue(1, 1));
                resultMatrix.SetValue(0, 1, -1 * currentMatrix.GetValue(1, 0));
                resultMatrix.SetValue(1, 0, -1 * currentMatrix.GetValue(0, 1));
                resultMatrix.SetValue(1, 1, currentMatrix.GetValue(0, 0));
            }
            else
            {
                for (int row = 0; row < currentMatrix.size; row++)
                {
                    for (int col = 0; col < currentMatrix.size; col++)
                    {

                        double temp = (Determinate(FindMinor(row, col, currentMatrix)));
                        if ((row + col) % 2 != 0 )
                        {
                            temp *= -1;
                        }
                        resultMatrix.SetValue(row, col, temp);
                    }
                }
                
            }
            return det;
        }

        public CustomMatrix FindMinor(int ignoreRow, int ignoreCol, CustomMatrix currentMatrix)
        {
            CustomMatrix resultMatrix = new CustomMatrix(currentMatrix.size - 1);
            Queue<double> targetValues = new Queue<double>();

            for (int i = 0; i < currentMatrix.size; i++)
            {
                if (i == ignoreRow)
                {
                    i++;
                }
                if (i < currentMatrix.size)
                {
                    for (int j = 0; j < currentMatrix.size; j++)
                    {
                        if (j == ignoreCol)
                        {
                            j++;
                        }
                        if (j < currentMatrix.size)
                        {
                            targetValues.Enqueue(currentMatrix.GetValue(i, j));
                        }
                    }
                }
            }

            for (int i = 0; i < resultMatrix.size; i++)
            {
                for (int j = 0; j < resultMatrix.size; j++)
                {
                    resultMatrix.SetValue(i, j, targetValues.Dequeue());
                }
            }

            return resultMatrix;
        }

        public double Determinate(CustomMatrix currentMatrix)
        {
            double det = 0;
            if (currentMatrix.size == 2)
            {
                det = ((currentMatrix.GetValue(0, 0) * currentMatrix.GetValue(1, 1)) - (currentMatrix.GetValue(0, 1) * currentMatrix.GetValue(1, 0)));
            }
            else
            {
                for (int current = 0; current < currentMatrix.size; current++)
                {

                    double temp = currentMatrix.GetValue(0, current) * (Determinate(FindMinor(0, current, currentMatrix)));
                    if (current % 2 != 0)
                    {
                        temp *= -1;
                    }
                    det += temp;
                }
            }
            return det;
        }

        public double GetValue(int row, int col)

        {
            return theMatrix[row, col];
        }

        public void SetValue(int row, int col, double value)
        {
            theMatrix[row, col] = value;
        }

        public double[,] getMatrix()
        {
            return theMatrix;
        }
    }
}
