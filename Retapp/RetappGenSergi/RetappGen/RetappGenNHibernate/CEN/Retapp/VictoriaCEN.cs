

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

public int New_ (int p_concurso, int p_usuario, int p_usuario_0, Nullable<DateTime> p_Fecha, float p_Valor, string p_Prueba, int p_Votos, int p_Reportes, int p_Pos, string p_Premio)
{
        VictoriaEN victoriaEN = null;
        int oid;

        //Initialized VictoriaEN
        victoriaEN = new VictoriaEN ();

        if (p_concurso != -1) {
                // El argumento p_concurso -> Property concurso es oid = false
                // Lista de oids id
                victoriaEN.Concurso = new RetappGenNHibernate.EN.Retapp.ConcursoEN ();
                victoriaEN.Concurso.Id = p_concurso;
        }


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                victoriaEN.Usuario = new RetappGenNHibernate.EN.Retapp.UsuarioEN ();
                victoriaEN.Usuario.Id = p_usuario;
        }


        if (p_usuario_0 != -1) {
                // El argumento p_usuario_0 -> Property usuario_0 es oid = false
                // Lista de oids id
                victoriaEN.Usuario_0 = new RetappGenNHibernate.EN.Retapp.UsuarioEN ();
                victoriaEN.Usuario_0.Id = p_usuario_0;
        }

        victoriaEN.Fecha = p_Fecha;

        victoriaEN.Valor = p_Valor;

        victoriaEN.Prueba = p_Prueba;

        victoriaEN.Votos = p_Votos;

        victoriaEN.Reportes = p_Reportes;


        victoriaEN.Pos = p_Pos;

        victoriaEN.Premio = p_Premio;

        //Call to VictoriaCAD

        oid = _IVictoriaCAD.New_ (victoriaEN);
        return oid;
}

public void Modify (int p_Victoria_OID, Nullable<DateTime> p_Fecha, float p_Valor, string p_Prueba, int p_Votos, int p_Reportes, int p_Pos, string p_Premio)
{
        VictoriaEN victoriaEN = null;

        //Initialized VictoriaEN
        victoriaEN = new VictoriaEN ();
        victoriaEN.Id = p_Victoria_OID;
        victoriaEN.Fecha = p_Fecha;
        victoriaEN.Valor = p_Valor;
        victoriaEN.Prueba = p_Prueba;
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
}
}
