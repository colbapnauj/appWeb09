using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace appWeb09.Models
{
    public class Pedido
    {
        [Display(Name = "ID de Pedido")]public int idpedido { get; set; }
        [Display(Name = "Fecha Pedido")]public DateTime fecha { get; set; }
        [Display(Name = "Cliente")]public string nombrecia { get; set; }
        [Display(Name = "Dirección Destino")] public string direccion{ get; set; }
        [Display(Name = "Ciudad Destino")] public string ciudad{ get; set; }
    }
}