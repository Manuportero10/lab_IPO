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
                && txtbEdad.Text != String.Empty && txtbTarjeta.Text != String.Empty 
                && ComprobarEntradaDNI(txtbDNI))
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

        private Boolean ComprobarEntradaEntero(TextBox txtb)
        {
            Boolean valido = false;
            if (int.TryParse(txtb.Text, out int numero) && numero > 0)
            {
                // borde y background en verde
                txtb.BorderBrush = Brushes.Green;
                txtb.Background = Brushes.LightGreen;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                txtb.BorderBrush = Brushes.Red;
                txtb.Background = Brushes.LightCoral; ;
                valido = false;
            }
            return valido;
        }

        private Boolean ComprobarEntradaDNI(TextBox txtb)
        {
            Boolean valido = false;
            char[] dni = txtb.Text.ToCharArray();
            if (txtb.Text.Length == 9 && int.TryParse(txtb.Text.Substring(0, 8), out _)
                && char.IsLetter(dni[dni.Length - 1]))
            {
                // borde y background en verde
                txtb.BorderBrush = Brushes.Green;
                txtb.Background = Brushes.LightGreen;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                txtb.BorderBrush = Brushes.Red;
                txtb.Background = Brushes.LightCoral; ;
                valido = false;
            }
            return valido;
        }
        private void txtbDNI_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaDNI(txtbDNI) && campos_completos())
            {
                btn_alta.IsEnabled = true;
            }
            else
            {
                btn_alta.IsEnabled = false;
            }
        }

        private void txtbEdad_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaEntero(txtbEdad) && campos_completos())
            {
                btn_alta.IsEnabled = true;
            }
            else
            {
                btn_alta.IsEnabled = false;
            }
        }

        private void txtbTarjeta_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaEntero(txtbTarjeta) && campos_completos())
            {
                btn_alta.IsEnabled = true;
            }
            else
            {
                btn_alta.IsEnabled = false;
            }
        }

    }
}
