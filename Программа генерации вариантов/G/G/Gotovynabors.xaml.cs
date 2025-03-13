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
using static MaterialDesignThemes.Wpf.Theme;

namespace G
{
    /// <summary>
    /// Логика взаимодействия для Gotovynabors.xaml
    /// </summary>
    public partial class Gotovynabors : Window
    {
        public Gotovynabors()
        {
            InitializeComponent();
            var data = new List<MyDataItem> { };

            // Привязка данных к DataGrid
            myData.ItemsSource = data;
        }
        public class MyDataItem
        {

            // Добавьте другие свойства по необходимости
        }

      

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Nabor nabor = new Nabor();
            nabor.Show();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Delete delete = new Delete();
            delete.Show();
        }
    }
}
