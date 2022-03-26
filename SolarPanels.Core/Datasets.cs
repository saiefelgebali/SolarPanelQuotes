using SolarPanels.Core.Data;
using SolarPanels.Core.Data.JSON;
using SolarPanels.Core.Data.Models;

namespace SolarPanels.Core
{
    public static class DaylightDataset
    {
        public static readonly Daylight[] Data = Dataset<Daylight, JSONDaylight>.FromPath("Daylight.json");
    }

    public static class HouseDataset
    {
        public static readonly House[] Data = Dataset<House, JSONHouse>.FromPath("Houses.json");
    }

    public static class InstallerDataset
    {
        public static readonly Installer[] Data = Dataset<Installer, JSONInstaller>.FromPath("Installers.json");
    }

    public static class PanelDataset
    {
        public static readonly Panel[] Data = Dataset<Panel, JSONPanel>.FromPath("Panels.json");
    }

    public static class TariffDataset
    {
        public static readonly Tariff[] Data = Dataset<Tariff, JSONTariff>.FromPath("Tariffs.json");
    }
}
