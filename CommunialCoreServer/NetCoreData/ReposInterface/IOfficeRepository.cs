using NetCoreData.Models;
using NetCoreServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoreData.ReposInterface
{
    public interface IOfficeRepository
    {
        public IEnumerable<Office> GetAllFood();

        public Office GetOneFood(string ID);

        public void InsertNewFood(Office food);

        public void UpdateOneFood(Office food);

        public void DeleteOneFood(Office food);

        public void DeleteOneFoodByID(string ID);

        public IEnumerable<Office> Search(OfficeFilterModel office);
    }
}