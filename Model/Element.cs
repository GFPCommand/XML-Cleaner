using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Element
{
    public string? XPath { get; set; }
    public string? Condition { get; set; }
    public List<string>? Values { get; set; }
}