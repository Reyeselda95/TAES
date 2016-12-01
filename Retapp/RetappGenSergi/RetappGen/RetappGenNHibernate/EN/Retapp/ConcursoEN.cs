
using System;
// Definición clase ConcursoEN
namespace RetappGenNHibernate.EN.Retapp
{
    public partial class ConcursoEN : RetappGenNHibernate.EN.Retapp.UsuarioEN
{
/**
 *	Atributo victoria
 */
private System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.VictoriaEN> victoria;



/**
 *	Atributo participaciones
 */
private System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participaciones;



/**
 *	Atributo fechaFin
 */
private Nullable<DateTime> fechaFin;



/**
 *	Atributo aprobado
 */
private bool aprobado;



/**
 *	Atributo finalizado
 */
private bool finalizado;



/**
 *	Atributo campaña
 */
private string campaña;



/**
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo premios
 */
private string premios;



/**
 *	Atributo reto
 */
private string reto;



/**
 *	Atributo pos
 */
private int pos;



/**
 *	Atributo fechaInicio
 */
private Nullable<DateTime> fechaInicio;



/**
 *	Atributo id
 */
private int id;






public virtual System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.VictoriaEN> Victoria {
        get { return victoria; } set { victoria = value;  }
}



public virtual System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> Participaciones {
        get { return participaciones; } set { participaciones = value;  }
}



public virtual Nullable<DateTime> FechaFin {
        get { return fechaFin; } set { fechaFin = value;  }
}



public virtual bool Aprobado {
        get { return aprobado; } set { aprobado = value;  }
}



public virtual bool Finalizado {
        get { return finalizado; } set { finalizado = value;  }
}



public virtual string Campaña {
        get { return campaña; } set { campaña = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual string Premios {
        get { return premios; } set { premios = value;  }
}



public virtual string Reto {
        get { return reto; } set { reto = value;  }
}



public virtual int Pos {
        get { return pos; } set { pos = value;  }
}



public virtual Nullable<DateTime> FechaInicio {
        get { return fechaInicio; } set { fechaInicio = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public ConcursoEN()
{
        victoria = new System.Collections.Generic.List<RetappGenNHibernate.EN.Retapp.VictoriaEN>();
        Participaciones = new System.Collections.Generic.List<RetappGenNHibernate.EN.Retapp.ParticipacionEN>();
}

public ConcursoEN(int id, string nombre)
{
    this.Id = id;
    this.Nombre = nombre;
}

public ConcursoEN(int id, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.VictoriaEN> victoria, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participaciones, Nullable<DateTime> fechaFin, bool aprobado, bool finalizado, string campaña, string cuerpo, string premios, string reto, int pos, Nullable<DateTime> fechaInicio
                  )
{
        this.init (Id, victoria, participaciones, fechaFin, aprobado, finalizado, campaña, cuerpo, premios, reto, pos, fechaInicio);
}


public ConcursoEN(ConcursoEN concurso)
{
        this.init (Id, concurso.Victoria, concurso.Participaciones, concurso.FechaFin, concurso.Aprobado, concurso.Finalizado, concurso.Campaña, concurso.Cuerpo, concurso.Premios, concurso.Reto, concurso.Pos, concurso.FechaInicio);
}

private void init (int id, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.VictoriaEN> victoria, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participaciones, Nullable<DateTime> fechaFin, bool aprobado, bool finalizado, string campaña, string cuerpo, string premios, string reto, int pos, Nullable<DateTime> fechaInicio)
{
        this.Id = id;


        this.Victoria = victoria;

        this.Participaciones = participaciones;

        this.FechaFin = fechaFin;

        this.Aprobado = aprobado;

        this.Finalizado = finalizado;

        this.Campaña = campaña;

        this.Cuerpo = cuerpo;

        this.Premios = premios;

        this.Reto = reto;

        this.Pos = pos;

        this.FechaInicio = fechaInicio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ConcursoEN t = obj as ConcursoEN;
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
