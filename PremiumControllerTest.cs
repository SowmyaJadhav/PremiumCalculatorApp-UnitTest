using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PremiumCalculatorApp.Controllers;
using PremiumCalculatorApp.Data;
using PremiumCalculatorApp.Models;
using PremiumCalculatorApp.ViewModels;

namespace PremiumCalculatorAppTest
{    
    public class PremiumControllerTest 
    {
        private readonly PremiumController _controller;
        public PremiumControllerTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                           .UseInMemoryDatabase(databaseName: "OccupationTest")
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
            var dbcontext = new AppDbContext(options);
            var occRepository = new Mock<OccupationRepository>(dbcontext);
            var userRepository = new Mock<UserRepository>(dbcontext, occRepository.Object);
            _controller = new PremiumController(dbcontext, userRepository.Object);
           
        }

        [Test]
        public void GetUserEdit_UserSaveFailed_ReturnsAViewResult()
        {
            UserEditViewModal userEditModelData = new UserEditViewModal();
            userEditModelData = TestHelper.GetUserEditViewModal();
            userEditModelData.Age = 0;
          
            _controller.ModelState.AddModelError("Age", "Please select Date of Birth");          
           
            var model = _controller.Create(userEditModelData) as ViewResult;
            int errorCount = _controller.ModelState.ErrorCount;

            Assert.AreEqual(1, errorCount); 
        }

        [Test]
        public void GetUserEdit_ReturnsAViewResult_WithMonthlyPremium()
        {
            UserEditViewModal userEditModelData = new UserEditViewModal();
            User user = new User();
            userEditModelData = TestHelper.GetUserEditViewModal();
            user = TestHelper.GetUser();
            decimal MonthlyPremium = 14.34375M;

            var result = _controller.Create(userEditModelData);
            var premiumValue = _controller.ModelState["MonthlyPremium"].RawValue;
           
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(MonthlyPremium, Convert.ToDecimal(premiumValue));

        }
        [Test]
        public void CreateUser()
        {
            var model = _controller.Create();
            
            Assert.IsInstanceOf<ActionResult>(model);            

        }
    }
}
