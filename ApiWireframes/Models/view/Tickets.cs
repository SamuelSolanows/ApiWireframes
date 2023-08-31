using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWireframes.Models.view
{
    public class Tickets
    {
        public int ID { get; set; }
        public string User_Name { get; set; }
        public DateTime Fecha { get; set; }
        public string Silla { get; set; }
        public int ID_Evento { get; set; }
        public Eventos eventos { get; set; }
    }
}