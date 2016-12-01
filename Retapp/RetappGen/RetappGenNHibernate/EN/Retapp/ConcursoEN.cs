
using System;
// Definición clase ConcursoEN
namespace RetappGenNHibernate.EN.Retapp
{
public partial class ConcursoEN
{
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
 *	Atributo fraseCaracteristica
 */
private string fraseCaracteristica;



/**
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo premios
 */
private string premios;



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



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo compañia
 */
private string compañia;



/**
 *	Atributo retos
 */
private System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.RetoEN> retos;






public virtual Nullable<DateTime> FechaFin {
        get { return fechaFin; } set { fechaFin = value;  }
}



public virtual bool Aprobado {
        get { return aprobado; } set { aprobado = value;  }
}



public virtual bool Finalizado {
        get { return finalizado; } set { finalizado = value;  }
}



public virtual string FraseCaracteristica {
        get { return fraseCaracteristica; } set { fraseCaracteristica = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual string Premios {
        get { return premios; } set { premios = value;  }
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



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual string Compañia {
        get { return compañia; } set { compañia = value;  }
}



public virtual System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.RetoEN> Retos {
        get { return retos; } set { retos = value;  }
}





public ConcursoEN()
{
        retos = new System.Collections.Generic.List<RetappGenNHibernate.EN.Retapp.RetoEN>();
}



public ConcursoEN(int id, Nullable<DateTime> fechaFin, bool aprobado, bool finalizado, string fraseCaracteristica, string cuerpo, string premios, int pos, Nullable<DateTime> fechaInicio, string imagen, string compañia, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.RetoEN> retos
                  )
{
        this.init (Id, fechaFin, aprobado, finalizado, fraseCaracteristica, cuerpo, premios, pos, fechaInicio, imagen, compañia, retos);
}


public ConcursoEN(ConcursoEN concurso)
{
        this.init (Id, concurso.FechaFin, concurso.Aprobado, concurso.Finalizado, concurso.FraseCaracteristica, concurso.Cuerpo, concurso.Premios, concurso.Pos, concurso.FechaInicio, concurso.Imagen, concurso.Compañia, concurso.Retos);
}

private void init (int id, Nullable<DateTime> fechaFin, bool aprobado, bool finalizado, string fraseCaracteristica, string cuerpo, string premios, int pos, Nullable<DateTime> fechaInicio, string imagen, string compañia, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.RetoEN> retos)
{
        this.Id = id;


        this.FechaFin = fechaFin;

        this.Aprobado = aprobado;

        this.Finalizado = finalizado;

        this.FraseCaracteristica = fraseCaracteristica;

        this.Cuerpo = cuerpo;

        this.Premios = premios;

        this.Pos = pos;

        this.FechaInicio = fechaInicio;

        this.Imagen = imagen;

        this.Compañia = compañia;

        this.Retos = retos;
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
