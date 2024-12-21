namespace BookDepository2.Models;

public class ConcreteBook : Book
{
    public int Id { get; set; } // Первичный ключ для базы данных

    // Конструктор без параметров для EF Core
    public ConcreteBook() { }

    // Конструктор с параметрами для создания объектов
    public ConcreteBook(string title, string author, string[] genres, int publicationYear, string annotation, string isbn)
        : base(title, author, genres, publicationYear, annotation, isbn)
    {
        // Поле Id не передаётся в базовый класс, оно остаётся только в производном классе
    }
}