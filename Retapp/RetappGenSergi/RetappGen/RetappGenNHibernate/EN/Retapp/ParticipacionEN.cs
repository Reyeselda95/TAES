
using System;
// Definición clase ParticipacionEN
namespace RetappGenNHibernate.EN.Retapp
{
public partial class ParticipacionEN
{
/**
 *	Atributo concurso
 */
private RetappGenNHibernate.EN.Retapp.ConcursoEN concurso;



/**
 *	Atributo usuario
 */
private RetappGenNHibernate.EN.Retapp.UsuarioEN usuario;



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






public virtual RetappGenNHibernate.EN.Retapp.ConcursoEN Concurso {
        get { return concurso; } set { concurso = value;  }
}



public virtual RetappGenNHibernate.EN.Retapp.UsuarioEN Usuario {
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





public ParticipacionEN()
{
}



public ParticipacionEN(int id, RetappGenNHibernate.EN.Retapp.ConcursoEN concurso, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes
                       )
{
        this.init (Id, concurso, usuario, usuario_0, fecha, valor, prueba, votos, reportes);
}


public ParticipacionEN(ParticipacionEN participacion)
{
        this.init (Id, participacion.Concurso, participacion.Usuario, participacion.Usuario_0, participacion.Fecha, participacion.Valor, participacion.Prueba, participacion.Votos, participacion.Reportes);
}

private void init (int id, RetappGenNHibernate.EN.Retapp.ConcursoEN concurso, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes)
{
        this.Id = id;


        this.Concurso = concurso;

        this.Usuario = usuario;

        this.Usuario_0 = usuario_0;

        this.Fecha = fecha;

        this.Valor = valor;

        this.Prueba = prueba;

        this.Votos = votos;

        this.Reportes = reportes;
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
