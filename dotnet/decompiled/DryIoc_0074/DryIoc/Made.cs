using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DryIoc.ImTools;

namespace DryIoc;

public class Made
{
	internal class WithFactoryMethodKnownResultType : Made
	{
		public override Type FactoryMethodKnownResultType { get; }

		internal WithFactoryMethodKnownResultType(object factoryMethodOrSelector, Type factoryReturnType)
			: base(factoryMethodOrSelector)
		{
			FactoryMethodKnownResultType = factoryReturnType;
		}

		internal WithFactoryMethodKnownResultType(FactoryMethod factoryMethod, Type factoryReturnType)
			: base(factoryMethod)
		{
			FactoryMethodKnownResultType = factoryReturnType;
		}
	}

	internal sealed class WithDetails : WithFactoryMethodKnownResultType
	{
		public override ParameterSelector Parameters { get; }

		public override PropertiesAndFieldsSelector PropertiesAndFields { get; }

		internal override MadeDetails _details { get; }

		public WithDetails(object factoryMethodOrSelector, Type factoryMethodKnownResultType, ParameterSelector parameters, PropertiesAndFieldsSelector propertiesAndFields, MadeDetails details)
			: base(factoryMethodOrSelector, factoryMethodKnownResultType)
		{
			_details = details;
			Parameters = parameters;
			PropertiesAndFields = propertiesAndFields;
		}

		internal WithDetails(object factoryMethodOrSelector, Type factoryMethodKnownResultType = null, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null, bool hasCustomValue = false, bool isConditionalImplementation = false, bool implMemberDependsOnRequest = false)
			: base(factoryMethodOrSelector, factoryMethodKnownResultType)
		{
			MadeDetails madeDetails = MadeDetails.NoConditionals;
			if (parameters != null || propertiesAndFields != null)
			{
				madeDetails |= MadeDetails.ImplMemberDependsOnRequest;
			}
			if (hasCustomValue)
			{
				madeDetails |= MadeDetails.HasCustomDependencyValue;
			}
			if (isConditionalImplementation)
			{
				madeDetails |= MadeDetails.ImplTypeDependsOnRequest;
			}
			if (implMemberDependsOnRequest)
			{
				madeDetails |= MadeDetails.ImplMemberDependsOnRequest;
			}
			_details = madeDetails;
			Parameters = parameters;
			PropertiesAndFields = propertiesAndFields;
		}
	}

	[Flags]
	internal enum MadeDetails : byte
	{
		NoConditionals = 0,
		ImplTypeDependsOnRequest = 2,
		ImplMemberDependsOnRequest = 8,
		HasCustomDependencyValue = 0x10
	}

	public class TypedMade<TService> : Made
	{
		public override Type FactoryMethodKnownResultType => typeof(TService);

		internal TypedMade(FactoryMethodSelector factoryMethodSelector)
			: base(factoryMethodSelector)
		{
		}
	}

	internal sealed class WithDetails<TService> : TypedMade<TService>
	{
		public override ParameterSelector Parameters { get; }

		public override PropertiesAndFieldsSelector PropertiesAndFields { get; }

		internal override MadeDetails _details { get; }

		public WithDetails(FactoryMethodSelector factoryMethod, ParameterSelector parameters, PropertiesAndFieldsSelector propertiesAndFields, bool hasCustomValue)
			: base(factoryMethod)
		{
			MadeDetails madeDetails = MadeDetails.NoConditionals;
			if (parameters != null || propertiesAndFields != null)
			{
				madeDetails |= MadeDetails.ImplMemberDependsOnRequest;
			}
			if (hasCustomValue)
			{
				madeDetails |= MadeDetails.HasCustomDependencyValue;
			}
			_details = madeDetails;
			Parameters = parameters;
			PropertiesAndFields = propertiesAndFields;
		}
	}

	public static readonly Made Default = new Made(null);

	public object FactoryMethodOrSelector { get; internal set; }

	public virtual Type FactoryMethodKnownResultType => null;

	public virtual ParameterSelector Parameters => null;

	public virtual PropertiesAndFieldsSelector PropertiesAndFields => null;

	internal virtual MadeDetails _details => MadeDetails.NoConditionals;

	public bool IsConditional => _details != MadeDetails.NoConditionals;

	public bool HasCustomDependencyValue => (_details & MadeDetails.HasCustomDependencyValue) != 0;

	public bool IsConditionalImplementation => (_details & MadeDetails.ImplTypeDependsOnRequest) != 0;

	public bool IsImplMemberDependsOnRequest => (_details & MadeDetails.ImplMemberDependsOnRequest) != 0;

	public override string ToString()
	{
		if (this == Default)
		{
			return "Made.Default";
		}
		string text = "{";
		if (FactoryMethodOrSelector != null)
		{
			text = text + ((text == "{") ? "" : ", ") + "FactoryMethod=";
			text = ((FactoryMethodOrSelector == FactoryMethod.ConstructorWithResolvableArguments) ? (text + "ConstructorWithResolvableArguments") : ((FactoryMethodOrSelector != FactoryMethod.ConstructorWithResolvableArgumentsIncludingNonPublic) ? (text + "<custom>") : (text + "ConstructorWithResolvableArgumentsIncludingNonPublic")));
		}
		if (FactoryMethodKnownResultType != null)
		{
			text = text + ((text == "{") ? "" : ", ") + "FactoryMethodKnownResultType=" + FactoryMethodKnownResultType;
		}
		if (HasCustomDependencyValue)
		{
			text = text + ((text == "{") ? "" : ", ") + "HasCustomDependencyValue=true";
		}
		if (PropertiesAndFields != null)
		{
			text = text + ((text == "{") ? "" : ", ") + "PropertiesAndFields=<custom>";
		}
		if (Parameters != null)
		{
			text = text + ((text == "{") ? "" : ", ") + "ParameterSelector=<custom>";
		}
		return text + "}";
	}

	public static implicit operator Made(FactoryMethodSelector factoryMethod)
	{
		return new Made(factoryMethod);
	}

	public static implicit operator Made(ParameterSelector parameters)
	{
		return new WithDetails(null, null, parameters);
	}

	public static implicit operator Made(PropertiesAndFieldsSelector propertiesAndFields)
	{
		return new WithDetails(null, null, null, propertiesAndFields);
	}

	public static Made Of(FactoryMethodSelector factoryMethodSelector = null, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null, bool isConditionalImplementation = false)
	{
		return Create(factoryMethodSelector, parameters, propertiesAndFields, isConditionalImplementation);
	}

	internal static Made Create(object factoryMethodOrSelector, ParameterSelector parameters, PropertiesAndFieldsSelector propertiesAndFields, bool isConditionalImplementation)
	{
		bool flag = parameters != null || propertiesAndFields != null || isConditionalImplementation;
		if (factoryMethodOrSelector != null || flag)
		{
			if (flag)
			{
				return new WithDetails(factoryMethodOrSelector, null, parameters, propertiesAndFields, hasCustomValue: false, isConditionalImplementation);
			}
			return new Made(factoryMethodOrSelector);
		}
		return Default;
	}

	public static Made Of(FactoryMethod factoryMethod, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null)
	{
		Type type = factoryMethod.ThrowIfNull().ConstructorOrMethodOrMember.GetReturnTypeOrDefault();
		if (type != null && type.IsOpenGeneric())
		{
			type = type.GetGenericTypeDefinition();
		}
		if (parameters != null || propertiesAndFields != null)
		{
			return new WithDetails(factoryMethod, type, parameters, propertiesAndFields);
		}
		return new WithFactoryMethodKnownResultType(factoryMethod, type);
	}

	public static Made Of(MemberInfo factoryMethodOrMember, ServiceInfo factoryInfo = null, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null)
	{
		return Of(FactoryMethod.Of(factoryMethodOrMember, factoryInfo), parameters, propertiesAndFields);
	}

	public static Made Of(Func<Request, Type> getImplType, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null)
	{
		return Of((Request r) => FactoryMethod.Of(getImplType(r).SingleConstructor()), parameters, propertiesAndFields, isConditionalImplementation: true);
	}

	public static Made Of(Func<Request, MemberInfo> getMethodOrMember, ServiceInfo factoryInfo = null, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null)
	{
		return new WithDetails((FactoryMethodSelector)((Request r) => FactoryMethod.Of(getMethodOrMember(r), factoryInfo)), null, parameters, propertiesAndFields, hasCustomValue: false, isConditionalImplementation: false, implMemberDependsOnRequest: true);
	}

	public static Made Of(Func<Request, MemberInfo> getMethodOrMember, Func<Request, ServiceInfo> factoryInfo, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null)
	{
		return new WithDetails((FactoryMethodSelector)((Request r) => FactoryMethod.Of(getMethodOrMember(r), factoryInfo(r))), null, parameters, propertiesAndFields, hasCustomValue: false, isConditionalImplementation: false, implMemberDependsOnRequest: true);
	}

	public static Made Of(Func<Type, ConstructorInfo> getConstructor, ParameterSelector parameters = null, PropertiesAndFieldsSelector propertiesAndFields = null)
	{
		return Create((FactoryMethodSelector)((Request r) => FactoryMethod.Of(getConstructor(r.ImplementationType).ThrowIfNull(Error.GotNullConstructorFromFactoryMethod, r))), parameters, propertiesAndFields, isConditionalImplementation: false);
	}

	public static TypedMade<TService> Of<TService>(Expression<Func<TService>> serviceReturningExpr, params Func<Request, object>[] argValues)
	{
		return FromExpression<object, TService>((MemberInfo member) => (Request _) => FactoryMethod.Of(member), null, serviceReturningExpr, argValues);
	}

	public static TypedMade<TService> Of<TFactory, TService>(Func<Request, ServiceInfo.Typed<TFactory>> getFactoryInfo, Expression<Func<TFactory, TService>> serviceReturningExpr, params Func<Request, object>[] argValues) where TFactory : class
	{
		return FromExpression<TFactory, TService>(null, getFactoryInfo.ThrowIfNull(), serviceReturningExpr, argValues);
	}

	public static TypedMade<TService> Of<TFactory, TService>(TFactory factoryInstance, Expression<Func<TFactory, TService>> serviceReturningExpr, params Func<Request, object>[] argValues) where TFactory : class
	{
		factoryInstance.ThrowIfNull();
		return FromExpression<TFactory, TService>((MemberInfo member) => (Request request) => FactoryMethod.Of(member, factoryInstance), null, serviceReturningExpr, argValues);
	}

	private static TypedMade<TService> FromExpression<TFactory, TService>(Func<MemberInfo, FactoryMethodSelector> eitherGetFactoryMethodSelector, Func<Request, ServiceInfo.Typed<TFactory>> orGetFactoryInfo, LambdaExpression serviceReturningExpr, params Func<Request, object>[] argValues)
	{
		Expression body = serviceReturningExpr.ThrowIfNull().Body;
		if (body.NodeType == ExpressionType.Convert)
		{
			return FromExpression<TFactory, TService>(eitherGetFactoryMethodSelector, orGetFactoryInfo, Expression.Lambda(((UnaryExpression)body).Operand, ArrayTools.Empty<ParameterExpression>()), argValues);
		}
		IList<Expression> argExprs = null;
		IList<MemberBinding> list = null;
		ParameterInfo[] array = null;
		MemberInfo ctorOrMethodOrMember;
		if (body.NodeType == ExpressionType.New || body.NodeType == ExpressionType.MemberInit)
		{
			NewExpression newExpression = (body as NewExpression) ?? ((MemberInitExpression)body).NewExpression;
			ctorOrMethodOrMember = newExpression.Constructor;
			array = newExpression.Constructor.GetParameters();
			argExprs = newExpression.Arguments;
			if (body is MemberInitExpression)
			{
				list = ((MemberInitExpression)body).Bindings;
			}
		}
		else if (body.NodeType == ExpressionType.Call)
		{
			MethodCallExpression methodCallExpression = (MethodCallExpression)body;
			ctorOrMethodOrMember = methodCallExpression.Method;
			array = methodCallExpression.Method.GetParameters();
			argExprs = methodCallExpression.Arguments;
		}
		else if (body.NodeType == ExpressionType.Invoke)
		{
			InvocationExpression invocationExpression = (InvocationExpression)body;
			Expression expression = invocationExpression.Expression;
			array = ((MethodBase)(ctorOrMethodOrMember = expression.Type.GetMethod("Invoke"))).GetParameters();
			argExprs = invocationExpression.Arguments;
		}
		else
		{
			if (body.NodeType != ExpressionType.MemberAccess)
			{
				return Throw.For<TypedMade<TService>>(Error.NotSupportedMadeOfExpression, body);
			}
			MemberInfo member = ((MemberExpression)body).Member;
			Throw.If(!(member is PropertyInfo) && !(member is FieldInfo), Error.UnexpectedFactoryMemberExpressionInMadeOf, member, serviceReturningExpr);
			ctorOrMethodOrMember = member;
		}
		bool hasCustomValue = false;
		bool hasUsedFactoryInfoForParameter = false;
		ParameterSelector parameterSelector = (array.IsNullOrEmpty() ? null : ComposeParameterSelectorFromArgs(ref hasCustomValue, ref hasUsedFactoryInfoForParameter, orGetFactoryInfo, serviceReturningExpr, array, argExprs, argValues));
		PropertiesAndFieldsSelector propertiesAndFieldsSelector = ((list == null || list.Count == 0) ? null : ComposePropertiesAndFieldsSelector(ref hasCustomValue, serviceReturningExpr, list, argValues));
		FactoryMethodSelector factoryMethodSelector = ((eitherGetFactoryMethodSelector != null) ? eitherGetFactoryMethodSelector(ctorOrMethodOrMember) : (hasUsedFactoryInfoForParameter ? ((FactoryMethodSelector)((Request _) => FactoryMethod.Of(ctorOrMethodOrMember))) : ((FactoryMethodSelector)((Request r) => FactoryMethod.Of(ctorOrMethodOrMember, orGetFactoryInfo(r))))));
		if (!hasCustomValue && parameterSelector == null && propertiesAndFieldsSelector == null)
		{
			return new TypedMade<TService>(factoryMethodSelector);
		}
		return new WithDetails<TService>(factoryMethodSelector, parameterSelector, propertiesAndFieldsSelector, hasCustomValue);
	}

	internal Made(object factoryMethodOrSelector = null)
	{
		FactoryMethodOrSelector = factoryMethodOrSelector;
	}

	internal Made(FactoryMethod factoryMethod)
	{
		FactoryMethodOrSelector = factoryMethod;
	}

	internal Made Clone()
	{
		Type factoryMethodKnownResultType = FactoryMethodKnownResultType;
		if (_details != MadeDetails.NoConditionals)
		{
			return new WithDetails(FactoryMethodOrSelector, factoryMethodKnownResultType, Parameters, PropertiesAndFields, _details);
		}
		if (!(factoryMethodKnownResultType == null))
		{
			return new WithFactoryMethodKnownResultType(FactoryMethodOrSelector, factoryMethodKnownResultType);
		}
		return new Made(FactoryMethodOrSelector);
	}

	private static ParameterSelector ComposeParameterSelectorFromArgs<TFactory>(ref bool hasCustomValue, ref bool hasUsedFactoryInfoForParameter, Func<Request, ServiceInfo.Typed<TFactory>> nullOrGetFactoryInfo, Expression wholeServiceExpr, ParameterInfo[] paramInfos, IList<Expression> argExprs, params Func<Request, object>[] argValues)
	{
		ParameterSelector parameterSelector = DryIoc.Parameters.Of;
		for (int i = 0; i < argExprs.Count; i++)
		{
			ParameterInfo paramInfo = paramInfos[i];
			Expression expression = argExprs[i];
			if (expression is ParameterExpression parameterExpression)
			{
				if (nullOrGetFactoryInfo != null && typeof(TFactory).IsAssignableTo(parameterExpression.Type))
				{
					hasUsedFactoryInfoForParameter = true;
					parameterSelector = parameterSelector.OverrideWith((Request req) => (ParameterInfo p) => (!p.Equals(paramInfo)) ? null : nullOrGetFactoryInfo(req)?.Details?.To(ParameterServiceInfo.Of(p).WithDetails));
				}
				else
				{
					Throw.It(Error.MadeOfCallExpressionParameterDoesNotCorrespondToTheFactoryInfo, parameterExpression, typeof(TFactory));
				}
			}
			else if (expression is MethodCallExpression methodCallExpression)
			{
				if (methodCallExpression.Method.DeclaringType != typeof(Arg))
				{
					Throw.It(Error.UnexpectedExpressionInsteadOfArgMethodInMadeOf, methodCallExpression, wholeServiceExpr);
				}
				if (methodCallExpression.Method.Name == Arg.ArgIndexMethodName)
				{
					Func<Request, object> getArgValue = GetArgCustomValueProvider(wholeServiceExpr, methodCallExpression, argValues);
					parameterSelector = parameterSelector.Details((Request r, ParameterInfo p) => (!p.Equals(paramInfo)) ? null : ServiceDetails.Of(getArgValue(r)));
					hasCustomValue = true;
				}
				else
				{
					object defaultValue = (paramInfo.IsOptional ? paramInfo.DefaultValue : null);
					ServiceDetails argDetails = GetArgServiceDetails(wholeServiceExpr, methodCallExpression, paramInfo.ParameterType, IfUnresolved.Throw, defaultValue);
					parameterSelector = parameterSelector.Details((Request r, ParameterInfo p) => (!p.Equals(paramInfo)) ? null : argDetails);
				}
			}
			else
			{
				object customValue = GetArgExpressionValueOrThrow(wholeServiceExpr, argExprs[i]);
				parameterSelector = parameterSelector.Details((Request r, ParameterInfo p) => (!p.Equals(paramInfo)) ? null : ServiceDetails.Of(customValue));
			}
		}
		return parameterSelector;
	}

	private static PropertiesAndFieldsSelector ComposePropertiesAndFieldsSelector(ref bool hasCustomValue, Expression wholeServiceExpr, IList<MemberBinding> memberBindings, params Func<Request, object>[] argValues)
	{
		PropertiesAndFieldsSelector propertiesAndFieldsSelector = DryIoc.PropertiesAndFields.Of;
		for (int i = 0; i < memberBindings.Count; i++)
		{
			MemberAssignment memberAssignment = (memberBindings[i] as MemberAssignment).ThrowIfNull();
			MemberInfo member = memberAssignment.Member;
			if (!(memberAssignment.Expression is MethodCallExpression methodCallExpression))
			{
				object customValue = GetArgExpressionValueOrThrow(wholeServiceExpr, memberAssignment.Expression);
				propertiesAndFieldsSelector = propertiesAndFieldsSelector.OverrideWith((Request r) => PropertyOrFieldServiceInfo.Of(member).WithDetails(ServiceDetails.Of(customValue)).One());
				continue;
			}
			Throw.If(methodCallExpression.Method.DeclaringType != typeof(Arg), Error.UnexpectedExpressionInsteadOfArgMethodInMadeOf, methodCallExpression, wholeServiceExpr);
			if (methodCallExpression.Method.Name == Arg.ArgIndexMethodName)
			{
				Func<Request, object> getArgValue = GetArgCustomValueProvider(wholeServiceExpr, methodCallExpression, argValues);
				propertiesAndFieldsSelector = propertiesAndFieldsSelector.OverrideWith((Request req) => PropertyOrFieldServiceInfo.Of(member).WithDetails(ServiceDetails.Of(getArgValue(req))).One());
				hasCustomValue = true;
			}
			else
			{
				Type returnTypeOrDefault = member.GetReturnTypeOrDefault();
				ServiceDetails argServiceDetails = GetArgServiceDetails(wholeServiceExpr, methodCallExpression, returnTypeOrDefault, IfUnresolved.ReturnDefault, null);
				propertiesAndFieldsSelector = propertiesAndFieldsSelector.OverrideWith((Request r) => PropertyOrFieldServiceInfo.Of(member).WithDetails(argServiceDetails).One());
			}
		}
		return propertiesAndFieldsSelector;
	}

	private static Func<Request, object> GetArgCustomValueProvider(Expression wholeServiceExpr, MethodCallExpression methodCallExpr, Func<Request, object>[] argValues)
	{
		Throw.If(argValues.IsNullOrEmpty(), Error.ArgValueIndexIsProvidedButNoArgValues, wholeServiceExpr);
		int num = (int)GetArgExpressionValueOrThrow(wholeServiceExpr, methodCallExpr.Arguments[0]);
		if (num < 0 || num >= argValues.Length)
		{
			Throw.It(Error.ArgValueIndexIsOutOfProvidedArgValues, num, argValues, wholeServiceExpr);
		}
		return argValues[num];
	}

	private static ServiceDetails GetArgServiceDetails(Expression wholeServiceExpr, MethodCallExpression methodCallExpr, Type dependencyType, IfUnresolved defaultIfUnresolved, object defaultValue)
	{
		Type type = methodCallExpr.Method.GetGenericArguments().Last();
		if (type == dependencyType)
		{
			type = null;
		}
		object obj = null;
		string metadataKey = null;
		object metadata = null;
		IfUnresolved ifUnresolved = defaultIfUnresolved;
		bool flag = false;
		ReadOnlyCollection<Expression> arguments = methodCallExpr.Arguments;
		if (arguments.Count == 2 && arguments[0].Type == typeof(string) && arguments[1].Type != typeof(IfUnresolved))
		{
			metadataKey = (string)GetArgExpressionValueOrThrow(wholeServiceExpr, arguments[0]);
			metadata = GetArgExpressionValueOrThrow(wholeServiceExpr, arguments[1]);
		}
		else
		{
			for (int i = 0; i < arguments.Count; i++)
			{
				object argExpressionValueOrThrow = GetArgExpressionValueOrThrow(wholeServiceExpr, arguments[i]);
				if (argExpressionValueOrThrow == null)
				{
					continue;
				}
				if (argExpressionValueOrThrow is IfUnresolved)
				{
					ifUnresolved = (IfUnresolved)argExpressionValueOrThrow;
					if (flag)
					{
						defaultValue = obj;
						obj = null;
					}
				}
				else
				{
					obj = argExpressionValueOrThrow;
					flag = true;
				}
			}
		}
		return ServiceDetails.Of(type, obj, ifUnresolved, defaultValue, metadataKey, metadata);
	}

	private static object GetArgExpressionValueOrThrow(Expression wholeServiceExpr, Expression argExpr)
	{
		if (argExpr is ConstantExpression constantExpression)
		{
			return constantExpression.Value;
		}
		if (argExpr is UnaryExpression { NodeType: ExpressionType.Convert } unaryExpression)
		{
			return GetArgExpressionValueOrThrow(wholeServiceExpr, unaryExpression.Operand as ConstantExpression);
		}
		if (argExpr is MemberExpression { Expression: ConstantExpression expression } memberExpression && expression.Type.IsClosureType() && memberExpression.Member is FieldInfo)
		{
			return ((FieldInfo)memberExpression.Member).GetValue(expression.Value);
		}
		if (argExpr is NewArrayExpression newArrayExpression)
		{
			ReadOnlyCollection<Expression> expressions = newArrayExpression.Expressions;
			object[] array = new object[expressions.Count];
			for (int i = 0; i < expressions.Count; i++)
			{
				array[i] = GetArgExpressionValueOrThrow(wholeServiceExpr, expressions[i]);
			}
			return Converter.ConvertMany(array, newArrayExpression.Type.GetElementType());
		}
		return Throw.For<object>(Error.UnexpectedExpressionInsteadOfConstantInMadeOf, argExpr, wholeServiceExpr);
	}
}
