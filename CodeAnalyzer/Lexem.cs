using System.Collections.Generic;

namespace XML_Cleaner.CodeAnalyzer
{
	public class Lexem
	{
		public string? Main_XPath { get; set; }
		public List<string>? ConditionElements { get; set; }
		public List<string>? Conditions { get; set; }
	}
}
