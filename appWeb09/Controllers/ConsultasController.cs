using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using appWeb09.Models;

namespace appWeb09.Controllers
{
    public class ConsultasController : Controller
    {
        IEnumerable<Cliente> busqueda(string nombre)
        {
            List<Cliente> temporal = new List<Cliente>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("exec usp_buscar_cliente @nombre", cn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                temporal.Add(new Cliente()
                {
                    idcliente = dr.GetInt32(0),
                    nombrecia = dr.GetString(1),
                    direccion = dr.GetString(2),
                    idpais = dr.GetString(3),
                    fono = dr.GetString(4),
                });
            }

            dr.Close();
            cn.Close();
            return temporal;
        }
        
        public ActionResult ConsultaNombre(string nombre = "")
        {
            return View(busqueda(nombre));
        }

        IEnumerable<Pedido> pedidosyear(int y)
        {
            List<Pedido> temporal = new List<Pedido>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("exec usp_pedidos_year @y", cn);
            cmd.Parameters.AddWithValue("@y", y);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                temporal.Add(new Pedido()
                {
                    idpedido = dr.GetInt32(0),
                    fecha = dr.GetDateTime(1),
                    nombrecia = dr.GetString(2),
                    direccion = dr.GetString(3),
                    ciudad = dr.GetString(4),
                });
            }

            dr.Close();
            cn.Close();
            return temporal;
        }

        public ActionResult ConsultaYear(int y = 0)
        {
            return View(pedidosyear(y));
        }

        // Lab 9.3
        IEnumerable<Pedido> pedidosfechas(DateTime f1, DateTime f2)
        {
            List<Pedido> temporal = new List<Pedido>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("exec usp_pedidos_fechas @f1, @f2", cn);
            cmd.Parameters.AddWithValue("@f1", f1);
            cmd.Parameters.AddWithValue("@f2", f2);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                temporal.Add(new Pedido()
                {
                    idpedido = dr.GetInt32(0),
                    fecha = dr.GetDateTime(1),
                    nombrecia = dr.GetString(2),
                    direccion = dr.GetString(3),
                    ciudad = dr.GetString(4),
                });
            }

            dr.Close();
            cn.Close();
            return temporal;

        }

        public ActionResult ConsultaFechas(DateTime? f1 = null, DateTime? f2 = null)
        {
            DateTime vf1 = f1 == null ? DateTime.Today : (DateTime)f1;
            DateTime vf2 = f2 == null ? DateTime.Today : (DateTime)f2;

            return View(pedidosfechas(vf1, vf2));
        }
    }
}