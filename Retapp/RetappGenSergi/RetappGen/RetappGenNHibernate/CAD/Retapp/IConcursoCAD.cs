
using System;
using RetappGenNHibernate.EN.Retapp;

namespace RetappGenNHibernate.CAD.Retapp
{
public partial interface IConcursoCAD
{
ConcursoEN ReadOIDDefault (int id);

int New_ (ConcursoEN concurso);

void Modify (ConcursoEN concurso);


void Destroy (int id);


ConcursoEN ReadOID (int id);


System.Collections.Generic.IList<ConcursoEN> ReadAll (int first, int size);
}
}
