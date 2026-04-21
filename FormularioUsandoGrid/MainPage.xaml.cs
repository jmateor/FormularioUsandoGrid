using System.Text.RegularExpressions;

namespace FormularioUsandoGrid
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnEnviarClicked(object sender, EventArgs e)
        {
            string mensajeError = ValidarFormulario();

            if (!string.IsNullOrEmpty(mensajeError))
            {
                await DisplayAlert("Error", mensajeError, "OK");
            }
            else
            {
                await DisplayAlert("Éxito", "Formulario enviado correctamente", "OK");
            }
        }

        private string ValidarFormulario()
        {
            // Nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                return "El nombre es obligatorio";

            // Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return "El correo es obligatorio";

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "El correo no es válido";

            // Picker
            if (pickerGenero.SelectedIndex == -1)
                return "Seleccione un género";

            // Fecha
            if (dateNacimiento.Date > DateTime.Now)
                return "La fecha no puede ser futura";

            // Checkbox
            if (!chkTerminos.IsChecked)
                return "Debe aceptar los términos";

            return "";
        }
    }
}