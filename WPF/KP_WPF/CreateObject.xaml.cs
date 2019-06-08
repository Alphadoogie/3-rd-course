using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Globalization;

namespace KP_WPF
{
    /// <summary>
    /// Логика взаимодействия для CreateObject.xaml
    /// </summary>
    public partial class CreateObject : Window
    {
        public CreateObject()
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

        private void tb_Sirt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(tb_SirtName.Text, @"^[\sа-яA]*$"))
            {
                return;
            }
            else
            {
                tb_SirtName.Text = String.Empty;
            }
        }

        private void Tb_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(tb_Name.Text, @"^[\sа-яA]*$"))
            {
                return;
            }
            else
            {
                tb_Name.Text = String.Empty;
            }
        }

        private void Tb_Third_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(tb_ThirdName.Text, @"^[\sа-яA]*$"))
            {
                return;
            }
            else
            {
                tb_ThirdName.Text = String.Empty;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Tb_city_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(tb_city.Text, @"^[\sа-яA]*$"))
            {
                return;
            }
            else
            {
                tb_city.Text = String.Empty;
            }
        }

        private void Tb_num_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_num.MaxLength = 14;
            if (Regex.IsMatch(tb_num.Text, @"^([\(\)\+0-9\s\-\#]+)$"))
            {
                return;
            }
            else
            {
                tb_num.Text = String.Empty;
            }

        }
        private void Tb_Data(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(tb_city.Text, @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"))
            {
                MessageBox.Show("Дата введена успешно");
                return;
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные (ДД.ММ.ГГГГ");
            }
        }

        private void Tb_Data_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = tb_data.Text;
            DateTime result;
            if (!DateTime.TryParseExact(
                 s,
                 @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$",
                 CultureInfo.InvariantCulture,
                 DateTimeStyles.AssumeUniversal,
                 out result))
            {
                Console.WriteLine("Invalid date entered.");
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int temp = 0;
            if (tb_data.Text == "" || tb_city.Text == "" || tb_Name.Text == "")
            {
                MessageBox.Show("Поля не могут быть пустыми!");
            }
            else
            {
                if (Regex.IsMatch(tb_data.Text, "^[0-9]+$"))
                {
                    temp++;
                }
                else
                {
                    MessageBox.Show("Поле 'Дата' должно содержать только цифры!");
                    temp = 0;
                }
                if(temp!=0)
                {
                    MessageBox.Show("СОХРАНЕНИЕ УСПЕШНО ВЫПОЛНЕНО С БОЖЕЙ ПОМОЩЬЮ");
                    tb_data.Clear();
                    tb_Name.Clear();
                    tb_SirtName.Clear();
                    tb_ThirdName.Clear();
                    tb_num.Clear();
                    tb_city.Clear();
                }
                else
                {
                    MessageBox.Show("Введите валидные данные!");
                }
             
            }
        }


    }
}
 
 