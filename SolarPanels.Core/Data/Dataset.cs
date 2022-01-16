using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SolarPanels.Core.Data.JSON;
using SolarPanels.Core.Data.Models;

namespace SolarPanels.Core.Data
{
    public class Dataset<T, J> where T : class, new()
    {
        public T[] Data;

        public Dataset(string path)
        {
            Data = FromPath(path);
        }

        public T[] FromPath(string path)
        {
            var text = File.ReadAllText(path);

            var json = JsonSerializer.Deserialize<J[]>(text);

            var data = new T[json.Length];

            // Convert json instances to their respective model objects
            for (int i = 0; i < json.Length; i++)
            {
                data[i] = (T)Activator.CreateInstance(typeof(T), json[i]);
            }

            return data;
        }
    }
}
