using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using RetappGenNHibernate.EN.Retapp;

namespace WebApplication4.Clases
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://retapp.org/")]
    public class Concurso
    {
        [XmlElement(ElementName = "idConcurso")]
        public int Id { get; set; }

        /**
         *	Atributo fechaFin
         */
        [XmlElement(ElementName = "FechaFin")]
        public Nullable<DateTime> fechaFin { get; set; }



        /**
         *	Atributo aprobado
         */
        [XmlElement(ElementName = "Aprobado")]
        public bool aprobado { get; set; }



        /**
         *	Atributo finalizado
         */
        [XmlElement(ElementName = "Finalizado")]
        public bool finalizado { get; set; }



        /**
         *	Atributo campaña
         */
        [XmlElement(ElementName = "FraseCaracteristica")]
        public string FraseCaracterizacion { get; set; }



        /**
         *	Atributo cuerpo
         */
        [XmlElement(ElementName = "Cuerpo")]
        public string cuerpo { get; set; }



        /**
         *	Atributo premios
         */
        [XmlElement(ElementName = "premios")]
        public string premios { get; set; }



        /**
         *	Atributo pos
         */
        [XmlElement(ElementName = "pos")]
        public int pos { get; set; }



        /**
         *	Atributo fechaInicio
         */
        [XmlElement(ElementName = "fechaInicio")]
        public Nullable<DateTime> fechaInicio { get; set; }


        /**
         *	Atributo fechaInicio
         */
        [XmlElement(ElementName = "imagen")]
        public string imagen { get; set; }


        /**
         *	Atributo fechaInicio
         */
        [XmlElement(ElementName = "compañia")]
        public string compañia { get; set; }

        public Concurso()
        {

        }
        
        public Concurso(int id, Nullable<DateTime> fechaFin, bool aprobado, bool finalizado, string frase, string cuerpo, string premios, int pos, Nullable<DateTime> fechaInicio, string ima, string comp)
        {
            this.Id = id;
            this.fechaFin = fechaFin;
            this.aprobado = aprobado;
            this.finalizado = finalizado;
            this.FraseCaracterizacion = frase;
            this.cuerpo = cuerpo;
            this.premios = premios;
            this.pos = pos;
            this.fechaInicio = fechaInicio;
            this.imagen = ima;
            this.compañia = comp;

        }

        public Concurso(ConcursoEN concursoEN)
        {
            this.Id = concursoEN.Id;
            this.fechaFin = concursoEN.FechaFin;
            this.aprobado = concursoEN.Aprobado;
            this.finalizado = concursoEN.Finalizado;
            this.FraseCaracterizacion = concursoEN.FraseCaracteristica;
            this.cuerpo = concursoEN.Cuerpo;
            this.premios = concursoEN.Premios;
            this.imagen = concursoEN.Imagen;
            this.compañia = concursoEN.Compañia;
            this.pos = concursoEN.Pos;
            this.fechaInicio = concursoEN.FechaInicio;

        }

    }
}