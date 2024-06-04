using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private ObservableCollection<Operacion> _operaciones;

        public Registro(ObservableCollection<Operacion> operaciones)
        {
            InitializeComponent();
            _operaciones = operaciones;
            OperationsListView.ItemsSource = _operaciones;
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var operacion = menuItem.CommandParameter as Operacion;

            if (operacion != null)
            {
                bool answer = await DisplayAlert("Confirmación", "¿Estás seguro de eliminar este registro?", "Sí", "Cancelar");
                if (answer)
                {
                    if (_operaciones.Contains(operacion))
                    {
                        _operaciones.Remove(operacion);
                    }
                }
            }
        }

        public class Operacion
        {
            public DateTime Fecha { get; set; }
            public string TipoOperacion { get; set; }
            public int Numero1 { get; set; }
            public int Numero2 { get; set; }
            public double Resultado { get; set; }
        }
    }
}