 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoRicardo.Models
{
    public class Productos
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal? PRECIO { get; set; }
    }
}