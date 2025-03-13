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
    /// <summary>
    /// Логика взаимодействия для savenabor2.xaml
    /// </summary>
    public partial class savenabor2 : Window
    {
        public savenabor2()
        {
            InitializeComponent();
        }

        private void Label_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            _2 win2 = new _2();
            win2.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
               
    }
}
