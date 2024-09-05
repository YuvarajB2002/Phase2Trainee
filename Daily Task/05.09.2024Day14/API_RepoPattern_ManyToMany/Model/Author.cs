namespace API_ManyToMany.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }

        public ICollection<BookAuthor>? bookAuthor { get; set; }
    }
}
