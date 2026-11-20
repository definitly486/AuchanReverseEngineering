using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.ComponentModel.Design.Serialization;

public sealed class InstanceDescriptor
{
	[CompilerGenerated]
	private readonly bool _003CIsComplete_003Ek__BackingField;

	public ICollection Arguments { get; }

	public MemberInfo? MemberInfo { get; }

	public InstanceDescriptor(MemberInfo? member, ICollection? arguments)
		: this(member, arguments, isComplete: true)
	{
	}

	public InstanceDescriptor(MemberInfo? member, ICollection? arguments, bool isComplete)
	{
		MemberInfo = member;
		_003CIsComplete_003Ek__BackingField = isComplete;
		if (arguments == null)
		{
			Arguments = Array.Empty<object>();
		}
		else
		{
			object[] array = new object[arguments.Count];
			arguments.CopyTo(array, 0);
			Arguments = array;
		}
		if (member is FieldInfo fieldInfo)
		{
			if (!fieldInfo.IsStatic)
			{
				throw new ArgumentException("InstanceDescriptorMustBeStatic");
			}
			if (Arguments.Count != 0)
			{
				throw new ArgumentException("InstanceDescriptorLengthMismatch");
			}
		}
		else if (member is ConstructorInfo constructorInfo)
		{
			if (constructorInfo.IsStatic)
			{
				throw new ArgumentException("InstanceDescriptorCannotBeStatic");
			}
			if (Arguments.Count != constructorInfo.GetParameters().Length)
			{
				throw new ArgumentException("InstanceDescriptorLengthMismatch");
			}
		}
		else if (member is MethodInfo methodInfo)
		{
			if (!methodInfo.IsStatic)
			{
				throw new ArgumentException("InstanceDescriptorMustBeStatic");
			}
			if (Arguments.Count != methodInfo.GetParameters().Length)
			{
				throw new ArgumentException("InstanceDescriptorLengthMismatch");
			}
		}
		else if (member is PropertyInfo propertyInfo)
		{
			if (!propertyInfo.CanRead)
			{
				throw new ArgumentException("InstanceDescriptorMustBeReadable");
			}
			MethodInfo getMethod = propertyInfo.GetGetMethod();
			if (getMethod != null && !getMethod.IsStatic)
			{
				throw new ArgumentException("InstanceDescriptorMustBeStatic");
			}
		}
	}

	public object? Invoke()
	{
		object[] array = new object[Arguments.Count];
		Arguments.CopyTo(array, 0);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] is InstanceDescriptor instanceDescriptor)
			{
				array[i] = instanceDescriptor.Invoke();
			}
		}
		if (MemberInfo is ConstructorInfo)
		{
			return ((ConstructorInfo)MemberInfo).Invoke(array);
		}
		if (MemberInfo is MethodInfo)
		{
			return ((MethodInfo)MemberInfo).Invoke(null, array);
		}
		if (MemberInfo is PropertyInfo)
		{
			return ((PropertyInfo)MemberInfo).GetValue(null, array);
		}
		if (MemberInfo is FieldInfo)
		{
			return ((FieldInfo)MemberInfo).GetValue(null);
		}
		return null;
	}
}
