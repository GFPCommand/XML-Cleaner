using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;

namespace XML_Cleaner.Model;

// maybe make as service
public static class FileIOManager
{
    private static List<FilePickerFileType> _filePickerFileTypes = [];

    public static async Task<IStorageFile?> DoOpenFilePickerAsync(bool isDialogInstance)
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
            throw new NullReferenceException("Missing StorageProvider instance.");

        if (isDialogInstance) _filePickerFileTypes = [new("XPA File") { Patterns = ["*.xpa"]}, FilePickerFileTypes.All];
        else _filePickerFileTypes = [new("XML File") { Patterns = ["*.xml"] }, FilePickerFileTypes.All];

        var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Open XML file",
            AllowMultiple = false,
			FileTypeFilter = _filePickerFileTypes
		});

        return files?.Count >= 1 ? files[0] : null;
    }

    public static async Task<IStorageFile?> DoSaveFlePickerAsync()
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