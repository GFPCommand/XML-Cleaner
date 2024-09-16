using System.Collections.Generic;
using System.Diagnostics;

namespace XML_Cleaner.CodeAnalyzer;

public class LexerAnalyzer
{
    private List<string> _input = [];

    private List<Lexem> _lexems = [];

    public LexerAnalyzer() {}

    private void Splitter(string content)
    {
		foreach (var item in content.Split(';'))
		{
			if (!string.IsNullOrEmpty(item))
			{
				_input.Add(item);
			}
		}
	}

    public void Parser(string content, string? rootNode = "")
    {
        string root = string.Empty;

        if (!string.IsNullOrWhiteSpace(rootNode)) root = $"/{rootNode}";

        Splitter(content);

        foreach (var item in _input)
        {
            int index = item.IndexOf('=');

            // if not found -> simple xpath
            if (index == -1) 
            {
                _lexems.Add(new Lexem() {Main_XPath = item});
                Debug.WriteLine(item);
                continue;
            }

            // if char after '=' not > -> nothing to do, this is syntax error
            if (item[index + 1] != '>') 
            {
                Debug.WriteLine($"Error in {item}");
                continue;
            }

            // pack it to Lexem's and send to translator for building xpath's

            // if condition start with '=>' -> get condition element
            string xpath = item.Substring(0, index).Trim();

            string cut_string = item.Remove(0, index + 2);

            int idx = cut_string.IndexOf('=');

            string node = cut_string.Substring(0, idx);

            string multipleConditions = string.Empty;

            // most likely need rename
            int idx_s = cut_string.IndexOf('[');
            int idx_z = cut_string.IndexOf(',');
            int idx_u = cut_string.IndexOf('&');

            if (idx_s == -1 || idx_z == -1)
            {
                string final = cut_string.Remove(0, idx + 1);

                List<string> strs = [];

                foreach (var innerItem in final.Split(','))
                {
                    strs.Add(innerItem);
                }

                string res = $"{root}/{xpath}[";

                if (strs.Count < 2) 
                {
                    string tmp = strs[0].Contains('!') ? $"{strs[0].Replace("!", "not(")})" : strs[0];
                    res += $"{node.Trim()}={tmp}";
                }
                else 
                {
                    bool isRemove = false;
                    int idx_rem = 0;

                    res += $"{node.Trim()}=";
                    for (int i = 0; i < strs.Count; i++)
                    {
                        if (isRemove) {
                            res += strs[i].Remove(0, idx_rem+1);
                            isRemove = false;
                        } else res += strs[i];

                        if (i != strs.Count-1){
                            if (strs[i+1].Contains("&")) {
                                idx_rem = strs[i+1].IndexOf('&');
                                isRemove = true;
                                res += " and ";
                            }
                            else res += " or ";
                        }
                    }
                }

                res += "]";

                //string res = $"{root}/{xpath}[{node.Trim()}={innerItem.Replace("&", "and")}]";
                Debug.WriteLine($"{res}");

                continue;
            }

            var innerItems = cut_string.Split(',');

            List<string> items = new List<string>();

            foreach (var innerItem in innerItems)
            {
                int idx_start = innerItem.IndexOf("[");
                int idx_end = innerItem.IndexOf("]");

                if (idx_start != -1 && idx_end != -1)
                {
                    string str = innerItem.Substring(idx_start+1, innerItem.Length-idx_start-2);

                    foreach (var item1 in str.Split(' '))
                    {
                        string elem = string.Empty;

                        if (item1.StartsWith('!'))
                        {
                            int i =  item1.IndexOf('!');
                            if (item1[i+1] != '"') elem = $"{item1.Replace("!", "not(")})";
                            else {
                            }
                        }
                        else if (item1.StartsWith('"'))
                        {

                        }
                        string not_item_str = item1.StartsWith('!') ? $"{item1.Replace("!", "not(")})" : item1;
                        //items.Add($"{node}={not_item_str}");
                        Debug.WriteLine($"1{node}={not_item_str}");
                        //Debug.WriteLine(elem);
                    }

                    continue;
                } 
                else
                {
                    string not_item_str = innerItem.StartsWith('!') ? $"{innerItem.Replace("!", "not(")})" : innerItem;
                    items.Add($"{xpath}[{not_item_str}]");
                    Debug.WriteLine($"2{xpath}[{not_item_str}");
                }
            }

            //string cut = cut_string.Remove(0, idx_s - 1);


            //Debug.WriteLine($"{root}/{xpath}[{node.Trim()}={cut}]");

            //Debug.WriteLine(xpath);
            //Debug.WriteLine(cut_string);
            //Debug.WriteLine(node);
        }
    }
}

// for multiple choice in [] set space or new line as delimiter
// 1. find '['
// 2. find ']'
// 3. select string between []
// 4. split strings in array -> new word after space and out of ""


// read string from start to '='
// if next char is '>' -> start condition
// else error
// read from '>' to '=' -> get conditional node
// if next char is '[' -> start multiple condition (read above)
// else if next char is ']' -> error