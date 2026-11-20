using System;
using System.Collections;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/Spanned", "", "Android.Text.ISpannedInvoker")]
public interface ISpanned : ICharSequence, IEnumerable<char>, IEnumerable, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("getSpanEnd", "(Ljava/lang/Object;)I", "GetGetSpanEnd_Ljava_lang_Object_Handler:Android.Text.ISpannedInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetSpanEnd(Java.Lang.Object? tag);

	[Register("getSpanFlags", "(Ljava/lang/Object;)I", "GetGetSpanFlags_Ljava_lang_Object_Handler:Android.Text.ISpannedInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	SpanTypes GetSpanFlags(Java.Lang.Object? tag);

	[Register("getSpans", "(IILjava/lang/Class;)[Ljava/lang/Object;", "GetGetSpans_IILjava_lang_Class_Handler:Android.Text.ISpannedInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object[]? GetSpans(int start, int end, Class? type);

	[Register("getSpanStart", "(Ljava/lang/Object;)I", "GetGetSpanStart_Ljava_lang_Object_Handler:Android.Text.ISpannedInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetSpanStart(Java.Lang.Object? tag);

	[Register("nextSpanTransition", "(IILjava/lang/Class;)I", "GetNextSpanTransition_IILjava_lang_Class_Handler:Android.Text.ISpannedInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int NextSpanTransition(int start, int limit, Class? type);
}
