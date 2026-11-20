using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Diagnostics;

public readonly struct ActivityCreationOptions<T>
{
	private readonly ActivityTagsCollection _samplerTags;

	private readonly ActivityContext _context;

	private readonly string _traceState;

	public string? TraceState => _traceState;

	internal ActivityIdFormat IdFormat { get; }

	internal ActivityCreationOptions(ActivitySource source, string name, T parent, ActivityKind kind, IEnumerable<KeyValuePair<string, object>> tags, IEnumerable<ActivityLink> links, ActivityIdFormat idFormat)
	{
		_003CSource_003Ek__BackingField = source;
		_003CName_003Ek__BackingField = name;
		_003CKind_003Ek__BackingField = kind;
		_003CParent_003Ek__BackingField = parent;
		_003CTags_003Ek__BackingField = tags;
		_003CLinks_003Ek__BackingField = links;
		IdFormat = idFormat;
		if (IdFormat == ActivityIdFormat.Unknown && Activity.ForceDefaultIdFormat)
		{
			IdFormat = Activity.DefaultIdFormat;
		}
		_samplerTags = null;
		_traceState = null;
		if (parent is ActivityContext activityContext && activityContext != default(ActivityContext))
		{
			_context = activityContext;
			if (IdFormat == ActivityIdFormat.Unknown)
			{
				IdFormat = ActivityIdFormat.W3C;
			}
			_traceState = activityContext.TraceState;
		}
		else if (parent is string traceParent)
		{
			if (IdFormat != ActivityIdFormat.Hierarchical)
			{
				if (ActivityContext.TryParse(traceParent, null, out _context))
				{
					IdFormat = ActivityIdFormat.W3C;
				}
				if (IdFormat == ActivityIdFormat.Unknown)
				{
					IdFormat = ActivityIdFormat.Hierarchical;
				}
			}
			else
			{
				_context = default(ActivityContext);
			}
		}
		else
		{
			_context = default(ActivityContext);
			if (IdFormat == ActivityIdFormat.Unknown)
			{
				IdFormat = ((Activity.Current != null) ? Activity.Current.IdFormat : Activity.DefaultIdFormat);
			}
		}
	}

	internal void SetTraceState(string traceState)
	{
		Unsafe.AsRef(in _traceState) = traceState;
	}

	internal ActivityTagsCollection GetSamplingTags()
	{
		return _samplerTags;
	}

	internal ActivityContext GetContext()
	{
		return _context;
	}
}
