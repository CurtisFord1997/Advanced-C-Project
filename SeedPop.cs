using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DrinkUp.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DrinkUp.Models
{
    public static class SeedPop
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DrinkUpContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DrinkUpContext>>()))
            {
                // Look for any teas.
                if (!context.Pop.Any())
                {
                    context.Pop.AddRange(
                        new Pop
                        {
                            PopId = 1,
                            PopName = "Mtn Dew",
                            FruitFlavor = "Always Fruity",
                            Diet = "Diet Pop",
                            PackageType = "Bottled Pop",
                            PreferTemp = "Room Tempature",
                            Sugar = "Zero Sugar",
                            NumDrinkPerDay = 5
                        },

        
   

                        new Pop
                        {
                            PopId = 1,
                            PopName = "Dr Pepper",
                            FruitFlavor = "Never Fruity",
                            Diet = "Regular Pop",
                            PackageType = "Bottled Pop",
                            PreferTemp = "Ice Cold",
                            Sugar = "Zero Sugar",
                            NumDrinkPerDay = 2
                        },
                        new Pop
                        {
                            PopId = 1,
                            PopName = "Mtn Dew",
                            FruitFlavor = "Always Fruity",
                            Diet = "Diet Pop",
                            PackageType = "Canned Pop",
                            PreferTemp = "Slightly Chilled",
                            Sugar = "Sugar Added",
                            NumDrinkPerDay = 2
                        },
                        new Pop
                        {
                            PopId = 1,
                            PopName = "Mtn Dew",
                            FruitFlavor = "Always Fruity",
                            Diet = "Diet Pop",
                            PackageType = "Bottled Pop",
                            PreferTemp = "Room Tempature",
                            Sugar = "Zero Sugar",
                            NumDrinkPerDay = 5
                        }
                        
                    );
                    context.SaveChanges();
                }

                List<int> popIDList = new List<int>();
                foreach (Tea thePop in context.Tea)
                {
                    popIDList.Add(thePop.TeaID);
                }


               
            }
        }
    }
}