using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Tarea1.Registro;

namespace Tarea1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Registro.Operacion> Operaciones { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Operaciones = new ObservableCollection<Registro.Operacion>();
            OperationsListView.ItemsSource = Operaciones;
        }

        private void OnOperationButtonClicked(object sender, EventArgs e)
        {
            if (int.TryParse(FirstNumberEntry.Text, out int firstNumber) && int.TryParse(SecondNumberEntry.Text, out int secondNumber))
            {
                string operacion = (string)((Button)sender).CommandParameter;
                double resultado = 0;

                switch (operacion)
                {
                    case "Sumar":
                        resultado = firstNumber + secondNumber;
                        break;
                    case "Restar":
                        resultado = firstNumber - secondNumber;
                        break;
                    case "Multiplicar":
                        resultado = firstNumber * secondNumber;
                        break;
                    case "Dividir":
                        if (secondNumber != 0)
                        {
                            resultado = (double)firstNumber / secondNumber;
                        }
                        else
                        {
                            ResultLabel.Text = "No se puede dividir por cero.";
                            return;
                        }
                        break;
                }

                // Registrar la operación
                Operaciones.Add(new Registro.Operacion
                {
                    Fecha = DateTime.Now,
                    TipoOperacion = operacion,
                    Numero1 = firstNumber,
                    Numero2 = secondNumber,
                    Resultado = resultado
                });

                // Mostrar el resultado
                ResultLabel.Text = $"El resultado es: {resultado}";
            }
            else
            {
                ResultLabel.Text = "Por favor, ingrese números válidos.";
            }
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var operacion = button?.CommandParameter as Registro.Operacion;

            if (operacion != null)
            {
                Operaciones.Remove(operacion);
            }
        }

        private async void OnVerRegistroButtonClicked(object sender, EventArgs e)
        {
            // Crear una instancia de la página Registro y pasar la colección de operaciones
            Registro registro = new Registro(Operaciones);

            // Navegar a la página Registro
            await Navigation.PushAsync(registro);
        }

        private async void OnGoToRegistroButtonClicked(object sender, EventArgs e)
        {
            // Crear una instancia de la página Registro y pasar la colección de operaciones
            Registro registro = new Registro(Operaciones);

            // Navegar a la página Registro
            await Navigation.PushAsync(registro);
        }



    }
}