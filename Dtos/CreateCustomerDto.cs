namespace MyApiProject.Dtos
{
    public class CreateCustomerDto
    {
        public required string Name { get; set; }
        public int ProductId { get; set; }
    }
}