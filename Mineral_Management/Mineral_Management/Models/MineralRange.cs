using System;
using System.Collections.Generic;
using System.Text;

namespace Mineral_Management.Models
{
    public class MineralRange
    {
        public MineralRange(double ear, double rdi, double ul)
        {
            EstimatedAverageRequirement = ear;
            RecommendedDietaryIntake = rdi;
            UpperLevelOfIntake = ul;
        }

        public MineralRange(double ai, double ul=0)
        {
            AdequateIntake = ai;
            UpperLevelOfIntake = ul;
        }
        public double EstimatedAverageRequirement { get; set; }
        public double RecommendedDietaryIntake { get; set; }
        public double UpperLevelOfIntake { get; set; }
        public double AdequateIntake { get; set; }
    }
}
