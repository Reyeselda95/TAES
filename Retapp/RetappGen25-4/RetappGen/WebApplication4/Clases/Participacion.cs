using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RetappGenNHibernate.EN.Retapp;
using System.Xml.Serialization;

namespace WebApplication4.Clases
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://retapp.org/")]
    public class Participacion
    {

        /**
         *	id del reto
         */
        [XmlElement(ElementName = "reto")]
        public int Reto { get; set; }


        /**
         *	Atributo usuario_0
         */
        [XmlElement(ElementName = "usuario_0")]
        private RetappGenNHibernate.EN.Retapp.UsuarioEN Usuario_0 { get; set; }


        [XmlElement(ElementName = "fecha")]
        public Nullable<DateTime> Fecha { get; set; }


        [XmlElement(ElementName = "valor")]
        public float Valor { get; set; }


        [XmlElement(ElementName = "prueba")]
        public string Prueba { get; set; }


        [XmlElement(ElementName = "votos")]
        public int Votos { get; set; }


        [XmlElement(ElementName = "reportes")]
        public int Reportes { get; set; }


        [XmlElement(ElementName = "id")]
        public int Id { get; set; }


        public Participacion()
        {
        }

        public Participacion(ParticipacionEN p)
        {
            this.Reto = p.Reto.Id;
            this.Fecha = p.Fecha;
            this.Id = p.Id;
            this.Prueba = p.Prueba;
            this.Reportes = p.Reportes;
            this.Usuario_0 = p.Usuario_0;
            this.Valor = p.Valor;
            this.Votos = p.Votos;


        }

        public Participacion(Participacion participacion)
        {
                this.init (Id, participacion.Reto, participacion.Usuario_0, participacion.Fecha, participacion.Valor, participacion.Prueba, participacion.Votos, participacion.Reportes);
        }

        private void init (int id, int reto, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes)
        {
                this.Id = id;

                this.Reto = reto;

                this.Usuario_0 = usuario_0;

                this.Fecha = fecha;

                this.Valor = valor;

                this.Prueba = prueba;

                this.Votos = votos;

                this.Reportes = reportes;
        }

        public void Modify(ParticipacionEN participacion)
        {
            this.Id = participacion.Id;

            this.Reto = participacion.Reto.Id;
            
            this.Usuario_0 = participacion.Usuario_0;

            this.Fecha = participacion.Fecha;

            this.Valor = participacion.Valor;

            this.Prueba = participacion.Prueba;

            this.Votos = participacion.Votos;

            this.Reportes = participacion.Reportes;
        }
    }
}