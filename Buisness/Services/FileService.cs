
using Buisness.Interfaces;
using System.Diagnostics;

namespace Buisness.Services;


public class FileService(string directionPath = "Data", string fileName = "list.json") : IFileService
{
    private readonly string _directoryPath = directionPath;
    private readonly string _filePath = Path.Combine(directionPath, fileName);


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
        try
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
        catch (Exception ex)
        {
            Debug.WriteLine($"Error reading from file: {ex.Message}");
            return null!;
        }
    }



}
