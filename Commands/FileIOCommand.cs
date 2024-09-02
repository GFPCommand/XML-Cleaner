using System.Diagnostics;

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using XML_Cleaner.Model;
using System.ComponentModel;
namespace XML_Cleaner.Commands;

public class FileIOCommand
{
    private FileIOManager fileIOManager = new();

    private string? _fileContent;

    private FileInformation _file = null!;

    public FileInformation File
    {
        get { return _file ?? new() { FullPath = "", Path = "File path...", FileSize = 0, FileName = "", FileContent = ""}; }
    }

	public async Task<FileInformation> OpenFile()
    {
        try
        {
            var file = await fileIOManager.DoOpenFilePickerAsync();
            if (file is null) return new();

            var value = (ulong)Math.Ceiling((double)(await file.GetBasicPropertiesAsync()).Size! / 1024);

            await using var readStream = await file.OpenReadAsync();
            using var reader = new StreamReader(readStream);
            _fileContent = await reader.ReadToEndAsync();

            _file = new()
            {
                FullPath = file.Path.LocalPath,
                Path = file.Path.AbsolutePath,
                FileSize = value,
                FileName = file.Name,
                FileContent = _fileContent
            };
        }
        catch
        {
            Debug.WriteLine("Error while opening file");
        }

        return _file;
    }

    public async Task SaveFile(bool isSaveAs)
    {
        try
        {
            var file = await fileIOManager.DoSaveFlePickerAsync();
            if (file is not null) return;

            var stream = new MemoryStream(Encoding.Default.GetBytes(_fileContent));
            await using var writeStream = await file!.OpenWriteAsync();
            await stream.CopyToAsync(writeStream);
        }
        catch 
        {
            Debug.WriteLine("Error while saving file");
        }
    }
}