using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
using MathNet.Numerics;
using MathNet.Numerics.Distributions;

namespace G
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : System.Windows.Window
    {
        private static Random random = new Random();
        private int distributionMode = 0;
        private int distribution = 0;
        public int KolVar1 { get; private set; }
        private AppContext db;
        public Window3()
        {
            InitializeComponent();
            db = new AppContext();
            


        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(Kolvovar1.Text, out int kolvovar1);
            KolVar1 = kolvovar1;
            Window4 win4 = new Window4(KolVar1);
            win4.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new AppContext())
            {

                var latestDate = context.Enters1.Max(entry => entry.data_time);
                var enter1 = context.Enters1.Where(entry => entry.data_time == latestDate).ToList();


                foreach (var entry in enter1)
                {
                    double koefA = entry.A;
                    double koefB = entry.B;
                    double koefC = entry.C;
                    double koefD = entry.D;
                    int v = entry.variant;
                    int a = entry.start;
                    int b = entry.end;
                    double meaneps = 0.5;
                    double stddeveps = 0.3;
                    string dt = entry.data_time;
                    double mean = Math.Round((a + b) / 2.0, 1);
                    double stddev = Math.Round((b - a) / 6.0, 1);


                    int count = 20; 
                    for (int i = 0; i < count; i++)
                    {
                        double sample;
                        if (distributionMode == 1)
                        {
                            if (v % 2 == 1) 
                            {
                                sample = GenerateTruncatedNormal(mean, stddev, a, b);
                            }
                            else 
                            {
                                sample = GenerateUniform(a, b);
                            }
                        }
                        else if (distributionMode == 2)
                        {
                            if ((v - 1) % 4 < 2) // 1, 2, 5, 6, ...
                            {
                                sample = GenerateTruncatedNormal(mean, stddev, a, b);
                            }
                            else // 3, 4, 7, 8, ...
                            {
                                sample = GenerateUniform(a, b);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите режим чередования распределений");
                            return;
                        }


                        double ep = GenerateTruncatedNormal1(meaneps, stddeveps);
                        double Yper = 0;

                        if (distribution == 1)
                        {
                            if (v % 6 == 1) // 1,7,13
                            {
                                Yper = koefA * sample + koefB;
                            }

                            else if (v % 6 == 2 ) // 2,8,14
                            {
                                Yper = koefA * Math.Log10(sample) + koefB;
                            }
                            else if (v % 6 == 3 ) // 3,9,15
                            {
                                Yper = koefA * Math.Exp(1) + koefB;
                            }
                            else if (v % 6 == 4 ) // 4,10,16
                            {
                                Yper = koefA / sample + koefB;
                            }
                            else if (v % 6 == 5) // 5,11,17
                            {
                                Yper = koefA * (Math.Pow(sample, 2)) + koefB * sample + koefC;
                            }
                            else  // 6,12,18
                            {
                                Yper = koefA * (Math.Pow(sample, 3)) + koefB * (Math.Pow(sample, 2)) + koefC * sample + koefD;
                            }
                        }
                        else if (distribution == 2)
                        {
                            MessageBox.Show("sdsa");
                        }

                        var exit = new Exit1
                        {
                            variant = v,
                            iter_number = i + 1,
                            X = Math.Round(sample,4),
                            Y = Math.Round(Yper + ep, 4),
                            eps = ep,
                            data_time = dt
                        };

                        context.Exits1.Add(exit);
                    }

                }
                context.SaveChanges();
            }
        }

        
        private static double GenerateTruncatedNormal(double mean, double stddev, double a, double b)
        {
            var normal = new Normal(mean, stddev);
            double sample;
            do
            {
                sample = normal.Sample();
            } while (sample < a || sample > b);
            return sample;
        }
        private static double GenerateTruncatedNormal1(double meaneps, double stddeveps)
        {
            var normal = new Normal(meaneps, stddeveps);
            double sample;
            do
            {
                sample = normal.Sample();
            } while (sample < 0 || sample > 1);
            return sample;
        }

        private static double GenerateUniform(int a, int b)
        {
            ContinuousUniform sample = new ContinuousUniform(a, b);
            return sample.Sample();

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window2 window2 = new Window2();
            window2.Show();
        }

        private void Button_Click22(object sender, RoutedEventArgs e)
        {
            int.TryParse(Kolvovar1.Text, out int kolvovar1);
            KolVar1 = kolvovar1;
            Rparametrs param = new Rparametrs(KolVar1);
            param.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
           
           

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            distribution = 1;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            distribution = 2;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            distributionMode = 1;
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            distributionMode = 2;
        }
    }
}
