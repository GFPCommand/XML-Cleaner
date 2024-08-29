using System.Diagnostics;

using System;
using System.IO;
using System.Threading.Tasks;
using XML_Cleaner.Model;
using System.Text;

namespace XML_Cleaner.Commands;

public class FileIOCommand
{
    private FileIOManager fileIOManager = new();

    private string? _fileContent;
    
    public string FileContent { 
        get {
            return _fileContent!;
        }
    }

    // write class file manager
    // commands must call functions from file manager
    public async Task OpenFile()
    {
        try
        {
            var file = await fileIOManager.DoOpenFilePickerAsync();
            if (file is null) return;

            if ((await file.GetBasicPropertiesAsync()).Size <= 1024 * 1024 * 1)
            {
                await using var readStream = await file.OpenReadAsync();
                using var reader = new StreamReader(readStream);
                _fileContent = await reader.ReadToEndAsync();
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
        Debug.WriteLine(_fileContent);
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