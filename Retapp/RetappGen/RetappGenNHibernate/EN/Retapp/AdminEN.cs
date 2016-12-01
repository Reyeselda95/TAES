
using System;
// Definición clase AdminEN
namespace RetappGenNHibernate.EN.Retapp
{
public partial class AdminEN
{
/**
 *	Atributo usr
 */
private string usr;



/**
 *	Atributo pass
 */
private string pass;






public virtual string Usr {
        get { return usr; } set { usr = value;  }
}



public virtual string Pass {
        get { return pass; } set { pass = value;  }
}





public AdminEN()
{
}



public AdminEN(string usr, string pass
               )
{
        this.init (Usr, pass);
}


public AdminEN(AdminEN admin)
{
        this.init (Usr, admin.Pass);
}

private void init (string Usr, string pass)
{
        this.Usr = Usr;


        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Usr.Equals (t.Usr))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Usr.GetHashCode ();
        return hash;
}
}
}
