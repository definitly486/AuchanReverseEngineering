using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Helpers;
using Auchan.Common.AdminTool;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Networking;
using Bumptech.Glide;
using Bumptech.Glide.Load;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Load.Model;
using Bumptech.Glide.Load.Resource.Bitmap;
using Bumptech.Glide.Load.Resource.Drawable;
using Bumptech.Glide.Request;
using Bumptech.Glide.Request.Transition;
using Com.Google.Zxing;
using DryIoc;

namespace Auchan.Android.Extensions;

public static class ImageViewExtensions
{
	private static readonly IHeaderInjector _injector = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IHeaderInjector>();

	private static readonly IHeaderInjector2 _injector2 = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IHeaderInjector2>();

	private static readonly IAdminContext _adminContext = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IAdminContext>();

	public static void FromUrl(this ImageView imageView, string? url, bool originalSize = false)
	{
		imageView.SetImageDrawable(null);
		if (!string.IsNullOrWhiteSpace(url))
		{
			RequestBuilder requestBuilder = Glide.With(Application.Context).CreateGlideUrl(url, imageView).SetPriority(Priority.Immediate);
			if (originalSize)
			{
				requestBuilder.Override(int.MinValue, int.MinValue);
			}
			requestBuilder.Into(imageView);
		}
	}

	public static void FromUrlWithSize(this ImageView imageView, string url, int width, int height)
	{
		if (!string.IsNullOrWhiteSpace(url))
		{
			Glide.With(Application.Context).CreateGlideUrl(url, imageView).SetPriority(Priority.Immediate)
				.Override(width, height)
				.Into(imageView);
		}
	}

	public static void FromUrlAnimated(this ImageView imageView, string url, ITransformation? transformation, int? placeholder = null)
	{
		imageView.SetImageDrawable(null);
		if (!string.IsNullOrWhiteSpace(url))
		{
			RequestBuilder requestBuilder = Glide.With(Application.Context).CreateGlideUrl(url, imageView).Transition(DrawableTransitionOptions.WithCrossFade())
				.SetPriority(Priority.Immediate);
			if (placeholder.HasValue)
			{
				requestBuilder = requestBuilder.Placeholder(placeholder.Value);
			}
			if (transformation != null)
			{
				requestBuilder = requestBuilder.Transform(transformation);
			}
			requestBuilder.Into(imageView);
		}
	}

	public static void FromUrlWithListener(this ImageView imageView, string url, IRequestListener requestListener)
	{
		imageView.SetImageDrawable(null);
		if (!string.IsNullOrWhiteSpace(url))
		{
			Glide.With(Application.Context).CreateGlideUrl(url, imageView, withAuthorizationHeader: false, IsGifUrl(url)).AddListener(requestListener)
				.SetPriority(Priority.Immediate)
				.Into(imageView);
		}
	}

	public static void FromUrlDownsample(this ImageView imageView, string url)
	{
		imageView.SetImageDrawable(null);
		if (!string.IsNullOrWhiteSpace(url))
		{
			Glide.With(Application.Context).CreateGlideUrl(url, imageView).SetPriority(Priority.Immediate)
				.Downsample(DownsampleStrategy.FitCenter)
				.Into(imageView);
		}
	}

	public static void FromUrlAnimated(this ImageView imageView, string? url)
	{
		imageView.SetImageDrawable(null);
		if (!string.IsNullOrWhiteSpace(url))
		{
			Glide.With(Application.Context).CreateGlideUrl(url, imageView).Transition(DrawableTransitionOptions.WithCrossFade(new DrawableCrossFadeFactory.Builder().SetCrossFadeEnabled(isCrossFadeEnabled: true).Build()))
				.SetPriority(Priority.Immediate)
				.Into(imageView);
		}
	}

	public static void FromUrlAnimated(this ImageView imageView, string? url, params ITransformation[] transformations)
	{
		imageView.SetImageDrawable(null);
		if (!string.IsNullOrWhiteSpace(url))
		{
			Glide.With(Application.Context).CreateGlideUrl(url, imageView).Transform(transformations)
				.Transition(DrawableTransitionOptions.WithCrossFade(new DrawableCrossFadeFactory.Builder().SetCrossFadeEnabled(isCrossFadeEnabled: true).Build()))
				.SetPriority(Priority.Immediate)
				.Into(imageView);
		}
	}

	public static void SetQrCode(this ImageView view, string content)
	{
		if (!string.IsNullOrWhiteSpace(content))
		{
			view.Post(delegate
			{
			});
		}
	}

	public static void SetPDF417Code(this ImageView view, string content, int? width = null, int? height = null)
	{
		if (!string.IsNullOrWhiteSpace(content))
		{
			view.Post(delegate
			{
				Bitmap imageBitmap = BarcodeGenerator.CreatePDF417Code(content, width ?? view.Width, height ?? view.Height);
				view.SetImageBitmap(imageBitmap);
			});
		}
	}

	public static void SetBitmap(this ImageView view, Bitmap bitmap)
	{
		view.Post(delegate
		{
			view.SetImageBitmap(bitmap);
		});
	}

	public static void SetEAN13Code(this ImageView view, string content, int? width = null, int? height = null)
	{
		if (string.IsNullOrWhiteSpace(content))
		{
			return;
		}
		view.Post(delegate
		{
			int valueOrDefault = width.GetValueOrDefault();
			if (!width.HasValue)
			{
				valueOrDefault = view.Width;
				width = valueOrDefault;
			}
			valueOrDefault = height.GetValueOrDefault();
			if (!height.HasValue)
			{
				valueOrDefault = view.Height;
				height = valueOrDefault;
			}
			Bitmap bitmap = null;
			try
			{
				bitmap = BarcodeGenerator.CreateEAN13Code(content, width.Value, height.Value);
			}
			catch (WriterException)
			{
			}
			if (bitmap != null)
			{
				view.SetImageBitmap(bitmap);
			}
			else
			{
				view.SetImageDrawable(null);
			}
		});
	}

	public static void PreloadImage(this RequestManager builder, string url)
	{
		if (!string.IsNullOrWhiteSpace(url))
		{
			Glide.With(Application.Context).CreateGlideUrl(url).SetPriority(Priority.Immediate)
				.Preload();
		}
	}

	private static RequestBuilder CreateGlideUrl(this RequestManager builder, string url, ImageView? imageView = null, bool withAuthorizationHeader = false, bool forceAsGif = false)
	{
		LazyHeaders.Builder builder2 = new LazyHeaders.Builder();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (withAuthorizationHeader)
		{
			string text = (_adminContext.AppConfigIsNotNull ? _adminContext.AppConfig.BasicAuthToken : string.Empty);
			if (!string.IsNullOrWhiteSpace(text))
			{
				builder2.AddHeader("Authorization", "Basic " + text);
			}
		}
		if (_injector.Inject(url, dictionary))
		{
			foreach (var (key, value) in dictionary)
			{
				builder2.AddHeader(key, value);
			}
		}
		_injector2.Inject(url, dictionary);
		GlideUrl model = new GlideUrl(url, builder2.Build());
		RequestBuilder requestBuilder = (forceAsGif ? builder.AsGif().Load(model) : builder.Load(model)).Listener(new GlideLoadingListener(delegate
		{
		}, delegate(GlideException error)
		{
			if (error.Message != null && error.Message.Contains("401") && !withAuthorizationHeader)
			{
				Handler handler = new Handler();
				handler.Post(delegate
				{
					builder.CreateGlideUrl(url, imageView, withAuthorizationHeader: true, forceAsGif).SetPriority(Priority.Immediate);
					handler.Dispose();
				});
			}
		}));
		if (withAuthorizationHeader && imageView != null)
		{
			requestBuilder.Into(imageView);
		}
		return requestBuilder;
	}

	private static bool IsGifUrl(string url)
	{
		int num = url.IndexOf('?');
		return ((num >= 0) ? url.Substring(0, num) : url).EndsWith(".gif", StringComparison.OrdinalIgnoreCase);
	}

	public static void FromUrlWithPlaceholder(this ImageView imageView, string url, int placeholder)
	{
		if (string.IsNullOrWhiteSpace(url))
		{
			imageView.SetImageResource(placeholder);
		}
		else
		{
			Glide.With(Application.Context).CreateGlideUrl(url, imageView).Placeholder(placeholder)
				.SetPriority(Priority.Immediate)
				.Into(imageView);
		}
	}
}
