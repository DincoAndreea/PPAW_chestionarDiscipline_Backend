//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibrarieModele
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("raspunsurichestionar")]
    public partial class raspunsurichestionar
    {
        [Key]
        public int id_raspuns { get; set; }
        [ForeignKey("chestionare")]
        public int id_chestionar { get; set; }
        [ForeignKey("intrebari")]
        public int id_intrebare { get; set; }
        public string text_raspuns { get; set; }
    
        public virtual intrebari intrebari { get; set; }
        public virtual chestionare chestionare { get; set; }
    }
}
