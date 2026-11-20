using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/ListIterator", "", "Java.Util.IListIteratorInvoker")]
[JavaTypeParameters(new string[] { "E" })]
public interface IListIterator : IIterator, IJavaObject, IDisposable, IJavaPeerable
{
	new bool HasNext { get; }

	bool HasPrevious { get; }

	void Add(Java.Lang.Object? e);

	new Java.Lang.Object? Next();

	int NextIndex();

	Java.Lang.Object? Previous();

	int PreviousIndex();

	new void Remove();

	void Set(Java.Lang.Object? e);
}
