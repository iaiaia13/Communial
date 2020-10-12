using Common;
using Microsoft.EntityFrameworkCore.Internal;
using NetCoreData.Models;
using NetCoreData.ReposInterface;
using NetCoreServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetCoreData.Repos
{
    public class OfficeRepository : EntityBaseRepository<Office>, IOfficeRepository
    {
        public OfficeRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<Office> GetAllFood()
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

        public Office GetOneFood(string id)
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

        public IEnumerable<Office> Search(OfficeFilterModel office)
        {
            try
            {
                Expression<Func<Office, bool>> predicateBody = BuildSearchExpression(office);

                var result = FindBy(predicateBody);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Expression<Func<Office, bool>> BuildSearchExpression(OfficeFilterModel office)
        {
            var c = ExpressionHelper.GetCriteriaWhere<Office>(a => a.Address, OperationExpression.Like, office.Address);

            if (office.Capacity > 50)
            {
                c = c.And(ExpressionHelper.GetCriteriaWhere<Office>(a => a.Capacity, OperationExpression.MinorEquals, 50));
            }
            else if (office.Capacity > 0)
            {
                c = c.And(ExpressionHelper.GetCriteriaWhere<Office>(a => a.Capacity, OperationExpression.MayorEquals, 50));
            }
            if (office.PriceFrom > 0)
                c = c.And(ExpressionHelper.GetCriteriaWhere<Office>(a => a.PricePerMonth, OperationExpression.MayorEquals, office.PriceFrom));
            if (office.PriceTo > 0)
                c = c.And(ExpressionHelper.GetCriteriaWhere<Office>(a => a.PricePerMonth, OperationExpression.MinorEquals, office.PriceTo));

            return c;
        }

        public void InsertNewFood(Office food)
        {
            try
            {
                this.Add(food);
                this.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateOneFood(Office food)
        {
            try
            {
                Office fo = this.GetOneFood(food.ID);
                fo.Name = food.Name;
                fo.Description = food.Description;
                fo.Type = food.Type;

                this.Update(fo);
                this.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteOneFood(Office food)
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

        public void DeleteOneFoodByID(string id)
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

        //public IEnumerable<Offices> SearchOffices(Offices office)
        //{
        //    try
        //    {
        //        return this.GetSingle(predicate);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}