using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;


using System.Data.SqlClient;
using WebApplication3.Clases;

//using RetappGenNHibernate.EN.Retapp;
//using RetappGenNHibernate.CEN.Retapp;

namespace WebApplication3
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {


        [WebMethod]
        public Concurso[] ListadoConcursos()
        {
            //Concurso[] c = new Concurso[];
            //SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RetappGenNHibernate;Integrated Security=True");
            SqlConnection con = new SqlConnection(@"Server=(local); database=RetappGenNHibernate; integrated security=yes");

            con.Open();

            string sql = "SELECT idConcurso, FechaFin, Aprobado, Finalizado, Campaña, Cuerpo, Premios, Reto, Pos, FechaInicio FROM RetappGenNHibernate.dbo.Concurso";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Concurso> lista = new List<Concurso>();

            while (reader.Read())
            {
                lista.Add(new Concurso(reader.GetInt32(0), reader.GetDateTime(1), reader.GetBoolean(2), reader.GetBoolean(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetDateTime(9)));
            }

            con.Close();
            //return lista;
            
            return lista.ToArray();
            
            
        }



        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
