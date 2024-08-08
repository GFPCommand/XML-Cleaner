using System;
using System.Windows.Input;

namespace XML_Cleaner.Commands
{
	internal class FileIOCommand : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			CanExecuteChanged?.Invoke(null, new EventArgs());
			throw new NotImplementedException();
		}

		public void Execute(object? parameter)
		{
			throw new NotImplementedException();
		}
	}
}
