using SolarPanels.Core.Algorithms.Models;
using SolarPanels.Core.Data.Models;
using System;

namespace SolarPanels.Core.Algorithms
{
    public class InstallerFitter
    {
        private readonly Installer[] Installers;

        public InstallerFitter()
        {
            Installers = InstallerDataset.Data;
        }

        public FittedInstaller[] FitInstallers(int panelCount)
        {
            if (panelCount < 0)
            {
                throw new ArgumentException("panelCount must be greater than 0");
            }

            FittedInstaller[] fittedInstallers = new FittedInstaller[Installers.Length];

            for (int i = 0; i < Installers.Length; i++)
            {
                var installer = Installers[i];

                var totalPrice = 
                    installer.CallOutCost + 
                    (installer.CostPerPanel * panelCount);

                fittedInstallers[i] = new FittedInstaller(installer, totalPrice);
            }

            return fittedInstallers;
        }
    }
}
