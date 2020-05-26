using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using VMM.Data;
using VMM.Services;
using VMM.ViewModels.ObservableObjects.Charts;
using VMM.ViewModels.ObservableObjects.Data;

namespace VMM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ProtocolLoaderService _protocolLoaderService;

        public MainViewModel(ProtocolLoaderService protocolLoaderService)
        {
            _protocolLoaderService = protocolLoaderService;

            YSxFormatter = sx => $"{sx:f2}";
            YSyFormatter = sx => $"{sx:f2}";

            SeriesCollection = new SeriesCollection();
        }

        #region Properties

        #region Selection

        private ObservableCollection<SpaceCraftVM> _spaceCrafts;

        public ObservableCollection<SpaceCraftVM> SpaceCrafts
        {
            get { return _spaceCrafts; }
            set { Set("SpaceCrafts", ref _spaceCrafts, value); }
        }

        private SpaceCraftVM _selectedSpaceCraft;

        public SpaceCraftVM SelectedSpaceCraft
        {
            get { return _selectedSpaceCraft; }
            set { Set("SelectedSpaceCraft", ref _selectedSpaceCraft, value); }
        }

        private OepVM _selectedOep;

        public OepVM SelectedOep
        {
            get { return _selectedOep; }
            set { Set("SelectedOep", ref _selectedOep, value); }
        }

        private CompensationZoneVM _selectedCompensationZone;

        public CompensationZoneVM SelectedCompensationZone
        {
            get { return _selectedCompensationZone; }
            set
            {
                Set("SelectedCompensationZone", ref _selectedCompensationZone, value);
                UpdateChart();
            }
        }

        #endregion

        #endregion


        private SeriesCollection _seriesCollection;

        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set { Set("SeriesCollection", ref _seriesCollection, value); }
        }

        private ObservableCollection<LineSeries> _lineSeries;

        public ObservableCollection<LineSeries> LineSeries
        {
            get { return _lineSeries; }
            set { Set("LineSeries", ref _lineSeries, value); }
        }

        #region Methods

        private void UpdateChart()
        {
            SeriesCollection.Clear();

            var seriesList = new List<ISeriesView>();

            for (int i = 0; i < SelectedCompensationZone.ProtocolLines.Count; i++)
            {
                var protocol = SelectedCompensationZone.ProtocolLines[i];

                var valuesX = new ChartValues<ObservablePoint>();
                var valuesY = new ChartValues<ObservablePoint>();

                foreach (var protocolRow in protocol)
                {
                    valuesX.Add(new ObservablePoint(protocolRow.RowNumber, protocolRow.Sx));
                    valuesY.Add(new ObservablePoint(protocolRow.RowNumber, protocolRow.Sy));
                }

                var seamNumber = i;
                if (SelectedCompensationZone.Name == "1")
                    seamNumber++;
                 

                seriesList.Add(new LineSeries
                {
                    Title = $"X по шву {seamNumber}",
                    Values = valuesX,
                    LineSmoothness = 0,
                    PointGeometry = null,
                    PointGeometrySize = 1,
                    ScalesYAt = 0,
                    Fill = Brushes.Transparent
                });

                seriesList.Add(new LineSeries
                {
                    Title = $"Y по шву {seamNumber}",
                    Values = valuesY,
                    LineSmoothness = 0,
                    PointGeometry = null,
                    PointGeometrySize = 1,
                    ScalesYAt = 1,
                    Fill = Brushes.Transparent
                });

                seriesList = seriesList.OrderBy(series => series.Title).ToList();
            }

            SeriesCollection.AddRange(seriesList);

            LineSeries = new ObservableCollection<LineSeries>(SeriesCollection.OfType<LineSeries>());
        }

        public void FillDefaultValues()
        {
            SpaceCrafts = new ObservableCollection<SpaceCraftVM>
            {
                _protocolLoaderService.LoadProtocolData(
                    "Resources\\Protocols\\10504_01_Aurora_10rows")
            };

            SelectedSpaceCraft = SpaceCrafts.FirstOrDefault();
            SelectedOep = SelectedSpaceCraft?.Oeps.FirstOrDefault();
            SelectedCompensationZone = SelectedOep?.CompensationZones.FirstOrDefault();
        }

        #endregion

        public Func<double, string> YSxFormatter { get; set; }
        public Func<double, string> YSyFormatter { get; set; }
    }
}