using System.Collections.Generic;

namespace Store.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Tag> Tags { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}