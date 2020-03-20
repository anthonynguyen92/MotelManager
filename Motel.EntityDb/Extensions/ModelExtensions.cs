using Microsoft.EntityFrameworkCore;
using Motel.EntityDb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.EntityDb.Extensions
{
    public static class ModelExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var manager = new Manager
            {
                ID = Guid.NewGuid(),
                Birthday = Convert.ToDateTime("5/5/1999"),
                FirstName = "Anthony",
                Lastname = "Nguyen",
                Username = "Duong",
                Password = "Thuythuy1",
            };
            builder.Entity<Manager>().HasData(manager);

            var customer = new Customer
            {
                Address = "Ho Chi Minh",
                Birthdate = Convert.ToDateTime("11/12/1998"),
                Email = "Duongthuy111298@gmail.com",
                FirstName = "Thuy",
                LastName = "Duong Thi Thu",
                Identification = "183218131",
                IDuser = Guid.NewGuid(),
                PhoneNumber = "0963902609",
                
            };
            builder.Entity<Customer>().HasData(customer);

            var motel = new MotelRoom
            {
                Area = 123,
                BedRoom = 1,
                id = Guid.NewGuid(),
                NameRoom = "Anthony's Room",
                Payment = 12,
                Status = true,
                Toilet = 1,
            };
            builder.Entity<MotelRoom>().HasData(motel);

            var rent = new Rent
            {
                IdRent = Guid.NewGuid(),
                Start = DateTime.Today,
            };
            builder.Entity<Rent>().HasData(rent);

            var infor = new InforBill
            {
                ElectricBill = 1,
                Id = Guid.NewGuid(),
                MonthRent = 1,
                ParkingFee = 1,
                RoomBil = 1,
                WaterBill = 1,
                WifiBill = 1,
            };
            //builder.Entity<InforBill>().HasData(infor);
        }
    }
}
