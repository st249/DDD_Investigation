namespace DDD_Investigation.Domain.PublicationAggregate
{
    public class Book : Publication
    {
        public int VersionNumber { get; set; }
        public Book(string title, string pulisher, string author) : base(title, pulisher, author)
        {
            _publicationType = PublicationType.Book;
        }
    }
}
