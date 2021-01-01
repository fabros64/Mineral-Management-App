using SQLite;

namespace Mineral_Management
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

