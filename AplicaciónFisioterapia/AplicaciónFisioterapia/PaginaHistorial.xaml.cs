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
    /// Lógica de interacción para PaginaHistorial.xaml
    /// </summary>
    public partial class PaginaHistorial : Page
    {
        public static ObservableCollection<Historial> lista_historial = new ObservableCollection<Historial>();
        
        public PaginaHistorial()
        {
            InitializeComponent();
            crear_historiales();
            lstHistorial.ItemsSource = lista_historial;
        }

        private void crear_historiales()
        {
            lista_historial.Clear();
            Historial historial = new Historial(DateTime.Parse("2023-10-10"), encontrar_paciente("22222222A")
                , encontrar_profesional("11111111A"), crear_lista_dolencias1(), crear_lista_tratamientos1());
            Console.WriteLine(historial.ToString());

            lista_historial.Add(new Historial(DateTime.Parse("2023-10-10"),encontrar_paciente("22222222A")
                ,encontrar_profesional("11111111A"),crear_lista_dolencias1(),crear_lista_tratamientos1()));

            lista_historial.Add(new Historial(DateTime.Parse("2023-5-5"), encontrar_paciente("22222222C")
                , encontrar_profesional("11111111A"), crear_lista_dolencias2(), crear_lista_tratamientos1()));

            lista_historial.Add(new Historial(DateTime.Parse("2023-2-2"), encontrar_paciente("22222222D")
                , encontrar_profesional("11111111A"), crear_lista_dolencias1(), crear_lista_tratamientos2()));
        }

        public List<String> crear_lista_dolencias1()
        {
            List<String> lista = new List<String>();
            lista.Add("Presión fuerte en el aductor");
            lista.Add("Molestia en las lumbares");
            
            return lista;
        }

        public List<String> crear_lista_dolencias2()
        {
            List<String> lista = new List<String>();
            lista.Add("Molestia en el cuello");
            lista.Add("Molestia en las lumbares");
            return lista;
        }

        public List<String> crear_lista_tratamientos1()
        {
            List<String> lista = new List<String>();
            lista.Add("Masajes regulares");
            lista.Add("Aplicar crema antinflamatoria");

            return lista;
        }

        public List<String> crear_lista_tratamientos2()
        {
            List<String> lista = new List<String>();
            lista.Add("Masajes regulares");
            lista.Add("Relizar ejercicios de movilidad");

            return lista;
        }
        public static Paciente encontrar_paciente(String dni_paciente)
        {
            Paciente paciente_aux = new Paciente();
            foreach (var paciente in PaginaListadoPacientes.lista_pacientes)
            {
                if (paciente.Dni.Equals(dni_paciente))
                {
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

        private void lstHistorial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstDolencias.Items.Clear();
            lstTratamientos.Items.Clear();

            foreach (var elemento in lista_historial[lstHistorial.SelectedIndex].lista_tratamientos)
            {
                lstTratamientos.Items.Add(elemento);
            }

            foreach (var elemento in lista_historial[lstHistorial.SelectedIndex].lista_dolencias)
            {
                lstDolencias.Items.Add(elemento);
            }
        }
    }
}
