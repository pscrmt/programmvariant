using G;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using static G.Gotovynabors;
using static MaterialDesignThemes.Wpf.Theme;

namespace G
{   
    public partial class Rparametrs : Window
    {
        private List<Enter1> data2;
        public Rparametrs(int kolvovar1)
        {
            InitializeComponent();
            using (var context = new AppContext())
            {
                
                var latestDates = context.Enters1
                                         .GroupBy(e => e.variant)
                                         .Select(g => new
                                         {
                                             variant = g.Key,
                                             latestDate = g.Max(e => e.data_time)
                                         })
                                         .ToList();
                var tempData = latestDates
                            .Where(ld => ld.variant <= kolvovar1)
                            .Select(ld => context.Enters1
                                                .Where(entry => entry.variant == ld.variant && entry.data_time == ld.latestDate)
                                                .Select(entry => new
                                                {
                                                    entry.variant,
                                                    entry.start,
                                                    entry.end,
                                                    entry.A,
                                                    entry.B,
                                                    entry.C,
                                                    entry.D,
                                                    entry.data_time
                                                })
                                                .FirstOrDefault())
                            .ToList();
                data2 = tempData.Select(item => new Enter1
                {
                    variant = item.variant,
                    start = item.start,
                    end = item.end,
                    A = item.A,
                    B = item.B,
                    C = item.C,
                    D = item.D,
                    data_time = item.data_time
                }).ToList();
                for (int i = 1; i <= kolvovar1; i++)
                {
                    if (!data2.Any(d => d.variant == i))
                    {
                        data2.Add(new Enter1 { variant = i, start = 0, end = 0, A = 0, B = 0, C = 0, D = 0 });
                    }
                }
            }

            myData.ItemsSource = data2;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new AppContext())
            {
                foreach (var item in myData.ItemsSource as List<Enter1>)
                {
                    var existingEntry = context.Enters1
                                               .Where(entry => entry.variant == item.variant && entry.data_time == item.data_time)
                                               .FirstOrDefault();

                    if (existingEntry != null)
                    {
                        existingEntry.start = item.start;
                        existingEntry.end = item.end;
                    }
                    else
                    {
                        var enter = new Enter1
                        {
                            variant = item.variant,
                            start = item.start,
                            end = item.end,
                            A = item.A,
                            B = item.B,
                            C = item.C,
                            D = item.D,
                            data_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
                        };
                        context.Enters1.Add(enter);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
    



