using System.Collections.Generic;

namespace XML_Cleaner.Model;

public class Element
{
    public string? XPath { get; set; }
    public string? Condition { get; set; }
    public List<string>? Values { get; set; }

    
}