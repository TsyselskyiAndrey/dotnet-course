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
            IBookService bookService = new BookService(userRepository);
            IRecipeService recipyService = new RecipeService(bookService);
            while (true)
            {
                Console.WriteLine("\n===== Recipe Book Management System =====");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. Publish Recipe Book");
                Console.WriteLine("3. View All Books");
                Console.WriteLine("4. Read Book");
                Console.WriteLine("5. Get All Users");
                Console.WriteLine("6. Add a recipe to a book");
                Console.WriteLine("7. Filter Books by Title");
                Console.WriteLine("8. Filter Books by Author");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your name: ");
                        string userName = Console.ReadLine()!;
                        userService.RegisterUser(userName);
                        Console.WriteLine($"\nUser '{userName}' registered successfully!\n");
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
                        var book = new Book
                        {
                            Title = title,
                            Description = description,
                            Author = user.Name
                        };

                        bookService.PublishBook(userId, book);
                        Console.WriteLine("\nBook published successfully!\n");
                        break;

                    case "3":
                        var books = bookService.ViewAllBooks();
                        if (!books.Any())
                        {
                            Console.WriteLine("No books found.\n");
                        }
                        else
                        {
                            Console.WriteLine("\n=== All Books ===");
                            foreach (var b in books)
                            {
                                Console.WriteLine($"Title: {b.Title}\nAuthor: {b.Author}\nDescription: {b.Description}\n");
                            }
                        }
                        break;

                    case "4":
                        Console.Write("Enter Book Title: ");
                        string bookTitle = Console.ReadLine()!;
                        var selectedBook = bookService.ReadBook(bookTitle);
                        Console.WriteLine(selectedBook != null ? $"\n{selectedBook}\n" : "\nBook not found.\n");
                        break;

                    case "5":
                        var users = userService.GetAllUsers();
                        if (!users.Any())
                        {
                            Console.WriteLine("No users found.\n");
                        }
                        else
                        {
                            Console.WriteLine("\n=== Registered Users ===");
                            foreach (var u in users)
                            {
                                Console.WriteLine($"ID: {u.Id} | Name: {u.Name}\n");
                            }
                        }
                        break;

                    case "6":
                        Console.Write("Enter Book Title: ");
                        string bookTitleAnother = Console.ReadLine()!;
                        Console.Write("Enter Recipe Title: ");
                        string recipeTitle = Console.ReadLine()!;
                        Console.Write("Enter Recipe Ingredients: ");
                        string ingredients = Console.ReadLine()!;
                        Console.Write("Enter Recipe Instructions: ");
                        string instructions = Console.ReadLine()!;
                        recipyService.AddRecipe(bookTitleAnother, new Recipe
                        {
                            Title = recipeTitle,
                            Ingredients = new List<Ingredient>() { new Ingredient { Id = 0, Name = ingredients } },
                            Instructions = new List<Instruction>() { new Instruction { Id = 0, Name = instructions } }
                        });
                        Console.WriteLine("\nRecipe added successfully!\n");
                        break;

                    case "7":
                        Console.Write("Enter Title to search: ");
                        string searchTitle = Console.ReadLine()!;
                        var filteredByTitle = bookService.GetBooksByTitle(t => t.Contains(searchTitle, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine(filteredByTitle.Any() ? "\n=== Filtered Books ===" : "\nNo books found with that title.\n");
                        foreach (var bookElem in filteredByTitle)
                        {
                            Console.WriteLine($"Title: {bookElem.Title} | Author: {bookElem.Author}\n");
                        }
                        break;

                    case "8":
                        Console.Write("Enter Author to search: ");
                        string searchAuthor = Console.ReadLine()!;
                        var filteredByAuthor = bookService.GetBooksByAuthor(a => a.Contains(searchAuthor, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine(filteredByAuthor.Any() ? "\n=== Filtered Books ===" : "\nNo books found by that author.\n");
                        foreach (var bookElem in filteredByAuthor)
                        {
                            Console.WriteLine($"Title: {bookElem.Title} | Author: {bookElem.Author}\n");
                        }
                        break;

                    case "0":
                        Console.WriteLine("\nExiting the program...\n");
                        return;

                    default:
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        break;
                }
            }
        }
    }
}
