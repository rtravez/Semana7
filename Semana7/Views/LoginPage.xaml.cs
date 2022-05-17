using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace Semana7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private SQLiteAsyncConnection con;

        public LoginPage()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }
        public static IEnumerable<Models.Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Models.Estudiante>("SELECT * FROM Estudiante where Usuario = ? and Contrasenia = ?", usuario, contrasenia);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                var db = new SQLiteConnection(documetPath);
                db.CreateTable<Models.Estudiante>();
                IEnumerable<Models.Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasenia.Text);

                if (resultado.Count() > 1)
                {
                    DisplayAlert("Alerta","Usuario Correcto", "Ok");
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario Incorrecto", "Ok");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());

        }
    }
}