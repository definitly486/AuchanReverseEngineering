namespace System;

internal interface ITypeIdentifier : ITypeName, IEquatable<ITypeName>
{
	string InternalName { get; }
}
