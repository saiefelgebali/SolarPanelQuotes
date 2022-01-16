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
    public class DaylightDataset
    {
        public readonly Daylight[] Data;

        public DaylightDataset(string path)
        {
            Data = Dataset<Daylight, JSONDaylight>.FromPath(path);
        }
    }
    public class HouseDataset
    {
        public readonly House[] Data;

        public HouseDataset(string path)
        {
            Data = Dataset<House, JSONHouse>.FromPath(path);
        }
    }
    public class InstallerDataset
    {
        public readonly Installer[] Data;

        public InstallerDataset(string path)
        {
            Data = Dataset<Installer, JSONInstaller>.FromPath(path);
        }
    }
    public class PanelDataset
    {
        public readonly Panel[] Data;
        public PanelDataset(string path)
        {
            Data = Dataset<Panel, JSONPanel>.FromPath(path);
        }
    }
    public class TariffDataset
    {
        public readonly Tariff[] Data;
        public TariffDataset(string path)
        {
            Data = Dataset<Tariff, JSONTariff>.FromPath(path);
        }
    }
}
