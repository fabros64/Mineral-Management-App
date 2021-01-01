using System;
using System.Collections.Generic;
using System.Text;

namespace Mineral_Management.Models
{
    public class Person
    {
        public AgeRange Age { get; set; }
        public Gender Gender { get; set; }

        public Person(Gender gender, int age)
        {
            Gender = gender;

            Age = (age >= 1 && age <= 3) ? AgeRange.OneThree : (age >= 4 && age <= 8) ? AgeRange.FourEight :
                (age >= 9 && age <= 13) ? AgeRange.NineThirteen : (age >= 14 && age <= 18) ? AgeRange.FourteenEighteen :
                (age >= 19 && age <= 30) ? AgeRange.NineteenThirty : (age >= 31 && age <= 50) ? AgeRange.ThirtyoneFifty :
                (age >= 51 && age <= 70) ? AgeRange.FiftyoneSeventy : AgeRange.AboveSeventy;
        }
    }

    public enum Gender
    {
        Man,
        Woman
    }

    public enum AgeRange
    {
        OneThree,
        FourEight,
        NineThirteen,
        FourteenEighteen,
        NineteenThirty,
        ThirtyoneFifty,
        FiftyoneSeventy,
        AboveSeventy
    }


            //    if (age >= 1 && age <= 3)
            //    Age = AgeRange.OneThree;
            //else if (age >= 4 && age <= 8)
            //    Age = AgeRange.FourEight;
            //else if (age >= 9 && age <= 13)
            //    Age = AgeRange.NineThirteen;
            //else if (age >= 14 && age <= 18)
            //    Age = AgeRange.FourteenEighteen;
            //else if (age >= 19 && age <= 30)
            //    Age = AgeRange.NineteenThirty;
            //else if (age >= 31 && age <= 50)
            //    Age = AgeRange.ThirtyoneFifty;
            //else if (age >= 51 && age <= 70)
            //    Age = AgeRange.FiftyoneSeventy;
            //else if (age > 70)
            //    Age = AgeRange.AboveSeventy;

}
