using System.Runtime.CompilerServices;

namespace System.IO.IsolatedStorage;

public abstract class IsolatedStorage : MarshalByRefObject
{
	private object _applicationIdentity;

	private object _assemblyIdentity;

	private object _domainIdentity;

	[CompilerGenerated]
	private string _003CIdentityHash_003Ek__BackingField;

	public IsolatedStorageScope Scope { get; private set; }

	protected virtual char SeparatorExternal => Path.DirectorySeparatorChar;

	protected virtual char SeparatorInternal => '.';

	private string? IdentityHash
	{
		[CompilerGenerated]
		set
		{
			_003CIdentityHash_003Ek__BackingField = value;
		}
	}

	protected void InitStore(IsolatedStorageScope scope, Type? domainEvidenceType, Type? assemblyEvidenceType)
	{
		VerifyScope(scope);
		Scope = scope;
		Helper.GetDefaultIdentityAndHash(out var identity, out var hash, SeparatorInternal);
		if (Helper.IsApplication(scope))
		{
			_applicationIdentity = identity;
		}
		else
		{
			if (Helper.IsDomain(scope))
			{
				_domainIdentity = identity;
				IFormatProvider formatProvider = null;
				IFormatProvider provider = formatProvider;
				Span<char> initialBuffer = stackalloc char[128];
				DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 3, formatProvider, initialBuffer);
				handler.AppendFormatted(hash);
				handler.AppendFormatted(SeparatorExternal);
				handler.AppendFormatted(hash);
				hash = string.Create(provider, initialBuffer, ref handler);
			}
			_assemblyIdentity = identity;
		}
		IdentityHash = hash;
	}

	private static void VerifyScope(IsolatedStorageScope scope)
	{
		switch (scope)
		{
		case IsolatedStorageScope.User | IsolatedStorageScope.Assembly:
		case IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly:
		case IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Roaming:
		case IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly | IsolatedStorageScope.Roaming:
		case IsolatedStorageScope.Assembly | IsolatedStorageScope.Machine:
		case IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly | IsolatedStorageScope.Machine:
		case IsolatedStorageScope.User | IsolatedStorageScope.Application:
		case IsolatedStorageScope.User | IsolatedStorageScope.Roaming | IsolatedStorageScope.Application:
		case IsolatedStorageScope.Machine | IsolatedStorageScope.Application:
			return;
		}
		throw new ArgumentException("IsolatedStorage_Scope_Invalid");
	}
}
