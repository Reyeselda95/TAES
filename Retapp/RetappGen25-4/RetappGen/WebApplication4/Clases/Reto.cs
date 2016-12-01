using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using RetappGenNHibernate.EN.Retapp;


// Definición clase RetoEN
namespace WebApplication4.Clases
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://retapp.org/")]
    public class Reto
    {

        /**
         *	Atributo nombre
         */
        [XmlElement(ElementName = "nombre")]
        public string Nombre{ get; set; }

        /**
         *	Atributo descripcion
         */
        [XmlElement(ElementName = "descripcion")]
        public string Descripcion { get; set; }
        
        /**
         *	Atributo fechaFin
         */
        [XmlElement(ElementName = "FechaFin")]
        public Nullable<DateTime> FechaFin{ get; set; }
        
        /**
         *	Atributo active
         */
        [XmlElement(ElementName = "Active")]
        public bool Active{ get; set; }
        
        /**
         *	Atributo id
         */
        [XmlElement(ElementName = "Id")]
        public int Id{ get; set; }


        public Reto(int id, string nombre, string descripcion, Nullable<DateTime> fechaFin, bool active)
        {
                this.init (Id, nombre, descripcion, fechaFin, active);
        }

        public Reto() { }

        public Reto(RetoEN reto)
        {
                this.init (reto.Id, reto.Nombre, reto.Descripcion, reto.FechaFin, reto.Active);
        }

        private void init (int id, string nombre, string descripcion, Nullable<DateTime> fechaFin, bool active)
        {
                this.Id = id;

                this.Nombre = nombre;

                this.Descripcion = descripcion;

                this.FechaFin = fechaFin;

                this.Active = active;

        }
    }
}
