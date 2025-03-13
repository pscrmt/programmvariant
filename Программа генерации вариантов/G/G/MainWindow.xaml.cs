using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace G
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textboxlogin.Text.Trim();
            string pass = textboxpass.Password.Trim();


            
                if (login == "admin" && pass == "12345")

                {
                    this.Hide();
                    Window1 window1 = new Window1();
                    window1.Show();
                }

                else
                {
                    MessageBox.Show("Введены неправильные данные");
                }

            
        }
    }
}
