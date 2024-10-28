using Library.Common.Enum;

namespace Library.Model
{
    public class FictionBook : Book
    {
        public required FictionGenre Genre { get; set; }
        public required Rating Rating { get; set; }
        public string? RatingDescription { get; set; }

        public override bool CanBookBeCheckedOut(Member member)
        {
            var canCheckout = base.CanBookBeCheckedOut(member);
            if (canCheckout)
            {
                //If the member hasn't hit their maximum checkouts, check age restrictions
                switch (Rating)
                {
                    case Rating.Children:
                        //Children's books have no minimum age.
                        break;
                    case Rating.Adolescent:

                        canCheckout = member.DateOfBirth < DateTime.Now.AddYears(-12);
                        break;
                    case Rating.Adult:
                        canCheckout = member.DateOfBirth < DateTime.Now.AddYears(-18);
                        break;
                }
            }
            return canCheckout;
        }
    }
}
