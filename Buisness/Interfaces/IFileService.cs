namespace Buisness.Interfaces
{
    public interface IFileService
    {
        string? GetFromFile();
        void SaveToFile(string content);
    }
}