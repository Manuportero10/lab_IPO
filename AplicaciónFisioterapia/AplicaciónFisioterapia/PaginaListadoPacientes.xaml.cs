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
    /// Lógica de interacción para PaginaListadoPacientes.xaml
    /// </summary>
    
    public partial class PaginaListadoPacientes : Page
    {
        public static ObservableCollection<Paciente> lista_pacientes = new ObservableCollection<Paciente>();
        public Paciente paciente_seleccionado = new Paciente();
        public int indice_paciente_seleccionado;
        public List<Paciente> lista_auxiliar_pacientes;
        public PaginaListadoPacientes()
        {
            InitializeComponent();
            crear_lista();
            lstPacientes.ItemsSource = lista_pacientes;
        }

        public void crear_lista()
        {
            lista_pacientes.Clear();
            lista_pacientes.Add(new Paciente("Ernesto", "22222222A",5,677172));
            lista_pacientes.Add(new Paciente("Claudia", "22222222B", 33, 677172));
            lista_pacientes.Add(new Paciente("Alberto", "22222222C", 15, 871855));
            lista_pacientes.Add(new Paciente("José", "22222222D", 88, 719285));
        }

        private void lstPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnMod_pac.Visibility = Visibility.Visible;
            btnEliminar_pac.Visibility = Visibility.Visible;
            btnEliminar_pac.IsEnabled = true;
            btnMod_pac.IsEnabled = true;
            btnDescartar_pac.Visibility = Visibility.Hidden;
            btnGuardar_pac.Visibility = Visibility.Hidden;
            txtbDNI.IsEnabled = false;
            txtbEdad.IsEnabled = false;
            txtbNombre.IsEnabled = false;
            txtbID.IsEnabled = false;
            txtbTarjeta.IsEnabled = false;

            txtbTarjeta.BorderBrush = Brushes.DimGray; //que se muestre como antes
            txtbTarjeta.Background = Brushes.White;
            txtbEdad.BorderBrush = Brushes.DimGray;
            txtbEdad.Background = Brushes.White;

            if (lstPacientes.SelectedItem != null)
            {
                indice_paciente_seleccionado = lstPacientes.SelectedIndex;
            }

        }
        private void btnMod_pac_Click(object sender, RoutedEventArgs e)
        {
            if (lstPacientes.SelectedItem != null)
            {
                paciente_seleccionado.Name = txtbNombre.Text;
                paciente_seleccionado.edad = Convert.ToInt32(txtbEdad.Text);
                paciente_seleccionado.tarjeta = Convert.ToInt32(txtbTarjeta.Text);
                paciente_seleccionado.Dni = txtbDNI.Text;
                paciente_seleccionado.Id = Convert.ToInt32(txtbID.Text);

                lista_auxiliar_pacientes = lista_pacientes.ToList();

                lstPacientes.ItemsSource = null;
                lstPacientes.ItemsSource = lista_auxiliar_pacientes;

                txtbNombre.Text = paciente_seleccionado.Name;
                txtbEdad.Text = paciente_seleccionado.edad.ToString();
                txtbID.Text = paciente_seleccionado.Id.ToString();
                txtbDNI.Text = paciente_seleccionado.Dni;
                txtbTarjeta.Text = paciente_seleccionado.tarjeta.ToString();


                btnEliminar_pac.IsEnabled = false;
                btnMod_pac.IsEnabled = false;
                txtbDNI.IsEnabled = false;
                txtbNombre.IsEnabled = true;
                txtbTarjeta.IsEnabled = true;
                txtbEdad.IsEnabled = true;
                btnGuardar_pac.Visibility = Visibility.Visible;
                btnDescartar_pac.Visibility = Visibility.Visible;
            }
        }

        private void btnEliminar_pac_Click(object sender, RoutedEventArgs e)
        {
            if (lstPacientes.SelectedItem != null)
            {
                MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar el paciente seleccionado?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultado == MessageBoxResult.Yes)
                {
                    Paciente paciente_seleccionado = (Paciente)lstPacientes.SelectedItem;
                    lista_pacientes.Remove(paciente_seleccionado);
                    lstPacientes.ItemsSource = null;
                    lstPacientes.ItemsSource = lista_pacientes;
                    MessageBox.Show("" + paciente_seleccionado.Name + " eliminado correctamente", "Eliminación correcta", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        private void btnDescartar_pac_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres descartar los cambios realizados?", "Descartar cambios", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                txtbDNI.IsEnabled = false;
                txtbDNI.Text = paciente_seleccionado.Dni;

                txtbTarjeta.IsEnabled = false;
                txtbTarjeta.Text = paciente_seleccionado.tarjeta.ToString();

                txtbNombre.IsEnabled = false;
                txtbNombre.Text = paciente_seleccionado.Name;

                txtbEdad.IsEnabled = false;
                txtbEdad.Text = paciente_seleccionado.edad.ToString();

                txtbID.IsEnabled = false;
                txtbID.Text = paciente_seleccionado.Id.ToString();

                lstPacientes.ItemsSource = null;
                lstPacientes.ItemsSource = lista_pacientes;

                btnMod_pac.IsEnabled = true;
                btnEliminar_pac.IsEnabled = true;
                btnDescartar_pac.Visibility = Visibility.Hidden;
                btnGuardar_pac.Visibility = Visibility.Hidden;

            }
        }

        private void btnGuardar_pac_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres guardar los cambios realizados?", "Realizar cambios", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                txtbDNI.IsEnabled = false;
                txtbEdad.IsEnabled = false;
                txtbNombre.IsEnabled = false;
                txtbTarjeta.IsEnabled = false;
                txtbID.IsEnabled = false;

                lista_pacientes[indice_paciente_seleccionado]
                    = new Paciente(Convert.ToInt32(txtbID.Text),txtbNombre.Text ,txtbDNI.Text,
                    Convert.ToInt32(txtbEdad.Text), Convert.ToInt32(txtbTarjeta.Text));

                lstPacientes.ItemsSource = null;
                lstPacientes.ItemsSource = lista_pacientes;

                btnMod_pac.IsEnabled = true;
                btnEliminar_pac.IsEnabled = true;
                btnDescartar_pac.Visibility = Visibility.Hidden;
                btnGuardar_pac.Visibility = Visibility.Hidden;
                MessageBox.Show("Paciente modificado con éxito", "Modificación exitosa", MessageBoxButton.OK, MessageBoxImage.None);

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
        private void txtbEdad_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaEntero(txtbEdad) && campos_completos())
            {
                btnGuardar_pac.IsEnabled = true;
            }
            else
            {
                btnGuardar_pac.IsEnabled = false;
            }
        }

        private void txtbEdad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (campos_completos())
            {
                btnGuardar_pac.IsEnabled = true;
            }
            else
            {
                btnGuardar_pac.IsEnabled = false;
            }
        }

        private void txtbTarjeta_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaEntero(txtbTarjeta) && campos_completos())
            {
                btnGuardar_pac.IsEnabled = true;
            }
            else
            {
                btnGuardar_pac.IsEnabled = false;
            }
        }

        private void txtbTarjeta_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (campos_completos())
            {
                btnGuardar_pac.IsEnabled = true;
            }
            else
            {
                btnGuardar_pac.IsEnabled = false;
            }
        }
    }
}
