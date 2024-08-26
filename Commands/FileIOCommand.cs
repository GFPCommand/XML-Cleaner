using System;
using System.Diagnostics;

namespace XML_Cleaner.Commands
{
	public class FileIOCommand
	{
		public void OpenFile(){
			Debug.WriteLine("Open file");
		}

		public void SaveFile(){
			Debug.WriteLine("Save file");
		}
	}
}
