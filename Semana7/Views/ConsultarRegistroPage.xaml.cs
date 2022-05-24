using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Semana7.Models;
using Xamarin.Forms.Xaml;

namespace Semana7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarRegistroPage : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiantes;
       
        public ConsultarRegistroPage()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiantes = new ObservableCollection<Estudiante>(resultado);
            listaUsuarios.ItemsSource = tablaEstudiantes;
            base.OnAppearing();
        }

        private void listaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var id = Convert.ToInt32(item);

            Navigation.PushAsync(new ElementoPage(obj));
        }
    }
}