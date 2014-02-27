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

        public Matrix(int dimension)
        {
            InitializeMatrix(dimension);
        }

        public void InitializeMatrix(int dimension)
        {
            theMatrix = new int[dimension, dimension];
        }


    }
}
