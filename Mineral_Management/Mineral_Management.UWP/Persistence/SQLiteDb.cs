using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Mineral_Management.UWP;
using Mineral_Management;
using Windows.Storage;
using System.Threading.Tasks;

[assembly: Dependency(typeof(SQLiteDb))]


namespace Mineral_Management.UWP
{
	public class SQLiteDb : ISQLiteDb
	{
        private SQLiteAsyncConnection _connection;

        public async Task<string> GetDataBasePath()
        {
            string filename = "ddb.db3";         
            await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
            return dbpath;
        }

		public SQLiteAsyncConnection GetConnection()
		{
            if (_connection != null)
                return _connection;

            string dbPath = GetDataBasePath().ToString();
            return _connection = new SQLiteAsyncConnection(dbPath);
		}

    }
}

