using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Heroe
    {
        [Key]
        public int IdHeroe { get; set; }
        public string Nombre { get; set; }
        public int IdAltergo { get; set; }
        public bool Activo { get; set; }
    }
}
