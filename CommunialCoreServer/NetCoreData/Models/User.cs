﻿using NetCoreData.ReposInterface;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreData.Models
{
    public class User : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string GUID { get; set; }
    }
}