//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GradoEstudio
    {
        public int Id { get; set; }
        public string Nombre_Institucion { get; set; }
        public string Titulo { get; set; }
        public Nullable<System.DateTime> Fecha_Graduacion { get; set; }
        public Nullable<int> AplicanteId { get; set; }
    
        public virtual Aplicante Aplicante { get; set; }
    }
}