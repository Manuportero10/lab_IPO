using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaciónFisioterapia
{
    public class Empleado
    {
        public String nombre { set; get; }
        public String DNI { set; get; }
        public int sueldo { set; get; }
        public int anio_fin_contrato { set; get; }

        public Uri Url_icono_rol {  set; get; }

        public String rol {  set; get; }

        public Empleado(string nombre, string dNI, int sueldo, int anio_fin_contrato, String url, String rol)
        {
            this.nombre = nombre;
            DNI = dNI;
            this.sueldo = sueldo;
            this.anio_fin_contrato = anio_fin_contrato;
            Url_icono_rol = new Uri(url, UriKind.Relative);
            this.rol = rol;
        }
    }
}
