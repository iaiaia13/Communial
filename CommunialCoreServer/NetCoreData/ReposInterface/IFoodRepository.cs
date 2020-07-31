using NetCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoreData.ReposInterface
{
    public interface IFoodRepository
    {
        public IEnumerable<Food> GetAllFood();

        public Food GetOneFood(int ID);

        public Food GetOneFood(Expression<Func<Food, bool>> predicate);

        public void InsertNewFood(Food food);

        public void UpdateOneFood(Food food);

        public void DeleteOneFood(Food food);

        public void DeleteOneFoodByID(int ID);
    }
}