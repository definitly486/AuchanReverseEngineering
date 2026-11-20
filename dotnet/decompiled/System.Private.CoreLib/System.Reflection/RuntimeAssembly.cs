using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Threading;
using Mono;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeAssembly : Assembly
{
	private enum AssemblyInfoKind
	{
		Location = 1,
		CodeBase,
		FullName,
		ImageRuntimeVersion
	}

	private sealed class ResolveEventHolder
	{
		public event ModuleResolveEventHandler ModuleResolve;
	}

	private sealed class UnmanagedMemoryStreamForModule : UnmanagedMemoryStream
	{
		private Module module;

		public unsafe UnmanagedMemoryStreamForModule(byte* pointer, long length, Module module)
			: base(pointer, length)
		{
			this.module = module;
		}
	}

	private nint _mono_assembly;

	private LoaderAllocator m_keepalive;

	private ResolveEventHolder resolve_event_holder;

	public override MethodInfo EntryPoint
	{
		get
		{
			RuntimeAssembly assembly = this;
			MethodInfo o = null;
			GetEntryPoint(new QCallAssembly(ref assembly), ObjectHandleOnStack.Create(ref o));
			return o;
		}
	}

	public override bool ReflectionOnly => false;

	[Obsolete("Assembly.CodeBase and Assembly.EscapedCodeBase are only included for .NET Framework compatibility. Use Assembly.Location.", DiagnosticId = "SYSLIB0012", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[RequiresAssemblyFiles("This member throws an exception for assemblies embedded in a single-file app")]
	public override string CodeBase => GetInfo(AssemblyInfoKind.CodeBase);

	public override string FullName => GetInfo(AssemblyInfoKind.FullName);

	public override Module ManifestModule
	{
		get
		{
			RuntimeAssembly assembly = this;
			Module o = null;
			GetManifestModuleInternal(new QCallAssembly(ref assembly), ObjectHandleOnStack.Create(ref o));
			return o;
		}
	}

	[Obsolete("The Global Assembly Cache is not supported.", DiagnosticId = "SYSLIB0005", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public override bool GlobalAssemblyCache => false;

	public override long HostContext => 0L;

	public override string ImageRuntimeVersion => GetInfo(AssemblyInfoKind.ImageRuntimeVersion);

	public override string Location => GetInfo(AssemblyInfoKind.Location);

	public override bool IsCollectible => AssemblyLoadContext.GetLoadContext(this).IsCollectible;

	public override event ModuleResolveEventHandler ModuleResolve
	{
		add
		{
			resolve_event_holder.ModuleResolve += value;
		}
		remove
		{
			resolve_event_holder.ModuleResolve -= value;
		}
	}

	internal nint GetUnderlyingNativeHandle()
	{
		return _mono_assembly;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetEntryPoint(QCallAssembly assembly, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetManifestResourceNames(QCallAssembly assembly_h, ObjectHandleOnStack res);

	public override string[] GetManifestResourceNames()
	{
		RuntimeAssembly assembly = this;
		string[] o = null;
		GetManifestResourceNames(new QCallAssembly(ref assembly), ObjectHandleOnStack.Create(ref o));
		return o;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetExportedTypes(QCallAssembly assembly_h, ObjectHandleOnStack res);

	[RequiresUnreferencedCode("Types might be removed")]
	public override Type[] GetExportedTypes()
	{
		RuntimeAssembly assembly = this;
		Type[] o = null;
		GetExportedTypes(new QCallAssembly(ref assembly), ObjectHandleOnStack.Create(ref o));
		return o;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetTopLevelForwardedTypes(QCallAssembly assembly_h, ObjectHandleOnStack res);

	[RequiresUnreferencedCode("Types might be removed")]
	public override Type[] GetForwardedTypes()
	{
		RuntimeAssembly assembly = this;
		Type[] o = null;
		GetTopLevelForwardedTypes(new QCallAssembly(ref assembly), ObjectHandleOnStack.Create(ref o));
		List<Type> list = new List<Type>(o);
		List<Exception> list2 = new List<Exception>();
		Type[] array = o;
		for (int i = 0; i < array.Length; i++)
		{
			AddPublicNestedTypes(array[i], list, list2);
		}
		if (list2.Count > 0)
		{
			list.AddRange(new Type[list2.Count]);
			list2.InsertRange(0, new Exception[list.Count]);
			throw new ReflectionTypeLoadException(list.ToArray(), list2.ToArray());
		}
		return list.ToArray();
	}

	[RequiresUnreferencedCode("Types might be removed")]
	private static void AddPublicNestedTypes(Type type, List<Type> types, List<Exception> exceptions)
	{
		Type[] nestedTypes;
		try
		{
			nestedTypes = type.GetNestedTypes(BindingFlags.Public);
		}
		catch (FileLoadException item)
		{
			exceptions.Add(item);
			return;
		}
		catch (FileNotFoundException item2)
		{
			exceptions.Add(item2);
			return;
		}
		catch (TypeLoadException item3)
		{
			exceptions.Add(item3);
			return;
		}
		catch (IOException item4)
		{
			exceptions.Add(item4);
			return;
		}
		catch (UnauthorizedAccessException item5)
		{
			exceptions.Add(item5);
			return;
		}
		Type[] array = nestedTypes;
		foreach (Type type2 in array)
		{
			types.Add(type2);
			AddPublicNestedTypes(type2, types, exceptions);
		}
	}

	public override ManifestResourceInfo GetManifestResourceInfo(string resourceName)
	{
		ArgumentException.ThrowIfNullOrEmpty(resourceName, "resourceName");
		ManifestResourceInfo manifestResourceInfo = new ManifestResourceInfo(null, null, (ResourceLocation)0);
		RuntimeAssembly assembly = this;
		if (GetManifestResourceInfoInternal(new QCallAssembly(ref assembly), resourceName, manifestResourceInfo))
		{
			return manifestResourceInfo;
		}
		return null;
	}

	public unsafe override Stream GetManifestResourceStream(string name)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		Module o = null;
		RuntimeAssembly assembly = this;
		int size;
		byte* manifestResourceInternal = (byte*)GetManifestResourceInternal(new QCallAssembly(ref assembly), name, out size, ObjectHandleOnStack.Create(ref o));
		if (manifestResourceInternal == null)
		{
			assembly = AssemblyLoadContext.OnResourceResolve(assembly, name);
			if (assembly != null)
			{
				manifestResourceInternal = (byte*)GetManifestResourceInternal(new QCallAssembly(ref assembly), name, out size, ObjectHandleOnStack.Create(ref o));
			}
			if (manifestResourceInternal == null)
			{
				return null;
			}
		}
		return new UnmanagedMemoryStreamForModule(manifestResourceInternal, size, o);
	}

	public override Stream GetManifestResourceStream(Type type, string name)
	{
		if (name == null)
		{
			ArgumentNullException.ThrowIfNull(type, "type");
		}
		string text = type?.Namespace;
		string name2 = ((text != null && name != null) ? (text + Type.Delimiter + name) : (text + name));
		return GetManifestResourceStream(name2);
	}

	public override AssemblyName GetName(bool copiedName)
	{
		return AssemblyName.Create(_mono_assembly, GetInfo(AssemblyInfoKind.CodeBase));
	}

	[RequiresUnreferencedCode("Types might be removed by trimming. If the type name is a string literal, consider using Type.GetType instead.")]
	public override Type GetType(string name, bool throwOnError, bool ignoreCase)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		return InternalGetType(null, name, throwOnError, ignoreCase);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(this, attributeType, inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return RuntimeCustomAttributeData.GetCustomAttributesInternal(this);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, attributeType, inherit);
	}

	public override Module GetModule(string name)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		Module[] modules = GetModules(getResourceModules: true);
		foreach (Module module in modules)
		{
			if (module.ScopeName == name)
			{
				return module;
			}
		}
		return null;
	}

	public override Module[] GetModules(bool getResourceModules)
	{
		RuntimeAssembly assembly = this;
		Module[] o = null;
		GetModulesInternal(new QCallAssembly(ref assembly), ObjectHandleOnStack.Create(ref o));
		Module[] array = o;
		if (!getResourceModules)
		{
			List<Module> list = new List<Module>(array.Length);
			Module[] array2 = array;
			foreach (Module module in array2)
			{
				if (!module.IsResource())
				{
					list.Add(module);
				}
			}
			return list.ToArray();
		}
		return array;
	}

	public override Module[] GetLoadedModules(bool getResourceModules)
	{
		return GetModules(getResourceModules);
	}

	internal unsafe static AssemblyName[] GetReferencedAssemblies(Assembly assembly)
	{
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(InternalGetReferencedAssemblies(assembly));
		int length = safeGPtrArrayHandle.Length;
		try
		{
			AssemblyName[] array = new AssemblyName[length];
			for (int i = 0; i < length; i++)
			{
				AssemblyName assemblyName = new AssemblyName();
				MonoAssemblyName* native = (MonoAssemblyName*)safeGPtrArrayHandle[i];
				assemblyName.FillName(native, null, addVersion: true, addPublickey: false, defaultToken: true);
				array[i] = assemblyName;
			}
			return array;
		}
		finally
		{
			for (int j = 0; j < length; j++)
			{
				MonoAssemblyName* ptr = (MonoAssemblyName*)safeGPtrArrayHandle[j];
				AssemblyName.FreeAssemblyName(ref *ptr, freeStruct: true);
			}
		}
	}

	[RequiresUnreferencedCode("Assembly references might be removed")]
	public override AssemblyName[] GetReferencedAssemblies()
	{
		return GetReferencedAssemblies(this);
	}

	public override Assembly GetSatelliteAssembly(CultureInfo culture)
	{
		return GetSatelliteAssembly(culture, null);
	}

	public override Assembly GetSatelliteAssembly(CultureInfo culture, Version version)
	{
		ArgumentNullException.ThrowIfNull(culture, "culture");
		return InternalGetSatelliteAssembly(this, culture, version, throwOnFileNotFound: true);
	}

	internal static Assembly InternalGetSatelliteAssembly(Assembly assembly, CultureInfo culture, Version version, bool throwOnFileNotFound)
	{
		AssemblyName name = assembly.GetName();
		AssemblyName assemblyName = new AssemblyName();
		if (version == null)
		{
			assemblyName.Version = name.Version;
		}
		else
		{
			assemblyName.Version = version;
		}
		assemblyName.CultureInfo = culture;
		assemblyName.Name = name.Name + ".resources";
		Assembly assembly2 = null;
		try
		{
			StackCrawlMark stackMark = StackCrawlMark.LookForMe;
			assembly2 = Assembly.Load(assemblyName, ref stackMark, AssemblyLoadContext.GetLoadContext(assembly));
		}
		catch
		{
		}
		if (assembly2 == assembly)
		{
			assembly2 = null;
		}
		if (assembly2 == null && throwOnFileNotFound)
		{
			throw new FileNotFoundException(SR.Format(culture, "IO_FileNotFound_FileName", assemblyName.Name));
		}
		return assembly2;
	}

	[RequiresAssemblyFiles("This member throws an exception for assemblies embedded in a single-file app")]
	public override FileStream GetFile(string name)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		if (Location.Length == 0)
		{
			throw new FileNotFoundException("IO_NoFileTableInInMemoryAssemblies");
		}
		RuntimeModule runtimeModule = (RuntimeModule)GetModule(name);
		if (runtimeModule != null)
		{
			return new FileStream(runtimeModule.FullyQualifiedName, FileMode.Open, FileAccess.Read);
		}
		return null;
	}

	[RequiresAssemblyFiles("This member throws an exception for assemblies embedded in a single-file app")]
	public override FileStream[] GetFiles(bool getResourceModules)
	{
		if (Location.Length == 0)
		{
			throw new FileNotFoundException("IO_NoFileTableInInMemoryAssemblies");
		}
		Module[] modules = GetModules(getResourceModules);
		if (modules.Length == 0)
		{
			return Array.Empty<FileStream>();
		}
		FileStream[] array = new FileStream[modules.Length];
		for (int i = 0; i < modules.Length; i++)
		{
			RuntimeModule runtimeModule = (RuntimeModule)modules[i];
			array[i] = new FileStream(runtimeModule.FullyQualifiedName, FileMode.Open, FileAccess.Read);
		}
		return array;
	}

	internal static RuntimeAssembly InternalLoad(AssemblyName assemblyRef, ref StackCrawlMark stackMark, AssemblyLoadContext assemblyLoadContext)
	{
		RuntimeAssembly obj = (RuntimeAssembly)Assembly.InternalLoad(assemblyRef.FullName, ref stackMark, assemblyLoadContext?.NativeALC ?? IntPtr.Zero);
		if (obj == null)
		{
			throw new FileNotFoundException(null, assemblyRef.Name);
		}
		return obj;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetInfo(QCallAssembly assembly, ObjectHandleOnStack res, AssemblyInfoKind kind);

	private string GetInfo(AssemblyInfoKind kind)
	{
		RuntimeAssembly assembly = this;
		string o = null;
		GetInfo(new QCallAssembly(ref assembly), ObjectHandleOnStack.Create(ref o), kind);
		return o;
	}

	internal unsafe bool TryGetRawMetadata(out byte* blob, out int length)
	{
		RuntimeAssembly assembly = this;
		return InternalTryGetRawMetadata(new QCallAssembly(ref assembly), out blob, out length);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetManifestResourceInfoInternal(QCallAssembly assembly, string name, ManifestResourceInfo info);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetManifestResourceInternal(QCallAssembly assembly, string name, out int size, ObjectHandleOnStack module);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetManifestModuleInternal(QCallAssembly assembly, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetModulesInternal(QCallAssembly assembly, ObjectHandleOnStack res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint InternalGetReferencedAssemblies(Assembly assembly);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern bool InternalTryGetRawMetadata(QCallAssembly assembly, out byte* blob, out int length);

	internal string GetSimpleName()
	{
		return GetName().Name;
	}
}
