using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using NLog.Common;
using NLog.Filters;
using NLog.Internal;
using NLog.LayoutRenderers;
using NLog.Layouts;
using NLog.Targets;
using NLog.Time;

namespace NLog.Config;

public sealed class ConfigurationItemFactory
{
	private readonly struct ItemFactory
	{
		public readonly Func<Dictionary<string, PropertyInfo>> ItemProperties;

		public readonly Func<object?> ItemCreator;

		public ItemFactory(Func<Dictionary<string, PropertyInfo>> itemProperties, Func<object?> itemCreator)
		{
			ItemProperties = itemProperties;
			ItemCreator = itemCreator;
		}
	}

	private static ConfigurationItemFactory? _defaultInstance;

	internal static readonly object SyncRoot = new object();

	private readonly ServiceRepository _serviceRepository;

	private readonly IFactory[] _allFactories;

	private readonly Factory<Target, TargetAttribute> _targets;

	private readonly Factory<Filter, FilterAttribute> _filters;

	private readonly LayoutRendererFactory _layoutRenderers;

	private readonly Factory<Layout, LayoutAttribute> _layouts;

	private readonly MethodFactory _conditionMethods;

	private readonly Factory<LayoutRenderer, AmbientPropertyAttribute> _ambientProperties;

	private readonly Factory<TimeSource, TimeSourceAttribute> _timeSources;

	private readonly Dictionary<Type, ItemFactory> _itemFactories = new Dictionary<Type, ItemFactory>(256);

	internal IAssemblyExtensionLoader AssemblyLoader { get; } = new AssemblyExtensionLoader();

	public static ConfigurationItemFactory Default
	{
		get
		{
			return _defaultInstance ?? (_defaultInstance = new ConfigurationItemFactory(LogManager.LogFactory.ServiceRepository));
		}
		set
		{
			_defaultInstance = value;
		}
	}

	public IFactory<Target> TargetFactory
	{
		get
		{
			if (!_targets.Initialized)
			{
				_targets.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllTargets(skipCheckExists);
				});
				if (!_filters.Initialized)
				{
					_filters.Initialize(delegate(bool skipCheckExists)
					{
						RegisterAllFilters(skipCheckExists);
					});
				}
				if (!_conditionMethods.Initialized)
				{
					_conditionMethods.Initialize(delegate(bool skipCheckExists)
					{
						RegisterAllConditionMethods(skipCheckExists);
					});
				}
				if (!_layouts.Initialized)
				{
					_layouts.Initialize(delegate(bool skipCheckExists)
					{
						RegisterAllLayouts(skipCheckExists);
					});
				}
				if (!_layoutRenderers.Initialized)
				{
					_layoutRenderers.Initialize(delegate(bool skipCheckExists)
					{
						RegisterAllLayoutRenderers(skipCheckExists);
					});
				}
			}
			return _targets;
		}
	}

	public IFactory<Layout> LayoutFactory
	{
		get
		{
			if (!_layouts.Initialized)
			{
				_layouts.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllLayouts(skipCheckExists);
				});
				if (!_layoutRenderers.Initialized)
				{
					_layoutRenderers.Initialize(delegate(bool skipCheckExists)
					{
						RegisterAllLayoutRenderers(skipCheckExists);
					});
				}
				if (!_conditionMethods.Initialized)
				{
					_conditionMethods.Initialize(delegate(bool skipCheckExists)
					{
						RegisterAllConditionMethods(skipCheckExists);
					});
				}
			}
			return _layouts;
		}
	}

	public IFactory<LayoutRenderer> LayoutRendererFactory
	{
		get
		{
			if (!_layoutRenderers.Initialized)
			{
				_layoutRenderers.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllLayoutRenderers(skipCheckExists);
				});
			}
			if (!_conditionMethods.Initialized)
			{
				_conditionMethods.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllConditionMethods(skipCheckExists);
				});
			}
			return _layoutRenderers;
		}
	}

	public IFactory<LayoutRenderer> AmbientRendererFactory
	{
		get
		{
			if (!_layoutRenderers.Initialized)
			{
				_layoutRenderers.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllLayoutRenderers(skipCheckExists);
				});
			}
			if (!_conditionMethods.Initialized)
			{
				_conditionMethods.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllConditionMethods(skipCheckExists);
				});
			}
			return _ambientProperties;
		}
	}

	public IFactory<Filter> FilterFactory
	{
		get
		{
			if (!_filters.Initialized)
			{
				_filters.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllFilters(skipCheckExists);
				});
			}
			if (!_conditionMethods.Initialized)
			{
				_conditionMethods.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllConditionMethods(skipCheckExists);
				});
			}
			return _filters;
		}
	}

	public IFactory<TimeSource> TimeSourceFactory
	{
		get
		{
			if (!_timeSources.Initialized)
			{
				_timeSources.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllTimeSources(skipCheckExists);
				});
			}
			return _timeSources;
		}
	}

	internal MethodFactory ConditionMethodFactory
	{
		get
		{
			if (!_conditionMethods.Initialized)
			{
				_conditionMethods.Initialize(delegate(bool skipCheckExists)
				{
					RegisterAllConditionMethods(skipCheckExists);
				});
			}
			return _conditionMethods;
		}
	}

	internal ICollection<Type> ItemTypes
	{
		get
		{
			lock (SyncRoot)
			{
				return new List<Type>(_itemFactories.Keys);
			}
		}
	}

	[Obsolete("Instead use NLog.LogManager.Setup().SetupSerialization(s => s.RegisterJsonConverter()) or ResolveService<IJsonConverter>(). Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IJsonConverter JsonConverter
	{
		get
		{
			return _serviceRepository.GetService<IJsonConverter>();
		}
		set
		{
			_serviceRepository.RegisterJsonConverter(value);
		}
	}

	public bool? ParseMessageTemplates
	{
		get
		{
			return _serviceRepository.ResolveParseMessageTemplates();
		}
		set
		{
			_serviceRepository.ParseMessageTemplates(LogManager.LogFactory, value);
		}
	}

	public ConfigurationItemFactory()
		: this(LogManager.LogFactory.ServiceRepository)
	{
	}

	internal ConfigurationItemFactory(ServiceRepository serviceRepository)
	{
		_serviceRepository = Guard.ThrowIfNull(serviceRepository, "serviceRepository");
		_targets = new Factory<Target, TargetAttribute>(this);
		_filters = new Factory<Filter, FilterAttribute>(this);
		_layoutRenderers = new LayoutRendererFactory(this);
		_layouts = new Factory<Layout, LayoutAttribute>(this);
		_conditionMethods = new MethodFactory();
		_ambientProperties = new Factory<LayoutRenderer, AmbientPropertyAttribute>(this);
		_timeSources = new Factory<TimeSource, TimeSourceAttribute>(this);
		_allFactories = new IFactory[7] { _targets, _filters, _layoutRenderers, _layouts, _conditionMethods, _ambientProperties, _timeSources };
		RegisterType<LoggingRule>();
	}

	internal Factory<Target, TargetAttribute> GetTargetFactory()
	{
		return _targets;
	}

	internal Factory<Layout, LayoutAttribute> GetLayoutFactory()
	{
		return _layouts;
	}

	internal LayoutRendererFactory GetLayoutRendererFactory()
	{
		return _layoutRenderers;
	}

	internal Factory<LayoutRenderer, AmbientPropertyAttribute> GetAmbientPropertyFactory()
	{
		return _ambientProperties;
	}

	internal Factory<Filter, FilterAttribute> GetFilterFactory()
	{
		return _filters;
	}

	internal Factory<TimeSource, TimeSourceAttribute> GetTimeSourceFactory()
	{
		return _timeSources;
	}

	internal MethodFactory GetConditionMethodFactory()
	{
		return _conditionMethods;
	}

	[Obsolete("Instead use NLog.LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RegisterItemsFromAssembly(Assembly assembly)
	{
		AssemblyLoader.LoadAssembly(this, assembly, string.Empty);
	}

	[Obsolete("Instead use NLog.LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RegisterItemsFromAssembly(Assembly assembly, string itemNamePrefix)
	{
		AssemblyLoader.LoadAssembly(this, assembly, itemNamePrefix);
	}

	public void Clear()
	{
		lock (SyncRoot)
		{
			IFactory[] allFactories = _allFactories;
			for (int i = 0; i < allFactories.Length; i++)
			{
				allFactories[i].Clear();
			}
		}
	}

	[Obsolete("Instead use NLog.LogManager.Setup().SetupExtensions(). Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RegisterType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties)] Type type, string? itemNamePrefix)
	{
		lock (SyncRoot)
		{
			IFactory[] allFactories = _allFactories;
			for (int i = 0; i < allFactories.Length; i++)
			{
				allFactories[i].RegisterType(type, itemNamePrefix ?? string.Empty);
			}
		}
	}

	internal void RegisterType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties)] TType>() where TType : class, new()
	{
		lock (SyncRoot)
		{
			RegisterTypeProperties<TType>(() => new TType());
			IFactory[] allFactories = _allFactories;
			for (int num = 0; num < allFactories.Length; num++)
			{
				allFactories[num].RegisterType(typeof(TType), string.Empty);
			}
		}
	}

	internal void RegisterTypeProperties<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] TType>(Func<object?> itemCreator)
	{
		lock (SyncRoot)
		{
			if (_itemFactories.ContainsKey(typeof(TType)))
			{
				return;
			}
			Dictionary<string, PropertyInfo> properties = null;
			Func<Dictionary<string, PropertyInfo>> itemProperties = () => properties ?? (properties = typeof(TType).GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary<PropertyInfo, string>((PropertyInfo p) => p.Name, StringComparer.OrdinalIgnoreCase));
			ItemFactory value = new ItemFactory(itemProperties, itemCreator);
			_itemFactories[typeof(TType)] = value;
		}
	}

	internal void RegisterTypeProperties([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] Type itemType, Func<object?> itemCreator)
	{
		lock (SyncRoot)
		{
			if (_itemFactories.ContainsKey(itemType))
			{
				return;
			}
			Dictionary<string, PropertyInfo> properties = null;
			Func<Dictionary<string, PropertyInfo>> itemProperties = () => properties ?? (properties = itemType.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary<PropertyInfo, string>((PropertyInfo p) => p.Name, StringComparer.OrdinalIgnoreCase));
			ItemFactory value = new ItemFactory(itemProperties, itemCreator);
			_itemFactories[itemType] = value;
		}
	}

	internal Dictionary<string, PropertyInfo> TryGetTypeProperties(Type itemType)
	{
		lock (SyncRoot)
		{
			if (_itemFactories.TryGetValue(itemType, out var value))
			{
				return value.ItemProperties();
			}
		}
		if (itemType.IsAbstract)
		{
			return new Dictionary<string, PropertyInfo>();
		}
		if (itemType.IsGenericType && itemType.GetGenericTypeDefinition() == typeof(Layout<>))
		{
			return new Dictionary<string, PropertyInfo>();
		}
		InternalLogger.Debug("Object reflection needed to configure instance of type: {0}", itemType);
		return ResolveTypePropertiesLegacy(itemType);
	}

	[UnconditionalSuppressMessage("Trimming - Ignore since obsolete", "IL2067")]
	[UnconditionalSuppressMessage("Trimming - Ignore since obsolete", "IL2070")]
	[UnconditionalSuppressMessage("Trimming - Ignore since obsolete", "IL2072")]
	[Obsolete("Instead use RegisterType<T>, as dynamic Assembly loading will be moved out. Marked obsolete with NLog v5.2")]
	private Dictionary<string, PropertyInfo> ResolveTypePropertiesLegacy(Type itemType)
	{
		Dictionary<string, PropertyInfo> properties = itemType.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary<PropertyInfo, string>((PropertyInfo p) => p.Name, StringComparer.OrdinalIgnoreCase);
		lock (SyncRoot)
		{
			_itemFactories[itemType] = new ItemFactory(() => properties, () => Activator.CreateInstance(itemType));
		}
		return properties;
	}

	internal bool TryCreateInstance(Type itemType, out object? instance)
	{
		Func<object> func = null;
		lock (SyncRoot)
		{
			if (_itemFactories.TryGetValue(itemType, out var value))
			{
				func = value.ItemCreator;
			}
		}
		if (func == null)
		{
			InternalLogger.Debug("Object reflection needed to create instance of type: {0}", itemType);
			instance = ResolveCreateInstanceLegacy(itemType);
		}
		else
		{
			instance = func();
		}
		return instance != null;
	}

	[UnconditionalSuppressMessage("Trimming - Ignore since obsolete", "IL2067")]
	[UnconditionalSuppressMessage("Trimming - Ignore since obsolete", "IL2070")]
	[UnconditionalSuppressMessage("Trimming - Ignore since obsolete", "IL2072")]
	[Obsolete("Instead use RegisterType<T>, as dynamic Assembly loading will be moved out. Marked obsolete with NLog v5.2")]
	private object? ResolveCreateInstanceLegacy(Type itemType)
	{
		Dictionary<string, PropertyInfo> properties = null;
		Func<Dictionary<string, PropertyInfo>> itemProperties = () => properties ?? (properties = itemType.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary<PropertyInfo, string>((PropertyInfo p) => p.Name, StringComparer.OrdinalIgnoreCase));
		ItemFactory value = new ItemFactory(itemProperties, () => Activator.CreateInstance(itemType));
		lock (SyncRoot)
		{
			_itemFactories[itemType] = value;
		}
		return value.ItemCreator();
	}

	private static void SafeRegisterNamedType<TBaseType, TAttributeType>(Factory<TBaseType, TAttributeType> factory, string typeAlias, string fullTypeName, bool skipCheckExists) where TBaseType : class where TAttributeType : NameBaseAttribute
	{
		if (skipCheckExists || !factory.CheckTypeAliasExists(typeAlias))
		{
			factory.RegisterNamedType(typeAlias, fullTypeName);
		}
	}

	private void RegisterAllTargets(bool skipCheckExists)
	{
		AssemblyExtensionTypes.RegisterTargetTypes(this, skipCheckExists);
		SafeRegisterNamedType(_targets, "diagnosticlistener", "NLog.Targets.DiagnosticListenerTarget, NLog.DiagnosticSource", skipCheckExists);
		SafeRegisterNamedType(_targets, "database", "NLog.Targets.DatabaseTarget, NLog.Database", skipCheckExists);
		SafeRegisterNamedType(_targets, "atomfile", "NLog.Targets.AtomicFileTarget, NLog.Targets.AtomicFile", skipCheckExists);
		SafeRegisterNamedType(_targets, "atomicfile", "NLog.Targets.AtomicFileTarget, NLog.Targets.AtomicFile", skipCheckExists);
		SafeRegisterNamedType(_targets, "eventlog", "NLog.Targets.EventLogTarget, NLog.WindowsEventLog", skipCheckExists);
		SafeRegisterNamedType(_targets, "impersonatingwrapper", "NLog.Targets.Wrappers.ImpersonatingTargetWrapper, NLog.WindowsIdentity", skipCheckExists);
		SafeRegisterNamedType(_targets, "logreceiverservice", "NLog.Targets.LogReceiverWebServiceTarget, NLog.Wcf", skipCheckExists);
		SafeRegisterNamedType(_targets, "outputdebugstring", "NLog.Targets.OutputDebugStringTarget, NLog.OutputDebugString", skipCheckExists);
		SafeRegisterNamedType(_targets, "network", "NLog.Targets.NetworkTarget, NLog.Targets.Network", skipCheckExists);
		SafeRegisterNamedType(_targets, "log4jxml", "NLog.Targets.Log4JXmlTarget, NLog.Targets.Network", skipCheckExists);
		SafeRegisterNamedType(_targets, "chainsaw", "NLog.Targets.Log4JXmlTarget, NLog.Targets.Network", skipCheckExists);
		SafeRegisterNamedType(_targets, "nlogviewer", "NLog.Targets.Log4JXmlTarget, NLog.Targets.Network", skipCheckExists);
		SafeRegisterNamedType(_targets, "syslog", "NLog.Targets.SyslogTarget, NLog.Targets.Network", skipCheckExists);
		SafeRegisterNamedType(_targets, "gelf", "NLog.Targets.GelfTarget, NLog.Targets.Network", skipCheckExists);
		SafeRegisterNamedType(_targets, "mail", "NLog.Targets.MailTarget, NLog.Targets.Mail", skipCheckExists);
		SafeRegisterNamedType(_targets, "email", "NLog.Targets.MailTarget, NLog.Targets.Mail", skipCheckExists);
		SafeRegisterNamedType(_targets, "smtp", "NLog.Targets.MailTarget, NLog.Targets.Mail", skipCheckExists);
		SafeRegisterNamedType(_targets, "performancecounter", "NLog.Targets.PerformanceCounterTarget, NLog.PerformanceCounter", skipCheckExists);
		SafeRegisterNamedType(_targets, "richtextbox", "NLog.Windows.Forms.RichTextBoxTarget, NLog.Windows.Forms", skipCheckExists);
		SafeRegisterNamedType(_targets, "messagebox", "NLog.Windows.Forms.MessageBoxTarget, NLog.Windows.Forms", skipCheckExists);
		SafeRegisterNamedType(_targets, "formcontrol", "NLog.Windows.Forms.FormControlTarget, NLog.Windows.Forms", skipCheckExists);
		SafeRegisterNamedType(_targets, "toolstripitem", "NLog.Windows.Forms.ToolStripItemTarget, NLog.Windows.Forms", skipCheckExists);
		SafeRegisterNamedType(_targets, "trace", "NLog.Targets.TraceTarget, NLog.Targets.Trace", skipCheckExists);
		SafeRegisterNamedType(_targets, "tracesystem", "NLog.Targets.TraceTarget, NLog.Targets.Trace", skipCheckExists);
		SafeRegisterNamedType(_targets, "webservice", "NLog.Targets.WebServiceTarget, NLog.Targets.WebService", skipCheckExists);
	}

	private void RegisterAllLayouts(bool skipCheckExists)
	{
		AssemblyExtensionTypes.RegisterLayoutTypes(this, skipCheckExists);
		SafeRegisterNamedType(_layouts, "microsoftconsolejsonlayout", "NLog.Extensions.Logging.MicrosoftConsoleJsonLayout, NLog.Extensions.Logging", skipCheckExists);
		SafeRegisterNamedType(_layouts, "sysloglayout", "NLog.Targets.SyslogLayout, NLog.Targets.Network", skipCheckExists);
		SafeRegisterNamedType(_layouts, "log4jxmllayout", "NLog.Targets.Log4JXmlEventLayout, NLog.Targets.Network", skipCheckExists);
		SafeRegisterNamedType(_layouts, "log4jxmleventlayout", "NLog.Targets.Log4JXmlEventLayout, NLog.Targets.Network", skipCheckExists);
		SafeRegisterNamedType(_layouts, "gelflayout", "NLog.Targets.GelfLayout, NLog.Targets.Network", skipCheckExists);
	}

	private void RegisterAllLayoutRenderers(bool skipCheckExists)
	{
		AssemblyExtensionTypes.RegisterLayoutRendererTypes(this, skipCheckExists);
		SafeRegisterNamedType(_layoutRenderers, "configsetting", "NLog.Extensions.Logging.ConfigSettingLayoutRenderer, NLog.Extensions.Logging", skipCheckExists);
		SafeRegisterNamedType(_layoutRenderers, "microsoftconsolelayout", "NLog.Extensions.Logging.MicrosoftConsoleLayoutRenderer, NLog.Extensions.Logging", skipCheckExists);
		SafeRegisterNamedType(_layoutRenderers, "performancecounter", "NLog.LayoutRenderers.PerformanceCounterLayoutRenderer, NLog.PerformanceCounter", skipCheckExists);
		SafeRegisterNamedType(_layoutRenderers, "registry", "NLog.LayoutRenderers.RegistryLayoutRenderer, NLog.WindowsRegistry", skipCheckExists);
		SafeRegisterNamedType(_layoutRenderers, "windowsidentity", "NLog.LayoutRenderers.WindowsIdentityLayoutRenderer, NLog.WindowsIdentity", skipCheckExists);
		SafeRegisterNamedType(_layoutRenderers, "rtblink", "NLog.Windows.Forms.RichTextBoxLinkLayoutRenderer, NLog.Windows.Forms", skipCheckExists);
		SafeRegisterNamedType(_layoutRenderers, "activity", "NLog.LayoutRenderers.ActivityTraceLayoutRenderer, NLog.DiagnosticSource", skipCheckExists);
		SafeRegisterNamedType(_layoutRenderers, "activityid", "NLog.LayoutRenderers.TraceActivityIdLayoutRenderer, NLog.Targets.Trace", skipCheckExists);
	}

	private void RegisterAllFilters(bool skipCheckExists)
	{
		AssemblyExtensionTypes.RegisterFilterTypes(this, skipCheckExists);
	}

	private void RegisterAllConditionMethods(bool skipCheckExists)
	{
		AssemblyExtensionTypes.RegisterConditionTypes(this, skipCheckExists);
	}

	private void RegisterAllTimeSources(bool skipCheckExists)
	{
		AssemblyExtensionTypes.RegisterTimeSourceTypes(this, skipCheckExists);
	}
}
