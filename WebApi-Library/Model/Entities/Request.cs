namespace WebApi_Library.Model.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public int Qtd { get; set; }
        public int IdBook { get; set; }
        public List<Book> Books { get; set; }
        public int IdClient { get; set; }
        public Client CLient { get; set; }
    }
}
