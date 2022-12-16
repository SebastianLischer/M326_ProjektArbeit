using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_ProjektArbeit.Model
{
    public class CompetenceGrid
    {
        public int CompetenceGridId { get; set; }
        public string Name { get; set; }
        public Job Job { get; set; }
    }
}
