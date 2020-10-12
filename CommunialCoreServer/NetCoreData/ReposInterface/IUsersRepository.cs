using NetCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoreData.ReposInterface
{
    public interface IUsersRepository
    {
        public IEnumerable<Users> GetAllUsers();

        public Users GetUser(string id);

        public Users GetUser(Expression<Func<Users, bool>> predicate);

        public void InsertUser(Users user);

        public void UpdateUser(Users user);

        public void DeleteUser(Users user);

        public void DeleteUser(string id);

        public bool isEmailUniq(string email);

        public bool IsUsernameUniq(string username);
    }
}