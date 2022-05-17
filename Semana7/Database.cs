using SQLite;

namespace Semana7
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
