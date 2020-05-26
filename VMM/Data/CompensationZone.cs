using System.Collections.Generic;
using System.Windows.Documents;

namespace VMM.Data
{
    public class CompensationZone
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProtocolRow[]> ProtocolLines { get; set; }
    }
}