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
    public class Daylights
    {
        public readonly Daylight[] Data;

        public Daylights(string path)
        {
            var daylightsText = File.ReadAllText(path);

            var daylightsJson = JsonSerializer.Deserialize<JSONDaylight[]>(daylightsText);

            var daylights = new Daylight[daylightsJson.Length];

            for (int i = 0; i < daylightsJson.Length; i++)
            {
                daylights[i] = new Daylight(daylightsJson[i]);
            }

            Data = daylights;
        }
    }
}
