
using System;
// Definición clase UsuarioEN
namespace RetappGenNHibernate.EN.Retapp
{
public partial class UsuarioEN
{
/**
 *	Atributo participacionesVotadas
 */
private System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participacionesVotadas;



/**
 *	Atributo participacionesEnviadas
 */
private System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participacionesEnviadas;



/**
 *	Atributo gaccount
 */
private string gaccount;



/**
 *	Atributo tlf
 */
private int tlf;



/**
 *	Atributo fechaBaneado
 */
private Nullable<DateTime> fechaBaneado;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo numBaneos
 */
private int numBaneos;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo baneado
 */
private bool baneado;



/**
 *	Atributo votos
 */
private int votos;



/**
 *	Atributo karma
 */
private float karma;



/**
 *	Atributo codPstal
 */
private int codPstal;



/**
 *	Atributo fechaLogin
 */
private Nullable<DateTime> fechaLogin;



/**
 *	Atributo password
 */
private string password;






public virtual System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> ParticipacionesVotadas {
        get { return participacionesVotadas; } set { participacionesVotadas = value;  }
}



public virtual System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> ParticipacionesEnviadas {
        get { return participacionesEnviadas; } set { participacionesEnviadas = value;  }
}



public virtual string Gaccount {
        get { return gaccount; } set { gaccount = value;  }
}



public virtual int Tlf {
        get { return tlf; } set { tlf = value;  }
}



public virtual Nullable<DateTime> FechaBaneado {
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



public virtual Nullable<DateTime> FechaLogin {
        get { return fechaLogin; } set { fechaLogin = value;  }
}



public virtual string Password {
        get { return password; } set { password = value;  }
}





public UsuarioEN()
{
        ParticipacionesVotadas = new System.Collections.Generic.List<RetappGenNHibernate.EN.Retapp.ParticipacionEN>();
        ParticipacionesEnviadas = new System.Collections.Generic.List<RetappGenNHibernate.EN.Retapp.ParticipacionEN>();
}



public UsuarioEN(string gaccount, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participacionesVotadas, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participacionesEnviadas, int tlf, Nullable<DateTime> fechaBaneado, string nombre, int numBaneos, string direccion, bool baneado, int votos, float karma, int codPstal, Nullable<DateTime> fechaLogin, string password
                 )
{
        this.init (Gaccount, participacionesVotadas, participacionesEnviadas, tlf, fechaBaneado, nombre, numBaneos, direccion, baneado, votos, karma, codPstal, fechaLogin, password);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Gaccount, usuario.ParticipacionesVotadas, usuario.ParticipacionesEnviadas, usuario.Tlf, usuario.FechaBaneado, usuario.Nombre, usuario.NumBaneos, usuario.Direccion, usuario.Baneado, usuario.Votos, usuario.Karma, usuario.CodPstal, usuario.FechaLogin, usuario.Password);
}

private void init (string Gaccount, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participacionesVotadas, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participacionesEnviadas, int tlf, Nullable<DateTime> fechaBaneado, string nombre, int numBaneos, string direccion, bool baneado, int votos, float karma, int codPstal, Nullable<DateTime> fechaLogin, string password)
{
        this.Gaccount = Gaccount;


        this.ParticipacionesVotadas = participacionesVotadas;

        this.ParticipacionesEnviadas = participacionesEnviadas;

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

        this.Password = password;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Gaccount.Equals (t.Gaccount))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Gaccount.GetHashCode ();
        return hash;
}
}
}
