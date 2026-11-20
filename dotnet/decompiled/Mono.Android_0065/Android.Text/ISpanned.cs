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
	int GetSpanEnd(Java.Lang.Object? tag);

	SpanTypes GetSpanFlags(Java.Lang.Object? tag);

	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object[]? GetSpans(int start, int end, Class? type);

	int GetSpanStart(Java.Lang.Object? tag);

	int NextSpanTransition(int start, int limit, Class? type);
}
