

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public int New_ (string p_Gaccount, int p_Tlf, Nullable<DateTime> p_FechaBaneado, string p_Nombre, int p_NumBaneos, string p_Direccion, bool p_Baneado, int p_Votos, float p_Karma, int p_CodPstal, Nullable<DateTime> p_FechaLogin)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Gaccount = p_Gaccount;

        usuarioEN.Tlf = p_Tlf;

        usuarioEN.FechaBaneado = p_FechaBaneado;

        usuarioEN.Nombre = p_Nombre;

        usuarioEN.NumBaneos = p_NumBaneos;

        usuarioEN.Direccion = p_Direccion;

        usuarioEN.Baneado = p_Baneado;

        usuarioEN.Votos = p_Votos;

        usuarioEN.Karma = p_Karma;

        usuarioEN.CodPstal = p_CodPstal;

        usuarioEN.FechaLogin = p_FechaLogin;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (int p_Usuario_OID, string p_Gaccount, int p_Tlf, Nullable<DateTime> p_FechaBaneado, string p_Nombre, int p_NumBaneos, string p_Direccion, bool p_Baneado, int p_Votos, float p_Karma, int p_CodPstal, Nullable<DateTime> p_FechaLogin)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Id = p_Usuario_OID;
        usuarioEN.Gaccount = p_Gaccount;
        usuarioEN.Tlf = p_Tlf;
        usuarioEN.FechaBaneado = p_FechaBaneado;
        usuarioEN.Nombre = p_Nombre;
        usuarioEN.NumBaneos = p_NumBaneos;
        usuarioEN.Direccion = p_Direccion;
        usuarioEN.Baneado = p_Baneado;
        usuarioEN.Votos = p_Votos;
        usuarioEN.Karma = p_Karma;
        usuarioEN.CodPstal = p_CodPstal;
        usuarioEN.FechaLogin = p_FechaLogin;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (int id)
{
        _IUsuarioCAD.Destroy (id);
}

public UsuarioEN ReadOID (int id)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (id);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
}
}
