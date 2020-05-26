using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace VMM.ViewModels.ObservableObjects.Data
{
    public class CompensationZoneVM : ObservableObject
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { Set("Id", ref _id, value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { Set("Number", ref _name, value); }
        }

        private List<ProtocolRowVM[]> _protocolLines;

        public List<ProtocolRowVM[]> ProtocolLines
        {
            get { return _protocolLines; }
            set { Set("ProtocolLines", ref _protocolLines, value); }
        }
    }
}