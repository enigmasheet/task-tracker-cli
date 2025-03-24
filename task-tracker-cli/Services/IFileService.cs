namespace task_tracker_cli.Services
{
    public interface IFileService
    {
        List<T> LoadData<T>(string filePath);
        void SaveData<T>(string filePath, List<T> data);
    }
}
