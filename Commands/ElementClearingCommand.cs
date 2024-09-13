using System.Diagnostics;

namespace XML_Cleaner.Commands
{
	public class ElementClearingCommand
	{
		public void ClearExtraElements()
		{
			// steps
			// 1. remove nodes by conditions
			// 2. remove empty lines

			Debug.WriteLine("Clearing");
		}

		// send CancellationToken when stop process
		public void StopClearingExtraElements()
		{
			Debug.WriteLine("Stop clearing");
		}
	}
}
