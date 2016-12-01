using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RetappGenNHibernate.EN.Retapp;
using RetappGenNHibernate.CEN.Retapp;

namespace Interfaz_admin_RetApp
{
    public partial class Reto : Form
    {
        RetoEN reto;
        Campaña campaign;

        public virtual RetoEN Retoen
        {
            get { return reto; }
            set { reto = value; }
        }


        public Reto()
        {
            InitializeComponent();
        }

        public Reto(Campaña camp)
        {
            campaign = camp;
            InitializeComponent();
        }

        private void Reto_Load(object sender, EventArgs e)
        {
            try
            {
                if (reto != null)
                {
                    textBox1.Text = reto.Nombre;
                    richTextBox1.Text = reto.Descripcion;
                    dateTimePicker1.Value = (DateTime)reto.FechaFin;
                    if (dateTimePicker1.Value < DateTime.Now)
                    {
                        label4.Visible = true;
                    }
                    else { label4.Visible = false; }
                    if(!reto.Active){
                        button1.Visible = true;
                    }
                    else { button1.Visible = false; }
                }
                else
                {
                    dateTimePicker1.Value = new DateTime();
                    textBox1.Text = null;
                    richTextBox1.Text = null;
                }
            }
            catch (Exception ex) { }
        }

        //Activa un reto si su fecha no ha expirado todavía
        private void button1_Click(object sender, EventArgs e)
        {
            RetoCEN retocen = new RetoCEN();
            DateTime ahora = DateTime.Now;
            try
            {
                if (dateTimePicker1.Value < ahora)
                {
                    label4.ForeColor = Color.Red;
                    label4.Text = "La fecha de finalización del reto ha expirado.\r\nPara activar el reto cambiela por una igual o superior a la actual.";
                    label4.Visible = true;
                }
                else
                {
                    if (reto.FechaFin < ahora)
                    {
                        label4.ForeColor = Color.Red;
                        label4.Text = "Debe confirmar los cambios antes de activar el reto.";
                        label4.Visible = true;
                    }
                    else
                    {
                        label4.Visible = false;
                        retocen.Activar(reto.Id);
                        reto.Active = true;
                        this.Reto_Load(sender, e);
                        label4.ForeColor = Color.Black;
                        label4.Text = "Reto Activado";
                        label4.Visible = true;
                    }
                }
            }catch(Exception ex){}
        }

        //Guarda los cambios y hace commmit en la BBDD
        //Pone active a false
        private void button2_Click(object sender, EventArgs e)
        {
            RetoCEN retocen = new RetoCEN();
            ConcursoCEN concen = new ConcursoCEN();
            if (reto == null)
            {
                reto = new RetoEN();
                reto.Concurso = campaign.Concur;
                reto.Active = false;
                reto.Nombre = textBox1.Text;
                reto.Descripcion=richTextBox1.Text;
                reto.FechaFin = (DateTime)dateTimePicker1.Value;
                reto.Id=retocen.New_(campaign.Concur.Id,textBox1.Text,richTextBox1.Text,(DateTime)dateTimePicker1.Value,false);
            }
            else
            {
                reto.FechaFin = dateTimePicker1.Value;
                reto.Nombre = textBox1.Text;
                reto.Descripcion = richTextBox1.Text;
                reto.Active = false;
                retocen.get_IRetoCAD().Modify(reto);
            }
            //Actualiza la vista anterior
            this.Reto_Load(sender,e);
            campaign.Campaña_Load(sender, e);
        }
        
        //Descarta los cambios
        private void button3_Click(object sender, EventArgs e)
        {
            this.Reto_Load(sender, e);
        }

        //Vuelve atrás sin tocar nada
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
