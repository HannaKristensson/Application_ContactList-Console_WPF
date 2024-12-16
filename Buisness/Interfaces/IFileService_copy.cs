

namespace Buisness.Interfaces;

public interface IFileService_copy
{
    string? GetListFromFile();
    bool SaveListToFile(string content);
}

//public interface IContactService