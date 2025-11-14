using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Requests
{
    public class HeroeRequest
    {
        public string Nombre { get; set; }
        public int? IdAlterEgo {  get; set; }
        public bool Activo { get; set; }
    }
}
