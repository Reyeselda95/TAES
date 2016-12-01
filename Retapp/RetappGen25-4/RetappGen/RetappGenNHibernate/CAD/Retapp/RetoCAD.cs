
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
 * Clase Reto:
 *
 */

namespace RetappGenNHibernate.CAD.Retapp
{
public partial class RetoCAD : BasicCAD, IRetoCAD
{
public RetoCAD() : base ()
{
}

public RetoCAD(ISession sessionAux) : base (sessionAux)
{
}



public RetoEN ReadOIDDefault (int id)
{
        RetoEN retoEN = null;

        try
        {
                SessionInitializeTransaction ();
                retoEN = (RetoEN)session.Get (typeof(RetoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in RetoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return retoEN;
}

public System.Collections.Generic.IList<RetoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RetoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RetoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RetoEN>();
                        else
                                result = session.CreateCriteria (typeof(RetoEN)).List<RetoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in RetoCAD.", ex);
        }

        return result;
}

public int New_ (RetoEN reto)
{
        try
        {
                SessionInitializeTransaction ();
                if (reto.Concurso != null) {
                        // Argumento OID y no colección.
                        reto.Concurso = (RetappGenNHibernate.EN.Retapp.ConcursoEN)session.Load (typeof(RetappGenNHibernate.EN.Retapp.ConcursoEN), reto.Concurso.Id);

                        reto.Concurso.Retos
                        .Add (reto);
                }

                session.Save (reto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in RetoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reto.Id;
}

public void Modify (RetoEN reto)
{
        try
        {
                SessionInitializeTransaction ();
                RetoEN retoEN = (RetoEN)session.Load (typeof(RetoEN), reto.Id);

                retoEN.Nombre = reto.Nombre;


                retoEN.Descripcion = reto.Descripcion;


                retoEN.FechaFin = reto.FechaFin;


                retoEN.Active = reto.Active;

                session.Update (retoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in RetoCAD.", ex);
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
                RetoEN retoEN = (RetoEN)session.Load (typeof(RetoEN), id);
                session.Delete (retoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in RetoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: RetoEN
public RetoEN ReadOID (int id)
{
        RetoEN retoEN = null;

        try
        {
                SessionInitializeTransaction ();
                retoEN = (RetoEN)session.Get (typeof(RetoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in RetoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return retoEN;
}

public System.Collections.Generic.IList<RetoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RetoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RetoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RetoEN>();
                else
                        result = session.CreateCriteria (typeof(RetoEN)).List<RetoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in RetoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
