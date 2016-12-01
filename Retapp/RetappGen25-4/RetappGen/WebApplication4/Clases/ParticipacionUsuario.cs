using RetappGenNHibernate.CAD.Retapp;
using RetappGenNHibernate.EN.Retapp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4.Clases
{

    public class ParticipacionUsuario
    {

        public int idConcurso;
        public string nombreConcurso;
        public string idUsuario;
        public string nombreUsuario;
        public int votos;
        public int posicion;

        public ParticipacionUsuario(string gacc, int idConc, string fraseCar, int vot)
        {
            idUsuario = gacc;
            idConcurso = idConc;
            nombreConcurso = fraseCar;
            votos = vot;
            posicion = 0;

            //string sql = "select tabla.pos from (SELECT ROW_NUMBER() OVER(ORDER BY Votos DESC) AS pos, FK_idUsuario_idUsuario idUsu FROM[RetappGenNHibernate].[dbo].[Participacion] where FK_idConcurso_idConcurso_0 = " + idConcurso + ") tabla where tabla.idUsu = " + idUsuario + ";";
            string sql = "select tabla.pos from (SELECT ROW_NUMBER() OVER(ORDER BY tabla0.votos_total DESC) AS pos, tabla0.Gaccount FROM " +
"(select Gaccount, idConcurso, sum(part.Votos) as votos_total from [RetappGenNHibernate].[dbo].[Usuario] usu, [RetappGenNHibernate].[dbo].[Participacion] part, [RetappGenNHibernate].[dbo].[Reto] reto, [RetappGenNHibernate].[dbo].[Concurso] con " +
"where part.FK_Gaccount_idUsuario_0 = usu.Gaccount and part.FK_id_idReto = reto.id and reto.FK_idConcurso_idConcurso = con.idConcurso " +
"group by Gaccount, idConcurso) tabla0 " +
"where tabla0.idConcurso = " + idConc + ") tabla where tabla.Gaccount = '" + gacc + "';";

            SqlConnection con = new SqlConnection(@"Server=(local); database=RetappGenNHibernate; integrated security=yes");
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                posicion = (int)reader.GetInt64(0);
            }

            con.Close();
        }

        public ParticipacionUsuario(ParticipacionEN pEN)
        {

            idConcurso = pEN.Reto.Concurso.Id;
            //idConcurso = pEN.Concurso.Id;
            ConcursoCAD concursoCAD = new ConcursoCAD();
            ConcursoEN concurso = concursoCAD.ReadOID(idConcurso);
            nombreConcurso = concurso.Compañia;
            idUsuario = pEN.Usuario_0.Gaccount;
            UsuarioCAD usuarioCAD = new UsuarioCAD();
            UsuarioEN usuario = usuarioCAD.ReadOID(idUsuario);
            nombreUsuario = usuario.Nombre;
            votos = pEN.Votos;
            posicion = 0;

            string sql = "select tabla.pos from (SELECT ROW_NUMBER() OVER(ORDER BY Votos DESC) AS pos, FK_idUsuario_idUsuario idUsu FROM[RetappGenNHibernate].[dbo].[Participacion] where FK_idConcurso_idConcurso_0 = " + idConcurso + ") tabla where tabla.idUsu = " + idUsuario + ";";
            SqlConnection con = new SqlConnection(@"Server=(local); database=RetappGenNHibernate; integrated security=yes");
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                posicion = (int)reader.GetInt64(0);
            }

            con.Close();

        }

        public ParticipacionUsuario()
        {

        }

    }

}