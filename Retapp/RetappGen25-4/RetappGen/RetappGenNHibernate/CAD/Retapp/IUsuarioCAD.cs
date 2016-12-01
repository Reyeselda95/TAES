
using System;
using RetappGenNHibernate.EN.Retapp;

namespace RetappGenNHibernate.CAD.Retapp
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string Gaccount);

string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string Gaccount);


UsuarioEN ReadOID (string Gaccount);


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);
}
}
