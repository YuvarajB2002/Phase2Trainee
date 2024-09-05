namespace API_ManyToMany.Model
{
    public class Book
    {
        public int BookId {  get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }
        public ICollection<BookAuthor >? bookAuthor { get; set; }
    }
}
