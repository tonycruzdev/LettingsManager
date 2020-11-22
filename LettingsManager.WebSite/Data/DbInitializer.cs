using LettingsManager.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LettingsManagerContext context, IWebHostEnvironment webHostEnvironment)
        {
            //context.Database.EnsureCreated();


            
            if (context.Landlords.Any())
            {
                return;   // DB has been seeded
            }
            var landlords = GetLandlord(webHostEnvironment);
            foreach (var land in landlords)
            {
                var l = new Landlord
                {
                    Name = land.Name,
                    Address1 = land.Address1,
                    Address2 = land.Address2,
                    Address3 = land.Address3,
                    Address4 = land.Address4,
                    Address5 = land.Address5,
                    Mobile = land.Mobile,
                    Email = land.Email
                };

                context.Landlords.Add(l);
            }
            
            context.SaveChanges();
           var houses = GetHouses(webHostEnvironment);
            foreach (var house in houses)
            {
                var h = new House
                {
                    Address1 = house.Address1,
                    Address2 = house.Address2,
                    Address3 = house.Address3,
                    Address4 = house.Address4,
                    Address5 = house.Address5,
                    Tenant1 = house.Tenant1,
                    Tenant2 = house.Tenant2,
                    DateFrom = house.DateFrom,
                    DateTo = house.DateTo,
                    LandlordId = house.LandlordId,
                    Rent = house.Rent,
                    Deposit = house.Deposit,
                    Mobile = house.Mobile,
                    Email = house.Email
                };
                context.Houses.Add(h);
            }

            context.SaveChanges();
        }
        public static IEnumerable<LandlordInfo> GetLandlord(IWebHostEnvironment webHostEnvironment)
        {
            string JsonFile = Path.Combine(webHostEnvironment.WebRootPath, "Data", "landlords.json");
            using (var jsonFileReader = File.OpenText(JsonFile))
            {
                return JsonSerializer.Deserialize<LandlordInfo[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public static IEnumerable<HouseInfo> GetHouses(IWebHostEnvironment webHostEnvironment)
        {
            string JsonFile = Path.Combine(webHostEnvironment.WebRootPath, "Data", "houses.json");
            using (var jsonFileReader = File.OpenText(JsonFile))
            {
                return JsonSerializer.Deserialize<HouseInfo[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
    
}
