using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Targets;

public abstract class TargetWithContext : TargetWithLayout, IIncludeContext
{
	[ThreadAgnostic]
	internal sealed class TargetWithContextLayout : Layout, IIncludeContext, IUsesStackTrace, IStringValueRenderer
	{
		public class LayoutScopeContextProperties : Layout
		{
			private readonly TargetWithContext _owner;

			public bool IsActive { get; set; }

			public LayoutScopeContextProperties(TargetWithContext owner)
			{
				_owner = owner;
			}

			protected override string GetFormattedMessage(LogEventInfo logEvent)
			{
				CaptureContext(logEvent);
				return string.Empty;
			}

			public override void Precalculate(LogEventInfo logEvent)
			{
				CaptureContext(logEvent);
			}

			private void CaptureContext(LogEventInfo logEvent)
			{
				if (IsActive && !logEvent.TryGetCachedLayoutValue(this, out object _))
				{
					IDictionary<string, object> value2 = _owner.CaptureScopeContextProperties(logEvent, null);
					logEvent.AddCachedLayoutValue(this, value2);
				}
			}
		}

		public class LayoutScopeContextNestedStates : Layout
		{
			private readonly TargetWithContext _owner;

			public bool IsActive { get; set; }

			public LayoutScopeContextNestedStates(TargetWithContext owner)
			{
				_owner = owner;
			}

			protected override string GetFormattedMessage(LogEventInfo logEvent)
			{
				CaptureContext(logEvent);
				return string.Empty;
			}

			public override void Precalculate(LogEventInfo logEvent)
			{
				CaptureContext(logEvent);
			}

			private void CaptureContext(LogEventInfo logEvent)
			{
				if (IsActive && !logEvent.TryGetCachedLayoutValue(this, out object _))
				{
					IList<object> value2 = _owner.CaptureScopeContextNested(logEvent);
					logEvent.AddCachedLayoutValue(this, value2);
				}
			}
		}

		private Layout _targetLayout = NLog.Layouts.Layout.Empty;

		private IStringValueRenderer? _targetStringLayout;

		private bool? _includeScopeProperties;

		private bool? _includeScopeNested;

		private bool? _includeMdc;

		private bool? _includeMdlc;

		private bool? _includeNdc;

		private bool? _includeNdlc;

		public Layout TargetLayout
		{
			get
			{
				return _targetLayout;
			}
			set
			{
				_targetLayout = ((this == value) ? _targetLayout : value);
				_targetStringLayout = _targetLayout as IStringValueRenderer;
			}
		}

		internal LayoutScopeContextProperties ScopeContextPropertiesLayout { get; }

		internal LayoutScopeContextNestedStates ScopeContextNestedStatesLayout { get; }

		public bool IncludeEventProperties { get; set; }

		public bool IncludeCallSite { get; set; }

		public bool IncludeCallSiteStackTrace { get; set; }

		public bool IncludeScopeProperties
		{
			get
			{
				return _includeScopeProperties ?? ScopeContextPropertiesLayout.IsActive;
			}
			set
			{
				bool value2 = (ScopeContextPropertiesLayout.IsActive = value);
				_includeScopeProperties = value2;
			}
		}

		public bool IncludeScopeNested
		{
			get
			{
				return _includeScopeNested ?? ScopeContextNestedStatesLayout.IsActive;
			}
			set
			{
				bool value2 = (ScopeContextNestedStatesLayout.IsActive = value);
				_includeScopeNested = value2;
			}
		}

		[Obsolete("Replaced by IncludeScopeProperties. Marked obsolete on NLog 5.0")]
		public bool IncludeMdc
		{
			get
			{
				return _includeMdc == true;
			}
			set
			{
				_includeMdc = value;
				ScopeContextPropertiesLayout.IsActive = _includeScopeProperties ?? (_includeMdlc == true || value);
			}
		}

		[Obsolete("Replaced by IncludeScopeProperties. Marked obsolete on NLog 5.0")]
		public bool IncludeMdlc
		{
			get
			{
				return _includeMdlc == true;
			}
			set
			{
				_includeMdlc = value;
				ScopeContextPropertiesLayout.IsActive = _includeScopeProperties ?? (_includeMdc == true || value);
			}
		}

		[Obsolete("Replaced by IncludeScopeNested. Marked obsolete on NLog 5.0")]
		public bool IncludeNdc
		{
			get
			{
				return _includeNdc == true;
			}
			set
			{
				_includeNdc = value;
				ScopeContextNestedStatesLayout.IsActive = _includeScopeNested ?? (_includeNdlc == true || value);
			}
		}

		[Obsolete("Replaced by IncludeScopeNested. Marked obsolete on NLog 5.0")]
		public bool IncludeNdlc
		{
			get
			{
				return _includeNdlc == true;
			}
			set
			{
				_includeNdlc = value;
				ScopeContextNestedStatesLayout.IsActive = _includeScopeNested ?? (_includeNdc == true || value);
			}
		}

		StackTraceUsage IUsesStackTrace.StackTraceUsage
		{
			get
			{
				if (IncludeCallSiteStackTrace)
				{
					return StackTraceUsage.WithSource;
				}
				if (IncludeCallSite)
				{
					return StackTraceUsage.WithCallSite | StackTraceUsage.WithCallSiteClassName;
				}
				return StackTraceUsage.None;
			}
		}

		public TargetWithContextLayout(TargetWithContext owner, Layout targetLayout)
		{
			TargetLayout = targetLayout;
			ScopeContextPropertiesLayout = new LayoutScopeContextProperties(owner);
			ScopeContextNestedStatesLayout = new LayoutScopeContextNestedStates(owner);
		}

		protected override void InitializeLayout()
		{
			base.InitializeLayout();
			if (IncludeScopeProperties || IncludeScopeNested)
			{
				base.ThreadAgnostic = false;
			}
			if (IncludeEventProperties)
			{
				base.ThreadAgnosticImmutable = true;
			}
		}

		public override string ToString()
		{
			return TargetLayout?.ToString() ?? base.ToString();
		}

		public override void Precalculate(LogEventInfo logEvent)
		{
			Layout targetLayout = TargetLayout;
			if (targetLayout == null || targetLayout.ThreadAgnostic)
			{
				Layout targetLayout2 = TargetLayout;
				if (targetLayout2 == null || !targetLayout2.ThreadAgnosticImmutable)
				{
					goto IL_004f;
				}
			}
			TargetLayout.Precalculate(logEvent);
			if (logEvent.TryGetCachedLayoutValue(TargetLayout, out object value))
			{
				logEvent.AddCachedLayoutValue(this, value);
			}
			goto IL_004f;
			IL_004f:
			PrecalculateContext(logEvent);
		}

		internal override void PrecalculateBuilder(LogEventInfo logEvent, StringBuilder target)
		{
			Layout targetLayout = TargetLayout;
			if (targetLayout == null || targetLayout.ThreadAgnostic)
			{
				Layout targetLayout2 = TargetLayout;
				if (targetLayout2 == null || !targetLayout2.ThreadAgnosticImmutable)
				{
					goto IL_0050;
				}
			}
			TargetLayout.PrecalculateBuilder(logEvent, target);
			if (logEvent.TryGetCachedLayoutValue(TargetLayout, out object value))
			{
				logEvent.AddCachedLayoutValue(this, value);
			}
			goto IL_0050;
			IL_0050:
			PrecalculateContext(logEvent);
		}

		private void PrecalculateContext(LogEventInfo logEvent)
		{
			if (IncludeScopeProperties)
			{
				ScopeContextPropertiesLayout.Precalculate(logEvent);
			}
			if (IncludeScopeNested)
			{
				ScopeContextNestedStatesLayout.Precalculate(logEvent);
			}
		}

		protected override string GetFormattedMessage(LogEventInfo logEvent)
		{
			return TargetLayout?.Render(logEvent) ?? string.Empty;
		}

		protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
		{
			TargetLayout?.Render(logEvent, target);
		}

		string? IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
		{
			return _targetStringLayout?.GetFormattedString(logEvent);
		}
	}

	private TargetWithContextLayout _contextLayout;

	public sealed override Layout Layout
	{
		get
		{
			return _contextLayout;
		}
		set
		{
			if (_contextLayout == null)
			{
				_contextLayout = new TargetWithContextLayout(this, value);
			}
			else
			{
				_contextLayout.TargetLayout = value;
			}
		}
	}

	public bool IncludeEventProperties
	{
		get
		{
			return _contextLayout.IncludeEventProperties;
		}
		set
		{
			_contextLayout.IncludeEventProperties = value;
		}
	}

	public bool IncludeScopeProperties
	{
		get
		{
			return _contextLayout.IncludeScopeProperties;
		}
		set
		{
			_contextLayout.IncludeScopeProperties = value;
		}
	}

	public bool IncludeScopeNested
	{
		get
		{
			return _contextLayout.IncludeScopeNested;
		}
		set
		{
			_contextLayout.IncludeScopeNested = value;
		}
	}

	[Obsolete("Replaced by IncludeScopeProperties. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IncludeMdc
	{
		get
		{
			return _contextLayout.IncludeMdc;
		}
		set
		{
			_contextLayout.IncludeMdc = value;
		}
	}

	[Obsolete("Replaced by IncludeScopeNested. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IncludeNdc
	{
		get
		{
			return _contextLayout.IncludeNdc;
		}
		set
		{
			_contextLayout.IncludeNdc = value;
		}
	}

	[Obsolete("Replaced by IncludeScopeProperties. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IncludeMdlc
	{
		get
		{
			return _contextLayout.IncludeMdlc;
		}
		set
		{
			_contextLayout.IncludeMdlc = value;
		}
	}

	[Obsolete("Replaced by IncludeScopeNested. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IncludeNdlc
	{
		get
		{
			return _contextLayout.IncludeNdlc;
		}
		set
		{
			_contextLayout.IncludeNdlc = value;
		}
	}

	public bool IncludeGdc { get; set; }

	public bool IncludeCallSite
	{
		get
		{
			return _contextLayout.IncludeCallSite;
		}
		set
		{
			_contextLayout.IncludeCallSite = value;
		}
	}

	public bool IncludeCallSiteStackTrace
	{
		get
		{
			return _contextLayout.IncludeCallSiteStackTrace;
		}
		set
		{
			_contextLayout.IncludeCallSiteStackTrace = value;
		}
	}

	[ArrayParameter(typeof(TargetPropertyWithContext), "contextproperty")]
	public virtual IList<TargetPropertyWithContext> ContextProperties { get; } = new List<TargetPropertyWithContext>();

	public ISet<string> ExcludeProperties { get; set; }

	protected TargetWithContext()
	{
		_contextLayout = _contextLayout ?? new TargetWithContextLayout(this, base.Layout);
		ExcludeProperties = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		IList<TargetPropertyWithContext> contextProperties = ContextProperties;
		if (contextProperties == null || contextProperties.Count <= 0)
		{
			return;
		}
		foreach (TargetPropertyWithContext contextProperty in ContextProperties)
		{
			if (string.IsNullOrEmpty(contextProperty.Name))
			{
				throw new NLogConfigurationException($"{this}: Contains invalid ContextProperty with unassigned Name-property");
			}
		}
	}

	protected bool ShouldIncludeProperties(LogEventInfo logEvent)
	{
		if (!IncludeGdc && !IncludeScopeProperties)
		{
			if (IncludeEventProperties)
			{
				return logEvent?.HasProperties ?? false;
			}
			return false;
		}
		return true;
	}

	protected IDictionary<string, object?>? GetContextProperties(LogEventInfo logEvent)
	{
		return GetContextProperties(logEvent, null);
	}

	protected IDictionary<string, object?>? GetContextProperties(LogEventInfo logEvent, IDictionary<string, object?>? combinedProperties)
	{
		IList<TargetPropertyWithContext> contextProperties = ContextProperties;
		if (contextProperties != null && contextProperties.Count > 0)
		{
			combinedProperties = CaptureContextProperties(logEvent, combinedProperties);
		}
		if (IncludeScopeProperties && !CombineProperties(logEvent, _contextLayout.ScopeContextPropertiesLayout, ref combinedProperties))
		{
			combinedProperties = CaptureScopeContextProperties(logEvent, combinedProperties);
		}
		if (IncludeGdc)
		{
			combinedProperties = CaptureContextGdc(logEvent, combinedProperties);
		}
		return combinedProperties;
	}

	protected IDictionary<string, object?> GetAllProperties(LogEventInfo logEvent)
	{
		return GetAllProperties(logEvent, null);
	}

	protected IDictionary<string, object?> GetAllProperties(LogEventInfo logEvent, IDictionary<string, object?>? combinedProperties)
	{
		if (IncludeEventProperties && logEvent.HasProperties)
		{
			combinedProperties = combinedProperties ?? CreateNewDictionary(logEvent.Properties.Count + (ContextProperties?.Count ?? 0));
			bool checkForDuplicates = combinedProperties.Count > 0;
			ISet<string> set = ((ExcludeProperties == null || ExcludeProperties.Count == 0) ? null : ExcludeProperties);
			using PropertiesDictionary.PropertyDictionaryEnumerator propertyDictionaryEnumerator = logEvent.CreatePropertiesInternal().GetPropertyEnumerator();
			while (propertyDictionaryEnumerator.MoveNext())
			{
				KeyValuePair<string, object> currentProperty = propertyDictionaryEnumerator.CurrentProperty;
				if (!string.IsNullOrEmpty(currentProperty.Key) && (set == null || !set.Contains(currentProperty.Key)))
				{
					AddContextProperty(logEvent, currentProperty.Key, currentProperty.Value, checkForDuplicates, combinedProperties);
				}
			}
		}
		combinedProperties = GetContextProperties(logEvent, combinedProperties);
		return combinedProperties ?? CreateNewDictionary(0);
	}

	private static IDictionary<string, object?> CreateNewDictionary(int initialCapacity)
	{
		return new Dictionary<string, object>((initialCapacity >= 3) ? initialCapacity : 0, StringComparer.Ordinal);
	}

	protected virtual string GenerateUniqueItemName(LogEventInfo logEvent, string itemName, object? itemValue, IDictionary<string, object?> combinedProperties)
	{
		return PropertiesDictionary.GenerateUniquePropertyName<string, object>(itemName, combinedProperties, (string newKey, IDictionary<string, object> props) => props.ContainsKey(newKey));
	}

	private bool CombineProperties(LogEventInfo logEvent, Layout contextLayout, ref IDictionary<string, object?>? combinedProperties)
	{
		if (!logEvent.TryGetCachedLayoutValue(contextLayout, out object value))
		{
			return false;
		}
		if (value is IDictionary<string, object> dictionary)
		{
			if (combinedProperties != null)
			{
				bool checkForDuplicates = combinedProperties.Count > 0;
				foreach (KeyValuePair<string, object> item in dictionary)
				{
					AddContextProperty(logEvent, item.Key, item.Value, checkForDuplicates, combinedProperties);
				}
			}
			else
			{
				combinedProperties = dictionary;
			}
		}
		return true;
	}

	private void AddContextProperty(LogEventInfo logEvent, string propertyName, object? propertyValue, bool checkForDuplicates, IDictionary<string, object?> combinedProperties)
	{
		if (checkForDuplicates && combinedProperties.ContainsKey(propertyName))
		{
			propertyName = GenerateUniqueItemName(logEvent, propertyName, propertyValue, combinedProperties);
		}
		combinedProperties[propertyName] = propertyValue;
	}

	protected IDictionary<string, object?>? GetScopeContextProperties(LogEventInfo logEvent)
	{
		if (logEvent.TryGetCachedLayoutValue(_contextLayout.ScopeContextPropertiesLayout, out object value))
		{
			return value as IDictionary<string, object>;
		}
		return CaptureScopeContextProperties(logEvent, null);
	}

	protected IList<object>? GetScopeContextNested(LogEventInfo logEvent)
	{
		if (logEvent.TryGetCachedLayoutValue(_contextLayout.ScopeContextNestedStatesLayout, out object value))
		{
			return value as IList<object>;
		}
		return CaptureScopeContextNested(logEvent);
	}

	private IDictionary<string, object?>? CaptureContextProperties(LogEventInfo logEvent, IDictionary<string, object?>? combinedProperties)
	{
		combinedProperties = combinedProperties ?? CreateNewDictionary(ContextProperties.Count);
		for (int i = 0; i < ContextProperties.Count; i++)
		{
			TargetPropertyWithContext targetPropertyWithContext = ContextProperties[i];
			if (targetPropertyWithContext == null || string.IsNullOrEmpty(targetPropertyWithContext.Name))
			{
				continue;
			}
			try
			{
				if (TryGetContextPropertyValue(logEvent, targetPropertyWithContext, out object propertyValue))
				{
					combinedProperties[targetPropertyWithContext.Name] = propertyValue;
				}
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrownImmediately())
				{
					throw;
				}
				InternalLogger.Warn(ex, "{0}: Failed to add context property {1}", new ReadOnlySpan<object>(new object[2] { this, targetPropertyWithContext.Name }));
			}
		}
		return combinedProperties;
	}

	private static bool TryGetContextPropertyValue(LogEventInfo logEvent, TargetPropertyWithContext contextProperty, out object? propertyValue)
	{
		propertyValue = contextProperty.RenderValue(logEvent);
		if (!contextProperty.IncludeEmptyValue && StringHelpers.IsNullOrEmptyString(propertyValue))
		{
			return false;
		}
		return true;
	}

	protected virtual IDictionary<string, object?>? CaptureContextGdc(LogEventInfo logEvent, IDictionary<string, object?>? contextProperties)
	{
		ICollection<string> names = GlobalDiagnosticsContext.GetNames();
		if (names.Count == 0)
		{
			return contextProperties;
		}
		contextProperties = contextProperties ?? CreateNewDictionary(names.Count);
		bool checkForDuplicates = contextProperties.Count > 0;
		ISet<string> set = ((ExcludeProperties == null || ExcludeProperties.Count == 0) ? null : ExcludeProperties);
		foreach (string item in names)
		{
			if (!string.IsNullOrEmpty(item) && (set == null || !set.Contains(item)))
			{
				object serializedValue = GlobalDiagnosticsContext.GetObject(item);
				if (SerializeItemValue(logEvent, item, serializedValue, out serializedValue))
				{
					AddContextProperty(logEvent, item, serializedValue, checkForDuplicates, contextProperties);
				}
			}
		}
		return contextProperties;
	}

	protected virtual IDictionary<string, object?>? CaptureScopeContextProperties(LogEventInfo logEvent, IDictionary<string, object?>? contextProperties)
	{
		using ScopeContextPropertyEnumerator<object> scopeContextPropertyEnumerator = ScopeContext.GetAllPropertiesEnumerator();
		bool checkForDuplicates = contextProperties != null && contextProperties.Count > 0;
		ISet<string> set = ((ExcludeProperties == null || ExcludeProperties.Count == 0) ? null : ExcludeProperties);
		while (scopeContextPropertyEnumerator.MoveNext())
		{
			KeyValuePair<string, object> current = scopeContextPropertyEnumerator.Current;
			string key = current.Key;
			if (!string.IsNullOrEmpty(key) && (set == null || !set.Contains(key)))
			{
				contextProperties = contextProperties ?? CreateNewDictionary(0);
				object value = current.Value;
				if (SerializeScopeContextProperty(logEvent, key, value, out object serializedValue))
				{
					AddContextProperty(logEvent, key, serializedValue, checkForDuplicates, contextProperties);
				}
			}
		}
		return contextProperties;
	}

	protected virtual bool SerializeScopeContextProperty(LogEventInfo logEvent, string name, object? value, out object? serializedValue)
	{
		if (string.IsNullOrEmpty(name))
		{
			serializedValue = null;
			return false;
		}
		return SerializeItemValue(logEvent, name, value, out serializedValue);
	}

	protected virtual IList<object> CaptureScopeContextNested(LogEventInfo logEvent)
	{
		IList<object> allNestedStateList = ScopeContext.GetAllNestedStateList();
		if (allNestedStateList.Count == 0)
		{
			return allNestedStateList;
		}
		IList<object> list = null;
		for (int i = 0; i < allNestedStateList.Count; i++)
		{
			object value = allNestedStateList[i];
			if (SerializeScopeContextNestedState(logEvent, value, out object serializedValue) && serializedValue != null)
			{
				if (list != null)
				{
					list.Add(serializedValue);
				}
				else
				{
					allNestedStateList[i] = serializedValue;
				}
			}
			else if (list == null)
			{
				list = new List<object>(allNestedStateList.Count);
				for (int j = 0; j < i; j++)
				{
					list.Add(allNestedStateList[j]);
				}
			}
		}
		return list ?? allNestedStateList;
	}

	protected virtual bool SerializeScopeContextNestedState(LogEventInfo logEvent, object value, out object? serializedValue)
	{
		return SerializeItemValue(logEvent, string.Empty, value, out serializedValue);
	}

	protected virtual bool SerializeItemValue(LogEventInfo logEvent, string name, object? value, out object? serializedValue)
	{
		if (value == null)
		{
			serializedValue = null;
			return true;
		}
		if (value is string || Convert.GetTypeCode(value) != TypeCode.Object || value.GetType().IsValueType)
		{
			serializedValue = value;
			return true;
		}
		serializedValue = Convert.ToString(value, CultureInfo.InvariantCulture);
		return true;
	}

	[Obsolete("Replaced by GetScopeContextNested. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected IList<object>? GetContextNdlc(LogEventInfo logEvent)
	{
		return GetScopeContextNested(logEvent);
	}

	[Obsolete("Replaced by GetScopeContextProperties. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected IDictionary<string, object?>? GetContextMdlc(LogEventInfo logEvent)
	{
		return GetScopeContextProperties(logEvent);
	}
}
