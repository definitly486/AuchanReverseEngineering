using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeAssemblyBuilder : AssemblyBuilder
{
	internal nint _mono_assembly;

	private LoaderAllocator m_keepalive;

	private nuint dynamic_assembly;

	private RuntimeModuleBuilder[] modules;

	private string name;

	private CustomAttributeBuilder[] cattrs;

	private string version;

	private string culture;

	private byte[] public_key_token;

	private Module[] loaded_modules;

	private uint access;

	private AssemblyName aname;

	private RuntimeModuleBuilder manifest_module;

	private bool manifest_module_used;

	public override bool ReflectionOnly => base.ReflectionOnly;

	public override bool IsCollectible => access == 9;

	public override Module ManifestModule => manifest_module;

	public override string FullName => aname.ToString();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void basic_init(RuntimeAssemblyBuilder ab);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void UpdateNativeCustomAttributes(RuntimeAssemblyBuilder ab);

	internal RuntimeAssemblyBuilder(AssemblyName n, AssemblyBuilderAccess access)
	{
		AssemblyBuilder.EnsureDynamicCodeSupported();
		aname = (AssemblyName)n.Clone();
		if (!Enum.IsDefined(typeof(AssemblyBuilderAccess), access))
		{
			throw new ArgumentException(SR.Format(CultureInfo.InvariantCulture, "Arg_EnumIllegalVal", (int)access), "access");
		}
		name = n.Name;
		this.access = (uint)access;
		if (n.CultureInfo != null)
		{
			culture = n.CultureInfo.Name;
		}
		Version version = n.Version;
		if (version != null)
		{
			this.version = version.ToString();
		}
		public_key_token = n.GetPublicKeyToken();
		basic_init(this);
		manifest_module = new RuntimeModuleBuilder(this, "RefEmit_InMemoryManifestModule");
		modules = new RuntimeModuleBuilder[1] { manifest_module };
		AssemblyLoadContext.InvokeAssemblyLoadEvent(this);
	}

	protected override ModuleBuilder DefineDynamicModuleCore(string name)
	{
		if (name[0] == '\0')
		{
			throw new ArgumentException("Argument_InvalidName", "name");
		}
		if (manifest_module_used)
		{
			throw new InvalidOperationException("InvalidOperation_NoMultiModuleAssembly");
		}
		manifest_module_used = true;
		return manifest_module;
	}

	internal static AssemblyBuilder InternalDefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access, AssemblyLoadContext _, IEnumerable<CustomAttributeBuilder> assemblyAttributes)
	{
		return AssemblyBuilder.DefineDynamicAssembly(name, access, assemblyAttributes);
	}

	protected override ModuleBuilder GetDynamicModuleCore(string name)
	{
		if (modules != null)
		{
			for (int i = 0; i < modules.Length; i++)
			{
				if (modules[i].name == name)
				{
					return modules[i];
				}
			}
		}
		return null;
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		CustomAttributeBuilder customAttributeBuilder = new CustomAttributeBuilder(con, binaryAttribute);
		if (cattrs != null)
		{
			CustomAttributeBuilder[] array = new CustomAttributeBuilder[cattrs.Length + 1];
			cattrs.CopyTo(array, 0);
			array[cattrs.Length] = customAttributeBuilder;
			cattrs = array;
		}
		else
		{
			cattrs = new CustomAttributeBuilder[1];
			cattrs[0] = customAttributeBuilder;
		}
		UpdateNativeCustomAttributes(this);
	}

	internal static Type MakeGenericType(Type gtd, Type[] typeArguments)
	{
		return new TypeBuilderInstantiation(gtd, typeArguments);
	}

	[RequiresUnreferencedCode("Types might be removed by trimming. If the type name is a string literal, consider using Type.GetType instead.")]
	public override Type GetType(string name, bool throwOnError, bool ignoreCase)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		Type type = InternalGetType(null, name, throwOnError, ignoreCase);
		if (type is TypeBuilder)
		{
			if (throwOnError)
			{
				throw new TypeLoadException(SR.Format("ClassLoad_General", name, this.name));
			}
			return null;
		}
		return type;
	}

	public override Module GetModule(string name)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, "name");
		if (modules == null)
		{
			return null;
		}
		RuntimeModuleBuilder[] array = modules;
		foreach (Module module in array)
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
		if (modules == null)
		{
			return Array.Empty<Module>();
		}
		return (Module[])modules.Clone();
	}

	public override AssemblyName GetName(bool copiedName)
	{
		return AssemblyName.Create(_mono_assembly, null);
	}

	[RequiresUnreferencedCode("Assembly references might be removed")]
	public override AssemblyName[] GetReferencedAssemblies()
	{
		return RuntimeAssembly.GetReferencedAssemblies(this);
	}

	public override Module[] GetLoadedModules(bool getResourceModules)
	{
		return GetModules(getResourceModules);
	}

	public override Assembly GetSatelliteAssembly(CultureInfo culture)
	{
		return GetSatelliteAssembly(culture, null);
	}

	public override Assembly GetSatelliteAssembly(CultureInfo culture, Version version)
	{
		return RuntimeAssembly.InternalGetSatelliteAssembly(this, culture, version, throwOnFileNotFound: true);
	}

	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(this, attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, attributeType, inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return CustomAttribute.GetCustomAttributesData(this);
	}
}
