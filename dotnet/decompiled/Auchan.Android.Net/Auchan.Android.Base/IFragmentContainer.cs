namespace Auchan.Android.Base;

internal interface IFragmentContainer
{
	bool IsHidden { get; }

	void PostRepeatedOpenEvent();
}
