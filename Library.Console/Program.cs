// See https://aka.ms/new-console-template for more information
using Library.Business;
using Library.Data;
using Library.Model;
using System.Runtime.CompilerServices;

Console.WriteLine("Welcome to the Library");

var context = new Context();
var library = new LibraryManagement(context);

library.ClearDB();

//await library.SetupInventory();

var sam = await library.EnrollNewMember("Sam", "Barnes", DateTime.Parse("2004-12-06"));
var david = await library.EnrollNewMember("David", "Barnes", DateTime.Parse("2008-12-06"));
var susie = await library.EnrollNewMember("Susie", "Barnes", DateTime.Parse("2016-12-06"));


//Childrens - "978-0-596-52068-7"
//Adolescent -     "978-0-595-54568-3"
//Adult -    "978-0-596-53098-7"
//Nonfiction -    "978-0-696-23078-9"

Console.WriteLine($"{susie.FirstName} can checkout a Children's book: {await library.CheckoutBook(susie, "978-0-596-52068-7")}");
Console.WriteLine($"{susie.FirstName} can checkout a Adolescent book: {await library.CheckoutBook(susie, "978-0-595-54568-3")}");
Console.WriteLine($"{susie.FirstName} can checkout a Adult book: {await library.CheckoutBook(susie, "978-0-596-53098-7")}");
Console.WriteLine($"{susie.FirstName} can checkout a NonFiction book: {await library.CheckoutBook(susie, "978-0-696-23078-9")}");

Console.WriteLine($"{david.FirstName} can checkout a Children's book: {await library.CheckoutBook(david, "978-0-596-52068-7")}");
Console.WriteLine($"{david.FirstName} can checkout a Adolescent book: {await library.CheckoutBook(david, "978-0-595-54568-3")}");
Console.WriteLine($"{david.FirstName} can checkout a Adult book: {await library.CheckoutBook(david, "978-0-596-53098-7")}");
Console.WriteLine($"{david.FirstName} can checkout a NonFiction book: {await library.CheckoutBook(david, "978-0-696-23078-9")}");

Console.WriteLine($"{sam.FirstName} can checkout a Children's book: {await library.CheckoutBook(sam, "978-0-596-52068-7")}");
Console.WriteLine($"{sam.FirstName} can checkout a Adolescent book: {await library.CheckoutBook(sam, "978-0-595-54568-3")}");
Console.WriteLine($"{sam.FirstName} can checkout a Adult book: {await library.CheckoutBook(sam, "978-0-596-53098-7")}");
Console.WriteLine($"{sam.FirstName} can checkout a NonFiction book: {await library.CheckoutBook(sam, "978-0-696-23078-9")}");

