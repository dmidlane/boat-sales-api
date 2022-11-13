using System.ComponentModel.DataAnnotations;

namespace BoatSalesApi.Domain
{
    public class Boat
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
