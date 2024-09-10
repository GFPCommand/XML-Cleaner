namespace XML_Cleaner.Commands;
public class SettingUpElementCommand
{
	private DialogWindow _dialogWindow;

    public SettingUpElementCommand(DialogWindow dialogWindow)
    {
		_dialogWindow = dialogWindow;
    }

    public void AddElementCommand()
	{
		_dialogWindow.Show();
	}

	public void RemoveElementCommand() 
	{

	}
}
// https://docs.avaloniaui.net/docs/tutorials/music-store-app/opening-a-dialog