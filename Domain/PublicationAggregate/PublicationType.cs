using DDD_Investigation.Domain.OrderAggregate;
using DDD_Investigation.Domain.Shared;

namespace DDD_Investigation.Domain.PublicationAggregate
{
    public class PublicationType : Enumeration
    {
        protected PublicationType()
        {

        }
        protected PublicationType(int id, string name) : base(id, name) { }


        public static PublicationType Book = new PublicationType(1, "Book".ToLowerInvariant());
        public static PublicationType EBook = new PublicationType(2, "EBook".ToLowerInvariant());
    }
}
