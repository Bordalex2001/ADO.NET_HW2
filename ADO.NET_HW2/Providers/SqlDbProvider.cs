using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace ADO.NET_HW2
{
    public class SqlDbProvider : IDbProvider
    {
        private SqlConnection connection;
        private readonly string connectionString;

        public SqlDbProvider()
        {
            //this.connectionString = connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public async Task ConnectAsync() 
        {
            connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
        }

        public void Disconnect() 
        {
            connection.Close();
        }

        private async Task<DataTable> ExecuteQueryAsync(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            return dataTable;
        }

        private async Task<int> ExecuteNonQueryAsync(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            return await command.ExecuteNonQueryAsync();
        }

        public Task<DataTable> GetAllAsync() 
        {
            string query = "Select * from List";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }
        
        public Task<DataTable> GetNamesAsync() 
        {
            string query = "Select Name as N'Назва' from List";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }
        
        public Task<DataTable> GetColorsAsync() 
        {
            string query = "Select distinct Color as N'Колір' from List";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetMinCaloriesAsync() 
        {
            string query = "Select MIN(CaloricContent) as N'Найменша калорійність' from List";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }
        
        public Task<DataTable> GetMaxCaloriesAsync() 
        {
            string query = "Select MAX(CaloricContent) as N'Найбільша калорійність' from List";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }
        
        public Task<DataTable> GetAvgCaloriesAsync() 
        {
            string query = "Select AVG(CaloricContent) as N'Середня калорійність' from List";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }
        
        public Task<DataTable> GetCountVegetablesAsync() 
        {
            string query = "Select count(*) as N'Кількість овочів' from List where Type = N'Овочі'";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }
        
        public Task<DataTable> GetCountFruitsAsync() 
        {
            string query = "Select count(*) as N'Кількість фруктів' from List where Type = N'Фрукти' or Type = N'Ягоди'";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetCountByChosenColorAsync(string color) 
        {
            string query = $"Select count(*) as N'{color} колір' from List where Color = N'{color}'";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetCountEachColorAsync() 
        {
            string query = "Select Color as N'Колір', count(*) as N'Кількість' from List group by Color";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetCaloriesBelowValueAsync(int calories) 
        {
            string query = $"Select * from List where CaloricContent < {calories}";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetCaloriesAboveValueAsync(int calories) 
        {
            string query = $"Select * from List where CaloricContent > {calories}";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetCaloriesByRangeAsync(int minCalories, int maxCalories) 
        {
            string query = $"Select * from List where CaloricContent between {minCalories} and {maxCalories}";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetYellowOrRedColorAsync() 
        {
            string query = "Select * from List where Color = N'Жовтий' or Color = N'Червоний'";
            /*SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);*/
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetIdsAsync()
        {
            string query = "Select Id from List";
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetValuesByIdAsync(int id)
        {
            string query = $"Select * from List where Id = {id}";
            return ExecuteQueryAsync(query);
        }

        public Task<DataTable> GetTypesAsync()
        {
            string query = "Select distinct Type from List";
            return ExecuteQueryAsync(query);
        }

        public Task<int> PutValuesByIdAsync(int id, string name, string type, string color, string caloricContent)
        {
            string query = $"Update List set Name = N'{name}', Type = N'{type}', Color = N'{color}', CaloricContent = {caloricContent} where Id = {id}";
            return ExecuteNonQueryAsync(query);
        }

        public Task<int> DeleteRowByIdAsync(int id)
        {
            string query = $"Delete from List where Id = {id}";
            return ExecuteNonQueryAsync(query);
        }
    }
}