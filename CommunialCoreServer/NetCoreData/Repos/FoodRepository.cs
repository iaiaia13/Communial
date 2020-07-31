using NetCoreData.Models;
using NetCoreData.ReposInterface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoreData.Repos
{
    public class FoodRepository : EntityBaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<Food> GetAllFood()
        {
            try
            {
                return this.GetAll();
            }
            catch
            {
                throw;
            }
        }

        public Food GetOneFood(int id)
        {
            try
            {
                return this.GetSingle(u => u.ID == id);
            }
            catch
            {
                throw;
            }
        }

        public Food GetOneFood(Expression<Func<Food, bool>> predicate)
        {
            try
            {
                return this.GetSingle(predicate);
            }
            catch
            {
                throw;
            }
        }

        public void InsertNewFood(Food food)
        {
            try
            {
                //food.ID = GetNextGenerationId();
                this.Add(food);
                this.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateOneFood(Food food)
        {
            try
            {
                Food fo = this.GetOneFood(food.ID);
                fo.Name = food.Name;
                fo.Description = food.Description;
                fo.Type = food.Type;
                fo.Quantity = food.Quantity;

                this.Update(fo);
                this.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteOneFood(Food food)
        {
            try
            {
                this.Delete(food);
                this.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteOneFoodByID(int id)
        {
            try
            {
                this.DeleteWhere(u => u.ID == id);
                this.Commit();
            }
            catch
            {
                throw;
            }
        }
    }
}