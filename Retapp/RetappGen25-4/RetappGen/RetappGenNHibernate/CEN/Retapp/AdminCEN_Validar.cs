
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
public partial class AdminCEN
{
public bool Validar (string usr, string pass)
{
        /*PROTECTED REGION ID(RetappGenNHibernate.CEN.Retapp_Admin_Validar) ENABLED START*/
        NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration ().Configure ();
        string ConnectionString = cfg.GetProperty (NHibernate.Cfg.Environment.ConnectionString);

        bool esAdmin = false;

        try
        {
                SqlConnection c = new SqlConnection (ConnectionString);
                c.Open ();
                SqlCommand com = new SqlCommand ("Select * from Admin where [Usr] like '" + usr + "' and [pass] like '" + pass + "';", c);
                SqlDataReader dr = com.ExecuteReader ();
                if (dr.Read ()) {
                        esAdmin = true;
                }
                dr.Close ();
                c.Close ();
        }

        catch (Exception ex)
        {
                Console.WriteLine ("Se ha producido una excepción al validar el Admin: " + ex);
        }

        return esAdmin;

        /*PROTECTED REGION END*/
}
}
}
