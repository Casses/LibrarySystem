using Library.Common.Enum;
using Library.Data;
using Library.Model;
using Microsoft.EntityFrameworkCore;



namespace Library.Business
{
    public class LibraryManagement
    {
        private readonly Context context;
        public LibraryManagement(Context context)
        {
            this.context = context;
        }

        public async Task<bool> ClearDB()
        {
            var activityLog = this.context.ActivityLogs;
            var books = this.context.Books;
            var members = this.context.Members;

            foreach (var ac in activityLog)
            {
                this.context.Remove(ac);
            }
            foreach (var member in members)
            {
                this.context.Remove(member);
            }
            this.context.SaveChanges();
            return true;
        }

        public int CountMembers()
        {
            return this.context.Members.Count();
        }

        public async Task SetupInventory()
        {
            var books = new List<Book>();

            books.Add(new FictionBook()
            {
                Author = "Shel Silverstein",
                Title = "The Giving Tree",
                Category = Library.Common.Enum.BookType.Fiction,
                Genre = Library.Common.Enum.FictionGenre.Fantasy,
                Rating = Library.Common.Enum.Rating.Children,
                ISBN = "978-0-596-52068-7",
                Description = "A lovely children's book"
            });
            books.Add(new FictionBook()
            {
                Author = "Margaret Weiss & Tracy Hickman",
                Title = "Dragons of Spring Dawning",
                Category = Library.Common.Enum.BookType.Fiction,
                Genre = Library.Common.Enum.FictionGenre.Fantasy,
                Rating = Library.Common.Enum.Rating.Adolescent,
                ISBN = "978-0-595-54568-3",
                Description = "YA Fantasy novel series first entry"
            });
            books.Add(new FictionBook()
            {
                Author = "Lee Childs",
                Title = "Reacher",
                Category = Library.Common.Enum.BookType.Fiction,
                Genre = Library.Common.Enum.FictionGenre.Crime,
                Rating = Library.Common.Enum.Rating.Adult,
                ISBN = "978-0-596-53098-7",
                Description = "Story of a drifter veteran who helps solve crime"
            });
            books.Add(new NonFictionBook()
            {
                Author = "Vasily Grossman",
                Title = "Life and Fate",
                Category = Library.Common.Enum.BookType.Nonfiction,
                ISBN = "978-0-696-23078-9",
                Description = "A history book about World War 2"
            });

            foreach (var book in books)
            {
                await AddBook(book);
            }
        }

        public async Task<Member> EnrollNewMember(string firstName, string lastName, DateTime dateOfBirth)
        {
            var newMember = new Member()
            {
                CardIdentifier = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                CheckoutHistory = new List<ActivityLog>()
            };

            context.Add(newMember);
            await context.SaveChangesAsync();

            return newMember;
        }

        public async Task<Book> AddBook(Book book)
        {
            context.Add(book);
            await context.SaveChangesAsync();

            return book;
        }

        public async Task<bool> CheckoutBook(Member member, string isbn)
        {
            var result = false;
            var book = await context.Books.SingleOrDefaultAsync(b => b.ISBN == isbn);

            if (book == null)
            {
                throw new Exception("No book found for provided ISBN");
            }

            if (book.CanBookBeCheckedOut(member))
            {
                var checkout = new ActivityLog()
                {
                    Member = member,
                    Book = book,
                    Checkout = DateTime.Now
                };

                context.Add(checkout);
                result = await context.SaveChangesAsync() > 0;
            }

            return result;
        }

    }
}
