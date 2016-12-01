
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
public partial class ConcursoCEN
{
public void Validar (int concurso)
{
        /*PROTECTED REGION ID(RetappGenNHibernate.CEN.Retapp_Concurso_Validar) ENABLED START*/

        try
        {
                ConcursoEN concur = ReadOID (concurso);
                concur.Aprobado = true;
                this.Modify (concur.Id, concur.FechaFin, concur.Aprobado, concur.Finalizado, concur.FraseCaracteristica, concur.Cuerpo, concur.Premios, concur.Pos, concur.FechaInicio, concur.Imagen, concur.Compañia);
        }
        catch (Exception ex) { Console.WriteLine ("Se ha producido una excepción al validar el concurso: " + ex); }

        /*PROTECTED REGION END*/
}
}
}
