using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Net;

public class NetworkCredential : ICredentials
{
	private string _domain;

	private string _userName = string.Empty;

	private object _password;

	public string UserName
	{
		get
		{
			return _userName;
		}
		[param: AllowNull]
		set
		{
			_userName = value ?? string.Empty;
		}
	}

	public string Password
	{
		get
		{
			if (_password is SecureString sstr)
			{
				return MarshalToString(sstr);
			}
			return ((string)_password) ?? string.Empty;
		}
		[param: AllowNull]
		set
		{
			SecureString obj = _password as SecureString;
			_password = value;
			obj?.Dispose();
		}
	}

	public string Domain
	{
		get
		{
			return _domain;
		}
		[MemberNotNull("_domain")]
		[param: AllowNull]
		set
		{
			_domain = value ?? string.Empty;
		}
	}

	public NetworkCredential(string? userName, string? password)
		: this(userName, password, string.Empty)
	{
	}

	public NetworkCredential(string? userName, string? password, string? domain)
	{
		UserName = userName;
		Password = password;
		Domain = domain;
	}

	public NetworkCredential GetCredential(Uri? uri, string? authenticationType)
	{
		return this;
	}

	private static string MarshalToString(SecureString sstr)
	{
		if (sstr == null || sstr.Length == 0)
		{
			return string.Empty;
		}
		nint num = IntPtr.Zero;
		string empty = string.Empty;
		try
		{
			num = Marshal.SecureStringToGlobalAllocUnicode(sstr);
			return Marshal.PtrToStringUni(num);
		}
		finally
		{
			if (num != IntPtr.Zero)
			{
				Marshal.ZeroFreeGlobalAllocUnicode(num);
			}
		}
	}
}
