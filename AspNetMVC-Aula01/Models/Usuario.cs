using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace AspNetMVC_Aula01.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string UserName { get; set;}
        public string UserPass { get; set; }
    }
}