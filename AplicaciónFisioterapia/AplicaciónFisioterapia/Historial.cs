using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaciónFisioterapia
{
    public class Historial
    {
        public DateTime fecha { set; get; }
        public Paciente paciente { set; get; }
        public Empleado empleado { set; get; }
        public List<String> lista_dolencias { set; get; }
        public List<String> lista_tratamientos { set; get; }
        public String identificador { set; get; }
        public String fecha_formateada { set; get; }

        public Historial(DateTime fecha, Paciente paciente, Empleado empleado, List<string> lista_dolencias, List<string> lista_tratamientos)
        {
            this.fecha = fecha;
            this.paciente = paciente;
            this.empleado = empleado;
            this.lista_dolencias = lista_dolencias;
            this.lista_tratamientos = lista_tratamientos;
            identificador = fecha.ToString("dd/MM/yyyy") + " - " + paciente.Name;
            fecha_formateada = fecha.ToString("dd/MM/yyyy");
        }

        public String toString()
        {
            return fecha.ToString("dd/MM/yyyy") + " | " + paciente.Name + " | " + empleado.nombre + " | " + identificador;
        }
    }
}
