namespace MyApiProject.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ProductId { get; set; }
    }
}