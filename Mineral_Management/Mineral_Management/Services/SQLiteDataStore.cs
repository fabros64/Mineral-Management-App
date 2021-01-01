using Mineral_Management.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mineral_Management.Services
{
    public class SQLiteDataStore : IDataStore<DailyDietProduct>
    {
        public List<DailyDietProduct> dailyItems = new List<DailyDietProduct>();
        private SQLiteAsyncConnection _connection;

        public SQLiteDataStore()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<DailyDietProduct>().Wait();
        }

        public async Task<bool> AddItemAsync(DailyDietProduct item)
        {
            dailyItems.Add(item);

            await _connection.InsertAsync(item);  //dodanie obiektu do SQLite

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(DailyDietProduct item)
        {
            var oldItem = dailyItems.Where((DailyDietProduct arg) => arg.Id == item.Id).FirstOrDefault();
            dailyItems.Remove(oldItem);
            dailyItems.Add(item);

            await _connection.UpdateAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = dailyItems.Where((DailyDietProduct arg) => arg.Id == int.Parse(id)).FirstOrDefault();
            dailyItems.Remove(oldItem);

            await _connection.DeleteAsync(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<DailyDietProduct> GetItemAsync(string id)
        {
            return await Task.FromResult(dailyItems.FirstOrDefault(s => s.Id == int.Parse(id)));
        }

        public async Task<IEnumerable<DailyDietProduct>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                dailyItems = await _connection.Table<DailyDietProduct>().ToListAsync();
            }
            return dailyItems;
        }
    }
}
