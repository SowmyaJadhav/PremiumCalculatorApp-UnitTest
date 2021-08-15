using Microsoft.EntityFrameworkCore;
using PremiumCalculatorApp.Data;
using PremiumCalculatorApp.Models;
using PremiumCalculatorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PremiumCalculatorAppTest
{
    public class TestDBSetRepository : IUserRepository
    {
        private readonly DbSet<Occupation> _dbSet;
        public TestDBSetRepository(DbSet<Occupation> dbSet)
        {
            _dbSet = dbSet;
        }
        public List<Occupation> LoadOccupationList()
        {
            return _dbSet.AsQueryable().ToList();
        }

        public bool SaveUser(UserEditViewModal userEdit)
        {           
            return true;
        }
    }
}
