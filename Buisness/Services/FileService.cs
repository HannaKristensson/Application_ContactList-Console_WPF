
using Buisness.Interfaces;
using System.Diagnostics;

namespace Buisness.Services;

//public class FileService : IFileService
//{

//private readonly string _directoryPath;
//private readonly string _filePath;

////Constructor:
//public FileService(string directoryPath, string fileName)
//{
//    _directoryPath = directoryPath;
//    _filePath = Path.Combine(_directoryPath, fileName);
//}

public class FileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    //Construktor:
    public FileService(string directionPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directionPath;
        _filePath = Path.Combine(directionPath, fileName);
    }


    //Save to fil:
    public bool SaveListToFile(string content)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            File.WriteAllText(_filePath, content);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving to file: {ex.Message}");
            return false;
        }

    }


    //Get from fil:
    public string? GetListFromFile()
    {
        if (File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }
        else
        {
            Debug.WriteLine("File not found.");
            return null!;
        }
    }
}
