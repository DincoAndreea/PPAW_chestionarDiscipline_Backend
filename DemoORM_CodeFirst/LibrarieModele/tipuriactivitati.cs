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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [JsonObject]
    [Serializable]
    [Table("tipuriactivitati")]
    public partial class tipuriactivitati
    {

        [Key]
        public int id_tip_activitate { get; set; }
        public string nume_activitate { get; set; }
    
    }
}