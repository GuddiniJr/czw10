using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Prodedre
    {
        public Prodedre()
        {
            ProcedureAnimal = new HashSet<ProcedureAnimal>();
        }

        public int IdProcedure { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProcedureAnimal> ProcedureAnimal { get; set; }
    }
}
