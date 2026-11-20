using System.Security.Authentication.ExtendedProtection;
using System.Security.Principal;

namespace System.Net.Security;

public sealed class NegotiateAuthentication : IDisposable
{
	private readonly NegotiateAuthenticationPal _pal;

	private readonly string _requestedPackage;

	private readonly bool _isServer;

	private readonly TokenImpersonationLevel _requiredImpersonationLevel;

	private readonly ProtectionLevel _requiredProtectionLevel;

	private readonly ExtendedProtectionPolicy _extendedProtectionPolicy;

	private readonly bool _isSecureConnection;

	private bool _isDisposed;

	private IIdentity _remoteIdentity;

	public bool IsAuthenticated
	{
		get
		{
			if (!_isDisposed)
			{
				return _pal.IsAuthenticated;
			}
			return false;
		}
	}

	public ProtectionLevel ProtectionLevel
	{
		get
		{
			if (IsSigned)
			{
				if (IsEncrypted)
				{
					return ProtectionLevel.EncryptAndSign;
				}
				return ProtectionLevel.Sign;
			}
			return ProtectionLevel.None;
		}
	}

	public bool IsSigned
	{
		get
		{
			if (!_isDisposed)
			{
				return _pal.IsSigned;
			}
			return false;
		}
	}

	public bool IsEncrypted
	{
		get
		{
			if (!_isDisposed)
			{
				return _pal.IsEncrypted;
			}
			return false;
		}
	}

	public bool IsServer => _isServer;

	public TokenImpersonationLevel ImpersonationLevel => _pal.ImpersonationLevel;

	public NegotiateAuthentication(NegotiateAuthenticationClientOptions clientOptions)
	{
		ArgumentNullException.ThrowIfNull(clientOptions, "clientOptions");
		_isServer = false;
		_requestedPackage = clientOptions.Package;
		_requiredImpersonationLevel = TokenImpersonationLevel.None;
		_requiredProtectionLevel = clientOptions.RequiredProtectionLevel;
		_pal = NegotiateAuthenticationPal.Create(clientOptions);
	}

	public void Dispose()
	{
		if (!_isDisposed)
		{
			_isDisposed = true;
			_pal?.Dispose();
			if (_remoteIdentity is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}

	public byte[]? GetOutgoingBlob(ReadOnlySpan<byte> incomingBlob, out NegotiateAuthenticationStatusCode statusCode)
	{
		if (_isDisposed)
		{
			throw new InvalidOperationException("net_auth_noauth");
		}
		byte[] outgoingBlob = _pal.GetOutgoingBlob(incomingBlob, out statusCode);
		if (statusCode == NegotiateAuthenticationStatusCode.Completed)
		{
			if (IsServer && _extendedProtectionPolicy != null && !CheckSpn())
			{
				statusCode = NegotiateAuthenticationStatusCode.TargetUnknown;
				return outgoingBlob;
			}
			if (_requiredImpersonationLevel != TokenImpersonationLevel.None && ImpersonationLevel < _requiredImpersonationLevel)
			{
				statusCode = NegotiateAuthenticationStatusCode.ImpersonationValidationFailed;
				return outgoingBlob;
			}
			if (_requiredProtectionLevel != ProtectionLevel.None && ProtectionLevel < _requiredProtectionLevel)
			{
				statusCode = NegotiateAuthenticationStatusCode.SecurityQosFailed;
			}
		}
		return outgoingBlob;
	}

	public string? GetOutgoingBlob(string? incomingBlob, out NegotiateAuthenticationStatusCode statusCode)
	{
		byte[] array = null;
		if (!string.IsNullOrEmpty(incomingBlob))
		{
			array = Convert.FromBase64String(incomingBlob);
		}
		byte[] outgoingBlob = GetOutgoingBlob(array, out statusCode);
		string result = null;
		if (outgoingBlob != null && outgoingBlob.Length != 0)
		{
			result = Convert.ToBase64String(outgoingBlob);
		}
		return result;
	}

	private bool CheckSpn()
	{
		if (_pal.Package == "Kerberos")
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return true;
		}
		if (_extendedProtectionPolicy.PolicyEnforcement == PolicyEnforcement.Never)
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return true;
		}
		if (_isSecureConnection && _extendedProtectionPolicy.ProtectionScenario == ProtectionScenario.TransportSelected)
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return true;
		}
		if (_extendedProtectionPolicy.CustomServiceNames == null)
		{
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return true;
		}
		string targetName = _pal.TargetName;
		if (string.IsNullOrEmpty(targetName))
		{
			if (_extendedProtectionPolicy.PolicyEnforcement == PolicyEnforcement.WhenSupported)
			{
				if (System.Net.NetEventSource.Log.IsEnabled())
				{
				}
				return true;
			}
			if (System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			return false;
		}
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		bool result = _extendedProtectionPolicy.CustomServiceNames.Contains(targetName);
		if (System.Net.NetEventSource.Log.IsEnabled())
		{
		}
		return result;
	}
}
