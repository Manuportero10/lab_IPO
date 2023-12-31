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
    /// Lógica de interacción para PaginaAñadirEmpleado.xaml
    /// </summary>
    public partial class PaginaAñadirEmpleado : Page
    {
        public List<String> lista_roles = new List<string>();
        public PaginaAñadirEmpleado()
        {
            InitializeComponent();
            lista_roles.Add("Doctor");
            lista_roles.Add("Oficinista");
            lista_roles.Add("Programador");
            cbRol_emp.ItemsSource = lista_roles;
        }

        private Boolean campos_completos()
        {
            if (txtbDNI_emp.Text != String.Empty && txtbNombre_emp.Text != String.Empty
                && txtbSueldo_emp.Text != String.Empty && txtExpir_emp.Text != String.Empty
                && cbRol_emp.SelectedItem != null && ComprobarEntradaDNI(txtbDNI_emp) &&
                ComprobarEntradaEntero(txtbSueldo_emp) && ComprobarEntradaEnteroAnio(txtExpir_emp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cbRol_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            MessageBoxResult resultado = MessageBox.Show("¿Quieres dar de alta a " + txtbNombre_emp.Text + "?","Alta",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                PaginaListadoEmpleados.lista_empleados.Add
                    (new Empleado(txtbNombre_emp.Text,txtbDNI_emp.Text,Convert.ToInt32(txtbSueldo_emp.Text)
                    ,Convert.ToInt32(txtExpir_emp.Text),cbRol_emp.SelectedItem.ToString()));

                MessageBox.Show("Empleado " + txtbNombre_emp.Text + " dado de alta correctamente");
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

        private Boolean ComprobarEntradaEnteroAnio(TextBox txtb)
        {
            Boolean valido = false;
            if (int.TryParse(txtb.Text, out int numero) && numero > 0 && txtb.Text.Length == 4)
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

        private void txtbSueldo_emp_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaEntero(txtbSueldo_emp) && campos_completos())
            {
                btn_alta.IsEnabled = true;
            }
            else
            {
                btn_alta.IsEnabled = false;
            }
        }

        private void txtbNombre_emp_KeyUp(object sender, KeyEventArgs e)
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

        private void txtbDNI_emp_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaDNI(txtbDNI_emp) && campos_completos())
            {
                btn_alta.IsEnabled = true;
            }
            else
            {
                btn_alta.IsEnabled = false;
            }
        }

        private void txtExpir_emp_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaEnteroAnio(txtExpir_emp) && campos_completos())
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
