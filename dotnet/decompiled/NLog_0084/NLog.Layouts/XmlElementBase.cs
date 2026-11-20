using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.LayoutRenderers.Wrappers;
using NLog.MessageTemplates;
using NLog.Targets;

namespace NLog.Layouts;

public abstract class XmlElementBase : Layout
{
	private Layout[]? _precalculateLayouts;

	private const string DefaultPropertyName = "property";

	private const string DefaultPropertyKeyAttribute = "key";

	private const string DefaultCollectionItemName = "item";

	private string _elementNameInternal = string.Empty;

	internal readonly XmlEncodeLayoutRendererWrapper LayoutWrapper = new XmlEncodeLayoutRendererWrapper();

	private bool? _includeScopeProperties;

	private bool? _includeMdc;

	private bool? _includeMdlc;

	private string _propertiesElementName = "property";

	private bool _propertiesElementNameHasFormat;

	private ObjectReflectionCache? _objectReflectionCache;

	private static readonly IEqualityComparer<object> _referenceEqualsComparer = SingleItemOptimizedHashSet<object>.ReferenceEqualityComparer.Default;

	private const int MaxXmlLength = 524288;

	internal string ElementNameInternal
	{
		get
		{
			return _elementNameInternal;
		}
		set
		{
			_elementNameInternal = XmlHelper.XmlConvertToElementName(value?.Trim() ?? string.Empty);
		}
	}

	public bool IndentXml { get; set; }

	[ArrayParameter(typeof(XmlElement), "element")]
	public IList<XmlElement> Elements { get; } = new List<XmlElement>();

	[ArrayParameter(typeof(XmlAttribute), "attribute")]
	public IList<XmlAttribute> Attributes { get; } = new List<XmlAttribute>();

	[ArrayParameter(typeof(TargetPropertyWithContext), "contextproperty")]
	public List<TargetPropertyWithContext>? ContextProperties { get; set; }

	public bool IncludeEmptyValue { get; set; }

	public bool IncludeEventProperties { get; set; }

	public bool IncludeScopeProperties
	{
		get
		{
			bool? includeScopeProperties = _includeScopeProperties;
			if (!includeScopeProperties.HasValue)
			{
				if (_includeMdlc != true)
				{
					return _includeMdc == true;
				}
				return true;
			}
			return includeScopeProperties == true;
		}
		set
		{
			_includeScopeProperties = value;
		}
	}

	[Obsolete("Replaced by IncludeScopeProperties. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IncludeMdc
	{
		get
		{
			return _includeMdc == true;
		}
		set
		{
			_includeMdc = value;
		}
	}

	[Obsolete("Replaced by IncludeScopeProperties. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IncludeMdlc
	{
		get
		{
			return _includeMdlc == true;
		}
		set
		{
			_includeMdlc = value;
		}
	}

	[Obsolete("Replaced by IncludeEventProperties. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IncludeAllProperties
	{
		get
		{
			return IncludeEventProperties;
		}
		set
		{
			IncludeEventProperties = value;
		}
	}

	public ISet<string> ExcludeProperties { get; set; }

	public string PropertiesElementName
	{
		get
		{
			return _propertiesElementName;
		}
		set
		{
			_propertiesElementName = value;
			_propertiesElementNameHasFormat = value != null && value.IndexOf('{') >= 0;
			if (!_propertiesElementNameHasFormat)
			{
				_propertiesElementName = XmlHelper.XmlConvertToElementName(value?.Trim() ?? string.Empty);
			}
		}
	}

	public string PropertiesElementKeyAttribute { get; set; } = "key";

	public string PropertiesElementValueAttribute { get; set; } = string.Empty;

	public string PropertiesCollectionItemName { get; set; } = "item";

	public int MaxRecursionLimit { get; set; } = 1;

	private ObjectReflectionCache ObjectReflectionCache => _objectReflectionCache ?? (_objectReflectionCache = new ObjectReflectionCache(base.LoggingConfiguration.GetServiceProvider()));

	protected XmlElementBase(string elementName, Layout elementValue)
	{
		ElementNameInternal = elementName;
		LayoutWrapper.Inner = elementValue;
		ExcludeProperties = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
	}

	protected override void InitializeLayout()
	{
		base.InitializeLayout();
		if (string.IsNullOrEmpty(ElementNameInternal))
		{
			throw new NLogConfigurationException("XmlLayout Name-property must be assigned. Name is required for valid XML element.");
		}
		if (IncludeScopeProperties)
		{
			base.ThreadAgnostic = false;
		}
		if (IncludeEventProperties)
		{
			base.ThreadAgnosticImmutable = true;
		}
		if (Attributes.Count > 0)
		{
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			foreach (XmlAttribute attribute in Attributes)
			{
				if (string.IsNullOrEmpty(attribute.Name))
				{
					throw new NLogConfigurationException("XmlElement(Name=" + ElementNameInternal + "): Contains invalid XmlAttribute with unassigned Name-property");
				}
				if (hashSet.Contains(attribute.Name))
				{
					InternalLogger.Warn("XmlElement(ElementName={0}): Contains duplicate XmlAttribute(Name={1}) (Invalid xml)", ElementNameInternal, attribute.Name);
				}
				else
				{
					hashSet.Add(attribute.Name);
				}
			}
		}
		if (ContextProperties != null && ContextProperties.Count > 0)
		{
			foreach (TargetPropertyWithContext contextProperty in ContextProperties)
			{
				if (string.IsNullOrEmpty(contextProperty.Name))
				{
					throw new NLogConfigurationException("XmlElement(Name=" + ElementNameInternal + "): Contains invalid ContextProperty with unassigned Name-property");
				}
			}
		}
		Layout[] second = ((LayoutWrapper.Inner == null) ? ArrayHelper.Empty<Layout>() : new Layout[1] { LayoutWrapper.Inner });
		_precalculateLayouts = ((IncludeEventProperties || IncludeScopeProperties) ? null : ResolveLayoutPrecalculation(Attributes.Select((XmlAttribute atr) => atr.Layout).Concat(from elm in Elements
			where elm.Layout != null
			select elm.Layout).Concat(ContextProperties?.Select((TargetPropertyWithContext ctx) => ctx.Layout) ?? Enumerable.Empty<Layout>())
			.Concat(second)));
	}

	protected override void CloseLayout()
	{
		_precalculateLayouts = null;
		base.CloseLayout();
	}

	internal override void PrecalculateBuilder(LogEventInfo logEvent, StringBuilder target)
	{
		PrecalculateBuilderInternal(logEvent, target, _precalculateLayouts);
	}

	protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
	{
		int length = target.Length;
		RenderXmlFormattedMessage(logEvent, target);
		if (target.Length == length && IncludeEmptyValue && !string.IsNullOrEmpty(ElementNameInternal))
		{
			RenderSelfClosingElement(target, ElementNameInternal);
		}
	}

	protected override string GetFormattedMessage(LogEventInfo logEvent)
	{
		return RenderAllocateBuilder(logEvent);
	}

	private void RenderXmlFormattedMessage(LogEventInfo logEvent, StringBuilder sb)
	{
		int length = sb.Length;
		if (!string.IsNullOrEmpty(ElementNameInternal))
		{
			for (int i = 0; i < Attributes.Count; i++)
			{
				XmlAttribute xmlAttribute = Attributes[i];
				int length2 = sb.Length;
				if (!RenderAppendXmlAttributeValue(xmlAttribute, logEvent, sb, sb.Length == length))
				{
					sb.Length = length2;
				}
			}
			if (sb.Length != length)
			{
				if (!HasNestedXmlElements(logEvent))
				{
					sb.Append("/>");
					return;
				}
				sb.Append('>');
			}
			if (LayoutWrapper.Inner != null)
			{
				int length3 = sb.Length;
				if (sb.Length == length)
				{
					RenderStartElement(sb, ElementNameInternal);
				}
				int length4 = sb.Length;
				LayoutWrapper.RenderAppendBuilder(logEvent, sb);
				if (length4 == sb.Length && !IncludeEmptyValue)
				{
					sb.Length = length3;
				}
			}
			if (IndentXml && sb.Length != length)
			{
				sb.AppendLine();
			}
		}
		for (int j = 0; j < Elements.Count; j++)
		{
			XmlElement xmlElement = Elements[j];
			int length5 = sb.Length;
			if (!RenderAppendXmlElementValue(xmlElement, logEvent, sb, sb.Length == length))
			{
				sb.Length = length5;
			}
		}
		AppendLogEventXmlProperties(logEvent, sb, length);
		if (sb.Length > length && !string.IsNullOrEmpty(ElementNameInternal))
		{
			EndXmlDocument(sb, ElementNameInternal);
		}
	}

	private bool HasNestedXmlElements(LogEventInfo logEvent)
	{
		Layout inner = LayoutWrapper.Inner;
		if (inner != null && inner != Layout.Empty)
		{
			return true;
		}
		if (Elements.Count > 0)
		{
			return true;
		}
		List<TargetPropertyWithContext>? contextProperties = ContextProperties;
		if (contextProperties != null && contextProperties.Count > 0)
		{
			return true;
		}
		if (IncludeScopeProperties)
		{
			return true;
		}
		if (IncludeEventProperties && logEvent.HasProperties)
		{
			return true;
		}
		return false;
	}

	private void AppendLogEventXmlProperties(LogEventInfo logEventInfo, StringBuilder sb, int orgLength)
	{
		if (ContextProperties != null)
		{
			foreach (TargetPropertyWithContext contextProperty in ContextProperties)
			{
				object obj = contextProperty.RenderValue(logEventInfo);
				if (contextProperty.IncludeEmptyValue || !StringHelpers.IsNullOrEmptyString(obj))
				{
					AppendXmlPropertyValue(contextProperty.Name, obj, sb, orgLength);
				}
			}
		}
		if (IncludeScopeProperties)
		{
			bool flag = ExcludeProperties.Count > 0;
			using ScopeContextPropertyEnumerator<object> scopeContextPropertyEnumerator = ScopeContext.GetAllPropertiesEnumerator();
			while (scopeContextPropertyEnumerator.MoveNext())
			{
				KeyValuePair<string, object> current2 = scopeContextPropertyEnumerator.Current;
				if (!string.IsNullOrEmpty(current2.Key) && (!flag || !ExcludeProperties.Contains(current2.Key)))
				{
					AppendXmlPropertyValue(current2.Key, current2.Value, sb, orgLength);
				}
			}
		}
		if (IncludeEventProperties)
		{
			AppendLogEventProperties(logEventInfo, sb, orgLength);
		}
	}

	private void AppendLogEventProperties(LogEventInfo logEventInfo, StringBuilder sb, int orgLength)
	{
		if (!logEventInfo.HasProperties)
		{
			return;
		}
		bool flag = ExcludeProperties.Count > 0;
		using PropertiesDictionary.PropertyDictionaryEnumerator propertyDictionaryEnumerator = logEventInfo.CreatePropertiesInternal().GetPropertyEnumerator();
		while (propertyDictionaryEnumerator.MoveNext())
		{
			MessageTemplateParameter currentParameter = propertyDictionaryEnumerator.CurrentParameter;
			if (!string.IsNullOrEmpty(currentParameter.Name) && (!flag || !ExcludeProperties.Contains(currentParameter.Name)))
			{
				object obj = currentParameter.Value;
				if (!string.IsNullOrEmpty(currentParameter.Format) && obj is IFormattable formattable)
				{
					obj = formattable.ToString(currentParameter.Format, CultureInfo.InvariantCulture);
				}
				else if (currentParameter.CaptureType == CaptureType.Stringify)
				{
					obj = Convert.ToString(currentParameter.Value ?? string.Empty, CultureInfo.InvariantCulture);
				}
				AppendXmlPropertyObjectValue(currentParameter.Name, obj, sb, orgLength, default(SingleItemOptimizedHashSet<object>), 0);
			}
		}
	}

	private bool AppendXmlPropertyObjectValue(string propName, object? propertyValue, StringBuilder sb, int orgLength, SingleItemOptimizedHashSet<object> objectsInPath, int depth, bool ignorePropertiesElementName = false)
	{
		if (propertyValue is IConvertible convertible)
		{
			TypeCode typeCode = convertible.GetTypeCode();
			if (typeCode != TypeCode.Object)
			{
				string xmlValueString = XmlHelper.XmlConvertToString(convertible, typeCode, safeConversion: true);
				AppendXmlPropertyStringValue(propName, xmlValueString, sb, orgLength, ignoreValue: false, ignorePropertiesElementName);
				return true;
			}
		}
		else if (propertyValue == null)
		{
			string xmlValueString2 = "null";
			AppendXmlPropertyStringValue(propName, xmlValueString2, sb, orgLength, ignoreValue: false, ignorePropertiesElementName);
			return true;
		}
		if (sb.Length > 524288)
		{
			return false;
		}
		int num = ((objectsInPath.Count == 0) ? depth : (depth + 1));
		if (num > MaxRecursionLimit)
		{
			return false;
		}
		if (objectsInPath.Contains(propertyValue))
		{
			return false;
		}
		if (MaxRecursionLimit == 0 || (num == MaxRecursionLimit && !(propertyValue is IEnumerable)))
		{
			string xmlValueString3 = XmlHelper.XmlConvertToStringSafe(propertyValue);
			AppendXmlPropertyStringValue(propName, xmlValueString3, sb, orgLength, ignoreValue: false, ignorePropertiesElementName);
			return true;
		}
		if (propertyValue is IDictionary dictionary)
		{
			using (StartCollectionScope(ref objectsInPath, dictionary))
			{
				AppendXmlDictionaryObject(propName, dictionary, sb, orgLength, objectsInPath, num, ignorePropertiesElementName);
			}
		}
		else if (propertyValue is IEnumerable enumerable)
		{
			if (ObjectReflectionCache.TryLookupExpandoObject(propertyValue, out var objectPropertyList))
			{
				using (new SingleItemOptimizedHashSet<object>.SingleItemScopedInsert(propertyValue, ref objectsInPath, forceHashSet: false, _referenceEqualsComparer))
				{
					AppendXmlObjectPropertyValues(propName, ref objectPropertyList, sb, orgLength, ref objectsInPath, num, ignorePropertiesElementName);
				}
			}
			else
			{
				using (StartCollectionScope(ref objectsInPath, enumerable))
				{
					AppendXmlCollectionObject(propName, enumerable, sb, orgLength, objectsInPath, num, ignorePropertiesElementName);
				}
			}
		}
		else
		{
			using (new SingleItemOptimizedHashSet<object>.SingleItemScopedInsert(propertyValue, ref objectsInPath, forceHashSet: false, _referenceEqualsComparer))
			{
				ObjectReflectionCache.ObjectPropertyList propertyValues = ObjectReflectionCache.LookupObjectProperties(propertyValue);
				AppendXmlObjectPropertyValues(propName, ref propertyValues, sb, orgLength, ref objectsInPath, num, ignorePropertiesElementName);
			}
		}
		return true;
	}

	private static SingleItemOptimizedHashSet<object>.SingleItemScopedInsert StartCollectionScope(ref SingleItemOptimizedHashSet<object> objectsInPath, object value)
	{
		return new SingleItemOptimizedHashSet<object>.SingleItemScopedInsert(value, ref objectsInPath, forceHashSet: true, _referenceEqualsComparer);
	}

	private void AppendXmlCollectionObject(string propName, IEnumerable collection, StringBuilder sb, int orgLength, SingleItemOptimizedHashSet<object> objectsInPath, int depth, bool ignorePropertiesElementName)
	{
		string text = AppendXmlPropertyValue(propName, string.Empty, sb, orgLength, ignoreValue: true);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		foreach (object item in collection)
		{
			int length = sb.Length;
			if (length > 524288)
			{
				break;
			}
			if (!AppendXmlPropertyObjectValue(PropertiesCollectionItemName, item, sb, orgLength, objectsInPath, depth, ignorePropertiesElementName: true))
			{
				sb.Length = length;
			}
		}
		AppendClosingPropertyTag(text, sb, ignorePropertiesElementName);
	}

	private void AppendXmlDictionaryObject(string propName, IDictionary dictionary, StringBuilder sb, int orgLength, SingleItemOptimizedHashSet<object> objectsInPath, int depth, bool ignorePropertiesElementName)
	{
		string text = AppendXmlPropertyValue(propName, string.Empty, sb, orgLength, ignoreValue: true, ignorePropertiesElementName);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		foreach (DictionaryEntry item in new DictionaryEntryEnumerable(dictionary))
		{
			int length = sb.Length;
			if (length > 524288)
			{
				break;
			}
			string text2 = item.Key?.ToString() ?? string.Empty;
			if (!string.IsNullOrEmpty(text2) && !AppendXmlPropertyObjectValue(text2, item.Value, sb, orgLength, objectsInPath, depth))
			{
				sb.Length = length;
			}
		}
		AppendClosingPropertyTag(text, sb, ignorePropertiesElementName);
	}

	private void AppendXmlObjectPropertyValues(string propName, ref ObjectReflectionCache.ObjectPropertyList propertyValues, StringBuilder sb, int orgLength, ref SingleItemOptimizedHashSet<object> objectsInPath, int depth, bool ignorePropertiesElementName = false)
	{
		if (propertyValues.IsSimpleValue)
		{
			AppendXmlPropertyValue(propName, propertyValues.ObjectValue, sb, orgLength, ignoreValue: false, ignorePropertiesElementName);
			return;
		}
		string text = AppendXmlPropertyValue(propName, string.Empty, sb, orgLength, ignoreValue: true, ignorePropertiesElementName);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		foreach (ObjectReflectionCache.ObjectPropertyList.PropertyValue propertyValue in propertyValues)
		{
			int length = sb.Length;
			if (length > 524288)
			{
				break;
			}
			if (!string.IsNullOrEmpty(propertyValue.Name) && (IncludeEmptyValue || !StringHelpers.IsNullOrEmptyString(propertyValue.Value)))
			{
				TypeCode typeCode = propertyValue.TypeCode;
				if (typeCode != TypeCode.Object)
				{
					string xmlValueString = XmlHelper.XmlConvertToString((IConvertible)propertyValue.Value, typeCode, safeConversion: true);
					AppendXmlPropertyStringValue(propertyValue.Name, xmlValueString, sb, orgLength, ignoreValue: false, ignorePropertiesElementName);
				}
				else if (!AppendXmlPropertyObjectValue(propertyValue.Name, propertyValue.Value, sb, orgLength, objectsInPath, depth))
				{
					sb.Length = length;
				}
			}
		}
		AppendClosingPropertyTag(text, sb, ignorePropertiesElementName);
	}

	private string AppendXmlPropertyValue(string propName, object? propertyValue, StringBuilder sb, int orgLength, bool ignoreValue = false, bool ignorePropertiesElementName = false)
	{
		string xmlValueString = (ignoreValue ? string.Empty : XmlHelper.XmlConvertToStringSafe(propertyValue));
		return AppendXmlPropertyStringValue(propName, xmlValueString, sb, orgLength, ignoreValue, ignorePropertiesElementName);
	}

	private string AppendXmlPropertyStringValue(string propName, string xmlValueString, StringBuilder sb, int orgLength, bool ignoreValue = false, bool ignorePropertiesElementName = false)
	{
		if (string.IsNullOrEmpty(PropertiesElementName))
		{
			return string.Empty;
		}
		propName = propName?.Trim() ?? string.Empty;
		if (string.IsNullOrEmpty(propName))
		{
			return string.Empty;
		}
		if (sb.Length == orgLength && !string.IsNullOrEmpty(ElementNameInternal))
		{
			BeginXmlDocument(sb, ElementNameInternal);
		}
		if (IndentXml && !string.IsNullOrEmpty(ElementNameInternal))
		{
			sb.Append("  ");
		}
		sb.Append('<');
		string text;
		if (ignorePropertiesElementName)
		{
			text = XmlHelper.XmlConvertToElementName(propName);
			sb.Append(text);
		}
		else
		{
			if (_propertiesElementNameHasFormat)
			{
				text = XmlHelper.XmlConvertToElementName(propName);
				sb.AppendFormat(CultureInfo.InvariantCulture, PropertiesElementName, text);
			}
			else
			{
				text = PropertiesElementName;
				sb.Append(PropertiesElementName);
			}
			RenderAttribute(sb, PropertiesElementKeyAttribute, propName);
		}
		if (ignoreValue)
		{
			sb.Append('>');
			if (IndentXml)
			{
				sb.AppendLine();
			}
		}
		else if (RenderAttribute(sb, PropertiesElementValueAttribute, xmlValueString))
		{
			sb.Append("/>");
			if (IndentXml)
			{
				sb.AppendLine();
			}
		}
		else
		{
			sb.Append('>');
			XmlHelper.EscapeXmlString(xmlValueString, xmlEncodeNewlines: false, sb);
			AppendClosingPropertyTag(text, sb, ignorePropertiesElementName);
		}
		return text;
	}

	private void AppendClosingPropertyTag(string propNameElement, StringBuilder sb, bool ignorePropertiesElementName = false)
	{
		sb.Append("</");
		if (ignorePropertiesElementName)
		{
			sb.Append(propNameElement);
		}
		else
		{
			sb.AppendFormat(CultureInfo.InvariantCulture, PropertiesElementName, propNameElement);
		}
		sb.Append('>');
		if (IndentXml)
		{
			sb.AppendLine();
		}
	}

	private static bool RenderAttribute(StringBuilder sb, string attributeName, string value)
	{
		if (!string.IsNullOrEmpty(attributeName))
		{
			sb.Append(' ');
			sb.Append(attributeName);
			sb.Append("=\"");
			XmlHelper.EscapeXmlString(value, xmlEncodeNewlines: true, sb);
			sb.Append('"');
			return true;
		}
		return false;
	}

	private bool RenderAppendXmlElementValue(XmlElementBase xmlElement, LogEventInfo logEvent, StringBuilder sb, bool beginXmlDocument)
	{
		if (string.IsNullOrEmpty(xmlElement.ElementNameInternal))
		{
			return false;
		}
		if (beginXmlDocument && !string.IsNullOrEmpty(ElementNameInternal))
		{
			BeginXmlDocument(sb, ElementNameInternal);
		}
		if (IndentXml && !string.IsNullOrEmpty(ElementNameInternal))
		{
			sb.Append("  ");
		}
		int length = sb.Length;
		xmlElement.Render(logEvent, sb);
		if (sb.Length == length && !xmlElement.IncludeEmptyValue)
		{
			return false;
		}
		if (IndentXml)
		{
			sb.AppendLine();
		}
		return true;
	}

	private bool RenderAppendXmlAttributeValue(XmlAttribute xmlAttribute, LogEventInfo logEvent, StringBuilder sb, bool beginXmlDocument)
	{
		string name = xmlAttribute.Name;
		if (string.IsNullOrEmpty(name))
		{
			return false;
		}
		if (beginXmlDocument)
		{
			sb.Append('<');
			sb.Append(ElementNameInternal);
		}
		sb.Append(' ');
		sb.Append(name);
		sb.Append("=\"");
		if (!xmlAttribute.RenderAppendXmlValue(logEvent, sb))
		{
			return false;
		}
		sb.Append('"');
		return true;
	}

	private void BeginXmlDocument(StringBuilder sb, string elementName)
	{
		RenderStartElement(sb, elementName);
		if (IndentXml)
		{
			sb.AppendLine();
		}
	}

	private void EndXmlDocument(StringBuilder sb, string elementName)
	{
		RenderEndElement(sb, elementName);
	}

	public override string ToString()
	{
		if (Elements.Count > 0)
		{
			return ToStringWithNestedItems(Elements, (XmlElement l) => l.ToString());
		}
		if (Attributes.Count > 0)
		{
			return ToStringWithNestedItems(Attributes, (XmlAttribute a) => "Attributes:" + a.Name);
		}
		if (ElementNameInternal != null)
		{
			return ToStringWithNestedItems(new XmlElementBase[1] { this }, (XmlElementBase n) => "Element:" + n.ElementNameInternal);
		}
		return GetType().Name;
	}

	private static void RenderSelfClosingElement(StringBuilder target, string elementName)
	{
		target.Append('<');
		target.Append(elementName);
		target.Append("/>");
	}

	private static void RenderStartElement(StringBuilder sb, string elementName)
	{
		sb.Append('<');
		sb.Append(elementName);
		sb.Append('>');
	}

	private static void RenderEndElement(StringBuilder sb, string elementName)
	{
		sb.Append("</");
		sb.Append(elementName);
		sb.Append('>');
	}
}
