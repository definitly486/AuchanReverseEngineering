using System;

namespace NLog.Internal;

internal class ReusableObjectCreator<T> where T : class
{
	public readonly struct LockOject : IDisposable
	{
		public readonly T Result;

		private readonly NLog.Internal.ReusableObjectCreator<T> _owner;

		public LockOject(NLog.Internal.ReusableObjectCreator<T> owner, T reusableObject)
		{
			Result = reusableObject;
			_owner = owner;
		}

		public void Dispose()
		{
			_owner?.Deallocate(Result);
		}
	}

	protected T _reusableObject;

	private readonly Action<T> _clearObject;

	private readonly Func<T> _createObject;

	protected ReusableObjectCreator(Func<T> createObject, Action<T> clearObject)
	{
		_reusableObject = createObject();
		_clearObject = clearObject;
		_createObject = createObject;
	}

	public LockOject Allocate()
	{
		T reusableObject = _reusableObject ?? _createObject();
		_reusableObject = null;
		return new LockOject(this, reusableObject);
	}

	private void Deallocate(T reusableObject)
	{
		_clearObject(reusableObject);
		_reusableObject = reusableObject;
	}
}
