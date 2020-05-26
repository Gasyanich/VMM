using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace VMM.ViewModels.ObservableObjects.Data
{
    public class SpaceCraftVM : ObservableObject
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
            set { Set("Name", ref _name, value); }
        }

        private ObservableCollection<OepVM> _oeps;

        public ObservableCollection<OepVM> Oeps
        {
            get { return _oeps; }
            set { Set("Oeps", ref _oeps, value); }
        }
    }
}