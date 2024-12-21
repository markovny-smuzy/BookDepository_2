using BookDepository2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookDepository2.Models;

public class EfBookRepository : IBookCatalog
{
    private readonly BookContext _context;

    public EfBookRepository(BookContext context)
    {
        _context = context;
    }

    public async Task AddBookAsync(ConcreteBook book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<IBook>> FindByTitleAsync(string titleFragment)
    {
        return await _context.Books.Where(b => b.Title.Contains(titleFragment)).ToListAsync();
    }

    public async Task<IEnumerable<IBook>> FindByAuthorAsync(string authorName)
    {
        return await _context.Books.Where(b => b.Author.Contains(authorName)).ToListAsync();
    }

    public async Task<IBook?> FindByISBNAsync(string isbn)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
    }

    public async Task<IEnumerable<(IBook Book, List<string> KeywordsFound)>> FindByKeywordsAsync(string[] keywords)
    {
        var results = new List<(IBook, List<string>)>();
        foreach (var book in _context.Books)
        {
            var keywordsFound = keywords.Where(k => book.ContainsKeyword(k)).ToList();
            if (keywordsFound.Any())
            {
                results.Add((book, keywordsFound));
            }
        }
        return await Task.FromResult(results);
    }
}
