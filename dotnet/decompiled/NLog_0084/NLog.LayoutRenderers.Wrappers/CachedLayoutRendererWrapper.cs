using System;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers;

[LayoutRenderer("cached")]
[AmbientProperty("Cached")]
[AmbientProperty("ClearCache")]
[AmbientProperty("CachedSeconds")]
[ThreadAgnostic]
public sealed class CachedLayoutRendererWrapper : WrapperLayoutRendererBase, IStringValueRenderer
{
	[Flags]
	public enum ClearCacheOption
	{
		None = 0,
		OnInit = 1,
		OnClose = 2
	}

	private readonly object _lockObject = new object();

	private string? _cachedValue;

	private string? _renderedCacheKey;

	private DateTime _cachedValueExpires;

	private TimeSpan? _cachedValueTimeout;

	public bool Cached { get; set; } = true;

	public ClearCacheOption ClearCache { get; set; } = ClearCacheOption.OnInit | ClearCacheOption.OnClose;

	public Layout? CacheKey { get; set; }

	public int CachedSeconds
	{
		get
		{
			return (int)(_cachedValueTimeout?.TotalSeconds ?? 0.0);
		}
		set
		{
			_cachedValueTimeout = TimeSpan.FromSeconds((double)value);
			if (_cachedValueTimeout > TimeSpan.Zero)
			{
				Cached = true;
			}
		}
	}

	protected override void InitializeLayoutRenderer()
	{
		base.InitializeLayoutRenderer();
		if ((ClearCache & ClearCacheOption.OnInit) == ClearCacheOption.OnInit)
		{
			_cachedValue = null;
		}
	}

	protected override void CloseLayoutRenderer()
	{
		base.CloseLayoutRenderer();
		if ((ClearCache & ClearCacheOption.OnClose) == ClearCacheOption.OnClose)
		{
			_cachedValue = null;
		}
	}

	protected override string Transform(string text)
	{
		return text;
	}

	protected override string RenderInner(LogEventInfo logEvent)
	{
		if (Cached)
		{
			string text = CacheKey?.Render(logEvent) ?? string.Empty;
			string text2 = LookupValidCachedValue(logEvent, text);
			if (text2 == null)
			{
				lock (_lockObject)
				{
					text2 = LookupValidCachedValue(logEvent, text);
					if (text2 == null)
					{
						text2 = (_cachedValue = base.RenderInner(logEvent));
						_renderedCacheKey = text;
						if (_cachedValueTimeout.HasValue)
						{
							_cachedValueExpires = logEvent.TimeStamp + _cachedValueTimeout.Value;
						}
					}
				}
			}
			return text2;
		}
		return base.RenderInner(logEvent);
	}

	private string? LookupValidCachedValue(LogEventInfo logEvent, string newCacheKey)
	{
		if (_renderedCacheKey != newCacheKey)
		{
			return null;
		}
		if (_cachedValueTimeout.HasValue && logEvent.TimeStamp > _cachedValueExpires)
		{
			return null;
		}
		return _cachedValue;
	}

	string? IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		if (!Cached)
		{
			return null;
		}
		return RenderInner(logEvent);
	}
}
