namespace BookDepository2.Interfaces;

using BookDepository2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBookCatalog
{
    Task AddBookAsync(ConcreteBook book);
    Task<IEnumerable<IBook>> FindByTitleAsync(string titleFragment);
    Task<IEnumerable<IBook>> FindByAuthorAsync(string authorName);
    Task<IBook?> FindByISBNAsync(string isbn);
    Task<IEnumerable<(IBook Book, List<string> KeywordsFound)>> FindByKeywordsAsync(string[] keywords);
}