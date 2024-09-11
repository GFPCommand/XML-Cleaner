using ReactiveUI;
using System;
using System.Reactive;
using XML_Cleaner.Commands;

namespace XML_Cleaner.ViewModel
{
	public class DialogWindowViewModel : ViewModelBase
	{
        private bool _isFileLoadable;

        private IObservable<bool> _isFileLoadableObserver;

        private SettingUpElementCommand _settingUpElementCommand = new();

        public ReactiveCommand<Unit, Unit> LoadNodesFromFileCommand { get; }

        public DialogWindowViewModel()
        {
            _isFileLoadableObserver = this.WhenAnyValue(x => x.IsFileLoadable);

            LoadNodesFromFileCommand = ReactiveCommand.Create(_settingUpElementCommand.AddElementCommand, _isFileLoadableObserver);
        }

        public bool IsFileLoadable
        {
            get { return _isFileLoadable; } 
            set { this.RaiseAndSetIfChanged(ref _isFileLoadable, value); }
        }
    }
}
