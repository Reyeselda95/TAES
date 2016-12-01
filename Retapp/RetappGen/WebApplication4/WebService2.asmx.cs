using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication4.Clases;
using RetappGenNHibernate.CAD.Retapp;
using RetappGenNHibernate.EN.Retapp;
using RetappGenNHibernate.CEN.Retapp;
using System.Data.SqlClient;

namespace WebApplication4
{
    /// <summary>
    /// Descripción breve de WebService2
    /// </summary>
    [WebService(Namespace = "http://retapp.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {
        
        [WebMethod]
        public string Login(string username, string password)
        {
            
            string sol = "nada";
            
            Console.Out.Write(username + " " + password);
            sol = username + " " + password;
            if (username == "Paco@gmail.com" && password == "pakete")
                sol = "true";
            return sol;
             
           
        }

        
        [WebMethod]
        public Concurso[] ListadoConcursos()
        {
            List<Concurso> lista = new List<Concurso>();
            ConcursoCAD concursoCAD = new ConcursoCAD();
            List<ConcursoEN> concursos = new List<ConcursoEN>(concursoCAD.ReadAll(0, 0));
            //return new Concurso(concursoCAD.ReadAll(0));
            foreach (ConcursoEN cEN in concursos)
            {
                lista.Add(new Concurso(cEN));
            }

            return lista.ToArray();

        }
        


        [WebMethod]
        public Resultado Registrarse(string gaccount, int tlf, string nom, string direccion, int codpo)
        {

            Resultado res = new Resultado();
            res.result = true;
            res.msg = "Usuario dado de alta.";

            Nullable<DateTime> a = new Nullable<DateTime>();

            UsuarioEN usu = new UsuarioEN();
            usu.Gaccount = gaccount;
            usu.Tlf = tlf;
            usu.Nombre = nom;
            usu.Direccion = direccion;
            usu.CodPstal = codpo;
            usu.Baneado = true;
            usu.FechaBaneado = a;
            usu.FechaLogin = a;
            usu.Karma = 0;
            usu.NumBaneos = 0;
            usu.Votos = 0;
            usu.Password = "as";
            //usu.Id = 11;

            SqlConnection con = new SqlConnection(@"Server=(local); database=RetappGenNHibernate; integrated security=yes");
            con.Open();

            string sql = "SELECT * FROM RetappGenNHibernate.dbo.Usuario where Gaccount = '" + gaccount + "';";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                res.result = false;
                res.msg = "El usuario ya existe.";

            }
            else
            {
                UsuarioCAD usuarioCAD = new UsuarioCAD();
                usuarioCAD.New_(usu);
            }


            return res;

        }


        [WebMethod]
        public Resultado inscribirse(String gaccount, int idConcurso)
        {
            Resultado res = new Resultado();
            res.result = true;
            res.msg = "Inscripción realizada con éxito.";

            UsuarioCAD usuarioCAD = new UsuarioCAD();
            UsuarioEN usuarioEN = usuarioCAD.ReadOID(gaccount);
            if (usuarioEN == null)
            {
                res.result = false;
                res.msg = "El usuario no existe.";
            }
            else
            {
                RetoCAD retoCAD = new RetoCAD();
                List<RetoEN> listaRetoEN = new List<RetoEN>(retoCAD.ReadAll(0, 0));
                //listaRetoEN = listaRetoEN.Where(r => r.Concurso.Id == idConcurso).ToList<RetoEN>();
                listaRetoEN = listaRetoEN.Where(r => r.Concurso.Id == idConcurso && r.Active == true).ToList<RetoEN>();

                foreach (RetoEN retoEN in listaRetoEN)
                {
                    ParticipacionCAD participacionCAD = new ParticipacionCAD();
                    ParticipacionEN participacionEN = new ParticipacionEN();
                    participacionEN.Fecha = DateTime.Now;
                    participacionEN.Valor = 0;
                    participacionEN.Prueba = "";
                    participacionEN.Votos = 0;
                    participacionEN.Reportes = 0;
                    participacionEN.Reto = retoEN;
                    participacionEN.Usuario_0 = usuarioEN;
                    participacionCAD.New_(participacionEN);
                }
            }

            return res;
        }

        [WebMethod]
        public ParticipacionUsuario[] getParticipacionesUsuario(string gaccount)
        {
            List<ParticipacionUsuario> lista = new List<ParticipacionUsuario>();

            string sql = "select Gaccount, idConcurso, FraseCaracteristica, sum(part.Votos) from [RetappGenNHibernate].[dbo].[Usuario] usu, [RetappGenNHibernate].[dbo].[Participacion] part, [RetappGenNHibernate].[dbo].[Reto] reto, [RetappGenNHibernate].[dbo].[Concurso] con " +
                "where usu.Gaccount = '" + gaccount + "' and part.FK_Gaccount_idUsuario_0 = usu.Gaccount and part.FK_id_idReto = reto.id and reto.FK_idConcurso_idConcurso = con.idConcurso " +
                "group by Gaccount, idConcurso, FraseCaracteristica" +
                ";";
            SqlConnection con = new SqlConnection(@"Server=(local); database=RetappGenNHibernate; integrated security=yes");
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new ParticipacionUsuario(reader.GetString(0), (int)reader.GetInt32(1), reader.GetString(2), (int)reader.GetInt32(3)));
            }

            con.Close();

            return lista.ToArray();
        }
        

        // Devuelve el concurso que se le pasa por id
        [WebMethod]
        public Concurso getConcurso(int id)
        {
            ConcursoCAD concursoCAD = new ConcursoCAD();
            return new Concurso(concursoCAD.ReadOID(id));

        }


        //Metodo cuando se le da a votar un reto, si se considera superado
        [WebMethod]
        public Resultado votar(int idParticipacion)
        {

            Resultado res = new Resultado();
            res.result = true;
            res.msg = "Voto realizado con éxito.";



            ParticipacionCAD participacionCAD = new ParticipacionCAD();
            ParticipacionEN participacionEN = participacionCAD.ReadOID(idParticipacion);

            if (participacionEN == null)
            {
                res.result = true;
                res.msg = "No se ha podido realizar la votación.";
            }
            else
            {
                participacionEN.Votos = participacionEN.Votos + 1;
                participacionCAD.Modify(participacionEN);

            }


            return res;

        }
        


        //Devuelve los datos del usuario pasandole su id
        [WebMethod]
        //public Usuario UsuarioPerfil(int id)
        public Usuario UsuarioPerfil(String gaccount)
        {

            UsuarioCAD usuarioCAD = new UsuarioCAD();
            return new Usuario(usuarioCAD.ReadOID(gaccount));

        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
