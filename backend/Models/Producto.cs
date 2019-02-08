using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string CodProducto { get; set; }
        public string NombreProducto { get; set; }
        public string TipoProducto { get; set; }
        public int SaldoMinimo { get; set; }
        public int Estado { get; set; }
		public int CodStatus { get; set; }
        public string DesStatus { get; set; }

		public Producto (){
			this.Id=0;
			this.CodProducto="";
			this.NombreProducto="";
			this.TipoProducto="";
			this.SaldoMinimo=0;
			this.Estado=0;
			this.CodStatus=0;
			this.DesStatus="";
		}
    }
}
