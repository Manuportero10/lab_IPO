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

        private Button btnCrearCita = new Button();
        private Button btnBorrarCita = new Button();
        private Button btnVerCitas = new Button();
        private Button btnCambiarCita = new Button();
        private Button btnListadoPacientes = new Button();
        private Button btnCalendarioPacientes = new Button();
        private Button btnAnadirEmpleado = new Button();
        private Button btnListadoEmpleados = new Button();
        private Page[] paneles = new Page[] {new PaginaPrincipal(),new PaginaListadoEmpleados(), new PaginaListadoPacientes()}; //dentro iran las paginas
        public MenuPrincipal()
        {
            InitializeComponent();
            pnlContenido.Content = paneles[0];
            
        }

        private void MenuPrincipal_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Estas seguro de que quieres cerrar la aplicación?", "Cierre de aplicación", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (resultado == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
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

        private void reestablecer_bordes_grid(Grid grid_propio, Button boton)
        {
            var elementosEnCelda = grid_propio.Children
            .Cast<UIElement>()
            .Where(elemento => Grid.GetRow(elemento) == 2 && Grid.GetColumn(elemento) == 1)
            .ToList();

            // Restablece los bordes para los demas botones no pulsados
            // en el grid.
            foreach (Button elemento in elementosEnCelda)
            {
                if (!elemento.Equals(boton)){
                    elemento.BorderBrush = Brushes.Black;
                    elemento.BorderThickness = new Thickness(0.6);
                }
            }
        }

        private void reestablecer_bordes_botones()
        {
            btnCitas.BorderBrush = Brushes.Black;
            btnCitas.BorderThickness = new Thickness(0.6);

            btnCrearCita.BorderBrush = Brushes.Black;
            btnCrearCita.BorderThickness = new Thickness(0.6);

            btnBorrarCita.BorderBrush = Brushes.Black;
            btnBorrarCita.BorderThickness = new Thickness(0.6);

            btnVerCitas.BorderBrush = Brushes.Black;
            btnVerCitas.BorderThickness = new Thickness(0.6);

            btnCambiarCita.BorderBrush = Brushes.Black;
            btnCambiarCita.BorderThickness = new Thickness(0.6);

            btnListadoPacientes.BorderBrush = Brushes.Black;
            btnListadoPacientes.BorderThickness = new Thickness(0.6);

            btnCalendarioPacientes.BorderBrush = Brushes.Black;
            btnCalendarioPacientes.BorderThickness = new Thickness(0.6);

            btnAnadirEmpleado.BorderBrush = Brushes.Black;
            btnAnadirEmpleado.BorderThickness = new Thickness(0.6);

            btnListadoEmpleados.BorderBrush = Brushes.Black;
            btnListadoEmpleados.BorderThickness = new Thickness(0.6);

            btnPacientes.BorderBrush = Brushes.Black;
            btnPacientes.BorderThickness = new Thickness(0.6);

            btnEmpleado.BorderBrush = Brushes.Black;
            btnEmpleado.BorderThickness = new Thickness(0.6);

            btnHistorial.BorderBrush = Brushes.Black;
            btnHistorial.BorderThickness = new Thickness(0.6);
           
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
            reestablecer_bordes_botones();
            pnlContenido.Content = paneles[0]; //pagina principal

            //resaltamos el boton pulsado
            btnCitas.BorderBrush = Brushes.AliceBlue;
            btnCitas.BorderThickness = new Thickness(4);

            
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
            reestablecer_bordes_botones();
            ocultar_buscador();
            pnlContenido.Content = paneles[0]; //pagina principal

            //resaltamos el boton pulsado
            btnPacientes.BorderBrush = Brushes.AliceBlue;
            btnPacientes.BorderThickness = new Thickness(4);

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

            btnCalendarioPacientes.Name = "btnCalendarioPacientes";
            btnCalendarioPacientes.Content = "Calendario pacientes";
            btnCalendarioPacientes.Click += btnCalendarioPacientes_click;
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
            reestablecer_bordes_botones();
            ocultar_buscador();
            pnlContenido.Content = paneles[0]; //pagina principal

            //resaltamos el boton pulsado
            btnEmpleado.BorderBrush = Brushes.AliceBlue;
            btnEmpleado.BorderThickness = new Thickness(4);

            
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnAnadirEmpleado, columna_grid);
            Grid.SetRow(btnAnadirEmpleado, fila_grid);
            btnAnadirEmpleado.Name = "AnadirEmpleado";
            btnAnadirEmpleado.Content = "Añadir empleado";
            btnAnadirEmpleado.Click += btnAnadirEmpleado_click;
            btnAnadirEmpleado.HorizontalAlignment = HorizontalAlignment.Left;
            btnAnadirEmpleado.Margin = new Thickness(25, 8, 0, 0);
            btnAnadirEmpleado.VerticalAlignment = VerticalAlignment.Top;
            btnAnadirEmpleado.Height = 27;
            btnAnadirEmpleado.Width = 150;
            mi_grid.Children.Add(btnAnadirEmpleado);

            btnListadoEmpleados.Name = "btnListadoEmpleados";
            btnListadoEmpleados.Content = "Listado empleados";
            btnListadoEmpleados.Click += btnListadoEmpleados_click;
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
            reestablecer_bordes_grid(mi_grid, btnListadoPacientes);
            //resaltamos el boton pulsado
            btnListadoPacientes.BorderBrush = Brushes.AliceBlue;
            btnListadoPacientes.BorderThickness = new Thickness(4);
            imagLupa.Visibility = Visibility.Visible;
            txtBuscador.Visibility = Visibility.Visible;
            pnlContenido.Content = paneles[2];

        }

        private void btnCalendarioPacientes_click(object sender, RoutedEventArgs e)
        {
            reestablecer_bordes_grid(mi_grid, btnCalendarioPacientes);
            //resaltamos el boton pulsado
            btnCalendarioPacientes.BorderBrush = Brushes.AliceBlue;
            btnCalendarioPacientes.BorderThickness = new Thickness(4);
            imagLupa.Visibility = Visibility.Hidden;
            txtBuscador.Visibility = Visibility.Hidden;
            txtBuscador.Text = string.Empty;
            
        }
        private void btnAnadirEmpleado_click(object sender, RoutedEventArgs e)
        {
            reestablecer_bordes_grid(mi_grid, btnAnadirEmpleado);
            //resaltamos el boton pulsado
            btnAnadirEmpleado.BorderBrush = Brushes.AliceBlue;
            btnAnadirEmpleado.BorderThickness = new Thickness(4);
            imagLupa.Visibility = Visibility.Hidden;
            txtBuscador.Visibility = Visibility.Hidden;
            txtBuscador.Text = string.Empty;

        }
        private void btnListadoEmpleados_click(object sender, RoutedEventArgs e)
        {
            reestablecer_bordes_grid(mi_grid, btnListadoEmpleados);
            //resaltamos el boton pulsado
            btnListadoEmpleados.BorderBrush = Brushes.AliceBlue;
            btnListadoEmpleados.BorderThickness = new Thickness(4);
            imagLupa.Visibility = Visibility.Visible;
            txtBuscador.Visibility = Visibility.Visible;
            pnlContenido.Content = paneles[1];

        }

        private void btnHistorial_click(object sender, RoutedEventArgs e)
        {
            int columna_grid = 1;
            int fila_grid = 2;
            reestablecer_bordes_botones();
            limpiar(fila_grid, columna_grid, mi_grid);
            pnlContenido.Content = paneles[0];

            //resaltamos el boton pulsado
            btnHistorial.BorderBrush = Brushes.AliceBlue;
            btnHistorial.BorderThickness = new Thickness(4);

            imagLupa.Visibility = Visibility.Visible;
            txtBuscador.Visibility = Visibility.Visible;
            txtBuscador.Text = string.Empty;
        }


    }
}
    