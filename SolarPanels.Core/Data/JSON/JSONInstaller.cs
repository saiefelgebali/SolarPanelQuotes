using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Data.JSON
{
    public class JSONInstaller : BaseJSONData
    {
        public string Id { get; set; }
        public double CallOutCost { get; set; }
        public double CostPerPanel { get; set; }
    }
}
