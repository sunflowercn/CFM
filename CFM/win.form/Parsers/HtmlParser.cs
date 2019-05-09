using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Util;

namespace win.form.Parsers
{
    public class HtmlParser
    {
        public void Parse(TreeNode treeNode,string htmlText)
        {

        }
        public void RecursionHtmlNode(TreeNode treeNode, INode htmlNode, bool siblingRequired)
        {
            if (htmlNode == null || treeNode == null)
                return;

            TreeNode current = treeNode;
            TreeNode content;
            if (htmlNode is ITag)
            {
                ITag tag = (htmlNode as ITag);
                if (!tag.IsEndTag())
                {
                    string nodeString = tag.TagName;
                    if (tag.Attributes != null && tag.Attributes.Count > 0)
                    {
                        if (tag.Attributes["ID"] != null)
                        {
                            nodeString = nodeString + " { id=\"" + tag.Attributes["ID"].ToString() + "\" }";
                        }
                        if (tag.Attributes["HREF"] != null)
                        {
                            nodeString = nodeString + " { href=\"" + tag.Attributes["HREF"].ToString() + "\" }";
                        }
                    }
                    current = new TreeNode(nodeString);
                    treeNode.Nodes.Add(current);
                }
            }
            //获取节点间的内容 
            if (htmlNode.Children != null && htmlNode.Children.Count > 0)
            {
                this.RecursionHtmlNode(current, htmlNode.FirstChild, true);
                content = new TreeNode(htmlNode.FirstChild.GetText());
                treeNode.Nodes.Add(content);
            }
            //the sibling nodes 
            if (siblingRequired)
            {
                INode sibling = htmlNode.NextSibling;
                while (sibling != null)
                {
                    this.RecursionHtmlNode(treeNode, sibling, false);
                    sibling = sibling.NextSibling;
                }
            }
        }
    }
}
