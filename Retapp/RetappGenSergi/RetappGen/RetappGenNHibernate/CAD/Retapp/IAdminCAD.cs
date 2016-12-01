
using System;
using RetappGenNHibernate.EN.Retapp;

namespace RetappGenNHibernate.CAD.Retapp
{
public partial interface IAdminCAD
{
AdminEN ReadOIDDefault (int id);

int New_ (AdminEN admin);

void Modify (AdminEN admin);


void Destroy (int id);
}
}
