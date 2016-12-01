using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication3.Clases
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public class Concurso
    {
        [XmlElement(ElementName = "idConcurso")]
        public int Id { get; set; }

        /**
         *	Atributo fechaFin
         */
        [XmlElement(ElementName = "fechaFin")]
        public DateTime fechaFin { get; set; }



        /**
         *	Atributo aprobado
         */
        [XmlElement(ElementName = "aprobado")]
        public bool aprobado { get; set; }



        /**
         *	Atributo finalizado
         */
        [XmlElement(ElementName = "finalizado")]
        public bool finalizado { get; set; }



        /**
         *	Atributo campaña
         */
        [XmlElement(ElementName = "campanya")]
        public string campanya { get; set; }



        /**
         *	Atributo cuerpo
         */
        [XmlElement(ElementName = "cuerpo")]
        public string cuerpo { get; set; }



        /**
         *	Atributo premios
         */
        [XmlElement(ElementName = "premios")]
        public string premios { get; set; }



        /**
         *	Atributo reto
         */
        [XmlElement(ElementName = "reto")]
        public string reto { get; set; }



        /**
         *	Atributo pos
         */
        [XmlElement(ElementName = "pos")]
        public int pos { get; set; }



        /**
         *	Atributo fechaInicio
         */
        [XmlElement(ElementName = "fechaInicio")]
        public DateTime fechaInicio { get; set; }


        public Concurso()
        {

        }
        
        public Concurso(int id, DateTime fechaFin, bool aprobado, bool finalizado, string campanya, string cuerpo, string premios, string reto, int pos, DateTime fechaInicio)
        {
            this.Id = id;
            this.fechaFin = fechaFin;
            this.aprobado = aprobado;
            this.finalizado = finalizado;
            this.campanya = campanya;
            this.cuerpo = cuerpo;
            this.premios = premios;
            this.reto = reto;
            this.pos = pos;
            this.fechaInicio = fechaInicio;

        }
    }
}