using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BookDepository2.Models;
using BookDepository2.Services;
using System.IO;

namespace BookDepository2;

class Program
{
    static async Task Main()
    {
        // Загрузка конфигурации из appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Указание текущего каталога
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Чтение конфигурации
            .Build();

        // Извлечение строки подключения из конфигурации
        var connectionString = configuration.GetConnectionString("BookDatabase");

        // Настройка контекста базы данных
        var options = new DbContextOptionsBuilder<BookContext>()
            .UseSqlite(connectionString) // Используем строку подключения из конфигурации
            .Options;

        // Создание контекста базы данных
        var context = new BookContext(options);

        // Обеспечиваем создание базы данных, если она не существует
        await context.Database.EnsureCreatedAsync();

        // Создаём репозиторий для работы с базой данных
        var bookCatalog = new EfBookRepository(context);

        // Настройка пользовательского ввода и вывода
        var userInput = new ConsoleUserInput();
        var userOutput = new ConsoleUserOutput();

        // Меню для взаимодействия с пользователем
        var menu = new Menu(userInput, userOutput, bookCatalog);

        // Запуск главного меню
        await menu.ShowAsync();
    }
}