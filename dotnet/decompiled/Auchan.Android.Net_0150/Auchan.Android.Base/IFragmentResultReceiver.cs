namespace Auchan.Android.Base;

internal interface IFragmentResultReceiver<T>
{
	void OnResult(int requestCode, T value);
}
