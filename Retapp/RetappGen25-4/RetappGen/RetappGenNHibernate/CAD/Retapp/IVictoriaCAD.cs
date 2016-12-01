
using System;
using RetappGenNHibernate.EN.Retapp;

namespace RetappGenNHibernate.CAD.Retapp
{
public partial interface IVictoriaCAD
{
VictoriaEN ReadOIDDefault (int id);

VictoriaEN ReadOID (int id);


System.Collections.Generic.IList<VictoriaEN> ReadAll (int first, int size);




void Modify (VictoriaEN victoria);


void Destroy (int id);


int New_ (VictoriaEN victoria);
}
}
