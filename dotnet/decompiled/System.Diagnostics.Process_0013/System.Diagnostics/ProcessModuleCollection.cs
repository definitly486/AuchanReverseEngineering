using System.Collections;

namespace System.Diagnostics;

public class ProcessModuleCollection : ReadOnlyCollectionBase
{
	public ProcessModule this[int index] => (ProcessModule)base.InnerList[index];

	internal ProcessModuleCollection(int capacity)
	{
		if (capacity > 0)
		{
			base.InnerList.Capacity = capacity;
		}
	}

	internal void Add(ProcessModule module)
	{
		base.InnerList.Add(module);
	}

	internal void Insert(int index, ProcessModule module)
	{
		base.InnerList.Insert(index, module);
	}

	internal void RemoveAt(int index)
	{
		base.InnerList.RemoveAt(index);
	}

	internal void Dispose()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				((ProcessModule)enumerator.Current).Dispose();
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
