
using System;
// Definición clase VictoriaEN
namespace RetappGenNHibernate.EN.Retapp
{
public partial class VictoriaEN                                                                     : RetappGenNHibernate.EN.Retapp.ParticipacionEN


{
/**
 *	Atributo pos
 */
private int pos;



/**
 *	Atributo premio
 */
private string premio;






public virtual int Pos {
        get { return pos; } set { pos = value;  }
}



public virtual string Premio {
        get { return premio; } set { premio = value;  }
}





public VictoriaEN() : base ()
{
}



public VictoriaEN(int id, int pos, string premio
                  , System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.UsuarioEN> usuario, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes, RetappGenNHibernate.EN.Retapp.RetoEN reto
                  )
{
        this.init (Id, pos, premio, usuario, usuario_0, fecha, valor, prueba, votos, reportes, reto);
}


public VictoriaEN(VictoriaEN victoria)
{
        this.init (Id, victoria.Pos, victoria.Premio, victoria.Usuario, victoria.Usuario_0, victoria.Fecha, victoria.Valor, victoria.Prueba, victoria.Votos, victoria.Reportes, victoria.Reto);
}

private void init (int id, int pos, string premio, System.Collections.Generic.IList<RetappGenNHibernate.EN.Retapp.UsuarioEN> usuario, RetappGenNHibernate.EN.Retapp.UsuarioEN usuario_0, Nullable<DateTime> fecha, float valor, string prueba, int votos, int reportes, RetappGenNHibernate.EN.Retapp.RetoEN reto)
{
        this.Id = id;


        this.Pos = pos;

        this.Premio = premio;

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
