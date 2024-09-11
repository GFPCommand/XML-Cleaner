using System.Collections.Generic;

namespace XML_Cleaner.CodeAnalyzer;

public class LexerAnalyzer
{
    public List<string> InputLexems = [];

    public LexerAnalyzer() {}

    // maybe set all string from view and parse here
    public void AddLexemToList(string lexem)
    {
        if (lexem is not null)
        {
            InputLexems.Add(lexem);
        }
    }

    public void Analyzer()
    {

    }
}

// for multiple choice in [] set space or new line as delimiter
// 1. find '['
// 2. find ']'
// 3. select string between []
// 4. split strings in array -> new word after space


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