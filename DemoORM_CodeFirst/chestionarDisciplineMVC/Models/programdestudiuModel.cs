using LibrarieModele;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace chestionarDisciplineMVC.Models
{
    public class programdestudiuModel
    {
        [Key]
        public int id_programe_de_studiu { get; set; }
        public string nume_programe_de_studiu { get; set; }
        [ForeignKey("cicluldestudii")]
        public int id_ciclul_de_studii { get; set; }
        public virtual cicluldestudii cicluldestudii { get; set; }
    }
}