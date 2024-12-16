
using Buisness.Interfaces;
using Buisness.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Buisness.Services;

public class FileService_copy 
{
    //private readonly string _directionPath;
    //private readonly string _filePath;

    ////Construktor:
    //public FileService_copy(string directionPath = "data", string fileName = "list.json")
    //{
    //    _directionPath = directionPath;
    //    _filePath = Path.Combine(_directionPath, fileName);
    //}


    ////Save to fil:
    ////public void SaveToFile(string content)
    ////{
    ////    if (!string.IsNullOrEmpty(content))
    ////    {
    ////        //Control if file exists, else a new file is created
    ////        //if (!Directory.Exists(_directionPath))
    ////        //{
    ////        //    Directory.CreateDirectory(_directionPath);
    ////        //    File.WriteAllText(_filePath, content);
    ////        //}
    ////        if (!Directory.Exists(_directionPath))
    ////            Directory.CreateDirectory(_directionPath);

    ////        using var sw = new StreamWriter(_filePath);
    ////        sw.WriteLine(content);
    ////    }
    ////}
    ////public readonly JsonSerializerOptions _jsonSeralizerOptions;


    //public bool SaveListToFile(string content, ContactModel contact)
    //{
    //    try
    //    {
    //        if (!Directory.Exists(_directionPath))
    //            Directory.CreateDirectory(_directionPath);

    //        File.WriteAllText(_filePath, content);
    //        return true;
    //    }
    //    catch
    //    {
    //        Debug.WriteLine(ex.Message);
    //        return false;
    //    }

    //}




    //public bool SaveListToFile()
    //{
    //    try
    //    {
    //        _contactList.Add(contact);
    //        _fileService.SaveToFile(JsonSerializer.Serialize(contact));
    //        return true;
    //    }
    //    catch
    //    {

    //    }
    //}





    ////Get from fil:
    //public string? GetListFromFile()
    //{
    //    if (File.Exists(_filePath))
    //    {
    //        return File.ReadAllText(_filePath);
    //    }
    //    else
    //    {
    //    return null!;
    //    }
    //    //if (File.Exists(_filePath))
    //    //{
    //    //    using var sr = new StreamReader(_filePath);
    //    //    string content = sr.ReadToEnd();
    //    //    return content;
    //    //}
    //    //return string.Empty;
    //}

    //public bool GetListFromFile()
    //{
    //    var json = _fileService.GetFromFile();
    //    var data = JsonSerializer.Deserialize<List<ContactModel>>(json);
    //    if (data != null)
    //    {

    //    }
    //}



    //bool IFileService.SaveToFile(string content)
    //{
    //    throw new NotImplementedException();
    //}





}
