using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWireframes.Models.view
{
    public class Eventos
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ID_Visto { get; set; }
        public bool Visto { get; set; }
        public byte[] Imagen { get; set; }
    }
}