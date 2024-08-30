using System.Diagnostics;

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using XML_Cleaner.Model;
using XML_Cleaner.ViewModel;
namespace XML_Cleaner.Commands;

public class FileIOCommand
{
    private FileIOManager fileIOManager = new();

    private MainWindowViewModel _mainVM;

    private string? _fileContent;
    
    public string FileContent { 
        get {
            return _fileContent!;
        }
    }

    public FileIOCommand(MainWindowViewModel reactiveObject)
    {
        _mainVM = reactiveObject;
    }

    public async Task OpenFile()
    {
        try
        {
            var file = await fileIOManager.DoOpenFilePickerAsync();
            if (file is null) return;

            _mainVM.FileName = file.Name;
            _mainVM.FilePath = file.Path.LocalPath;
            var value = Math.Ceiling((double)(await file.GetBasicPropertiesAsync()).Size! / 1024).ToString();
            _mainVM.FileSize = value + " Kb";

            await using var readStream = await file.OpenReadAsync();
            using var reader = new StreamReader(readStream);
            _fileContent = await reader.ReadToEndAsync();
        }
        catch
        {
            Debug.WriteLine("ERROR");
        }
    }

    public async Task SaveFile(bool isSaveAs)
    {
        try
        {
            var file = await fileIOManager.DoSaveFlePickerAsync();
            if (file is not null) return;

            if (_fileContent?.Length <= 1024 * 1024 * 1)
            {
                var stream = new MemoryStream(Encoding.Default.GetBytes(_fileContent));
                await using var writeStream = await file!.OpenWriteAsync();
                await stream.CopyToAsync(writeStream);
            }
            else
            {
                throw new Exception("File exceeded 1MB limit.");
            }
        }
        catch 
        {
            Debug.WriteLine("ERROR");
        }
    }
}