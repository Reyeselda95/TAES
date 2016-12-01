
using System;
using System.Text;
using RetappGenNHibernate.CEN.Retapp;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using RetappGenNHibernate.EN.Retapp;
using RetappGenNHibernate.Exceptions;

/*
 * Clase Concurso:
 *
 */

namespace RetappGenNHibernate.CAD.Retapp
{
public partial class ConcursoCAD : BasicCAD, IConcursoCAD
{
public ConcursoCAD() : base ()
{
}

public ConcursoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ConcursoEN ReadOIDDefault (int id)
{
        ConcursoEN concursoEN = null;

        try
        {
                SessionInitializeTransaction ();
                concursoEN = (ConcursoEN)session.Get (typeof(ConcursoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ConcursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return concursoEN;
}

public System.Collections.Generic.IList<ConcursoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ConcursoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ConcursoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ConcursoEN>();
                        else
                                result = session.CreateCriteria (typeof(ConcursoEN)).List<ConcursoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ConcursoCAD.", ex);
        }

        return result;
}

public int New_ (ConcursoEN concurso)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (concurso);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ConcursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return concurso.Id;
}

public void Modify (ConcursoEN concurso)
{
        try
        {
                SessionInitializeTransaction ();
                ConcursoEN concursoEN = (ConcursoEN)session.Load (typeof(ConcursoEN), concurso.Id);

                concursoEN.FechaFin = concurso.FechaFin;


                concursoEN.Aprobado = concurso.Aprobado;


                concursoEN.Finalizado = concurso.Finalizado;


                concursoEN.FraseCaracteristica = concurso.FraseCaracteristica;


                concursoEN.Cuerpo = concurso.Cuerpo;


                concursoEN.Premios = concurso.Premios;


                concursoEN.Pos = concurso.Pos;


                concursoEN.FechaInicio = concurso.FechaInicio;


                concursoEN.Imagen = concurso.Imagen;


                concursoEN.Compañia = concurso.Compañia;

                session.Update (concursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ConcursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ConcursoEN concursoEN = (ConcursoEN)session.Load (typeof(ConcursoEN), id);
                session.Delete (concursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ConcursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ConcursoEN
public ConcursoEN ReadOID (int id)
{
        ConcursoEN concursoEN = null;

        try
        {
                SessionInitializeTransaction ();
                concursoEN = (ConcursoEN)session.Get (typeof(ConcursoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ConcursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return concursoEN;
}

public System.Collections.Generic.IList<ConcursoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ConcursoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ConcursoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ConcursoEN>();
                else
                        result = session.CreateCriteria (typeof(ConcursoEN)).List<ConcursoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ConcursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
