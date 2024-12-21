namespace BookDepository2.Services;

using BookDepository2.Interfaces;

public class ConsoleUserInput : IUserInput
{
    public string ReadInput() => Console.ReadLine() ?? string.Empty;
}