using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace VMM.ViewModels.ObservableObjects.Data
{
    public class OepVM : ObservableObject
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { Set("Id", ref _id, value); }
        }

        private string _number;

        public string Number
        {
            get { return _number; }
            set { Set("Number", ref _number, value); }
        }

        private ObservableCollection<CompensationZoneVM> _compensationZones;

        public ObservableCollection<CompensationZoneVM> CompensationZones
        {
            get { return _compensationZones; }
            set { Set("CompensationZones", ref _compensationZones, value); }
        }

        private int _zoneCompensationAmount;

        public int ZoneCompensationAmount
        {
            get { return _zoneCompensationAmount; }
            set { Set("ZoneCompensationAmount", ref _zoneCompensationAmount, value); }
        }
    }
}