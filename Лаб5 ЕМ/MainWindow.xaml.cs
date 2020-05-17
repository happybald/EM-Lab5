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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Лаб5_ЕМ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Top = (SystemParameters.FullPrimaryScreenHeight - this.Height) / 2;
            this.Left = (SystemParameters.FullPrimaryScreenWidth - this.Width) / 2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var boxes = new TextBox[] { textbox1, textbox2, textbox3, textbox4, textbox5, textbox6, textbox7, textbox8, textbox9, textbox10, textbox11 };
            if (boxes.Any(x => x.Text.Length == 0))
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }
            try
            {
                double Ca = Double.Parse(boxes[0].Text);
                double Tout = Double.Parse(boxes[2].Text);
                double Vout = Double.Parse(boxes[4].Text);
                double Ch = Double.Parse(boxes[1].Text);
                double Tin = Double.Parse(boxes[3].Text);
                double Vin = Double.Parse(boxes[5].Text);
                double EF = Double.Parse(boxes[6].Text);
                double ED = Double.Parse(boxes[7].Text);
                double BW = Double.Parse(boxes[8].Text);
                double AT = Double.Parse(boxes[9].Text);
                double SF = Double.Parse(boxes[10].Text);
                double ADD = (Ca * Tout * Vout + Ch * Tin * Vin);
                ADD *= EF * ED;
                ADD /= (BW * AT * 365);
                double CR = ADD * SF;
                if (CR > 1 || CR < 0)
                {
                    throw new Exception("Введено помилкові данні (CR>1 or CR<0)");
                }
                result.Text = CR.ToString("F4");
                if (CR > Math.Pow(10, -3))
                {
                    ResultLabel.Content = "Високий рівень ризику";
                }
                if (CR > Math.Pow(10, -4) && CR < Math.Pow(10, -3))
                {
                    ResultLabel.Content = "Ceредній рівень ризику";
                }
                if (CR > Math.Pow(10, -6) && CR < Math.Pow(10, -4))
                {
                    ResultLabel.Content = "Низький рівень ризику";
                }
                if (CR < Math.Pow(10, -6))
                {
                    ResultLabel.Content = "Мінімальний рівень ризику";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введено невірний формат!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (IsWindowOpen<Info>())
            {
                return;
            }
            Info info = new Info();
            info.Show();
        }

        private void selectElement(object sender, RoutedEventArgs e)
        {
            select SelectWindow = new select(1);
            if (SelectWindow.ShowDialog() == false)
            {
                string foo = SelectWindow.Foo();
                textbox1.Text = foo;
                textbox2.Text = foo;
            }
        }
        private void selectRate(object sender, RoutedEventArgs e)
        {
            select SelectWindow = new select(2);
            if (SelectWindow.ShowDialog() == false)
            {
                string foo = SelectWindow.Foo();
                textbox5.Text = foo;
                textbox6.Text = foo;
            }
        }
        private void selectFactor(object sender, RoutedEventArgs e)
        {
            select SelectWindow = new select(3);
            if (SelectWindow.ShowDialog() == false)
            {
                string foo = SelectWindow.Foo();
                textbox11.Text = foo;
            }
        }
    }
}
