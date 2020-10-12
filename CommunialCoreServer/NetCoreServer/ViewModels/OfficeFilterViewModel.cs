namespace NetCoreServer.ViewModels
{
    public class OfficeFilterViewModel
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Address { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string StrCapacity { get; set; }

        public int Capacity { get; set; }

        public double PricePerMonth { get; set; }

        public double PricePerDay { get; set; }

        public double PricePerQuarter { get; set; }

        public double PricePerYear { get; set; }

        public string PriceFrom { get; set; }

        public string PriceTo { get; set; }
    }
}