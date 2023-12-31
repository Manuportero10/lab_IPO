using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Lógica de interacción para PaginaListadoEmpleados.xaml
    /// </summary>
    public partial class PaginaListadoEmpleados : Page
    {

        public static ObservableCollection<Empleado> lista_empleados = new ObservableCollection<Empleado>();
        public List<Empleado> lista_auxiliar;
        private String url_doctor = "img/doctor.jpg";
        private String url_oficinista = "img/oficinista.png";
        private String url_programador = "img/programador.png";
        private List<String> roles_unicos = new List<String>();
        public Empleado empleado_seleccionado = new Empleado();
        public int indice_empleado_seleccionado;
        public PaginaListadoEmpleados()
        {
            InitializeComponent();
            crear_lista();
            lstEmpleados.ItemsSource = lista_empleados;
            
            // Filtra nombres duplicados
            foreach (var empleado in lista_empleados)
            {
                if (!roles_unicos.Contains<String>(empleado.rol))
                {
                    roles_unicos.Add(empleado.rol);
                }
            }
            
            foreach (var roles in roles_unicos)
            {
                cbRol.Items.Add(roles);
            }

           
        }

        public void crear_lista()
        {
            lista_empleados.Clear();
            lista_empleados.Add(new Empleado("Manuel","11111111A",2700,2025,url_doctor,"Doctor"));
            lista_empleados.Add(new Empleado("David", "11111111B", 2000, 2024,url_oficinista,"Oficinista"));
            lista_empleados.Add(new Empleado("Alejandro", "11111111C", 2000, 2024, url_oficinista,"Oficinista"));
            lista_empleados.Add(new Empleado("Ana", "11111111D", 3500, 2027, url_programador, "Programador"));
        }

        private void lstEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnMod.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;
            btnEliminar.IsEnabled = true;
            btnMod.IsEnabled = true;
            btnDescartar.Visibility = Visibility.Hidden;
            btnGuardar.Visibility = Visibility.Hidden;
            txtbDNI.IsEnabled = false;
            txtbExpContr.IsEnabled = false;
            txtbNombre.IsEnabled = false;
            txtbSueldo.IsEnabled = false;
            cbRol.IsEnabled = false;

            txtbExpContr.BorderBrush = Brushes.DimGray;
            txtbExpContr.Background = Brushes.White;
            txtbSueldo.BorderBrush = Brushes.DimGray;
            txtbSueldo.Background = Brushes.White;

            if (lstEmpleados.SelectedItem != null)
            {
                indice_empleado_seleccionado = lstEmpleados.SelectedIndex;
            }

        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            if (lstEmpleados.SelectedItem != null)
            {
                empleado_seleccionado.nombre = txtbNombre.Text;
                empleado_seleccionado.sueldo = Convert.ToInt32(txtbSueldo.Text);
                empleado_seleccionado.anio_fin_contrato = Convert.ToInt32(txtbExpContr.Text);
                empleado_seleccionado.DNI = txtbDNI.Text;
                empleado_seleccionado.rol = cbRol.SelectedItem.ToString();


                lista_auxiliar = lista_empleados.ToList();

                lstEmpleados.ItemsSource = null;
                lstEmpleados.ItemsSource = lista_auxiliar;

                txtbNombre.Text = empleado_seleccionado.nombre;
                txtbSueldo.Text = empleado_seleccionado.sueldo.ToString();
                txtbExpContr.Text = empleado_seleccionado.anio_fin_contrato.ToString();
                txtbDNI.Text = empleado_seleccionado.DNI;
                cbRol.SelectedItem = empleado_seleccionado.rol.ToString();


                btnEliminar.IsEnabled = false;
                btnMod.IsEnabled = false;
                txtbNombre.IsEnabled = true;
                txtbSueldo.IsEnabled = true;
                txtbExpContr.IsEnabled = true;
                cbRol.IsEnabled = true;
                btnGuardar.Visibility = Visibility.Visible;
                btnDescartar.Visibility = Visibility.Visible;
            }

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lstEmpleados.SelectedItem != null)
            {
                MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar el empleado seleccionado?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (resultado == MessageBoxResult.Yes)
                {
                    Empleado empleado_seleccionado = (Empleado)lstEmpleados.SelectedItem;
                    lista_empleados.Remove(empleado_seleccionado);
                    lstEmpleados.ItemsSource = null;
                    lstEmpleados.ItemsSource = lista_empleados;
                    MessageBox.Show(""+empleado_seleccionado.nombre+" eliminado correctamente", "Eliminación correcta", MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }

        }

        private void btnDescartar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres descartar los cambios realizados?", "Descartar cambios", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                txtbDNI.IsEnabled=false;
                txtbDNI.Text = empleado_seleccionado.DNI;

                txtbExpContr.IsEnabled=false;
                txtbExpContr.Text = empleado_seleccionado.anio_fin_contrato.ToString();

                txtbNombre.IsEnabled=false;
                txtbNombre.Text = empleado_seleccionado.nombre;

                txtbSueldo.IsEnabled=false;
                txtbSueldo.Text = empleado_seleccionado.sueldo.ToString();

                cbRol.IsEnabled=false;
                cbRol.SelectedItem = empleado_seleccionado.rol;

                lstEmpleados.ItemsSource = null;
                lstEmpleados.ItemsSource = lista_empleados;

                btnMod.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnDescartar.Visibility=Visibility.Hidden;
                btnGuardar.Visibility=Visibility.Hidden;

            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres guardar los cambios realizados?", "Realizar cambios", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                txtbDNI.IsEnabled = false;                
                txtbExpContr.IsEnabled = false;                
                txtbNombre.IsEnabled = false;               
                txtbSueldo.IsEnabled = false;         
                cbRol.IsEnabled = false;
                

                lista_empleados[indice_empleado_seleccionado] 
                    = new Empleado(txtbNombre.Text,txtbDNI.Text,
                    Convert.ToInt32(txtbSueldo.Text),Convert.ToInt32(txtbExpContr.Text),cbRol.SelectedItem.ToString());
                
                lstEmpleados.ItemsSource= null;
                lstEmpleados.ItemsSource = lista_empleados;

                btnMod.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnDescartar.Visibility = Visibility.Hidden;
                btnGuardar.Visibility = Visibility.Hidden;
                MessageBox.Show("Empleado modificado con éxito","Modificación exitosa",MessageBoxButton.OK,MessageBoxImage.None);

            }
        }

        private Boolean campos_completos()
        {
            if (txtbDNI.Text != String.Empty && txtbNombre.Text != String.Empty
                && txtbSueldo.Text != String.Empty && txtbExpContr.Text != String.Empty
                && cbRol.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
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

        private void txtbNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (campos_completos())
            {
                btnGuardar.IsEnabled = true;
            }
            else
            {
                btnGuardar.IsEnabled=false;
            }
        }

        private void txtbSueldo_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaEntero(txtbSueldo) && campos_completos())
            {
                btnGuardar.IsEnabled = true;
            }
            else
            {
                btnGuardar.IsEnabled = false;
            }
        }

        private void txtbExpContr_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntradaEnteroAnio(txtbExpContr) && campos_completos())
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
