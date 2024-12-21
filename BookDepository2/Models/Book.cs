using BookDepository2.Interfaces;

namespace BookDepository2.Models;

public class Book : IBook
{
    public string Title { get; protected set; } = string.Empty; // Значение по умолчанию
    public string Author { get; protected set; } = string.Empty; // Значение по умолчанию
    public string GenresSerialized { get; protected set; } = string.Empty; // Для EF Core
    public int PublicationYear { get; protected set; }
    public string Annotation { get; protected set; } = string.Empty; // Значение по умолчанию
    public string ISBN { get; protected set; } = string.Empty; // Значение по умолчанию

    public string[] Genres
    {
        get => GenresSerialized.Split(',', StringSplitOptions.RemoveEmptyEntries);
        protected set => GenresSerialized = string.Join(",", value);
    }

    // Конструктор без параметров для EF Core
    protected Book() { }

    // Конструктор для пользовательского создания объектов
    protected Book(string title, string author, string[] genres, int publicationYear, string annotation, string isbn)
    {
        Title = title;
        Author = author;
        Genres = genres;
        PublicationYear = publicationYear;
        Annotation = annotation;
        ISBN = isbn;
    }

    // Проверка ключевых слов
    public bool ContainsKeyword(string keyword)
    {
        keyword = keyword.ToLower();
        return Title.ToLower().Contains(keyword) ||
               Author.ToLower().Contains(keyword) ||
               Annotation.ToLower().Contains(keyword);
    }
}