using System.Collections.Generic;

public class Element
{
    public string? XPath { get; set; }
    public string? Condition { get; set; }
    public string? Values { get; set; }

    public Element(string xpath, string condition, string values)
    {
        XPath = xpath;
        Condition = condition;
        Values = values;
    }
}