using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Semana7.Models;

namespace Semana7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElementoPage : ContentPage
    {
        private SQLiteAsyncConnection con;
        private IEnumerable<Estudiante> deleteEstudiante;
        private IEnumerable<Estudiante> updateEstudiante;
        private Estudiante estudiante;
        public ElementoPage(Estudiante estudiante)
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            this.estudiante = estudiante;
            txtId.Text = estudiante.Id.ToString();
            txtNombre.Text = estudiante.Nombre;
            txtUsuario.Text = estudiante.Usuario;
            txtContrasenia.Text = estudiante.Contrasenia;
        }

        public static IEnumerable<Estudiante> delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("Delete from Estudiante where Id=?", id);
        }

        public static IEnumerable<Estudiante> update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("Update Estudiante set Nombre =?, Usuario=?, Contrasenia=? where Id=?", nombre, usuario, contrasenia, id);
        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasepath);
                updateEstudiante = update(db, txtNombre.Text, txtUsuario.Text, txtContrasenia.Text, estudiante.Id);
                DisplayAlert("Alerta", "Se actualizo correctamente", "ok");

            }
            catch (Exception ex) {
                throw ex;
            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try {
                var databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasepath);
                deleteEstudiante = delete(db, estudiante.Id);
                DisplayAlert("Alerta", "Se elimino correctamente", "ok");


            } catch (Exception ex) {
                throw ex;
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultarRegistroPage());
        }
    }
}