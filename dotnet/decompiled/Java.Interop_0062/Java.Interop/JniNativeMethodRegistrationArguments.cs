using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Java.Interop;

public struct JniNativeMethodRegistrationArguments
{
	[CompilerGenerated]
	private readonly string? _003CMethods_003Ek__BackingField;

	private ICollection<JniNativeMethodRegistration> _registrations;

	public JniNativeMethodRegistrationArguments(ICollection<JniNativeMethodRegistration> registrations, string? methods)
	{
		_registrations = registrations ?? throw new ArgumentNullException("registrations");
		_003CMethods_003Ek__BackingField = methods;
	}
}
