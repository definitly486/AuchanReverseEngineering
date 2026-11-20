using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util;

[Register("java/util/ListIterator", "", "Java.Util.IListIteratorInvoker")]
[JavaTypeParameters(new string[] { "E" })]
public interface IListIterator : IIterator, IJavaObject, IDisposable, IJavaPeerable
{
	new bool HasNext
	{
		[Register("hasNext", "()Z", "GetHasNextHandler:Java.Util.IListIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool HasPrevious
	{
		[Register("hasPrevious", "()Z", "GetHasPreviousHandler:Java.Util.IListIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("add", "(Ljava/lang/Object;)V", "GetAdd_Ljava_lang_Object_Handler:Java.Util.IListIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Add(Java.Lang.Object? e);

	[Register("next", "()Ljava/lang/Object;", "GetNextHandler:Java.Util.IListIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new Java.Lang.Object? Next();

	[Register("nextIndex", "()I", "GetNextIndexHandler:Java.Util.IListIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int NextIndex();

	[Register("previous", "()Ljava/lang/Object;", "GetPreviousHandler:Java.Util.IListIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? Previous();

	[Register("previousIndex", "()I", "GetPreviousIndexHandler:Java.Util.IListIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int PreviousIndex();

	[Register("remove", "()V", "GetRemoveHandler:Java.Util.IListIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new void Remove();

	[Register("set", "(Ljava/lang/Object;)V", "GetSet_Ljava_lang_Object_Handler:Java.Util.IListIteratorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Set(Java.Lang.Object? e);
}
