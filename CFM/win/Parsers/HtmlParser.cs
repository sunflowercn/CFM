using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;

namespace win.Parsers
{
   public class HtmlParser
    {
        public NodeList Parse(string htmlText)
        {
            Lexer lexer = new Lexer(htmlText);
            Parser parser = new Parser(lexer);
            NodeList htmlNodes = parser.Parse(null);
            return htmlNodes;
        }       
    }
}
