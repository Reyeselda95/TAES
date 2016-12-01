
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



/**
 *	Atributo id
 */
private int id;






public virtual string Usr {
        get { return usr; } set { usr = value;  }
}



public virtual string Pass {
        get { return pass; } set { pass = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public AdminEN()
{
}



public AdminEN(int id, string usr, string pass
               )
{
        this.init (Id, usr, pass);
}


public AdminEN(AdminEN admin)
{
        this.init (Id, admin.Usr, admin.Pass);
}

private void init (int id, string usr, string pass)
{
        this.Id = id;


        this.Usr = usr;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
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
