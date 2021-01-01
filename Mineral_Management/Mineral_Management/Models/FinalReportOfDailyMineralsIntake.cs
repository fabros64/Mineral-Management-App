using System;
using System.Collections.Generic;
using System.Text;

namespace Mineral_Management.Models
{
    public class FinalReportOfDailyMineralsIntake
    {
        public PersonNutrientsDailyIntake PersonNutrientsDailyIntake { get; set; }
        public DailyDietSumOfMinerals DailyDietSumOfMinerals { get; set; }
        public List<ChartMineral> ChartMinerals { get; set; }
        public FinalReportOfDailyMineralsIntake(PersonNutrientsDailyIntake personNutrientsDailyIntake,
            DailyDietSumOfMinerals dailyDietSumOfMinerals)
        {
            this.PersonNutrientsDailyIntake = personNutrientsDailyIntake;
            this.DailyDietSumOfMinerals = dailyDietSumOfMinerals;

            double percentage;

            PhosphorusReport = MineralReport(personNutrientsDailyIntake.MineralsDailyIntake.Phosphorus, 
                dailyDietSumOfMinerals.PhosphorusTotal, out percentage);
            PhosphorusPercentage = percentage;

            PotassiumReport = MineralReport(personNutrientsDailyIntake.MineralsDailyIntake.Potassium,
                dailyDietSumOfMinerals.PotassiumTotal, out percentage);
            PotassiumPercentage = percentage;

            SodiumReport = MineralReport(personNutrientsDailyIntake.MineralsDailyIntake.Sodium,
                dailyDietSumOfMinerals.SodiumTotal, out percentage);
            SodiumPercentage = percentage;

            CalciumReport = MineralReport(personNutrientsDailyIntake.MineralsDailyIntake.Calcium,
                dailyDietSumOfMinerals.CalciumTotal, out percentage);
            CalciumPercentage = percentage;

            IronReport = MineralReport(personNutrientsDailyIntake.MineralsDailyIntake.Iron,
                dailyDietSumOfMinerals.IronTotal, out percentage);
            IronPercentage = percentage;

            MagnesiumReport = MineralReport(personNutrientsDailyIntake.MineralsDailyIntake.Magnesium,
                dailyDietSumOfMinerals.MagnesiumTotal, out percentage);
            MagnesiumPercentage = percentage;

            ZincReport = MineralReport(personNutrientsDailyIntake.MineralsDailyIntake.Zinc,
                dailyDietSumOfMinerals.ZincTotal, out percentage);
            ZincPercentage = percentage;

            CopperReport = MineralReport(personNutrientsDailyIntake.MineralsDailyIntake.Copper,
                dailyDietSumOfMinerals.CopperTotal, out percentage);
            CopperPercentage = percentage;

            SeleniumReport = MineralReport(personNutrientsDailyIntake.MineralsDailyIntake.Selenium,
                dailyDietSumOfMinerals.SeleniumTotal, out percentage);
            SeleniumPercentage = percentage;

            ChartMinerals = new List<ChartMineral>()
            {
                new ChartMineral("P", PhosphorusPercentage),
                new ChartMineral("K", PotassiumPercentage),
                new ChartMineral("Na", SodiumPercentage),
                new ChartMineral("Ca", CalciumPercentage),
                new ChartMineral("Fe", IronPercentage),
                new ChartMineral("Mg", MagnesiumPercentage),
                new ChartMineral("Zn", ZincPercentage),
                new ChartMineral("Cu", CopperPercentage),
                new ChartMineral("Se", SeleniumPercentage)
            };
        }

        private string MineralReport(MineralRange mineralRangeIntake, double mineralAmountFromDiet, out double percentage)
        {
            string report = null;
            string initialReport = null;
            string necessaryInformation = null;

            // ear,rdi,ul / ai / ai,ul / ear,rdi

            if (mineralRangeIntake.EstimatedAverageRequirement > 0.0000 && mineralRangeIntake.RecommendedDietaryIntake > 0.0000
                                                                        && mineralRangeIntake.UpperLevelOfIntake > 0.0000)
            {
               initialReport = "You provide " + mineralAmountFromDiet + " mg\nYour body needs at least " +
                         mineralRangeIntake.EstimatedAverageRequirement + " mg\nRecommended value is " +
                         mineralRangeIntake.RecommendedDietaryIntake + " mg\nMaximum daily dose is " +
                         mineralRangeIntake.UpperLevelOfIntake + " mg ";

               if (mineralAmountFromDiet < mineralRangeIntake.EstimatedAverageRequirement)
                   necessaryInformation = "\nYOU SUPPLY TOO LITTLE OF THIS MINERAL!";
               else if (mineralAmountFromDiet > mineralRangeIntake.UpperLevelOfIntake)
                   necessaryInformation = "\nYOU SUPPLY TOO MUCH OF THIS MINERAL!";
               else
                   necessaryInformation = "\nYOU SUPPLY THE CORRECT AMOUNT";

            }

            else if (mineralRangeIntake.EstimatedAverageRequirement == 0.0000 && mineralRangeIntake
                                                                                  .RecommendedDietaryIntake == 0.0000
                                                                              && mineralRangeIntake.UpperLevelOfIntake ==
                                                                              0.0000)
            {
                initialReport = "You provide " + mineralAmountFromDiet +
                                " mg\nYour body needs about " +
                                mineralRangeIntake.AdequateIntake + " mg\nNo maximum dose specified " +
                                "from food";
                if (mineralAmountFromDiet < mineralRangeIntake.AdequateIntake)
                    necessaryInformation = "\nYOU SUPPLY TOO LITTLE OF THIS MINERAL!";
                else
                    necessaryInformation = "\nYOU SUPPLY THE CORRECT AMOUNT";

            }

            else if (mineralRangeIntake.AdequateIntake > 0.0000 && mineralRangeIntake.UpperLevelOfIntake > 0.0000)
            {
                initialReport = "You provide " + mineralAmountFromDiet +
                                " mg\nYour body needs about " +
                                mineralRangeIntake.AdequateIntake + " mg\nMaximum daily dose is " +
                    mineralRangeIntake.UpperLevelOfIntake + " mg";
                if (mineralAmountFromDiet < mineralRangeIntake.AdequateIntake)
                    necessaryInformation = "\nYOU SUPPLY TOO LITTLE OF THIS MINERAL!";
                else if (mineralAmountFromDiet > mineralRangeIntake.UpperLevelOfIntake)
                    necessaryInformation = "\nYOU SUPPLY TOO MUCH OF THIS MINERAL!";
                else
                    necessaryInformation = "\nYOU SUPPLY THE CORRECT AMOUNT";

            }

            else if (mineralRangeIntake.UpperLevelOfIntake == 0.0000 && mineralRangeIntake.AdequateIntake == 0.0000)
            {
                initialReport = "You provide " + mineralAmountFromDiet + " mg\nYour body needs at least " +
                                mineralRangeIntake.EstimatedAverageRequirement + " mg\nRecommended value is " +
                                mineralRangeIntake.RecommendedDietaryIntake + " mg\nNo maximum dose specified " +
                                "from food";
                if (mineralAmountFromDiet < mineralRangeIntake.EstimatedAverageRequirement)
                    necessaryInformation = "\nYOU SUPPLY TOO LITTLE OF THIS MINERAL!";
                else
                    necessaryInformation = "\nYOU SUPPLY THE CORRECT AMOUNT";
            }

            percentage = mineralRangeIntake.AdequateIntake > 0.00000
                ? ((mineralAmountFromDiet * 100.0) / mineralRangeIntake.AdequateIntake)
                : ((mineralAmountFromDiet * 100.0) / mineralRangeIntake.RecommendedDietaryIntake);

            report = initialReport + necessaryInformation;
            return report;
        }

        public string PhosphorusReport { get; set; } 
        public string PotassiumReport { get; set; }
        public string SodiumReport { get; set; } 
        public string CalciumReport { get; set; }
        public string IronReport { get; set; }
        public string MagnesiumReport { get; set; }
        public string ZincReport { get; set; }
        public string CopperReport { get; set; }
        public string SeleniumReport { get; set; }


        public double PhosphorusPercentage { get; set; }
        public double PotassiumPercentage { get; set; }
        public double SodiumPercentage { get; set; }
        public double CalciumPercentage { get; set; }
        public double IronPercentage { get; set; }
        public double MagnesiumPercentage { get; set; }
        public double ZincPercentage { get; set; }
        public double CopperPercentage { get; set; }
        public double SeleniumPercentage { get; set; }
    }
}
