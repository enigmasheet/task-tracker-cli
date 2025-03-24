using task_tracker_cli.Services;
using Task = task_tracker_cli.Models.Task;

namespace task_tracker_cli.Managers
{
    public class TaskManager: ITaskManager
    {
        private const string FilePath= "Tasks.json";
        private readonly IFileService _fileService;

        public TaskManager(IFileService fileService)
        {
            _fileService = fileService;
        }
        private List<Task> GetTasks()=> _fileService.LoadData<Task>(FilePath);
        private void SaveTasks(List<Task> tasks)
        {
            _fileService.SaveData(FilePath, tasks);
        }

        private static int GenerateId(List<Task> tasks) => tasks.Count > 0 ? tasks[^1].Id + 1 : 1;

        public void AddTask(string description)
        {
            var tasks = GetTasks();
            tasks.Add(new Task { Id = GenerateId(tasks), Description = description });
            SaveTasks(tasks);
            Console.WriteLine($"Task added successfully (ID: {tasks[^1].Id})");
        }
       

        public void UpdateTask(int id, string description)
        {
            var tasks = GetTasks();
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.Description = description;
                task.UpdatedAt = DateTime.Now;
                SaveTasks(tasks);
                Console.WriteLine("Task updated successfully.");
            }
            else
                Console.WriteLine("Task not found.");
        }

        public void DeleteTask(int id)
        {
            var tasks = GetTasks();
            tasks.RemoveAll(t => t.Id == id);
            SaveTasks(tasks);
            Console.WriteLine("Task deleted successfully.");
        }

        public void MarkTask(int id, string status)
        {
            var tasks = GetTasks();
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.Status = status;
                task.UpdatedAt = DateTime.Now;
                SaveTasks(tasks);
                Console.WriteLine($"Task marked as {status}.");
            }
            else
                Console.WriteLine("Task not found.");

        }

        public void ListTasks(string? status = null)
        {
            var tasks = GetTasks();
            var filteredTasks = status == null ? tasks : tasks.FindAll(t => t.Status == status);

            if (filteredTasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in filteredTasks)
            {
                Console.WriteLine($"[{task.Id}] {task.Description} - {task.Status} (Created: {task.CreatedAt})");
            }
        }
    }
}
