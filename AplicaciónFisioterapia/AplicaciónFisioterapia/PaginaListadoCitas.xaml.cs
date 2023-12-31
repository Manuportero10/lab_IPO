using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para PaginaListadoCitas.xaml
    /// </summary>
    public partial class PaginaListadoCitas : Page
    {
        public static ObservableCollection<Cita> lista_citas = new ObservableCollection<Cita>();
        public static ObservableCollection<String> lista_dni_pacientes = new ObservableCollection<String>();
        public static ObservableCollection<String> lista_dni_empleados = new ObservableCollection<String>();

        public List<Cita> lista_auxiliar;
        public int indice_cita_seleccionada;
        public Cita cita_seleccionada = new Cita();
        public String formato = "dd-MM-yyyy";
        public PaginaListadoCitas()
        {
            InitializeComponent();
            crear_lista();
            anadir_dni_empleados();
            anadir_dni_pacientes();
            lstCitas.ItemsSource = lista_citas;
            cbPaciente.ItemsSource = lista_dni_pacientes;
            cbProfesional.ItemsSource = lista_dni_empleados;
        }

        private void crear_lista()
        {
            lista_citas.Clear();

            lista_citas.Add(new Cita(DateTime.ParseExact("10-05-2024",formato,null),encontrar_paciente("22222222C"),encontrar_profesional("11111111A"),600,"Tiene un leve hinchazón en la pierna"));
            lista_citas.Add(new Cita(DateTime.ParseExact("10-07-2024", formato, null), encontrar_paciente("22222222C"), encontrar_profesional("11111111A"), 500, "Tiene un leve hinchazón en el cuello"));
            lista_citas.Add(new Cita(DateTime.ParseExact("10-08-2024", formato, null), encontrar_paciente("22222222C"), encontrar_profesional("11111111A"), 601, "Tiene un leve esguince"));
            lista_citas.Add(new Cita(DateTime.ParseExact("10-02-2024", formato, null), encontrar_paciente("22222222C"), encontrar_profesional("11111111A"), 602, "Tiene un leve esguince"));
        }

        public static void anadir_dni_empleados()
        {
            lista_dni_empleados.Clear();
            foreach (var empleados in PaginaListadoEmpleados.lista_empleados)
            {
                if (empleados.rol.Equals("Doctor"))
                {
                    lista_dni_empleados.Add(empleados.DNI);
                }
            }
        }

        public static void anadir_dni_pacientes()
        {
            lista_dni_pacientes.Clear();
            foreach (var pacientes in PaginaListadoPacientes.lista_pacientes)
            {
                lista_dni_pacientes.Add(pacientes.Dni);
            }
        }
        public static Paciente encontrar_paciente(String dni_paciente)
        {
            Paciente paciente_aux = new Paciente();
            foreach (var paciente in PaginaListadoPacientes.lista_pacientes)
            {
                if (paciente.Dni.Equals(dni_paciente)){
                    paciente_aux = paciente;
                    break;
                }
            }
            
            return paciente_aux;
        }

        public static Empleado encontrar_profesional(String dni_profesional)
        {
            Empleado empleado_aux = new Empleado();
            foreach (var empleado in PaginaListadoEmpleados.lista_empleados)
            {
                if (empleado.DNI.Equals(dni_profesional))
                {                    
                    empleado_aux = empleado;
                    break;
                }
            }
            
            return empleado_aux;
        }

        private void lstCitas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnMod.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;
            btnEliminar.IsEnabled = true;
            btnMod.IsEnabled = true;
            btnDescartar.Visibility = Visibility.Hidden;
            btnGuardar.Visibility = Visibility.Hidden;
            dtFecha.IsEnabled = false;
            cbPaciente.IsEnabled = false;
            cbProfesional.IsEnabled = false;
            txtbTiempo.IsEnabled = false;
            txtObservaciones.IsEnabled = false;

            if (lstCitas.SelectedItem != null)
            {
                indice_cita_seleccionada = lstCitas.SelectedIndex;
                cbPaciente.Text = lista_citas[indice_cita_seleccionada].paciente.Dni;
                cbProfesional.Text = lista_citas[indice_cita_seleccionada].profesional.DNI;
                dtFecha.SelectedDate = lista_citas[indice_cita_seleccionada].fecha;
            }

            

        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            if (lstCitas.SelectedItem != null)
            {
                cita_seleccionada.fecha = DateTime.Parse(dtFecha.Text);
                cita_seleccionada.paciente = encontrar_paciente(cbPaciente.Text);
                cita_seleccionada.profesional = encontrar_profesional(cbProfesional.Text);
                cita_seleccionada.tiempo_en_segundos = Convert.ToInt32(txtbTiempo.Text);
                cita_seleccionada.info_adiccional = txtObservaciones.Text;

                lista_auxiliar = lista_citas.ToList();

                lstCitas.ItemsSource = null;
                lstCitas.ItemsSource = lista_auxiliar;

                dtFecha.Text = cita_seleccionada.fecha.ToString();
                cbPaciente.SelectedItem = cita_seleccionada.paciente.ToString();
                cbProfesional.SelectedItem = cita_seleccionada.profesional.ToString();
                txtbTiempo.Text = cita_seleccionada.tiempo_en_segundos.ToString();
                txtObservaciones.Text = cita_seleccionada.info_adiccional;


                btnEliminar.IsEnabled = false;
                btnMod.IsEnabled = false;
                dtFecha.IsEnabled = true;
                cbPaciente.IsEnabled = true;
                cbProfesional.IsEnabled = true;
                txtbTiempo.IsEnabled = true;
                txtObservaciones.IsEnabled = true;

                btnGuardar.Visibility = Visibility.Visible;
                btnDescartar.Visibility = Visibility.Visible;
            }

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lstCitas.SelectedItem != null)
            {
                MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar la cita seleccionada?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultado == MessageBoxResult.Yes)
                {
                    Cita cita_seleccionada = (Cita)lstCitas.SelectedItem;
                    lista_citas.Remove(cita_seleccionada);
                    lstCitas.ItemsSource = null;
                    lstCitas.ItemsSource = lista_citas;
                    cbPaciente.Text = String.Empty;
                    cbProfesional.Text = String.Empty;

                    MessageBox.Show("Cita eliminada correctamente", "Eliminación correcta", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        private void btnDescartar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres descartar los cambios realizados?", "Descartar cambios", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                dtFecha.IsEnabled = false;
                dtFecha.Text = cita_seleccionada.fecha.ToString();

                cbPaciente.IsEnabled = false;
                cbPaciente.SelectedItem = cita_seleccionada.paciente;

                cbProfesional.IsEnabled = false;
                cbProfesional.SelectedItem = cita_seleccionada.profesional;

                txtbTiempo.IsEnabled = false;
                txtbTiempo.Text = cita_seleccionada.tiempo_en_segundos.ToString();

                txtObservaciones.IsEnabled = false;
                txtObservaciones.Text = cita_seleccionada.info_adiccional;

                lstCitas.ItemsSource = null;
                lstCitas.ItemsSource = lista_citas;

                btnMod.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnDescartar.Visibility = Visibility.Hidden;
                btnGuardar.Visibility = Visibility.Hidden;

            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres guardar los cambios realizados?", "Realizar cambios", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                dtFecha.IsEnabled = false;
                cbPaciente.IsEnabled = false;
                cbProfesional.IsEnabled = false;
                txtbTiempo.IsEnabled = false;
                txtObservaciones.IsEnabled = false;


                lista_citas[indice_cita_seleccionada]
                    = new Cita(DateTime.Parse(dtFecha.Text),encontrar_paciente(cbPaciente.Text)
                    , encontrar_profesional(cbProfesional.Text),Convert.ToInt32(txtbTiempo.Text)
                    , txtObservaciones.Text);

                lstCitas.ItemsSource = null;
                lstCitas.ItemsSource = lista_citas;

                btnMod.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnDescartar.Visibility = Visibility.Hidden;
                btnGuardar.Visibility = Visibility.Hidden;
                
                MessageBox.Show("Cita modificada con éxito", "Modificación exitosa", MessageBoxButton.OK, MessageBoxImage.None);

            }
        }

        //OYENTES
        private Boolean ComprobarEntradaTiempo()
        {
            Boolean valido = false;
            if (int.TryParse(txtbTiempo.Text, out int numero) && txtbTiempo.IsEnabled == true
                && numero > 0)
            {
                // borde y background en verde
                txtbTiempo.BorderBrush = Brushes.Green;
                txtbTiempo.Background = Brushes.LightGreen;
                valido = true;
            }
            else
            {
                if (txtbTiempo.IsEnabled == false)
                {
                    valido = false;
                    txtbTiempo.BorderBrush = Brushes.DimGray;
                    txtbTiempo.Background = Brushes.White;
                }
                else
                {
                    // marcamos borde en rojo
                    txtbTiempo.BorderBrush = Brushes.Red;
                    txtbTiempo.Background = Brushes.LightCoral;
                    valido = false;
                }

            }
            return valido;
        }
        private Boolean campos_completos()
        {
            if (dtFecha.SelectedDate != null && cbPaciente.SelectedItem != null
                && cbProfesional.SelectedItem != null && ComprobarEntradaTiempo())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dtFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (campos_completos())
            {
                btnGuardar.IsEnabled = true;
            }
            else
            {
                btnGuardar.IsEnabled = false;
            }
        }

        private void cbPaciente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (campos_completos())
            {
                btnGuardar.IsEnabled = true;
            }
            else
            {
                btnGuardar.IsEnabled = false;
            }
        }

        private void cbProfesional_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (campos_completos())
            {
                btnGuardar.IsEnabled = true;
            }
            else
            {
                btnGuardar.IsEnabled = false;
            }
        }

        private void txtbTiempo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (campos_completos())
            {
                btnGuardar.IsEnabled = true;
            }
            else
            {
                btnGuardar.IsEnabled = false;
            }
        }

        private void txtbTiempo_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaTiempo() && campos_completos())
            {
                btnGuardar.IsEnabled = true;
            }
            else
            {
                btnGuardar.IsEnabled = false;
            }
        }
    }
}
