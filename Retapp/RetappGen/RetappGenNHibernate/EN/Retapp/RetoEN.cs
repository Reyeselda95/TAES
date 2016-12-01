
using System;
// Definición clase RetoEN
namespace RetappGenNHibernate.EN.Retapp
{
public partial class RetoEN
{
/**
 *	Atributo concurso
 */
private RetappGenNHibernate.EN.Retapp.ConcursoEN concurso;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo fechaFin
 */
private Nullable<DateTime> fechaFin;



/**
 *	Atributo active
 */
private bool active;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo participacion
 */
private System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participacion;






public virtual RetappGenNHibernate.EN.Retapp.ConcursoEN Concurso {
        get { return concurso; } set { concurso = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Nullable<DateTime> FechaFin {
        get { return fechaFin; } set { fechaFin = value;  }
}



public virtual bool Active {
        get { return active; } set { active = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> Participacion {
        get { return participacion; } set { participacion = value;  }
}





public RetoEN()
{
        participacion = new System.Collections.Generic.List<RetappGenNHibernate.EN.Retapp.ParticipacionEN>();
}



public RetoEN(int id, RetappGenNHibernate.EN.Retapp.ConcursoEN concurso, string nombre, string descripcion, Nullable<DateTime> fechaFin, bool active, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participacion
              )
{
        this.init (Id, concurso, nombre, descripcion, fechaFin, active, participacion);
}


public RetoEN(RetoEN reto)
{
        this.init (Id, reto.Concurso, reto.Nombre, reto.Descripcion, reto.FechaFin, reto.Active, reto.Participacion);
}

private void init (int id, RetappGenNHibernate.EN.Retapp.ConcursoEN concurso, string nombre, string descripcion, Nullable<DateTime> fechaFin, bool active, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.ParticipacionEN> participacion)
{
        this.Id = id;


        this.Concurso = concurso;

        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.FechaFin = fechaFin;

        this.Active = active;

        this.Participacion = participacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RetoEN t = obj as RetoEN;
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
