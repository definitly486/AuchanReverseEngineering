using System;
using System.Reactive.Subjects;
using Android.Runtime;
using Android.Views;
using Google.Android.Material.BottomSheet;

namespace Auchan.Android.Ecom.PriceChecker;

public class BottomSheetCallback : BottomSheetBehavior.BottomSheetCallback
{
	private readonly Subject<float> _slideSubject = new Subject<float>();

	private readonly Subject<int> _stateSubject = new Subject<int>();

	public IObservable<float> Slide => _slideSubject;

	public IObservable<int> State => _stateSubject;

	public BottomSheetCallback(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public BottomSheetCallback()
	{
	}

	public override void OnSlide(View bottomSheet, float newState)
	{
		_slideSubject.OnNext(newState);
	}

	public override void OnStateChanged(View view, int state)
	{
		_stateSubject.OnNext(state);
	}
}
