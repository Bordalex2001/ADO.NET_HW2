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

namespace ADO.NET_HW2
{
    /// <summary>
    /// Interaction logic for ConnectionString.xaml
    /// </summary>
    public partial class ConnectionString : Window
    {
        public static SqlConnection connection;

        public ConnectionString()
        {
            InitializeComponent();
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString.Text);
                connection.Open();
                statusLbl.Content = "З'єднання з БД відбулося успішно.";
                statusLbl.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                statusLbl.Content = $"Помилка з'єднання: {ex.Message}";
                statusLbl.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }

        private void DisconnectBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    statusLbl.Content = "Роз'єдання відбулося успішно.";
                    statusLbl.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
            }
            catch (Exception ex)
            {
                statusLbl.Content = $"Помилка роз'єднання: {ex.Message}";
                statusLbl.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }
    }
}