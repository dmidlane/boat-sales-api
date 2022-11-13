namespace BoatSalesApi.Contracts.V1.Request
{
    public class UpdateBoatRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}