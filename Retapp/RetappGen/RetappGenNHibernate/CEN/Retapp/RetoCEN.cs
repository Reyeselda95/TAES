

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
 *      Definition of the class RetoCEN
 *
 */
public partial class RetoCEN
{
private IRetoCAD _IRetoCAD;

public RetoCEN()
{
        this._IRetoCAD = new RetoCAD ();
}

public RetoCEN(IRetoCAD _IRetoCAD)
{
        this._IRetoCAD = _IRetoCAD;
}

public IRetoCAD get_IRetoCAD ()
{
        return this._IRetoCAD;
}

public int New_ (int p_concurso, string p_Nombre, string p_Descripcion, Nullable<DateTime> p_FechaFin, bool p_Active)
{
        RetoEN retoEN = null;
        int oid;

        //Initialized RetoEN
        retoEN = new RetoEN ();

        if (p_concurso != -1) {
                // El argumento p_concurso -> Property concurso es oid = false
                // Lista de oids id
                retoEN.Concurso = new RetappGenNHibernate.EN.Retapp.ConcursoEN ();
                retoEN.Concurso.Id = p_concurso;
        }

        retoEN.Nombre = p_Nombre;

        retoEN.Descripcion = p_Descripcion;

        retoEN.FechaFin = p_FechaFin;

        retoEN.Active = p_Active;

        //Call to RetoCAD

        oid = _IRetoCAD.New_ (retoEN);
        return oid;
}

public void Modify (int p_Reto_OID, string p_Nombre, string p_Descripcion, Nullable<DateTime> p_FechaFin, bool p_Active)
{
        RetoEN retoEN = null;

        //Initialized RetoEN
        retoEN = new RetoEN ();
        retoEN.Id = p_Reto_OID;
        retoEN.Nombre = p_Nombre;
        retoEN.Descripcion = p_Descripcion;
        retoEN.FechaFin = p_FechaFin;
        retoEN.Active = p_Active;
        //Call to RetoCAD

        _IRetoCAD.Modify (retoEN);
}

public void Destroy (int id)
{
        _IRetoCAD.Destroy (id);
}

public RetoEN ReadOID (int id)
{
        RetoEN retoEN = null;

        retoEN = _IRetoCAD.ReadOID (id);
        return retoEN;
}

public System.Collections.Generic.IList<RetoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RetoEN> list = null;

        list = _IRetoCAD.ReadAll (first, size);
        return list;
}
}
}
