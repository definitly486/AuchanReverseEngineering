using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeEventInfo : EventInfo
{
	private nint klass;

	private nint handle;

	public override Module Module => GetRuntimeModule();

	internal BindingFlags BindingFlags => GetBindingFlags();

	public override bool IsCollectible => false;

	public override EventAttributes Attributes => GetEventInfo(this).attrs;

	public override Type DeclaringType => GetEventInfo(this).declaring_type;

	public override Type ReflectedType => GetEventInfo(this).reflected_type;

	public override string Name => GetEventInfo(this).name;

	public override int MetadataToken => get_metadata_token(this);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_event_info(RuntimeEventInfo ev, out MonoEventInfo info);

	internal static MonoEventInfo GetEventInfo(RuntimeEventInfo ev)
	{
		get_event_info(ev, out var info);
		return info;
	}

	internal RuntimeType GetDeclaringTypeInternal()
	{
		return (RuntimeType)DeclaringType;
	}

	internal RuntimeModule GetRuntimeModule()
	{
		return GetDeclaringTypeInternal().GetRuntimeModule();
	}

	internal BindingFlags GetBindingFlags()
	{
		MonoEventInfo eventInfo = GetEventInfo(this);
		MethodInfo methodInfo = eventInfo.add_method ?? eventInfo.remove_method ?? eventInfo.raise_method;
		return RuntimeType.FilterPreCalculate(methodInfo != null && methodInfo.IsPublic, GetDeclaringTypeInternal() != ReflectedType, methodInfo != null && methodInfo.IsStatic);
	}

	public override MethodInfo GetAddMethod(bool nonPublic)
	{
		MonoEventInfo eventInfo = GetEventInfo(this);
		if (nonPublic || (eventInfo.add_method != null && eventInfo.add_method.IsPublic))
		{
			return eventInfo.add_method;
		}
		return null;
	}

	public override MethodInfo GetRaiseMethod(bool nonPublic)
	{
		MonoEventInfo eventInfo = GetEventInfo(this);
		if (nonPublic || (eventInfo.raise_method != null && eventInfo.raise_method.IsPublic))
		{
			return eventInfo.raise_method;
		}
		return null;
	}

	public override MethodInfo GetRemoveMethod(bool nonPublic)
	{
		MonoEventInfo eventInfo = GetEventInfo(this);
		if (nonPublic || (eventInfo.remove_method != null && eventInfo.remove_method.IsPublic))
		{
			return eventInfo.remove_method;
		}
		return null;
	}

	public override MethodInfo[] GetOtherMethods(bool nonPublic)
	{
		MonoEventInfo eventInfo = GetEventInfo(this);
		if (nonPublic)
		{
			return eventInfo.other_methods;
		}
		int num = 0;
		MethodInfo[] other_methods = eventInfo.other_methods;
		for (int i = 0; i < other_methods.Length; i++)
		{
			if (other_methods[i].IsPublic)
			{
				num++;
			}
		}
		if (num == eventInfo.other_methods.Length)
		{
			return eventInfo.other_methods;
		}
		MethodInfo[] array = new MethodInfo[num];
		num = 0;
		other_methods = eventInfo.other_methods;
		foreach (MethodInfo methodInfo in other_methods)
		{
			if (methodInfo.IsPublic)
			{
				array[num++] = methodInfo;
			}
		}
		return array;
	}

	public override string ToString()
	{
		return EventHandlerType?.ToString() + " " + Name;
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
		return RuntimeCustomAttributeData.GetCustomAttributesInternal(this);
	}

	public sealed override bool HasSameMetadataDefinitionAs(MemberInfo other)
	{
		return HasSameMetadataDefinitionAsCore<RuntimeEventInfo>(other);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int get_metadata_token(RuntimeEventInfo monoEvent);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern EventInfo internal_from_handle_type(nint event_handle, nint type_handle);

	internal static EventInfo GetEventFromHandle(RuntimeEventHandle handle, RuntimeTypeHandle reflectedType)
	{
		if (handle.Value == IntPtr.Zero)
		{
			throw new ArgumentException("Argument_InvalidHandle");
		}
		EventInfo eventInfo = internal_from_handle_type(handle.Value, reflectedType.Value);
		if (eventInfo == null)
		{
			throw new ArgumentException("Argument_FieldPropertyEventAndTypeHandleIncompatibility");
		}
		return eventInfo;
	}
}
