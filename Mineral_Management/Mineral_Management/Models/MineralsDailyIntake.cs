using System;
using System.Collections.Generic;
using System.Text;

namespace Mineral_Management.Models
{
    public class MineralsDailyIntake
    {
        public MineralRange Phosphorus { get; set; } 
        public MineralRange Potassium { get; set; } 
        public MineralRange Sodium { get; set; } 
        public MineralRange Calcium { get; set; } 
        public MineralRange Iron { get; set; } 
        public MineralRange Magnesium { get; set; } 
        public MineralRange Zinc { get; set; } 
        public MineralRange Copper { get; set; } 
        public MineralRange Selenium { get; set; } 
    }
}
