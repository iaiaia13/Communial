using NetCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreData
{
    public static class DataContextSeed
    {
        public static async Task SeedOffices(DataContext context)
        {
            var guid1 = Guid.NewGuid().ToString();
            var guid2 = Guid.NewGuid().ToString();

            // Seed, if necessary
            if (!context.Office.Any())
            {
                context.Office.AddRange(new Office
                {
                    ID = guid1,
                    Image = "img/offices/1.jpg",
                    Address = "Dist.1, Ho Chi Minh city, Vietnam",
                    Name = "Mapple Tree",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Capacity = 20,
                    PricePerMonth = 35000000,
                    Start = 4
                }, new Office
                {
                    ID = guid2,
                    Image = "img/offices/1.jpg",
                    Address = "Dist.Binh Thanh, Ho Chi Minh city, Vietnam",
                    Name = "LankMark 81",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Capacity = 40,
                    PricePerMonth = 20000000,
                    Start = 4
                });
            }

            // Seed, if necessary
            if (!context.OfficeRenting.Any())
            {
                context.OfficeRenting.AddRange(new OfficeRenting
                {
                    OfficeID = guid1,
                    Price = 35000000,
                    FromDate = DateTime.Now,
                    ToDate = DateTime.Now.AddMonths(1)
                }, new OfficeRenting
                {
                    OfficeID = guid1,
                    Price = 5000000,
                    FromDate = DateTime.Now.AddMonths(-3),
                    ToDate = DateTime.Now.AddMonths(-2)
                });
            }

            await context.SaveChangesAsync();
        }
    }
}