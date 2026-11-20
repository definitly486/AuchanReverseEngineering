using System;

namespace Auchan.Common.UniversalLinks;

public interface IActivationParametersStore
{
	object? PopFor(Type type);

	void PushFor(Type type, object parameters);
}
