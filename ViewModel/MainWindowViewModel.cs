using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;
using XML_Cleaner.Commands;

namespace XML_Cleaner.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
	private bool _canClear;
	private bool _canStopClear;

	private ulong _fileSize;

	private string _fileName = string.Empty;
	private string _filePath = string.Empty;

	public string FileName { 
		get { return _fileName; }
		set { this.RaiseAndSetIfChanged(ref _fileName, value); }
	}

	public ulong FileSize {
		get { return _fileSize; }
		set { this.RaiseAndSetIfChanged(ref _fileSize, value); }
	}

	public string FilePath
	{
		get { return _filePath; }
		set { this.RaiseAndSetIfChanged(ref _filePath, value); }
	}

	public bool CanClear
	{
		get { return _canClear; }
		set { this.RaiseAndSetIfChanged(ref _canClear, value); }
	}

	public bool CanStopClear
	{
		get { return _canStopClear; }
		set { this.RaiseAndSetIfChanged(ref _canStopClear, value); }
	}

	private IObservable<bool> _canClearObserver;
	private IObservable<bool> _canStopClearObserver;

	public FileIOCommand FileIO_command;

	public ElementClearingCommand ElementClearing_command = new();

	public ReactiveCommand<Unit, Unit> FileOpenCommand { get; }
	public ReactiveCommand<bool, Unit> FileSaveCommand { get; }

	public ReactiveCommand<Unit, Unit> ClearExtraElementsCommand { get; }
	public ReactiveCommand<Unit, Unit> StopClearExtraElementsCommand { get; }

	private Func<bool, Task> _action;

	public MainWindowViewModel()
	{
		FileIO_command = new(this);

		_canClearObserver = this.WhenAnyValue(x => x.CanClear);
		_canStopClearObserver = this.WhenAnyValue(x => x.CanStopClear);

		_action += FileIO_command.SaveFile;

		FileOpenCommand = ReactiveCommand.CreateFromTask(FileIO_command.OpenFile);
		FileSaveCommand = ReactiveCommand.CreateFromTask(_action);

		ClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.ClearExtraElements, _canClearObserver);
		StopClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.StopClearingExtraElements, _canStopClearObserver);
	}
}