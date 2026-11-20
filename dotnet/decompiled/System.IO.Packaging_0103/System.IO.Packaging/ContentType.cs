using System.Collections.Generic;
using System.Text;

namespace System.IO.Packaging;

internal sealed class ContentType
{
	private string _contentType;

	private string _type = string.Empty;

	private string _subType = string.Empty;

	private string _originalString;

	private Dictionary<string, string> _parameterDictionary;

	private bool _isInitialized;

	private static readonly char[] s_allowedCharacters = new char[15]
	{
		'!', '#', '$', '%', '&', '\'', '*', '+', '-', '.',
		'^', '_', '`', '|', '~'
	};

	private static readonly char[] s_linearWhiteSpaceChars = new char[4] { ' ', '\n', '\r', '\t' };

	internal string TypeComponent => _type;

	internal string SubTypeComponent => _subType;

	internal Dictionary<string, string>.Enumerator ParameterValuePairs
	{
		get
		{
			EnsureParameterDictionary();
			return _parameterDictionary.GetEnumerator();
		}
	}

	internal ContentType(string contentType)
	{
		if (contentType == null)
		{
			throw new ArgumentNullException("contentType");
		}
		if (contentType.Length == 0)
		{
			_contentType = string.Empty;
		}
		else
		{
			if (IsLinearWhiteSpaceChar(contentType[0]) || IsLinearWhiteSpaceChar(contentType[contentType.Length - 1]))
			{
				throw new ArgumentException(System.SR.ContentTypeCannotHaveLeadingTrailingLWS);
			}
			ValidateCarriageReturns(contentType);
			int num = contentType.IndexOf(';');
			if (num == -1)
			{
				ParseTypeAndSubType(contentType);
			}
			else
			{
				ParseTypeAndSubType(contentType.Substring(0, num));
				ParseParameterAndValue(contentType.Substring(num));
			}
		}
		_originalString = contentType;
		_isInitialized = true;
	}

	internal bool AreTypeAndSubTypeEqual(ContentType contentType)
	{
		return AreTypeAndSubTypeEqual(contentType, allowParameterValuePairs: false);
	}

	internal bool AreTypeAndSubTypeEqual(ContentType contentType, bool allowParameterValuePairs)
	{
		bool result = false;
		if (contentType != null)
		{
			if (!allowParameterValuePairs)
			{
				if (_parameterDictionary != null && _parameterDictionary.Count > 0)
				{
					return false;
				}
				Dictionary<string, string>.Enumerator parameterValuePairs = contentType.ParameterValuePairs;
				parameterValuePairs.MoveNext();
				if (parameterValuePairs.Current.Key != null)
				{
					return false;
				}
			}
			result = string.Equals(_type, contentType.TypeComponent, StringComparison.OrdinalIgnoreCase) && string.Equals(_subType, contentType.SubTypeComponent, StringComparison.OrdinalIgnoreCase);
		}
		return result;
	}

	public override string ToString()
	{
		if (_contentType == null)
		{
			if (!_isInitialized)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(_type);
			stringBuilder.Append('/');
			stringBuilder.Append(_subType);
			if (_parameterDictionary != null && _parameterDictionary.Count > 0)
			{
				foreach (string key in _parameterDictionary.Keys)
				{
					stringBuilder.Append(s_linearWhiteSpaceChars[0]);
					stringBuilder.Append(';');
					stringBuilder.Append(s_linearWhiteSpaceChars[0]);
					stringBuilder.Append(key);
					stringBuilder.Append('=');
					stringBuilder.Append(_parameterDictionary[key]);
				}
			}
			_contentType = stringBuilder.ToString();
		}
		return _contentType;
	}

	private static void ValidateCarriageReturns(string contentType)
	{
		int num = contentType.IndexOf(s_linearWhiteSpaceChars[2]);
		while (num != -1)
		{
			if (contentType[num - 1] == s_linearWhiteSpaceChars[1] || contentType[num + 1] == s_linearWhiteSpaceChars[1])
			{
				num = contentType.IndexOf(s_linearWhiteSpaceChars[2], ++num);
				continue;
			}
			throw new ArgumentException(System.SR.InvalidLinearWhiteSpaceCharacter);
		}
	}

	private void ParseTypeAndSubType(string typeAndSubType)
	{
		typeAndSubType = typeAndSubType.TrimEnd(s_linearWhiteSpaceChars);
		string[] array = typeAndSubType.Split(PackUriHelper.s_forwardSlashCharArray);
		if (array.Length != 2)
		{
			throw new ArgumentException(System.SR.InvalidTypeSubType);
		}
		_type = ValidateToken(array[0]);
		_subType = ValidateToken(array[1]);
	}

	private void ParseParameterAndValue(string parameterAndValue)
	{
		while (parameterAndValue != string.Empty)
		{
			if (parameterAndValue[0] != ';')
			{
				throw new ArgumentException(System.SR.ExpectingSemicolon);
			}
			if (parameterAndValue.Length == 1)
			{
				throw new ArgumentException(System.SR.ExpectingParameterValuePairs);
			}
			parameterAndValue = parameterAndValue.Substring(1);
			parameterAndValue = parameterAndValue.TrimStart(s_linearWhiteSpaceChars);
			int num = parameterAndValue.IndexOf('=');
			if (num <= 0 || num == parameterAndValue.Length - 1)
			{
				throw new ArgumentException(System.SR.InvalidParameterValuePair);
			}
			int num2 = num + 1;
			int lengthOfParameterValue = GetLengthOfParameterValue(parameterAndValue, num2);
			EnsureParameterDictionary();
			_parameterDictionary.Add(ValidateToken(parameterAndValue.Substring(0, num)), ValidateQuotedStringOrToken(parameterAndValue.Substring(num2, lengthOfParameterValue)));
			parameterAndValue = parameterAndValue.Substring(num2 + lengthOfParameterValue).TrimStart(s_linearWhiteSpaceChars);
		}
	}

	private static int GetLengthOfParameterValue(string s, int startIndex)
	{
		int num = 0;
		if (s[startIndex] != '"')
		{
			int num2 = s.IndexOf(';', startIndex);
			if (num2 != -1)
			{
				int num3 = s.IndexOfAny(s_linearWhiteSpaceChars, startIndex);
				num = ((num3 == -1 || num3 >= num2) ? num2 : num3);
			}
			else
			{
				num = num2;
			}
			if (num == -1)
			{
				num = s.Length;
			}
		}
		else
		{
			bool flag = false;
			num = startIndex;
			while (!flag)
			{
				num = s.IndexOf('"', ++num);
				if (num == -1)
				{
					throw new ArgumentException(System.SR.InvalidParameterValue);
				}
				if (s[num - 1] != '\\')
				{
					flag = true;
					num++;
				}
			}
		}
		return num - startIndex;
	}

	private static string ValidateToken(string token)
	{
		if (string.IsNullOrEmpty(token))
		{
			throw new ArgumentException(System.SR.InvalidToken_ContentType);
		}
		for (int i = 0; i < token.Length; i++)
		{
			if (!IsAsciiLetterOrDigit(token[i]) && !IsAllowedCharacter(token[i]))
			{
				throw new ArgumentException(System.SR.InvalidToken_ContentType);
			}
		}
		return token;
	}

	private static string ValidateQuotedStringOrToken(string parameterValue)
	{
		if (string.IsNullOrEmpty(parameterValue))
		{
			throw new ArgumentException(System.SR.InvalidParameterValue);
		}
		if (parameterValue.Length >= 2 && parameterValue.StartsWith("\"", StringComparison.Ordinal) && parameterValue.EndsWith("\"", StringComparison.Ordinal))
		{
			ValidateQuotedText(parameterValue.Substring(1, parameterValue.Length - 2));
		}
		else
		{
			ValidateToken(parameterValue);
		}
		return parameterValue;
	}

	private static void ValidateQuotedText(string quotedText)
	{
		for (int i = 0; i < quotedText.Length; i++)
		{
			if (!IsLinearWhiteSpaceChar(quotedText[i]))
			{
				if (quotedText[i] <= ' ' || quotedText[i] >= 'ÿ')
				{
					throw new ArgumentException(System.SR.InvalidParameterValue);
				}
				if (quotedText[i] == '"' && (i == 0 || quotedText[i - 1] != '\\'))
				{
					throw new ArgumentException(System.SR.InvalidParameterValue);
				}
			}
		}
	}

	private static bool IsAllowedCharacter(char character)
	{
		return Array.IndexOf(s_allowedCharacters, character) >= 0;
	}

	private static bool IsAsciiLetterOrDigit(char character)
	{
		if (!IsAsciiLetter(character))
		{
			if (character >= '0')
			{
				return character <= '9';
			}
			return false;
		}
		return true;
	}

	private static bool IsAsciiLetter(char character)
	{
		if (character < 'a' || character > 'z')
		{
			if (character >= 'A')
			{
				return character <= 'Z';
			}
			return false;
		}
		return true;
	}

	private static bool IsLinearWhiteSpaceChar(char ch)
	{
		if (ch > ' ')
		{
			return false;
		}
		int num = Array.IndexOf(s_linearWhiteSpaceChars, ch);
		return num != -1;
	}

	private void EnsureParameterDictionary()
	{
		if (_parameterDictionary == null)
		{
			_parameterDictionary = new Dictionary<string, string>();
		}
	}
}
