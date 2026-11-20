namespace System.Xml;

internal static class ValidateNames
{
	internal static int ParseNmtoken(string s, int offset)
	{
		int i;
		for (i = offset; i < s.Length && XmlCharType.IsNCNameSingleChar(s[i]); i++)
		{
		}
		return i - offset;
	}

	internal static int ParseNmtokenNoNamespaces(string s, int offset)
	{
		int i;
		for (i = offset; i < s.Length && (XmlCharType.IsNameSingleChar(s[i]) || s[i] == ':'); i++)
		{
		}
		return i - offset;
	}

	internal static int ParseNameNoNamespaces(string s, int offset)
	{
		int i = offset;
		if (i < s.Length)
		{
			if (!XmlCharType.IsStartNCNameSingleChar(s[i]) && s[i] != ':')
			{
				return 0;
			}
			for (i++; i < s.Length && (XmlCharType.IsNCNameSingleChar(s[i]) || s[i] == ':'); i++)
			{
			}
		}
		return i - offset;
	}

	internal static bool IsNameNoNamespaces(string s)
	{
		int num = ParseNameNoNamespaces(s, 0);
		if (num > 0)
		{
			return num == s.Length;
		}
		return false;
	}

	internal static int ParseNCName(string s, int offset)
	{
		int i = offset;
		if (i < s.Length)
		{
			if (!XmlCharType.IsStartNCNameSingleChar(s[i]))
			{
				return 0;
			}
			for (i++; i < s.Length && XmlCharType.IsNCNameSingleChar(s[i]); i++)
			{
			}
		}
		return i - offset;
	}

	internal static int ParseNCName(string s)
	{
		return ParseNCName(s, 0);
	}

	internal static string ParseNCNameThrow(string s)
	{
		ParseNCNameInternal(s, throwOnError: true);
		return s;
	}

	private static bool ParseNCNameInternal(string s, bool throwOnError)
	{
		int num = ParseNCName(s, 0);
		if (num == 0 || num != s.Length)
		{
			if (throwOnError)
			{
				ThrowInvalidName(s, 0, num);
			}
			return false;
		}
		return true;
	}

	internal static int ParseQName(string s, int offset, out int colonOffset)
	{
		colonOffset = 0;
		int num = ParseNCName(s, offset);
		if (num != 0)
		{
			offset += num;
			if ((uint)offset < (uint)s.Length && s[offset] == ':')
			{
				int num2 = ParseNCName(s, offset + 1);
				if (num2 != 0)
				{
					colonOffset = offset;
					num += num2 + 1;
				}
			}
		}
		return num;
	}

	internal static int ParseQNameThrow(string s)
	{
		int colonOffset;
		int num = ParseQName(s, 0, out colonOffset);
		if (num == 0 || num != s.Length)
		{
			ThrowInvalidName(s, 0, num);
		}
		return colonOffset;
	}

	internal static void ParseQNameThrow(string s, out string prefix, out string localName)
	{
		int num = ParseQNameThrow(s);
		if (num != 0)
		{
			prefix = s.Substring(0, num);
			localName = s.Substring(num + 1);
		}
		else
		{
			prefix = "";
			localName = s;
		}
	}

	internal static void ThrowInvalidName(string s, int offsetStartChar, int offsetBadChar)
	{
		if (offsetStartChar >= s.Length)
		{
			throw new XmlException(System.SR.Format("Xml_EmptyName", string.Empty));
		}
		if (XmlCharType.IsNCNameSingleChar(s[offsetBadChar]) && !XmlCharType.IsStartNCNameSingleChar(s[offsetBadChar]))
		{
			throw new XmlException("Xml_BadStartNameChar", XmlException.BuildCharExceptionArgs(s, offsetBadChar));
		}
		throw new XmlException("Xml_BadNameChar", XmlException.BuildCharExceptionArgs(s, offsetBadChar));
	}

	internal static Exception GetInvalidNameException(string s, int offsetStartChar, int offsetBadChar)
	{
		if (offsetStartChar >= s.Length)
		{
			return new XmlException("Xml_EmptyName", string.Empty);
		}
		if (XmlCharType.IsNCNameSingleChar(s[offsetBadChar]) && !XmlCharType.IsStartNCNameSingleChar(s[offsetBadChar]))
		{
			return new XmlException("Xml_BadStartNameChar", XmlException.BuildCharExceptionArgs(s, offsetBadChar));
		}
		return new XmlException("Xml_BadNameChar", XmlException.BuildCharExceptionArgs(s, offsetBadChar));
	}

	internal static void SplitQName(string name, out string prefix, out string lname)
	{
		int num = name.IndexOf(':');
		if (-1 == num)
		{
			prefix = string.Empty;
			lname = name;
			return;
		}
		if (num == 0 || name.Length - 1 == num)
		{
			object[] args = XmlException.BuildCharExceptionArgs(':', '\0');
			throw new ArgumentException(System.SR.Format("Xml_BadNameChar", args), "name");
		}
		prefix = name.Substring(0, num);
		num++;
		lname = name.Substring(num);
	}
}
