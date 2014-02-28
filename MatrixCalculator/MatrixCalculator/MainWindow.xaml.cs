using MatrixCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatrixCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            const int dimension = 2;

            int[,] arrayForA = new int[dimension, dimension] { {3, 4}, {2, 1}};
            int[,] arrayForB = new int[dimension, dimension] { { 1, 6 }, { 2, 4 } };

            CustomMatrix A = new CustomMatrix(dimension);
            A.PopulateMatrix(arrayForA);
            CustomMatrix B = new CustomMatrix(dimension);
            B.PopulateMatrix(arrayForB);

            CustomMatrix result = A.Scale(2);

            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    Console.Write(result.GetValue(row, col) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
