//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atestados.Datos.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class EvaluaciónXAtestado
    {
        public int AtestadoID { get; set; }
        public int PersonaID { get; set; }
        public int AutorID { get; set; }
        public double PorcentajeObtenido { get; set; }
        public string Observaciones { get; set; }
    
        public virtual Atestado Atestado { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Persona Persona1 { get; set; }
    }
}
