using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("mono/android/text/TextWatcherImplementor")]
internal sealed class TextWatcherImplementor : Java.Lang.Object, ITextWatcher, INoCopySpan, IJavaObject, IDisposable, IJavaPeerable
{
	private object inst;

	public EventHandler<AfterTextChangedEventArgs>? AfterTextChanged;

	public EventHandler<TextChangedEventArgs>? BeforeTextChanged;

	public EventHandler<TextChangedEventArgs>? TextChanged;

	public TextWatcherImplementor(object inst, EventHandler<TextChangedEventArgs>? changed_handler, EventHandler<TextChangedEventArgs>? before_handler, EventHandler<AfterTextChangedEventArgs>? after_handler)
		: base(JNIEnv.StartCreateInstance("mono/android/text/TextWatcherImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.inst = inst;
		AfterTextChanged = after_handler;
		BeforeTextChanged = before_handler;
		TextChanged = changed_handler;
	}

	void ITextWatcher.AfterTextChanged(IEditable? s)
	{
		AfterTextChanged?.Invoke(inst, new AfterTextChangedEventArgs(s));
	}

	void ITextWatcher.BeforeTextChanged(ICharSequence? s, int start, int before, int after)
	{
		BeforeTextChanged?.Invoke(inst, new TextChangedEventArgs(s, start, before, after));
	}

	void ITextWatcher.OnTextChanged(ICharSequence? s, int start, int before, int count)
	{
		TextChanged?.Invoke(inst, new TextChangedEventArgs(s, start, before, count));
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
