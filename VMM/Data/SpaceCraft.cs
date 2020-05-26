using System.Collections.Generic;
using System.Windows.Documents;

namespace VMM.Data
{
    public class SpaceCraft
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Oep> Oeps { get; set; }
    }
}