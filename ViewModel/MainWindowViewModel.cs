using System.ComponentModel;
using System.Reactive;
using System.Runtime.CompilerServices;
using ReactiveUI;
using XML_Cleaner.Commands;

namespace XML_Cleaner.ViewModel;

class MainWindowViewModel : INotifyPropertyChanged
{
  public ReactiveCommand<Unit, Unit> FileOpenCommand {get;}

  public ReactiveCommand<bool, Unit> FileSaveCommand {get;}

  FileIOCommand FileIO = new();

  public event PropertyChangedEventHandler? PropertyChanged;

  public MainWindowViewModel()
  {
    FileOpenCommand = ReactiveCommand.Create(FileIO.OpenFile);
    FileSaveCommand = ReactiveCommand.Create<bool>(FileIO.SaveFile);
  }

	protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}