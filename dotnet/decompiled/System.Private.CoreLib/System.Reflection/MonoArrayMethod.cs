using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class MonoArrayMethod : MethodInfo
{
	internal RuntimeMethodHandle mhandle;

	internal Type parent;

	internal Type ret;

	internal Type[] parameters;

	internal string name;

	internal int table_idx;

	internal CallingConventions call_conv;

	public override Type ReturnType => ret;

	public override ICustomAttributeProvider ReturnTypeCustomAttributes => null;

	public override RuntimeMethodHandle MethodHandle => mhandle;

	public override MethodAttributes Attributes => MethodAttributes.PrivateScope;

	public override Type ReflectedType => parent;

	public override Type DeclaringType => parent;

	public override string Name => name;

	internal MonoArrayMethod(Type arrayClass, string methodName, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
	{
		name = methodName;
		parent = arrayClass;
		ret = returnType;
		parameters = (Type[])parameterTypes.Clone();
		call_conv = callingConvention;
	}

	public override MethodInfo GetBaseDefinition()
	{
		return this;
	}

	public override MethodImplAttributes GetMethodImplementationFlags()
	{
		return MethodImplAttributes.IL;
	}

	public override ParameterInfo[] GetParameters()
	{
		return GetParametersInternal();
	}

	internal override ParameterInfo[] GetParametersInternal()
	{
		return Array.Empty<ParameterInfo>();
	}

	internal override int GetParametersCount()
	{
		return 0;
	}

	public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		throw new NotImplementedException();
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

	public override string ToString()
	{
		string text = string.Empty;
		ParameterInfo[] array = GetParameters();
		for (int i = 0; i < array.Length; i++)
		{
			if (i > 0)
			{
				text += ", ";
			}
			text += array[i].ParameterType.Name;
		}
		if (ReturnType != null)
		{
			return ReturnType.Name + " " + Name + "(" + text + ")";
		}
		return "void " + Name + "(" + text + ")";
	}
}
