using Microsoft.EntityFrameworkCore;
using Moq;
using MockQueryable.Moq;
using NUnit.Framework;
using PremiumCalculatorApp.Data;
using PremiumCalculatorApp.Models;
using PremiumCalculatorApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;
//using Xunit;

namespace PremiumCalculatorAppTest
{
   
    [TestFixture]
    public class UserRepositoryTest
    {
       
        [Test, Order(3)]
        public void GetOccupationList_WhenCalled_ReturnsAllItems()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                         .UseInMemoryDatabase(databaseName: "OccupationRatingTest")
                         .Options;
           
            using (var context = new AppDbContext(options))
            {
                var occRepository = new Mock<OccupationRepository>(context);
                UserRepository userRepository = new UserRepository(context, occRepository.Object);
                List<Occupation> occupations = userRepository.LoadOccupationList();

                Assert.AreEqual(7, occupations.Count);
            }

        }


        [Test, Order(1)]
        public void SaveUser_WhenCalled_ReturnsMonthlyPremium()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                          .UseInMemoryDatabase(databaseName: "OccupationRatingTest")
                          .Options;
            using (var context = new AppDbContext(options))
            {
                foreach (var item in TestHelper.GetOccupationList())
                {
                    context.Occupations.Add(item);
                }
                foreach (var item in TestHelper.GetRatingFactors())
                {
                    context.RatingFactors.Add(item);
                }
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                var occRepository = new Mock<OccupationRepository>(context);
                UserRepository userRepository = new UserRepository(context, occRepository.Object);

                var userEditModelData = new UserEditViewModal();
                userEditModelData = TestHelper.GetUserEditViewModal();

                var user = new User();
                user = TestHelper.GetUser();
                var MonthlyPremium = 14.34375;

                bool saved = userRepository.SaveUser(userEditModelData);

                Assert.IsTrue(saved);
                Assert.AreEqual(MonthlyPremium, user.MonthlyPremium); 
            }

        }

        [Test,Order(2)]
        public void SaveUser_WhenCalled_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                         .UseInMemoryDatabase(databaseName: "OccupationRatingTest")
                         .Options;

            using (var context = new AppDbContext(options))
            {
                var occRepository = new Mock<OccupationRepository>(context);
                UserRepository userRepository = new UserRepository(context, occRepository.Object);

                UserEditViewModal userEditModelData = null;              

                bool saved = userRepository.SaveUser(userEditModelData);

                Assert.IsFalse(saved);
                Assert.IsNull(userEditModelData);
            }         
        }

       

    }
}
