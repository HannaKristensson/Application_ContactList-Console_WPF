namespace Buisness.Interfaces
{
    public interface IFileService
    {
        string? GetListFromFile();
        bool SaveListToFile(string content);
    }
}