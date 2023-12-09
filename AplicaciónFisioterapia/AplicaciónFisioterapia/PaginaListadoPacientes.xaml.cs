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
    /// Lógica de interacción para PaginaListadoPacientes.xaml
    /// </summary>
    
    public partial class PaginaListadoPacientes : Page
    {
        private List<Paciente> lista_pacientes = new List<Paciente>();
        public PaginaListadoPacientes()
        {
            InitializeComponent();
            crear_lista();
            lstPacientes.ItemsSource = lista_pacientes;
        }

        public void crear_lista()
        {
            lista_pacientes.Clear();
            lista_pacientes.Add(new Paciente(1,"Ernesto", "22222222A",88,677172));
            lista_pacientes.Add(new Paciente(2, "Claudia", "22222222B", 88, 677172));
            lista_pacientes.Add(new Paciente(3, "Alberto", "22222222C", 15, 871855));
            lista_pacientes.Add(new Paciente(4, "José", "22222222D", 88, 719285));
        }
    }
}
