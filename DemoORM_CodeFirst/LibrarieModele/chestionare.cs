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
    using LibrarieModele;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("chestionare")]
    public partial class chestionare
    {
        [Key]
        public int id_chestionar { get; set; }
        [ForeignKey("studenti")]
        public int id_student { get; set; }
        [ForeignKey("discipline")]
        public int id_disciplina { get; set; }
        [ForeignKey("anidestudiu")]
        public int id_an_de_studiu { get; set; }
        [ForeignKey("programedestudiu")]
        public int id_program_de_studiu { get; set; }
        [ForeignKey("tipuriactivitati")]
        public int id_tip_activitate { get; set; }
        public int numar_activitate { get; set; }
    
        public virtual anidestudiu anidestudiu { get; set; }
        public virtual discipline discipline { get; set; }
        public virtual programedestudiu programedestudiu { get; set; }
        public virtual tipuriactivitati tipuriactivitati { get; set; }
        public virtual studenti studenti { get; set; }
    }
}
