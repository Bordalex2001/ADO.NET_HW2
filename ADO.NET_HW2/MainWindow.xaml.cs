using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace ADO.NET_HW2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void showAllBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from List", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showNamesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Name as N'Назва' from List", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showColorsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Color as N'Колір' from List", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void minCaloriesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select MIN(CaloricContent) as N'Найменша калорійність' from List", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void maxCaloriesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select MAX(CaloricContent) as N'Найбільша калорійність' from List", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void avgCaloriesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select AVG(CaloricContent) as N'Середня калорійність' from List", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void countVegetablesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select count(*) as N'Кількість овочів' from List where Type = N'Овочі'", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void countFruitsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select count(*) as N'Кількість фруктів' from List where Type = N'Фрукти' or Type = N'Ягоди'", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void countByChosenColorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string color = Prompt.ShowDialog("Уведіть колір:");
                if (!string.IsNullOrWhiteSpace(color))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select count(*) as N'{color} колір' from List where Color = N'{color}'", ConnectionString.connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void countEachColorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Color as N'Колір', count(*) as N'Кількість' from List group by Color", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void caloriesBelowValueBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string calories = Prompt.ShowDialog("Уведіть кількість калорій:");
                if (!string.IsNullOrWhiteSpace(calories))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select * from List where CaloricContent < {calories}", ConnectionString.connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void caloriesAboveValueBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string calories = Prompt.ShowDialog("Уведіть кількість калорій:");
                if (!string.IsNullOrWhiteSpace(calories))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select * from List where CaloricContent > {calories}", ConnectionString.connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void caloriesByRangeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string minCalories = Prompt.ShowDialog("Уведіть найменшу кількість калорій:");
                string maxCalories = Prompt.ShowDialog("Уведіть найбільшу кількість калорій:");
                if (!string.IsNullOrWhiteSpace(minCalories) && !string.IsNullOrWhiteSpace(maxCalories))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select * from List where CaloricContent between {minCalories} and {maxCalories}", ConnectionString.connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void yellowOrRedColorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from List where Color = N'Жовтий' or Color = N'Червоний'", ConnectionString.connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}