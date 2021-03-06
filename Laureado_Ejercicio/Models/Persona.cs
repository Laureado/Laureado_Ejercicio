//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laureado_Ejercicio.Models
{
    using Laureado_Ejercicio.Validation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Persona
    {
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "El nombre debe tener entre 3-50 caracteres.", MinimumLength = 3)]
        public string Nombre { get; set; }
        [ValidateDate]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaDeNacimiento { get; set; }
    }
}
