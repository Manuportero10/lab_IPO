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
using System.Windows.Shapes;


namespace AplicaciónFisioterapia
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {

        private BitmapImage imgLupa = new BitmapImage(new Uri("img/Lupa.png", UriKind.Relative));
        public MenuPrincipal()
        {
            InitializeComponent();
            
        }

        private void limpiar(int fila_grid, int columna_grid, Grid grid_propio)
        {
            //previamente, borramos todos los elementos que podrian haber estado en la porcion del grid que estamos usando
            var elementosEnCelda = grid_propio.Children
                .Cast<UIElement>()
                .Where(elemento => Grid.GetRow(elemento) == fila_grid && Grid.GetColumn(elemento) == columna_grid)
                .ToList();

            // Elimina los elementos de la celda
            foreach (var elemento in elementosEnCelda)
            {
                grid_propio.Children.Remove(elemento);
            }
        }

        private void ocultar_buscador()
        {
            txtBuscador.Visibility = Visibility.Hidden;
            imagLupa.Visibility = Visibility.Hidden;
            txtBuscador.Text = "";
        }
        private void btnCitas_Click(object sender, RoutedEventArgs e)
        {
            int columna_grid = 1;
            int fila_grid = 2;
            limpiar(fila_grid, columna_grid,mi_grid);
            ocultar_buscador();

            Button btnCrearCita = new Button();
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnCrearCita, columna_grid);
            Grid.SetRow(btnCrearCita, fila_grid);
            
            btnCrearCita.Name = "btnCrearCita";
            btnCrearCita.Content = "Crear Cita";
            btnCrearCita.HorizontalAlignment = HorizontalAlignment.Left;
            btnCrearCita.Margin = new Thickness(25,8,0,0);
            btnCrearCita.VerticalAlignment = VerticalAlignment.Top;
            btnCrearCita.Height = 27;
            btnCrearCita.Width = 82;
            mi_grid.Children.Add(btnCrearCita);
            

            Button btnBorrarCita = new Button();
            btnBorrarCita.Name = "btnBorrarCita";
            btnBorrarCita.Content = "Borrar Cita";
            btnBorrarCita.HorizontalAlignment = HorizontalAlignment.Left;
            btnBorrarCita.Margin = new Thickness(144, 8, 0, 0);
            btnBorrarCita.VerticalAlignment = VerticalAlignment.Top;
            btnBorrarCita.Height = 27;
            btnBorrarCita.Width = 82;
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnBorrarCita, columna_grid);
            Grid.SetRow(btnBorrarCita, fila_grid);
            mi_grid.Children.Add(btnBorrarCita);

            Button btnVerCitas = new Button();
            btnVerCitas.Name = "btnVerCita";
            btnVerCitas.Content = "Ver Citas";
            btnVerCitas.HorizontalAlignment = HorizontalAlignment.Left;
            btnVerCitas.Margin = new Thickness(263, 8, 0, 0);
            btnVerCitas.VerticalAlignment = VerticalAlignment.Top;
            btnVerCitas.Height = 27;
            btnVerCitas.Width = 82;
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnVerCitas, columna_grid);
            Grid.SetRow(btnVerCitas, fila_grid);
            mi_grid.Children.Add(btnVerCitas);

            Button btnCambiarCita = new Button();
            btnCambiarCita.Name = "btnCambiarCita";
            btnCambiarCita.Content = "Cambiar Cita";
            btnCambiarCita.HorizontalAlignment = HorizontalAlignment.Left;
            btnCambiarCita.Margin = new Thickness(384, 8, 0, 0);
            btnCambiarCita.VerticalAlignment = VerticalAlignment.Top;
            btnCambiarCita.Height = 27;
            btnCambiarCita.Width = 82;
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnCambiarCita, columna_grid);
            Grid.SetRow(btnCambiarCita, fila_grid);
            mi_grid.Children.Add(btnCambiarCita);

        }

        private void btnPacientes_click(object sender, RoutedEventArgs e)
        {
            int columna_grid = 1;
            int fila_grid = 2;
            limpiar(fila_grid, columna_grid, mi_grid);
            ocultar_buscador();

            Button btnListadoPacientes = new Button();
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnListadoPacientes, columna_grid);
            Grid.SetRow(btnListadoPacientes, fila_grid);
            btnListadoPacientes.Name = "btnListadoPacientes";
            btnListadoPacientes.Content = "Listado de pacientes";
            btnListadoPacientes.Click += btnListadoPacientes_click; // asignamos el manejador de eventos
            btnListadoPacientes.HorizontalAlignment = HorizontalAlignment.Left;
            btnListadoPacientes.Margin = new Thickness(25, 8, 0, 0);
            btnListadoPacientes.VerticalAlignment = VerticalAlignment.Top;
            btnListadoPacientes.Height = 27;
            btnListadoPacientes.Width = 150;
            mi_grid.Children.Add(btnListadoPacientes); // añadimos el boton


            Button btnCalendarioPacientes = new Button();
            btnCalendarioPacientes.Name = "btnCalendarioPacientes";
            btnCalendarioPacientes.Content = "Calendario pacientes";
            btnCalendarioPacientes.HorizontalAlignment = HorizontalAlignment.Left;
            btnCalendarioPacientes.Margin = new Thickness(255, 8, 0, 0);
            btnCalendarioPacientes.VerticalAlignment = VerticalAlignment.Top;
            btnCalendarioPacientes.Height = 27;
            btnCalendarioPacientes.Width = 150;
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnCalendarioPacientes, columna_grid);
            Grid.SetRow(btnCalendarioPacientes, fila_grid);
            mi_grid.Children.Add(btnCalendarioPacientes);
        }

        private void btnEmpleado_click(object sender, RoutedEventArgs e)
        {
            int columna_grid = 1;
            int fila_grid = 2;
            limpiar(fila_grid, columna_grid, mi_grid);
            ocultar_buscador();

            Button btnAnadirEmpleado = new Button();
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnAnadirEmpleado, columna_grid);
            Grid.SetRow(btnAnadirEmpleado, fila_grid);
            btnAnadirEmpleado.Name = "AnadirEmpleado";
            btnAnadirEmpleado.Content = "Añadir empleado";
            btnAnadirEmpleado.HorizontalAlignment = HorizontalAlignment.Left;
            btnAnadirEmpleado.Margin = new Thickness(25, 8, 0, 0);
            btnAnadirEmpleado.VerticalAlignment = VerticalAlignment.Top;
            btnAnadirEmpleado.Height = 27;
            btnAnadirEmpleado.Width = 150;
            mi_grid.Children.Add(btnAnadirEmpleado);


            Button btnListadoEmpleados = new Button();
            btnListadoEmpleados.Name = "btnCalendarioPacientes";
            btnListadoEmpleados.Content = "Listado empleados";
            btnListadoEmpleados.HorizontalAlignment = HorizontalAlignment.Left;
            btnListadoEmpleados.Margin = new Thickness(255, 8, 0, 0);
            btnListadoEmpleados.VerticalAlignment = VerticalAlignment.Top;
            btnListadoEmpleados.Height = 27;
            btnListadoEmpleados.Width = 150;
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnListadoEmpleados, columna_grid);
            Grid.SetRow(btnListadoEmpleados, fila_grid);
            mi_grid.Children.Add(btnListadoEmpleados); 
        }

        private void btnListadoPacientes_click(object sender, RoutedEventArgs e)
        {
            imagLupa.Visibility = Visibility.Visible;
            txtBuscador.Visibility = Visibility.Visible;

        }
    }
}
    