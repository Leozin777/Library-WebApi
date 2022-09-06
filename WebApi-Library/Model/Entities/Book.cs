﻿namespace WebApi_Library.Model.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Request Request { get; set; }
        public int RequestId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }

    }
}
