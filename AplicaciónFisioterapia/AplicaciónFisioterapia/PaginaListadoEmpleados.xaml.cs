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
    /// Lógica de interacción para PaginaListadoEmpleados.xaml
    /// </summary>
    public partial class PaginaListadoEmpleados : Page
    {
        private List<Empleado> lista_empleados = new List<Empleado>();
        private String url_doctor = "img/doctor.jpg";
        private String url_oficinista = "img/oficinista.png";
        private String url_programador = "img/programador.png";
        public PaginaListadoEmpleados()
        {
            InitializeComponent();
            crear_lista();
            lstEmpleados.ItemsSource = lista_empleados;
        }

        public void crear_lista()
        {
            lista_empleados.Clear();
            lista_empleados.Add(new Empleado("Manuel","11111111A",2700,2025,url_doctor,"Doctor"));
            lista_empleados.Add(new Empleado("David", "11111111B", 2000, 2024,url_oficinista,"Oficinista"));
            lista_empleados.Add(new Empleado("Alejandro", "11111111C", 2000, 2024, url_oficinista,"Oficinista"));
            lista_empleados.Add(new Empleado("Ana", "11111111D", 3500, 2027, url_programador, "Programador"));
        }
    }
}
