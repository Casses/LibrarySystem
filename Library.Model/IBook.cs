using Library.Common.Enum;

namespace Library.Model
{
    public interface IBook
    {
        string Author { get; set; }
        BookType Category { get; set; }
        string Description { get; set; }
        int ID { get; set; }
        string ISBN { get; set; }
        string Title { get; set; }

        bool CanBookBeCheckedOut(Member member);
    }
}