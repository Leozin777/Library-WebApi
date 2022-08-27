namespace WebApi_Library.Model.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Request> Requests { get; set; }
    }
}
