﻿using SolarPanels.Core.Algorithms.Models;
using SolarPanels.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Algorithms
{
    public class InstallerFitter
    {
        private double Budget { get; set; }

        public InstallerFitter(double? budget)
        {
            if (budget != null) Budget = (double)budget;
        }

        public FittedInstaller[] FitInstallers(Installer[] installers, int panelCount)
        {
            FittedInstaller[] FittedInstallers = new FittedInstaller[installers.Length];

            for (int i = 0; i < installers.Length; i++)
            {
                var installer = installers[i];

                var totalPrice = 
                    installer.CallOutCost + 
                    (installer.CostPerPanel * panelCount);

                FittedInstallers[i] = new FittedInstaller(installer, totalPrice);
            }

            return FittedInstallers;
        }
    }
}
