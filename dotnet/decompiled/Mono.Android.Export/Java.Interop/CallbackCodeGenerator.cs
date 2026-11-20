namespace Java.Interop;

internal abstract class CallbackCodeGenerator<TDelegateSpec>
{
	public abstract TDelegateSpec GetDelegateType();

	public abstract void GenerateNativeCallbackDelegate();
}
