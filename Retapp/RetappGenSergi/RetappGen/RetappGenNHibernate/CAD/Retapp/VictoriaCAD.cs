
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
 * Clase Victoria:
 *
 */

namespace RetappGenNHibernate.CAD.Retapp
{
public partial class VictoriaCAD : BasicCAD, IVictoriaCAD
{
public VictoriaCAD() : base ()
{
}

public VictoriaCAD(ISession sessionAux) : base (sessionAux)
{
}



public VictoriaEN ReadOIDDefault (int id)
{
        VictoriaEN victoriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                victoriaEN = (VictoriaEN)session.Get (typeof(VictoriaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in VictoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return victoriaEN;
}

public System.Collections.Generic.IList<VictoriaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VictoriaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VictoriaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<VictoriaEN>();
                        else
                                result = session.CreateCriteria (typeof(VictoriaEN)).List<VictoriaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in VictoriaCAD.", ex);
        }

        return result;
}

public int New_ (VictoriaEN victoria)
{
        try
        {
                SessionInitializeTransaction ();
                if (victoria.Concurso != null) {
                        // Argumento OID y no colección.
                        victoria.Concurso = (RetappGenNHibernate.EN.Retapp.ConcursoEN)session.Load (typeof(RetappGenNHibernate.EN.Retapp.ConcursoEN), victoria.Concurso.Id);

                        victoria.Concurso.Victoria
                        .Add (victoria);
                }
                if (victoria.Usuario != null) {
                        // Argumento OID y no colección.
                        victoria.Usuario = (RetappGenNHibernate.EN.Retapp.UsuarioEN)session.Load (typeof(RetappGenNHibernate.EN.Retapp.UsuarioEN), victoria.Usuario.Id);

                        victoria.Usuario.Victoria
                        .Add (victoria);
                }
                if (victoria.Usuario_0 != null) {
                        // Argumento OID y no colección.
                        victoria.Usuario_0 = (RetappGenNHibernate.EN.Retapp.UsuarioEN)session.Load (typeof(RetappGenNHibernate.EN.Retapp.UsuarioEN), victoria.Usuario_0.Id);

                        victoria.Usuario_0.ParticipacionesEnviadas
                        .Add (victoria);
                }
                if (victoria.Concurso != null) {
                        // Argumento OID y no colección.
                        victoria.Concurso = (RetappGenNHibernate.EN.Retapp.ConcursoEN)session.Load (typeof(RetappGenNHibernate.EN.Retapp.ConcursoEN), victoria.Concurso.Id);

                        victoria.Concurso.Victoria
                        .Add (victoria);
                }
                if (victoria.Usuario != null) {
                        // Argumento OID y no colección.
                        victoria.Usuario = (RetappGenNHibernate.EN.Retapp.UsuarioEN)session.Load (typeof(RetappGenNHibernate.EN.Retapp.UsuarioEN), victoria.Usuario.Id);

                        victoria.Usuario.Victoria
                        .Add (victoria);
                }

                session.Save (victoria);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in VictoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return victoria.Id;
}

public void Modify (VictoriaEN victoria)
{
        try
        {
                SessionInitializeTransaction ();
                VictoriaEN victoriaEN = (VictoriaEN)session.Load (typeof(VictoriaEN), victoria.Id);

                victoriaEN.Fecha = victoria.Fecha;


                victoriaEN.Valor = victoria.Valor;


                victoriaEN.Prueba = victoria.Prueba;


                victoriaEN.Votos = victoria.Votos;


                victoriaEN.Reportes = victoria.Reportes;


                victoriaEN.Pos = victoria.Pos;


                victoriaEN.Premio = victoria.Premio;

                session.Update (victoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in VictoriaCAD.", ex);
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
                VictoriaEN victoriaEN = (VictoriaEN)session.Load (typeof(VictoriaEN), id);
                session.Delete (victoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in VictoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: VictoriaEN
public VictoriaEN ReadOID (int id)
{
        VictoriaEN victoriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                victoriaEN = (VictoriaEN)session.Get (typeof(VictoriaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in VictoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return victoriaEN;
}

public System.Collections.Generic.IList<VictoriaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VictoriaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(VictoriaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<VictoriaEN>();
                else
                        result = session.CreateCriteria (typeof(VictoriaEN)).List<VictoriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in VictoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
