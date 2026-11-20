using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using NLog.Config;
using NLog.Internal;
using NLog.LayoutRenderers;
using NLog.Layouts;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace NLog;

public static class SetupExtensionsBuilderExtensions
{
	[Obsolete("AutoLoadAssemblies(true) has been replaced by AutoLoadExtensions(), that matches the name of nlog-attribute in NLog.config. Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static ISetupExtensionsBuilder AutoLoadAssemblies(this ISetupExtensionsBuilder setupBuilder, bool enable)
	{
		if (enable)
		{
			setupBuilder.AutoLoadExtensions();
		}
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder AutoLoadExtensions(this ISetupExtensionsBuilder setupBuilder)
	{
		ConfigurationItemFactory.Default.AssemblyLoader.ScanForAutoLoadExtensions(ConfigurationItemFactory.Default);
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterAssembly(this ISetupExtensionsBuilder setupBuilder, Assembly assembly)
	{
		ConfigurationItemFactory.Default.AssemblyLoader.LoadAssembly(ConfigurationItemFactory.Default, assembly, string.Empty);
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterAssembly(this ISetupExtensionsBuilder setupBuilder, string assemblyName)
	{
		ConfigurationItemFactory.Default.AssemblyLoader.LoadAssemblyFromName(ConfigurationItemFactory.Default, assemblyName, string.Empty);
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties)] T>(this ISetupExtensionsBuilder setupBuilder) where T : class, new()
	{
		ConfigurationItemFactory.Default.RegisterType<T>();
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterTarget<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] T>(this ISetupExtensionsBuilder setupBuilder, string? name = null) where T : Target, new()
	{
		return setupBuilder.RegisterTarget(() => new T(), name);
	}

	public static ISetupExtensionsBuilder RegisterTarget<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] T>(this ISetupExtensionsBuilder setupBuilder, Func<T> factory, string? typeAlias = null) where T : Target
	{
		typeAlias = ((!string.IsNullOrEmpty(typeAlias)) ? typeAlias : typeof(T).GetFirstCustomAttribute<TargetAttribute>()?.Name);
		if (typeAlias == null || string.IsNullOrEmpty(typeAlias))
		{
			typeAlias = ResolveTypeAlias<T>(new string[2] { "TargetWrapper", "Target" });
			if (typeof(WrapperTargetBase).IsAssignableFrom(typeof(T)) && !typeAlias.EndsWith("Wrapper", StringComparison.OrdinalIgnoreCase))
			{
				typeAlias += "Wrapper";
			}
		}
		ConfigurationItemFactory.Default.GetTargetFactory().RegisterType(typeAlias, factory);
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterTarget(this ISetupExtensionsBuilder setupBuilder, string name, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] Type targetType)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentException("Missing NLog Target type-alias", "name");
		}
		if (!typeof(Target).IsAssignableFrom(targetType))
		{
			throw new ArgumentException("Not of type NLog Target", "targetType");
		}
		ConfigurationItemFactory.Default.GetTargetFactory().RegisterType(name, () => (Target)Activator.CreateInstance(targetType));
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterLayout<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] T>(this ISetupExtensionsBuilder setupBuilder, string? typeAlias = null) where T : Layout, new()
	{
		return setupBuilder.RegisterLayout(() => new T(), typeAlias);
	}

	public static ISetupExtensionsBuilder RegisterLayout<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] T>(this ISetupExtensionsBuilder setupBuilder, Func<T> factory, string? typeAlias = null) where T : Layout
	{
		typeAlias = ((typeAlias == null || string.IsNullOrEmpty(typeAlias)) ? ResolveTypeAlias<T, LayoutAttribute>(ArrayHelper.Empty<string>()) : typeAlias);
		ConfigurationItemFactory.Default.GetLayoutFactory().RegisterType(typeAlias, factory);
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterLayout(this ISetupExtensionsBuilder setupBuilder, string typeAlias, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] Type layoutType)
	{
		if (string.IsNullOrEmpty(typeAlias))
		{
			throw new ArgumentException("Missing NLog Layout type-alias", "typeAlias");
		}
		if (!typeof(Layout).IsAssignableFrom(layoutType))
		{
			throw new ArgumentException("Not of type NLog Layout", "layoutType");
		}
		ConfigurationItemFactory.Default.GetLayoutFactory().RegisterType(typeAlias, () => (Layout)Activator.CreateInstance(layoutType));
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterLayoutRenderer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] T>(this ISetupExtensionsBuilder setupBuilder, string? name = null) where T : LayoutRenderer, new()
	{
		return setupBuilder.RegisterLayoutRenderer(() => new T(), name);
	}

	public static ISetupExtensionsBuilder RegisterLayoutRenderer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] T>(this ISetupExtensionsBuilder setupBuilder, Func<T> factory, string? typeAlias = null) where T : LayoutRenderer
	{
		typeAlias = ((typeAlias == null || string.IsNullOrEmpty(typeAlias)) ? ResolveTypeAlias<T, LayoutRendererAttribute>(new string[2] { "LayoutRendererWrapper", "LayoutRenderer" }) : typeAlias);
		ConfigurationItemFactory.Default.GetLayoutRendererFactory().RegisterType(typeAlias, factory);
		return setupBuilder;
	}

	private static string ResolveTypeAlias<T, TNameAttribute>(params string[] trimEndings) where TNameAttribute : NameBaseAttribute
	{
		string text = typeof(T).GetFirstCustomAttribute<TNameAttribute>()?.Name;
		if (text == null || string.IsNullOrEmpty(text))
		{
			return ResolveTypeAlias<T>(trimEndings);
		}
		return text;
	}

	private static string ResolveTypeAlias<T>(params string[] trimEndings)
	{
		string name = typeof(T).Name;
		foreach (string value in trimEndings)
		{
			int num = name.IndexOf(value, StringComparison.OrdinalIgnoreCase);
			if (num > 0)
			{
				return name.Substring(0, num);
			}
		}
		return name;
	}

	public static ISetupExtensionsBuilder RegisterLayoutRenderer(this ISetupExtensionsBuilder setupBuilder, string name, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties)] Type layoutRendererType)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentException("Missing NLog LayoutRenderer type-alias", "name");
		}
		if (!typeof(LayoutRenderer).IsAssignableFrom(layoutRendererType))
		{
			throw new ArgumentException("Not of type NLog LayoutRenderer", "layoutRendererType");
		}
		ConfigurationItemFactory.Default.GetLayoutRendererFactory().RegisterType(name, () => (LayoutRenderer)Activator.CreateInstance(layoutRendererType));
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterLayoutRenderer(this ISetupExtensionsBuilder setupBuilder, string name, Func<LogEventInfo, object> layoutMethod)
	{
		return setupBuilder.RegisterLayoutRenderer(name, (LogEventInfo info, LoggingConfiguration? configuration) => layoutMethod(info));
	}

	public static ISetupExtensionsBuilder RegisterLayoutRenderer(this ISetupExtensionsBuilder setupBuilder, string name, Func<LogEventInfo, LoggingConfiguration?, object> layoutMethod)
	{
		return setupBuilder.RegisterLayoutRenderer(name, layoutMethod, LayoutRenderOptions.None);
	}

	public static ISetupExtensionsBuilder RegisterLayoutRenderer(this ISetupExtensionsBuilder setupBuilder, string name, Func<LogEventInfo, object> layoutMethod, LayoutRenderOptions options)
	{
		return setupBuilder.RegisterLayoutRenderer(name, (LogEventInfo info, LoggingConfiguration? configuration) => layoutMethod(info), options);
	}

	public static ISetupExtensionsBuilder RegisterLayoutRenderer(this ISetupExtensionsBuilder setupBuilder, string name, Func<LogEventInfo, LoggingConfiguration?, object> layoutMethod, LayoutRenderOptions options)
	{
		FuncLayoutRenderer layoutRenderer = Layout.CreateFuncLayoutRenderer(layoutMethod, options, name);
		return setupBuilder.RegisterLayoutRenderer(layoutRenderer);
	}

	public static ISetupExtensionsBuilder RegisterLayoutRenderer(this ISetupExtensionsBuilder setupBuilder, FuncLayoutRenderer layoutRenderer)
	{
		ConfigurationItemFactory.Default.GetLayoutRendererFactory().RegisterFuncLayout(layoutRenderer.LayoutRendererName, layoutRenderer);
		return setupBuilder;
	}

	[Obsolete("Instead use RegisterConditionMethod with delegate, as type reflection will be moved out. Marked obsolete with NLog v5.2")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static ISetupExtensionsBuilder RegisterConditionMethod(this ISetupExtensionsBuilder setupBuilder, string name, MethodInfo conditionMethod)
	{
		Guard.ThrowIfNull(conditionMethod, "conditionMethod");
		if (!conditionMethod.IsStatic)
		{
			throw new ArgumentException(conditionMethod.Name + " must be static", "conditionMethod");
		}
		ConfigurationItemFactory.Default.GetConditionMethodFactory().RegisterDefinition(name, conditionMethod);
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterConditionMethod(this ISetupExtensionsBuilder setupBuilder, string name, Func<LogEventInfo, object> conditionMethod)
	{
		Guard.ThrowIfNull(conditionMethod, "conditionMethod");
		ConfigurationItemFactory.Default.GetConditionMethodFactory().RegisterNoParameters(name, (LogEventInfo logEvent) => conditionMethod(logEvent));
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterConditionMethod(this ISetupExtensionsBuilder setupBuilder, string name, Func<object> conditionMethod)
	{
		Guard.ThrowIfNull(conditionMethod, "conditionMethod");
		ConfigurationItemFactory.Default.GetConditionMethodFactory().RegisterNoParameters(name, (LogEventInfo logEvent) => conditionMethod());
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterSingletonService<T>(this ISetupExtensionsBuilder setupBuilder, T singletonService) where T : class
	{
		Guard.ThrowIfNull(singletonService, "singletonService");
		setupBuilder.LogFactory.ServiceRepository.RegisterSingleton(singletonService);
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterSingletonService(this ISetupExtensionsBuilder setupBuilder, Type interfaceType, object singletonService)
	{
		Guard.ThrowIfNull(interfaceType, "interfaceType");
		Guard.ThrowIfNull(singletonService, "singletonService");
		if (!interfaceType.IsAssignableFrom(singletonService.GetType()))
		{
			throw new ArgumentException("Service instance not matching type", "singletonService");
		}
		setupBuilder.LogFactory.ServiceRepository.RegisterService(interfaceType, singletonService);
		return setupBuilder;
	}

	public static ISetupExtensionsBuilder RegisterServiceProvider(this ISetupExtensionsBuilder setupBuilder, IServiceProvider serviceProvider)
	{
		Guard.ThrowIfNull(serviceProvider, "serviceProvider");
		setupBuilder.LogFactory.ServiceRepository.RegisterSingleton(serviceProvider);
		return setupBuilder;
	}
}
