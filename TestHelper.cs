using PremiumCalculatorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using PremiumCalculatorApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;

namespace PremiumCalculatorAppTest
{
    public static class TestHelper
    {
      
        public static User GetUser()
        {

            var userInfo = new User()
            {
                UserId = Guid.NewGuid(),
                Name = "TestUser1",
                Age = 75,
                DateOfBirth = Convert.ToDateTime(DateTime.ParseExact("12-04-1965", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                DeathSumInsured = 12.75M,
                OccupationId = 3,
                RatingId = 2,
                MonthlyPremium = 14.34375M
            };
            return userInfo;         
            
        }

        public static List<UserEditViewModal> GetUserEditViewModalData()
        {
            var userEdit = new List<UserEditViewModal>
        {
             new UserEditViewModal {UserId = Guid.NewGuid(),Name="TestUser1", Age = 75,
                                    DateOfBirth =Convert.ToDateTime(DateTime.ParseExact("12-04-1965", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                                    DeathSumInsured = 12.75M, SelectedOccupationId = 3},
             new UserEditViewModal {UserId = Guid.NewGuid(),Name="TestUser2", Age = 68,
                                    DateOfBirth =Convert.ToDateTime(DateTime.ParseExact("22-06-1955", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                                    DeathSumInsured = 22.50M, SelectedOccupationId = 2},
             new UserEditViewModal {UserId = Guid.NewGuid(),Name="TestUser3", Age = 55,
                                    DateOfBirth =Convert.ToDateTime(DateTime.ParseExact("08-11-1945", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                                    DeathSumInsured = 43.65M, SelectedOccupationId = 6},
             new UserEditViewModal {UserId = Guid.NewGuid(),Name="TestUser3", Age = 35,
                                    DateOfBirth =Convert.ToDateTime(DateTime.ParseExact("30-07-1987", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                                    DeathSumInsured = 36.80M, SelectedOccupationId = 4},
        };
            return userEdit;
        }

        public static UserEditViewModal GetUserEditViewModal()
        {
            var userEdit = new UserEditViewModal()
            {                
                Name = "TestUser1",
                Age = 75,
                DateOfBirth = Convert.ToDateTime(DateTime.ParseExact("12-04-1965", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                DeathSumInsured = 12.75M,
                SelectedOccupationId = 3               
            };
            return userEdit;
        }

        public static List<RatingFactor> GetRatingFactors()
        {
            var ratingFactor = new List<RatingFactor>
            {
                new RatingFactor
                {
                    RatingId = 1,
                    Rating = "Professional",
                    Factor = 1.00m
                },
                new RatingFactor
                {
                    RatingId = 2,
                    Rating = "White Collar",
                    Factor = 1.25m
                },
                 new RatingFactor
                 {
                     RatingId = 3,
                     Rating = "Light Manual",
                     Factor = 1.50m
                 },
                new RatingFactor
                {
                    RatingId = 4,
                    Rating = "Heavy Manual",
                    Factor = 1.75m
                }
            };
            return ratingFactor;
        }


        public static List<Occupation> GetOccupationList()
        {
            var OccupationList = new List<Occupation>
            {

                new Occupation
                {
                    OccupationId = 1,
                    OccupationName = "Cleaner",
                    RatingId = 3
                },
                new Occupation
                {
                    OccupationId = 2,
                    OccupationName = "Doctor",
                    RatingId = 1
                },
                new Occupation
                {
                    OccupationId = 3,
                    OccupationName = "Author",
                    RatingId = 2
                },
                new Occupation
                {
                    OccupationId = 4,
                    OccupationName = "Farmer",
                    RatingId = 4
                },
                new Occupation
                {
                    OccupationId = 5,
                    OccupationName = "Mechanic",
                    RatingId = 4
                },
                new Occupation
                {
                    OccupationId = 6,
                    OccupationName = "Florist",
                    RatingId = 3
                }
            };
            return OccupationList;
        }
    }
}
