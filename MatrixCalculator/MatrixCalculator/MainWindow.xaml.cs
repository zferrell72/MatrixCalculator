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

        private CustomMatrix MatrixA= new CustomMatrix(1);
        private CustomMatrix MatrixB= new CustomMatrix(1);
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


           // CustomMatrix result = A.Add(B);
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

        private bool setAandB()
        {
            int[,] TempA = new int[GridA.Rows, GridA.Rows];
            int[,] TempB = new int[GridA.Rows, GridA.Rows];
            bool worked = true;
            for(int i=0;i<GridA.Rows;i++)
            {
                for (int j = 0; j < GridA.Rows; j++)
                {
                    if (!Int32.TryParse(((String)inputFields["A" + i + ":" + j].Text), out TempA[i, j]) || !Int32.TryParse(((String)inputFields["B" + i + ":" + j].Text), out TempB[i, j]))
                    {
                        worked = false;
                        break;
                    }
                    if (!worked)
                        break;
                }
            }
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

        private void BuildAndDisplay(int[,] matrix)
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

        private int getScalar()
        {
            int returnme;
            if (!Int32.TryParse(((String)Button0.Text), out returnme))
            {
                returnme = -1337;
            }
            return returnme;
        }

        private void SubAB(object sender, RoutedEventArgs e)
        {
            if (setAandB())
            {
                //BuildAndDisplay(CustomMatrixMethodCall.getMatrix());
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
                //BuildAndDisplay(CustomMatrixMethodCall.getMatrix());
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
                //BuildAndDisplay(CustomMatrixMethodCall.getMatrix());
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
                //BuildAndDisplay(CustomMatrixMethodCall.getMatrix());
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
                //BuildAndDisplay(CustomMatrixMethodCall.getMatrix());
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
                //BuildAndDisplay(CustomMatrixMethodCall.getMatrix());
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
                //BuildAndDisplay(CustomMatrixMethodCall.getMatrix());
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
                //BuildAndDisplay(CustomMatrixMethodCall.getMatrix());
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
                //BuildAndDisplay(CustomMatrixMethodCall.getMatrix());
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
