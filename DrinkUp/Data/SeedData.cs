using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DrinkUp.Data;
using System;
using System.Linq;
using DrinkUp.Models;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DrinkUpContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DrinkUpContext>>()))
            {
                // Look for any coffee.
                if (context.Coffee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Coffee.AddRange(
                    new Coffee
                    {
                        CoffeeName = "Caffe Americano",
                        Description = "Espresso shots topped with hot water create a light layer of crema culminating in this wonderfully rich cup with depth and nuance.",
                        CoffeeType = "Hot Coffee",
                        Caffiene = true
                    },

                    new Coffee
                    {
                        CoffeeName = "Blonde Roast",
                        Description = "Lightly roasted coffee that's soft, mellow and flavorful. Easy-drinking on its own and delicious with milk, sugar or flavored with vanilla, caramel or hazelnut.",
                        CoffeeType = "Hot Coffee",
                        Caffiene = true
                    },

                    new Coffee
                    {
                        CoffeeName = "Blonde Roast",
                        Description = "Lightly roasted coffee that's soft, mellow and flavorful. Easy-drinking on its own and delicious with milk, sugar or flavored with vanilla, caramel or hazelnut.",
                        CoffeeType = "Hot Coffee",
                        Caffiene = true
                    }

                ) ; 
                context.SaveChanges();
            }
        }
    }
}