using System.Collections.Generic;
using XML_Cleaner.ViewModel;

namespace XML_Cleaner.Model;

public class Element : ViewModelBase
{
    public string? XPath { get; set; }
    public string? Condition { get; set; }
    public List<string>? Values { get; set; }

    
}