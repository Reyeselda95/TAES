
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
public partial class ParticipacionCEN
{
public void SubirDemo (string file, int id)
{
        /*PROTECTED REGION ID(RetappGenNHibernate.CEN.Retapp_Participacion_SubirDemo) ENABLED START*/

        // Write here your custom code...
        try
        {
                ParticipacionEN par = ReadOID (id);
                par.Prueba = file;
                this._IParticipacionCAD.Modify(par);
        }
        catch (Exception ex) { Console.WriteLine ("Se ha producido una excepci�n al introducir la url a la prueba de la particiacion en la base de datos: " + ex); }

        /*PROTECTED REGION END*/
}
}
}
