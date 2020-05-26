namespace VMM.Data
{
    public class ProtocolRow
    {
        public int Id { get; set; }
        public int RowNumber { get; set; }
        public double Sx { get; set; }
        public double Sy { get; set; }
        public double DeltaX { get; set; }
        public double DeltaY { get; set; }
        public bool IsActual { get; set; }
    }
}