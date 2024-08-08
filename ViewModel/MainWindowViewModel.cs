using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XML_Cleaner.ViewModel;

class MainWindowViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}