using System.Diagnostics.CodeAnalysis;

namespace Auchan.Common.Common;

public static class HtmlConverter
{
	[return: NotNullIfNotNull("content")]
	public static string? WrapIntoHtml(string? content)
	{
		if (content != null && !content.Contains("</html>"))
		{
			return "<html>\n                        <head>\n                            <style>\n                                html, body {\n                                    word-break:break-word;\n                                    width:100%;max-width:100%;\n                                    height:100%;\n                                    margin:0;\n                                    padding:0;\n                                    font-size:14px;\n                                    font-family:'Roboto',sans-serif; }\n                                    img, table {\n                                    width:100% !important;\n                                    max-width:100%; }\n                            </style>\n                        </head>\n                        <body>\n                            " + content + "\n                        </body>\n                    </html>";
		}
		return content;
	}
}
