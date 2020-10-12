using NetCoreData.ReposInterface;
using System;
using System.Collections.Generic;

namespace NetCoreData.Models
{
    public class Office
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public int Capacity { get; set; }

        public double PricePerMonth { get; set; }

        public double PricePerDay { get; set; }

        public double PricePerQuarter { get; set; }

        public double PricePerYear { get; set; }

        public double Start { get; set; }

        public ICollection<OfficeRenting> OfficeRenting { get; set; }
    }
}