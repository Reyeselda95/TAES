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
using RetappGenNHibernate.EN.Retapp;

namespace Interfaz_admin_RetApp
{
    public partial class Administracion : Form
    {
        Login Padre;
        public Administracion() {
            InitializeComponent();
        }
        public Administracion(Login padre)
        {
            Padre = padre;
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ConcursoCEN concen = new ConcursoCEN();
      //        ConcursoEN concurso = concen.ReadOID(Int32.Parse(listBox1.SelectedValue.ToString()));
                Console.WriteLine(listBox1.SelectedValue.ToString());
            }
            catch (Exception) { }
        }

        public void Administracion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'retappGenNHibernateDataSet1.Concurso' Puede moverla o quitarla según sea necesario.
            this.concursoTableAdapter1.Fill(this.retappGenNHibernateDataSet1.Concurso);
            // TODO: esta línea de código carga datos en la tabla 'retappGenNHibernateDataSet.Concurso' Puede moverla o quitarla según sea necesario.
            this.concursoTableAdapter.Fill(this.retappGenNHibernateDataSet.Concurso);
            // TODO: esta línea de código carga datos en la tabla 'retappGenNHibernateDataSet.Concurso' Puede moverla o quitarla según sea necesario.
        }

        //Invalida la campaña
        //OK
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ConcursoCEN concen = new ConcursoCEN();
                concen.Invalidar(Int32.Parse(listBox2.SelectedValue.ToString()));
                this.Administracion_Load(sender,e);
               // Console.WriteLine(listBox2.SelectedValue.ToString());
            }
            catch (Exception) { }
        }

        //Borra la campaña
        //OK
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ConcursoCEN concen = new ConcursoCEN();
                concen.Destroy(Int32.Parse(listBox1.SelectedValue.ToString()));
                this.Administracion_Load(sender, e);
           //     Console.WriteLine(listBox2.SelectedValue.ToString());
            }
            catch (Exception) { }
        }

        //Esto cierra el login cuando se cierra la ventana de administracion
        private void Administracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Padre.Close();
            }
            catch(Exception){
            }
        }

        //Abre la ventana de descripción cuando se hace click
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(listBox2.SelectedValue.ToString());
            }
            catch (Exception) { }
        }

        //Finaliza la campaña
        //OK
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConcursoCEN concen = new ConcursoCEN();
                concen.Finalizar(Int32.Parse(listBox1.SelectedValue.ToString()));
                this.Administracion_Load(sender, e);
            }
            catch (Exception) { }
        }

        //Abre la ventana para modificar la campaña
        //OK
        private void button4_Click(object sender, EventArgs e)
        {
            Campaña camp = new Campaña(this);
            ConcursoCEN concen = new ConcursoCEN();
            camp.Concur = concen.ReadOID(Int32.Parse(listBox1.SelectedValue.ToString()));
            camp.Visible = true;
        }

        //Valida la campaña
        //OK
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ConcursoCEN concen = new ConcursoCEN();
                concen.Validar(Int32.Parse(listBox1.SelectedValue.ToString()));
                this.Administracion_Load(sender, e);
            }
            catch (Exception) { }
        }

        //Crea una nueva campaña
        //OK
        private void button6_Click(object sender, EventArgs e)
        {
            Campaña camp = new Campaña(this);
            camp.Visible = true;
        }


    }
}
