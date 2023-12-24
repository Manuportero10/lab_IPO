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
                && cbRol_emp.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtbNombre_emp_TextChanged(object sender, TextChangedEventArgs e)
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

        private void txtbDNI_emp_TextChanged(object sender, TextChangedEventArgs e)
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

        private void txtbSueldo_emp_TextChanged(object sender, TextChangedEventArgs e)
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

        private void txtExpir_emp_TextChanged(object sender, TextChangedEventArgs e)
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
    }
}
