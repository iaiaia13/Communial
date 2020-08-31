using NetCoreData.Models;
using NetCoreData.ReposInterface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoreData.Repos
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public bool isEmailUniq(string email)
        {
            var user = this.GetSingle(u => u.Email == email);
            return user == null;
        }

        public bool IsUsernameUniq(string username)
        {
            var user = this.GetSingle(u => u.UserName == username);
            return user == null;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.GetAll();
        }

        public User GetUser(string username)
        {
            return this.GetSingle(u => u.UserName == username);
        }

        public User GetUser(Expression<Func<User, bool>> predicate)
        {
            return this.GetSingle(predicate);
        }

        public void InsertUser(User user)
        {
            user.ID = Guid.NewGuid().ToString();
            user.CreatedDate = DateTime.Now;
            this.Add(user);
            this.Commit();
        }

        public void UpdateUser(User user)
        {
            User us = this.GetUser(user.UserName);
            us.Name = user.Name;
            us.Phone = user.Phone;
            us.UpdatedDate = DateTime.Now;

            this.Update(us);
            this.Commit();
        }

        public void DeleteUser(User user)
        {
            this.Delete(user);
            this.Commit();
        }

        public void DeleteUser(string username)
        {
            this.DeleteWhere(u => u.UserName == username);
            this.Commit();
        }
    }
}