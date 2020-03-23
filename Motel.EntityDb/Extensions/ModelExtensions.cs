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
            var customer = new Customer
            {
                Address = "Ho Chi Minh",
                Birthdate = Convert.ToDateTime("11/12/1998"),
                Email = "Duongthuy111298@gmail.com",
                FirstName = "Thuy",
                LastName = "Duong Thi Thu",
                Identification = "183218131",
                IDuser = "Test",
                PhoneNumber = "0963902609",
                
            };
            builder.Entity<Customer>().HasData(customer);

            var motel = new MotelRoom
            {
                Area = 123,
                BedRoom = 1,
                idMotel = 12,
                NameRoom = "Anthony's Room",
                Payment = 12,
                Status = true,
                Toilet = 1,
            };
            builder.Entity<MotelRoom>().HasData(motel);

            var rent = new Rent
            {
                IdRent = "Test2",
                Start = DateTime.Today,
            };
            builder.Entity<Rent>().HasData(rent);

            var bill = new InforBill()
            {
                ElectricBill = 1,
                IdInforBill = "test1",

                IdMotel = 12,

                MonthRent = 1,
                ParkingFee = 1,
                RoomBill = 1,
                WaterBill = 1,
                WifiBill = 1,
            };
            builder.Entity<InforBill>().HasData(bill);
        }
    }
}
