using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.Collections;

using RetappGenNHibernate.EN.Retapp;

namespace Campañas.aspx
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlDataReader a;
        ENUsuario usuario = new ENUsuario();
        ConcursoEN en = new ConcursoEN();
        DataSet d = new DataSet();
        SqlDataReader d1;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //muestra canciones y las añade al grid y lo enseña
                d = en.mostrarCanciones();
                if (d.Tables.Count > 0)
                {
                    //GridView1.Columns[0].Visible = false;
                    GridView1.DataSource = d;
                    GridView1.DataBind();
                }
                else
                {

                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}