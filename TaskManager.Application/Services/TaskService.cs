using TaskManager.Application.Interfaces;
using TaskManager.Infrastructure.DataAccess;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services
{
    public class TaskService : ITask
    {
        private readonly TaskManagerDbContext _context;

        public TaskService(TaskManagerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> Search(byte? status)
        {
            var listTasks = _context.Task.ToList();

            if (status != null)
                listTasks = listTasks.Where(a => a.Status == status).ToList();

            return listTasks;
        }

        public Task Create(Task task)
        {
            var createdPedido = _context.Task.Add(task);

            ValidateTask(task);

            _context.SaveChanges();
            return task;
        }

        public Task Update(int id, Task task)
        {
            var taskExist = _context.Task.FirstOrDefault(c => c.Id == id);

            if (taskExist == null)
            {
                throw new ArgumentException("Não foi possivel alterar a tarefa, pois a tarefa não foi encontrada.");
            }

            taskExist.Title = task.Title ?? taskExist.Title;
            taskExist.Description = task.Description ?? taskExist.Description;
            taskExist.CreateDate = task.CreateDate != null ? task.CreateDate :  taskExist.CreateDate;
            taskExist.FinishDate = task.FinishDate != null ? task.FinishDate : taskExist.FinishDate;
            taskExist.Status = task.Status != null ? task.Status : taskExist.Status;

            ValidateTask(taskExist);

            _context.SaveChanges();

            return taskExist;
        }

        public void Delete(int id)
        {
            var task = _context.Task.FirstOrDefault(a => a.Id == id);

            if (task != null)
            {
                _context.Remove(task);
            }

            _context.SaveChanges();
        }

        private void ValidateTask(Task task)
        {
            if (task.Title.Length > 100 || task.Title == "")
                throw new ArgumentException("O campo Título deve ser obrigatório e ter no máximo 100 caracteres.");

            if(task.CreateDate == null)
                throw new ArgumentException("O campo Data de Criação deve ser obrigatório.");

            if (task.FinishDate < task.CreateDate)
                throw new Exception("A Data de Conclusão não pode ser anterior à Data de Criação.");
        }
    }
}
