using System;
using System.Collections.Generic;
using System.Text;
using BeetrootModels.Context;
using BeetrootModels.DbModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BeetrooModels.Context
{
    public static class BeetrootDbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BeetrootDbContext>();

                context.Cars.AddRange(
                new Car()
                {
                    Name = "Audi",
                    Year = "1900"
                },
                new Car()
                {
                    Name = "BMW",
                    Year = "1900"
                },
                new Car()
                {
                    Name = "KIA",
                    Year = "1900"
                },
                new Car()
                {
                    Name = "Ford",
                    Year = "1900"
                },
                new Car()
                {
                    Name = "Mercedes",
                    Year = "1900"
                });

                context.Services.AddRange(
                new Service()
                {
                    Name = "Transmission"
                },
                new Service()
                {
                    Name = "Maintenance"
                },
                new Service()
                {
                    Name = "Repair"
                },
                new Service()
                {
                    Name = "Other"
                });

                context.OrderServices.AddRange(
                new OrderService()
                {
                    OrderId = 1,
                    ServiceId = 1
                },
                new OrderService()
                {
                    OrderId = 1,
                    ServiceId = 2
                },
                new OrderService()
                {
                    OrderId = 1,
                    ServiceId = 3
                },
                new OrderService()
                {
                    OrderId = 2,
                    ServiceId = 2
                },
                new OrderService()
                {
                    OrderId = 3,
                    ServiceId = 1
                },
                new OrderService()
                {
                    OrderId = 3,
                    ServiceId = 4
                });

                context.PersonInfos.AddRange(
                new PersonalInfo()
                {
                    FirstName = "Ivan",
                    SecondName = "Ivanov",
                    Phone = "9999999999",
                    Email = "ivan@gmail.com"
                },
                new PersonalInfo()
                {
                    FirstName = "Petr",
                    SecondName = "Petrov",
                    Phone = "8888888888",
                    Email = "petr@gmail.com"
                },
                new PersonalInfo()
                {
                    FirstName = "Alex",
                    SecondName = "Sidorov",
                    Phone = "5555555555",
                    Email = "alex@gmail.com"
                });

                context.Orders.AddRange(new Order()
                {
                    DateFrom = new DateTime(2019, 1, 10, 13, 00, 00).ToString(),
                    DateTo = new DateTime(2019, 1, 17, 13, 00, 00).ToString(),
                    OrderDateCreate = DateTime.Now,
                    Message = "kds dfsd ffdkf gd",
                    CarId = 1,
                    PersonInfoId = 1,
                },
                new Order()
                {
                    DateFrom = new DateTime(2019, 2, 10, 13, 00, 00).ToString(),
                    DateTo = new DateTime(2019, 2, 17, 13, 00, 00).ToString(),
                    OrderDateCreate = DateTime.Now,
                    Message = "kdjghdk kdjfdkf gd",
                    CarId = 2,
                    PersonInfoId = 2,
                },
                new Order()
                {
                    DateFrom = new DateTime(2019, 3, 10, 13, 00, 00).ToString(),
                    DateTo = new DateTime(2019, 3, 17, 13, 00, 00).ToString(),
                    OrderDateCreate = DateTime.Now,
                    Message = "kdj 34343534 ghdk kdjfdkf gd",
                    CarId = 3,
                    PersonInfoId = 3,
                },
                new Order()
                {
                    DateFrom = new DateTime(2019, 4, 10, 13, 00, 00).ToString(),
                    DateTo = new DateTime(2019, 4, 17, 13, 00, 00).ToString(),
                    OrderDateCreate = DateTime.Now,
                    Message = "kdjg  3332 23 2 hdk kdjfdkf gd",
                    CarId = 4,
                    PersonInfoId = 1,
                });

                context.SaveChanges();
            }
        }
    }
}
