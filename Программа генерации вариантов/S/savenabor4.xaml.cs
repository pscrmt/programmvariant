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
    /// Логика взаимодействия для savenabor4.xaml
    /// </summary>
    public partial class savenabor4 : Window
    {
        public savenabor4()
        {
            InitializeComponent();
        }

        private void Label_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            _4 win4 = new _4();
            win4.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
