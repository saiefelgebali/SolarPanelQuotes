using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SolarPanels.Core.JSON;
using SolarPanels.Core.Models;

namespace SolarPanels.Core.Data
{
    public class Tariffs
    {
        public readonly Tariff[] Data;

        public Tariffs(string path)
        {
            var tariffsText = File.ReadAllText(path);

            var tariffsJson = JsonSerializer.Deserialize<JSONTariff[]>(tariffsText);

            var tariffs = new Tariff[tariffsJson.Length];

            for (int i = 0; i < tariffs.Length; i++)
            {
                tariffs[i] = new Tariff(tariffsJson[i]);
            }

            Data = tariffs;
        }
    }
}
