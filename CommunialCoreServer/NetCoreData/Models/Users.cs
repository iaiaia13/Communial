using NetCoreData.ReposInterface;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreData.Models
{
    public class Users
    {
        public string ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Token { get; set; }

        public long TokenExpirationTime { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}