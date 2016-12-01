using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RetappGenNHibernate.EN.Retapp;

namespace WebApplication4.Clases
{
    public class Admin
    {
        
        public string usr;


        public string pass;


        public int id;


        public virtual string Usr {
                get { return usr; } set { usr = value;  }
        }



        public virtual string Pass {
                get { return pass; } set { pass = value;  }
        }



        public virtual int Id {
                get { return id; } set { id = value;  }
        }


        public Admin()
        {
        }



        public Admin(int id, string usr, string pass)
        {
                this.init (Id, usr, pass);
        }


        public Admin(Admin admin)
        {
                this.init (Id, admin.Usr, admin.Pass);
        }

        private void init(int id, string usr, string pass)
        {
            this.Id = id;


            this.Usr = usr;

            this.Pass = pass;
        }

        public override bool Equals (object obj)
        {
                if (obj == null)
                        return false;
                Admin t = obj as Admin;
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