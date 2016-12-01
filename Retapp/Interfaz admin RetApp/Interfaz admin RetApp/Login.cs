using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RetappGenNHibernate.CEN.Retapp;

namespace Interfaz_admin_RetApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminCEN admin = new AdminCEN();
            if (admin.Validar(textBox1.Text,textBox2.Text)){
                    label3.Visible = false;
                    try {
                        Administracion administrate = new Administracion(this);
                        this.Hide();
                        administrate.Show();                      
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Se ha producido una excepción al abrir el programa: " + ex);
                    }
            }
            else {
                label3.Visible = true;
                textBox2.Clear();
            }         
        }
    }
}
