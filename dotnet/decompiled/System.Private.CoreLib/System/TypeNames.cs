namespace System;

internal static class TypeNames
{
	internal abstract class ATypeName : ITypeName, IEquatable<ITypeName>
	{
		public abstract string DisplayName { get; }

		public abstract ITypeName NestedName(ITypeIdentifier innerName);

		public bool Equals(ITypeName other)
		{
			if (other != null)
			{
				return DisplayName == other.DisplayName;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return DisplayName.GetHashCode();
		}

		public override bool Equals(object other)
		{
			return Equals(other as ITypeName);
		}
	}

	private sealed class Display : ATypeName
	{
		private readonly string displayName;

		public override string DisplayName => displayName;

		internal Display(string displayName)
		{
			this.displayName = displayName;
		}

		public override ITypeName NestedName(ITypeIdentifier innerName)
		{
			return new Display(DisplayName + "+" + innerName.DisplayName);
		}
	}

	internal static ITypeName FromDisplay(string displayName)
	{
		return new Display(displayName);
	}
}
