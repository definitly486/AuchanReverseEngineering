namespace System;

internal static class TypeIdentifiers
{
	private sealed class Display : TypeNames.ATypeName, ITypeIdentifier, ITypeName, IEquatable<ITypeName>
	{
		private readonly string displayName;

		private string internal_name;

		public override string DisplayName => displayName;

		public string InternalName => internal_name ?? (internal_name = GetInternalName());

		internal Display(string displayName)
		{
			this.displayName = displayName;
		}

		private string GetInternalName()
		{
			return TypeSpec.UnescapeInternalName(displayName);
		}

		public override ITypeName NestedName(ITypeIdentifier innerName)
		{
			return TypeNames.FromDisplay(DisplayName + "+" + innerName.DisplayName);
		}
	}

	private sealed class Internal : TypeNames.ATypeName, ITypeIdentifier, ITypeName, IEquatable<ITypeName>
	{
		private readonly string internalName;

		private string display_name;

		public override string DisplayName => display_name ?? (display_name = GetDisplayName());

		public string InternalName => internalName;

		internal Internal(string internalName)
		{
			this.internalName = internalName;
		}

		internal Internal(string nameSpaceInternal, ITypeIdentifier typeName)
		{
			internalName = nameSpaceInternal + "." + typeName.InternalName;
		}

		private string GetDisplayName()
		{
			return TypeSpec.EscapeDisplayName(internalName);
		}

		public override ITypeName NestedName(ITypeIdentifier innerName)
		{
			return TypeNames.FromDisplay(DisplayName + "+" + innerName.DisplayName);
		}
	}

	private sealed class NoEscape : TypeNames.ATypeName, ITypeIdentifier, ITypeName, IEquatable<ITypeName>
	{
		private readonly string simpleName;

		public override string DisplayName => simpleName;

		public string InternalName => simpleName;

		internal NoEscape(string simpleName)
		{
			this.simpleName = simpleName;
		}

		public override ITypeName NestedName(ITypeIdentifier innerName)
		{
			return TypeNames.FromDisplay(DisplayName + "+" + innerName.DisplayName);
		}
	}

	internal static ITypeIdentifier FromDisplay(string displayName)
	{
		return new Display(displayName);
	}

	internal static ITypeIdentifier FromInternal(string internalName)
	{
		return new Internal(internalName);
	}

	internal static ITypeIdentifier FromInternal(string internalNameSpace, ITypeIdentifier typeName)
	{
		return new Internal(internalNameSpace, typeName);
	}

	internal static ITypeIdentifier WithoutEscape(string simpleName)
	{
		return new NoEscape(simpleName);
	}
}
