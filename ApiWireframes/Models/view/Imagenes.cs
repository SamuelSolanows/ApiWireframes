using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWireframes.Models.view
{
    public class Imagenes
    {
        public int ID { get; set; }
        public byte[] Imagen { get; set; }
        public int ID_Evento { get; set; }


    }
}
