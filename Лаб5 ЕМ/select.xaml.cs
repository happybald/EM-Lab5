using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Windows.Media.Animation;
using System.Runtime.Serialization;

namespace Лаб5_ЕМ
{
    /// <summary>
    /// Логика взаимодействия для select.xaml
    /// </summary>
    public partial class select : Window
    {
        public select(int type)
        {
            InitializeComponent();
            List<elementOfGrid> list;
            StreamReader r;
            string json;

            switch (type)
            {
                case 2:
                    {
                        r = new StreamReader(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"data/airRate.json"));
                        json = r.ReadToEnd();
                        list = JsonConvert.DeserializeObject<List<elementOfGrid>>(json);
                        break;
                    }
                case 3:
                    {
                        r = new StreamReader(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"data/Factors.json"));
                        json = r.ReadToEnd();
                        list = JsonConvert.DeserializeObject<List<elementOfGrid>>(json);
                        break;
                    }
                default:
                    {
                        r = new StreamReader(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"data/elements.json"));
                        json = r.ReadToEnd();
                        list = JsonConvert.DeserializeObject<List<elementOfGrid>>(json);
                        break;
                    }
            }
            EG.ItemsSource = list;
        }

        private elementOfGrid selected { get; set; }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            selected = (elementOfGrid)EG.SelectedItem;
            this.Close();
        }

        public string Foo()
        {
            if (selected != null)
            {
                return selected.Value.ToString();
            }
            elementOfGrid temp = (elementOfGrid)EG.SelectedItem;
            return temp.Value.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
