
using System.Text.Json;

namespace Buisness.Services;

public class FileService
{
    private readonly string _directionPath;
    private readonly string _filePath;

    //Konstruktor:
    public FileService(string directionPath = "Data", string fileName = "list.json")
    {
        _directionPath = directionPath;
        _filePath = Path.Combine(directionPath, fileName);
    }

    //Spara till fil:
    public void SaveToFile(string content)
    {
        if (!string.IsNullOrEmpty(content))
        {
            //Kontroll om fil finns, annars skapas ny
            if (!Directory.Exists(_directionPath))
            {
                Directory.CreateDirectory(_directionPath);
                File.WriteAllText(_filePath, content);
            }
        }
    }
    public readonly JsonSerializerOptions _jsonSeralizerOptions;


    //Hämta från fil:
    public string? GetFromFile()
    {
        if(File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }
        return null;
    }
}
