using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DrinkUp.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DrinkUp.Models
{
    public static class SeedData
    {
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DrinkUpContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DrinkUpContext>>()))
            {
                // Look for any teas.
                if (!context.Tea.Any())
                {
                    context.Tea.AddRange(
                        new Tea
                        {
                            TeaName = "Brooklyn Tea",
                            Discription = "An organic black tea blend with a twist. Brooklyn has a vibrant black tea base with high notes of Madagascar vanilla for a full-bodied, malty morning cup.",
                            TeaType = "Black",
                            TeaBrand = "Art Of Tea",
                            Organic = false,
                            Caffene = 'H',
                            BrewType = "Loose",
                            BrewTempC = 96,
                            BrewTime = 4,
                            Source = ""
                        },

                        new Tea
                        {
                            TeaName = "6:00 PM Tea",
                            Discription = "Immerse yourself into a cup of this inviting loose leaf chamomile infused blend. 6:00 pm steeps a floral cup with a thin liquor and a sweet and spicy character. The perfect answer to your evening tea needs.",
                            TeaType = "Herbal",
                            TeaBrand = "Art Of Tea",
                            Organic = true,
                            Caffene = 'N',
                            BrewType = "Loose",
                            BrewTempC = 96,
                            BrewTime = 4,
                            Source = ""
                        },
                        new Tea
                        {
                            TeaName = "Mint Matcha Superfood Green Tea Powder",
                            Discription = "Indulge in a revitalizing Matcha green tea blend that brings you a soothing cup of natural goodness! The dry Mint Matcha green tea powder is of a bright, light-green color ; along with a earthy and minty aroma that fills the air. The brewed matcha tea is full-bodied and has a deep dark-green color. The cup starts with fresh vegetal notes of the pure Japanese matcha, joined by the discernible, cooling and invigorating notes of Mint which travel into the finish as well. This matcha tea can be accompanied by a dollop of honey or it can enjoyed all by itself. Overall, a calming and enveloping cup of vitality.",
                            TeaType = "Matcha",
                            TeaBrand = "Vahdam",
                            Organic = false,
                            Caffene = 'L',
                            BrewType = "Powder",
                            BrewTempC = 90,
                            BrewTime = 0,
                            Source = "Farms in Shizouka, Japan and India"
                        }/*,
                        new Tea
                        {
                            TeaName = "",
                            Discription = "",
                            TeaType = "",
                            TeaBrand = "",
                            Organic = ,
                            Caffene = '',
                            BrewType = "",
                            BrewTempC = ,
                            BrewTime = ,
                            Source = ""
                        },
                        new Tea
                        {
                            TeaName = "",
                            Discription = "",
                            TeaType = "",
                            TeaBrand = "",
                            Organic = ,
                            Caffene = '',
                            BrewType = "",
                            BrewTempC = ,
                            BrewTime = ,
                            Source = ""
                        }
                        */
                    );
                    context.SaveChanges();
                }

                List<int> teaIDList = new List<int>();
                foreach(Tea theTea in context.Tea)
                {
                    teaIDList.Add(theTea.TeaID);
                }


                // Look for any teas.
                if (!context.TeaIngredient.Any())
                {
                    context.TeaIngredient.AddRange(
                        new TeaIngredient
                        {
                            IngredientName = "Organic Black Tea"
                        },
                        new TeaIngredient
                        {
                            IngredientName = "Cornflowers"
                        },
                        new TeaIngredient
                        {
                            IngredientName = "Organic Marigolds"
                        },
                        new TeaIngredient
                        {
                            IngredientName = "Natural Flavors"
                        },
                        new TeaIngredient
                        {
                            IngredientName = "Organic Chamomile"
                        },
                        new TeaIngredient
                        {
                            IngredientName = "Orgnic Lavender"
                        },
                        new TeaIngredient
                        {
                            IngredientName = "Organic Rosehips"
                        },
                        new TeaIngredient
                        {
                            IngredientName = "Organic Pink Peppercorn"
                        },
                        new TeaIngredient
                        {
                            IngredientName = "Matcha Green Tea Powder"
                        },
                        new TeaIngredient
                        {
                            IngredientName = "Mint Extracts"
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.TeaIngredientLink.Any())
                {
                    List<int> teaIngredientIDList = new List<int>();
                    foreach (TeaIngredient objectt in context.TeaIngredient)
                    {
                        teaIngredientIDList.Add(objectt.TeaIngredientID);
                    }

                    context.TeaIngredientLink.AddRange(
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[0],
                            TeaIngredientID = teaIngredientIDList[0]
                        },
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[0],
                            TeaIngredientID = teaIngredientIDList[1]
                        },
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[0],
                            TeaIngredientID = teaIngredientIDList[2]
                        },
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[0],
                            TeaIngredientID = teaIngredientIDList[3]
                        },
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[1],
                            TeaIngredientID = teaIngredientIDList[4]
                        },
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[1],
                            TeaIngredientID = teaIngredientIDList[5]
                        },
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[1],
                            TeaIngredientID = teaIngredientIDList[6]
                        },
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[1],
                            TeaIngredientID = teaIngredientIDList[7]
                        },
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[2],
                            TeaIngredientID = teaIngredientIDList[8]
                        },
                        new TeaIngredientLink
                        {
                            TeaId = teaIDList[2],
                            TeaIngredientID = teaIngredientIDList[9]
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.TeaStore.Any())
                {
                    context.TeaStore.AddRange(
                        new TeaStore
                        {
                            Name = "Art Of Tea",
                            Url = "https://www.artoftea.com/products/brooklyn"
                        },
                        new TeaStore
                        {
                            Name = "Art Of Tea",
                            Url = "https://www.artoftea.com/products/6pm"
                        },
                        new TeaStore
                        {
                            Name = "Vahdam",
                            Url = "https://www.vahdamteas.com/products/mint-matcha-green-tea?_pos=1&_sid=fd4ef41a3&_ss=r&variant=16903226294315"
                        },
                        new TeaStore
                        {
                            Name = "Amazon",
                            Url = ""
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.TeaStoreLink.Any())
                {
                    List<int> IDList = new List<int>();
                    foreach (TeaStore objectt in context.TeaStore)
                    {
                        IDList.Add(objectt.TeaStoreID);
                    }

                    context.TeaStoreLink.AddRange(
                        new TeaStoreLink
                        {
                            TeaId = teaIDList[0],
                            TeaStoreId = IDList[0]
                        },
                        new TeaStoreLink
                        {
                            TeaId = teaIDList[1],
                            TeaStoreId = IDList[1]
                        },
                        new TeaStoreLink
                        {
                            TeaId = teaIDList[2],
                            TeaStoreId = IDList[2]
                        },
                        new TeaStoreLink
                        {
                            TeaId = teaIDList[2],
                            TeaStoreId = IDList[3]
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.TeaTags.Any())
                {
                    context.TeaTags.AddRange(
                        new TeaTags
                        {
                            Tag = "vanilla"
                        },
                        new TeaTags
                        {
                            Tag = "full-bodied"
                        },
                        new TeaTags
                        {
                            Tag = "malty"
                        },
                        new TeaTags
                        {
                            Tag = "floral"
                        },
                        new TeaTags
                        {
                            Tag = "sweet and spicy"
                        },
                        new TeaTags
                        {
                            Tag = "earthy"
                        },
                        new TeaTags
                        {
                            Tag = "minty"
                        },
                        new TeaTags
                        {
                            Tag = "vegital"
                        },
                        new TeaTags
                        {
                            Tag = "cooling"
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.TeaTagsLink.Any())
                {
                    List<int> IDList = new List<int>();
                    foreach (TeaTags objectt in context.TeaTags)
                    {
                        IDList.Add(objectt.TeaTagID);
                    }

                    context.TeaTagsLink.AddRange(
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[0],
                            TeaTagID = IDList[0]
                        },
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[0],
                            TeaTagID = IDList[1]
                        },
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[0],
                            TeaTagID = IDList[2]
                        },
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[1],
                            TeaTagID = IDList[3]
                        },
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[1],
                            TeaTagID = IDList[4]
                        },
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[2],
                            TeaTagID = IDList[1]
                        },
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[2],
                            TeaTagID = IDList[5]
                        },
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[2],
                            TeaTagID = IDList[6]
                        },
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[2],
                            TeaTagID = IDList[7]
                        },
                        new TeaTagsLink
                        {
                            TeaId = teaIDList[2],
                            TeaTagID = IDList[8]
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}