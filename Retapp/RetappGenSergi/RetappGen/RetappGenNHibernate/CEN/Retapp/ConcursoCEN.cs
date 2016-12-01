

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
 *      Definition of the class ConcursoCEN
 *
 */
public partial class ConcursoCEN
{
private IConcursoCAD _IConcursoCAD;

public ConcursoCEN()
{
        this._IConcursoCAD = new ConcursoCAD ();
}

public ConcursoCEN(IConcursoCAD _IConcursoCAD)
{
        this._IConcursoCAD = _IConcursoCAD;
}

public IConcursoCAD get_IConcursoCAD ()
{
        return this._IConcursoCAD;
}

public int New_ (Nullable<DateTime> p_FechaFin, bool p_Aprobado, bool p_Finalizado, string p_Campaña, string p_Cuerpo, string p_Premios, string p_Reto, int p_Pos, Nullable<DateTime> p_FechaInicio)
{
        ConcursoEN concursoEN = null;
        int oid;

        //Initialized ConcursoEN
        concursoEN = new ConcursoEN ();
        concursoEN.FechaFin = p_FechaFin;

        concursoEN.Aprobado = p_Aprobado;

        concursoEN.Finalizado = p_Finalizado;

        concursoEN.Campaña = p_Campaña;

        concursoEN.Cuerpo = p_Cuerpo;

        concursoEN.Premios = p_Premios;

        concursoEN.Reto = p_Reto;

        concursoEN.Pos = p_Pos;

        concursoEN.FechaInicio = p_FechaInicio;

        //Call to ConcursoCAD

        oid = _IConcursoCAD.New_ (concursoEN);
        return oid;
}

public void Modify (int p_Concurso_OID, Nullable<DateTime> p_FechaFin, bool p_Aprobado, bool p_Finalizado, string p_Campaña, string p_Cuerpo, string p_Premios, string p_Reto, int p_Pos, Nullable<DateTime> p_FechaInicio)
{
        ConcursoEN concursoEN = null;

        //Initialized ConcursoEN
        concursoEN = new ConcursoEN ();
        concursoEN.Id = p_Concurso_OID;
        concursoEN.FechaFin = p_FechaFin;
        concursoEN.Aprobado = p_Aprobado;
        concursoEN.Finalizado = p_Finalizado;
        concursoEN.Campaña = p_Campaña;
        concursoEN.Cuerpo = p_Cuerpo;
        concursoEN.Premios = p_Premios;
        concursoEN.Reto = p_Reto;
        concursoEN.Pos = p_Pos;
        concursoEN.FechaInicio = p_FechaInicio;
        //Call to ConcursoCAD

        _IConcursoCAD.Modify (concursoEN);
}

public void Destroy (int id)
{
        _IConcursoCAD.Destroy (id);
}

public ConcursoEN ReadOID (int id)
{
        ConcursoEN concursoEN = null;

        concursoEN = _IConcursoCAD.ReadOID (id);
        return concursoEN;
}

public System.Collections.Generic.IList<ConcursoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ConcursoEN> list = null;

        list = _IConcursoCAD.ReadAll (first, size);
        return list;
}
}
}
