using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization;

public abstract class ReferenceResolver
{
	public abstract void AddReference(string referenceId, object value);

	public abstract string GetReference(object value, out bool alreadyExists);

	public abstract object ResolveReference(string referenceId);

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void PopReferenceForCycleDetection()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void PushReferenceForCycleDetection(object value)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual bool ContainsReferenceForCycleDetection(object value)
	{
		throw new NotSupportedException("Linked away");
	}
}
