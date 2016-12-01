
using System;
// Definición clase VictoriaEN
namespace RetappGenNHibernate.EN.Retapp
{
public partial class VictoriaEN                                                                     : RetappGenNHibernate.EN.Retapp.ParticipacionEN


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
 *	Atributo pos
 */
private int pos;



/**
 *	Atributo premio
 */
private string premio;






public virtual RetappGenNHibernate.EN.Retapp.ConcursoEN Concurso {
        get { return concurso; } set { concurso = value;  }
}



public virtual RetappGenNHibernate.EN.Retapp.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual int Pos {
        get { return pos; } set { pos = value;  }
}



public virtual string Premio {
        get { return premio; } set { premio = value;  }
}





public VictoriaEN() : base ()
{
}



public VictoriaEN(int id, RetappGenNHibernate.EN.Retapp.ConcursoEN concurso, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario, int pos, string premio
                  , RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes
                  )
{
        this.init (Id, concurso, usuario, pos, premio, usuario_0, fecha, valor, prueba, votos, reportes);
}


public VictoriaEN(VictoriaEN victoria)
{
        this.init (Id, victoria.Concurso, victoria.Usuario, victoria.Pos, victoria.Premio, victoria.Usuario_0, victoria.Fecha, victoria.Valor, victoria.Prueba, victoria.Votos, victoria.Reportes);
}

private void init (int id, RetappGenNHibernate.EN.Retapp.ConcursoEN concurso, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario, int pos, string premio, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes)
{
        this.Id = id;


        this.Concurso = concurso;

        this.Usuario = usuario;

        this.Pos = pos;

        this.Premio = premio;

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
        VictoriaEN t = obj as VictoriaEN;
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
