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
            
            // most likely need rename
            int idx_s = cut_string.IndexOf('[');
            int idx_z = cut_string.IndexOf(',');
            int idx_u = cut_string.IndexOf('&');

            if (idx_s == -1 || idx_z == -1 || idx_u == -1)
            {
                string final = cut_string.Remove(0, idx + 1).Trim();
                Debug.WriteLine($"{root}/{xpath}[{node.Trim()}={final}]");
                continue;
            }

            Debug.WriteLine(xpath);
            Debug.WriteLine(cut_string);
            Debug.WriteLine(node);
        }
    }
}

// for multiple choice in [] set space or new line as delimiter
// 1. find '['
// 2. find ']'
// 3. select string between []
// 4. split strings in array -> new word after space


// read string from start to '='
// if next char is '>' -> start condition
// else error
// read from '>' to '=' -> get conditional node
// if next char is '[' -> start multiple condition (read above)
// else if next char is ']' -> error


// https://www.google.com/search?q=lexer+analyzer&oq=lexer+analyzer&gs_lcrp=EgZjaHJvbWUyBggAEEUYOdIBCDQ4NTJqMGoxqAIAsAIA&sourceid=chrome&ie=UTF-8
// https://www.geeksforgeeks.org/introduction-of-lexical-analysis/
// https://www.google.com/search?q=Lexical+Analysis&sourceid=chrome&ie=UTF-8
// https://www.tutorialspoint.com/compiler_design/compiler_design_lexical_analysis.htm
// https://www.tutorialspoint.com/compiler_design/compiler_design_semantic_analysis.htm
// https://wiki.livid.pp.ru/students/sp/lectures/3.html
// https://habr.com/ru/articles/663870/
// https://habr.com/ru/articles/515420/
// http://prog.tversu.ru/pr3/ex4.pdf
// http://prog.tversu.ru/pr3/codeStyle.pdf