
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
public partial class ParticipacionCEN
{
public String Ranking (string usr)
{
        /*PROTECTED REGION ID(RetappGenNHibernate.CEN.Retapp_Participacion_Ranking) ENABLED START*/

        NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration().Configure();
       string ConnectionString = cfg.GetProperty(NHibernate.Cfg.Environment.ConnectionString);

        // Write here your custom code...
         String ranking = "";
        try
        {
            SqlConnection c = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("dbo.Ranking", c);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@user", usr);
            c.Open();
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ranking= ranking + dr.GetString(1)+"   |   "+dr.GetInt32(0)+"#";
            }
        }
        catch (Exception ex) { Console.WriteLine ("Se ha producido una excepci�n al introducir la crear el ranking del usuario: " + ex); }
        return ranking;

        /*PROTECTED REGION END*/
}
}
}
