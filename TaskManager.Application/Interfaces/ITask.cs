using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Interfaces
{
    public interface ITask
    {
        IEnumerable<Task> Search(byte? status);

        Task Create(Task task);

        Task Update(int id, Task task);

        void Delete(int id);
    }
}
