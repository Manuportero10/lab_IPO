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
using System.Windows.Media.Animation;
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

        private Button btnAnadirCita = new Button();
        private Button btnListadoCitas = new Button();
        private Button btnListadoPacientes = new Button();
        private Button btnAnadirPacientes = new Button();
        private Button btnAnadirEmpleado = new Button();
        private Button btnListadoEmpleados = new Button();
        private Page[] paneles = new Page[] {new PaginaPrincipal(),new PaginaListadoEmpleados(), new PaginaListadoPacientes(), new PaginaAñadirEmpleado(), new PaginaListadoCitas(), new PaginaHistorial()}; //dentro iran las paginas
        public MenuPrincipal()
        {
            InitializeComponent();
            pnlContenido.Content = paneles[0];
            
        }

        private void MenuPrincipal_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar la aplicación?", "Cierre de aplicación", MessageBoxButton.YesNo, MessageBoxImage.Information);
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

            btnAnadirCita.BorderBrush = Brushes.Black;
            btnAnadirCita.BorderThickness = new Thickness(0.6);

            btnListadoCitas.BorderBrush = Brushes.Black;
            btnListadoCitas.BorderThickness = new Thickness(0.6);

            btnAnadirPacientes.BorderBrush = Brushes.Black;
            btnAnadirPacientes.BorderThickness = new Thickness(0.6);

            btnListadoPacientes.BorderBrush = Brushes.Black;
            btnListadoPacientes.BorderThickness = new Thickness(0.6);

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
            Grid.SetColumn(btnAnadirCita, columna_grid);
            Grid.SetRow(btnAnadirCita, fila_grid);

            btnAnadirCita.Name = "btnAnadirCita";
            btnAnadirCita.Content = "Añadir Cita";
            btnAnadirCita.Click += btnAnadirCita_click;
            btnAnadirCita.HorizontalAlignment = HorizontalAlignment.Left;
            btnAnadirCita.Margin = new Thickness(25,8,0,0);
            btnAnadirCita.VerticalAlignment = VerticalAlignment.Top;
            btnAnadirCita.Height = 27;
            btnAnadirCita.Width = 150;
            mi_grid.Children.Add(btnAnadirCita);
           

            btnListadoCitas.Name = "btnListadoCitas";
            btnListadoCitas.Content = "Listado de Citas";
            btnListadoCitas.Click += btnListadoCitas_click;
            btnListadoCitas.HorizontalAlignment = HorizontalAlignment.Left;
            btnListadoCitas.Margin = new Thickness(255, 8, 0, 0);
            btnListadoCitas.VerticalAlignment = VerticalAlignment.Top;
            btnListadoCitas.Height = 27;
            btnListadoCitas.Width = 150;
            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnListadoCitas, columna_grid);
            Grid.SetRow(btnListadoCitas, fila_grid);
            mi_grid.Children.Add(btnListadoCitas);
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
            Grid.SetColumn(btnAnadirPacientes, columna_grid);
            Grid.SetRow(btnAnadirPacientes, fila_grid);
            btnAnadirPacientes.Name = "btnAnadirPacientes";
            btnAnadirPacientes.Content = "Añadir paciente";
            btnAnadirPacientes.Click += btnAnadirPacientes_click; // asignamos el manejador de eventos
            btnAnadirPacientes.HorizontalAlignment = HorizontalAlignment.Left;
            btnAnadirPacientes.Margin = new Thickness(25, 8, 0, 0);
            btnAnadirPacientes.VerticalAlignment = VerticalAlignment.Top;
            btnAnadirPacientes.Height = 27;
            btnAnadirPacientes.Width = 150;
            mi_grid.Children.Add(btnAnadirPacientes); // añadimos el boton

            // ponemos el boton en la parte del grid correspondiente
            Grid.SetColumn(btnListadoPacientes, columna_grid);
            Grid.SetRow(btnListadoPacientes, fila_grid);
            btnListadoPacientes.Name = "btnListadoPacientes";
            btnListadoPacientes.Content = "Listado de pacientes";
            btnListadoPacientes.Click += btnListadoPacientes_click; // asignamos el manejador de eventos
            btnListadoPacientes.HorizontalAlignment = HorizontalAlignment.Left;
            btnListadoPacientes.Margin = new Thickness(255, 8, 0, 0);
            btnListadoPacientes.VerticalAlignment = VerticalAlignment.Top;
            btnListadoPacientes.Height = 27;
            btnListadoPacientes.Width = 150;
            mi_grid.Children.Add(btnListadoPacientes); // añadimos el boton
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
            btnListadoEmpleados.Content = "Listado de empleados";
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

        private void btnAnadirCita_click(object sender, RoutedEventArgs e)
        {
            reestablecer_bordes_grid(mi_grid, btnAnadirCita);
            //resaltamos el boton pulsado
            btnAnadirCita.BorderBrush = Brushes.AliceBlue;
            btnAnadirCita.BorderThickness = new Thickness(4);
            imagLupa.Visibility = Visibility.Hidden;
            txtBuscador.Visibility = Visibility.Hidden;
            txtBuscador.Text = string.Empty;
            pnlContenido.Content = new PaginaAñadirCita();

        }

        private void btnListadoCitas_click(object sender, RoutedEventArgs e)
        {
            reestablecer_bordes_grid(mi_grid, btnListadoCitas);
            //resaltamos el boton pulsado
            btnListadoCitas.BorderBrush = Brushes.AliceBlue;
            btnListadoCitas.BorderThickness = new Thickness(4);
            imagLupa.Visibility = Visibility.Visible;
            txtBuscador.Visibility = Visibility.Visible;
            pnlContenido.Content = paneles[4];

        }
        private void btnAnadirPacientes_click(object sender, RoutedEventArgs e)
        {
            reestablecer_bordes_grid(mi_grid, btnAnadirPacientes);
            //resaltamos el boton pulsado
            btnAnadirPacientes.BorderBrush = Brushes.AliceBlue;
            btnAnadirPacientes.BorderThickness = new Thickness(4);
            imagLupa.Visibility = Visibility.Hidden;
            txtBuscador.Visibility = Visibility.Hidden;
            txtBuscador.Text = string.Empty;
            pnlContenido.Content = new PaginaAñadirPacientes();

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

        private void btnAnadirEmpleado_click(object sender, RoutedEventArgs e)
        {
            reestablecer_bordes_grid(mi_grid, btnAnadirEmpleado);
            //resaltamos el boton pulsado
            btnAnadirEmpleado.BorderBrush = Brushes.AliceBlue;
            btnAnadirEmpleado.BorderThickness = new Thickness(4);
            imagLupa.Visibility = Visibility.Hidden;
            txtBuscador.Visibility = Visibility.Hidden;
            txtBuscador.Text = string.Empty;
            pnlContenido.Content = new PaginaAñadirEmpleado();

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
            pnlContenido.Content = paneles[5];

            //resaltamos el boton pulsado
            btnHistorial.BorderBrush = Brushes.AliceBlue;
            btnHistorial.BorderThickness = new Thickness(4);

            imagLupa.Visibility = Visibility.Visible;
            txtBuscador.Visibility = Visibility.Visible;
            txtBuscador.Text = string.Empty;
        }


    }
}
    