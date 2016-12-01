
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
public partial class RetoCEN
{
public void Activar (int p_oid)
{
        /*PROTECTED REGION ID(RetappGenNHibernate.CEN.Retapp_Reto_Activar) ENABLED START*/

        // Write here your custom code...

        try
        {
                RetoEN ret = ReadOID (p_oid);
                ret.Active = true;
                this.Modify (ret.Id, ret.Nombre, ret.Descripcion, ret.FechaFin, ret.Active);
        }
        catch (Exception ex) { Console.WriteLine ("Se ha producido una excepci�n al activar el reto: " + ex); }
        /*PROTECTED REGION END*/
}
}
}
