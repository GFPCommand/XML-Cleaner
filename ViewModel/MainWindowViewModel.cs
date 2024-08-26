using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using XML_Cleaner.Commands;

namespace XML_Cleaner.ViewModel;

class MainWindowViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}