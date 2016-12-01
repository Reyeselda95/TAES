using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using RetappGenNHibernate.EN.Retapp;
using RetappGenNHibernate.CAD.Retapp;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
namespace RetappGenNHibernate.CEN.Retapp
{
public partial class ConcursoCEN
{
public System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ConcursoEN> ReadporFecha (Nullable<DateTime> fecha)
{
        /*PROTECTED REGION ID(RetappGenNHibernate.CEN.Retapp_Concurso_ReadporFecha) ENABLED START*/

        // Write here your custom code...

        string ConnectionString = "Data Source=ARA65;Initial Catalog=RetappGenNHibernate;Persist Security Info=True;User ID=nhibernateUser;Password=nhibernatePass";

        List<ConcursoEN> lista = new List<ConcursoEN>();
        try
        {
                SqlConnection c = new SqlConnection (ConnectionString);
                c.Open ();
                SqlCommand com = new SqlCommand ("Select idConcurso from Concurso where (FechaFin > " + fecha + ") and ((Aprobado is true) and (Finalizado is false)) order by FechaFin asc;", c);
                SqlDataReader dr = com.ExecuteReader ();
                ConcursoCEN concen = new ConcursoCEN ();
                while (dr.Read ()) {
                        ConcursoEN conc = concen.ReadOID (dr.GetInt32 (0));
                        lista.Add (conc);
                }
                dr.Close ();
                c.Close ();
        }

        catch (Exception ex)
        {
                Console.WriteLine ("Se ha producido una excepcion al leer concursos por fecha: " + ex);
        }

        return lista;

        /*PROTECTED REGION END*/
}
}
}
