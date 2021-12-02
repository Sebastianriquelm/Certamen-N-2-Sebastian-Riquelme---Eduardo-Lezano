using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationClientes.Models
{
    public class Alertas
    {
        public bool error { get; set; }
        public string mensaje { get; set; }
        public object data { get; set; }
    }
}