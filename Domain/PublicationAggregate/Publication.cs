namespace DDD_Investigation.Domain.PublicationAggregate
{
    public class Publication
    {
        public Publication(string title, string pulisher, string author)
        {
            Title = title;
            Pulisher = pulisher;
            Author = author;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Pulisher { get; set; }
        public string Author { get; set; }
        public int BHId { get; set; }

        protected PublicationType _publicationType;
        public PublicationType PublicationType => _publicationType;


    }
}
