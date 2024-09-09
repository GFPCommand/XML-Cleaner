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

    private string? _fileContent;

    private FileInformation _file = new();

    public FileInformation File => _file;

    private MainWindowViewModel _mainWindowViewModel;

    public FileIOCommand(MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
    }

    public async Task<bool> OpenFile()
    {
        try
        {
            var file = await fileIOManager.DoOpenFilePickerAsync();
            if (file is null) return false;

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

			//_mainWindowViewModel.FileInfo = _file;

			_mainWindowViewModel.FileName = _file.FileName;
			_mainWindowViewModel.FileSize = $"{_file.FileSize} Kb";
			_mainWindowViewModel.FilePath = _file.Path;

			return true;
		}
        catch
        {
            Debug.WriteLine("Error while opening file");

			return false;
		}
    }

    public async Task SaveFile(bool isSaveAs)
    {
        try
        {
            if (isSaveAs)
            {
                var file = await fileIOManager.DoSaveFlePickerAsync();
                if (file is not null) return;

                var stream = new MemoryStream(Encoding.Default.GetBytes(_fileContent));
                await using var writeStream = await file!.OpenWriteAsync();
                await stream.CopyToAsync(writeStream);
            }
        }
        catch 
        {
            Debug.WriteLine("Error while saving file");
        }
    }
}