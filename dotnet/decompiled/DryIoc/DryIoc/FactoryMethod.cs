using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace DryIoc;

public class FactoryMethod
{
	internal sealed class WithFactoryExpression : FactoryMethod
	{
		public override DryIoc.FastExpressionCompiler.LightExpression.Expression FactoryExpression { get; }

		internal WithFactoryExpression(MemberInfo constructorOrMethodOrMember, DryIoc.FastExpressionCompiler.LightExpression.Expression factoryExpression)
			: base(constructorOrMethodOrMember)
		{
			FactoryExpression = factoryExpression;
		}
	}

	internal sealed class WithFunc : FactoryMethod
	{
		internal override Delegate FactoryFunc { get; }

		internal WithFunc(MethodInfo invokeMethod, Delegate factoryFunc)
			: base(invokeMethod)
		{
			FactoryFunc = factoryFunc;
		}
	}

	internal sealed class WithFactoryServiceInfo : FactoryMethod
	{
		public override ServiceInfo FactoryServiceInfo { get; }

		internal WithFactoryServiceInfo(MemberInfo constructorOrMethodOrMember, ServiceInfo factoryServiceInfo)
			: base(constructorOrMethodOrMember)
		{
			FactoryServiceInfo = factoryServiceInfo;
		}
	}

	internal sealed class WithResolvedParameterExpressions : FactoryMethod
	{
		internal override DryIoc.FastExpressionCompiler.LightExpression.Expression[] ResolvedParameterExpressions { get; }

		internal WithResolvedParameterExpressions(ConstructorInfo ctor, DryIoc.FastExpressionCompiler.LightExpression.Expression[] resolvedParameterExpressions)
			: base(ctor)
		{
			ResolvedParameterExpressions = resolvedParameterExpressions;
		}
	}

	private struct CtorWithParameters
	{
		public ConstructorInfo Ctor;

		public ParameterInfo[] Params;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static FactoryMethodSelector _003C_003E9__20_0;

		public static FactoryMethodSelector _003C_003E9__20_1;

		public static FactoryMethodSelector _003C_003E9__20_2;

		public static FactoryMethodSelector _003C_003E9__20_3;

		public static Func<Func<Type, ParameterInfo[], bool>, ConstructorInfo, bool> _003C_003E9__21_0;

		public static Func<ConstructorInfo, FactoryMethod> _003C_003E9__23_1;

		public static Func<Type, ParameterInfo, bool> _003C_003E9__27_2;

		public static Func<Type, ParameterInfo[], bool> _003C_003E9__27_1;

		internal FactoryMethod _003CConstructor_003Eb__20_0(Request request)
		{
			return MostResolvableConstructor(request, BindingFlags.NonPublic);
		}

		internal FactoryMethod _003CConstructor_003Eb__20_1(Request request)
		{
			return MostResolvableConstructor(request);
		}

		internal FactoryMethod _003CConstructor_003Eb__20_2(Request request)
		{
			return Constructor(request, BindingFlags.NonPublic);
		}

		internal FactoryMethod _003CConstructor_003Eb__20_3(Request request)
		{
			return Constructor(request);
		}

		internal bool _003CMostResolvableConstructor_003Eb__21_0(Func<Type, ParameterInfo[], bool> cond, ConstructorInfo c)
		{
			return cond(c.DeclaringType, c.GetParameters());
		}

		internal FactoryMethod _003CDefaultConstructor_003Eb__23_1(ConstructorInfo ctor)
		{
			return new FactoryMethod(ctor);
		}

		internal FactoryMethod _003C_002Ecctor_003Eb__27_0(Request request)
		{
			return MostResolvableConstructor(request, BindingFlags.NonPublic, (Type implType, ParameterInfo[] ps) => ps.FindFirst(implType, (Type t, ParameterInfo p) => t == p.ParameterType) == null);
		}

		internal bool _003C_002Ecctor_003Eb__27_1(Type implType, ParameterInfo[] ps)
		{
			return ps.FindFirst(implType, (Type t, ParameterInfo p) => t == p.ParameterType) == null;
		}

		internal bool _003C_002Ecctor_003Eb__27_2(Type t, ParameterInfo p)
		{
			return t == p.ParameterType;
		}
	}

	public readonly MemberInfo ConstructorOrMethodOrMember;

	public static readonly FactoryMethodSelector ConstructorWithResolvableArgumentsIncludingNonPublicWithoutSameTypeParam = (Request request) => MostResolvableConstructor(request, BindingFlags.NonPublic, (Type implType, ParameterInfo[] ps) => ps.FindFirst(implType, (Type t, ParameterInfo p) => t == p.ParameterType) == null);

	public static readonly FactoryMethodSelector ConstructorWithResolvableArguments = Constructor(mostResolvable: true);

	public static readonly FactoryMethodSelector ConstructorWithResolvableArgumentsIncludingNonPublic = Constructor(mostResolvable: true, includeNonPublic: true);

	public virtual ServiceInfo FactoryServiceInfo => null;

	public virtual DryIoc.FastExpressionCompiler.LightExpression.Expression FactoryExpression => null;

	internal virtual Delegate FactoryFunc => null;

	internal virtual DryIoc.FastExpressionCompiler.LightExpression.Expression[] ResolvedParameterExpressions => null;

	public FactoryMethod(MemberInfo memberInfo)
	{
		ConstructorOrMethodOrMember = memberInfo;
	}

	public static FactoryMethod Of(MemberInfo ctorOrMethodOrMember, ServiceInfo factoryInfo = null)
	{
		ctorOrMethodOrMember.ThrowIfNull(Error.PassedCtorOrMemberIsNull);
		if (!(ctorOrMethodOrMember is ConstructorInfo) && !ctorOrMethodOrMember.IsStatic())
		{
			if (factoryInfo == null)
			{
				Throw.It(Error.PassedMemberIsNotStaticButInstanceFactoryIsNull, ctorOrMethodOrMember);
			}
			return new WithFactoryServiceInfo(ctorOrMethodOrMember, factoryInfo);
		}
		if (factoryInfo != null)
		{
			Throw.It(Error.PassedMemberIsStaticButInstanceFactoryIsNotNull, ctorOrMethodOrMember, factoryInfo);
		}
		return new FactoryMethod(ctorOrMethodOrMember);
	}

	public static FactoryMethod Of(MemberInfo methodOrMember, object factoryInstance)
	{
		factoryInstance.ThrowIfNull();
		methodOrMember.ThrowIfNull(Error.PassedCtorOrMemberIsNull);
		if (methodOrMember.IsStatic())
		{
			Throw.It(Error.PassedMemberIsStaticButInstanceFactoryIsNotNull, methodOrMember, factoryInstance);
		}
		return new WithFactoryExpression(methodOrMember, DryIoc.FastExpressionCompiler.LightExpression.Expression.Constant(factoryInstance));
	}

	internal static FactoryMethod OfFactory<F>(MemberInfo methodOrMember, F factory)
	{
		return new WithFactoryExpression(methodOrMember, DryIoc.FastExpressionCompiler.LightExpression.Expression.ConstantOf(factory));
	}

	public static FactoryMethod Of<TFactory>(string methodOrMemberName)
	{
		return Of(typeof(TFactory).GetAllMembers().FindFirst((MemberInfo m) => m.Name == methodOrMemberName).ThrowIfNull());
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("{").Print(ConstructorOrMethodOrMember.DeclaringType).Append('.').Append(ConstructorOrMethodOrMember);
		if (FactoryServiceInfo != null)
		{
			stringBuilder.Append(" of factory service ").Append(FactoryServiceInfo);
		}
		if (FactoryExpression != null)
		{
			stringBuilder.Append(" of factory expression ").Append(FactoryExpression);
		}
		return stringBuilder.Append('}').ToString();
	}

	public static FactoryMethodSelector Constructor(bool mostResolvable = false, bool includeNonPublic = false)
	{
		if (mostResolvable)
		{
			object obj;
			if (!includeNonPublic)
			{
				obj = _003C_003Ec._003C_003E9__20_1;
				if (obj == null)
				{
					return _003C_003Ec._003C_003E9__20_1 = (Request request) => MostResolvableConstructor(request);
				}
			}
			else
			{
				obj = (FactoryMethodSelector)((Request request) => MostResolvableConstructor(request, BindingFlags.NonPublic));
			}
			return (FactoryMethodSelector)obj;
		}
		object obj2;
		if (!includeNonPublic)
		{
			obj2 = _003C_003Ec._003C_003E9__20_3;
			if (obj2 == null)
			{
				return _003C_003Ec._003C_003E9__20_3 = (Request request) => Constructor(request);
			}
		}
		else
		{
			obj2 = (FactoryMethodSelector)((Request request) => Constructor(request, BindingFlags.NonPublic));
		}
		return (FactoryMethodSelector)obj2;
	}

	private static FactoryMethod MostResolvableConstructor(Request request, BindingFlags additionalToPublicAndInstance = BindingFlags.Default, Func<Type, ParameterInfo[], bool> condition = null)
	{
		object implementationTypeOrProviderOrPubCtorOrCtors = ((ReflectionFactory)request.Factory)._implementationTypeOrProviderOrPubCtorOrCtors;
		ConstructorInfo[] array = null;
		if (implementationTypeOrProviderOrPubCtorOrCtors is ConstructorInfo constructorInfo)
		{
			if (additionalToPublicAndInstance == BindingFlags.Default)
			{
				if (condition != null && !condition(constructorInfo.DeclaringType, constructorInfo.GetParameters()))
				{
					return null;
				}
				return new FactoryMethod(constructorInfo);
			}
			array = constructorInfo.DeclaringType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | additionalToPublicAndInstance);
		}
		else if (implementationTypeOrProviderOrPubCtorOrCtors is ConstructorInfo[] array2)
		{
			array = array2;
		}
		else if (implementationTypeOrProviderOrPubCtorOrCtors is Type type)
		{
			array = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | additionalToPublicAndInstance);
		}
		else
		{
			Throw.It(Error.ImplTypeIsNotSpecifiedForAutoCtorSelection, request);
		}
		if (array.Length != 0 && condition != null)
		{
			array = array.Match(condition, (Func<Type, ParameterInfo[], bool> cond, ConstructorInfo c) => cond(c.DeclaringType, c.GetParameters()));
		}
		if (array.Length == 0)
		{
			return null;
		}
		ConstructorInfo constructorInfo2 = array[0];
		if (array.Length == 1)
		{
			return new FactoryMethod(constructorInfo2);
		}
		Func<ParameterInfo, ParameterServiceInfo> func = request.Rules.TryGetParameterSelector(request.Made)(request);
		bool flag = request.IfUnresolved != IfUnresolved.ReturnDefault;
		if (flag)
		{
			request = request.WithIfUnresolved(IfUnresolved.ReturnDefault);
		}
		ParameterInfo[] parameters = constructorInfo2.GetParameters();
		ConstructorInfo constructorInfo3 = array[1];
		ParameterInfo[] parameters2 = constructorInfo3.GetParameters();
		ConstructorInfo constructorInfo4 = ((parameters.Length > parameters2.Length) ? constructorInfo2 : constructorInfo3);
		ParameterInfo[] array3 = ((constructorInfo4 == constructorInfo2) ? parameters : parameters2);
		CtorWithParameters[] array4 = null;
		int num = -1;
		int num2 = array.Length;
		if (num2 > 2)
		{
			array4 = new CtorWithParameters[num2 - 2];
			for (int num3 = 0; num3 < num2 - 2; num3++)
			{
				ConstructorInfo constructorInfo5 = array[num3 + 2];
				ParameterInfo[] parameters3 = constructorInfo5.GetParameters();
				if (parameters3.Length > array3.Length)
				{
					constructorInfo4 = constructorInfo5;
					array3 = parameters3;
					num = num3;
				}
				array4[num3].Ctor = constructorInfo5;
				array4[num3].Params = parameters3;
			}
			if (constructorInfo4 == constructorInfo2)
			{
				constructorInfo2 = null;
			}
			else if (constructorInfo4 == constructorInfo3)
			{
				constructorInfo3 = null;
			}
			else
			{
				array4[num].Ctor = null;
			}
		}
		int num4 = -1;
		ConstructorInfo constructorInfo6 = null;
		DryIoc.FastExpressionCompiler.LightExpression.Expression[] array5 = null;
		for (int num5 = 0; num5 < num2; num5++)
		{
			if (num5 > 0)
			{
				if (num2 == 2)
				{
					constructorInfo4 = ((constructorInfo4 == constructorInfo2) ? constructorInfo3 : constructorInfo2);
					array3 = ((constructorInfo4 == constructorInfo2) ? parameters : parameters2);
				}
				else
				{
					constructorInfo4 = null;
					if (constructorInfo2 != null)
					{
						constructorInfo4 = constructorInfo2;
						array3 = parameters;
					}
					if (constructorInfo3 != null && (constructorInfo2 == null || parameters2.Length > parameters.Length))
					{
						constructorInfo4 = constructorInfo3;
						array3 = parameters2;
					}
					num = -1;
					for (int num6 = 0; num6 < array4.Length; num6++)
					{
						if (array4[num6].Ctor != null && (constructorInfo4 == null || array4[num6].Params.Length > array3.Length))
						{
							constructorInfo4 = array4[num6].Ctor;
							array3 = array4[num6].Params;
							num = num6;
						}
					}
					if (constructorInfo4 == constructorInfo2)
					{
						constructorInfo2 = null;
					}
					else if (constructorInfo4 == constructorInfo3)
					{
						constructorInfo3 = null;
					}
					else
					{
						array4[num].Ctor = null;
					}
				}
			}
			if (array3.Length == 0)
			{
				constructorInfo6 = constructorInfo6 ?? constructorInfo4;
				break;
			}
			if (array5 != null && array5.Length > array3.Length)
			{
				break;
			}
			int num7 = 0;
			DryIoc.FastExpressionCompiler.LightExpression.Expression[] inputArgExprs = request.InputArgExprs;
			int argsUsedMask = 0;
			DryIoc.FastExpressionCompiler.LightExpression.Expression[] array6 = new DryIoc.FastExpressionCompiler.LightExpression.Expression[array3.Length];
			for (int num8 = 0; num8 < array3.Length; num8++)
			{
				ParameterInfo parameterInfo = array3[num8];
				if (inputArgExprs != null)
				{
					DryIoc.FastExpressionCompiler.LightExpression.Expression expression = ReflectionFactory.TryGetExpressionFromInputArgs(parameterInfo.ParameterType, inputArgExprs, ref argsUsedMask);
					if (expression != null)
					{
						num7++;
						array6[num8] = expression;
						continue;
					}
				}
				ParameterServiceInfo parameterServiceInfo = func(parameterInfo) ?? ParameterServiceInfo.Of(parameterInfo);
				Request request2 = request.Push(parameterServiceInfo);
				ServiceDetails details = parameterServiceInfo.Details;
				DryIoc.FastExpressionCompiler.LightExpression.Expression expression2 = ReflectionFactory.TryGetUsedInstanceOrCustomValueExpression(request, request2, details);
				if (expression2 != null)
				{
					num7++;
					array6[num8] = expression2;
					continue;
				}
				DryIoc.FastExpressionCompiler.LightExpression.Expression expression3 = request.Container.ResolveFactory(request2)?.GetExpressionOrDefault(request2);
				if (expression3 == null || (details.DefaultValue != null && expression3.NodeType == ExpressionType.NewArrayInit && ((DryIoc.FastExpressionCompiler.LightExpression.NewArrayExpression)expression3).ArgumentCount == 0))
				{
					if (details.IfUnresolved == IfUnresolved.Throw)
					{
						array6 = null;
						break;
					}
					expression3 = ((details.DefaultValue != null) ? request.Container.GetConstantExpression(details.DefaultValue, request2.ServiceType) : request2.ServiceType.GetDefaultValueExpression());
				}
				array6[num8] = expression3;
			}
			if (array6 != null && num7 > num4)
			{
				num4 = num7;
				constructorInfo6 = constructorInfo4;
				array5 = array6;
			}
		}
		if (constructorInfo6 == null)
		{
			return Throw.For<FactoryMethod>(flag, Error.UnableToFindCtorWithAllResolvableArgs, request.InputArgExprs, request);
		}
		return new WithResolvedParameterExpressions(constructorInfo6, array5);
	}

	private static FactoryMethod Constructor(Request request, BindingFlags additionalToPublicAndInstance = BindingFlags.Default)
	{
		object implementationTypeOrProviderOrPubCtorOrCtors = ((ReflectionFactory)request.Factory)._implementationTypeOrProviderOrPubCtorOrCtors;
		ConstructorInfo[] array = null;
		if (implementationTypeOrProviderOrPubCtorOrCtors is ConstructorInfo constructorInfo)
		{
			if (additionalToPublicAndInstance == BindingFlags.Default)
			{
				return new FactoryMethod(constructorInfo);
			}
			array = constructorInfo.DeclaringType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | additionalToPublicAndInstance);
		}
		else if (implementationTypeOrProviderOrPubCtorOrCtors is ConstructorInfo[] array2)
		{
			array = array2;
		}
		else if (implementationTypeOrProviderOrPubCtorOrCtors is Type type)
		{
			array = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | additionalToPublicAndInstance);
		}
		else
		{
			Throw.It(Error.ImplTypeIsNotSpecifiedForAutoCtorSelection, request);
		}
		if (array.Length != 1)
		{
			return null;
		}
		return new FactoryMethod(array[0]);
	}

	public static FactoryMethodSelector DefaultConstructor(bool includeNonPublic = false)
	{
		return (Request request) => request.ImplementationType.ThrowIfNull(Error.ImplTypeIsNotSpecifiedForAutoCtorSelection, request).GetConstructorOrNull(includeNonPublic, ArrayTools.Empty<Type>())?.To((ConstructorInfo ctor) => new FactoryMethod(ctor));
	}
}
