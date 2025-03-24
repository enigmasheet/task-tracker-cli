using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_tracker_cli.Managers
{
    public interface ITaskManager
    {
        void AddTask(string description);
        void UpdateTask(int id, string description);
        void DeleteTask(int id);
        void MarkTask(int id, string status);
        void ListTasks(string? status=null);
    }

    
}
