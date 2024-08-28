using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;
using XML_Cleaner.Commands;

namespace XML_Cleaner.ViewModel;

class MainWindowViewModel
{
	public FileIOCommand FileIO_command = new();

	public ElementClearingCommand ElementClearing_command = new();

	public ReactiveCommand<Unit, Task> FileOpenCommand { get; }
	public ReactiveCommand<bool, Unit> FileSaveCommand { get; }

	public ReactiveCommand<Unit, Unit> ClearExtraElementsCommand { get; }
	public ReactiveCommand<Unit, Unit> StopClearExtraElementsCommand { get; }

	public MainWindowViewModel()
	{
		FileOpenCommand = ReactiveCommand.Create(FileIO_command.OpenFile);
		FileSaveCommand = ReactiveCommand.Create<bool>(FileIO_command.SaveFile);

		// add isvalid fields for commands for defining of executing of it
		ClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.ClearExtraElements);
		StopClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.StopClearingExtraElements);
	}
}