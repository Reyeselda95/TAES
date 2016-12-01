

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
 *      Definition of the class ParticipacionCEN
 *
 */
public partial class ParticipacionCEN
{
private IParticipacionCAD _IParticipacionCAD;

public ParticipacionCEN()
{
        this._IParticipacionCAD = new ParticipacionCAD ();
}

public ParticipacionCEN(IParticipacionCAD _IParticipacionCAD)
{
        this._IParticipacionCAD = _IParticipacionCAD;
}

public IParticipacionCAD get_IParticipacionCAD ()
{
        return this._IParticipacionCAD;
}

public int New_ (int p_concurso, int p_usuario, int p_usuario_0, Nullable<DateTime> p_Fecha, float p_Valor, string p_Prueba, int p_Votos, int p_Reportes)
{
        ParticipacionEN participacionEN = null;
        int oid;

        //Initialized ParticipacionEN
        participacionEN = new ParticipacionEN ();

        if (p_concurso != -1) {
                // El argumento p_concurso -> Property concurso es oid = false
                // Lista de oids id
                participacionEN.Concurso = new RetappGenNHibernate.EN.Retapp.ConcursoEN ();
                participacionEN.Concurso.Id = p_concurso;
        }


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                participacionEN.Usuario = new RetappGenNHibernate.EN.Retapp.UsuarioEN ();
                participacionEN.Usuario.Id = p_usuario;
        }


        if (p_usuario_0 != -1) {
                // El argumento p_usuario_0 -> Property usuario_0 es oid = false
                // Lista de oids id
                participacionEN.Usuario_0 = new RetappGenNHibernate.EN.Retapp.UsuarioEN ();
                participacionEN.Usuario_0.Id = p_usuario_0;
        }

        participacionEN.Fecha = p_Fecha;

        participacionEN.Valor = p_Valor;

        participacionEN.Prueba = p_Prueba;

        participacionEN.Votos = p_Votos;

        participacionEN.Reportes = p_Reportes;

        //Call to ParticipacionCAD

        oid = _IParticipacionCAD.New_ (participacionEN);
        return oid;
}

public void Modify (int p_Participacion_OID, Nullable<DateTime> p_Fecha, float p_Valor, string p_Prueba, int p_Votos, int p_Reportes)
{
        ParticipacionEN participacionEN = null;

        //Initialized ParticipacionEN
        participacionEN = new ParticipacionEN ();
        participacionEN.Id = p_Participacion_OID;
        participacionEN.Fecha = p_Fecha;
        participacionEN.Valor = p_Valor;
        participacionEN.Prueba = p_Prueba;
        participacionEN.Votos = p_Votos;
        participacionEN.Reportes = p_Reportes;
        //Call to ParticipacionCAD

        _IParticipacionCAD.Modify (participacionEN);
}

public void Destroy (int id)
{
        _IParticipacionCAD.Destroy (id);
}

public ParticipacionEN ReadOID (int id)
{
        ParticipacionEN participacionEN = null;

        participacionEN = _IParticipacionCAD.ReadOID (id);
        return participacionEN;
}

public System.Collections.Generic.IList<ParticipacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ParticipacionEN> list = null;

        list = _IParticipacionCAD.ReadAll (first, size);
        return list;
}
}
}
