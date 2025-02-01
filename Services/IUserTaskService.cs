namespace TaskTracker.Services;
using TaskTracker.Entities;

public interface IUserTaskService
{
    void Create(string description, State state);
    //void Delete(int id);
    //IEnumerable<UserTask> GetAll();
    //UserTask GetBy(int id);
    //void Update(UserTask task);
}