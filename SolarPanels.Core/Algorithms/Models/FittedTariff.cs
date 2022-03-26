﻿using SolarPanels.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanels.Core.Algorithms.Models
{
    public class FittedTariff
    {
        public Tariff Tariff{ get; private set; }

        public double[] AverageFeedAmounts { get; private set; }

        public double[] AverageRevenues { get; private set; }

        public double[] AverageExpiredRevenues { get; private set; }

        public FittedTariff(FittedPanels fitting, Tariff tarrif, double averageConsumption)
        {
            Tariff = tarrif;

            // Get average feed amounts over each month
            AverageFeedAmounts = fitting.AverageOutputs.Select(                
                output => {
                    // Subtract the average consumption from panel outputs
                    // feed amount is whatever there is left over.
                    var rawFeed = output - averageConsumption;

                    // If average consumption is greater than the output,
                    // then feed amount is 0.
                    if (rawFeed < 0) return 0;

                    // Clip the feedAmount so that it is never greater than
                    // the tariff's maximum feed amount.
                    if (rawFeed > tarrif.MaximumFeedAmount) return tarrif.MaximumFeedAmount;

                    return rawFeed;
                }).ToArray();

            // Calculate average revenue over each month
            AverageRevenues = AverageFeedAmounts.Select(feedAmount => feedAmount * tarrif.Price).ToArray();

            // Calculate average expired revenues
            AverageExpiredRevenues = AverageFeedAmounts.Select(feedAmount => feedAmount * tarrif.ExpiredPrice).ToArray();
        }
    }
}