using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaciónFisioterapia
{
    
    public class Paciente
    {
        private static int n_id = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dni { get; set; }

        public int edad {  get; set; }

        public int tarjeta { get; set; }

        public Uri icono_paciente { get; set; }

        public Paciente(string name, string dni, int edad, int tarjeta)
        {
            n_id = n_id + 1;
            Id = n_id;
            Name = name;
            Dni = dni;
            this.edad = edad;
            this.tarjeta = tarjeta;
            this.icono_paciente = obtener_icono_segun_edad();
        }

        public Paciente(int id,string name, string dni, int edad, int tarjeta)
        {
            Id = id;
            Name = name;
            Dni = dni;
            this.edad = edad;
            this.tarjeta = tarjeta;
            this.icono_paciente = obtener_icono_segun_edad();
        }

        public Paciente() { }

        private Uri obtener_icono_segun_edad()
        {
            
            if (edad <= 5)
            {
                return new Uri("img/bebe.png", UriKind.Relative);
            }

            if (edad < 18 )
            {
                return new Uri("img/joven.png", UriKind.Relative);
            }

            if (edad < 65)
            {
                return new Uri("img/adulto.png", UriKind.Relative);
            }
            else
            {
                return new Uri("img/anciano.png", UriKind.Relative);
            }
        }

        public String toString()
        {
            return "[ " + Id + " | " + Name + " | " + Dni + " ]";
        }
    }
}
