using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Android.Runtime;
using Java.Lang;

namespace Java.Interop;

public static class JavaObjectExtensions
{
	[return: NotNullIfNotNull("instance")]
	public static TResult? JavaCast<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] TResult>(this IJavaObject? instance) where TResult : class, IJavaObject
	{
		return instance._JavaCast<TResult>();
	}

	internal static TResult? _JavaCast<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] TResult>(this IJavaObject? instance)
	{
		if (instance == null)
		{
			return default(TResult);
		}
		if (instance is TResult)
		{
			return (TResult)instance;
		}
		if (instance.Handle == IntPtr.Zero)
		{
			throw new ObjectDisposedException(instance.GetType().FullName);
		}
		TResult val = (TResult)Java.Lang.Object.GetObject(instance.Handle, JniHandleOwnership.DoNotTransfer, typeof(TResult));
		if (val == null)
		{
			throw new InvalidCastException(FormattableString.Invariant($"Unable to convert instance of type '{instance.GetType().FullName}' to type '{typeof(TResult).FullName}'."));
		}
		return val;
	}

	internal static IJavaObject? JavaCast(IJavaObject? instance, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type resultType)
	{
		if (resultType == null)
		{
			throw new ArgumentNullException("resultType");
		}
		if (instance == null)
		{
			return null;
		}
		if (resultType.IsAssignableFrom(instance.GetType()))
		{
			return instance;
		}
		return ((IJavaObject)Java.Lang.Object.GetObject(instance.Handle, JniHandleOwnership.DoNotTransfer, resultType)) ?? throw new InvalidCastException(FormattableString.Invariant($"Unable to convert instance of type '{instance.GetType().FullName}' to type '{resultType.FullName}'."));
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	internal static Type? GetInvokerType(Type type)
	{
		Type[] genericArguments = type.GetGenericArguments();
		if (genericArguments.Length == 0)
		{
			return AssemblyGetType(type.Assembly, type?.ToString() + "Invoker");
		}
		Type genericTypeDefinition = type.GetGenericTypeDefinition();
		int num = genericTypeDefinition.FullName.IndexOf("`", StringComparison.Ordinal);
		if (num == -1)
		{
			throw new NotSupportedException("Generic type doesn't follow generic type naming convention! " + type.FullName);
		}
		Type type2 = AssemblyGetType(genericTypeDefinition.Assembly, genericTypeDefinition.FullName.Substring(0, num) + "Invoker" + genericTypeDefinition.FullName.Substring(num));
		if (type2 == null)
		{
			return null;
		}
		return MakeGenericType(type2, genericArguments);
		[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "*Invoker types are preserved by the MarkJavaObjects linker step.")]
		[UnconditionalSuppressMessage("Trimming", "IL2055", Justification = "*Invoker types are preserved by the MarkJavaObjects linker step.")]
		[UnconditionalSuppressMessage("Trimming", "IL2073", Justification = "*Invoker types are preserved by the MarkJavaObjects linker step.")]
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
		static Type? AssemblyGetType(Assembly assembly, string typeName)
		{
			return assembly.GetType(typeName);
		}
		[UnconditionalSuppressMessage("Trimming", "IL2055", Justification = "*Invoker types are preserved by the MarkJavaObjects linker step.")]
		[UnconditionalSuppressMessage("Trimming", "IL2068", Justification = "*Invoker types are preserved by the MarkJavaObjects linker step.")]
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
		static Type MakeGenericType(Type type3, params Type[] typeArguments)
		{
			return type3.MakeGenericType(typeArguments);
		}
	}
}
