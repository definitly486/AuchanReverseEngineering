using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Appendable", "", "Java.Lang.IAppendableInvoker")]
public interface IAppendable : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("append", "(C)Ljava/lang/Appendable;", "GetAppend_CHandler:Java.Lang.IAppendableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IAppendable Append(char c);

	[Register("append", "(Ljava/lang/CharSequence;II)Ljava/lang/Appendable;", "GetAppend_Ljava_lang_CharSequence_IIHandler:Java.Lang.IAppendableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IAppendable Append(ICharSequence? csq, int start, int end);

	[Register("append", "(Ljava/lang/CharSequence;)Ljava/lang/Appendable;", "GetAppend_Ljava_lang_CharSequence_Handler:Java.Lang.IAppendableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IAppendable Append(ICharSequence? csq);
}
