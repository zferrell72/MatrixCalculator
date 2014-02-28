using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator.Models
{
    class CustomMatrix
    {
        private int[,] theMatrix;
        private int size;

        public CustomMatrix(int dimension)
        {
            InitializeMatrix(dimension);
        }

        public void PopulateMatrix(int[,] array)
        {
            theMatrix = array;
        }

        public void InitializeMatrix(int dimension)
        {
            size = dimension;
            theMatrix = new int[dimension, dimension];
        }

        public CustomMatrix SubtractMatrix(CustomMatrix otherMatrix)
        {
            CustomMatrix result = new CustomMatrix(size);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int newValue = theMatrix[row, col] - otherMatrix.getValue(row, col);
                    result.setValue(row, col, newValue);
                }
            }

            return result;
        }

        public int getValue(int row, int col)
        {
            return theMatrix[row, col];
        }

        public void setValue(int row, int col, int value)
        {
            theMatrix[row, col] = value;
        }

    }
}
