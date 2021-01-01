using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mineral_Management.Models
{
    public class DailyDietSumOfMinerals
    {
        public DailyDietSumOfMinerals(List<DailyDietProduct> dailyDietProducts, List<Product> products)
        {
            MineralsSumCalculate(dailyDietProducts, products);
        }

        private void MineralsSumCalculate(List<DailyDietProduct> dailyDietProducts, List<Product> products)
        {
            foreach(var dailyDietProduct in dailyDietProducts)
            {
                Product product = products.Where((Product arg) => arg.ProductId == dailyDietProduct.ProductId).FirstOrDefault();
                PhosphorusTotal += (dailyDietProduct.Amount / 100.0) * product.Minerals.Phosphorus;
                PotassiumTotal += (dailyDietProduct.Amount / 100.0) * product.Minerals.Potassium;
                SodiumTotal += (dailyDietProduct.Amount / 100.0) * product.Minerals.Sodium;
                CalciumTotal += (dailyDietProduct.Amount / 100.0) * product.Minerals.Calcium;
                IronTotal += (dailyDietProduct.Amount / 100.0) * product.Minerals.Iron;
                MagnesiumTotal += (dailyDietProduct.Amount / 100.0) * product.Minerals.Magnesium;
                ZincTotal += (dailyDietProduct.Amount / 100.0) * product.Minerals.Zinc;
                CopperTotal += (dailyDietProduct.Amount / 100.0) * product.Minerals.Copper;
                SeleniumTotal += (dailyDietProduct.Amount / 100.0) * product.Minerals.Selenium;
            }
        }

        public double PhosphorusTotal { get; set; } = 0; // Suma fosforu z diety
        public double PotassiumTotal { get; set; } = 0; // Suma potasu z diety
        public double SodiumTotal { get; set; } = 0; // Suma sodu z diety
        public double CalciumTotal { get; set; } = 0; // Suma wapnia z diety
        public double IronTotal { get; set; } = 0; // Suma żelaza z diety
        public double MagnesiumTotal { get; set; } = 0; // Suma magnezu z diety
        public double ZincTotal { get; set; } = 0; // Suma cynku z diety
        public double CopperTotal { get; set; } = 0; // Suma miedzi z diety
        public double SeleniumTotal { get; set; } = 0; // Suma selenu z diety

    }
}
