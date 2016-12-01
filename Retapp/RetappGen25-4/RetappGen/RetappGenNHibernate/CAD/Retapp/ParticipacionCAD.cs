
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
 * Clase Participacion:
 *
 */

namespace RetappGenNHibernate.CAD.Retapp
{
public partial class ParticipacionCAD : BasicCAD, IParticipacionCAD
{
public ParticipacionCAD() : base ()
{
}

public ParticipacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public ParticipacionEN ReadOIDDefault (int id)
{
        ParticipacionEN participacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                participacionEN = (ParticipacionEN)session.Get (typeof(ParticipacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ParticipacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return participacionEN;
}

public System.Collections.Generic.IList<ParticipacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ParticipacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ParticipacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ParticipacionEN>();
                        else
                                result = session.CreateCriteria (typeof(ParticipacionEN)).List<ParticipacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ParticipacionCAD.", ex);
        }

        return result;
}

public int New_ (ParticipacionEN participacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (participacion.Usuario_0 != null) {
                        // Argumento OID y no colección.
                        participacion.Usuario_0 = (RetappGenNHibernate.EN.Retapp.UsuarioEN)session.Load (typeof(RetappGenNHibernate.EN.Retapp.UsuarioEN), participacion.Usuario_0.Gaccount);

                        participacion.Usuario_0.ParticipacionesEnviadas
                        .Add (participacion);
                }
                if (participacion.Reto != null) {
                        // Argumento OID y no colección.
                        participacion.Reto = (RetappGenNHibernate.EN.Retapp.RetoEN)session.Load (typeof(RetappGenNHibernate.EN.Retapp.RetoEN), participacion.Reto.Id);

                        participacion.Reto.Participacion
                        .Add (participacion);
                }

                session.Save (participacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ParticipacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return participacion.Id;
}

public void Modify (ParticipacionEN participacion)
{
        try
        {
                SessionInitializeTransaction ();
                ParticipacionEN participacionEN = (ParticipacionEN)session.Load (typeof(ParticipacionEN), participacion.Id);

                participacionEN.Fecha = participacion.Fecha;


                participacionEN.Valor = participacion.Valor;


                participacionEN.Votos = participacion.Votos;


                participacionEN.Reportes = participacion.Reportes;

                session.Update (participacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ParticipacionCAD.", ex);
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
                ParticipacionEN participacionEN = (ParticipacionEN)session.Load (typeof(ParticipacionEN), id);
                session.Delete (participacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ParticipacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ParticipacionEN
public ParticipacionEN ReadOID (int id)
{
        ParticipacionEN participacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                participacionEN = (ParticipacionEN)session.Get (typeof(ParticipacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ParticipacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return participacionEN;
}

public System.Collections.Generic.IList<ParticipacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ParticipacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ParticipacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ParticipacionEN>();
                else
                        result = session.CreateCriteria (typeof(ParticipacionEN)).List<ParticipacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RetappGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new RetappGenNHibernate.Exceptions.DataLayerException ("Error in ParticipacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
