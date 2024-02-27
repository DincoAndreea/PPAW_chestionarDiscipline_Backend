using LibrarieModele;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace chestionarDisciplineMVC.Models
{
    public class anidestudiuModel
    {
        [Key]
        public int id_ani_de_studiu { get; set; }
        public string anul_de_studiu { get; set; }
        [ForeignKey("cicluldestudii")]
        public int ciclul_de_studii { get; set; }

        public virtual cicluldestudii cicluldestudii { get; set; }
    }
}