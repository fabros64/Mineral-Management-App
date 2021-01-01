using System;
using System.Collections.Generic;
using System.Text;

namespace Mineral_Management.Models
{
    public class ChartMineral
    {
        public string Name { get; set; }
        public double Percentage { get; set; }
        public double Line { get; set; } = 100.0;

        public ChartMineral(string name, double percentage)
        {
            Name = name;
            Percentage = percentage;
        }
    }
}
