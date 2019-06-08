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

namespace KP_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class String23 : Window
    {

        public String23()
        {
            InitializeComponent();
            Background = Theme.background;
        }
        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void button_modeInput_Click(object sender, RoutedEventArgs e)
        {
            tb_output.Text = null;
            if (tb_inputWord.Text != "" && tb_inputSubString.Text != "" && tb_inputString.Text != "")
            {
                string result = tb_inputString.Text;
                string res = "";
                List<int> indecies = new List<int>();
                int i = 0, j = -1;
                while (i != -1)
                {
                    i = result.IndexOf(tb_inputSubString.Text, j + 1);
                    if (i > 0)
                    {
                        indecies.Add(i);
                    }
                    j = i;
                }
                j = 0;
                foreach (int index in indecies)
                {
                    result = result.Insert(index + tb_inputSubString.Text.Length + j, tb_inputWord.Text);
                    j += tb_inputWord.Text.Length;
                }
                tb_output.Text = result;
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }

        }
    }
}
