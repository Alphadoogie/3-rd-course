using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace KP_WPF
{
    /// <summary>
    /// Логика взаимодействия для Database.xaml
    /// </summary>
    public partial class Database : Window
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\Documents\GitHub\3-rd-course\WPF\KP_WPF\Database.mdf;Integrated Security=True";
        private SqlConnection connection = new SqlConnection(connectionString);
        private string flightNumber;
        private DateTime? departureDate;
        private string destination;
        private string surname;
        private int luggageSpace;
        private double luggageAmount;
        public Database()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    connection.Close();
                    connection.Open();
                    string query = $"INSERT INTO [Luggage] (flightNumber, departureDate, destination, surname, luggageSpace, luggageAmount) VALUES ('{flightNumber}', '{departureDate}', N'{destination}', N'{surname}', '{luggageSpace}', '{luggageAmount}') ";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    UpdateDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.GetBaseException());
            }
        }

        private void Button_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(tb_id.Text, out int id))
                {
                    if (id > 0)
                    {
                        connection.Open();
                        string query = $"DELETE FROM [Luggage] WHERE Id = {id}";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        UpdateDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректный id");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректный id");
                    return;
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDataGrid()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM [Luggage]";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable("Luggage");
                sqlData.Fill(dt);
                main_dataGrid.ItemsSource = dt.DefaultView;
                sqlData.Update(dt);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckInput()
        {
            if (tb_destination.Text != "" && tb_flightNumber.Text != "" && tb_luggageAmount.Text != "" && tb_luggageSpace.Text != "" && tb_surname.Text != "" && dt_date.Value != null)
            {
                if (tb_flightNumber.Text.Length == 10)
                {
                    this.flightNumber = tb_flightNumber.Text;
                }
                else
                {
                    MessageBox.Show("Номер рейса - 10 цифр");
                    return false;
                }
                if (tb_destination.Text[0] >= 'А' && tb_destination.Text[0] <= 'Я')
                {
                    destination = tb_destination.Text;
                }
                else
                {
                    MessageBox.Show("Пункт назначения с большой буквы");
                    return false;
                }
                if (tb_surname.Text[0] >= 'А' && tb_surname.Text[0] <= 'Я')
                {
                    surname = tb_surname.Text;
                }
                else
                {
                    MessageBox.Show("Фамилия с большой буквы");
                    return false;
                }
                if (int.Parse(tb_luggageSpace.Text) > 0 && int.Parse(tb_luggageSpace.Text) < 200)
                {
                    luggageSpace = int.Parse(tb_luggageSpace.Text);
                }
                else
                {
                    MessageBox.Show("Место для багажа от 0 до 200");
                    return false;
                }
                if (double.Parse(tb_luggageAmount.Text) > 0 && double.Parse(tb_luggageAmount.Text) < 60)
                {
                    luggageAmount = double.Parse(tb_luggageAmount.Text);
                }
                else
                {
                    MessageBox.Show("Вес для багажа от 0 до 60");
                    return false;
                }
                departureDate = dt_date.Value;
                return true;
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void Tb_flightNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(tb_flightNumber.Text, out double res))
            {
                tb_flightNumber.Text = null;
            }
        }

        private void Tb_luggageSpace_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(tb_luggageSpace.Text, out int res))
            {
                tb_luggageSpace.Text = null;
            }
        }

        private void Tb_luggageAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(tb_luggageAmount.Text, out double res))
            {
                tb_luggageAmount.Text = null;
            }
        }
    }
}
