//using NetCoreData.Models;
//using NetCoreData.ReposInterface;
//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;

//namespace NetCoreData.Repos
//{
//    public class OfficeRentingRepository : EntityBaseRepository<OfficeRenting>, IOfficeRentingRepository
//    {
//        public OfficeRentingRepository(DataContext context) : base(context)
//        {
//        }

//        public IEnumerable<Office> GetAllFood()
//        {
//            try
//            {
//                return this.GetAll();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public Office GetOneFood(Guid id)
//        {
//            try
//            {
//                return this.GetSingle(u => u.ID == id);
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public IEnumerable<Office> Search(Office office)
//        {
//            try
//            {
//                ParameterExpression addressParam = Expression.Parameter(typeof(string), "Address");
//                Expression left = Expression.Call(addressParam, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
//                Expression right = Expression.Constant(office.Address);

//                Expression innerLambda = Expression.Equal(left, right);

//                Expression<Func<Office, bool>> predicateBody = Expression.Lambda<Func<Office, bool>>(innerLambda, addressParam);

//                var reuslt = FindBy(predicateBody);
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public void InsertNewFood(Office food)
//        {
//            try
//            {
//                this.Add(food);
//                this.Commit();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public void UpdateOneFood(Office food)
//        {
//            try
//            {
//                Office fo = this.GetOneFood(food.ID);
//                fo.Name = food.Name;
//                fo.Description = food.Description;
//                fo.Type = food.Type;

//                this.Update(fo);
//                this.Commit();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public void DeleteOneFood(Office food)
//        {
//            try
//            {
//                this.Delete(food);
//                this.Commit();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public void DeleteOneFoodByID(Guid id)
//        {
//            try
//            {
//                this.DeleteWhere(u => u.ID == id);
//                this.Commit();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        //public IEnumerable<Offices> SearchOffices(Offices office)
//        //{
//        //    try
//        //    {
//        //        return this.GetSingle(predicate);
//        //    }
//        //    catch
//        //    {
//        //        throw;
//        //    }
//        //}
//    }
//}