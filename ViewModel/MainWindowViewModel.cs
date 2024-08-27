using ReactiveUI;
using System.ComponentModel;
using System.Reactive;
using System.Runtime.CompilerServices;
using XML_Cleaner.Commands;

namespace XML_Cleaner.ViewModel;

class MainWindowViewModel : INotifyPropertyChanged
{
	public FileIOCommand FileIO_command = new();

	public ElementClearingCommand ElementClearing_command = new();

	public event PropertyChangedEventHandler? PropertyChanged;

	public ReactiveCommand<Unit, Unit> FileOpenCommand { get; }
	public ReactiveCommand<bool, Unit> FileSaveCommand { get; }

	public ReactiveCommand<Unit, Unit> ClearExtraElementsCommand { get; }
	public ReactiveCommand<Unit, Unit> StopClearExtraElementsCommand { get; }

	public MainWindowViewModel()
	{
		FileOpenCommand = ReactiveCommand.Create(FileIO_command.OpenFile);
		FileSaveCommand = ReactiveCommand.Create<bool>(FileIO_command.SaveFile);

		ClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.ClearExtraElements);
		StopClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.StopClearingExtraElements);
	}

	protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "") {
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}