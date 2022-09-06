namespace WebApi_Library.Model.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public List<Book> Books { get; set; }
        
    }
}
