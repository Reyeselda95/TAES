using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RetappGenNHibernate.EN.Retapp;

namespace WebApplication4.Clases
{
    public class Participacion
    {

        /**
         *	Atributo concurso
         */
        private RetappGenNHibernate.EN.Retapp.RetoEN reto;


       
        /**
         *	Atributo usuario
         */
        //private RetappGenNHibernate.EN.Retapp.UsuarioEN usuario;

        /**
         *	Atributo usuario_0
         */
        private RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0;



        public Nullable<DateTime> fecha;



        public float valor;



        public string prueba;



        public int votos;



        public int reportes;



        public int id;






        public virtual RetappGenNHibernate.EN.Retapp.RetoEN Reto {
                get { return reto; } set { reto = value;  }
        }


        /*
        public virtual RetappGenNHibernate.EN.Retapp.UsuarioEN Usuario {
                get { return usuario; } set { usuario = value;  }
        }
        */


        public virtual RetappGenNHibernate.EN.Retapp.UsuarioEN Usuario_0 {
                get { return usuario_0; } set { usuario_0 = value;  }
        }



        public virtual Nullable<DateTime> Fecha {
                get { return fecha; } set { fecha = value;  }
        }



        public virtual float Valor {
                get { return valor; } set { valor = value;  }
        }



        public virtual string Prueba {
                get { return prueba; } set { prueba = value;  }
        }



        public virtual int Votos {
                get { return votos; } set { votos = value;  }
        }



        public virtual int Reportes {
                get { return reportes; } set { reportes = value;  }
        }



        public virtual int Id {
                get { return id; } set { id = value;  }
        }





        public Participacion()
        {
        }

        public Participacion(ParticipacionEN p)
        {
            this.reto = p.Reto;
            this.fecha = p.Fecha;
            this.id = p.Id;
            this.prueba = p.Prueba;
            this.reportes = p.Reportes;
            this.usuario_0 = p.Usuario_0;
            this.valor = p.Valor;
            this.votos = p.Votos;


        }


        /*
        public Participacion(int id, RetappGenNHibernate.EN.Retapp.ConcursoEN concurso, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes)
        {
                this.init (Id, concurso, usuario, usuario_0, fecha, valor, prueba, votos, reportes);
        }
        */

        public Participacion(Participacion participacion)
        {
                this.init (Id, participacion.Reto, participacion.Usuario_0, participacion.Fecha, participacion.Valor, participacion.Prueba, participacion.Votos, participacion.Reportes);
        }

        private void init (int id, RetappGenNHibernate.EN.Retapp.RetoEN reto, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes)
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

            this.Reto = participacion.Reto;

            
            this.Usuario_0 = participacion.Usuario_0;

            this.Fecha = participacion.Fecha;

            this.Valor = participacion.Valor;

            this.Prueba = participacion.Prueba;

            this.Votos = participacion.Votos;

            this.Reportes = participacion.Reportes;
        }

        public override bool Equals (object obj)
        {
                if (obj == null)
                        return false;
                Participacion t = obj as Participacion;
                if (t == null)
                        return false;
                if (Id.Equals (t.Id))
                        return true;
                else
                        return false;
        }

        public override int GetHashCode ()
        {
                int hash = 13;

                hash += this.Id.GetHashCode ();
                return hash;
        }
    }
}