using Semana7.Droid;
using SQLite;
using System.IO;

[assembly:Xamarin.Forms.Dependency(typeof(SqliteCliente))]
namespace Semana7.Droid
{
    class SqliteCliente : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);

        }
    }
}