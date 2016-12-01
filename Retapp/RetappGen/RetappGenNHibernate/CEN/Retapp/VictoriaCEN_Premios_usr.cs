
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
public partial class VictoriaCEN
{
public System.Collections.Generic.IList<string> Premios_usr (string usr)
{
        /*PROTECTED REGION ID(RetappGenNHibernate.CEN.Retapp_Victoria_Premios_usr) ENABLED START*/

        // Write here your custom code...

        NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration().Configure();
        string ConnectionString = cfg.GetProperty(NHibernate.Cfg.Environment.ConnectionString);

        List<String> lista = new List<String>();
        try
        {
                SqlConnection c = new SqlConnection (ConnectionString);
                c.Open ();
                SqlCommand com = new SqlCommand ("Select idParticipacion from Participacion where FK_idUsuario_idUsuario_0 = " + usr + " ; ", c);
                SqlDataReader dr = com.ExecuteReader ();
                VictoriaCEN vicen = new VictoriaCEN ();
                while (dr.Read ()) {
                        VictoriaEN vit = vicen.ReadOID (dr.GetInt32 (0));
                        lista.Add (vit.Premio);
                }
                dr.Close ();
                c.Close ();
        }

        catch (Exception ex)
        {
                Console.WriteLine ("Se ha producido una excepcion al leer los premios de un concurso: " + ex);
        }

        return lista;

        /*PROTECTED REGION END*/
}
}
}
