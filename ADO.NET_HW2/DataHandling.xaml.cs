using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ADO.NET_HW2
{
    /// <summary>
    /// Interaction logic for DataHandling.xaml
    /// </summary>
    public partial class DataHandling : Window
    {
        private readonly IDbProvider dbProvider;

        public DataHandling(IDbProvider dbProvider)
        {
            InitializeComponent();
            this.dbProvider = dbProvider;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable ids = await dbProvider.GetIdsAsync();
                idComboBox.ItemsSource = ids.DefaultView;
                idComboBox.DisplayMemberPath = "Id";
                idComboBox.SelectedValuePath = "Id";
                idComboBox.SelectedIndex = 0;

                DataTable types = await dbProvider.GetTypesAsync();
                typeComboBox.ItemsSource = types.DefaultView;
                typeComboBox.DisplayMemberPath = "Type";
                typeComboBox.SelectedValuePath = "Type";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = (int)idComboBox.SelectedValue;
                DataTable valuesById = await dbProvider.GetValuesByIdAsync(id);
                if (valuesById.Rows.Count > 0)
                { 
                    nameTxtBox.Text = valuesById.Rows[0]["Name"].ToString();
                    typeComboBox.SelectedValue = valuesById.Rows[0]["Type"];
                    colorTxtBox.Text = valuesById.Rows[0]["Color"].ToString();
                    caloricContentTxtBox.Text = valuesById.Rows[0]["CaloricContent"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (int)idComboBox.SelectedValue;
                string name = nameTxtBox.Text;
                string type = typeComboBox.Text;
                string color = colorTxtBox.Text;
                string caloricContent = caloricContentTxtBox.Text;

                int rowsAffected = await dbProvider.PutValuesByIdAsync(id, name, type, color, caloricContent);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Дані оновлено успішно", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Дані не збігаються за порядковим номером (Id)", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (int)idComboBox.SelectedValue;

                int rowsAffected = await dbProvider.DeleteRowByIdAsync(id);
                if (rowsAffected > 0) 
                {
                    MessageBox.Show("Дані видалено успішно", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Дані не збігаються за порядковим номером (Id)", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}