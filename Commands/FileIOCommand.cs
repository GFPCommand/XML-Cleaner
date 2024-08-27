using System.Diagnostics;

namespace XML_Cleaner.Commands
{
	public class FileIOCommand
	{

		// write class file manager
		// commands must call functions from file manager
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