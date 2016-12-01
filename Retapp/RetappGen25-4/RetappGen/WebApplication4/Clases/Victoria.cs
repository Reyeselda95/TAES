using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RetappGenNHibernate.EN.Retapp;

namespace WebApplication4.Clases
{
    public class Victoria
    {
        /**
         *	Atributo concurso
         */
        private RetappGenNHibernate.EN.Retapp.ConcursoEN concurso;



        /**
         *	Atributo usuario
         */
        private RetappGenNHibernate.EN.Retapp.UsuarioEN usuario;

        
        public int id;

        
        public int pos;


        public string premio;


        public virtual RetappGenNHibernate.EN.Retapp.ConcursoEN Concurso {
                get { return concurso; } set { concurso = value;  }
        }



        public virtual RetappGenNHibernate.EN.Retapp.UsuarioEN Usuario {
                get { return usuario; } set { usuario = value;  }
        }



        public virtual int Pos {
                get { return pos; } set { pos = value;  }
        }



        public virtual string Premio {
                get { return premio; } set { premio = value;  }
        }





        public Victoria() : base ()
        {
        }


        /*
        public Victoria(int id, RetappGenNHibernate.EN.Retapp.ConcursoEN concurso, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario, int pos, string premio, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes)
        {
                this.init (id, concurso, usuario, pos, premio, usuario_0, fecha, valor, prueba, votos, reportes);
        }


        public Victoria(Victoria victoria)
        {
                this.init (victoria.id, victoria.Concurso, victoria.Usuario, victoria.Pos, victoria.Premio, victoria.Usuario_0, victoria.Fecha, victoria.Valor, victoria.Prueba, victoria.Votos, victoria.Reportes);
        }
         * */

        /*
        private void init (int id, RetappGenNHibernate.EN.Retapp.ConcursoEN concurso, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario, int pos, string premio, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes)
        {
                this.id = id;


                this.Concurso = concurso;

                this.Usuario = usuario;

                this.Pos = pos;

                this.Premio = premio;

                this.Usuario_0 = usuario_0;

                this.Fecha = fecha;

                this.Valor = valor;

                this.Prueba = prueba;

                this.Votos = votos;

                this.Reportes = reportes;
        }
         * */

        public override bool Equals (object obj)
        {
                if (obj == null)
                        return false;
                Victoria t = obj as Victoria;
                if (t == null)
                        return false;
                if (id.Equals (t.id))
                        return true;
                else
                        return false;
        }

        public override int GetHashCode ()
        {
                int hash = 13;

                hash += this.id.GetHashCode ();
                return hash;
        }
    }
}