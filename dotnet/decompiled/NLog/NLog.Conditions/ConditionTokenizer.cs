using System;
using System.Text;
using NLog.Internal;

namespace NLog.Conditions;

internal sealed class ConditionTokenizer
{
	private readonly struct CharToTokenType
	{
		public readonly char Character;

		public readonly ConditionTokenType TokenType;

		public CharToTokenType(char character, ConditionTokenType tokenType)
		{
			Character = character;
			TokenType = tokenType;
		}
	}

	private static readonly ConditionTokenType[] CharIndexToTokenType = BuildCharIndexToTokenType();

	private readonly SimpleStringReader _stringReader;

	public ConditionTokenType TokenType { get; private set; }

	public string TokenValue { get; private set; }

	public ConditionTokenizer(SimpleStringReader stringReader)
	{
		_stringReader = stringReader;
		TokenType = ConditionTokenType.BeginningOfInput;
		TokenValue = string.Empty;
		GetNextToken();
	}

	public void Expect(ConditionTokenType tokenType)
	{
		if (TokenType != tokenType)
		{
			throw new ConditionParseException($"Expected token of type: {tokenType}, got {TokenType} ({TokenValue}).");
		}
		GetNextToken();
	}

	public string EatKeyword()
	{
		if (TokenType != ConditionTokenType.Keyword)
		{
			throw new ConditionParseException("Identifier expected");
		}
		string tokenValue = TokenValue;
		GetNextToken();
		return tokenValue;
	}

	public bool IsKeyword(string keyword)
	{
		if (TokenType != ConditionTokenType.Keyword)
		{
			return false;
		}
		return TokenValue.Equals(keyword, StringComparison.OrdinalIgnoreCase);
	}

	public bool IsEOF()
	{
		return TokenType == ConditionTokenType.EndOfInput;
	}

	public bool IsNumber()
	{
		return TokenType == ConditionTokenType.Number;
	}

	public bool IsToken(ConditionTokenType tokenType)
	{
		return TokenType == tokenType;
	}

	public void GetNextToken()
	{
		if (TokenType == ConditionTokenType.EndOfInput)
		{
			throw new ConditionParseException("Cannot read past end of stream.");
		}
		SkipWhitespace();
		int num = PeekChar();
		if (num == -1)
		{
			TokenType = ConditionTokenType.EndOfInput;
			return;
		}
		char c = (char)num;
		if (char.IsDigit(c))
		{
			ParseNumber(c);
			return;
		}
		switch (c)
		{
		case '\'':
			ParseSingleQuotedString(c);
			break;
		default:
			if (!char.IsLetter(c))
			{
				if (c == '}' || c == ':')
				{
					TokenType = ConditionTokenType.EndOfInput;
					break;
				}
				TokenValue = c.ToString();
				if (!TryGetComparisonToken(c) && !TryGetLogicalToken(c))
				{
					if (c < ' ' || c >= '\u0080')
					{
						throw new ConditionParseException($"Invalid token: {c}");
					}
					ConditionTokenType conditionTokenType = CharIndexToTokenType[(uint)c];
					if (conditionTokenType == ConditionTokenType.Invalid)
					{
						throw new ConditionParseException($"Invalid punctuation: {c}");
					}
					TokenType = conditionTokenType;
					TokenValue = new string(c, 1);
					ReadChar();
				}
				break;
			}
			goto case '_';
		case '_':
			ParseKeyword(c);
			break;
		}
	}

	private bool TryGetComparisonToken(char ch)
	{
		switch (ch)
		{
		case '<':
			ReadChar();
			switch (PeekChar())
			{
			case 62:
				TokenType = ConditionTokenType.NotEqual;
				TokenValue = "<>";
				ReadChar();
				return true;
			case 61:
				TokenType = ConditionTokenType.LessThanOrEqualTo;
				TokenValue = "<=";
				ReadChar();
				return true;
			default:
				TokenType = ConditionTokenType.LessThan;
				TokenValue = "<";
				return true;
			}
		case '>':
			ReadChar();
			if (PeekChar() == 61)
			{
				TokenType = ConditionTokenType.GreaterThanOrEqualTo;
				TokenValue = ">=";
				ReadChar();
				return true;
			}
			TokenType = ConditionTokenType.GreaterThan;
			TokenValue = ">";
			return true;
		default:
			return false;
		}
	}

	private bool TryGetLogicalToken(char ch)
	{
		switch (ch)
		{
		case '!':
			ReadChar();
			if (PeekChar() == 61)
			{
				TokenType = ConditionTokenType.NotEqual;
				TokenValue = "!=";
				ReadChar();
				return true;
			}
			TokenType = ConditionTokenType.Not;
			TokenValue = "!";
			return true;
		case '&':
			ReadChar();
			if (PeekChar() == 38)
			{
				TokenType = ConditionTokenType.And;
				TokenValue = "&&";
				ReadChar();
				return true;
			}
			throw new ConditionParseException("Expected '&&' but got '&'");
		case '|':
			ReadChar();
			if (PeekChar() == 124)
			{
				TokenType = ConditionTokenType.Or;
				TokenValue = "||";
				ReadChar();
				return true;
			}
			throw new ConditionParseException("Expected '||' but got '|'");
		case '=':
			ReadChar();
			if (PeekChar() == 61)
			{
				TokenType = ConditionTokenType.EqualTo;
				TokenValue = "==";
				ReadChar();
				return true;
			}
			TokenType = ConditionTokenType.EqualTo;
			TokenValue = "=";
			return true;
		default:
			return false;
		}
	}

	private static ConditionTokenType[] BuildCharIndexToTokenType()
	{
		CharToTokenType[] array = new CharToTokenType[6]
		{
			new CharToTokenType('(', ConditionTokenType.LeftParen),
			new CharToTokenType(')', ConditionTokenType.RightParen),
			new CharToTokenType('.', ConditionTokenType.Dot),
			new CharToTokenType(',', ConditionTokenType.Comma),
			new CharToTokenType('!', ConditionTokenType.Not),
			new CharToTokenType('-', ConditionTokenType.Minus)
		};
		ConditionTokenType[] array2 = new ConditionTokenType[128];
		for (int i = 0; i < 128; i++)
		{
			array2[i] = ConditionTokenType.Invalid;
		}
		CharToTokenType[] array3 = array;
		for (int j = 0; j < array3.Length; j++)
		{
			CharToTokenType charToTokenType = array3[j];
			array2[(uint)charToTokenType.Character] = charToTokenType.TokenType;
		}
		return array2;
	}

	private void ParseSingleQuotedString(char ch)
	{
		TokenType = ConditionTokenType.String;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ch);
		ReadChar();
		int num;
		while ((num = PeekChar()) != -1)
		{
			ch = (char)num;
			stringBuilder.Append((char)ReadChar());
			if (ch == '\'')
			{
				if (PeekChar() != 39)
				{
					break;
				}
				stringBuilder.Append('\'');
				ReadChar();
			}
		}
		if (num == -1)
		{
			throw new ConditionParseException("String literal is missing a closing quote character.");
		}
		TokenValue = stringBuilder.ToString();
	}

	private void ParseKeyword(char ch)
	{
		TokenType = ConditionTokenType.Keyword;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ch);
		ReadChar();
		int num;
		while ((num = PeekChar()) != -1 && ((ushort)num == 95 || (ushort)num == 45 || char.IsLetterOrDigit((char)num)))
		{
			stringBuilder.Append((char)ReadChar());
		}
		TokenValue = stringBuilder.ToString();
	}

	private void ParseNumber(char ch)
	{
		TokenType = ConditionTokenType.Number;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(ch);
		ReadChar();
		int num;
		while ((num = PeekChar()) != -1)
		{
			ch = (char)num;
			if (!char.IsDigit(ch) && ch != '.')
			{
				break;
			}
			stringBuilder.Append((char)ReadChar());
		}
		TokenValue = stringBuilder.ToString();
	}

	private void SkipWhitespace()
	{
		int num;
		while ((num = PeekChar()) != -1 && char.IsWhiteSpace((char)num))
		{
			ReadChar();
		}
	}

	private int PeekChar()
	{
		return _stringReader.Peek();
	}

	private int ReadChar()
	{
		return _stringReader.Read();
	}
}
