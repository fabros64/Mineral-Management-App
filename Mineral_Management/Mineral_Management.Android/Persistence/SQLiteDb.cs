using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Mineral_Management.Droid;
using Mineral_Management;


[assembly: Dependency(typeof(SQLiteDb))]
namespace Mineral_Management.Droid
{
	public class SQLiteDb : ISQLiteDb
	{
        private SQLiteAsyncConnection _connection;

        public string GetDataBasePath()
        {
            string filename = "DailyDiet.db3";
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }

		public SQLiteAsyncConnection GetConnection()
		{
            if (_connection != null)
                return _connection;

            return _connection = new SQLiteAsyncConnection(GetDataBasePath());
		}
	}
}

