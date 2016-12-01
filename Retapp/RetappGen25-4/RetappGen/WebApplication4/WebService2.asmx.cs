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

        String ConnectionString = "Data Source=84.120.133.214;Initial Catalog=RetappGennhibernate;User Id=nhibernateUser;Password=nhibernatePass;";
   
        [WebMethod]
        public string Login(string username, string password)
        {
            string sol = "nada";
            bool solb = false;
            UsuarioCEN usercen = new UsuarioCEN();
            try
            {
                solb = usercen.Validar(username, password);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
            /*SqlConnection con = new SqlConnection("Data Source=84.120.133.214;Initial Catalog=RetappGennhibernate;User Id=nhibernateUser;Password=nhibernatePass;");

            con.Open();

            string sql = "SELECT idConcurso, FechaFin, Aprobado, Finalizado, Campaña, Cuerpo, Premios, Reto, Pos, FechaInicio FROM RetappGenNHibernate.dbo.Concurso";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();*/
            /*Console.Out.Write(username + " " + password);
            sol = username + " " + password;
            if (username == "Paco@gmail.com" && password == "pakete")
                sol = "true";*/
            sol = solb.ToString();
            return sol;
        }

        //Muestra la lista de Id's de los concursos aprobados
        [WebMethod]
        public int[] ListaIdsConcursos()
        {
            ConcursoCEN cen = new ConcursoCEN();
            IList<ConcursoEN> en = cen.get_IConcursoCAD().ReadAll(0, int.MaxValue);
             for (int i = 0; i < en.Count; i++)
            {
                if (!en[i].Aprobado)
                {
                    en.Remove(en[i]);
                }
            }

            int[] lista = new int[en.Count];
            for (int i = 0; i < en.Count; i++)
            {
                lista[i] = en[i].Id;  
            }
                return lista;
        }
        
        [WebMethod]
        public string NombreCampanya(int id)
        {
            try
            {
                ConcursoCEN cen = new ConcursoCEN();
                ConcursoEN en = cen.get_IConcursoCAD().ReadOID(id);
                return en.FraseCaracteristica;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [WebMethod]
        public Resultado Registrarse(string gaccount, string pass, int tlf, string nom, string direccion, int codpo)
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
            usu.Baneado = false;
            usu.FechaBaneado = a;
            usu.FechaLogin = a;
            usu.Karma = 0;
            usu.NumBaneos = 0;
            usu.Votos = 0;
            usu.Password = pass;
            //usu.Id = 11;

            UsuarioCEN usucen = new UsuarioCEN();
            try {
                usucen.get_IUsuarioCAD().New_(usu);
            }catch(Exception){
                res.result = false;
                res.msg = "El usuario ya existe.";
            }         
            /*SqlConnection con = new SqlConnection("Data Source=84.120.133.214;Initial Catalog=RetappGennhibernate;User Id=nhibernateUser;Password=nhibernatePass;");
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
               // UsuarioCAD usuarioCAD = new UsuarioCAD();
                usuarioCAD.New_(usu);
            }*/
            

            return res;

        }

        [WebMethod]
        public Resultado ModificarUsuario(string gaccount, string pass, int tlf, string nom, string direccion, int codpo)
        {

            Resultado res = new Resultado();
            res.result = true;
            res.msg = "Usuario modificado.";

            UsuarioCEN usucen = new UsuarioCEN();

            UsuarioEN usu = usucen.ReadOID(gaccount);
            usu.Tlf = tlf;
            usu.Nombre = nom;
            usu.Direccion = direccion;
            usu.CodPstal = codpo;
            usu.Password = pass;

            try
            {
                usucen.get_IUsuarioCAD().Modify(usu);
            }
            catch (Exception)
            {
                res.result = false;
                res.msg = "El usuario no se ha podido modificar.";
            }
            
            return res;

        }
        
        [WebMethod]
        public Participacion pedirParticipacionVotar(string gaccount)
        {

            ParticipacionCEN parcen = new ParticipacionCEN();
            UsuarioCEN usucen = new UsuarioCEN();
            UsuarioEN usu = usucen.ReadOID(gaccount);

            foreach (ParticipacionEN p in parcen.ReadAll(0, int.MaxValue))
            {
                if (!p.Usuario_0.Equals(usu)  && !p.Usuario.Contains(usu))
                {
                    return new Participacion(p);
                }

            }

            return null;

        }

        
        [WebMethod]
        public Resultado inscribirse(String gaccount, int idConcurso)
        {
            Resultado res = new Resultado();
            res.result = true;
            res.msg = "Inscripción realizada con éxito.";

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            ConcursoCEN concen = new ConcursoCEN();
            ParticipacionCEN partcen = new ParticipacionCEN();
            ConcursoEN con = concen.ReadOID(idConcurso);
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(gaccount);
            if (usuarioEN == null || con==null)
            {
                res.result = false;
                res.msg = "El usuario no existe.";
            }
            else
            {
               /* RetoCAD retoCAD = new RetoCAD();
                List<RetoEN> listaRetoEN = new List<RetoEN>(retoCAD.ReadAll(0, int.MaxValue));
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
                }*/
                  foreach (RetoEN r in con.Retos) {
                    if (r.Active) {
                        ParticipacionEN participacionEN = new ParticipacionEN();
                        participacionEN.Fecha = DateTime.Now;
                        participacionEN.Valor = 0;
                        participacionEN.Prueba = "";
                        participacionEN.Votos = 0;
                        participacionEN.Reportes = 0;
                        participacionEN.Reto = r;
                        participacionEN.Usuario_0 = usuarioEN;
                        partcen.get_IParticipacionCAD().New_(participacionEN);
                    }
                  }
             }
                
            

            return res;
        }

        [WebMethod]
        public string ranking(string usuario) {
            ParticipacionCEN partcen = new ParticipacionCEN();
            return partcen.Ranking(usuario);
        }

        //Devuelve un array con los id's de los retos en los que estamos participando
        [WebMethod]
        public int[] getIdsRetos(string gaccount)
        {
            ParticipacionCEN parcen = new ParticipacionCEN();
            IList<ParticipacionEN> parlista = parcen.ReadAll(0, int.MaxValue);
            UsuarioCEN usucen = new UsuarioCEN();
            UsuarioEN usu = usucen.ReadOID(gaccount);

            for (int j = 0; j < parlista.Count; j++) {
                if (!parlista[j].Usuario_0.Equals(usu))
                {
                    parlista.Remove(parlista[j]);
                    j--;
                }
            
            }
      
            int[] lista = new int[parlista.Count];
            int i=0;
            foreach (ParticipacionEN part in parlista) {
                lista[i] = part.Id;
                ++i;
            }
            return lista;
            /*List<ParticipacionUsuario> lista = new List<ParticipacionUsuario>();

            string sql = "select Gaccount, idConcurso, FraseCaracteristica, sum(part.Votos) from [RetappGenNHibernate].[dbo].[Usuario] usu, [RetappGenNHibernate].[dbo].[Participacion] part, [RetappGenNHibernate].[dbo].[Reto] reto, [RetappGenNHibernate].[dbo].[Concurso] con " +
                "where usu.Gaccount = '" + gaccount + "' and part.FK_Gaccount_idUsuario_0 = usu.Gaccount and part.FK_id_idReto = reto.id and reto.FK_idConcurso_idConcurso = con.idConcurso " +
                "group by Gaccount, idConcurso, FraseCaracteristica" +
                ";";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new ParticipacionUsuario(reader.GetString(0), (int)reader.GetInt32(1), reader.GetString(2), (int)reader.GetInt32(3)));
            }

            con.Close();

            return lista.ToArray();*/
        }

        //Devuelve los retos activos asociados a una campaña
        [WebMethod]
        public int[] getRetosCampaña(int id) {
            ConcursoCEN concurcen = new ConcursoCEN();
            IList<RetoEN> listaRetos = concurcen.ReadRetos(id);
            for (int i = 0; i < listaRetos.Count; i++)
            {
                if (!listaRetos[i].Active)
                {
                    listaRetos.Remove(listaRetos[i]);
                }
            }

            int[] lista = new int[listaRetos.Count];
            for (int i = 0; i < listaRetos.Count; i++)
            {
                lista[i] = listaRetos[i].Id;
            }
            return lista;
        }

        //Devuelve el Reto que se le pasa por id
        [WebMethod]
        public Reto getReto(int id)
        {
            RetoCEN retocen = new RetoCEN();
            RetoEN retoEN = retocen.get_IRetoCAD().ReadOID(id);
            return new Reto(retoEN);

        }

        /*[WebMethod]
        public int[] getIdsRetos()
        {
            RetoCEN cen = new RetoCEN();
            ParticipacionCEN pcen = new ParticipacionCEN();
            ParticipacionEN pen;
            IList<RetoEN> en = cen.ReadAll(0,99);
            int cont = 0;
            int[] lista = new int[en.Count];
            for (int i = 0; i < en.Count; i++)
            {
                if (pcen.ReadOID(en[i].Participacion))
            }
        }*/

        // Devuelve el concurso que se le pasa por id
        [WebMethod]
        public Concurso getConcurso(int id)
        {
            ConcursoCAD concursoCAD = new ConcursoCAD();
            ConcursoEN concursoEN = concursoCAD.ReadOID(id);
            return new Concurso(concursoEN);

        }

        //Metodo cuando se le da a votar un reto, si se considera superado
        [WebMethod]
        public Resultado votar(int idParticipacion, string usuario)
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
                UsuarioCEN usucen = new UsuarioCEN();
                UsuarioEN usuen = usucen.get_IUsuarioCAD().ReadOID(usuario);
                if (!(participacionEN.Usuario.Contains(usuen) || usuen.Equals(participacionEN.Usuario_0))) {
                    participacionEN.Usuario.Add(usuen);
                    participacionEN.Votos = participacionEN.Votos + 1;
                    usuen.Votos++;
                    usucen.get_IUsuarioCAD().Modify(usuen);
                    participacionCAD.Modify(participacionEN);
                }
                else
                {
                    res.result = false;
                    res.msg = "Ya has votado este reto.";
                }
            }
            
            return res;

        }

        [WebMethod]
        public Resultado registrarPrueba(int idParticipacion, string url)
        {

            Resultado res = new Resultado();
            res.result = true;
            res.msg = "Prueba registrada con éxito.";

            ParticipacionCEN participacionCEN = new ParticipacionCEN();
            ParticipacionEN participacionEN = participacionCEN.ReadOID(idParticipacion);

            if (participacionEN == null)
            {
                res.result = true;
                res.msg = "No se ha podido registrar la prueba.";
            }
            else
            {
                participacionCEN.SubirDemo(url, idParticipacion);
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
        public string SaveImage()
        {
            HttpPostedFile file = HttpContext.Current.Request.Files["recFile"];
            string targetFilePath = HttpContext.Current.Server.MapPath("~/") + file.FileName;
            file.SaveAs(targetFilePath);

            return file.FileName.ToString();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "La connection string es:" + ConnectionString;
        }
    }
}
