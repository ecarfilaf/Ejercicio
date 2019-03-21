using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Respuesta

    {
        public int ErrCode { get; set; }
        public string ErrDesc { get; set; }
        public object  Data { get; set; }

		public Respuesta (){
			this.ErrCode=0;
			this.ErrDesc="";
			this.Data=null ;
		}
    }
}
