using System.Runtime.Remoting.Messaging;
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
        private Dictionary<String, TextBox> inputFields = new Dictionary<String, TextBox>();

        private CustomMatrix MatrixA;
        private CustomMatrix MatrixB;
        public MainWindow()
        {
            InitializeComponent();

            //const int dimension = 3;

            //double[,] arrayForA = new double[dimension, dimension] { { 2, 4, 3 }, { 0, 1, -1 }, { 3, 5, 7 } };

            //CustomMatrix A = new CustomMatrix(dimension);
            //A.PopulateMatrix(arrayForA);

            //CustomMatrix result = A.Inverse();

        }

        private bool setAandB()
        {
            double[,] TempA = new double[GridA.Rows, GridA.Rows];
            double[,] TempB = new double[GridA.Rows, GridA.Rows];
            bool worked = true;
            for(int i=0;i<GridA.Rows;i++)
            {
                for (int j = 0; j < GridA.Rows; j++)
                {
                    if (!Double.TryParse(((String)inputFields["A" + i + ":" + j].Text), out TempA[i, j]) || !Double.TryParse(((String)inputFields["B" + i + ":" + j].Text), out TempB[i, j]))
                    {
                        worked = false;
                        break;
                    }
                    if (!worked)
                        break;
                }
            }
            MatrixA = new CustomMatrix(GridA.Rows);
            MatrixB = new CustomMatrix(GridA.Rows);
            MatrixA.PopulateMatrix(TempA);
            MatrixB.PopulateMatrix(TempB);
            return worked;
        }

        private void setUpInputGrids(int Value, bool error)
        {
           

            EnableControlls();
            GridA.Children.Clear();
            GridB.Children.Clear();
            inputFields.Clear();

            GridA.Rows = Value;
            GridA.Columns = Value;
            for (int i = 0; i < Value; i++)
            {
                for (int j = 0; j < Value; j++)
                {
                    TextBox tb = new TextBox();
                    tb.Height = 100 / Value;
                    tb.Width = 120 / Value;
                    tb.Text = "0";
                    tb.Name = "A" + i + "_" + j;
                    tb.Background = Brushes.LightGray;
                    inputFields.Add("A"+i+":"+j,tb);
                    GridA.Children.Add(tb);
                }
            }
            GridA.Background = Brushes.AliceBlue;

            GridB.Rows = Value;
            GridB.Columns = Value;
            for (int i = 0; i < Value; i++)
            {
                for (int j = 0; j < Value; j++)
                {
                    TextBox tb = new TextBox();
                    tb.Height = 100 / Value;
                    tb.Width = 120 / Value;
                    tb.Text = "0";
                    tb.Name = "B" + i + "_" + j;
                    tb.Background = Brushes.LightGray;
                    inputFields.Add("B" + i + ":" + j, tb);
                    GridB.Children.Add(tb);
                }
            }
            GridB.Background = Brushes.AliceBlue;
            if(!error){
                Error.Foreground = Brushes.Blue;
                Error.Content = "Board Set Up!!";
            }
            else
            {
                Error.Foreground = Brushes.Red;
                Error.Content = "No Strings Allowed";
            }
        }

        private void EnableControlls()
        {
            Button0.IsEnabled = true;
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button4.IsEnabled = true;
            Button5.IsEnabled = true;
            Button6.IsEnabled = true;
            Button7.IsEnabled = true;
            Button8.IsEnabled = true;
            Button3.IsEnabled = true;
            Button9.IsEnabled = true;
        }

        private void BuildAndDisplay(double[,] matrix)
        {
            int numSides = GridA.Rows;
            AnswerDisplay.Children.Clear();
            AnswerDisplay.Rows = numSides;
            AnswerDisplay.Columns = numSides;
            
            for (int i = 0; i < numSides; i++)
            {
                for (int j = 0; j < numSides; j++)
                {
                    TextBox tb = new TextBox();
                    tb.Height = 100 / numSides;
                    tb.Width = 120 / numSides;
                    tb.Text = matrix[i,j]+"";
                    tb.Background = Brushes.LightGoldenrodYellow;
                    tb.IsEnabled = false;
                    AnswerDisplay.Children.Add(tb);
                }
            }
        }

        private double getScalar()
        {
            double returnme;
            if (!Double.TryParse(((String)Button0.Text), out returnme))
            {
                returnme = -1337;
            }
            return returnme;
        }

        private void SubAB(object sender, RoutedEventArgs e)
        {
            if (setAandB())
            {
                BuildAndDisplay(MatrixA.Subtract(MatrixB).getMatrix());
            }
            else
            {
                setUpInputGrids(GridA.Rows, true);
            }
        }
        private void SubBA(object sender, RoutedEventArgs e)
        {
            if (setAandB())
            {
                BuildAndDisplay(MatrixB.Subtract(MatrixA).getMatrix());
            }
            else
            {
                setUpInputGrids(GridA.Rows, true);
            }
        }
        private void AddAB(object sender, RoutedEventArgs e)
        {
            if (setAandB())
            {
                BuildAndDisplay(MatrixA.Add(MatrixB).getMatrix());
            }
            else
            {
                setUpInputGrids(GridA.Rows, true);
            }
        }
        private void MultiAB(object sender, RoutedEventArgs e)
        {
            if (setAandB())
            {
                BuildAndDisplay(MatrixA.Multiply(MatrixB).getMatrix());
            }
            else
            {
                setUpInputGrids(GridA.Rows, true);
            }
        }
        private void MultiBA(object sender, RoutedEventArgs e)
        {
            if (setAandB())
            {
                BuildAndDisplay(MatrixB.Multiply(MatrixA).getMatrix());
            }
            else
            {
                setUpInputGrids(GridA.Rows, true);
            }
        }
        private void ScalA(object sender, RoutedEventArgs e)
        {
            var scalar = getScalar();
            if (setAandB() && scalar!=-1337)
            {
                BuildAndDisplay(MatrixA.Scale(scalar).getMatrix());
            }
            else
            {
                setUpInputGrids(GridA.Rows, true);
            }
        }
        private void ScalB(object sender, RoutedEventArgs e)
        {
            var scalar = getScalar();
            if (setAandB() && scalar != -1337)
            {
                BuildAndDisplay(MatrixB.Scale(scalar).getMatrix());
            }
            else
            {
                setUpInputGrids(GridA.Rows, true);
            }
        }
        private void InvA(object sender, RoutedEventArgs e)
        {
            if (setAandB())
            {
                BuildAndDisplay(MatrixA.Inverse().getMatrix());
            }
            else
            {
                setUpInputGrids(GridA.Rows, true);
            }
        }
        private void InvB(object sender, RoutedEventArgs e)
        {
            if (setAandB())
            {
                BuildAndDisplay(MatrixB.Inverse().getMatrix());
            }
            else
            {
                setUpInputGrids(GridA.Rows, true);
            }
        }

        private void Make2x2(object sender, RoutedEventArgs e)
        {
            setUpInputGrids(2, false);
        }
        private void Make3x3(object sender, RoutedEventArgs e)
        {
            setUpInputGrids(3, false);
        }
        private void Make4x4(object sender, RoutedEventArgs e)
        {
            setUpInputGrids(4, false);
        }
        private void Make5x5(object sender, RoutedEventArgs e)
        {
            setUpInputGrids(5, false);
        }
        private void Make6x6(object sender, RoutedEventArgs e)
        {
            setUpInputGrids(6, false);
        }
    }
}
