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

namespace Pattern1
{
    /// <summary>
    /// Interaction logic for ExpertMethod.xaml
    /// </summary>
    public partial class ExpertMethod : Window
    {
        public ExpertMethod()
        {
            InitializeComponent();
            Z1.Text = "";
            Z2.Text = "";
            Z3.Text = "";
            Z4.Text = "";
            Z5.Text = "";
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            if (Z1.Text == "" || Z2.Text == "" || Z3.Text == "" || Z4.Text == "" || Z5.Text == "")
            {
                MessageBox.Show("Необходимо заполнить все поля!");
            }
            else
            {

                int rz1, rz2, rz3, rz4, rz5;
                outcome.Text = "";

                rz1 = 5 - Int32.Parse(Z1.Text);
                rz2 = 5 - Int32.Parse(Z2.Text);
                rz3 = 5 - Int32.Parse(Z3.Text);
                rz4 = 5 - Int32.Parse(Z4.Text);
                rz5 = 5 - Int32.Parse(Z5.Text);

                Rez_Z1.Text = rz1.ToString();
                Rez_Z2.Text = rz2.ToString();
                Rez_Z3.Text = rz3.ToString();
                Rez_Z4.Text = rz4.ToString();
                Rez_Z5.Text = rz5.ToString();

                double sum = rz1 + rz2 + rz3 + rz4 + rz5;

                double W1, W2, W3, W4, W5;

                W1 = Math.Round(rz1 / sum, 2);
                W2 = Math.Round(rz2 / sum, 2);
                W3 = Math.Round(rz3 / sum, 2);
                W4 = Math.Round(rz4 / sum, 2);
                W5 = Math.Round(rz5 / sum, 2);

                w1.Text = W1.ToString();
                w2.Text = W2.ToString();
                w3.Text = W3.ToString();
                w4.Text = W4.ToString();
                w5.Text = W5.ToString();

                var map = new Dictionary<string, double>();
                map.Add("w1", W1);
                map.Add("w2", W2);
                map.Add("w3", W3);
                map.Add("w4", W4);
                map.Add("w5", W5);
               
                outcome.Text = "Лучший вариант: " + map.OrderByDescending(key => key.Value).First().Key + " = " + map.OrderByDescending(key => key.Value).First().Value.ToString();

                text1.Text = "Модифицированная матрица предпочтений";
                text2.Text = "Искомые веса";

                Tz1.Text = "Z1";
                Tz2.Text = "Z2";
                Tz3.Text = "Z3";
                Tz4.Text = "Z4";
                Tz5.Text = "Z5";
            }
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {

            Z1.Text = "";
            Z2.Text = "";
            Z3.Text = "";
            Z4.Text = "";
            Z5.Text = "";

            Rez_Z1.Text = "";
            Rez_Z2.Text = "";
            Rez_Z3.Text = "";
            Rez_Z4.Text = "";
            Rez_Z5.Text = "";

            w1.Text = "";
            w2.Text = "";
            w3.Text = "";
            w4.Text = "";
            w5.Text = "";

            outcome.Text = "";

            text1.Text = "";
            text2.Text = "";

            Tz1.Text = "";
            Tz2.Text = "";
            Tz3.Text = "";
            Tz4.Text = "";
            Tz5.Text = "";
        }

        private void Button_Out(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
