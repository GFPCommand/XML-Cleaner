using System.Diagnostics;

namespace XML_Cleaner.Commands
{
	public class FileIOCommand
	{
		public void OpenFile()
		{
			Debug.WriteLine("Open file");
		}

		public void SaveFile(bool isSaveAs)
		{
			Debug.WriteLine(isSaveAs ? "Save file as" : "Save file");
		}
	}
}

// https://docs.avaloniaui.net/docs/basics/user-interface/file-dialogs