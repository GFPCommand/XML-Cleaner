using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using XML_Cleaner.Model;

namespace XML_Cleaner.Commands;
public class SettingUpElementCommand
{
	private string _fileContent = string.Empty;

	public string FileContent { 
		get { return _fileContent; }
	}

	// take out to base class for IO commands
    public async Task<string> AddElementCommand(bool isAddFromDialog)
	{
		if (!isAddFromDialog) return string.Empty;

		try
		{
			var file = await FileIOManager.DoOpenFilePickerAsync(isAddFromDialog);
			if (file is null) return string.Empty;

			await using var readStream = await file.OpenReadAsync();
			using var reader = new StreamReader(readStream);
			_fileContent = await reader.ReadToEndAsync();

			DialogWindow.XPA_Content = _fileContent;

			return _fileContent;
		}
		catch 
		{
			Debug.WriteLine("Error while opening file");

			return string.Empty;
		}
	}
}
// https://docs.avaloniaui.net/docs/tutorials/music-store-app/opening-a-dialog