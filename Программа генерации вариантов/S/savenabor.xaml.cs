using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using ClosedXML.Excel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Data.Entity;
using Microsoft.Win32;

namespace S
{
    
    public partial class savenabor : Window
    {
        public savenabor()
        {
            InitializeComponent();
        }

       

        private void Label_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            _1 win1 = new _1();
            win1.Show();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            _4 win4 = new _4();
            win4.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));



            using (var context = new AppContext())
            {
                var latestDate = context.Exits1
                            .Where(entry => entry.variant == 1)
                            .Max(entry => entry.data_time);

                var latestExit = context.Exits1
                                        .Where(entry => entry.variant == 1 && entry.data_time == latestDate)
                                        .ToList();
                if (latestExit != null)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("X", typeof(double)); 
                    dataTable.Columns.Add("Y", typeof(double));
                    foreach (var exit in latestExit)
        {
            dataTable.Rows.Add(exit.X, exit.Y);
        }
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Save an Excel File"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filePath = saveFileDialog.FileName;

                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(dataTable, "Sheet1");

                            workbook.SaveAs(filePath);

                            MessageBox.Show("Данные успешно экспортированы в Excel файл!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Нет данных для экспорта.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
