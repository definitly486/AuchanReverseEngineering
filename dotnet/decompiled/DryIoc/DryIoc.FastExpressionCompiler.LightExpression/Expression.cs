using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public abstract class Expression
{
	public static readonly ConstantExpression NullConstant = new NullConstantExpression<object>();

	public static readonly ConstantExpression FalseConstant = new ValueConstantExpression<bool>(false);

	public static readonly ConstantExpression TrueConstant = new ValueConstantExpression<bool>(true);

	public static readonly ConstantExpression ZeroConstant = new IntConstantExpression(0);

	public static readonly ConstantExpression OneConstant = new IntConstantExpression(1);

	public static readonly ConstantExpression MinusOneConstant = new IntConstantExpression(-1);

	public static readonly DefaultExpression VoidDefault = new DefaultExpression(typeof(void));

	public abstract ExpressionType NodeType { get; }

	public abstract Type Type { get; }

	public virtual object Tag => null;

	public virtual bool IsIntrinsic => false;

	public virtual bool TryCollectBoundConstants(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, bool isNestedLambda, ref ExpressionCompiler.ClosureInfo rootClosure)
	{
		return false;
	}

	public virtual bool TryEmit(CompilerFlags config, ref ExpressionCompiler.ClosureInfo closure, IParameterProvider paramExprs, ILGenerator il, ExpressionCompiler.ParentFlags parent, int byRefIndex = -1)
	{
		return false;
	}

	protected internal virtual Expression VisitChildren(ExpressionVisitor visitor)
	{
		return this;
	}

	public System.Linq.Expressions.Expression ToExpression()
	{
		LiveCountArray<LightAndSysExpr> exprsConverted = new LiveCountArray<LightAndSysExpr>(Tools.Empty<LightAndSysExpr>());
		return ToExpression(ref exprsConverted);
	}

	internal System.Linq.Expressions.Expression ToExpression(ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		int num = exprsConverted.Count - 1;
		while (num != -1 && exprsConverted.Items[num].LightExpr != this)
		{
			num--;
		}
		if (num != -1)
		{
			return (System.Linq.Expressions.Expression)exprsConverted.Items[num].SysExpr;
		}
		System.Linq.Expressions.Expression expression = CreateSysExpression(ref exprsConverted);
		ref LightAndSysExpr reference = ref exprsConverted.PushSlot();
		reference.LightExpr = this;
		reference.SysExpr = expression;
		return expression;
	}

	internal abstract System.Linq.Expressions.Expression CreateSysExpression(ref LiveCountArray<LightAndSysExpr> convertedExpressions);

	public override string ToString()
	{
		return ToExpression().ToString();
	}

	public virtual Expression Reduce()
	{
		return this;
	}

	internal static System.Linq.Expressions.Expression[] ToExpressions(IReadOnlyList<Expression> exprs, ref LiveCountArray<LightAndSysExpr> exprsConverted)
	{
		if (exprs.Count == 0)
		{
			return Tools.Empty<System.Linq.Expressions.Expression>();
		}
		if (exprs.Count == 1)
		{
			return new System.Linq.Expressions.Expression[1] { exprs[0].ToExpression(ref exprsConverted) };
		}
		System.Linq.Expressions.Expression[] array = new System.Linq.Expressions.Expression[exprs.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = exprs[i].ToExpression(ref exprsConverted);
		}
		return array;
	}

	public static ParameterExpression Parameter(Type type, string name = null)
	{
		if (type.IsByRef)
		{
			return new ByRefParameterExpression(type.GetElementType(), name);
		}
		if (type == typeof(object))
		{
			return new ParameterExpression(name);
		}
		if (type == typeof(object[]))
		{
			return new TypedParameterExpression<object[]>(name);
		}
		return new TypedParameterExpression(type, name);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ParameterExpression ParameterOf<T>(string name = null)
	{
		return new TypedParameterExpression<T>(name);
	}

	public static ParameterExpression Variable(Type type, string name = null)
	{
		if (!type.IsEnum)
		{
			return TryToMakeKnownTypeParameter(type, name);
		}
		return new TypedParameterExpression(type, name);
	}

	private static ParameterExpression TryToMakeKnownTypeParameter(Type type, string name = null)
	{
		return Type.GetTypeCode(type) switch
		{
			TypeCode.Boolean => new TypedParameterExpression<bool>(name), 
			TypeCode.Byte => new TypedParameterExpression<byte>(name), 
			TypeCode.Char => new TypedParameterExpression<char>(name), 
			TypeCode.DateTime => new TypedParameterExpression<DateTime>(name), 
			TypeCode.Decimal => new TypedParameterExpression<decimal>(name), 
			TypeCode.Double => new TypedParameterExpression<double>(name), 
			TypeCode.Int16 => new TypedParameterExpression<short>(name), 
			TypeCode.Int32 => new TypedParameterExpression<int>(name), 
			TypeCode.Int64 => new TypedParameterExpression<long>(name), 
			TypeCode.SByte => new TypedParameterExpression<sbyte>(name), 
			TypeCode.Single => new TypedParameterExpression<float>(name), 
			TypeCode.String => new TypedParameterExpression<string>(name), 
			TypeCode.UInt16 => new TypedParameterExpression<ushort>(name), 
			TypeCode.UInt32 => new TypedParameterExpression<uint>(name), 
			TypeCode.UInt64 => new TypedParameterExpression<ulong>(name), 
			_ => (type == typeof(object)) ? new ParameterExpression(name) : new TypedParameterExpression(type, name), 
		};
	}

	public static ConstantExpression Constant(bool value)
	{
		if (!value)
		{
			return FalseConstant;
		}
		return TrueConstant;
	}

	public static ConstantExpression Constant(object value)
	{
		if (value == null)
		{
			return NullConstant;
		}
		if (value is bool)
		{
			if (!(bool)value)
			{
				return FalseConstant;
			}
			return TrueConstant;
		}
		if (value is int num)
		{
			return num switch
			{
				-1 => MinusOneConstant, 
				1 => OneConstant, 
				0 => ZeroConstant, 
				_ => new IntConstantExpression(num), 
			};
		}
		return new ValueConstantExpression(value);
	}

	public static ConstantExpression Constant(object value, Type type)
	{
		if (value == null)
		{
			return ConstantNull(type);
		}
		if (type == typeof(bool))
		{
			if (!(bool)value)
			{
				return FalseConstant;
			}
			return TrueConstant;
		}
		if (type == value.GetType())
		{
			return new ValueConstantExpression(value);
		}
		return new TypedValueConstantExpression(value, type);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ConstantExpression ConstantNull(Type type = null)
	{
		if (!(type == null) && !(type == typeof(object)))
		{
			return new TypedNullConstantExpression(type);
		}
		return NullConstant;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ConstantExpression ConstantNull<T>()
	{
		return new NullConstantExpression<T>();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ConstantExpression ConstantInt(int value)
	{
		return new IntConstantExpression(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ConstantExpression ConstantOf<T>(T value)
	{
		if (value != null)
		{
			return new ValueConstantExpression<T>(value);
		}
		return ConstantNull<T>();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int TryGetIntConstantValue(Expression e)
	{
		return ((IntConstantExpression)e).IntValue;
	}

	public static NewExpression New(Type type)
	{
		if (type.IsValueType)
		{
			return new NewValueTypeExpression(type);
		}
		ConstructorInfo[] constructors = type.GetConstructors();
		foreach (ConstructorInfo constructorInfo in constructors)
		{
			if (constructorInfo.GetParameters().Length == 0)
			{
				return new NoArgsNewClassIntrinsicExpression(constructorInfo);
			}
		}
		throw new ArgumentException($"The type {type} is missing the default constructor");
	}

	public static NewExpression New(ConstructorInfo ctor, IReadOnlyList<Expression> arguments)
	{
		if (arguments != null && arguments.Count != 0)
		{
			return new ManyArgumentsNewExpression(ctor, arguments);
		}
		return new NoArgsNewClassIntrinsicExpression(ctor);
	}

	public static NewExpression New(ConstructorInfo ctor, params Expression[] arguments)
	{
		return New(ctor, (IReadOnlyList<Expression>)arguments);
	}

	public static NewExpression New(ConstructorInfo ctor, IEnumerable<Expression> arguments)
	{
		return New(ctor, arguments.AsReadOnlyList());
	}

	public static NewExpression NewNoByRefArgs(ConstructorInfo ctor, IReadOnlyList<Expression> arguments)
	{
		if (arguments != null && arguments.Count != 0)
		{
			return new NoByRefManyArgumentsNewExpression(ctor, arguments);
		}
		return new NoArgsNewClassIntrinsicExpression(ctor);
	}

	public static NewExpression New(ConstructorInfo ctor)
	{
		return new NoArgsNewClassIntrinsicExpression(ctor);
	}

	public static NewExpression New(ConstructorInfo ctor, Expression arg)
	{
		return new OneArgumentNewExpression(ctor, arg);
	}

	public static NewExpression NewNoByRefArgs(ConstructorInfo ctor, Expression arg)
	{
		return new NoByRefOneArgumentNewExpression(ctor, arg);
	}

	public static NewExpression New(ConstructorInfo ctor, Expression arg0, Expression arg1)
	{
		return new TwoArgumentsNewExpression(ctor, arg0, arg1);
	}

	public static NewExpression NewNoByRefArgs(ConstructorInfo ctor, Expression arg0, Expression arg1)
	{
		return new NoByRefTwoArgumentsNewExpression(ctor, arg0, arg1);
	}

	public static NewExpression New(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2)
	{
		return new ThreeArgumentsNewExpression(ctor, arg0, arg1, arg2);
	}

	public static NewExpression NewNoByRefArgs(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2)
	{
		return new NoByRefThreeArgumentsNewExpression(ctor, arg0, arg1, arg2);
	}

	public static NewExpression New(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2, Expression arg3)
	{
		return new FourArgumentsNewExpression(ctor, arg0, arg1, arg2, arg3);
	}

	public static NewExpression NewNoByRefArgs(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2, Expression arg3)
	{
		return new NoByRefFourArgumentsNewExpression(ctor, arg0, arg1, arg2, arg3);
	}

	public static NewExpression New(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4)
	{
		return new FiveArgumentsNewExpression(ctor, arg0, arg1, arg2, arg3, arg4);
	}

	public static NewExpression NewNoByRefArgs(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4)
	{
		return new NoByRefFiveArgumentsNewExpression(ctor, arg0, arg1, arg2, arg3, arg4);
	}

	public static NewExpression New(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4, Expression arg5)
	{
		return new SixArgumentsNewExpression(ctor, arg0, arg1, arg2, arg3, arg4, arg5);
	}

	public static NewExpression NewNoByRefArgs(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4, Expression arg5)
	{
		return new NoByRefSixArgumentsNewExpression(ctor, arg0, arg1, arg2, arg3, arg4, arg5);
	}

	public static NewExpression New(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4, Expression arg5, Expression arg6)
	{
		return new SevenArgumentsNewExpression(ctor, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
	}

	public static NewExpression NewNoByRefArgs(ConstructorInfo ctor, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4, Expression arg5, Expression arg6)
	{
		return new NoByRefSevenArgumentsNewExpression(ctor, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
	}

	public static MethodCallExpression Call(MethodInfo method, params Expression[] arguments)
	{
		if (arguments != null && arguments.Length != 0)
		{
			return new ManyArgumentsMethodCallExpression(method, arguments);
		}
		return new NotNullMethodCallExpression(method);
	}

	public static MethodCallExpression Call(MethodInfo method, IEnumerable<Expression> arguments)
	{
		IReadOnlyList<Expression> readOnlyList = arguments.AsReadOnlyList();
		if (readOnlyList == null || readOnlyList.Count == 0)
		{
			return new NotNullMethodCallExpression(method);
		}
		return new ManyArgumentsMethodCallExpression(method, readOnlyList);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method, params Expression[] arguments)
	{
		if (arguments == null || arguments.Length == 0)
		{
			return new InstanceMethodCallExpression(instance, method);
		}
		return new InstanceManyArgumentsMethodCallExpression(instance, method, arguments);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method, IEnumerable<Expression> arguments)
	{
		IReadOnlyList<Expression> readOnlyList = arguments.AsReadOnlyList();
		if (readOnlyList == null || readOnlyList.Count == 0)
		{
			return new InstanceMethodCallExpression(instance, method);
		}
		return new InstanceManyArgumentsMethodCallExpression(instance, method, readOnlyList);
	}

	public static MethodCallExpression Call(Type type, string methodName, Type[] typeArguments, params Expression[] arguments)
	{
		MethodInfo method = type.FindMethodOrThrow(methodName, typeArguments, arguments, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		if (arguments == null || arguments.Length == 0)
		{
			return new NotNullMethodCallExpression(method);
		}
		return new ManyArgumentsMethodCallExpression(method, arguments);
	}

	public static MethodCallExpression Call(Type type, string methodName, Type[] typeArguments, IEnumerable<Expression> arguments)
	{
		IReadOnlyList<Expression> readOnlyList = arguments.AsReadOnlyList();
		MethodInfo method = type.FindMethodOrThrow(methodName, typeArguments, readOnlyList, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		if (readOnlyList == null || readOnlyList.Count == 0)
		{
			return new NotNullMethodCallExpression(method);
		}
		return new ManyArgumentsMethodCallExpression(method, readOnlyList);
	}

	public static MethodCallExpression Call(Expression instance, string methodName, Type[] typeArguments, params Expression[] arguments)
	{
		MethodInfo method = instance.Type.FindMethodOrThrow(methodName, typeArguments, arguments, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (arguments == null || arguments.Length == 0)
		{
			return new InstanceMethodCallExpression(instance, method);
		}
		return new InstanceManyArgumentsMethodCallExpression(instance, method, arguments);
	}

	public static MethodCallExpression Call(Expression instance, string methodName, Type[] typeArguments, IEnumerable<Expression> arguments)
	{
		IReadOnlyList<Expression> readOnlyList = arguments.AsReadOnlyList();
		MethodInfo method = instance.Type.FindMethodOrThrow(methodName, typeArguments, readOnlyList, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (readOnlyList == null || readOnlyList.Count == 0)
		{
			return new InstanceMethodCallExpression(instance, method);
		}
		return new InstanceManyArgumentsMethodCallExpression(instance, method, readOnlyList);
	}

	public static MethodCallExpression Call(MethodInfo method)
	{
		return new NotNullMethodCallExpression(method);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method)
	{
		if (instance != null)
		{
			return new InstanceMethodCallExpression(instance, method);
		}
		return new NotNullMethodCallExpression(method);
	}

	public static MethodCallExpression Call(MethodInfo method, Expression argument)
	{
		return new OneArgumentMethodCallExpression(method, argument);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression argument)
	{
		if (instance != null)
		{
			return new InstanceOneArgumentMethodCallExpression(instance, method, argument);
		}
		return new OneArgumentMethodCallExpression(method, argument);
	}

	public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1)
	{
		return new TwoArgumentsMethodCallExpression(method, arg0, arg1);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1)
	{
		if (instance != null)
		{
			return new InstanceTwoArgumentsMethodCallExpression(instance, method, arg0, arg1);
		}
		return new TwoArgumentsMethodCallExpression(method, arg0, arg1);
	}

	public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2)
	{
		return new ThreeArgumentsMethodCallExpression(method, arg0, arg1, arg2);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1, Expression arg2)
	{
		if (instance != null)
		{
			return new InstanceThreeArgumentsMethodCallExpression(instance, method, arg0, arg1, arg2);
		}
		return new ThreeArgumentsMethodCallExpression(method, arg0, arg1, arg2);
	}

	public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3)
	{
		return new FourArgumentsMethodCallExpression(method, arg0, arg1, arg2, arg3);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3)
	{
		if (instance != null)
		{
			return new InstanceFourArgumentsMethodCallExpression(instance, method, arg0, arg1, arg2, arg3);
		}
		return new FourArgumentsMethodCallExpression(method, arg0, arg1, arg2, arg3);
	}

	public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4)
	{
		return new FiveArgumentsMethodCallExpression(method, arg0, arg1, arg2, arg3, arg4);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4)
	{
		if (instance != null)
		{
			return new InstanceFiveArgumentsMethodCallExpression(instance, method, arg0, arg1, arg2, arg3, arg4);
		}
		return new FiveArgumentsMethodCallExpression(method, arg0, arg1, arg2, arg3, arg4);
	}

	public static MethodCallExpression Call(MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4, Expression arg5)
	{
		return new SixArgumentsMethodCallExpression(method, arg0, arg1, arg2, arg3, arg4, arg5);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4, Expression arg5)
	{
		if (instance != null)
		{
			return new InstanceSixArgumentsMethodCallExpression(instance, method, arg0, arg1, arg2, arg3, arg4, arg5);
		}
		return new SixArgumentsMethodCallExpression(method, arg0, arg1, arg2, arg3, arg4, arg5);
	}

	public static MethodCallExpression Call(Expression instance, MethodInfo method, Expression arg0, Expression arg1, Expression arg2, Expression arg3, Expression arg4, Expression arg5, Expression arg6)
	{
		if (instance != null)
		{
			return new InstanceSevenArgumentsMethodCallExpression(instance, method, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
		}
		return new SevenArgumentsMethodCallExpression(method, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
	}

	public static Expression CallIfNotNull(Expression instance, MethodInfo method)
	{
		return CallIfNotNull(instance, method, Tools.Empty<Expression>());
	}

	public static Expression CallIfNotNull(Expression instance, MethodInfo method, IEnumerable<Expression> arguments)
	{
		ParameterExpression parameterExpression = Parameter(instance.Type, "x");
		return Block(new ParameterExpression[1] { parameterExpression }, Assign(parameterExpression, instance), Condition(Equal(parameterExpression, Constant(null, instance.Type)), NullConstant, Call(parameterExpression, method, arguments), method.ReturnType));
	}

	public static MemberExpression Property(PropertyInfo property)
	{
		return new PropertyExpression(property);
	}

	public static MemberExpression Property(Expression instance, PropertyInfo property)
	{
		if (instance != null)
		{
			return new InstancePropertyExpression(instance, property);
		}
		return new PropertyExpression(property);
	}

	public static MemberExpression Property(Expression expression, string propertyName)
	{
		return Property(expression, expression.Type.FindProperty(propertyName) ?? throw new ArgumentException($"Declared property with the name '{propertyName}' is not found in '{expression.Type}'", "propertyName"));
	}

	public static IndexExpression Property(Expression instance, PropertyInfo indexer, Expression argument)
	{
		return new HasIndexerOneArgumentIndexExpression(instance, indexer, argument);
	}

	public static IndexExpression Property(Expression instance, PropertyInfo indexer, params Expression[] arguments)
	{
		return new HasIndexerManyArgumentsIndexExpression(instance, indexer, arguments);
	}

	public static IndexExpression Property(Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments)
	{
		return new HasIndexerManyArgumentsIndexExpression(instance, indexer, arguments.AsReadOnlyList());
	}

	public static MemberExpression PropertyOrField(Expression expression, string memberName)
	{
		if (!(expression.Type.FindProperty(memberName) != null))
		{
			return Field(expression, expression.Type.FindField(memberName) ?? throw new ArgumentException($"Declared field with the name '{memberName}' is not found '{expression.Type}'", "memberName"));
		}
		return Property(expression, expression.Type.FindProperty(memberName) ?? throw new ArgumentException($"Declared property with the name '{memberName}' is not found in '{expression.Type}'", "memberName"));
	}

	public static MemberExpression MakeMemberAccess(Expression expression, MemberInfo member)
	{
		if (member is FieldInfo field)
		{
			return Field(expression, field);
		}
		if (member is PropertyInfo property)
		{
			return Property(expression, property);
		}
		throw new ArgumentException($"Member is not field or property: {member}", "member");
	}

	public static IndexExpression MakeIndex(Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments)
	{
		if (!(indexer != null))
		{
			return ArrayAccess(instance, arguments);
		}
		return Property(instance, indexer, arguments);
	}

	public static IndexExpression ArrayAccess(Expression array, Expression index)
	{
		return new OneArgumentIndexExpression(array, index);
	}

	public static IndexExpression ArrayAccess(Expression array, params Expression[] indexes)
	{
		return new ManyArgumentsIndexExpression(array, indexes);
	}

	public static IndexExpression ArrayAccess(Expression array, IEnumerable<Expression> indexes)
	{
		return new ManyArgumentsIndexExpression(array, indexes.AsReadOnlyList());
	}

	public static MemberExpression Field(FieldInfo field)
	{
		return new FieldExpression(field);
	}

	public static MemberExpression Field(Expression instance, FieldInfo field)
	{
		if (instance != null)
		{
			return new InstanceFieldExpression(instance, field);
		}
		return new FieldExpression(field);
	}

	public static MemberExpression Field(Expression instance, string fieldName)
	{
		return Field(instance, instance.Type.FindField(fieldName));
	}

	public static UnaryExpression Not(Expression expression)
	{
		if (expression.Type == typeof(bool))
		{
			return new NotBooleanUnaryExpression(expression);
		}
		return new NodeTypedUnaryExpression(ExpressionType.Not, expression);
	}

	public static UnaryExpression TypeAs(Expression expression, Type type)
	{
		return new TypedUnaryExpression(ExpressionType.TypeAs, expression, type);
	}

	public static TypeBinaryExpression TypeEqual(Expression operand, Type type)
	{
		return new TypeBinaryExpression(ExpressionType.TypeEqual, operand, type);
	}

	public static TypeBinaryExpression TypeIs(Expression operand, Type type)
	{
		return new TypeBinaryExpression(ExpressionType.TypeIs, operand, type);
	}

	public static UnaryExpression ArrayLength(Expression array)
	{
		return new TypedUnaryExpression<int>(ExpressionType.ArrayLength, array);
	}

	public static UnaryExpression Convert(Expression expression, Type type)
	{
		return new ConvertUnaryExpression(expression, type);
	}

	public static UnaryExpression Convert<T>(Expression expression)
	{
		return new TypedConvertUnaryExpression<T>(expression);
	}

	public static UnaryExpression ConvertViaCastClassIntrinsic(Expression expression, Type type)
	{
		return new ConvertViaCastClassIntrinsicExpression(expression, type);
	}

	public static UnaryExpression ConvertViaCastClassIntrinsic<T>(Expression expression) where T : class
	{
		return new ConvertViaCastClassIntrinsicExpression<T>(expression);
	}

	public static UnaryExpression Convert(Expression expression, Type type, MethodInfo method)
	{
		return new ConvertWithMethodUnaryExpression(ExpressionType.Convert, expression, type, method);
	}

	public static UnaryExpression ConvertChecked(Expression expression, Type type)
	{
		return new TypedUnaryExpression(ExpressionType.ConvertChecked, expression, type);
	}

	public static UnaryExpression ConvertChecked(Expression expression, Type type, MethodInfo method)
	{
		return new ConvertWithMethodUnaryExpression(ExpressionType.ConvertChecked, expression, type, method);
	}

	public static UnaryExpression Decrement(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.Decrement, expression);
	}

	public static UnaryExpression Increment(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.Increment, expression);
	}

	public static UnaryExpression IsFalse(Expression expression)
	{
		return new TypedUnaryExpression<bool>(ExpressionType.IsFalse, expression);
	}

	public static UnaryExpression IsTrue(Expression expression)
	{
		return new TypedUnaryExpression<bool>(ExpressionType.IsTrue, expression);
	}

	public static UnaryExpression MakeUnary(ExpressionType unaryType, Expression operand, Type type)
	{
		if (type == null || type == operand.Type)
		{
			return new NodeTypedUnaryExpression(unaryType, operand);
		}
		return new TypedUnaryExpression(unaryType, operand, type);
	}

	public static UnaryExpression Negate(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.Negate, expression);
	}

	public static UnaryExpression NegateChecked(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.NegateChecked, expression);
	}

	public static UnaryExpression OnesComplement(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.OnesComplement, expression);
	}

	public static UnaryExpression PreIncrementAssign(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.PreIncrementAssign, expression);
	}

	public static UnaryExpression PostIncrementAssign(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.PostIncrementAssign, expression);
	}

	public static UnaryExpression PreDecrementAssign(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.PreDecrementAssign, expression);
	}

	public static UnaryExpression PostDecrementAssign(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.PostDecrementAssign, expression);
	}

	public static UnaryExpression Quote(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.Quote, expression);
	}

	public static UnaryExpression UnaryPlus(Expression expression)
	{
		return new NodeTypedUnaryExpression(ExpressionType.UnaryPlus, expression);
	}

	public static UnaryExpression Unbox(Expression expression, Type type)
	{
		if (type.IsEnum)
		{
			return new TypedUnaryExpression(ExpressionType.Unbox, expression, type);
		}
		return Type.GetTypeCode(type) switch
		{
			TypeCode.Boolean => new TypedUnaryExpression<bool>(ExpressionType.Unbox, expression), 
			TypeCode.Byte => new TypedUnaryExpression<byte>(ExpressionType.Unbox, expression), 
			TypeCode.Char => new TypedUnaryExpression<char>(ExpressionType.Unbox, expression), 
			TypeCode.DateTime => new TypedUnaryExpression<DateTime>(ExpressionType.Unbox, expression), 
			TypeCode.Decimal => new TypedUnaryExpression<decimal>(ExpressionType.Unbox, expression), 
			TypeCode.Double => new TypedUnaryExpression<double>(ExpressionType.Unbox, expression), 
			TypeCode.Int16 => new TypedUnaryExpression<short>(ExpressionType.Unbox, expression), 
			TypeCode.Int32 => new TypedUnaryExpression<int>(ExpressionType.Unbox, expression), 
			TypeCode.Int64 => new TypedUnaryExpression<long>(ExpressionType.Unbox, expression), 
			TypeCode.SByte => new TypedUnaryExpression<sbyte>(ExpressionType.Unbox, expression), 
			TypeCode.Single => new TypedUnaryExpression<float>(ExpressionType.Unbox, expression), 
			TypeCode.String => new TypedUnaryExpression<string>(ExpressionType.Unbox, expression), 
			TypeCode.UInt16 => new TypedUnaryExpression<ushort>(ExpressionType.Unbox, expression), 
			TypeCode.UInt32 => new TypedUnaryExpression<uint>(ExpressionType.Unbox, expression), 
			TypeCode.UInt64 => new TypedUnaryExpression<ulong>(ExpressionType.Unbox, expression), 
			_ => new TypedUnaryExpression(ExpressionType.Unbox, expression, type), 
		};
	}

	public static LambdaExpression Lambda(Expression body)
	{
		return new TypedLambdaExpression(Tools.GetFuncOrActionType(body.Type), body);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body)
	{
		if (delegateType == null || delegateType == typeof(Delegate))
		{
			return Lambda(body);
		}
		Type delegateReturnType = GetDelegateReturnType(delegateType);
		if (delegateReturnType == body.Type)
		{
			return new TypedLambdaExpression(delegateType, body);
		}
		return new TypedReturnLambdaExpression(delegateType, body, delegateReturnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, Type returnType)
	{
		if (delegateType == null || delegateType == typeof(Delegate))
		{
			delegateType = Tools.GetFuncOrActionType(returnType);
		}
		if (returnType == body.Type)
		{
			return new TypedLambdaExpression(delegateType, body);
		}
		return new TypedReturnLambdaExpression(delegateType, body, returnType);
	}

	public static LambdaExpression Lambda(Expression body, IReadOnlyList<ParameterExpression> parameters)
	{
		if (parameters == null || parameters.Count <= 0)
		{
			return new TypedLambdaExpression(Tools.GetFuncOrActionType(body.Type), body);
		}
		return new ManyParametersLambdaExpression(Tools.GetFuncOrActionType(Tools.GetParamTypes(parameters), body.Type), body, parameters);
	}

	public static LambdaExpression Lambda(Expression body, params ParameterExpression[] parameters)
	{
		return Lambda(body, (IReadOnlyList<ParameterExpression>)parameters);
	}

	public static LambdaExpression Lambda(Expression body, ParameterExpression parameter)
	{
		return new OneParameterLambdaExpression(Tools.GetFuncOrActionType(parameter.Type, body.Type), body, parameter);
	}

	public static LambdaExpression Lambda(Expression body, ParameterExpression p0, ParameterExpression p1)
	{
		return new TwoParametersLambdaExpression(Tools.GetFuncOrActionType(p0.Type, p1.Type, body.Type), body, p0, p1);
	}

	public static LambdaExpression Lambda(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2)
	{
		return new ThreeParametersLambdaExpression(Tools.GetFuncOrActionType(p0.Type, p1.Type, p2.Type, body.Type), body, p0, p1, p2);
	}

	public static LambdaExpression Lambda(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3)
	{
		return new FourParametersLambdaExpression(Tools.GetFuncOrActionType(p0.Type, p1.Type, p2.Type, p3.Type, body.Type), body, p0, p1, p2, p3);
	}

	public static LambdaExpression Lambda(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4)
	{
		return new FiveParametersLambdaExpression(Tools.GetFuncOrActionType(p0.Type, p1.Type, p2.Type, p3.Type, p4.Type, body.Type), body, p0, p1, p2, p3, p4);
	}

	public static LambdaExpression Lambda(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4, ParameterExpression p5)
	{
		return new SixParametersLambdaExpression(Tools.GetFuncOrActionType(p0.Type, p1.Type, p2.Type, p3.Type, p4.Type, p5.Type, body.Type), body, p0, p1, p2, p3, p4, p5);
	}

	public static LambdaExpression Lambda(Expression body, IReadOnlyList<ParameterExpression> parameters, Type returnType)
	{
		if (returnType == body.Type)
		{
			Lambda(body, parameters);
		}
		Type funcOrActionType = Tools.GetFuncOrActionType(Tools.GetParamTypes(parameters), returnType);
		if (parameters != null && parameters.Count > 0)
		{
			return new TypedReturnManyParametersLambdaExpression(funcOrActionType, body, parameters, returnType);
		}
		return new TypedReturnLambdaExpression(funcOrActionType, body, returnType);
	}

	public static LambdaExpression Lambda(Expression body, IEnumerable<ParameterExpression> parameters, Type returnType)
	{
		return Lambda(body, parameters.AsReadOnlyList(), returnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, IReadOnlyList<ParameterExpression> parameters)
	{
		if (delegateType == null || delegateType == typeof(Delegate))
		{
			return Lambda(body, parameters);
		}
		Type delegateReturnType = GetDelegateReturnType(delegateType);
		return Lambda(delegateType, body, parameters, delegateReturnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, params ParameterExpression[] parameters)
	{
		return Lambda(delegateType, body, (IReadOnlyList<ParameterExpression>)parameters);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, IReadOnlyList<ParameterExpression> parameters, Type returnType)
	{
		if (delegateType == null || delegateType == typeof(Delegate))
		{
			return Lambda(body, parameters, returnType);
		}
		if (parameters != null && parameters.Count > 0)
		{
			if (returnType == body.Type)
			{
				return new ManyParametersLambdaExpression(delegateType, body, parameters);
			}
			return new TypedReturnManyParametersLambdaExpression(delegateType, body, parameters, returnType);
		}
		if (returnType == body.Type)
		{
			return new TypedLambdaExpression(delegateType, body);
		}
		return new TypedReturnLambdaExpression(delegateType, body, returnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, IEnumerable<ParameterExpression> parameters, Type returnType)
	{
		return Lambda(delegateType, body, parameters.AsReadOnlyList(), returnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, ParameterExpression p0, Type returnType)
	{
		if (returnType == body.Type)
		{
			return new OneParameterLambdaExpression(delegateType, body, p0);
		}
		return new TypedReturnOneParameterLambdaExpression(delegateType, body, p0, returnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, Type returnType)
	{
		if (returnType == body.Type)
		{
			return new TwoParametersLambdaExpression(delegateType, body, p0, p1);
		}
		return new TypedReturnTwoParametersLambdaExpression(delegateType, body, p0, p1, returnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, Type returnType)
	{
		if (returnType == body.Type)
		{
			return new ThreeParametersLambdaExpression(delegateType, body, p0, p1, p2);
		}
		return new TypedReturnThreeParametersLambdaExpression(delegateType, body, p0, p1, p2, returnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, Type returnType)
	{
		if (returnType == body.Type)
		{
			return new FourParametersLambdaExpression(delegateType, body, p0, p1, p2, p3);
		}
		return new TypedReturnFourParametersLambdaExpression(delegateType, body, p0, p1, p2, p3, returnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4, Type returnType)
	{
		if (returnType == body.Type)
		{
			return new FiveParametersLambdaExpression(delegateType, body, p0, p1, p2, p3, p4);
		}
		return new TypedReturnFiveParametersLambdaExpression(delegateType, body, p0, p1, p2, p3, p4, returnType);
	}

	public static LambdaExpression Lambda(Type delegateType, Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4, ParameterExpression p5, Type returnType)
	{
		if (returnType == body.Type)
		{
			return new SixParametersLambdaExpression(delegateType, body, p0, p1, p2, p3, p4, p5);
		}
		return new TypedReturnSixParametersLambdaExpression(delegateType, body, p0, p1, p2, p3, p4, p5, returnType);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, GetDelegateReturnType(typeof(TDelegate)));
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, Type returnType) where TDelegate : Delegate
	{
		if (!(returnType == body.Type))
		{
			return new TypedReturnExpression<TDelegate>(body, returnType);
		}
		return new Expression<TDelegate>(body);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, Type returnType) where TDelegate : Delegate
	{
		if (returnType == body.Type)
		{
			return new OneParameterExpression<TDelegate>(body, p0);
		}
		return new TypedReturnOneParameterExpression<TDelegate>(body, p0, returnType);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, p0, GetDelegateReturnType(typeof(TDelegate)));
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1, Type returnType) where TDelegate : Delegate
	{
		if (returnType == body.Type)
		{
			return new TwoParametersExpression<TDelegate>(body, p0, p1);
		}
		return new TypedReturnTwoParametersExpression<TDelegate>(body, p0, p1, returnType);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, p0, p1, GetDelegateReturnType(typeof(TDelegate)));
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, Type returnType) where TDelegate : Delegate
	{
		if (returnType == body.Type)
		{
			return new ThreeParametersExpression<TDelegate>(body, p0, p1, p2);
		}
		return new TypedReturnThreeParametersExpression<TDelegate>(body, p0, p1, p2, returnType);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, p0, p1, p2, GetDelegateReturnType(typeof(TDelegate)));
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, Type returnType) where TDelegate : Delegate
	{
		if (returnType == body.Type)
		{
			return new FourParametersExpression<TDelegate>(body, p0, p1, p2, p3);
		}
		return new TypedReturnFourParametersExpression<TDelegate>(body, p0, p1, p2, p3, returnType);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, p0, p1, p2, p3, GetDelegateReturnType(typeof(TDelegate)));
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4, Type returnType) where TDelegate : Delegate
	{
		if (returnType == body.Type)
		{
			return new FiveParametersExpression<TDelegate>(body, p0, p1, p2, p3, p4);
		}
		return new TypedReturnFiveParametersExpression<TDelegate>(body, p0, p1, p2, p3, p4, returnType);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, p0, p1, p2, p3, p4, GetDelegateReturnType(typeof(TDelegate)));
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4, ParameterExpression p5, Type returnType) where TDelegate : Delegate
	{
		if (returnType == body.Type)
		{
			return new SixParametersExpression<TDelegate>(body, p0, p1, p2, p3, p4, p5);
		}
		return new TypedReturnSixParametersExpression<TDelegate>(body, p0, p1, p2, p3, p4, p5, returnType);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, ParameterExpression p0, ParameterExpression p1, ParameterExpression p2, ParameterExpression p3, ParameterExpression p4, ParameterExpression p5) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, p0, p1, p2, p3, p4, p5, GetDelegateReturnType(typeof(TDelegate)));
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, IReadOnlyList<ParameterExpression> parameters, Type returnType) where TDelegate : Delegate
	{
		if (parameters != null && parameters.Count > 0)
		{
			if (returnType == body.Type)
			{
				return new ManyParametersExpression<TDelegate>(body, parameters);
			}
			return new TypedReturnManyParametersExpression<TDelegate>(body, parameters, returnType);
		}
		return Lambda<TDelegate>(body, returnType);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, IEnumerable<ParameterExpression> parameters, Type returnType) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, parameters.AsReadOnlyList(), returnType);
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, params ParameterExpression[] parameters) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, parameters, GetDelegateReturnType(typeof(TDelegate)));
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, IEnumerable<ParameterExpression> parameters) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, parameters.AsReadOnlyList(), GetDelegateReturnType(typeof(TDelegate)));
	}

	public static Expression<TDelegate> Lambda<TDelegate>(Expression body, string name, params ParameterExpression[] parameters) where TDelegate : Delegate
	{
		return Lambda<TDelegate>(body, parameters, GetDelegateReturnType(typeof(TDelegate)));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Type GetDelegateReturnType(Type delegateType)
	{
		return delegateType.GetMethod("Invoke").ReturnType;
	}

	public static BinaryExpression ArrayIndex(Expression array, Expression index)
	{
		return new ArrayIndexExpression(array, index);
	}

	public static BinaryExpression ArrayIndex(Expression array, Expression index, MethodInfo method)
	{
		if (!(method == null))
		{
			return GetMethodBasedBinaryOperator(ExpressionType.ArrayIndex, array, index, method, liftToNull: true);
		}
		return new ArrayIndexExpression(array, index);
	}

	public static MethodCallExpression ArrayIndex(Expression array, IEnumerable<Expression> indexes)
	{
		return Call(array, array.Type.GetMethod("Get", BindingFlags.Instance | BindingFlags.Public), indexes.AsReadOnlyList());
	}

	public static MethodCallExpression ArrayIndex(Expression array, params Expression[] indexes)
	{
		return Call(array, array.Type.GetMethod("Get", BindingFlags.Instance | BindingFlags.Public), indexes);
	}

	public static MemberAssignment Bind(MemberInfo member, Expression expression)
	{
		return new MemberAssignment(member, expression);
	}

	public static MemberMemberBinding MemberBind(MemberInfo member, params MemberBinding[] bindings)
	{
		return new MemberMemberBinding(member, bindings);
	}

	public static MemberMemberBinding MemberBind(MemberInfo member, IEnumerable<MemberBinding> bindings)
	{
		return new MemberMemberBinding(member, bindings.AsReadOnlyList());
	}

	public static MemberListBinding ListBind(MemberInfo member, params ElementInit[] initializers)
	{
		return new MemberListBinding(member, initializers);
	}

	public static MemberListBinding ListBind(MemberInfo member, IEnumerable<ElementInit> initializers)
	{
		return new MemberListBinding(member, initializers.AsReadOnlyList());
	}

	public static MemberInitExpression MemberInit(NewExpression newExpr)
	{
		return new MemberInitExpression(newExpr);
	}

	public static MemberInitExpression MemberInit(NewExpression newExpr, MemberBinding binding)
	{
		return new OneBindingMemberInitExpression(newExpr, binding);
	}

	public static MemberInitExpression MemberInit(NewExpression newExpr, MemberBinding b0, MemberBinding b1)
	{
		return new TwoBindingsMemberInitExpression(newExpr, b0, b1);
	}

	public static MemberInitExpression MemberInit(NewExpression newExpr, MemberBinding b0, MemberBinding b1, MemberBinding b2)
	{
		return new ThreeBindingsMemberInitExpression(newExpr, b0, b1, b2);
	}

	public static MemberInitExpression MemberInit(NewExpression newExpr, MemberBinding b0, MemberBinding b1, MemberBinding b2, MemberBinding b3)
	{
		return new FourBindingsMemberInitExpression(newExpr, b0, b1, b2, b3);
	}

	public static MemberInitExpression MemberInit(NewExpression newExpr, MemberBinding b0, MemberBinding b1, MemberBinding b2, MemberBinding b3, MemberBinding b4)
	{
		return new FiveBindingsMemberInitExpression(newExpr, b0, b1, b2, b3, b4);
	}

	public static MemberInitExpression MemberInit(NewExpression newExpr, MemberBinding b0, MemberBinding b1, MemberBinding b2, MemberBinding b3, MemberBinding b4, MemberBinding b5)
	{
		return new SixBindingsMemberInitExpression(newExpr, b0, b1, b2, b3, b4, b5);
	}

	public static MemberInitExpression MemberInit(NewExpression newExpr, params MemberBinding[] bindings)
	{
		if (bindings != null && bindings.Length != 0)
		{
			return new ManyBindingsMemberInitExpression(newExpr, bindings);
		}
		return new MemberInitExpression(newExpr);
	}

	public static MemberInitExpression MemberInit(NewExpression newExpr, IEnumerable<MemberBinding> bindings)
	{
		return MemberInit(newExpr, bindings.AsReadOnlyList());
	}

	public static MemberInitExpression MemberInit(Expression expression, params MemberBinding[] bindings)
	{
		if (bindings != null && bindings.Length != 0)
		{
			return new ManyBindingsMemberInitExpression(expression, bindings);
		}
		return new MemberInitExpression(expression);
	}

	public static MemberInitExpression MemberInit(Expression expression, IEnumerable<MemberBinding> assignments)
	{
		return MemberInit(expression, assignments.AsReadOnlyList());
	}

	public static ListInitExpression ListInit(NewExpression newExpression, IEnumerable<ElementInit> initializers)
	{
		return new ListInitExpression(newExpression, initializers.AsReadOnlyList());
	}

	public static ListInitExpression ListInit(NewExpression newExpression, params ElementInit[] initializers)
	{
		return new ListInitExpression(newExpression, initializers);
	}

	public static NewArrayExpression NewArrayInit(Type type, params Expression[] initializers)
	{
		return new ManyElementsNewArrayInitExpression(type.MakeArrayType(), initializers);
	}

	public static NewArrayExpression NewArrayInit(Type type, IEnumerable<Expression> initializers)
	{
		return new ManyElementsNewArrayInitExpression(type.MakeArrayType(), initializers.AsReadOnlyList());
	}

	public static NewArrayExpression NewArrayInit(Type type, Expression element)
	{
		return new OneElementNewArrayInitExpression(type.MakeArrayType(), element);
	}

	public static NewArrayExpression NewArrayInit(Type type, Expression el0, Expression el1)
	{
		return new TwoElementNewArrayInitExpression(type.MakeArrayType(), el0, el1);
	}

	public static NewArrayExpression NewArrayInit(Type type, Expression el0, Expression el1, Expression el2)
	{
		return new ThreeElementNewArrayInitExpression(type.MakeArrayType(), el0, el1, el2);
	}

	public static NewArrayExpression NewArrayInit(Type type, Expression el0, Expression el1, Expression el2, Expression el3)
	{
		return new FourElementNewArrayInitExpression(type.MakeArrayType(), el0, el1, el2, el3);
	}

	public static NewArrayExpression NewArrayInit(Type type, Expression el0, Expression el1, Expression el2, Expression el3, Expression el4)
	{
		return new FiveElementNewArrayInitExpression(type.MakeArrayType(), el0, el1, el2, el3, el4);
	}

	public static NewArrayExpression NewArrayInit(Type type, Expression el0, Expression el1, Expression el2, Expression el3, Expression el4, Expression el5)
	{
		return new SixElementNewArrayInitExpression(type.MakeArrayType(), el0, el1, el2, el3, el4, el5);
	}

	public static NewArrayExpression MakeArrayBounds(Type type, IReadOnlyList<Expression> bounds)
	{
		return new ManyBoundsNewArrayBoundsExpression((bounds.Count == 1) ? type.MakeArrayType() : type.MakeArrayType(bounds.Count), bounds);
	}

	public static NewArrayExpression NewArrayBounds(Type type, Expression bound)
	{
		return new OneBoundNewArrayBoundsExpression(type.MakeArrayType(), bound);
	}

	public static NewArrayExpression NewArrayBounds(Type type, params Expression[] bounds)
	{
		return MakeArrayBounds(type, bounds);
	}

	public static NewArrayExpression NewArrayBounds(Type type, IEnumerable<Expression> bounds)
	{
		return MakeArrayBounds(type, bounds.AsReadOnlyList());
	}

	public static BinaryExpression Assign(Expression left, Expression right)
	{
		return new AssignBinaryExpression(left, right);
	}

	public static BinaryExpression PowerAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.PowerAssign, left, right);
	}

	public static BinaryExpression AddAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.AddAssign, left, right);
	}

	public static BinaryExpression AddAssignChecked(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.AddAssignChecked, left, right);
	}

	public static BinaryExpression AndAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.AndAssign, left, right);
	}

	public static BinaryExpression OrAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.OrAssign, left, right);
	}

	public static BinaryExpression ExclusiveOrAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.ExclusiveOrAssign, left, right);
	}

	public static BinaryExpression RightShiftAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.RightShiftAssign, left, right);
	}

	public static BinaryExpression LeftShiftAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.LeftShiftAssign, left, right);
	}

	public static BinaryExpression ModuloAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.ModuloAssign, left, right);
	}

	public static BinaryExpression SubtractAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.SubtractAssign, left, right);
	}

	public static BinaryExpression SubtractAssignChecked(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.SubtractAssignChecked, left, right);
	}

	public static BinaryExpression MultiplyAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.MultiplyAssign, left, right);
	}

	public static BinaryExpression MultiplyAssignChecked(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.MultiplyAssignChecked, left, right);
	}

	public static BinaryExpression DivideAssign(Expression left, Expression right)
	{
		return new OpAssignBinaryExpression(ExpressionType.DivideAssign, left, right);
	}

	public static ElementInit ElementInit(MethodInfo addMethod, Expression arg)
	{
		return new OneArgumentElementInit(addMethod, arg);
	}

	public static ElementInit ElementInit(MethodInfo addMethod, params Expression[] arguments)
	{
		return new ManyArgumentsElementInit(addMethod, arguments);
	}

	public static ElementInit ElementInit(MethodInfo addMethod, IEnumerable<Expression> arguments)
	{
		return new ManyArgumentsElementInit(addMethod, arguments.AsReadOnlyList());
	}

	public static InvocationExpression Invoke(LambdaExpression expression)
	{
		return new NotNullExpressionInvocationExpression(expression);
	}

	public static InvocationExpression Invoke(LambdaExpression expression, Expression a0)
	{
		return new OneArgumentInvocationExpression(expression, a0);
	}

	public static InvocationExpression Invoke(Expression expression, Expression a0)
	{
		if (!(expression is LambdaExpression))
		{
			return new TypedOneArgumentInvocationExpression(expression, expression.Type.FindDelegateInvokeMethod().ReturnType, a0);
		}
		return new OneArgumentInvocationExpression(expression, a0);
	}

	public static InvocationExpression Invoke(Type returnType, Expression expression, Expression a0)
	{
		if (!(expression is LambdaExpression lambdaExpression) || !(lambdaExpression.ReturnType == returnType))
		{
			return new TypedOneArgumentInvocationExpression(expression, returnType, a0);
		}
		return new OneArgumentInvocationExpression(expression, a0);
	}

	public static InvocationExpression Invoke(LambdaExpression expression, Expression a0, Expression a1)
	{
		return new TwoArgumentsInvocationExpression(expression, a0, a1);
	}

	public static InvocationExpression Invoke(Expression expression, Expression a0, Expression a1)
	{
		if (!(expression is LambdaExpression))
		{
			return new TypedTwoArgumentsInvocationExpression(expression, expression.Type.FindDelegateInvokeMethod().ReturnType, a0, a1);
		}
		return new TwoArgumentsInvocationExpression(expression, a0, a1);
	}

	public static InvocationExpression Invoke(Type returnType, Expression expression, Expression a0, Expression a1)
	{
		if (!(expression is LambdaExpression lambdaExpression) || !(lambdaExpression.ReturnType == returnType))
		{
			return new TypedTwoArgumentsInvocationExpression(expression, returnType, a0, a1);
		}
		return new TwoArgumentsInvocationExpression(expression, a0, a1);
	}

	public static InvocationExpression Invoke(LambdaExpression expression, Expression a0, Expression a1, Expression a2)
	{
		return new ThreeArgumentsInvocationExpression(expression, a0, a1, a2);
	}

	public static InvocationExpression Invoke(Expression expression, Expression a0, Expression a1, Expression a2)
	{
		if (!(expression is LambdaExpression))
		{
			return new TypedThreeArgumentsInvocationExpression(expression, expression.Type.FindDelegateInvokeMethod().ReturnType, a0, a1, a2);
		}
		return new ThreeArgumentsInvocationExpression(expression, a0, a1, a2);
	}

	public static InvocationExpression Invoke(Type returnType, Expression expression, Expression a0, Expression a1, Expression a2)
	{
		if (!(expression is LambdaExpression lambdaExpression) || !(lambdaExpression.ReturnType == returnType))
		{
			return new TypedThreeArgumentsInvocationExpression(expression, returnType, a0, a1, a2);
		}
		return new ThreeArgumentsInvocationExpression(expression, a0, a1, a2);
	}

	public static InvocationExpression Invoke(LambdaExpression expression, Expression a0, Expression a1, Expression a2, Expression a3)
	{
		return new FourArgumentsInvocationExpression(expression, a0, a1, a2, a3);
	}

	public static InvocationExpression Invoke(Expression expression, Expression a0, Expression a1, Expression a2, Expression a3)
	{
		if (!(expression is LambdaExpression))
		{
			return new TypedFourArgumentsInvocationExpression(expression, expression.Type.FindDelegateInvokeMethod().ReturnType, a0, a1, a2, a3);
		}
		return new FourArgumentsInvocationExpression(expression, a0, a1, a2, a3);
	}

	public static InvocationExpression Invoke(Type returnType, Expression expression, Expression a0, Expression a1, Expression a2, Expression a3)
	{
		if (!(expression is LambdaExpression lambdaExpression) || !(lambdaExpression.ReturnType == returnType))
		{
			return new TypedFourArgumentsInvocationExpression(expression, returnType, a0, a1, a2, a3);
		}
		return new FourArgumentsInvocationExpression(expression, a0, a1, a2, a3);
	}

	public static InvocationExpression Invoke(LambdaExpression expression, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4)
	{
		return new FiveArgumentsInvocationExpression(expression, a0, a1, a2, a3, a4);
	}

	public static InvocationExpression Invoke(Expression expression, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4)
	{
		if (!(expression is LambdaExpression))
		{
			return new TypedFiveArgumentsInvocationExpression(expression, expression.Type.FindDelegateInvokeMethod().ReturnType, a0, a1, a2, a3, a4);
		}
		return new FiveArgumentsInvocationExpression(expression, a0, a1, a2, a3, a4);
	}

	public static InvocationExpression Invoke(Type returnType, Expression expression, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4)
	{
		if (!(expression is LambdaExpression lambdaExpression) || !(lambdaExpression.ReturnType == returnType))
		{
			return new TypedFiveArgumentsInvocationExpression(expression, returnType, a0, a1, a2, a3, a4);
		}
		return new FiveArgumentsInvocationExpression(expression, a0, a1, a2, a3, a4);
	}

	public static InvocationExpression Invoke(LambdaExpression expression, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4, Expression a5)
	{
		return new SixArgumentsInvocationExpression(expression, a0, a1, a2, a3, a4, a5);
	}

	public static InvocationExpression Invoke(Expression expression, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4, Expression a5)
	{
		if (!(expression is LambdaExpression))
		{
			return new TypedSixArgumentsInvocationExpression(expression, expression.Type.FindDelegateInvokeMethod().ReturnType, a0, a1, a2, a3, a4, a5);
		}
		return new SixArgumentsInvocationExpression(expression, a0, a1, a2, a3, a4, a5);
	}

	public static InvocationExpression Invoke(Type returnType, Expression expression, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4, Expression a5)
	{
		if (!(expression is LambdaExpression lambdaExpression) || !(lambdaExpression.ReturnType == returnType))
		{
			return new TypedSixArgumentsInvocationExpression(expression, returnType, a0, a1, a2, a3, a4, a5);
		}
		return new SixArgumentsInvocationExpression(expression, a0, a1, a2, a3, a4, a5);
	}

	public static InvocationExpression Invoke(Expression expression, IEnumerable<Expression> args)
	{
		if (!(expression is LambdaExpression))
		{
			return new TypedManyArgumentsInvocationExpression(expression, args.AsReadOnlyList(), expression.Type.FindDelegateInvokeMethod().ReturnType);
		}
		return new ManyArgumentsInvocationExpression(expression, args.AsReadOnlyList());
	}

	public static InvocationExpression Invoke(Type returnType, Expression expression, IEnumerable<Expression> args)
	{
		if (!(expression is LambdaExpression lambdaExpression) || !(lambdaExpression.ReturnType == returnType))
		{
			return new TypedManyArgumentsInvocationExpression(expression, args.AsReadOnlyList(), returnType);
		}
		return new ManyArgumentsInvocationExpression(expression, args.AsReadOnlyList());
	}

	public static InvocationExpression Invoke(Expression lambda, params Expression[] args)
	{
		return Invoke(lambda, (IEnumerable<Expression>)args);
	}

	public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse)
	{
		return new WithFalseBranchConditionalExpression(test, ifTrue, ifFalse);
	}

	public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse, Type type)
	{
		if (!(ifTrue.Type == type))
		{
			return new TypedWithFalseBranchConditionalExpression(test, ifTrue, ifFalse, type);
		}
		return new WithFalseBranchConditionalExpression(test, ifTrue, ifFalse);
	}

	public static ConditionalExpression IfThen(Expression test, Expression ifTrue)
	{
		return new ConditionalExpression(test, ifTrue);
	}

	public static ConditionalExpression IfThenElse(Expression test, Expression ifTrue, Expression ifFalse)
	{
		return new VoidWithFalseBranchConditionalExpression(test, ifTrue, ifFalse);
	}

	public static DefaultExpression Empty()
	{
		return VoidDefault;
	}

	public static DefaultExpression Default(Type type)
	{
		if (!(type == typeof(void)))
		{
			return new DefaultExpression(type);
		}
		return VoidDefault;
	}

	public static BinaryExpression GetArithmeticBinary(ExpressionType nodeType, Expression left, Expression right, MethodInfo method = null)
	{
		if (method == null)
		{
			if (left.Type == right.Type && left.Type.IsArithmetic())
			{
				return new LeftTypedBinaryExpression(nodeType, left, right);
			}
			return GetUserDefinedBinaryOperatorOrThrow(nodeType, nodeType.GetArithmeticBinaryOperatorMethodName(), left, right, liftToNull: true);
		}
		return GetMethodBasedBinaryOperator(nodeType, left, right, method, liftToNull: true);
	}

	public static BinaryExpression GetLeftTypedBinary(ExpressionType nodeType, Expression left, Expression right, MethodInfo method = null)
	{
		if (!(method == null))
		{
			return GetMethodBasedBinaryOperator(nodeType, left, right, method, liftToNull: true);
		}
		return new LeftTypedBinaryExpression(nodeType, left, right);
	}

	public static BinaryExpression Add(Expression left, Expression right)
	{
		return GetArithmeticBinary(ExpressionType.Add, left, right);
	}

	public static BinaryExpression Add(Expression left, Expression right, MethodInfo method)
	{
		return GetArithmeticBinary(ExpressionType.Add, left, right, method);
	}

	public static BinaryExpression AddChecked(Expression left, Expression right)
	{
		return GetArithmeticBinary(ExpressionType.AddChecked, left, right);
	}

	public static BinaryExpression AddChecked(Expression left, Expression right, MethodInfo method)
	{
		return GetArithmeticBinary(ExpressionType.AddChecked, left, right, method);
	}

	public static BinaryExpression ExclusiveOr(Expression left, Expression right)
	{
		return new LeftTypedBinaryExpression(ExpressionType.ExclusiveOr, left, right);
	}

	public static BinaryExpression ExclusiveOr(Expression left, Expression right, MethodInfo method)
	{
		return GetLeftTypedBinary(ExpressionType.ExclusiveOr, left, right, method);
	}

	public static BinaryExpression LeftShift(Expression left, Expression right)
	{
		return new LeftTypedBinaryExpression(ExpressionType.LeftShift, left, right);
	}

	public static BinaryExpression LeftShift(Expression left, Expression right, MethodInfo method)
	{
		return GetLeftTypedBinary(ExpressionType.LeftShift, left, right, method);
	}

	public static BinaryExpression Modulo(Expression left, Expression right)
	{
		return GetArithmeticBinary(ExpressionType.Modulo, left, right);
	}

	public static BinaryExpression Modulo(Expression left, Expression right, MethodInfo method)
	{
		return GetArithmeticBinary(ExpressionType.Modulo, left, right, method);
	}

	public static BinaryExpression RightShift(Expression left, Expression right)
	{
		return new LeftTypedBinaryExpression(ExpressionType.RightShift, left, right);
	}

	public static BinaryExpression RightShift(Expression left, Expression right, MethodInfo method)
	{
		return GetLeftTypedBinary(ExpressionType.RightShift, left, right, method);
	}

	public static BinaryExpression Subtract(Expression left, Expression right)
	{
		return GetArithmeticBinary(ExpressionType.Subtract, left, right);
	}

	public static BinaryExpression Subtract(Expression left, Expression right, MethodInfo method)
	{
		return GetArithmeticBinary(ExpressionType.Subtract, left, right, method);
	}

	public static BinaryExpression SubtractChecked(Expression left, Expression right)
	{
		return GetArithmeticBinary(ExpressionType.SubtractChecked, left, right);
	}

	public static BinaryExpression SubtractChecked(Expression left, Expression right, MethodInfo method)
	{
		return GetArithmeticBinary(ExpressionType.SubtractChecked, left, right, method);
	}

	public static BinaryExpression Multiply(Expression left, Expression right)
	{
		return GetArithmeticBinary(ExpressionType.Multiply, left, right);
	}

	public static BinaryExpression Multiply(Expression left, Expression right, MethodInfo method)
	{
		return GetArithmeticBinary(ExpressionType.Multiply, left, right, method);
	}

	public static BinaryExpression MultiplyChecked(Expression left, Expression right)
	{
		return GetArithmeticBinary(ExpressionType.MultiplyChecked, left, right);
	}

	public static BinaryExpression MultiplyChecked(Expression left, Expression right, MethodInfo method)
	{
		return GetArithmeticBinary(ExpressionType.MultiplyChecked, left, right, method);
	}

	public static BinaryExpression Divide(Expression left, Expression right)
	{
		return GetArithmeticBinary(ExpressionType.Divide, left, right);
	}

	public static BinaryExpression Divide(Expression left, Expression right, MethodInfo method)
	{
		return GetArithmeticBinary(ExpressionType.Divide, left, right, method);
	}

	public static BinaryExpression Power(Expression left, Expression right)
	{
		return new LeftTypedBinaryExpression(ExpressionType.Power, left, right);
	}

	public static BinaryExpression Power(Expression left, Expression right, MethodInfo method)
	{
		return GetLeftTypedBinary(ExpressionType.Power, left, right, method);
	}

	public static BinaryExpression And(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.And, left, right);
	}

	public static BinaryExpression And(Expression left, Expression right, MethodInfo method)
	{
		return GetLeftTypedBinary(ExpressionType.And, left, right, method);
	}

	public static BinaryExpression AndAlso(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.AndAlso, left, right);
	}

	public static BinaryExpression AndAlso(Expression left, Expression right, MethodInfo method)
	{
		return GetLeftTypedBinary(ExpressionType.AndAlso, left, right, method);
	}

	public static BinaryExpression Or(Expression left, Expression right)
	{
		return new LeftTypedBinaryExpression(ExpressionType.Or, left, right);
	}

	public static BinaryExpression Or(Expression left, Expression right, MethodInfo method)
	{
		return GetLeftTypedBinary(ExpressionType.Or, left, right, method);
	}

	public static BinaryExpression GetLogicalBinary(ExpressionType nodeType, Expression left, Expression right, bool liftToNull, MethodInfo method)
	{
		if (liftToNull || !(method == null))
		{
			return GetMethodBasedBinaryOperator(nodeType, left, right, method, liftToNull);
		}
		return new LogicalBinaryExpression(nodeType, left, right);
	}

	public static BinaryExpression OrElse(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.OrElse, left, right);
	}

	public static BinaryExpression OrElse(Expression left, Expression right, MethodInfo method)
	{
		return GetLeftTypedBinary(ExpressionType.OrElse, left, right, method);
	}

	public static BinaryExpression Equal(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.Equal, left, right);
	}

	public static BinaryExpression Equal(Expression left, Expression right, bool liftToNull, MethodInfo method)
	{
		return GetLogicalBinary(ExpressionType.Equal, left, right, liftToNull, method);
	}

	public static BinaryExpression NotEqual(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.NotEqual, left, right);
	}

	public static BinaryExpression NotEqual(Expression left, Expression right, bool liftToNull, MethodInfo method)
	{
		return GetLogicalBinary(ExpressionType.NotEqual, left, right, liftToNull, method);
	}

	public static BinaryExpression GreaterThan(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.GreaterThan, left, right);
	}

	public static BinaryExpression GreaterThan(Expression left, Expression right, bool liftToNull, MethodInfo method)
	{
		return GetLogicalBinary(ExpressionType.GreaterThan, left, right, liftToNull, method);
	}

	public static BinaryExpression GreaterThanOrEqual(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.GreaterThanOrEqual, left, right);
	}

	public static BinaryExpression GreaterThanOrEqual(Expression left, Expression right, bool liftToNull, MethodInfo method)
	{
		return GetLogicalBinary(ExpressionType.GreaterThanOrEqual, left, right, liftToNull, method);
	}

	public static BinaryExpression LessThan(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.LessThan, left, right);
	}

	public static BinaryExpression LessThan(Expression left, Expression right, bool liftToNull, MethodInfo method)
	{
		return GetLogicalBinary(ExpressionType.LessThan, left, right, liftToNull, method);
	}

	public static BinaryExpression LessThanOrEqual(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.LessThanOrEqual, left, right);
	}

	public static BinaryExpression LessThanOrEqual(Expression left, Expression right, bool liftToNull, MethodInfo method)
	{
		return GetLogicalBinary(ExpressionType.LessThanOrEqual, left, right, liftToNull, method);
	}

	public static BlockExpression Block(IEnumerable<Expression> expressions)
	{
		return new BlockExpression(expressions.AsReadOnlyList());
	}

	public static BlockExpression Block(params Expression[] expressions)
	{
		return new BlockExpression(expressions);
	}

	public static BlockExpression Block(Expression expr0)
	{
		return new BlockExpression(new Expression[1] { expr0 });
	}

	public static BlockExpression Block(Expression expr0, Expression expr1)
	{
		return new BlockExpression(new Expression[2] { expr0, expr1 });
	}

	public static BlockExpression Block(Expression expr0, Expression expr1, Expression expr2)
	{
		return new BlockExpression(new Expression[3] { expr0, expr1, expr2 });
	}

	public static BlockExpression Block(IEnumerable<ParameterExpression> variables, params Expression[] expressions)
	{
		return new ManyVariablesBlockExpression(variables.AsReadOnlyList(), expressions);
	}

	public static BlockExpression Block(IEnumerable<ParameterExpression> variables, Expression expr0)
	{
		return new ManyVariablesBlockExpression(variables.AsReadOnlyList(), new Expression[1] { expr0 });
	}

	public static BlockExpression Block(IEnumerable<ParameterExpression> variables, Expression expr0, Expression expr1)
	{
		return new ManyVariablesBlockExpression(variables.AsReadOnlyList(), new Expression[2] { expr0, expr1 });
	}

	public static BlockExpression Block(IEnumerable<ParameterExpression> variables, Expression expr0, Expression expr1, Expression expr2)
	{
		return new ManyVariablesBlockExpression(variables.AsReadOnlyList(), new Expression[3] { expr0, expr1, expr2 });
	}

	public static BlockExpression Block(IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions)
	{
		return new ManyVariablesBlockExpression(variables.AsReadOnlyList(), expressions.AsReadOnlyList());
	}

	public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, params Expression[] expressions)
	{
		return new TypedManyVariablesBlockExpression(type, variables.AsReadOnlyList(), expressions);
	}

	public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, Expression expr0)
	{
		return new TypedManyVariablesBlockExpression(type, variables.AsReadOnlyList(), new Expression[1] { expr0 });
	}

	public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, Expression expr0, Expression expr1)
	{
		return new TypedManyVariablesBlockExpression(type, variables.AsReadOnlyList(), new Expression[2] { expr0, expr1 });
	}

	public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, Expression expr0, Expression expr1, Expression expr2)
	{
		return new TypedManyVariablesBlockExpression(type, variables.AsReadOnlyList(), new Expression[3] { expr0, expr1, expr2 });
	}

	public static BlockExpression Block(Type type, IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions)
	{
		return new TypedManyVariablesBlockExpression(type, variables.AsReadOnlyList(), expressions.AsReadOnlyList());
	}

	public static BlockExpression MakeBlock(Type type, IEnumerable<ParameterExpression> variables, IEnumerable<Expression> expressions)
	{
		IReadOnlyList<ParameterExpression> readOnlyList = variables.AsReadOnlyList();
		IReadOnlyList<Expression> readOnlyList2 = expressions.AsReadOnlyList();
		Expression expression = readOnlyList2[readOnlyList2.Count - 1];
		if (expression.Type == type)
		{
			if (readOnlyList == null || readOnlyList.Count == 0)
			{
				return new BlockExpression(readOnlyList2);
			}
			return new ManyVariablesBlockExpression(readOnlyList, readOnlyList2);
		}
		if (readOnlyList == null || readOnlyList.Count == 0)
		{
			return new TypedBlockExpression(type, readOnlyList2);
		}
		return new TypedManyVariablesBlockExpression(type, readOnlyList, readOnlyList2);
	}

	public static Expression DebugInfo(SymbolDocumentInfo doc, int startLine, int startColumn, int endLine, int endColumn)
	{
		return new DebugInfoExpression(doc, startLine, startColumn, endLine, endColumn);
	}

	public static LoopExpression Loop(Expression body, LabelTarget @break = null)
	{
		return new LoopExpression(body, @break, null);
	}

	public static LoopExpression Loop(Expression body, LabelTarget @break, LabelTarget @continue)
	{
		return new LoopExpression(body, @break, @continue);
	}

	public static TryExpression TryCatch(Expression body, params CatchBlock[] handlers)
	{
		return new TryExpression(body, handlers);
	}

	public static TryExpression TryCatchFinally(Expression body, Expression @finally, params CatchBlock[] handlers)
	{
		return new WithFinallyTryExpression(body, handlers, @finally);
	}

	public static TryExpression TryFinally(Expression body, Expression @finally)
	{
		return new WithFinallyTryExpression(body, null, @finally);
	}

	public static CatchBlock Catch(ParameterExpression variable, Expression body)
	{
		return new CatchBlock(variable.Type, variable, body, null);
	}

	public static CatchBlock Catch(Type test, Expression body)
	{
		return new CatchBlock(test, null, body, null);
	}

	public static CatchBlock MakeCatchBlock(Type test, ParameterExpression variable, Expression body, Expression filter)
	{
		return new CatchBlock(test, variable, body, filter);
	}

	public static UnaryExpression Throw(Expression value)
	{
		return new ThrowUnaryExpression(value);
	}

	public static UnaryExpression Throw(Expression value, Type type)
	{
		return new TypedUnaryExpression(ExpressionType.Throw, value, type);
	}

	public static LabelExpression Label(LabelTarget target)
	{
		return new LabelExpression(target);
	}

	public static LabelExpression Label(LabelTarget target, Expression defaultValue)
	{
		if (defaultValue != null)
		{
			return new WithDefaultValueLabelExpression(target, defaultValue);
		}
		return new LabelExpression(target);
	}

	public static LabelTarget Label()
	{
		return new LabelTarget();
	}

	public static LabelTarget Label(Type type)
	{
		if (!(type == null))
		{
			return new TypedLabelTarget(type);
		}
		return new LabelTarget();
	}

	public static LabelTarget Label(string name)
	{
		if (name != null)
		{
			return new NamedLabelTarget(name);
		}
		return new LabelTarget();
	}

	public static LabelTarget Label(Type type, string name)
	{
		if (type == null)
		{
			if (name != null)
			{
				return new NamedLabelTarget(name);
			}
			return new LabelTarget();
		}
		if (name == null)
		{
			return new TypedLabelTarget(type);
		}
		return new TypedNamedLabelTarget(type, name);
	}

	public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right, LambdaExpression conversion = null)
	{
		switch (binaryType)
		{
		case ExpressionType.Add:
		case ExpressionType.AddChecked:
		case ExpressionType.Divide:
		case ExpressionType.Modulo:
		case ExpressionType.Multiply:
		case ExpressionType.MultiplyChecked:
		case ExpressionType.Subtract:
		case ExpressionType.SubtractChecked:
			return GetArithmeticBinary(binaryType, left, right);
		case ExpressionType.Power:
			return Power(left, right);
		case ExpressionType.And:
			return And(left, right);
		case ExpressionType.AndAlso:
			return AndAlso(left, right);
		case ExpressionType.Or:
			return Or(left, right);
		case ExpressionType.OrElse:
			return OrElse(left, right);
		case ExpressionType.LessThan:
			return LessThan(left, right);
		case ExpressionType.LessThanOrEqual:
			return LessThanOrEqual(left, right);
		case ExpressionType.GreaterThan:
			return GreaterThan(left, right);
		case ExpressionType.GreaterThanOrEqual:
			return GreaterThanOrEqual(left, right);
		case ExpressionType.Equal:
			return Equal(left, right);
		case ExpressionType.NotEqual:
			return NotEqual(left, right);
		case ExpressionType.ExclusiveOr:
			return ExclusiveOr(left, right);
		case ExpressionType.Coalesce:
			return Coalesce(left, right, conversion);
		case ExpressionType.ArrayIndex:
			return ArrayIndex(left, right);
		case ExpressionType.RightShift:
			return RightShift(left, right);
		case ExpressionType.LeftShift:
			return LeftShift(left, right);
		case ExpressionType.Assign:
			return Assign(left, right);
		case ExpressionType.AddAssign:
			return AddAssign(left, right);
		case ExpressionType.AndAssign:
			return AndAssign(left, right);
		case ExpressionType.DivideAssign:
			return DivideAssign(left, right);
		case ExpressionType.ExclusiveOrAssign:
			return ExclusiveOrAssign(left, right);
		case ExpressionType.LeftShiftAssign:
			return LeftShiftAssign(left, right);
		case ExpressionType.ModuloAssign:
			return ModuloAssign(left, right);
		case ExpressionType.MultiplyAssign:
			return MultiplyAssign(left, right);
		case ExpressionType.OrAssign:
			return OrAssign(left, right);
		case ExpressionType.PowerAssign:
			return PowerAssign(left, right);
		case ExpressionType.RightShiftAssign:
			return RightShiftAssign(left, right);
		case ExpressionType.SubtractAssign:
			return SubtractAssign(left, right);
		case ExpressionType.AddAssignChecked:
			return AddAssignChecked(left, right);
		case ExpressionType.SubtractAssignChecked:
			return SubtractAssignChecked(left, right);
		case ExpressionType.MultiplyAssignChecked:
			return MultiplyAssignChecked(left, right);
		default:
			throw new ArgumentException($"Unhandled binary node type: `{binaryType}`");
		}
	}

	public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left, Expression right, bool liftToNull, MethodInfo method, LambdaExpression conversion = null)
	{
		switch (binaryType)
		{
		case ExpressionType.Add:
		case ExpressionType.AddChecked:
		case ExpressionType.Divide:
		case ExpressionType.Modulo:
		case ExpressionType.Multiply:
		case ExpressionType.MultiplyChecked:
		case ExpressionType.Subtract:
		case ExpressionType.SubtractChecked:
			return GetArithmeticBinary(binaryType, left, right, method);
		case ExpressionType.And:
		case ExpressionType.AndAlso:
		case ExpressionType.Or:
		case ExpressionType.OrElse:
		case ExpressionType.Power:
			return GetLeftTypedBinary(binaryType, left, right, method);
		case ExpressionType.LessThan:
			return LessThan(left, right, liftToNull, method);
		case ExpressionType.LessThanOrEqual:
			return LessThanOrEqual(left, right, liftToNull, method);
		case ExpressionType.GreaterThan:
			return GreaterThan(left, right, liftToNull, method);
		case ExpressionType.GreaterThanOrEqual:
			return GreaterThanOrEqual(left, right, liftToNull, method);
		case ExpressionType.Equal:
			return Equal(left, right, liftToNull, method);
		case ExpressionType.NotEqual:
			return NotEqual(left, right, liftToNull, method);
		case ExpressionType.ExclusiveOr:
			return ExclusiveOr(left, right, method);
		case ExpressionType.Coalesce:
			return Coalesce(left, right, conversion);
		case ExpressionType.ArrayIndex:
			return ArrayIndex(left, right, method);
		case ExpressionType.RightShift:
			return RightShift(left, right, method);
		case ExpressionType.LeftShift:
			return LeftShift(left, right, method);
		case ExpressionType.Assign:
			return Assign(left, right);
		case ExpressionType.AddAssign:
		case ExpressionType.AndAssign:
		case ExpressionType.DivideAssign:
		case ExpressionType.ExclusiveOrAssign:
		case ExpressionType.LeftShiftAssign:
		case ExpressionType.ModuloAssign:
		case ExpressionType.MultiplyAssign:
		case ExpressionType.OrAssign:
		case ExpressionType.PowerAssign:
		case ExpressionType.RightShiftAssign:
		case ExpressionType.SubtractAssign:
		case ExpressionType.AddAssignChecked:
		case ExpressionType.MultiplyAssignChecked:
		case ExpressionType.SubtractAssignChecked:
			return new OpAssignMethodConversionBinaryExpression(binaryType, left, right, method, conversion, liftToNull);
		default:
			throw new ArgumentException($"Unhandled binary node type: `{binaryType}`");
		}
	}

	private static BinaryExpression GetUserDefinedBinaryOperatorOrThrow(ExpressionType binaryType, string name, Expression left, Expression right, bool liftToNull)
	{
		return GetUserDefinedBinaryOperator(binaryType, name, left, right, liftToNull) ?? throw new InvalidOperationException($"The binary operator {binaryType} is not defined for the types '{left.Type}' and '{right.Type}'.");
	}

	private static BinaryExpression GetUserDefinedBinaryOperator(ExpressionType binaryType, string name, Expression left, Expression right, bool liftToNull)
	{
		Type type = left.Type;
		Type type2 = right.Type;
		MethodInfo userDefinedBinaryOperator = GetUserDefinedBinaryOperator(binaryType, type, type2, name);
		if (userDefinedBinaryOperator != null)
		{
			return new MethodBinaryExpression(binaryType, left, right, userDefinedBinaryOperator.ReturnType, userDefinedBinaryOperator);
		}
		if (type.IsNullable() && type2.IsNullable())
		{
			Type nonNullableOrSelf = type.GetNonNullableOrSelf();
			Type nonNullableOrSelf2 = type2.GetNonNullableOrSelf();
			userDefinedBinaryOperator = GetUserDefinedBinaryOperator(binaryType, nonNullableOrSelf, nonNullableOrSelf2, name);
			if (userDefinedBinaryOperator != null && userDefinedBinaryOperator.ReturnType.IsValueType && !userDefinedBinaryOperator.ReturnType.IsNullable())
			{
				Type type3 = ((userDefinedBinaryOperator.ReturnType != typeof(bool) || liftToNull) ? userDefinedBinaryOperator.ReturnType.GetNullable() : typeof(bool));
				return new MethodBinaryExpression(binaryType, left, right, type3, userDefinedBinaryOperator);
			}
		}
		return null;
	}

	private static MethodInfo GetUserDefinedBinaryOperator(ExpressionType binaryType, Type leftType, Type rightType, string name)
	{
		Type[] array = new Type[2] { leftType, rightType };
		Type nonNullableOrSelf = leftType.GetNonNullableOrSelf();
		MethodInfo methodInfo = nonNullableOrSelf.GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, array, null).MatchesArgumentTypes(array);
		Type type = null;
		if (methodInfo == null && !leftType.IsEquivalentTo(rightType))
		{
			type = rightType.GetNonNullableOrSelf();
			methodInfo = type.GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, array, null).MatchesArgumentTypes(array);
		}
		if (methodInfo == null && rightType != type && leftType != nonNullableOrSelf && (binaryType == ExpressionType.AndAlso || binaryType == ExpressionType.OrElse))
		{
			methodInfo = GetUserDefinedBinaryOperator(binaryType, nonNullableOrSelf, type, name);
		}
		return methodInfo;
	}

	private static BinaryExpression GetMethodBasedBinaryOperator(ExpressionType binaryType, Expression left, Expression right, MethodInfo method, bool liftToNull)
	{
		Type type = left.Type;
		Type type2 = right.Type;
		if (method == null)
		{
			if (type == type2 && type.IsNumeric())
			{
				if (!(type.IsNullable() && liftToNull))
				{
					return new LeftTypedBinaryExpression(binaryType, left, right);
				}
				return new LiftedToNullBinaryExpression(binaryType, left, right);
			}
			throw new NotSupportedException($"The user-defined binary operator is not supported yet for {binaryType} left `{left}` and `{right}`");
		}
		ParameterInfo[] parameters = method.GetParameters();
		if (parameters.Length != 2)
		{
			throw new ArgumentException("IncorrectNumberOfMethodCallArguments in " + method, "method");
		}
		Type returnType = method.ReturnType;
		if (parameters[0].IsAssignableFrom(type) && parameters[1].IsAssignableFrom(type2))
		{
			return new MethodBinaryExpression(binaryType, left, right, returnType, method);
		}
		if (type.IsNullable() && type2.IsNullable() && parameters[0].IsAssignableFrom(type.GetNonNullable()) && parameters[1].IsAssignableFrom(type2.GetNonNullable()) && returnType.IsValueType && !returnType.IsNullable())
		{
			returnType = ((returnType != typeof(bool) || liftToNull) ? returnType.GetNullable() : typeof(bool));
			return new MethodBinaryExpression(binaryType, left, right, returnType, method);
		}
		throw new InvalidOperationException($"OperandTypesDoNotMatchParameters for {binaryType} and method {method.Name}");
	}

	public static GotoExpression MakeGoto(GotoExpressionKind kind, LabelTarget target, Expression value, Type type)
	{
		switch (kind)
		{
		case GotoExpressionKind.Return:
			if (value == null && type == null)
			{
				return new ReturnGotoExpression(target);
			}
			if (value == null)
			{
				return new ReturnTypedGotoExpression(target, type);
			}
			if (type == null)
			{
				return new ReturnValueGotoExpression(target, value);
			}
			return new ReturnTypedValueGotoExpression(target, value, type);
		case GotoExpressionKind.Break:
			if (value == null && type == null)
			{
				return new BreakGotoExpression(target);
			}
			if (value == null)
			{
				return new BreakTypedGotoExpression(target, type);
			}
			if (type == null)
			{
				return new BreakValueGotoExpression(target, value);
			}
			return new BreakTypedValueGotoExpression(target, value, type);
		case GotoExpressionKind.Continue:
			if (!(type == null))
			{
				return new ContinueTypedGotoExpression(target, type);
			}
			return new ContinueGotoExpression(target);
		default:
			if (value == null && type == null)
			{
				return new GotoExpression(target);
			}
			if (value == null)
			{
				return new TypedGotoExpression(target, type);
			}
			if (type == null)
			{
				return new ValueGotoExpression(target, value);
			}
			return new TypedValueGotoExpression(target, value, type);
		}
	}

	public static GotoExpression Goto(LabelTarget target)
	{
		return new GotoExpression(target);
	}

	public static GotoExpression Goto(LabelTarget target, Expression value)
	{
		if (value != null)
		{
			return new ValueGotoExpression(target, value);
		}
		return new GotoExpression(target);
	}

	public static GotoExpression Goto(LabelTarget target, Type type)
	{
		if (!(type == null))
		{
			return new TypedGotoExpression(target, type);
		}
		return new GotoExpression(target);
	}

	public static GotoExpression Goto(LabelTarget target, Expression value, Type type)
	{
		return MakeGoto(GotoExpressionKind.Goto, target, value, type);
	}

	public static GotoExpression Break(LabelTarget target)
	{
		return new BreakGotoExpression(target);
	}

	public static GotoExpression Break(LabelTarget target, Expression value)
	{
		if (value != null)
		{
			return new BreakValueGotoExpression(target, value);
		}
		return new BreakGotoExpression(target);
	}

	public static GotoExpression Break(LabelTarget target, Type type)
	{
		if (!(type == null))
		{
			return new BreakTypedGotoExpression(target, type);
		}
		return new BreakGotoExpression(target);
	}

	public static GotoExpression Break(LabelTarget target, Expression value, Type type)
	{
		return MakeGoto(GotoExpressionKind.Break, target, value, type);
	}

	public static GotoExpression Continue(LabelTarget target)
	{
		return new ContinueGotoExpression(target);
	}

	public static GotoExpression Continue(LabelTarget target, Type type)
	{
		if (!(type == null))
		{
			return new ContinueTypedGotoExpression(target, type);
		}
		return new ContinueGotoExpression(target);
	}

	public static GotoExpression Return(LabelTarget target)
	{
		return new ReturnGotoExpression(target);
	}

	public static GotoExpression Return(LabelTarget target, Type type)
	{
		if (!(type == null))
		{
			return new ReturnTypedGotoExpression(target, type);
		}
		return new ReturnGotoExpression(target);
	}

	public static GotoExpression Return(LabelTarget target, Expression value)
	{
		if (value != null)
		{
			return new ReturnValueGotoExpression(target, value);
		}
		return new ReturnGotoExpression(target);
	}

	public static GotoExpression Return(LabelTarget target, Expression value, Type type)
	{
		return MakeGoto(GotoExpressionKind.Return, target, value, type);
	}

	public static SwitchExpression Switch(Expression switchValue, Expression defaultBody, params SwitchCase[] cases)
	{
		return new SwitchExpression(defaultBody.Type, switchValue, defaultBody, cases);
	}

	public static SwitchExpression Switch(Expression switchValue, Expression defaultBody, MethodInfo comparison, params SwitchCase[] cases)
	{
		if (!(comparison == null))
		{
			return new WithComparisonSwitchExpression(defaultBody.Type, switchValue, defaultBody, cases, comparison);
		}
		return new SwitchExpression(defaultBody.Type, switchValue, defaultBody, cases);
	}

	public static SwitchExpression Switch(Type type, Expression switchValue, Expression defaultBody, MethodInfo comparison, params SwitchCase[] cases)
	{
		if (!(comparison == null))
		{
			return new WithComparisonSwitchExpression(type, switchValue, defaultBody, cases, comparison);
		}
		return new SwitchExpression(defaultBody.Type, switchValue, defaultBody, cases);
	}

	public static SwitchExpression Switch(Type type, Expression switchValue, Expression defaultBody, MethodInfo comparison, IEnumerable<SwitchCase> cases)
	{
		if (!(comparison == null))
		{
			return new WithComparisonSwitchExpression(type, switchValue, defaultBody, cases.AsArray(), comparison);
		}
		return new SwitchExpression(defaultBody.Type, switchValue, defaultBody, cases.AsArray());
	}

	public static SwitchExpression Switch(Expression switchValue, params SwitchCase[] cases)
	{
		return new SwitchExpression(null, switchValue, null, cases);
	}

	public static SwitchCase SwitchCase(Expression body, IEnumerable<Expression> testValues)
	{
		return new SwitchCase(body, testValues);
	}

	public static SwitchCase SwitchCase(Expression body, params Expression[] testValues)
	{
		return new SwitchCase(body, testValues);
	}

	public static BinaryExpression ReferenceEqual(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.Equal, left, right);
	}

	public static BinaryExpression ReferenceNotEqual(Expression left, Expression right)
	{
		return new LogicalBinaryExpression(ExpressionType.NotEqual, left, right);
	}

	public static BinaryExpression Coalesce(Expression left, Expression right)
	{
		return new CoalesceBinaryExpression(left, right, GetCoalesceType(left.Type, right.Type));
	}

	public static BinaryExpression Coalesce(Expression left, Expression right, Type type)
	{
		return new CoalesceBinaryExpression(left, right, type);
	}

	public static BinaryExpression Coalesce(Expression left, Expression right, LambdaExpression conversion)
	{
		if (conversion != null)
		{
			return new CoalesceConversionBinaryExpression(left, right, conversion);
		}
		return Coalesce(left, right);
	}

	private static Type GetCoalesceType(Type left, Type right)
	{
		TypeInfo typeInfo = left.GetTypeInfo();
		if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			left = typeInfo.GenericTypeArguments[0];
		}
		if (right == left)
		{
			return left;
		}
		if (typeInfo.IsAssignableFrom(right.GetTypeInfo()) || right.IsImplicitlyBoxingConvertibleTo(left) || right.IsImplicitlyNumericConvertibleTo(left))
		{
			return left;
		}
		if (right.GetTypeInfo().IsAssignableFrom(typeInfo) || left.IsImplicitlyBoxingConvertibleTo(right) || left.IsImplicitlyNumericConvertibleTo(right))
		{
			return right;
		}
		throw new ArgumentException($"Unable to coalesce arguments of left type of {left} and right type of {right}.");
	}

	public static SymbolDocumentInfo SymbolDocument(string fileName)
	{
		return new SymbolDocumentInfo(fileName);
	}
}
public class Expression<TDelegate> : LambdaExpression where TDelegate : Delegate
{
	public sealed override Type Type => typeof(TDelegate);

	internal Expression(Expression body)
		: base(body)
	{
	}

	public new System.Linq.Expressions.Expression<TDelegate> ToLambdaExpression()
	{
		LiveCountArray<LightAndSysExpr> exprsConverted = new LiveCountArray<LightAndSysExpr>(Tools.Empty<LightAndSysExpr>());
		return System.Linq.Expressions.Expression.Lambda<TDelegate>(Body.ToExpression(ref exprsConverted), ParameterExpression.ToParameterExpressions(Parameters, ref exprsConverted));
	}
}
