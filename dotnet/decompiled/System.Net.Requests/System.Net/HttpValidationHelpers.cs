namespace System.Net;

internal static class HttpValidationHelpers
{
	public static bool IsInvalidMethodOrHeaderString(string stringValue)
	{
		for (int i = 0; i < stringValue.Length; i++)
		{
			switch (stringValue[i])
			{
			case '\t':
			case '\n':
			case '\r':
			case ' ':
			case '"':
			case '\'':
			case '(':
			case ')':
			case ',':
			case '/':
			case ':':
			case ';':
			case '<':
			case '=':
			case '>':
			case '?':
			case '@':
			case '[':
			case '\\':
			case ']':
			case '{':
			case '}':
				return true;
			}
		}
		return false;
	}
}
