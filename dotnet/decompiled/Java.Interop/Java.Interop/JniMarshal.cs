using System;
using System.Collections;

namespace Java.Interop;

public static class JniMarshal
{
	public static bool RecursiveEquals(object? objA, object? objB)
	{
		if (object.Equals(objA, objB))
		{
			return true;
		}
		IEnumerable enumerable = objA as IEnumerable;
		IEnumerable enumerable2 = objB as IEnumerable;
		if (enumerable != null && enumerable2 != null)
		{
			IEnumerator enumerator = enumerable.GetEnumerator();
			IEnumerator enumerator2 = enumerable2.GetEnumerator();
			try
			{
				bool flag;
				bool flag2;
				while (true)
				{
					flag = enumerator.MoveNext();
					flag2 = enumerator2.MoveNext();
					if (!(flag && flag2))
					{
						break;
					}
					if (!RecursiveEquals(enumerator.Current, enumerator2.Current))
					{
						return false;
					}
				}
				return flag == flag2;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				IDisposable disposable2 = enumerator2 as IDisposable;
				disposable?.Dispose();
				disposable2?.Dispose();
			}
		}
		return false;
	}
}
