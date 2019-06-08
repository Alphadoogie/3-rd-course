using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        DataTable dt = new DataTable();
        public Database()
        {
            InitializeComponent();
            Background = Theme.background;
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
                        connection.Close();
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
                connection.Close();
                connection.Open();
                string query = "SELECT * FROM [Luggage]";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                 dt = new DataTable("Luggage");
                sqlData.Fill(dt);
                main_dataGrid.ItemsSource = dt.DefaultView;
                sqlData.Update(dt);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.GetBaseException());
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
        private void GroupBY(string table)
        {
            try
            {
                connection.Close();
                connection.Open();
                string query = $"SELECT {table}, COUNT({table}) AS [{table}Count] FROM [Luggage] GROUP BY {table}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                 dt = new DataTable("Luggage");
                sqlData.Fill(dt);
                main_dataGrid.ItemsSource = dt.DefaultView;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.GetBaseException());
            }
        }

        private void FirstEx()
        {
            try
            {
                connection.Close();
                connection.Open();
                string query = $"Select * FROM [Luggage] Order BY surname, departureDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                 dt = new DataTable("Bills");
                sqlData.Fill(dt);
                main_dataGrid.ItemsSource = dt.DefaultView;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.GetBaseException());
            }
        }

        private void SecondEx()
        {
            try
            {
                connection.Close();
                connection.Open();
                string query = $"SELECT flightNumber, departureDate, COUNT(*) AS [CountNums] FROM [Luggage] GROUP BY departureDate, flightNumber HAVING COUNT(*) > 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                 dt = new DataTable("Luggage");
                sqlData.Fill(dt);
                main_dataGrid.ItemsSource = dt.DefaultView;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.GetBaseException());
            }
        }

        private void ThirdEx()
        {
            try
            {
                connection.Close();
                connection.Open();
                string query = $"SELECT surname, flightNumber, departureDate, luggageAmount FROM [Luggage] WHERE (DATEPART(HOUR, CONVERT(varchar(8), departureDate, 108)) BETWEEN '12' AND '15') AND luggageAmount >= 20";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                 dt = new DataTable("Luggage");
                sqlData.Fill(dt);
                main_dataGrid.ItemsSource = dt.DefaultView;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.GetBaseException());
            }
        }

        private void FourthEx()
        {
            try
            {
                connection.Close();
                connection.Open();
                string query = $"SELECT SUM(luggageAmount) AS [MinskAmount] FROM [Luggage] WHERE destination = N'Минск'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                dt = new DataTable("Luggage");
                sqlData.Fill(dt);
                main_dataGrid.ItemsSource = dt.DefaultView;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.GetBaseException());
            }
        }
        private void Cb_example_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_example.SelectedItem != null)
            {
                cb_group.SelectedItem = null;
            }
            switch (cb_example.SelectedIndex)
            {
                case 0:
                    {
                        FirstEx();
                        break;
                    }
                case 1:
                    {
                        SecondEx();
                        break;
                    }
                case 2:
                    {
                        ThirdEx();
                        break;
                    }
                case 3:
                    {
                        FourthEx();
                        break;
                    }
            }
        }

        private void Cb_group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_group.SelectedItem != null)
            {
                cb_example.SelectedItem = null;
            }
            switch (cb_group.SelectedIndex)
            {
                case 0:
                    {
                        GroupBY("flightNumber");
                        break;
                    }
                case 1:
                    {
                        GroupBY("departureDate");
                        break;
                    }
                case 2:
                    {
                        GroupBY("destination");
                        break;
                    }
                case 3:
                    {
                        GroupBY("surname");
                        break;
                    }
                case 4:
                    {
                        GroupBY("luggageSpace");
                        break;
                    }
                case 5:
                    {
                        GroupBY("luggageAmount");
                        break;
                    }
                default:
                    break;
            }
        }

        private void Button_update_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void Button_report_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter swExtLogFile = new StreamWriter("D:/report.txt", true);
            int i;
            swExtLogFile.Write(Environment.NewLine);
            foreach (DataRow row in dt.Rows)
            {
                object[] array = row.ItemArray;
                for (i = 0; i < array.Length - 1; i++)
                {
                    swExtLogFile.Write(array[i].ToString() + " | ");
                }
                swExtLogFile.WriteLine(array[i].ToString());
            }
            swExtLogFile.Write("--------------------------------------------------------------------------------" + DateTime.Now.ToString());
            swExtLogFile.Flush();
            swExtLogFile.Close();
            MessageBox.Show("Отчёт создан");
        }
    }
}
