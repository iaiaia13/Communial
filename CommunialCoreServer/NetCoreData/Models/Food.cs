using NetCoreData.ReposInterface;

namespace NetCoreData.Models
{
    public class Food : IEntityBase
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }
    }
}