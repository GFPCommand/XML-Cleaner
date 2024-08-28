using System.Diagnostics;

using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;

namespace XML_Cleaner.Commands
{
	public class FileIOCommand
	{
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
            var file = await DoOpenFilePickerAsync();
            if (file is null) return;

            // Limit the text file to 1MB so that the demo won't lag.
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

private async Task<IStorageFile?> DoOpenFilePickerAsync()
    {
        // For learning purposes, we opted to directly get the reference
        // for StorageProvider APIs here inside the ViewModel. 

        // For your real-world apps, you should follow the MVVM principles
        // by making service classes and locating them with DI/IoC.

        // See IoCFileOps project for an example of how to accomplish this.
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
            throw new NullReferenceException("Missing StorageProvider instance.");

        var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Open XML file",
            AllowMultiple = false
        });

        return files?.Count >= 1 ? files[0] : null;
    }

		public void SaveFile(bool isSaveAs)
		{
			Debug.WriteLine(isSaveAs ? "Save file as" : "Save file");
		}
	}
}