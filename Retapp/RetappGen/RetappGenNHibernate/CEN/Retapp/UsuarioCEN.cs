

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

public string New_ (string p_Gaccount, bool p_Baneado, int p_Votos, float p_Karma, string p_Password)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        
        usuarioEN.Gaccount = p_Gaccount;

        usuarioEN.Baneado = p_Baneado;

        usuarioEN.Votos = p_Votos;

        usuarioEN.Karma = p_Karma;

        usuarioEN.Password = p_Password;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, bool p_Baneado, int p_Votos, float p_Karma, string p_Password)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Gaccount = p_Usuario_OID;
        usuarioEN.Baneado = p_Baneado;
        usuarioEN.Votos = p_Votos;
        usuarioEN.Karma = p_Karma;
        usuarioEN.Password = p_Password;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string Gaccount)
{
        _IUsuarioCAD.Destroy (Gaccount);
}

public UsuarioEN ReadOID (string Gaccount)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (Gaccount);
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
