using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Mineral_Management.iOS;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Mineral_Management.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); 
            var path = Path.Combine(documentsPath, "DailyDietDB.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}

