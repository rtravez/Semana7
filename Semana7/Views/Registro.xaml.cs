using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datosRegistro = new Models.Estudiante
            {
                Nombre = txtNombre.Text,
                Usuario = txtUsuario.Text,
                Contrasenia = txtContrasenia.Text
            };

            con.InsertAsync(datosRegistro);
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasenia.Text = "";

        }
    }
}