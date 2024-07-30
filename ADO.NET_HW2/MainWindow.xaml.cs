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
using System.Collections;

namespace ADO.NET_HW2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDbProvider dbProvider;
        
        public MainWindow(IDbProvider dbProvider)
        {
            InitializeComponent();
            this.dbProvider = dbProvider;
        }

        private async void showAllBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from List", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetAllAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void showNamesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Name as N'Назва' from List", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetNamesAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void showColorsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Color as N'Колір' from List", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetColorsAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void minCaloriesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select MIN(CaloricContent) as N'Найменша калорійність' from List", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetMinCaloriesAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void maxCaloriesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select MAX(CaloricContent) as N'Найбільша калорійність' from List", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetMaxCaloriesAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void avgCaloriesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select AVG(CaloricContent) as N'Середня калорійність' from List", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetAvgCaloriesAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void countVegetablesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select count(*) as N'Кількість овочів' from List where Type = N'Овочі'", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetCountVegetablesAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void countFruitsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select count(*) as N'Кількість фруктів' from List where Type = N'Фрукти' or Type = N'Ягоди'", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetCountFruitsAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void countByChosenColorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string colorInput = Prompt.ShowDialog("Уведіть колір:");
                if (!string.IsNullOrWhiteSpace(colorInput))
                {
                    //SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select count(*) as N'{color} колір' from List where Color = N'{color}'", ConnectionString.connection);
                    DataTable dataTable = await dbProvider.GetCountByChosenColorAsync(colorInput);
                    //dataAdapter.Fill(dataTable);
                    dataGridView.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void countEachColorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Color as N'Колір', count(*) as N'Кількість' from List group by Color", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetCountEachColorAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void caloriesBelowValueBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caloriesInput = Prompt.ShowDialog("Уведіть кількість калорій:");
                if (!string.IsNullOrWhiteSpace(caloriesInput) && int.TryParse(caloriesInput, out int calories))
                {
                    //SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select * from List where CaloricContent < {calories}", ConnectionString.connection);
                    DataTable dataTable = await dbProvider.GetCaloriesBelowValueAsync(calories);
                    //dataAdapter.Fill(dataTable);
                    dataGridView.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void caloriesAboveValueBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caloriesInput = Prompt.ShowDialog("Уведіть кількість калорій:");
                if (!string.IsNullOrWhiteSpace(caloriesInput) && int.TryParse(caloriesInput, out int calories))
                {
                    //SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select * from List where CaloricContent > {calories}", ConnectionString.connection);
                    DataTable dataTable = await dbProvider.GetCaloriesAboveValueAsync(calories);
                    //dataAdapter.Fill(dataTable);
                    dataGridView.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void caloriesByRangeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string minCaloriesInput = Prompt.ShowDialog("Уведіть найменшу кількість калорій:");
                string maxCaloriesInput = Prompt.ShowDialog("Уведіть найбільшу кількість калорій:");
                if ((!string.IsNullOrWhiteSpace(minCaloriesInput) && int.TryParse(minCaloriesInput, out int minCalories))
                    && (!string.IsNullOrWhiteSpace(maxCaloriesInput) && int.TryParse(maxCaloriesInput, out int maxCalories)))
                {
                    if (minCalories > maxCalories || maxCalories < minCalories)
                    {
                        MessageBox.Show("Найменше значення більше за найбільше. Спробуйте заповнити поля ще раз", "Ой", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    //SqlDataAdapter dataAdapter = new SqlDataAdapter($"Select * from List where CaloricContent between {minCalories} and {maxCalories}", ConnectionString.connection);
                    DataTable dataTable = await dbProvider.GetCaloriesByRangeAsync(minCalories, maxCalories);
                    //dataAdapter.Fill(dataTable);
                    dataGridView.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void yellowOrRedColorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from List where Color = N'Жовтий' or Color = N'Червоний'", ConnectionString.connection);
                DataTable dataTable = await dbProvider.GetYellowOrRedColorAsync();
                //dataAdapter.Fill(dataTable);
                dataGridView.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void openDataHandlingBtn_Click(object sender, RoutedEventArgs e)
        {
            DataHandling dataHandling = new DataHandling(dbProvider);
            dataHandling.Show();
        }
    }
}