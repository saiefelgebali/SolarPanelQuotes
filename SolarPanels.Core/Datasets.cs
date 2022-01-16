using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarPanels.Core.Data;
using SolarPanels.Core.Data.JSON;
using SolarPanels.Core.Data.Models;

namespace SolarPanels.Core
{
    public static class Datasets
    {
        public static Dataset<Daylight, JSONDaylight> DaylightDataset(string path) => new(path);
        public static Dataset<House, JSONHouse> HouseDataset(string path) => new(path);
        public static Dataset<Installer, JSONInstaller> InstallerDataset(string path) => new(path);
        public static Dataset<Panel, JSONPanel> PanelDataset(string path) => new(path);
        public static Dataset<Tariff, JSONTariff> TariffDataset(string path) => new(path);
    }
}
