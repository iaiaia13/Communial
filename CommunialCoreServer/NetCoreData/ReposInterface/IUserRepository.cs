using NetCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoreData.ReposInterface
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();

        public User GetUser(string id);

        public User GetUser(Expression<Func<User, bool>> predicate);

        public void InsertUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(User user);

        public void DeleteUser(string id);

        public bool isEmailUniq(string email);

        public bool IsUsernameUniq(string username);
    }
}