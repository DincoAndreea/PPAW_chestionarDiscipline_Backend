using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    [JsonObject]
    [Serializable]
    [Table("studenti")]
    public class studenti
    {
        [Key]
        public int id_student { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string email { get; set; }

    }
}
