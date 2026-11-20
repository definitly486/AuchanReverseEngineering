using System;
using Android.Runtime;
using Android.Text;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class SearchSpaceInputFilter : Java.Lang.Object, IInputFilter, IJavaObject, IDisposable, IJavaPeerable
{
	public ICharSequence FilterFormatted(ICharSequence source, int start, int end, ISpanned dest, int dstart, int dend)
	{
		string text = dest.ToString().Insert(dstart, source.ToString());
		if (text.StartsWith(" ") || text.Contains("  "))
		{
			return new Java.Lang.String(string.Empty);
		}
		return null;
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
