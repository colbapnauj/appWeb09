using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace appWeb09.Models
{
    public class Cliente
    {
        [Display(Name = "Id Cliente")]public int idcliente { get; set; }
        [Display(Name = "Nombre")] public string nombrecia { get; set; }
        [Display(Name = "Dirección")] public string direccion{ get; set; }
        [Display(Name = "Id País")] public string idpais{ get; set; }
        [Display(Name = "Teléfono")] public string fono{ get; set; }

    }
}