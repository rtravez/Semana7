using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semana7.Models;
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
        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
           
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario = ? and Contrasenia =?", usuario, contrasenia);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documenthpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documenthpath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasenia.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultarRegistroPage());
                }
                else
                {
                    DisplayAlert("Alerta", "Verifique su usuario/contraseña", "Ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Ok");
            }
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroPage());

        }
    }
}