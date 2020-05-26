using GalaSoft.MvvmLight;

namespace VMM.ViewModels.ObservableObjects.Data
{
    public class ProtocolRowVM : ObservableObject
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { Set("Id", ref _id, value); }
        }

        private int _rowNumber;

        public int RowNumber
        {
            get { return _rowNumber; }
            set { Set("RowNumber", ref _rowNumber, value); }
        }

        private double _sx;

        public double Sx
        {
            get { return _sx; }
            set { Set("Sx", ref _sx, value); }
        }

        private double _sy;

        public double Sy
        {
            get { return _sy; }
            set { Set("Sy", ref _sy, value); }
        }

        private double _deltaX;

        public double DeltaX
        {
            get { return _deltaX; }
            set { Set("DeltaX", ref _deltaX, value); }
        }

        private double _deltaY;

        public double DeltaY
        {
            get { return _deltaY; }
            set { Set("DeltaY", ref _deltaY, value); }
        }

        private bool _isActual;

        public bool IsActual
        {
            get { return _isActual; }
            set { Set("IsActual", ref _isActual, value); }
        }
    }
}