using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplicaciónFisioterapia
{
    /// <summary>
    /// Lógica de interacción para PaginaAñadirPacientes.xaml
    /// </summary>
    public partial class PaginaAñadirPacientes : Page
    {
        public PaginaAñadirPacientes()
        {
            InitializeComponent();
        }


        private Boolean campos_completos()
        {
            if (txtbDNI.Text != String.Empty && txtbNombre.Text != String.Empty
                && txtbEdad.Text != String.Empty && txtbTarjeta.Text != String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtbNombreTextChanged(object sender, TextChangedEventArgs e)
        {
            if (campos_completos())
            {
                btn_alta.IsEnabled = true;
            }
            else
            {
                btn_alta.IsEnabled = false;
            }
        }

        private void txtbDNITextChanged(object sender, TextChangedEventArgs e)
        {
            if (campos_completos())
            {
                btn_alta.IsEnabled = true;
            }
            else
            {
                btn_alta.IsEnabled = false;
            }
        }

        private void txtbEdadTextChanged(object sender, TextChangedEventArgs e)
        {
            if (campos_completos())
            {
                btn_alta.IsEnabled = true;
            }
            else
            {
                btn_alta.IsEnabled = false;
            }
        }

        private void txtTarjetaTextChanged(object sender, TextChangedEventArgs e)
        {
            if (campos_completos())
            {
                btn_alta.IsEnabled = true;
            }
            else
            {
                btn_alta.IsEnabled = false;
            }
        }

        private void btn_alta_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Quieres dar de alta a " + txtbNombre.Text + "?", "Alta", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                PaginaListadoPacientes.lista_pacientes.Add
                    (new Paciente(txtbNombre.Text, txtbDNI.Text, Convert.ToInt32(txtbEdad.Text)
                    , Convert.ToInt32(txtbTarjeta.Text)));

                MessageBox.Show("Paciente " + txtbNombre.Text + " dado de alta correctamente");
            }
        }
    }
}
