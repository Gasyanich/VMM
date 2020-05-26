using System.Collections.Generic;

namespace VMM.Data
{
    public class Oep
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ZoneCompensationAmount { get; set; }
        public List<CompensationZone> CompensationZones { get; set; }
    }
}