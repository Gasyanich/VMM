using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using VMM.Data;
using VMM.ViewModels.ObservableObjects.Data;

namespace VMM.Services
{
    public class ProtocolLoaderService
    {
        private const string ResPath = "Resources\\Protocols\\";

        public SpaceCraftVM LoadProtocolData(string folderPath, int zcAmount = 3, int zcMatrixCount = 6)
        {
            var files = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
                .OrderBy(fileName => fileName).ToList();


            var spaceCraftNumber =
                Path.GetFileName(files.First()).Split(new[] {"_"}, StringSplitOptions.RemoveEmptyEntries)[0];

            var oepNumber =
                Path.GetFileName(files.First()).Split(new[] {"_"}, StringSplitOptions.RemoveEmptyEntries)[6];

            var oepVm = new OepVM
            {
                CompensationZones = new ObservableCollection<CompensationZoneVM>(),
                Number = oepNumber,
                ZoneCompensationAmount = zcAmount
            };
            var spaceCraft = new SpaceCraftVM {Name = spaceCraftNumber, Oeps = new ObservableCollection<OepVM> {oepVm}};

            var groupedByCzNumber = files.GroupBy(name => Path.GetFileName(name).Split('_')[7]);

            foreach (var czFiles in groupedByCzNumber)
            {
                var czNumber = czFiles.Key;
                var compensationZone = new CompensationZoneVM
                {
                    Name = czNumber,
                    ProtocolLines = new List<ProtocolRowVM[]>()
                };

                foreach (var czFile in czFiles)
                    compensationZone.ProtocolLines.Add(GetProtocolRows(czFile));

                oepVm.CompensationZones.Add(compensationZone);
            }

            return spaceCraft;
        }

        private ProtocolRowVM[] GetProtocolRows(string protocolPath)
        {
            var protocolLines = File.ReadAllLines(protocolPath);

            return protocolLines
                .Skip(5)
                .Select(s =>
                {
                    var plRow = s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < plRow.Length; i++)
                        plRow[i] = plRow[i].Replace('.', ',');

                    return new ProtocolRowVM
                    {
                        RowNumber = int.Parse(plRow[0]),
                        Sx = double.Parse(plRow[1]),
                        Sy = double.Parse(plRow[2]),
                        DeltaX = double.Parse(plRow[3]),
                        DeltaY = double.Parse(plRow[4]),
                       // IsActual = bool.Parse(plRow[5].ToLower())
                    };
                }).ToArray();
        }
    }
}