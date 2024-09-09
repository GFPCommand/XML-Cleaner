using System.Threading.Tasks;

namespace XML_Cleaner.Commands;
public class SettingUpElementCommand
{
	private DialogWindow _dialogWindow;

	private MainWindow _mainWindow;

    public SettingUpElementCommand(DialogWindow dialogWindow, MainWindow mainWindow)
    {
		_dialogWindow = dialogWindow;
		_mainWindow = mainWindow;
    }

	// open dialog window and wait additonal info for next working
	// dialog window logic should be realized in separate class
    public async Task AddElementCommand()
	{
		await _dialogWindow.ShowDialog(_mainWindow);
	}

	public void RemoveElementCommand() 
	{

	}
}
// https://docs.avaloniaui.net/docs/tutorials/music-store-app/opening-a-dialog