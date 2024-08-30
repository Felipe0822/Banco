using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    internal class Cliente
    {
        private string nombre;
        private string apellido;
        private string direccion;
        private int identificacion;

        public Cliente(string nombre, string apellido, string direccion, int identificacion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.identificacion = identificacion;
        }


        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Identificacion { get => identificacion; set => identificacion = value; }

      
    }
}
