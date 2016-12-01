using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RetappGenNHibernate.EN.Retapp;

namespace WebApplication4.Clases
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public class Usuario
    {

        
        public string gaccount { get; set; }


        public int tlf { get; set; }


        public Nullable<DateTime> fechaBaneado { get; set; }


        public string nombre { get; set; }


        public int numBaneos { get; set; }


        public string direccion { get; set; }


        public bool baneado { get; set; }


        public int votos { get; set; }


        public float karma { get; set; }


        public int codPstal { get; set; }


        public Nullable<DateTime> fechaLogin { get; set; }


        public string password { get; set; }

        /*
        public virtual string Gaccount {
                get { return gaccount; } set { gaccount = value;  }
        }



        public virtual int Tlf {
                get { return tlf; } set { tlf = value;  }
        }



        public virtual DateTime FechaBaneado {
                get { return fechaBaneado; } set { fechaBaneado = value;  }
        }



        public virtual string Nombre {
                get { return nombre; } set { nombre = value;  }
        }



        public virtual int NumBaneos {
                get { return numBaneos; } set { numBaneos = value;  }
        }



        public virtual string Direccion {
                get { return direccion; } set { direccion = value;  }
        }



        public virtual bool Baneado {
                get { return baneado; } set { baneado = value;  }
        }



        public virtual int Votos {
                get { return votos; } set { votos = value;  }
        }



        public virtual float Karma {
                get { return karma; } set { karma = value;  }
        }



        public virtual int CodPstal {
                get { return codPstal; } set { codPstal = value;  }
        }



        public virtual DateTime FechaLogin {
                get { return fechaLogin; } set { fechaLogin = value;  }
        }



        public virtual int Id {
                get { return Id; } set { Id = value;  }
        }
        */


        public Usuario()
        {
            /*
                victoria = new Victoria();
                ParticipacionesVotadas = new Participacion();
                ParticipacionesEnviadas = new Participacion();
             * */
        }

        /*

        public Usuario(int id, string gaccount, int tlf, DateTime fechaBaneado, string nombre, int numBaneos, string direccion, bool baneado, int votos, float karma, int codPstal, DateTime fechaLogin)
        {
                this.init (id, gaccount, tlf, fechaBaneado, nombre, numBaneos, direccion, baneado, votos, karma, codPstal, fechaLogin);
        }

        */
        public Usuario(UsuarioEN usuario)
        {

            this.gaccount = usuario.Gaccount;
            this.tlf = usuario.Tlf;
            this.fechaBaneado = usuario.FechaBaneado;
            this.nombre = usuario.Nombre;
            this.numBaneos = usuario.NumBaneos;
            this.direccion = usuario.Direccion;
            this.baneado = usuario.Baneado;
            this.votos = usuario.Votos;
            this.karma = usuario.Karma;
            this.codPstal = usuario.CodPstal;
            this.fechaLogin = usuario.FechaLogin;
            this.password = usuario.Password;
        }

        /*
        private void init (int id, Victoria victoria, Participacion participacionesVotadas, Participacion participacionesEnviadas, string gaccount, int tlf, DateTime fechaBaneado, string nombre, int numBaneos, string direccion, bool baneado, int votos, float karma, int codPstal, DateTime fechaLogin)
        {
                this.Id = id;


                this.Victoria = victoria;

                this.ParticipacionesVotadas = participacionesVotadas;

                this.ParticipacionesEnviadas = participacionesEnviadas;

                this.Gaccount = gaccount;

                this.Tlf = tlf;

                this.FechaBaneado = fechaBaneado;

                this.Nombre = nombre;

                this.NumBaneos = numBaneos;

                this.Direccion = direccion;

                this.Baneado = baneado;

                this.Votos = votos;

                this.Karma = karma;

                this.CodPstal = codPstal;

                this.FechaLogin = fechaLogin;
        }

        
    */
       
    }
}