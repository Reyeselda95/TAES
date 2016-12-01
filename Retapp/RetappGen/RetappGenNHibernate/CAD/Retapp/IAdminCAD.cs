
using System;
using RetappGenNHibernate.EN.Retapp;

namespace RetappGenNHibernate.CAD.Retapp
{
public partial interface IAdminCAD
{
AdminEN ReadOIDDefault (string Usr);

string New_ (AdminEN admin);

void Modify (AdminEN admin);


void Destroy (string Usr);
}
}
