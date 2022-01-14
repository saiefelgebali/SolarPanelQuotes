using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SolarPanels.Core.JSON;
using SolarPanels.Core.Models;

namespace SolarPanels.Core.Data
{
    public class Panels
    {
        public readonly Panel[] Data;

        public Panels(string path)
        {
            var panelsText = File.ReadAllText(path);

            var panelsJson = JsonSerializer.Deserialize<JSONPanel[]>(panelsText);

            var panels = new Panel[panelsJson.Length];

            for (int i = 0; i < panels.Length; i++)
            {
                panels[i] = new Panel(panelsJson[i]);
            }

            Data = panels;
        }
    }
}
