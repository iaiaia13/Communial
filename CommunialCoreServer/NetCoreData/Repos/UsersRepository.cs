using NetCoreData.Models;
using NetCoreData.ReposInterface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoreData.Repos
{
    public class UsersRepository : EntityBaseRepository<Users>, IUsersRepository
    {
        public UsersRepository(DataContext context) : base(context)
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

        public IEnumerable<Users> GetAllUsers()
        {
            return this.GetAll();
        }

        public Users GetUser(string username)
        {
            return this.GetSingle(u => u.UserName == username);
        }

        public Users GetUser(Expression<Func<Users, bool>> predicate)
        {
            return this.GetSingle(predicate);
        }

        public void InsertUser(Users user)
        {
            user.ID = Guid.NewGuid().ToString();
            user.CreatedDate = DateTime.Now;
            this.Add(user);
            this.Commit();
        }

        public void UpdateUser(Users user)
        {
            Users us = this.GetUser(user.UserName);
            us.Name = user.Name;
            us.Phone = user.Phone;
            us.UpdatedDate = DateTime.Now;

            this.Update(us);
            this.Commit();
        }

        public void DeleteUser(Users user)
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