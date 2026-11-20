using System;
using System.Collections;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/Spannable", "", "Android.Text.ISpannableInvoker")]
public interface ISpannable : ISpanned, ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("removeSpan", "(Ljava/lang/Object;)V", "GetRemoveSpan_Ljava_lang_Object_Handler:Android.Text.ISpannableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RemoveSpan(Java.Lang.Object? what);

	[Register("setSpan", "(Ljava/lang/Object;III)V", "GetSetSpan_Ljava_lang_Object_IIIHandler:Android.Text.ISpannableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetSpan(Java.Lang.Object? what, int start, int end, SpanTypes flags);
}
