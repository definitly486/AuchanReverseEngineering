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
	void RemoveSpan(Java.Lang.Object? what);

	void SetSpan(Java.Lang.Object? what, int start, int end, SpanTypes flags);
}
