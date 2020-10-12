using NetCoreData.ReposInterface;
using System;

namespace NetCoreData.Models
{
    public class OfficeRenting
    {
        public int ID { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Type { get; set; }

        public double Price { get; set; }

        public string OfficeID { get; set; }

        public virtual Office Office { get; set; }
    }
}