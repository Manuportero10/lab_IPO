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

        public Paciente(string name, string dni, int edad, int tarjeta)
        {
            n_id = n_id + 1;
            Id = n_id;
            Name = name;
            Dni = dni;
            this.edad = edad;
            this.tarjeta = tarjeta;
        }

        public Paciente(int id,string name, string dni, int edad, int tarjeta)
        {
            Id = id;
            Name = name;
            Dni = dni;
            this.edad = edad;
            this.tarjeta = tarjeta;
        }

        public Paciente() { }
    }
}
