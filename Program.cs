using System.Text.RegularExpressions;
using TaskTracker.Entities;
using TaskTracker.Services;

internal class Program
{
    const string SPLIT_PATTERN = @"(\"".*?\"")|\S+";
    const string CREATE_OPERATION = "create";
    const string CREATE_PATTERN = @"^create ""(.*)"" --state [0-2]$";

    private static void Main(string[] args)
    {
        try
        {
            string command = string.Empty;

            do
            {
                printInitialLine();
                IUserTaskService _userTaskService = new UserTaskService("userTasks.json");
                command = Console.ReadLine();
                //executeComand(command, _userTaskService);
            }while(!commandIsValid(command));

            Console.WriteLine("In Progress...");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void printInitialLine()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("task-cli ");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static bool commandIsValid(string command)
    {
        string[] validSyntaxCommands = {CREATE_PATTERN};
        foreach (var validSyntaxCommand in validSyntaxCommands)
        {
            if(Regex.IsMatch(command, validSyntaxCommand)) return true;
        }

        return false;
    }

    private static void executeComand(string command, IUserTaskService userTaskService)
    {
        var splitCommand = Regex.Matches(command, SPLIT_PATTERN);
        string operation = splitCommand[0].Value;

        if(operation == CREATE_OPERATION)
        {
            userTaskService.Create(splitCommand[1].Value.Trim('"'), (State)Convert.ToInt32(splitCommand[3].Value.Trim('"')));
            Console.WriteLine("Task created.\n");
        }
        
    }
}