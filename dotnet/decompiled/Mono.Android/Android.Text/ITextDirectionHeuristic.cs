using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/TextDirectionHeuristic", "", "Android.Text.ITextDirectionHeuristicInvoker")]
public interface ITextDirectionHeuristic : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("isRtl", "([CII)Z", "GetIsRtl_arrayCIIHandler:Android.Text.ITextDirectionHeuristicInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool IsRtl(char[]? array, int start, int count);

	[Register("isRtl", "(Ljava/lang/CharSequence;II)Z", "GetIsRtl_Ljava_lang_CharSequence_IIHandler:Android.Text.ITextDirectionHeuristicInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool IsRtl(ICharSequence? cs, int start, int count);
}
