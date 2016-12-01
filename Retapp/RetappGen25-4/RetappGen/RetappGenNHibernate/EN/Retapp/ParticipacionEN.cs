
using System;
// Definición clase ParticipacionEN
namespace RetappGenNHibernate.EN.Retapp
{
public partial class ParticipacionEN
{
/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.UsuarioEN> usuario;



/**
 *	Atributo usuario_0
 */
private RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo valor
 */
private float valor;



/**
 *	Atributo prueba
 */
private string prueba;



/**
 *	Atributo votos
 */
private int votos;



/**
 *	Atributo reportes
 */
private int reportes;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo reto
 */
private RetappGenNHibernate.EN.Retapp.RetoEN reto;






public virtual System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



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



public virtual RetappGenNHibernate.EN.Retapp.RetoEN Reto {
        get { return reto; } set { reto = value;  }
}





public ParticipacionEN()
{
        usuario = new System.Collections.Generic.List<RetappGenNHibernate.EN.Retapp.UsuarioEN>();
}



public ParticipacionEN(int id, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.UsuarioEN> usuario, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes, RetappGenNHibernate.EN.Retapp.RetoEN reto
                       )
{
        this.init (Id, usuario, usuario_0, fecha, valor, prueba, votos, reportes, reto);
}


public ParticipacionEN(ParticipacionEN participacion)
{
        this.init (Id, participacion.Usuario, participacion.Usuario_0, participacion.Fecha, participacion.Valor, participacion.Prueba, participacion.Votos, participacion.Reportes, participacion.Reto);
}

private void init (int id, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.UsuarioEN> usuario, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes, RetappGenNHibernate.EN.Retapp.RetoEN reto)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Usuario_0 = usuario_0;

        this.Fecha = fecha;

        this.Valor = valor;

        this.Prueba = prueba;

        this.Votos = votos;

        this.Reportes = reportes;

        this.Reto = reto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ParticipacionEN t = obj as ParticipacionEN;
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
