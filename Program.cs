internal class Program
{
    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("task-cli ");
        Console.ForegroundColor = ConsoleColor.White;
        string command = Console.ReadLine();
        Console.WriteLine("In progress");
    }

}