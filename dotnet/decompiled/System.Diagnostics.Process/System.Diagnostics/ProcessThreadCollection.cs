using System.Collections;
using System.Reflection;

namespace System.Diagnostics;

[DefaultMember("Item")]
public class ProcessThreadCollection : ReadOnlyCollectionBase
{
	public ProcessThreadCollection(ProcessThread[] processThreads)
	{
		base.InnerList.AddRange(processThreads);
	}

	internal void Dispose()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				((ProcessThread)enumerator.Current).Dispose();
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}
}
