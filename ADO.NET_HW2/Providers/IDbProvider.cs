using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW2
{
    public interface IDbProvider
    {
        Task ConnectAsync();
        void Disconnect();
        Task<DataTable> GetAllAsync();
        Task<DataTable> GetNamesAsync();
        Task<DataTable> GetColorsAsync();
        Task<DataTable> GetMinCaloriesAsync();
        Task<DataTable> GetMaxCaloriesAsync();
        Task<DataTable> GetAvgCaloriesAsync();
        Task<DataTable> GetCountVegetablesAsync();
        Task<DataTable> GetCountFruitsAsync();
        Task<DataTable> GetCountByChosenColorAsync(string color);
        Task<DataTable> GetCountEachColorAsync();
        Task<DataTable> GetCaloriesBelowValueAsync(int calories);
        Task<DataTable> GetCaloriesAboveValueAsync(int calories);
        Task<DataTable> GetCaloriesByRangeAsync(int minCalories, int maxCalories);
        Task<DataTable> GetYellowOrRedColorAsync();
        Task<DataTable> GetIdsAsync();
        Task<DataTable> GetValuesByIdAsync(int id);
        Task<DataTable> GetTypesAsync();
        Task<int> PutValuesByIdAsync(int id, string name, string type, string color, string caloricContent);
        Task<int> DeleteRowByIdAsync(int id);
    }
}