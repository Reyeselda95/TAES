
using System;
using RetappGenNHibernate.EN.Retapp;

namespace RetappGenNHibernate.CAD.Retapp
{
public partial interface IParticipacionCAD
{
ParticipacionEN ReadOIDDefault (int id);

int New_ (ParticipacionEN participacion);

void Modify (ParticipacionEN participacion);


void Destroy (int id);


ParticipacionEN ReadOID (int id);


System.Collections.Generic.IList<ParticipacionEN> ReadAll (int first, int size);
}
}
