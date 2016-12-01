

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using RetappGenNHibernate.EN.Retapp;
using RetappGenNHibernate.CAD.Retapp;

namespace RetappGenNHibernate.CEN.Retapp
{
/*
 *      Definition of the class VictoriaCEN
 *
 */
public partial class VictoriaCEN
{
private IVictoriaCAD _IVictoriaCAD;

public VictoriaCEN()
{
        this._IVictoriaCAD = new VictoriaCAD ();
}

public VictoriaCEN(IVictoriaCAD _IVictoriaCAD)
{
        this._IVictoriaCAD = _IVictoriaCAD;
}

public IVictoriaCAD get_IVictoriaCAD ()
{
        return this._IVictoriaCAD;
}

public VictoriaEN ReadOID (int id)
{
        VictoriaEN victoriaEN = null;

        victoriaEN = _IVictoriaCAD.ReadOID (id);
        return victoriaEN;
}

public System.Collections.Generic.IList<VictoriaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VictoriaEN> list = null;

        list = _IVictoriaCAD.ReadAll (first, size);
        return list;
}
public void Modify (int p_Victoria_OID, Nullable<DateTime> p_Fecha, float p_Valor, int p_Votos, int p_Reportes, int p_Pos, string p_Premio)
{
        VictoriaEN victoriaEN = null;

        //Initialized VictoriaEN
        victoriaEN = new VictoriaEN ();
        victoriaEN.Id = p_Victoria_OID;
        victoriaEN.Fecha = p_Fecha;
        victoriaEN.Valor = p_Valor;
        victoriaEN.Votos = p_Votos;
        victoriaEN.Reportes = p_Reportes;
        victoriaEN.Pos = p_Pos;
        victoriaEN.Premio = p_Premio;
        //Call to VictoriaCAD

        _IVictoriaCAD.Modify (victoriaEN);
}

public void Destroy (int id)
{
        _IVictoriaCAD.Destroy (id);
}

public int New_ (string p_usuario_0, Nullable<DateTime> p_Fecha, float p_Valor, int p_Votos, int p_Reportes, int p_reto, int p_Pos, string p_Premio)
{
        VictoriaEN victoriaEN = null;
        int oid;

        //Initialized VictoriaEN
        victoriaEN = new VictoriaEN ();

        if (p_usuario_0 != null) {
                // El argumento p_usuario_0 -> Property usuario_0 es oid = false
                // Lista de oids id
                victoriaEN.Usuario_0 = new RetappGenNHibernate.EN.Retapp.UsuarioEN ();
                victoriaEN.Usuario_0.Gaccount = p_usuario_0;
        }

        victoriaEN.Fecha = p_Fecha;

        victoriaEN.Valor = p_Valor;

        victoriaEN.Votos = p_Votos;

        victoriaEN.Reportes = p_Reportes;


        if (p_reto != -1) {
                // El argumento p_reto -> Property reto es oid = false
                // Lista de oids id
                victoriaEN.Reto = new RetappGenNHibernate.EN.Retapp.RetoEN ();
                victoriaEN.Reto.Id = p_reto;
        }

        victoriaEN.Pos = p_Pos;

        victoriaEN.Premio = p_Premio;

        //Call to VictoriaCAD

        oid = _IVictoriaCAD.New_ (victoriaEN);
        return oid;
}
}
}
