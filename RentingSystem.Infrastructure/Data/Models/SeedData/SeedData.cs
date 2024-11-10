using Microsoft.AspNetCore.Identity;

namespace RentingSystem.Infrastructure.Data.Models.SeedData
{
    internal class SeedData
    {
        public IdentityUser DealerUser { get; set; }

        public IdentityUser GuestUser { get; set; }

        public IdentityUser AdminUser { get; set; }

        public Dealer Dealer { get; set; }

        public Category Sedan { get; set; }

        public Category Hatchback { get; set; }

        public Category StationWagonan { get; set; }
        public Category Coupe { get; set; }
        public Category Convertible { get; set; }
        public Category Jeep { get; set; }
        public Category Pickup { get; set; }

        public Car FirstCar { get; set; }

        public Car SecondCar { get; set; }

        public Car ThirdCar { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedDealer();
            SeedCategories();
            SeedCars();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            DealerUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "dealer@mail.com",
                NormalizedUserName = "DEALER@MAIL.COM",
                Email = "dealer@mail.com",
                NormalizedEmail = "DEALER@MAIL.COM",
            };


            DealerUser.PasswordHash =
                 hasher.HashPassword(DealerUser, "dealer123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "GUEST@MAIL.COM",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",

            };

            GuestUser.PasswordHash =
            hasher.HashPassword(GuestUser, "guest123");

            AdminUser = new IdentityUser()
            {
                Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
            };

            AdminUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedDealer()
        {
            Dealer = new Dealer()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = DealerUser.Id
            };

        }

        private void SeedCategories()
        {
            Sedan = new Category()
            {
                Id = 1,
                Name = "Sedan"
            };

            Hatchback = new Category()
            {
                Id = 2,
                Name = "Hatchback"
            };

            StationWagonan = new Category()
            {
                Id = 3,
                Name = "Station-Wagonan"
            };

            Coupe = new Category()
            {
                Id = 4,
                Name = "Coupe"
            };

            Convertible = new Category()
            {
                Id = 5,
                Name = "Convertible"
            };

            Jeep = new Category()
            {
                Id = 6,
                Name = "Jeep"
            };

            Pickup = new Category()
            {
                Id = 7,
                Name = "Pickup"
            };
        }

        private void SeedCars()
        {
            FirstCar = new Car()
            {
                Id = 1,
                Title = "VW Arteon R-line SB 4MOTION",
                Make = "VW",
                Model = "Arteon",
                Year = 2022,
                Shift = "Automatic",
                Seat = 5,
                FuelType = "Diesel",
                Description = "\"App Connect Wireless\"\r\n\r\n\"DIGITAL COCKPIT  PRO 10,25 inch\"\r\n\r\n\"Dynamic Light Assist\"\r\n\r\n\"Emergency call\"\r\n\r\n\"Keyless Access\"\r\n\r\n\"Lane Assist\"\r\n\r\n\"Rear view\"\r\n",
                ImageUrl = "https://office.dlrent.bg/storage/resources_type_images/456aa4ea12ecdd64705f6ef97d993f74.webp",
                PricePerDay = 100.00M,
                CategoryId = StationWagonan.Id,
                DealerId = Dealer.Id,
                RenterId = GuestUser.Id,
                IsApproved = true
            };

            SecondCar = new Car()
            {
                Id = 2,
                Title = "HUYNDAI i 10",
                Make = "HUYNDAI",
                Model = "i 10",
                Year = 2024,
                Shift = "Automatic",
                Seat = 5,
                FuelType = "Gasoline",
                Description = "The Hyundai i10 is a compact city car known for its practicality, efficiency, and maneuverability, making it ideal for urban driving. Despite its small size, the i10 offers a surprisingly spacious interior with seating for up to five passengers and ample headroom and legroom for a car in its class. It comes equipped with modern features, including a touchscreen infotainment system with smartphone connectivity, advanced safety systems, and efficient engine options that prioritize fuel economy. With its easy handling and compact dimensions, the Hyundai i10 is well-suited for navigating crowded city streets and tight parking spaces, making it a popular choice for city dwellers and young drivers alike.",
                ImageUrl = "https://office.dlrent.bg/storage/resources_type_images/ac39aadf98d02e09e18d87d723f237eb.webp",
                PricePerDay = 80.00M,
                CategoryId = Hatchback.Id,
                DealerId = Dealer.Id,
                IsApproved = true
            };

            ThirdCar = new Car()
            {
                Id = 3,
                Title = "VW T-Roc R-line 4MOTION",
                Make = "VW",
                Model = "T-Roc",
                Year = 2022,
                Shift = "Automatic",
                Seat = 5,
                FuelType = "Diesel",
                Description = "App Connect\"\r\n\r\n\"DIGITAL COCKPIT  PRO 10,25 inch\"\r\n\r\n\"Emergency call\"\r\n\r\n\"Keyless Access\"\r\n\r\n\"Lane Assist\"\r\n\r\n\"Light Assist\"\r\n\r\n\"Rear view\"",
                ImageUrl = "https://office.dlrent.bg/storage/resources_type_images/1975152798fef78ef132f1744fe82c59.webp",
                PricePerDay = 120.00M,
                CategoryId = Jeep.Id,
                DealerId = Dealer.Id,
                IsApproved = true
            };
        }

    }
}
