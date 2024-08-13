using System.Collections.Generic;

public class Element
{
    public string? XPath { get; set; }
    public string? Condition { get; set; }
    public List<string>? Values { get; set; }

    public Element(string xpath, string condition, List<string> values)
    {
        XPath = xpath;
        Condition = condition;
        Values = values;
    }
}