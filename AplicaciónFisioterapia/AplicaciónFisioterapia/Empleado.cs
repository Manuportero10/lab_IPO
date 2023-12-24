using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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

        public Empleado(string nombre, string dNI, int sueldo, int anio_fin_contrato,String rol)
        {
            this.nombre = nombre;
            DNI = dNI;
            this.sueldo = sueldo;
            this.anio_fin_contrato = anio_fin_contrato;
            this.rol = rol;
            Url_icono_rol = obtener_icono();
            
        }
        public Empleado() { }

        private Uri obtener_icono()
        {
            String url="";
            switch (rol)
            {
                case "Doctor": url = "img/doctor.jpg";
                    break;

                case "Oficinista": url = "img/oficinista.png";
                    break;

                case "Programador": url = "img/programador.png";
                    break;
            }
            
            return new Uri(url, UriKind.Relative);
        }
        public String toString()
        {
            return "["+nombre+" | " + DNI + " | " + sueldo + " | " + anio_fin_contrato + "]";
        }
    }
}
