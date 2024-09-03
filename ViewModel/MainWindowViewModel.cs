using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;
using XML_Cleaner.Commands;
using XML_Cleaner.Model;

namespace XML_Cleaner.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
	private bool _canClear;
	private bool _canStopClear;

	private IObservable<bool> _canClearObserver;
	private IObservable<bool> _canStopClearObserver;

	public FileIOCommand FileIO_command;

	public FileInformation FileInformation
	{
		get { return FileIO_command.File; }
		set
		{
			FileName = value.FileName;
			FileSize = value.FileSize.ToString();
			FilePath = value.Path;
		}
	}

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

	public string FileName
	{
		get { return FileInformation?.FileName; }
		set {
			string _fileName = FileInformation.FileName;
			this.RaiseAndSetIfChanged(ref _fileName, value);
		}
	}

	public string FileSize
	{
		get { return FileInformation?.FileSize.ToString(); }
		set {
			string fileSize = $"{FileInformation.FileSize} Kb";
			this.RaiseAndSetIfChanged(ref fileSize, value);
		}
	}

	public string FilePath
	{
		get { return FileInformation.Path ?? "File path..."; }
		set {
			string filePath = FileInformation.Path;
			this.RaiseAndSetIfChanged(ref filePath, value);
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
}