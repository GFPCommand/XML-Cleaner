using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;
using XML_Cleaner.Commands;

namespace XML_Cleaner.ViewModel;

class MainWindowViewModel
{
	public string filename { get; set; }
	public string filepath { get; set; }
	public string filesize { get; set; }

	public FileIOCommand FileIO_command = new();

	public ElementClearingCommand ElementClearing_command = new();

	public ReactiveCommand<Unit, Task> FileOpenCommand { get; }
	public ReactiveCommand<bool, Task> FileSaveCommand { get; }

	public ReactiveCommand<Unit, Unit> ClearExtraElementsCommand { get; }
	public ReactiveCommand<Unit, Unit> StopClearExtraElementsCommand { get; }

	Func<bool, Task> action;

	public MainWindowViewModel()
	{
		filename = "File";
		filepath = "path";
		filesize = "too much";

		action += FileIO_command.SaveFile;

		FileOpenCommand = ReactiveCommand.Create(FileIO_command.OpenFile);
		FileSaveCommand = ReactiveCommand.Create(action);

		// add isvalid fields for commands for defining of executing of it
		ClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.ClearExtraElements);
		StopClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.StopClearingExtraElements);
	}
}