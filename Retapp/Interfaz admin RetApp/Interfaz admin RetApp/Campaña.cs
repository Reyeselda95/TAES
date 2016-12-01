using System;
using System.Text.RegularExpressions;
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
    public partial class Campaña : Form
    {
        private ConcursoEN concur;
        private Administracion administration;
        public Campaña()
        {
            InitializeComponent();
        }

        public Campaña(Administracion admin) {
            administration = admin;
            InitializeComponent();
        }
        public virtual ConcursoEN Concur{
            get { return concur; }   set { concur = value; }
        }

        public void Campaña_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'retappGenNHibernateDataSet2.Reto' Puede moverla o quitarla según sea necesario.
            try
            {
                ///AQUI VAN LAS DEFINICIONES TEMPORALES///
          /*      ConcursoCEN concen = new ConcursoCEN();
                concur = concen.ReadOID(1);*/
                if (concur != null)
                {
                    this.retoTableAdapter.Fill(this.retappGenNHibernateDataSet2.Reto, concur.Id);
                    ///Tokenizaddo del string de Imagen y Eslogan de la campaña
                   /** string pattern = @"[^<>]+";
                    MatchCollection mc = Regex.Matches(concur.Campaña, pattern);
                    if (mc.Count >= 1)
                    {
                        textBox1.Text = mc[0].Groups[0].Value;
                        if (mc.Count >= 2)
                        {
                            textBox1.Text = mc[1].Groups[0].Value;
                        }
                    }
                    */

                    //Frase Característica
                    textBox2.Text = concur.FraseCaracteristica;
                    //Nombre Compañía
                    textBox3.Text = concur.Compañia;
                    //URL imagen
                    textBox1.Text = concur.Imagen;
                    //Fecha de inicio
                    dateTimePicker1.Value = (DateTime)concur.FechaInicio;
                    //Fecha de fin
                    dateTimePicker2.Value = (DateTime)concur.FechaFin;
                    //Asigna la URL al cuadrado de imagen
                    pictureBox1.ImageLocation = textBox1.Text;
                    //Premios
                    richTextBox1.Text = concur.Premios;
                    //Descripción
                    richTextBox2.Text = concur.Cuerpo;
                    //Reto
                    //Aqui habría que seleccionar únicamente los retos que pertenecieran a una campaña específica
                    listBox1.Items.Clear();
                    listBox1.Items.Add(concur.Retos);
                    button4.Visible = true;
                    button5.Visible = true;
                    button6.Visible = true;

                }
                else {//Limpia en el caso de descartar sin haber seleccionado nada
                    button4.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    pictureBox1.ImageLocation = null;
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    richTextBox1.Text = null;
                    richTextBox2.Text = null;
                    dateTimePicker1.Value = new DateTime();
                    dateTimePicker2.Value = new DateTime();
                    listBox1.Items.Clear();
                }

            }
            catch (Exception){ }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value) {
                label5.ForeColor = Color.Red;
                label5.Text="La fecha de inicio no puede ser mayor que la fecha de finalización.";
            }
            else{
                label5.ForeColor = Color.Black;
                label5.Text = "Fecha Inicio";
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                label6.ForeColor = Color.Red;
                label6.Text = "La fecha de finalización no puede ser menor que la fecha de inicio.";
            }
            else
            {
                label6.ForeColor = Color.Black;
                label6.Text = "Fecha Fin";
            }
        }

        //Guarda los cambios y cierra
        private void button2_Click(object sender, EventArgs e)
        {
            ConcursoCEN concen = new ConcursoCEN();

            if (concur == null)
            {
                concur = new ConcursoEN();
                concur.Aprobado = false;
                concur.Finalizado = false;

                //Asignamos los valores de los controles a las variables

                concur.Imagen = textBox1.Text;
                //Fecha de inicio
                concur.FechaInicio = dateTimePicker1.Value;
                //Fecha de fin
                concur.FechaFin = dateTimePicker2.Value;
                //Asigna la URL al cuadrado de imagen
                pictureBox1.ImageLocation = textBox1.Text;

                //Premios
                concur.Premios = richTextBox1.Text;
                //Descripción
                concur.Cuerpo = richTextBox2.Text;
                //Frase característica
                concur.FraseCaracteristica = textBox2.Text;
                //Campaña
                concur.Compañia = textBox3.Text;
                //Reto (NO PUEDE SER NULL)
                //concur.Reto = "NUEVO RETO";

                //Inserta
                concen.New_(concur.FechaFin, concur.Aprobado, concur.Finalizado, concur.FraseCaracteristica, concur.Cuerpo, concur.Premios, concur.Pos, concur.FechaInicio, concur.Imagen, concur.Compañia);
            }
            else {//En el caso de que no sea uno nuevo
                //Asignamos los valores de los controles a las variables

                //Asignamos los valores de los controles a las variables

                concur.Imagen = textBox1.Text;
                //Fecha de inicio
                concur.FechaInicio = dateTimePicker1.Value;
                //Fecha de fin
                concur.FechaFin = dateTimePicker2.Value;
                //Asigna la URL al cuadrado de imagen
                pictureBox1.ImageLocation = textBox1.Text;

                //Premios
                concur.Premios = richTextBox1.Text;
                //Descripción
                concur.Cuerpo = richTextBox2.Text;
                //Frase característica
                concur.FraseCaracteristica = textBox2.Text;
                //Campaña
                concur.Compañia = textBox3.Text;
                //Actualiza
                concen.Modify(concur.Id,concur.FechaFin, concur.Aprobado, concur.Finalizado, concur.FraseCaracteristica, concur.Cuerpo, concur.Premios, concur.Pos, concur.FechaInicio, concur.Imagen,concur.Compañia);
            }
            //Actualiza ventana anterior
            administration.Administracion_Load(sender, e);
            this.Close();
        }

        //Devuelve los cambios a su estado inicial
        //OK
        private void button1_Click(object sender, EventArgs e)
        {
            this.Campaña_Load(sender,e);
        }

        //Vuelve atrás sin tocar nada
        //OK
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Modificar Reto
        private void button5_Click(object sender, EventArgs e)
        {
            Reto reto = new Reto(this);
            RetoCEN retocen = new RetoCEN();
            reto.Retoen = retocen.ReadOID(Int32.Parse(listBox1.SelectedValue.ToString()));
            reto.Visible = true;
        }

        //Nuevo Reto
        private void button6_Click(object sender, EventArgs e)
        {
            Reto reto = new Reto(this);
            reto.Visible = true;
        }

        //Elimina un reto
        private void button4_Click(object sender, EventArgs e)
        {
            RetoCEN retocen = new RetoCEN();
            retocen.Destroy(Int32.Parse(listBox1.SelectedValue.ToString()));
            this.Campaña_Load(sender, e);
        }


    }
}
