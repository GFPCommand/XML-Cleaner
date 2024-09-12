using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;
using XML_Cleaner.Commands;

namespace XML_Cleaner.ViewModel
{
	public class DialogWindowViewModel : ViewModelBase
	{
        private bool _isFileLoadable;

        private IObservable<bool> _isFileLoadableObserver;

        private SettingUpElementCommand _settingUpElementCommand = new();

        public ReactiveCommand<bool, Unit> LoadNodesFromFileCommand { get; }

        private Func<bool, Task> _action;

        public DialogWindowViewModel()
        {
            _action += _settingUpElementCommand.AddElementCommand;

            _isFileLoadableObserver = this.WhenAnyValue(x => x.IsFileLoadable);

            LoadNodesFromFileCommand = ReactiveCommand.CreateFromTask(_action, _isFileLoadableObserver);
        }
        public bool IsFileLoadable
        {
            get { return _isFileLoadable; } 
            set { this.RaiseAndSetIfChanged(ref _isFileLoadable, value); }
        }
    }
}
