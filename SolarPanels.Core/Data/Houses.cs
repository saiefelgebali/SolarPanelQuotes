using SolarPanels.Core.JSON;
using SolarPanels.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolarPanels.Core.Data
{
    public class Houses
    {
        public readonly House[] Data;

        public Houses(string path)
        {
            var housesText = File.ReadAllText(path);

            var housesJson = JsonSerializer.Deserialize<JSONHouse[]>(housesText);

            var houses = new House[housesJson.Length];

            for (int i = 0; i < housesJson.Length; i++)
            {
                houses[i] = new House(housesJson[i]);
            }

            Data = houses;
        }
    }
}
