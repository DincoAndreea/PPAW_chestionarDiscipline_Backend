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
    [Table("anidestudiu")]
    public partial class anidestudiu
    {

        [Key]        
        public int id_ani_de_studiu { get; set; }
        public string anul_de_studiu { get; set; }
        [ForeignKey("cicluldestudii")]
        public int ciclul_de_studii { get; set; }

        public virtual cicluldestudii cicluldestudii { get; set; }
    
    }

    public class anidestudiuDTO
    {
        public int id_ani_de_studiu { get; set; }
        public string anul_de_studiu { get; set; }
    }
}