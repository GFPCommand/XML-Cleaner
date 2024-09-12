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

	private bool _canSave;
	private bool _canEdit;

	private IObservable<bool> _canClearObserver;
	private IObservable<bool> _canStopClearObserver;

	private IObservable<bool> _canSaveFileObserver;
	private IObservable<bool> _canEditExtraNodesObserver;

	public FileIOCommand FileIO_command;

	public ElementClearingCommand ElementClearing_command = new();

	public SettingUpElementCommand SettingUp_command;

	public ReactiveCommand<Unit, bool> FileOpenCommand { get; }
	public ReactiveCommand<bool, Unit> FileSaveCommand { get; }

	public ReactiveCommand<Unit, Unit> ClearExtraElementsCommand { get; }
	public ReactiveCommand<Unit, Unit> StopClearExtraElementsCommand { get; }

	public ReactiveCommand<bool, Unit> AddElementShowWindowCommand { get; }
	//public ReactiveCommand<Unit, Unit> RemoveElementCommand { get; }

	private Func<bool, Task> _action;
	private Func<bool, Task> _helpDelegate;

	private string? _fileName;
	private string? _fileSize = "0 Kb";
	private string? _filePath;

	public MainWindowViewModel()
	{
		FileIO_command = new(this);

		SettingUp_command = new();

		_canClearObserver = this.WhenAnyValue(x => x.CanClear);
		_canStopClearObserver = this.WhenAnyValue(x => x.CanStopClear);

		_canSaveFileObserver = this.WhenAnyValue(x => x.CanSave);
		_canEditExtraNodesObserver = this.WhenAnyValue(x => x.CanEdit);

		_action += FileIO_command.SaveFile;
		_helpDelegate += SettingUp_command.AddElementCommand;

		FileOpenCommand = ReactiveCommand.CreateFromTask(FileIO_command.OpenFile);
		FileSaveCommand = ReactiveCommand.CreateFromTask(_action, _canSaveFileObserver);

		ClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.ClearExtraElements, _canClearObserver);
		StopClearExtraElementsCommand = ReactiveCommand.Create(ElementClearing_command.StopClearingExtraElements, _canStopClearObserver);

		AddElementShowWindowCommand = ReactiveCommand.CreateFromTask(_helpDelegate, _canEditExtraNodesObserver);
		//RemoveElementCommand = ReactiveCommand.Create(SettingUp_command.RemoveElementCommand, _canEditExtraNodesObserver);
	}

	public string? FileName
	{
		get { return _fileName; }
		set {
			this.RaiseAndSetIfChanged(ref _fileName, value);
		}
	}

	public string? FileSize
	{
		get { return _fileSize; }
		set {
			this.RaiseAndSetIfChanged(ref _fileSize, value);
		}
	}

	public string? FilePath
	{
		get { return _filePath ?? "File path..."; }
		set {
			this.RaiseAndSetIfChanged(ref _filePath, value);
		}
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

	public bool CanSave
	{
		get { return _canSave; }
		set { this.RaiseAndSetIfChanged(ref _canSave, value); }
	}

	public bool CanEdit
	{
		get { return _canEdit; }
		set { this.RaiseAndSetIfChanged(ref _canEdit, value); }
	}
}

// https://habr.com/ru/articles/305350/
// https://www.reactiveui.net/docs/handbook/commands/