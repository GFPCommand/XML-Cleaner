using System.Diagnostics;

namespace XML_Cleaner.Commands
{
	public class ElementClearingCommand
	{
		public void ClearExtraElements()
		{
			Debug.WriteLine("Clearing");
		}

		// send CancellationToken when stop process
		public void StopClearingExtraElements()
		{
			Debug.WriteLine("Stop clearing");
		}
	}
}
