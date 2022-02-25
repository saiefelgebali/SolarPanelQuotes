using SolarPanels.Core;
using SolarPanels.Core.Data;
using SolarPanels.Core.Data.Models;
using SolarPanels.Core.Data.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Tests
{
    internal static class TestUtility
    {
        static readonly string HomePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        static readonly string DataPath = $"{HomePath}/source/repos/saiefelgebali/SolarPanels/data";

        static readonly string DaylightPath = Path.Combine(DataPath, "Daylight.json");
        static readonly string HousePath = Path.Combine(DataPath, "Houses.json");
        static readonly string InstallerPath = Path.Combine(DataPath, "Installers.json");
        static readonly string PanelPath = Path.Combine(DataPath, "Panels.json");
        static readonly string TariffPath = Path.Combine(DataPath, "Tariffs.json");

        public static DaylightDataset DaylightDataset = new (DaylightPath);
        public static PanelDataset PanelDataset = new (PanelPath);
        public static HouseDataset HouseDataset = new (HousePath);
        public static InstallerDataset InstallerDataset = new (InstallerPath);
        public static TariffDataset TariffDataset = new (TariffPath);
    }
}
