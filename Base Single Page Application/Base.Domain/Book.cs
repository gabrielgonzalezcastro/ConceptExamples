
namespace Base.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public int NumberInStock { get; set; }
        public int NumberPurchases { get; set; }
        public string Description { get; set; }
    }
}
