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
    /// Lógica de interacción para PaginaAñadirCita.xaml
    /// </summary>
    public partial class PaginaAñadirCita : Page
    {
        public PaginaAñadirCita()
        {
            InitializeComponent();
            cbPaciente.ItemsSource = obtener_dni_pacientes();
            cbProfesional.ItemsSource = obtener_dni_empleados();
        }

        private List<String> obtener_dni_pacientes()
        {
            List<String> lista_nombres = new List<String>();
            foreach (var paciente in PaginaListadoPacientes.lista_pacientes)
            {
                lista_nombres.Add(paciente.Dni);
            }
            return lista_nombres;
        }

        private List<String> obtener_dni_empleados()
        {
            //OBERVACION: Solo tienen que ser los doctores, ya que son los unicos
            // que antienden a los pacientes.

            List<String> lista_nombres = new List<String>();
            foreach (var empleado in PaginaListadoEmpleados.lista_empleados)
            {
                if (empleado.rol.Equals("Doctor"))
                {
                    lista_nombres.Add(empleado.DNI);
                }
            }
            return lista_nombres;
        }
        private Boolean campos_completos()
        {
            if (dtpFecha.SelectedDate != null && cbPaciente.SelectedItem != null
                && cbProfesional.SelectedItem != null && ComprobarEntradaTiempo())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cbPaciente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (campos_completos())
            {
                btn_cita.IsEnabled = true;
            }
            else
            {
                btn_cita.IsEnabled = false;
            }
        }

        private void cbProfesional_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (campos_completos())
            {
                btn_cita.IsEnabled = true;
            }
            else
            {
                btn_cita.IsEnabled = false;
            }
        }
        private void txtTiempoTextChanged(object sender, TextChangedEventArgs e)
        {
            if (campos_completos())
            {
                btn_cita.IsEnabled = true;
            }
            else
            {
                btn_cita.IsEnabled = false;
            }
        }

        private void dtpFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (campos_completos())
            {
                btn_cita.IsEnabled = true;
            }
            else
            {
                btn_cita.IsEnabled = false;
            }
        }

        private void btn_cita_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Quieres añadir la cita con fecha " + dtpFecha.Text + "?", "Cita", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                PaginaListadoCitas.lista_citas.Add
                    (new Cita(DateTime.Parse(dtpFecha.Text),PaginaListadoCitas.encontrar_paciente(cbPaciente.Text),
                    PaginaListadoCitas.encontrar_profesional(cbProfesional.Text)
                    ,Convert.ToInt32(txtTiempo.Text),txtObservacion.Text));

                PaginaListadoCitas.anadir_dni_empleados();
                PaginaListadoCitas.anadir_dni_pacientes();

                MessageBox.Show("Cita creada correctamente");
            }
        }

        private Boolean ComprobarEntradaTiempo()
        {
            Boolean valido = false;
            if (int.TryParse(txtTiempo.Text, out int numero) && numero > 0)
            {
                // borde y background en verde
                txtTiempo.BorderBrush = Brushes.Green;
                txtTiempo.Background = Brushes.LightGreen;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                txtTiempo.BorderBrush = Brushes.Red;
                txtTiempo.Background = Brushes.LightCoral;;
                valido = false;
            }
            return valido;
        }

        private void txtTiempo_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaTiempo() && campos_completos())
            {
                btn_cita.IsEnabled = true;
            }
            else
            {
                btn_cita.IsEnabled = false;
            }

        }
    }
}
