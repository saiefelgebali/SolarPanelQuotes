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
    public class Installers
    {
        public readonly Installer[] Data;

        public Installers(string path)
        {
            var installersText = File.ReadAllText(path);

            var installersJson = JsonSerializer.Deserialize<JSONInstaller[]>(installersText);

            var installers = new Installer[installersJson.Length];

            for (int i = 0; i < installersJson.Length; i++)
            {
                installers[i] = new Installer(installersJson[i]);
            }

            Data = installers;
        }
    }
}
