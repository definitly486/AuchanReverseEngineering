using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Extensions;
using Auchan.Common.PersonalCabinet.DomainModels;

namespace Auchan.Common.PersonalCabinet.Authorization;

public static class AuthValidationHelper
{
	private const int BACKEND_NAME_BYTES_LENGTH_MAX = 50;

	public const int InputMaxLength = 25;

	private static List<Func<string?, bool>> _passwordRules = new List<Func<string, bool>>
	{
		(string? pw) => pw.Any(char.IsUpper),
		(string? pw) => pw.Any(char.IsLower),
		(string? pw) => pw.Any(char.IsDigit),
		(string? pw) => pw.Any((char c) => char.IsSymbol(c) || char.IsPunctuation(c))
	};

	[GeneratedRegex("^(?!.{65})([abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0-9_\\-.+]+)@([a-z0-9]+)((([.]?|[_-]{0,2})[a-z0-9]+)*)\\.([a-z]{2,})$", RegexOptions.None, int.MaxValue)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.37416")]
	private static Regex MainEmailPattern()
	{
		return _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__MainEmailPattern_0.Instance;
	}

	[GeneratedRegex("^((?!\\.)[\\w\\-_.]*[^.\\+\\s])(@(\\w+|(\\w+-\\w*)*))(\\w+\\.\\w+(\\.\\w+)?[^.\\W])$", RegexOptions.None, int.MaxValue)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.37416")]
	public static Regex IsValidEmailWithPlusAndDotsPattern()
	{
		return _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__IsValidEmailWithPlusAndDotsPattern_1.Instance;
	}

	public static bool IsValidFirstName(string value)
	{
		return ValidateName(value);
	}

	public static Task<bool> IsValidFirstNameAsync(string value, CancellationToken cancellationToken = default(CancellationToken))
	{
		return ValidateNameAsync(value, cancellationToken);
	}

	public static bool IsValidLastName(string value)
	{
		return ValidateName(value);
	}

	public static Task<bool> IsValidLastNameAsync(string value, CancellationToken cancellationToken = default(CancellationToken))
	{
		return ValidateNameAsync(value, cancellationToken);
	}

	public static bool IsValidDateOfBirth(DateTime? value)
	{
		if (value.HasValue)
		{
			return value.Value < DateTime.Now.Date.YearsAgo(18);
		}
		return false;
	}

	public static bool IsValidEmail(string? email)
	{
		if (string.IsNullOrWhiteSpace(email))
		{
			return false;
		}
		if (MainEmailPattern().Match(email).Success)
		{
			return IsValidEmailWithPlusAndDotsPattern().Match(email).Success;
		}
		return false;
	}

	public static async Task<bool> IsValidEmailAsync(string? email, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (string.IsNullOrWhiteSpace(email))
		{
			return false;
		}
		return !(await Task.WhenAll<bool>(Task.Run(() => MainEmailPattern().Match(email).Success, cancellationToken), Task.Run(() => IsValidEmailWithPlusAndDotsPattern().Match(email).Success, cancellationToken))).Any((bool i) => !i);
	}

	public static bool IsValidPhone(string? phone)
	{
		string text = Regex.Replace(phone ?? "", "[^0-9]", "", RegexOptions.None, TimeSpan.FromSeconds(60L));
		if (!string.IsNullOrWhiteSpace(phone))
		{
			return text.Length == 11;
		}
		return false;
	}

	public static bool IsValidGender(Gender value)
	{
		return true;
	}

	public static bool IsValidPassword(string? passwordText)
	{
		if (passwordText == null)
		{
			return false;
		}
		return passwordText.Length >= 1;
	}

	public static bool IsValidNewPassword(string? passwordText)
	{
		string? text = passwordText;
		if (text != null && text.Length >= 8)
		{
			return _passwordRules.Count((Func<string, bool> isValid) => isValid(passwordText)) >= 3;
		}
		return false;
	}

	private static Task<bool> ValidateNameAsync(string name, CancellationToken cancellationToken)
	{
		return Task.Run(() => ValidateName(name), cancellationToken);
	}

	private static bool ValidateName(string value)
	{
		if (!string.IsNullOrWhiteSpace(value) && value.Length >= 1 && !IsNameTooLarge(value))
		{
			return IsNameCorrect(value);
		}
		return false;
	}

	public static bool IsNameTooLarge(string name)
	{
		return Encoding.UTF8.GetByteCount(name) > 50;
	}

	public static string CutdownNameToMaxLength(string name)
	{
		while (IsNameTooLarge(name))
		{
			name = name.Substring(0, name.Length - 1);
		}
		return name;
	}

	private static bool IsNameCorrect(string name)
	{
		for (int i = 0; i < name.Length; i++)
		{
			switch (name[i])
			{
			case '-':
				if (!IsBetweenLetters(i, name))
				{
					return false;
				}
				break;
			case ' ':
				return false;
			default:
				if (!char.IsLetter(name[i]))
				{
					return false;
				}
				break;
			}
		}
		return true;
	}

	private static bool IsBetweenLetters(int indexToCheck, string source)
	{
		if (indexToCheck > 0 && indexToCheck < source.Length - 1 && char.IsLetter(source[indexToCheck - 1]))
		{
			return char.IsLetter(source[indexToCheck + 1]);
		}
		return false;
	}

	private static bool IsInTheEnd(int indexToCheck, string source)
	{
		if (indexToCheck > 0 && indexToCheck <= source.Length - 1 && char.IsLetter(source[indexToCheck - 1]))
		{
			return source.Length - 1 == indexToCheck;
		}
		return false;
	}
}
