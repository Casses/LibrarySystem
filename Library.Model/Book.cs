using Library.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
    public abstract class Book
    {
        [Key]
        public int ID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        public BookType Category { get; set; }

        public virtual IList<ActivityLog> CheckoutHistory { get; set; }

        public virtual bool CanBookBeCheckedOut(Member member)
        {
            var rulesViolations = false;
            if (member.CheckoutHistory.Count(b => b.Return.HasValue) >= member.MaxCheckouts)
            {
                rulesViolations = true;
            }
           return !rulesViolations;
        }
    }
}
