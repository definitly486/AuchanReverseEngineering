using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content.Resources;
using AsyncAwaitBestPractices;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using Java.Interop;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Base;

[Register("auchan.HighlightedTextView")]
public class HighlightedTextView : TextView, ValueAnimator.IAnimatorUpdateListener, IJavaObject, IDisposable, IJavaPeerable
{
	private class TypefaceSpan : MetricAffectingSpan
	{
		private readonly Typeface _typeface;

		public TypefaceSpan(Typeface typeface)
		{
			_typeface = typeface;
		}

		public override void UpdateDrawState(TextPaint tp)
		{
			Apply(tp);
		}

		public override void UpdateMeasureState(TextPaint textPaint)
		{
			Apply(textPaint);
		}

		private void Apply(Paint paint)
		{
			paint.SetTypeface(_typeface);
		}
	}

	public const int DefStyleAttr = 0;

	public const int DefStyleRes = 0;

	public const int DefTextAppearanceHighlightedId = 0;

	public const int NoFontResourceId = 0;

	private int textAppearanceHighlightedId;

	private AttributedText? attributedText;

	private ValueAnimator _animator;

	private CancellationTokenSource _autoHideDelayCancellationTokenSource = new CancellationTokenSource();

	private readonly int[] _attrs = new int[1] { 2130969149 };

	public AttributedText? AttributedText
	{
		get
		{
			return attributedText;
		}
		set
		{
			attributedText = value;
			SetTextWithHighlight();
		}
	}

	public HighlightedTextView(nint ptr, JniHandleOwnership owner)
		: base(ptr, owner)
	{
	}

	public HighlightedTextView(Context context)
		: this(context, null)
	{
	}

	public HighlightedTextView(Context context, IAttributeSet? attrs)
		: this(context, attrs, 0)
	{
	}

	public HighlightedTextView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: this(context, attrs, defStyleAttr, 0)
	{
	}

	public HighlightedTextView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Init(context, attrs, defStyleAttr, defStyleRes);
	}

	private void Init(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
	{
		if (attrs != null)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.HighlightedTextView);
			textAppearanceHighlightedId = typedArray.GetResourceId(0, 0);
			typedArray.Recycle();
			_animator = new ValueAnimator();
			_animator.AddUpdateListener(this);
		}
	}

	private void SetTextWithHighlight()
	{
		if (string.IsNullOrWhiteSpace(attributedText?.Text))
		{
			base.Text = string.Empty;
			return;
		}
		if (textAppearanceHighlightedId == 0)
		{
			base.Text = attributedText.Text;
			return;
		}
		SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(attributedText.Text);
		int resourceId = base.Context.ObtainStyledAttributes(textAppearanceHighlightedId, _attrs).GetResourceId(0, 0);
		Typeface typeface = null;
		if (resourceId != 0)
		{
			typeface = ResourcesCompat.GetFont(base.Context, resourceId);
		}
		string[] highlights = attributedText.Highlights;
		foreach (string text in highlights)
		{
			int[] array = AllIndexesOf(attributedText.Text, text);
			int length = text.Length;
			int[] array2 = array;
			foreach (int num in array2)
			{
				spannableStringBuilder.SetSpan(new TextAppearanceSpan(base.Context, textAppearanceHighlightedId), num, num + length, SpanTypes.ExclusiveExclusive);
				if (typeface != null)
				{
					spannableStringBuilder.SetSpan(new TypefaceSpan(typeface), num, num + length, SpanTypes.ExclusiveExclusive);
				}
			}
		}
		SetText(spannableStringBuilder, BufferType.Spannable);
	}

	private int[] AllIndexesOf(string str, string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return new int[0];
		}
		List<int> list = new List<int>();
		int startIndex = 0;
		while (true)
		{
			startIndex = str.IndexOf(value, startIndex, StringComparison.Ordinal);
			if (startIndex == -1)
			{
				break;
			}
			list.Add(startIndex);
			startIndex += value.Length;
		}
		return list.ToArray();
	}

	public void Show(int duration = 250, int startDelay = 0)
	{
		ShowAnimation(1f, duration, startDelay);
	}

	public void Dismiss(int duration = 250, int startDelay = 0)
	{
		ShowAnimation(0f, duration, startDelay);
	}

	public void ShowImmediate()
	{
		_animator.Cancel();
		Visibility = ViewStates.Visible;
		Alpha = 1f;
	}

	public void DismissImmediate()
	{
		RecreateCancellationSource();
		_animator.Cancel();
		Visibility = ViewStates.Gone;
		Alpha = 0f;
	}

	public void ShowOrHideAuto(AttributedText? text)
	{
		if (text == null)
		{
			Dismiss();
			return;
		}
		AttributedText = text;
		Show();
	}

	private void ShowAnimation(float target, int duration, int startDelay)
	{
		_animator.Cancel();
		_animator.SetDuration(duration);
		_animator.SetFloatValues(Alpha, target);
		_animator.StartDelay = startDelay;
		_animator.Start();
	}

	public void OnAnimationUpdate(ValueAnimator animation)
	{
		float num = (Alpha = (float)animation.AnimatedValue);
		Visibility = (num > 0f).ToVisibility();
	}

	public void ShowFor(TimeSpan dismissAfter, int duration = 250, int startDelay = 0)
	{
		ShowAsync(dismissAfter, duration, startDelay).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task ShowAsync(TimeSpan dismissAfter, int animationDuration = 250, int animationStartDelay = 0)
	{
		RecreateCancellationSource();
		Show(animationDuration, animationStartDelay);
		try
		{
			await Task.Delay(dismissAfter, _autoHideDelayCancellationTokenSource.Token);
			Dismiss(animationDuration, animationStartDelay);
		}
		catch (OperationCanceledException)
		{
		}
	}

	private void RecreateCancellationSource()
	{
		_autoHideDelayCancellationTokenSource.Cancel();
		_autoHideDelayCancellationTokenSource.Dispose();
		_autoHideDelayCancellationTokenSource = new CancellationTokenSource();
	}
}
