using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Mineral_Management.Consts
{
    // Wartości przybliżone i uśrednione - dla osób dorosłych - według kilku oficjalnych wytycznych
    public static class AcceptableDailyIntakeOfMinerals 
    {
        public const double PhosphorusMin = 600; // Najniższy poziom dopuszczalnego spożycia fosforu w mg
        public const double PhosphorusMax = 4000; // Górny tolerowany poziom spożycia fosforu w mg

        //public const double PotassiumDangerousMin = 1600; // Najniższy niebezpieczny poziom spożycia potasu w mg 
        public const double PotassiumSafeMin = 3500;  // Najniższy bezpiecny poziom dopuszczalnego spożycia potasu w mg
        // potas z żywności nie ma dopuszczalnego górnego poziomu spożycia.

        public const double SodiumMin = 575;  // Najniższy poziom dopuszczalnego spożycia sodu w mg
        public const double SodiumMax = 2300; // Górny tolerowany poziom spożycia sodu w mg

        public const double CalciumMin = 600;  // Najniższy poziom dopuszczalnego spożycia wapnia w mg
        public const double CalciumMax = 2500; // Górny tolerowany poziom spożycia wapnia w mg

        public const double IronMinMan = 8; // Najniższy poziom dopuszczalnego spożycia żelaza dla mężczyzn w mg 
        public const double IronMinWoman = 18; // Najniższy poziom dopuszczalnego spożycia żelaza dla kobiet w mg
        //public const double IronMin = 18; // Najniższy poziom dopuszczalnego spożycia żelaza w mg 
        public const double IronMax = 45; // Górny tolerowany poziom spożycia żelaza w mg

        public const double MagnesiumMinMan = 400;  // Najniższy poziom dopuszczalnego spożycia magnezu dla mężczyzn w mg
        public const double MagnesiumMinWoman = 300; // Najniższy poziom dopuszczalnego spożycia magnezu dla kobiet w mg
        //Nadmiar magnezu występuje rzadko, ponieważ nasz organizm dobrze toleruje nawet wysokie dawki.

        public const double ZincMinMan = 11; // Najniższy poziom dopuszczalnego spożycia żelaza dla mężczyzn w mg
        public const double ZincMinWoman = 8; // Najniższy poziom dopuszczalnego spożycia żelaza dla kobiet w mg
        public const double ZincMax = 40; // Górny tolerowany poziom spożycia cynku w mg

        public const double CopperMin = 0.9; // miedź
        public const double CopperMax = 10; //

        public const double SeleniumMin = 0.05; // Najniższy poziom dopuszczalnego spożycia selenu w mg
        public const double SeleniumMax = 0.4; // Górny tolerowany poziom spożycia selenu w mg

        // Jod, chlor, fluor...
    }
}
