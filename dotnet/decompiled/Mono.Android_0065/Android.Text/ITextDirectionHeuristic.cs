using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/TextDirectionHeuristic", "", "Android.Text.ITextDirectionHeuristicInvoker")]
public interface ITextDirectionHeuristic : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsRtl(char[]? array, int start, int count);

	bool IsRtl(ICharSequence? cs, int start, int count);
}
