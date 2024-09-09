using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;

namespace XML_Cleaner.Model;

public class FileIOManager
{
    public async Task<IStorageFile?> DoOpenFilePickerAsync()
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
            throw new NullReferenceException("Missing StorageProvider instance.");

        var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Open XML file",
            AllowMultiple = false,
			FileTypeFilter = [new("XML File") { Patterns = ["*.xml"] }, FilePickerFileTypes.All]
		});

        return files?.Count >= 1 ? files[0] : null;
    }

    public async Task<IStorageFile?> DoSaveFlePickerAsync()
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
            throw new NullReferenceException("Missing StorageProvider instance.");

        return await provider.SaveFilePickerAsync(new FilePickerSaveOptions()
        {
            Title = "Save XML File",
            FileTypeChoices = [new ("XML File") { Patterns = ["*.xml"] }, FilePickerFileTypes.All]
        });
    }
}