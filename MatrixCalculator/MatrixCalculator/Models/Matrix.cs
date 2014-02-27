using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator.Models
{
    class Matrix
    {
        private int[,] theMatrix;
        private int size;

        public Matrix(int dimension)
        {
            InitializeMatrix(dimension);
        }

        public void PopulateMatrix(int[,] array)
        {

        }

        public void InitializeMatrix(int dimension)
        {
            size = dimension;
            theMatrix = new int[dimension, dimension];
        }

        public Matrix SubtractMatrix(Matrix otherMatrix)
        {
            return null;   
        }

        public int getValue(int row, int col)
        {
            return theMatrix[col, row];
        }

        public void setValue(int row, int col, int value)
        {
            theMatrix[col, row] = value;
        }

    }
}
