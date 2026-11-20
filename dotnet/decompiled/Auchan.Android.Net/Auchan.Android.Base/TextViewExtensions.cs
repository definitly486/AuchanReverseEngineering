using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.Content;
using Android.Graphics;
using Android.Text;
using Android.Text.Method;
using Android.Text.Style;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Text;
using Auchan.Android.Common;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Helpers;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Java.Lang;

namespace Auchan.Android.Base;

public static class TextViewExtensions
{
	public static void AddLinkedText(this TextView textView, LinkedText? linkedText)
	{
		textView.AddLinkedText(linkedText, null, underlineLinks: true);
	}

	public static void AddLinkedText(this TextView textView, LinkedText? linkedText, Color? highlightColor, bool underlineLinks, bool withDots = false, Color? mainColor = null, int? textAppearance = null)
	{
		if (linkedText != null)
		{
			Dictionary<string, Action> linksAndActions = linkedText.Highlights.Zip(linkedText.Actions, (string s, Action a) => new { s, a }).ToDictionary(item => item.s, item => item.a);
			textView.Text = linkedText.Text;
			if (mainColor.HasValue)
			{
				textView.SetTextColor(mainColor.Value);
			}
			if (textAppearance.HasValue)
			{
				textView.SetTextAppearance(textAppearance.Value);
			}
			textView.SetHighlightColor(Color.Transparent);
			textView.AddClickableSpans(linksAndActions, withDots, highlightColor, underlineLinks);
		}
	}

	public static void ChangeColorOfPartTextView(this TextView textView, string text, string coloredText, int color)
	{
		SpannableString spannableString = new SpannableString(text);
		ForegroundColorSpan what = new ForegroundColorSpan(new Color(ContextCompat.GetColor(textView.Context, color)));
		int end = text.IndexOf(coloredText, StringComparison.Ordinal) + coloredText.Length;
		spannableString.SetSpan(what, text.IndexOf(coloredText, StringComparison.Ordinal), end, SpanTypes.ExclusiveExclusive);
		textView.TextFormatted = spannableString;
	}

	public static void ChangeColorOfPartTextView(this TextView textView, string text, int start, int end, int color)
	{
		SpannableString spannableString = new SpannableString(text);
		ForegroundColorSpan what = new ForegroundColorSpan(new Color(ContextCompat.GetColor(textView.Context, color)));
		spannableString.SetSpan(what, start, end, SpanTypes.ExclusiveExclusive);
		textView.TextFormatted = spannableString;
	}

	private static void AddClickableSpans(this TextView textView, Dictionary<string, Action> linksAndActions, bool withDots, Color? highlightColor = null, bool underlineLinks = true)
	{
		Dictionary<string, Action<View>> dictionary = new Dictionary<string, Action<View>>();
		foreach (KeyValuePair<string, Action> item in linksAndActions)
		{
			dictionary.Add(item.Key, delegate
			{
				item.Value();
			});
		}
		Color linkTextColor = highlightColor ?? new Color(textView.CurrentTextColor);
		textView.AddClickableSpans(dictionary, underlineLinks, withDots);
		textView.SetLinkTextColor(linkTextColor);
	}

	private static void AddClickableSpans(this TextView textView, Dictionary<string, Action<View>> linksAndActions, bool underlineLinks, bool withDots)
	{
		string text = textView.Text;
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		SpannableString spannableString = new SpannableString(text);
		foreach (KeyValuePair<string, Action<View>> linksAndAction in linksAndActions)
		{
			if (linksAndAction.Key.Length != 0)
			{
				CustomClickableSpan customClickableSpan = new CustomClickableSpan(linksAndAction.Value)
				{
					Underline = underlineLinks
				};
				int num = text.IndexOf(linksAndAction.Key, StringComparison.Ordinal) + linksAndAction.Key.Length;
				spannableString.SetSpan(customClickableSpan, text.IndexOf(linksAndAction.Key, StringComparison.Ordinal), num, SpanTypes.ExclusiveExclusive);
				spannableString.GetSpans(0, num, customClickableSpan.Class);
			}
		}
		if (withDots)
		{
			foreach (int item in GetDotsIndex(text))
			{
				spannableString.SetSpan(new ForegroundColorSpan(new Color(ContextCompat.GetColor(textView.Context, 2131100611))), item, item + 1, SpanTypes.ExclusiveExclusive);
			}
		}
		textView.TextFormatted = spannableString;
		textView.MovementMethod = LinkMovementMethod.Instance;
	}

	public static void SetColorSpan(this TextView textView, Context context, string fullText, string hightlightedText, int highlightColorResId)
	{
		int num = fullText.IndexOf(hightlightedText, StringComparison.OrdinalIgnoreCase);
		if (num >= 0)
		{
			SpannableString spannableString = new SpannableString(fullText);
			spannableString.SetSpan(new ForegroundColorSpan(ColorHelper.FromId(context, highlightColorResId)), num, num + hightlightedText.Length, SpanTypes.ExclusiveExclusive);
			textView.SetText(spannableString, TextView.BufferType.Normal);
		}
		else
		{
			textView.Text = fullText;
		}
	}

	public static void SetBoldSpan(this TextView textView, Context context, string fullText, string hightlightedText)
	{
		int num = fullText.IndexOf(hightlightedText, StringComparison.OrdinalIgnoreCase);
		if (num >= 0)
		{
			SpannableString spannableString = new SpannableString(fullText);
			spannableString.SetSpan(new StyleSpan(TypefaceStyle.Bold), num, num + hightlightedText.Length, SpanTypes.ExclusiveExclusive);
			textView.SetText(spannableString, TextView.BufferType.Normal);
		}
		else
		{
			textView.Text = fullText;
		}
	}

	public static void ForceFocusKeyboard(this TextView textView)
	{
		textView.RequestFocus();
		if (textView.Context != null)
		{
			((InputMethodManager)textView.Context.GetSystemService("input_method")).ShowSoftInput(textView, ShowFlags.Implicit);
		}
	}

	public static void ForceUnfocusKeyboard(this TextView textView)
	{
		textView.ClearFocus();
		if (textView.Context != null)
		{
			((InputMethodManager)textView.Context.GetSystemService("input_method")).HideSoftInputFromWindow(textView.WindowToken, HideSoftInputFlags.None);
		}
	}

	public static void SetMaxLength(this TextView textView, int maxLength)
	{
		textView.SetFilters(new IInputFilter[1]
		{
			new InputFilterLengthFilter(maxLength)
		});
	}

	public static ICollection<IDisposable> SetLinkedHtml(this TextView textView, string html, Action<string> onLinkClick)
	{
		ICollection<IDisposable> disposables = new List<IDisposable>();
		ISpanned spanned = HtmlCompat.FromHtml(html, 256);
		SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(spanned);
		Java.Lang.Object[] spans = spannableStringBuilder.GetSpans(0, spanned.Length(), Class.FromType(typeof(URLSpan)));
		foreach (Java.Lang.Object obj in spans)
		{
			MakeClickable(spannableStringBuilder, obj as URLSpan);
		}
		textView.SetText(spannableStringBuilder, TextView.BufferType.Spannable);
		textView.MovementMethod = LinkMovementMethod.Instance;
		return disposables;
		void MakeClickable(SpannableStringBuilder builder, URLSpan span)
		{
			int spanStart = builder.GetSpanStart(span);
			int spanEnd = builder.GetSpanEnd(span);
			SpanTypes spanFlags = builder.GetSpanFlags(span);
			ClickableActionSpan what = new ClickableActionSpan(delegate
			{
				onLinkClick(span.URL);
			}).AddTo(disposables);
			builder.SetSpan(what, spanStart, spanEnd, spanFlags);
			builder.RemoveSpan(span);
		}
	}

	public static void AddScrollBehaviour(this TextView textView, bool lockParent = true)
	{
		if (lockParent)
		{
			textView.SetOnTouchListener(new BlockingTouchInterceptor());
		}
		textView.MovementMethod = LinkMovementMethod.Instance;
	}

	public static IDisposable OnTextChanged(this TextView textView, Action handler)
	{
		return textView.OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnTextChanged(this TextView textView, EventHandler<TextChangedEventArgs> handler)
	{
		textView.TextChanged += handler;
		return Disposable.Create(delegate
		{
			textView.TextChanged -= handler;
		});
	}

	public static IDisposable OnAfterTextChanged(this TextView @this, Action handler)
	{
		return @this.OnAfterTextChanged((EventHandler<AfterTextChangedEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnAfterTextChanged(this TextView @this, EventHandler<AfterTextChangedEventArgs> handler)
	{
		@this.AfterTextChanged += handler;
		return Disposable.Create(delegate
		{
			@this.AfterTextChanged -= handler;
		});
	}

	public static void ApplyText(this TextView @this, string text)
	{
		if (@this.Text != text)
		{
			@this.Text = text;
		}
	}

	private static IEnumerable<int> GetDotsIndex(string text)
	{
		for (int index = 0; index < text.Length; index++)
		{
			if (text[index] == '•')
			{
				yield return index;
			}
		}
	}

	public static IDisposable OnEditorAction(this TextView @this, Action handler)
	{
		return @this.OnEditorAction((EventHandler<TextView.EditorActionEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnEditorAction(this TextView @this, EventHandler<TextView.EditorActionEventArgs> handler)
	{
		@this.EditorAction += handler;
		return Disposable.Create(delegate
		{
			@this.EditorAction -= handler;
		});
	}

	public static T SetTextColor<T>(this T @this, int resource) where T : TextView
	{
		@this.SetTextColor(ContextCompat.GetColorStateList(@this.Context, resource));
		return @this;
	}
}
