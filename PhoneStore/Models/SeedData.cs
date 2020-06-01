using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if(!context.Products.Any())
            {
                context.Products.AddRange
                (
                    new Product
                    {
                        Title = "Смартфон Irbis SP402B 4Gb Черный",
                        Description = "[4x1.3 ГГц, 512 МБ, 2 SIM, TN, 800x480, камера 5 Мп, 3G, GPS, FM, 1400 мА*ч]",
                        Category = "Смартфоны",
                        Price = 1399
                    },
                    new Product
                    {
                        Title = "Смартфон Digma HIT Q401 3G 8Gb Золотистый",
                        Description = "[4x1.3 ГГц, 1 ГБ, 2 SIM, TN, 800x480, камера 2 Мп, 3G, GPS, 1600 мА*ч]",
                        Category = "Смартфоны",
                        Price = 1499
                    },
                    new Product
                    {
                        Title = "Планшет Dexp Urbus S470 MIX 16Gb 3G Фиолетовый",
                        Description = "[1024x600, IPS, 4х1.3 ГГц, 1 ГБ, BT, GPS, 2800 мА*ч, Android 8.x+]",
                        Category = "Планшеты",
                        Price = 2999
                    },
                    new Product
                    {
                        Title = "Планшет Lenovo TB-7304I 16Gb Черный",
                        Description = "[1024x600, IPS, 4х1.1 ГГц, 1 ГБ, BT, GPS, 3450 мА*ч, Android 7.x+]",
                        Category = "Планшеты",
                        Price = 4999
                    },
                    new Product
                    {
                        Title = "Фитнес-браслет JET Sport FT-4C ремешок-черный",
                        Description = "[корпус - черный, iOS 7.1 и выше, Android 4.3 и выше, крепление - на руку, Bluetooth, IP54]",
                        Category = "Фитнес-браслеты",
                        Price = 999
                    },
                    new Product
                    {
                        Title = "Смарт-часы Dexp R1",
                        Description = "[корпус - черный, iOS, Android, крепление - на руку, Bluetooth, IP68]",
                        Category = "Смарт-часы",
                        Price = 1650
                    }
                );
                context.SaveChanges();
            }
        }
    }
}