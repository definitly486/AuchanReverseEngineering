using System.Collections;

namespace System.ComponentModel;

internal sealed class WeakHashtable : Hashtable
{
	private sealed class WeakKeyComparer : IEqualityComparer
	{
		bool IEqualityComparer.Equals(object x, object y)
		{
			if (x == null)
			{
				return y == null;
			}
			if (y != null && x.GetHashCode() == y.GetHashCode())
			{
				if (x is WeakReference weakReference)
				{
					if (!weakReference.IsAlive)
					{
						return false;
					}
					x = weakReference.Target;
				}
				if (y is WeakReference weakReference2)
				{
					if (!weakReference2.IsAlive)
					{
						return false;
					}
					y = weakReference2.Target;
				}
				return x == y;
			}
			return false;
		}

		int IEqualityComparer.GetHashCode(object obj)
		{
			return obj.GetHashCode();
		}
	}

	private static readonly IEqualityComparer s_comparer = new WeakKeyComparer();

	internal WeakHashtable()
		: base(s_comparer)
	{
	}
}
