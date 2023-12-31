using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AplicaciónFisioterapia
{
    public class Cita
    {
        
        public DateTime fecha { set; get; }

        public String fecha_formateada { set; get; }
        public Paciente paciente { set; get; }
        public Empleado profesional { set; get; }
        public int tiempo_en_segundos { set; get; }
        public String info_adiccional { set; get; }


        public Cita(DateTime fecha, Paciente paciente, Empleado profesional, int tiempo_en_segundos, string info_adiccional)
        {
            
            this.fecha = fecha;
            this.paciente = paciente;
            this.profesional = profesional;
            this.tiempo_en_segundos = tiempo_en_segundos;
            this.info_adiccional = info_adiccional;
            fecha_formateada = fecha.ToString("dd/MM/yyyy");
        }

        public Cita() { }
    }
}
