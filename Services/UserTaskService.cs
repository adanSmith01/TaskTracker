namespace TaskTracker.Services;

using System.Text.Json;
using System.Text.Unicode;
using TaskTracker.Entities;

public class UserTaskService: IUserTaskService
{
    private readonly string _filePath;
    private const string MESSAGE_FILENOTFOUNDEXCEPTION = "The file of tasks not found";
    public UserTaskService(string filePath)
    {
        _filePath = filePath;
    }

    public void Create(string description, State state)
    {
        try
        {
            
            List<UserTask> tasks = readJsonFile();
            UserTask task = new UserTask{
                Id = new Random().Next(int.MaxValue),
                Description = description,
                StateTask = state,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            tasks.Add(task);
            writeJsonFile(tasks);
        }
        catch (FileNotFoundException)
        {
            throw new Exception(MESSAGE_FILENOTFOUNDEXCEPTION);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private List<UserTask> readJsonFile()
    {
        List<UserTask> tasks = [];

        if(File.Exists(_filePath) && new FileInfo(_filePath).Length > 0)
        {
            using StreamReader reader = new StreamReader(_filePath);
            tasks = JsonSerializer.Deserialize<List<UserTask>>(reader.ReadToEnd());
        }

        return tasks; 
    }

    private void writeJsonFile(List<UserTask> tasks)
    {
        using FileStream fwriter = File.Create(_filePath);
        using Utf8JsonWriter writer = new Utf8JsonWriter(fwriter, new JsonWriterOptions{Indented = true});

        JsonSerializer.Serialize(writer, tasks);
    }
}