
using System.Text.Json;

namespace Buisness.Services;

public class FileService
{
    private readonly string _directionPath;
    private readonly string _filePath;

    //Construktor:
    public FileService(string directionPath = "Data", string fileName = "list.json")
    {
        _directionPath = directionPath;
        _filePath = Path.Combine(directionPath, fileName);
    }

    //Save to fil:
    public void SaveToFile(string content)
    {
        if (!string.IsNullOrEmpty(content))
        {
            //Control if file exists, else a new file is created
            if (!Directory.Exists(_directionPath))
            {
                Directory.CreateDirectory(_directionPath);
                File.WriteAllText(_filePath, content);
            }
        }
    }
    public readonly JsonSerializerOptions _jsonSeralizerOptions;


    //Get from fil:
    public string? GetFromFile()
    {
        if(File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }
        return null;
    }
}
