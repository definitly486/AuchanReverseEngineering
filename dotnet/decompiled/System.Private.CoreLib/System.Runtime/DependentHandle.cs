namespace System.Runtime;

public struct DependentHandle : IDisposable
{
	private Ephemeron[] _data;

	public bool IsAllocated => _data != null;

	public object? Target
	{
		get
		{
			return UnsafeGetTarget();
		}
		set
		{
			Ephemeron[] data = _data;
			if (data == null || value != null)
			{
				ThrowHelper.ThrowInvalidOperationException();
			}
			else
			{
				data[0].Key = null;
			}
		}
	}

	public object? Dependent
	{
		get
		{
			return UnsafeGetDependent();
		}
		set
		{
			UnsafeSetDependent(value);
		}
	}

	public (object? Target, object? Dependent) TargetAndDependent
	{
		get
		{
			object dependent;
			return (Target: UnsafeGetTargetAndDependent(out dependent), Dependent: dependent);
		}
	}

	public DependentHandle(object? target, object? dependent)
	{
		_data = new Ephemeron[1];
		_data[0].Key = target;
		_data[0].Value = dependent;
		GC.register_ephemeron_array(_data);
	}

	internal object UnsafeGetTarget()
	{
		Ephemeron[] data = _data;
		if (data == null)
		{
			ThrowHelper.ThrowInvalidOperationException();
			return null;
		}
		object key = data[0].Key;
		if (key == GC.EPHEMERON_TOMBSTONE)
		{
			return null;
		}
		return key;
	}

	internal object UnsafeGetDependent()
	{
		Ephemeron[] data = _data;
		if (data == null)
		{
			ThrowHelper.ThrowInvalidOperationException();
			return null;
		}
		Ephemeron ephemeron = data[0];
		if (ephemeron.Key == GC.EPHEMERON_TOMBSTONE || ephemeron.Key == null)
		{
			return null;
		}
		return ephemeron.Value;
	}

	internal object UnsafeGetTargetAndDependent(out object dependent)
	{
		Ephemeron[] data = _data;
		if (data == null)
		{
			ThrowHelper.ThrowInvalidOperationException();
			dependent = null;
			return null;
		}
		Ephemeron ephemeron = data[0];
		if (ephemeron.Key != GC.EPHEMERON_TOMBSTONE && ephemeron.Key != null)
		{
			dependent = ephemeron.Value;
			return ephemeron.Key;
		}
		dependent = null;
		return null;
	}

	internal void UnsafeSetTargetToNull()
	{
		Ephemeron[] data = _data;
		if (data == null)
		{
			ThrowHelper.ThrowInvalidOperationException();
		}
		else
		{
			data[0].Key = null;
		}
	}

	internal void UnsafeSetDependent(object dependent)
	{
		Ephemeron[] data = _data;
		if (data == null)
		{
			ThrowHelper.ThrowInvalidOperationException();
		}
		else
		{
			data[0].Value = dependent;
		}
	}

	public void Dispose()
	{
		_data = null;
	}
}
