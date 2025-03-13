using DocumentFormat.OpenXml.EMMA;
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
using System.Windows.Shapes;

namespace S
{
        public partial class _2 : Window
    {
        public _2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string allowedChars = "12345abcde";
            TextBox currentTextBox = sender as TextBox;

            // Проверяем, что в TextBox уже нет символа или вводимый символ не входит в разрешенный набор
            if (currentTextBox.Text.Length >= 1 || !allowedChars.Contains(e.Text))
            {
                e.Handled = true;
            }
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox currentTextBox = sender as TextBox;
                int column = Grid.GetColumn(currentTextBox);
                int row = Grid.GetRow(currentTextBox);

                // Переход к следующему TextBox
                TextBox nextTextBox = GetNextTextBox(currentTextBox, column, row);
                if (nextTextBox != null)
                {
                    nextTextBox.Focus();
                }

                e.Handled = true;
            }
        }

        private TextBox GetNextTextBox(TextBox current, int currentColumn, int currentRow)
        {
           
            if (currentColumn < 4)
            {
                return (TextBox)MyTableGrid.Children.Cast<UIElement>().FirstOrDefault(ui => Grid.GetColumn(ui) == currentColumn + 1 && Grid.GetRow(ui) == currentRow);
            }
            else if (currentRow < 4)
            {
                return (TextBox)MyTableGrid.Children.Cast<UIElement>().FirstOrDefault(ui => Grid.GetColumn(ui) == 0 && Grid.GetRow(ui) == currentRow + 1);
            }
            return null;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string[] rows = new string[5];
            string[] columns = new string[5];

            for (int row = 0; row < 5; row++)
            {
                rows[row] = string.Empty; 
                for (int col = 0; col < 5; col++)
                {
                    if (columns[col] == null) 
                    {
                        columns[col] = string.Empty;
                    }

                    TextBox textBox = (TextBox)MyTableGrid.Children.Cast<UIElement>().FirstOrDefault(ui => Grid.GetColumn(ui) == col && Grid.GetRow(ui) == row);
                    if (textBox != null)
                    {
                        rows[row] += textBox.Text;
                        columns[col] += textBox.Text;
                    }
                }
            }

            bool hasDuplicates = false;
            bool isCircular = false;

            
            for (int i = 0; i < 5; i++)
            {
                if (HasDuplicates(rows[i]) || HasDuplicates(columns[i]))
                {
                    hasDuplicates = true;
                    break;
                }
            }

            if (!hasDuplicates)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (i != j && (IsCircularShift(rows[i], rows[j]) || IsCircularShift(columns[i], columns[j])))
                        {
                            isCircular = true;
                            break;
                        }
                    }
                    if (isCircular)
                        break;
                }
            }

            if (hasDuplicates)
            {
                MessageBox.Show("Найдены повторяющиеся символы в строках или столбцах.");
            }
            else if (isCircular)
            {
                MessageBox.Show("Последовательность символов не должна повторяться по кругу.");
            }
            else
            {
                MessageBox.Show("Все символы уникальны в строках и столбцах.");
            }
        }

        private bool HasDuplicates(string str)
        {
            HashSet<char> charSet = new HashSet<char>();
            foreach (char c in str)
            {
                if (!charSet.Add(c))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsCircularShift(string sequence1, string sequence2)
        {
            if (sequence1.Length != sequence2.Length)
                return false;

            string doubled = sequence1 + sequence1;
            return doubled.Contains(sequence2);
        }
           private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
                Application.Current.Shutdown();
                    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            savenabor2 saven2 = new savenabor2();
            saven2.Show();
        }
    }
}
