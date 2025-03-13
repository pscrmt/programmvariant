using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Логика взаимодействия для _1.xaml
    /// </summary>
    public partial class _1 : Window
    {
        public _1()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            savenabor saven = new savenabor();
            saven.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
                          Application.Current.Shutdown();
         
        }
    }
}
