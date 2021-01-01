using System;
using System.Collections.Generic;
using System.Text;

namespace Mineral_Management.Models
{
    public class PersonNutrientsDailyIntake
    {
        public MineralsDailyIntake MineralsDailyIntake { get; set; }

        public PersonNutrientsDailyIntake(Person person)
        {
            switch (person.Gender)
            {
                case Gender.Man:
                {
                    switch (person.Age)
                    { 
                        case AgeRange.OneThree:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(380, 460, 3000),
                                Potassium = new MineralRange(2000),
                                Sodium = new MineralRange(200, 1000),
                                Calcium = new MineralRange(360, 500, 2500),
                                Iron = new MineralRange(4,9,20),
                                Magnesium = new MineralRange(65,80,0),
                                Zinc = new MineralRange(2.5,3,7),
                                Copper = new MineralRange(0.7,1),
                                Selenium = new MineralRange(0.02,0.025, 0.09)
                            };
                            break;
                        }
                        case AgeRange.FourEight:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(405, 500, 3000),
                                Potassium = new MineralRange(2300),
                                Sodium = new MineralRange(300, 1400),
                                Calcium = new MineralRange(520, 700, 2500),
                                Iron = new MineralRange(4, 10, 40),
                                Magnesium = new MineralRange(110, 130, 0),
                                Zinc = new MineralRange(3, 4, 12),
                                Copper = new MineralRange(1, 3),
                                Selenium = new MineralRange(0.025, 0.030, 0.15)
                            };
                                    break;
                        }
                        case AgeRange.NineThirteen:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(1055, 1250, 4000),
                                Potassium = new MineralRange(3000),
                                Sodium = new MineralRange(400, 2000),
                                Calcium = new MineralRange(900, 1100, 2500),
                                Iron = new MineralRange(6, 8, 40),
                                Magnesium = new MineralRange(200, 240, 0),
                                Zinc = new MineralRange(5, 6, 25),
                                Copper = new MineralRange(1.3, 5),
                                Selenium = new MineralRange(0.04, 0.05, 0.28)
                            };
                                    break;
                        }
                        case AgeRange.FourteenEighteen:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(1055, 1250, 4000),
                                Potassium = new MineralRange(3600),
                                Sodium = new MineralRange(500, 2300),
                                Calcium = new MineralRange(1050, 1300, 2500),
                                Iron = new MineralRange(8, 11, 45),
                                Magnesium = new MineralRange(340, 410, 0),
                                Zinc = new MineralRange(11, 13, 35),
                                Copper = new MineralRange(1.5, 8),
                                Selenium = new MineralRange(0.06, 0.07, 0.4)
                            };
                                    break;
                        }
                        case AgeRange.NineteenThirty:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(580, 1000, 4000),
                                Potassium = new MineralRange(3800),
                                Sodium = new MineralRange(575, 2300),
                                Calcium = new MineralRange(840, 1000, 2500),
                                Iron = new MineralRange(6, 8, 45),
                                Magnesium = new MineralRange(330, 400, 0),
                                Zinc = new MineralRange(12, 14, 40),
                                Copper = new MineralRange(1.7, 10),
                                Selenium = new MineralRange(0.06, 0.07, 0.4)
                            };
                                    break;
                        }
                        case AgeRange.ThirtyoneFifty:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(580, 1000, 4000),
                                Potassium = new MineralRange(3800),
                                Sodium = new MineralRange(575, 2300),
                                Calcium = new MineralRange(840, 1000, 2500),
                                Iron = new MineralRange(6, 8, 45),
                                Magnesium = new MineralRange(350, 420, 0),
                                Zinc = new MineralRange(12, 14, 40),
                                Copper = new MineralRange(1.7, 10),
                                Selenium = new MineralRange(0.06, 0.07, 0.4)
                            };
                                    break;
                        }
                        case AgeRange.FiftyoneSeventy:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(580, 1000, 4000),
                                Potassium = new MineralRange(3800),
                                Sodium = new MineralRange(575, 2300),
                                Calcium = new MineralRange(840, 1000, 2500),
                                Iron = new MineralRange(6, 8, 45),
                                Magnesium = new MineralRange(350, 420, 0),
                                Zinc = new MineralRange(12, 14, 40),
                                Copper = new MineralRange(1.7, 10),
                                Selenium = new MineralRange(0.06, 0.07, 0.4)
                            };
                                    break;
                        }
                        case AgeRange.AboveSeventy:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(580, 1000, 3000),
                                Potassium = new MineralRange(3800),
                                Sodium = new MineralRange(575, 2300),
                                Calcium = new MineralRange(1100, 1300, 2500),
                                Iron = new MineralRange(6, 8, 45),
                                Magnesium = new MineralRange(350, 420, 0),
                                Zinc = new MineralRange(12, 14, 40),
                                Copper = new MineralRange(1.7, 10),
                                Selenium = new MineralRange(0.06, 0.07, 0.4)
                            };
                                    break;
                        }
                    }
                    break;
                }

                case Gender.Woman:
                {
                    switch (person.Age)
                    {
                        case AgeRange.OneThree:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(380, 460, 3000),
                                Potassium = new MineralRange(2000),
                                Sodium = new MineralRange(200, 1000),
                                Calcium = new MineralRange(360, 500, 2500),
                                Iron = new MineralRange(4, 9, 20),
                                Magnesium = new MineralRange(65, 80, 0),
                                Zinc = new MineralRange(2.5, 3, 7),
                                Copper = new MineralRange(0.7, 1),
                                Selenium = new MineralRange(0.02, 0.025, 0.09)
                            };
                                    break;
                        }
                        case AgeRange.FourEight:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(405, 500, 3000),
                                Potassium = new MineralRange(2300),
                                Sodium = new MineralRange(300, 1400),
                                Calcium = new MineralRange(520, 700, 2500),
                                Iron = new MineralRange(4, 10, 40),
                                Magnesium = new MineralRange(110, 130, 0),
                                Zinc = new MineralRange(3, 4, 12),
                                Copper = new MineralRange(1, 3),
                                Selenium = new MineralRange(0.025, 0.030, 0.15)
                            };
                                    break;
                        }
                        case AgeRange.NineThirteen:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(1055, 1250, 4000),
                                Potassium = new MineralRange(2500),
                                Sodium = new MineralRange(400, 2000),
                                Calcium = new MineralRange(900, 1100, 2500),
                                Iron = new MineralRange(6, 8, 40),
                                Magnesium = new MineralRange(200,240, 0),
                                Zinc = new MineralRange(5, 6, 25),
                                Copper = new MineralRange(1.1, 5),
                                Selenium = new MineralRange(0.04, 0.05, 0.28)
                            };
                                    break;
                        }
                        case AgeRange.FourteenEighteen:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(1055, 1250, 4000),
                                Potassium = new MineralRange(2600),
                                Sodium = new MineralRange(460, 2300),
                                Calcium = new MineralRange(1050, 1300, 2500),
                                Iron = new MineralRange(8, 15, 45),
                                Magnesium = new MineralRange(300, 360, 0),
                                Zinc = new MineralRange(6, 7, 35),
                                Copper = new MineralRange(1.1, 8),
                                Selenium = new MineralRange(0.05, 0.06, 0.4)
                            };
                                    break;
                        }
                        case AgeRange.NineteenThirty:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(580, 1000, 4000),
                                Potassium = new MineralRange(2800),
                                Sodium = new MineralRange(575, 2300),
                                Calcium = new MineralRange(840, 1000, 2500),
                                Iron = new MineralRange(8, 18, 45),
                                Magnesium = new MineralRange(255, 310, 0),
                                Zinc = new MineralRange(6.5, 8, 40),
                                Copper = new MineralRange(1.2, 10),
                                Selenium = new MineralRange(0.05, 0.06, 0.4)
                            };
                                    break;
                        }
                        case AgeRange.ThirtyoneFifty:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(580, 1000, 4000),
                                Potassium = new MineralRange(2800),
                                Sodium = new MineralRange(575, 2300),
                                Calcium = new MineralRange(840, 1000, 2500),
                                Iron = new MineralRange(8, 18, 45),
                                Magnesium = new MineralRange(265, 320, 0),
                                Zinc = new MineralRange(6.5, 8, 40),
                                Copper = new MineralRange(1.2, 10),
                                Selenium = new MineralRange(0.05, 0.06, 0.4)
                            };
                                    break;
                        }
                        case AgeRange.FiftyoneSeventy:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(580, 1000, 4000),
                                Potassium = new MineralRange(2800),
                                Sodium = new MineralRange(575, 2300),
                                Calcium = new MineralRange(1100, 1300, 2500),
                                Iron = new MineralRange(5, 8, 45),
                                Magnesium = new MineralRange(265, 320, 0),
                                Zinc = new MineralRange(6.5, 8, 40),
                                Copper = new MineralRange(1.2, 10),
                                Selenium = new MineralRange(0.05, 0.06, 0.4)
                            };
                                    break;
                        }
                        case AgeRange.AboveSeventy:
                        {
                            MineralsDailyIntake = new MineralsDailyIntake
                            {
                                Phosphorus = new MineralRange(580, 1000, 3000),
                                Potassium = new MineralRange(2800),
                                Sodium = new MineralRange(575, 2300),
                                Calcium = new MineralRange(1100, 1300, 2500),
                                Iron = new MineralRange(5, 8, 45),
                                Magnesium = new MineralRange(265, 320, 0),
                                Zinc = new MineralRange(6.5, 8, 40),
                                Copper = new MineralRange(1.2, 10),
                                Selenium = new MineralRange(0.05, 0.06, 0.4)
                            };
                                    break;
                        }
                    }
                        break;
                }
            }
        }

    }


}
