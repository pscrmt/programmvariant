using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace G
{
   
    public partial class Window4 : Window
    {
        public Window4(int kolvovar1)
        {
            InitializeComponent();
            var data = new List<Enter1>();
            for (int i = 1; i <= kolvovar1; i++)
            {
                data.Add(new Enter1 { variant = i, A = 0, B = 0, C = 0, D = 0});
            }           

            myDataGrid.ItemsSource = data;
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new AppContext())
            {
                foreach (var item in myDataGrid.ItemsSource as List<Enter1>)
                {
                    var enter = new Enter1(item.variant, item.A, item.B, item.C, item.D);
                    context.Enters1.Add(enter);
                }
                context.SaveChanges();
            }
        }
    }

    public class MyDataItem
    {
    }

}

