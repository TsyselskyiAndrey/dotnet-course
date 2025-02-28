using Application.Abstractions;
using Core.Models;
using Infrastructure.Services;

namespace RecipeBookManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new UserRepository();
            IUserService userService = new UserService(userRepository);

            while (true)
            {
                Console.WriteLine("\n1. Register User");
                Console.WriteLine("2. Publish Recipe Book");
                Console.WriteLine("3. View All Books");
                Console.WriteLine("4. Read Book");
                Console.WriteLine("5. Get All Users");
                Console.WriteLine("6. Add a recipe to a book");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your name: ");
                        string userName = Console.ReadLine()!;
                        userService.RegisterUser(userName);
                        Console.WriteLine($"User '{userName}' registered successfully!");
                        break;

                    case "2":
                        Console.Write("Enter your User ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int userId))
                        {
                            Console.WriteLine("Invalid User ID!");
                            break;
                        }

                        var user = userService.GetUserById(userId);
                        if (user == null)
                        {
                            Console.WriteLine("User not found!");
                            break;
                        }

                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine()!;
                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine()!;
                        var book = new Book(title, description, user.Name);

                        userService.PublishBook(userId, book);
                        break;

                    case "3":
                        var books = userService.ViewAllBooks();
                        if (!books.Any())
                        {
                            Console.WriteLine("No books found.");
                        }
                        else
                        {
                            foreach (var b in books)
                            {
                                Console.WriteLine($"{b.Title} by {b.Author}");
                            }
                        }
                        break;

                    case "4":
                        Console.Write("Enter Book Title: ");
                        string bookTitle = Console.ReadLine()!;
                        var selectedBook = userService.ReadBook(bookTitle);
                        if (selectedBook != null)
                        {
                            Console.WriteLine(selectedBook);
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;
                    case "5":
                        var users = userService.GetAllUsers();
                        if (!users.Any())
                        {
                            Console.WriteLine("No books found.");
                        }
                        else
                        {
                            foreach (var u in users)
                            {
                                Console.WriteLine(u);
                            }
                        }
                        break;

                    case "6":
                        Console.Write("Enter Book Title: ");
                        string bookTitleAnother = Console.ReadLine()!;
                        Console.Write("Enter Recipy Title: ");
                        string recipeTitle = Console.ReadLine()!;
                        Console.Write("Enter Recipy Ingredients: ");
                        string ingredients = Console.ReadLine()!;
                        Console.Write("Enter Recipy Instructions: ");
                        string instructions = Console.ReadLine()!;
                        userService.AddRecipe(bookTitleAnother, new Recipe(recipeTitle, ingredients, instructions));
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}
