using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Google.Android.Material.Button;

namespace Auchan.Android.Controls;

public class LoyaltyCardHintView : ConstraintLayout
{
	private const int TriangleShiftByAnchorInDp = 20;

	private ILifecycleOwner _lifecycleOwner;

	private View[] triangleAnchors;

	private HintItemViewModel _viewModel;

	private int _triangleIndex;

	public HintItemViewModel ViewModel
	{
		get
		{
			return _viewModel;
		}
		set
		{
			if (_viewModel != value && value != null)
			{
				_viewModel = value;
				DoBind();
			}
		}
	}

	public int TriangleIndex
	{
		get
		{
			return _triangleIndex;
		}
		set
		{
			_triangleIndex = value;
			if (Visibility != ViewStates.Gone)
			{
				ShiftTriangle(value);
			}
		}
	}

	public override ViewStates Visibility
	{
		get
		{
			return base.Visibility;
		}
		set
		{
			base.Visibility = value;
			if (value == ViewStates.Visible)
			{
				ShiftTriangle(ViewModel.Index);
			}
		}
	}

	public View TriangleView { get; private set; }

	public HighlightedTextView MessageLabel { get; private set; }

	public MaterialButton ContinueButton { get; private set; }

	public MaterialButton CloseButton { get; private set; }

	protected LoyaltyCardHintView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public LoyaltyCardHintView(Context context)
		: this(context, null)
	{
	}

	public LoyaltyCardHintView(Context context, IAttributeSet attrs)
		: this(context, attrs, -1)
	{
	}

	public LoyaltyCardHintView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Init(context, attrs, defStyleAttr);
	}

	public void SetupViewLifecycleOwner(ILifecycleOwner lifecycleOwner)
	{
		_lifecycleOwner = lifecycleOwner ?? throw new ArgumentNullException("lifecycleOwner");
	}

	public void SetupTriangleAnchors(params View[] anchors)
	{
		triangleAnchors = anchors;
	}

	private void DoBind()
	{
		if (_lifecycleOwner == null)
		{
			throw new InvalidOperationException("ILifecycleOwner is not set up");
		}
		ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[6]
		{
			(delegate
			{
				MessageLabel.AttributedText = ViewModel.Text;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Text")),
			(delegate
			{
				ContinueButton.Text = ViewModel.NextString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NextString")),
			(delegate
			{
				CloseButton.Text = ViewModel.CloseString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CloseString")),
			(delegate
			{
				ContinueButton.Visibility = (!ViewModel.IsLast).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsLast")),
			(delegate
			{
				Visibility = ViewModel.IsVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsVisible")),
			(delegate
			{
				TriangleIndex = ViewModel.Index;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Index"))
		})).AutoDisposeOnDestroy(_lifecycleOwner);
		ViewModel.BindEvents(ContinueButton.OnClick(ViewModel.Next), CloseButton.OnClick(ViewModel.Close)).AutoDisposeOnDestroy(_lifecycleOwner);
	}

	private void Init(Context context, IAttributeSet attrs, int defStyleAttr)
	{
		View view = LayoutInflater.From(context).Inflate(2131493368, this, attachToRoot: true);
		TriangleView = view.RequireViewById<View>(2131298767);
		MessageLabel = view.RequireViewById<HighlightedTextView>(2131297571);
		ContinueButton = view.RequireViewById<MaterialButton>(2131296846);
		CloseButton = view.RequireViewById<MaterialButton>(2131296795);
	}

	private void ShiftTriangle(int index)
	{
		TriangleView.Visibility = ViewStates.Gone;
		TriangleView.TranslationX = 0f;
		TriangleView.Post(delegate
		{
			View view = triangleAnchors[index];
			int specifiedViewLocationXOnScreen = GetSpecifiedViewLocationXOnScreen(view);
			int specifiedViewLocationXOnScreen2 = GetSpecifiedViewLocationXOnScreen(TriangleView);
			TriangleView.TranslationX = specifiedViewLocationXOnScreen - specifiedViewLocationXOnScreen2 + Converter.DpToPx(20f);
			TriangleView.Visibility = ViewStates.Visible;
		});
	}

	private int GetSpecifiedViewLocationXOnScreen(View view)
	{
		try
		{
			int[] array = new int[2];
			view.GetLocationOnScreen(array);
			return array[0];
		}
		catch (Exception)
		{
			return 0;
		}
	}
}
