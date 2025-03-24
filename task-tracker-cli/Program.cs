using Microsoft.Extensions.DependencyInjection;
using task_tracker_cli.Managers;
using task_tracker_cli.Services;


namespace task_tracker_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<ITaskManager, TaskManager>()
                .BuildServiceProvider();

            var taskManager = serviceProvider.GetService<ITaskManager>();

            if (args.Length == 0)
            {
                Console.WriteLine("Usage: task-cli <command> [arguments]");
                return;
            }

            string command = args[0];

            switch (command)
            {
                case "add":
                    if (args.Length < 2)
                        Console.WriteLine("Usage: task-cli add <description>");
                    else
                        taskManager.AddTask(string.Join(" ", args[1..]));
                    break;

                case "update":
                    if (args.Length < 3)
                        Console.WriteLine("Usage: task-cli update <id> <new description>");
                    else if (int.TryParse(args[1], out int updateId))
                        taskManager.UpdateTask(updateId, string.Join(" ", args[2..]));
                    else
                        Console.WriteLine("Invalid ID.");
                    break;

                case "delete":
                    if (args.Length < 2 || !int.TryParse(args[1], out int deleteId))
                        Console.WriteLine("Usage: task-cli delete <id>");
                    else
                        taskManager.DeleteTask(deleteId);
                    break;

                case "mark-in-progress":
                    if (args.Length < 2 || !int.TryParse(args[1], out int progressId))
                        Console.WriteLine("Usage: task-cli mark-in-progress <id>");
                    else
                        taskManager.MarkTask(progressId, "in-progress");
                    break;

                case "mark-done":
                    if (args.Length < 2 || !int.TryParse(args[1], out int doneId))
                        Console.WriteLine("Usage: task-cli mark-done <id>");
                    else
                        taskManager.MarkTask(doneId, "done");
                    break;

                case "list":
                    taskManager.ListTasks();
                    break;

                case "list-todo":
                    taskManager.ListTasks("todo");
                    break;

                case "list-done":
                    taskManager.ListTasks("done");
                    break;

                case "list-in-progress":
                    taskManager.ListTasks("in-progress");
                    break;

                default:
                    Console.WriteLine("Invalid command. Use 'list', 'add', 'update', 'delete', 'mark-in-progress', or 'mark-done'.");
                    break;
            }
        }
    }
}
