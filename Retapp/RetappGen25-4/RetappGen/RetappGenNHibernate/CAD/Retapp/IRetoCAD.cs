
using System;
using RetappGenNHibernate.EN.Retapp;

namespace RetappGenNHibernate.CAD.Retapp
{
public partial interface IRetoCAD
{
RetoEN ReadOIDDefault (int id);


int New_ (RetoEN reto);

void Modify (RetoEN reto);


void Destroy (int id);


RetoEN ReadOID (int id);


System.Collections.Generic.IList<RetoEN> ReadAll (int first, int size);
}
}
