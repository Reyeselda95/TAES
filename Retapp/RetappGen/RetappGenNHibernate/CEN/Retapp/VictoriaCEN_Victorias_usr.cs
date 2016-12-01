
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
public System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.VictoriaEN> Victorias_usr (string usr)
{
        /*PROTECTED REGION ID(RetappGenNHibernate.CEN.Retapp_Victoria_Victorias_usr) ENABLED START*/

        // Write here your custom code...

        NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration().Configure();
        string ConnectionString = cfg.GetProperty(NHibernate.Cfg.Environment.ConnectionString);

        List<VictoriaEN> lista = new List<VictoriaEN>();
        try
        {
                SqlConnection c = new SqlConnection (ConnectionString);
                c.Open ();
                SqlCommand com = new SqlCommand ("Select idParticipacion from Participacion where FK_idUsuario_idUsuario_0 = " + usr + " ; ", c);
                SqlDataReader dr = com.ExecuteReader ();
                VictoriaCEN vicen = new VictoriaCEN ();
                while (dr.Read ()) {
                        VictoriaEN vit = vicen._IVictoriaCAD.ReadOID (dr.GetInt32 (0));
                        lista.Add (vit);
                }
                dr.Close ();
                c.Close ();
        }

        catch (Exception ex)
        {
                Console.WriteLine ("Se ha producido una excepcion al leer las victorias de un usuario: " + ex);
        }

        return lista;

        /*PROTECTED REGION END*/
}
}
}
