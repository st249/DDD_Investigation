namespace DDD_Investigation.Domain.PublicationAggregate
{
    public class EBook : Publication
    {
        public string Format { get; set; }
        public EBook(string title, string pulisher, string author) : base(title, pulisher, author)
        {
            _publicationType = PublicationType.EBook;
        }
    }
}
