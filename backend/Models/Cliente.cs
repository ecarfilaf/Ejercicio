using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoCliente { get; set; }
        public int Estado { get; set; }
    }
}
