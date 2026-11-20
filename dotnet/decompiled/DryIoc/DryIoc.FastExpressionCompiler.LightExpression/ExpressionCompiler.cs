using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public static class ExpressionCompiler
{
	private struct BlockInfo
	{
		public object VarExprs;

		public int[] VarIndexes;
	}

	[Flags]
	public enum ClosureStatus : byte
	{
		ToBeCollected = 1,
		UserProvided = 2,
		HasClosure = 4,
		ShouldBeStaticMethod = 8
	}

	internal struct LabelInfo
	{
		public object Target;

		public Label Label;

		public Label ReturnLabel;

		public short ReturnVariableIndexPlusOneAndIsDefined;

		public short InlinedLambdaInvokeIndex;
	}

	public struct ClosureInfo
	{
		public bool LastEmitIsAddress;

		private LiveCountArray<BlockInfo> _blockStack;

		internal LiveCountArray<LabelInfo> Labels;

		internal short CurrentInlinedLambdaInvokeIndex;

		public ClosureStatus Status;

		public LiveCountArray<object> Constants;

		public LiveCountArray<short> ConstantUsageThenVarIndex;

		public ParameterExpression[] NonPassedParameters;

		public object NestedLambdaOrLambdas;

		public ClosureInfo(ClosureStatus status, object[] constValues = null, short[] constUsage = null)
		{
			Status = status;
			Constants = new LiveCountArray<object>(constValues ?? Tools.Empty<object>());
			ConstantUsageThenVarIndex = new LiveCountArray<short>((constValues == null) ? Tools.Empty<short>() : (constUsage ?? new short[constValues.Length]));
			NonPassedParameters = Tools.Empty<ParameterExpression>();
			NestedLambdaOrLambdas = null;
			LastEmitIsAddress = false;
			CurrentInlinedLambdaInvokeIndex = -1;
			Labels = new LiveCountArray<LabelInfo>(Tools.Empty<LabelInfo>());
			_blockStack = new LiveCountArray<BlockInfo>(Tools.Empty<BlockInfo>());
		}

		public bool ContainsConstantsOrNestedLambdas()
		{
			if (Constants.Count <= 0)
			{
				return NestedLambdaOrLambdas != null;
			}
			return true;
		}

		public bool AddConstantOrIncrementUsageCount(object value)
		{
			Status |= ClosureStatus.HasClosure;
			object[] items = Constants.Items;
			int num = Constants.Count - 1;
			while (num != -1 && items[num] != value)
			{
				num--;
			}
			if (num == -1)
			{
				Constants.PushSlot(value);
				ConstantUsageThenVarIndex.PushSlot(1);
			}
			else
			{
				ConstantUsageThenVarIndex.Items[num]++;
			}
			return true;
		}

		public void AddNonPassedParam(ParameterExpression expr)
		{
			Status |= ClosureStatus.HasClosure;
			if (NonPassedParameters.Length == 0)
			{
				NonPassedParameters = new ParameterExpression[1] { expr };
				return;
			}
			ParameterExpression[] nonPassedParameters = NonPassedParameters;
			int num = nonPassedParameters.Length;
			for (int i = 0; i < num; i++)
			{
				if (nonPassedParameters[i] == expr)
				{
					return;
				}
			}
			Array.Resize(ref NonPassedParameters, num + 1);
			NonPassedParameters[num] = expr;
		}

		public void AddNestedLambda(NestedLambdaInfo nestedLambdaInfo)
		{
			Status |= ClosureStatus.HasClosure;
			object nestedLambdaOrLambdas = NestedLambdaOrLambdas;
			if (nestedLambdaOrLambdas == null)
			{
				NestedLambdaOrLambdas = nestedLambdaInfo;
			}
			else if (nestedLambdaOrLambdas is NestedLambdaInfo nestedLambdaInfo2)
			{
				NestedLambdaOrLambdas = new NestedLambdaInfo[2] { nestedLambdaInfo2, nestedLambdaInfo };
			}
			else
			{
				NestedLambdaInfo[] array = (NestedLambdaInfo[])nestedLambdaOrLambdas;
				int num = array.Length;
				Array.Resize(ref array, num + 1);
				array[num] = nestedLambdaInfo;
				NestedLambdaOrLambdas = array;
			}
		}

		public short GetLabelOrInvokeIndex(object labelTarget)
		{
			int count = Labels.Count;
			LabelInfo[] items = Labels.Items;
			for (short num = 0; num < count; num++)
			{
				if (items[num].Target == labelTarget)
				{
					return num;
				}
			}
			return -1;
		}

		public void AddLabel(LabelTarget labelTarget, short inlinedLambdaInvokeIndex = -1)
		{
			if (GetLabelOrInvokeIndex(labelTarget) == -1)
			{
				ref LabelInfo reference = ref Labels.PushSlot();
				reference.Target = labelTarget;
				reference.InlinedLambdaInvokeIndex = inlinedLambdaInvokeIndex;
			}
		}

		public short AddInlinedLambdaInvoke(InvocationExpression e)
		{
			short num = GetLabelOrInvokeIndex(e);
			if (num == -1)
			{
				Labels.PushSlot().Target = e;
				num = (short)(Labels.Count - 1);
			}
			return num;
		}

		public Label GetDefinedLabel(int index, ILGenerator il)
		{
			ref LabelInfo reference = ref Labels.Items[index];
			if ((reference.ReturnVariableIndexPlusOneAndIsDefined & 1) == 0)
			{
				reference.ReturnVariableIndexPlusOneAndIsDefined |= 1;
				reference.Label = il.DefineLabel();
			}
			return reference.Label;
		}

		public void TryMarkDefinedLabel(int index, ILGenerator il)
		{
			ref LabelInfo reference = ref Labels.Items[index];
			if ((reference.ReturnVariableIndexPlusOneAndIsDefined & 1) == 1)
			{
				il.MarkLabel(reference.Label);
				return;
			}
			reference.ReturnVariableIndexPlusOneAndIsDefined |= 1;
			il.MarkLabel(reference.Label = il.DefineLabel());
		}

		private static object GetLambdaObject(NestedLambdaInfo nestedLambda)
		{
			if (nestedLambda.ClosureInfo.NonPassedParameters.Length != 0 && nestedLambda.ClosureInfo.ContainsConstantsOrNestedLambdas())
			{
				return new NestedLambdaWithConstantsAndNestedLambdas(nestedLambda.Lambda, nestedLambda.ClosureInfo.GetArrayOfConstantsAndNestedLambdas());
			}
			return nestedLambda.Lambda;
		}

		public object[] GetArrayOfConstantsAndNestedLambdas()
		{
			int count = Constants.Count;
			object nestedLambdaOrLambdas = NestedLambdaOrLambdas;
			if (count == 0)
			{
				if (nestedLambdaOrLambdas == null)
				{
					return null;
				}
				if (nestedLambdaOrLambdas is NestedLambdaInfo nestedLambda)
				{
					return new object[1] { GetLambdaObject(nestedLambda) };
				}
				NestedLambdaInfo[] array = (NestedLambdaInfo[])nestedLambdaOrLambdas;
				object[] array2 = new object[array.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = GetLambdaObject(array[i]);
				}
				return array2;
			}
			object[] array3 = Constants.Items;
			if (nestedLambdaOrLambdas == null)
			{
				if (array3.Length != count)
				{
					Array.Resize(ref array3, count);
				}
				return array3;
			}
			NestedLambdaInfo[] array4 = nestedLambdaOrLambdas as NestedLambdaInfo[];
			int num = ((array4 == null) ? 1 : array4.Length);
			int num2 = count + num;
			if (array3.Length != num2)
			{
				Array.Resize(ref array3, num2);
			}
			if (array4 == null)
			{
				array3[count] = GetLambdaObject((NestedLambdaInfo)nestedLambdaOrLambdas);
			}
			else
			{
				for (int j = 0; j < array4.Length; j++)
				{
					array3[count + j] = GetLambdaObject(array4[j]);
				}
			}
			return array3;
		}

		public void PushBlockWithVars(ParameterExpression blockVarExpr)
		{
			_blockStack.PushSlot().VarExprs = blockVarExpr;
		}

		public void PushBlockWithVars(ParameterExpression blockVarExpr, int varIndex)
		{
			ref BlockInfo reference = ref _blockStack.PushSlot();
			reference.VarExprs = blockVarExpr;
			reference.VarIndexes = new int[1] { varIndex };
		}

		public void PushBlockWithVars(IReadOnlyList<ParameterExpression> blockVarExprs, int[] localVarIndexes = null)
		{
			ref BlockInfo reference = ref _blockStack.PushSlot();
			reference.VarExprs = blockVarExprs;
			reference.VarIndexes = localVarIndexes;
		}

		public void PushBlockAndConstructLocalVars(IReadOnlyList<ParameterExpression> blockVarExprs, ILGenerator il)
		{
			int[] array = new int[blockVarExprs.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = il.GetNextLocalVarIndex(blockVarExprs[i].Type);
			}
			PushBlockWithVars(blockVarExprs, array);
		}

		public void PopBlock()
		{
			_blockStack.Pop();
		}

		public bool IsLocalVar(object varParamExpr)
		{
			for (int num = _blockStack.Count - 1; num > -1; num--)
			{
				object varExprs = _blockStack.Items[num].VarExprs;
				if (varExprs == varParamExpr)
				{
					return true;
				}
				if (varExprs is IReadOnlyList<ParameterExpression> readOnlyList)
				{
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						if (readOnlyList[i] == varParamExpr)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public int GetDefinedLocalVarOrDefault(ParameterExpression varParamExpr)
		{
			for (int num = _blockStack.Count - 1; num > -1; num--)
			{
				ref BlockInfo reference = ref _blockStack.Items[num];
				object varExprs = reference.VarExprs;
				if (varExprs == varParamExpr)
				{
					return reference.VarIndexes[0];
				}
				if (varExprs is IReadOnlyList<ParameterExpression> readOnlyList)
				{
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						if (readOnlyList[i] == varParamExpr)
						{
							return reference.VarIndexes[i];
						}
					}
				}
			}
			return -1;
		}
	}

	public class ArrayClosure
	{
		public readonly object[] ConstantsAndNestedLambdas;

		public ArrayClosure(object[] constantsAndNestedLambdas)
		{
			ConstantsAndNestedLambdas = constantsAndNestedLambdas;
		}
	}

	public sealed class DebugArrayClosure : ArrayClosure, IDelegateDebugInfo
	{
		private readonly Lazy<string> _expressionString;

		private readonly Lazy<string> _csharpString;

		public LambdaExpression Expression { get; internal set; }

		public string ExpressionString => _expressionString.Value;

		public string CSharpString => _csharpString.Value;

		public DebugArrayClosure(object[] constantsAndNestedLambdas, LambdaExpression expr)
			: base(constantsAndNestedLambdas)
		{
			Expression = expr;
			_expressionString = new Lazy<string>(() => Expression?.ToExpressionString() ?? "<expression is not available>");
			_csharpString = new Lazy<string>(() => Expression?.ToCSharpString() ?? "<expression is not available>");
		}
	}

	public sealed class ArrayClosureWithNonPassedParams : ArrayClosure
	{
		public readonly object[] NonPassedParams;

		public ArrayClosureWithNonPassedParams(object[] constantsAndNestedLambdas, object[] nonPassedParams)
			: base(constantsAndNestedLambdas)
		{
			NonPassedParams = nonPassedParams;
		}

		public ArrayClosureWithNonPassedParams(object[] nonPassedParams)
			: base(null)
		{
			NonPassedParams = nonPassedParams;
		}
	}

	public sealed class NestedLambdaWithConstantsAndNestedLambdas
	{
		public static FieldInfo NestedLambdaField = typeof(NestedLambdaWithConstantsAndNestedLambdas).GetTypeInfo().GetDeclaredField("NestedLambda");

		public static FieldInfo ConstantsAndNestedLambdasField = typeof(NestedLambdaWithConstantsAndNestedLambdas).GetTypeInfo().GetDeclaredField("ConstantsAndNestedLambdas");

		public readonly object NestedLambda;

		public readonly object ConstantsAndNestedLambdas;

		public NestedLambdaWithConstantsAndNestedLambdas(object nestedLambda, object constantsAndNestedLambdas)
		{
			NestedLambda = nestedLambda;
			ConstantsAndNestedLambdas = constantsAndNestedLambdas;
		}
	}

	public sealed class NestedLambdaInfo
	{
		public readonly LambdaExpression LambdaExpression;

		public ClosureInfo ClosureInfo;

		public object Lambda;

		public int LambdaVarIndex;

		public NestedLambdaInfo(LambdaExpression lambdaExpression)
		{
			LambdaExpression = lambdaExpression;
			ClosureInfo = new ClosureInfo(ClosureStatus.ToBeCollected);
			Lambda = null;
		}
	}

	internal static class CurryClosureFuncs
	{
		public static readonly MethodInfo[] Methods = typeof(CurryClosureFuncs).GetMethods();

		public static Func<R> Curry<C, R>(Func<C, R> f, C c)
		{
			return () => f(c);
		}

		public static Func<T1, R> Curry<C, T1, R>(Func<C, T1, R> f, C c)
		{
			return (T1 t1) => f(c, t1);
		}

		public static Func<T1, T2, R> Curry<C, T1, T2, R>(Func<C, T1, T2, R> f, C c)
		{
			return (T1 t1, T2 t2) => f(c, t1, t2);
		}

		public static Func<T1, T2, T3, R> Curry<C, T1, T2, T3, R>(Func<C, T1, T2, T3, R> f, C c)
		{
			return (T1 t1, T2 t2, T3 t3) => f(c, t1, t2, t3);
		}

		public static Func<T1, T2, T3, T4, R> Curry<C, T1, T2, T3, T4, R>(Func<C, T1, T2, T3, T4, R> f, C c)
		{
			return (T1 t1, T2 t2, T3 t3, T4 t4) => f(c, t1, t2, t3, t4);
		}

		public static Func<T1, T2, T3, T4, T5, R> Curry<C, T1, T2, T3, T4, T5, R>(Func<C, T1, T2, T3, T4, T5, R> f, C c)
		{
			return (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => f(c, t1, t2, t3, t4, t5);
		}

		public static Func<T1, T2, T3, T4, T5, T6, R> Curry<C, T1, T2, T3, T4, T5, T6, R>(Func<C, T1, T2, T3, T4, T5, T6, R> f, C c)
		{
			return (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => f(c, t1, t2, t3, t4, t5, t6);
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, R> Curry<C, T1, T2, T3, T4, T5, T6, T7, R>(Func<C, T1, T2, T3, T4, T5, T6, T7, R> f, C c)
		{
			return (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => f(c, t1, t2, t3, t4, t5, t6, t7);
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, R> Curry<C, T1, T2, T3, T4, T5, T6, T7, T8, R>(Func<C, T1, T2, T3, T4, T5, T6, T7, T8, R> f, C c)
		{
			return (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => f(c, t1, t2, t3, t4, t5, t6, t7, t8);
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> Curry<C, T1, T2, T3, T4, T5, T6, T7, T8, T9, R>(Func<C, T1, T2, T3, T4, T5, T6, T7, T8, T9, R> f, C c)
		{
			return (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9) => f(c, t1, t2, t3, t4, t5, t6, t7, t8, t9);
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> Curry<C, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>(Func<C, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> f, C c)
		{
			return (T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10) => f(c, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
		}
	}

	internal static class CurryClosureActions
	{
		public static readonly MethodInfo[] Methods = typeof(CurryClosureActions).GetMethods();

		public static Action Curry<C>(Action<C> a, C c)
		{
			return delegate
			{
				a(c);
			};
		}

		public static Action<T1> Curry<C, T1>(Action<C, T1> f, C c)
		{
			return delegate(T1 t1)
			{
				f(c, t1);
			};
		}

		public static Action<T1, T2> Curry<C, T1, T2>(Action<C, T1, T2> f, C c)
		{
			return delegate(T1 t1, T2 t2)
			{
				f(c, t1, t2);
			};
		}

		public static Action<T1, T2, T3> Curry<C, T1, T2, T3>(Action<C, T1, T2, T3> f, C c)
		{
			return delegate(T1 t1, T2 t2, T3 t3)
			{
				f(c, t1, t2, t3);
			};
		}

		public static Action<T1, T2, T3, T4> Curry<C, T1, T2, T3, T4>(Action<C, T1, T2, T3, T4> f, C c)
		{
			return delegate(T1 t1, T2 t2, T3 t3, T4 t4)
			{
				f(c, t1, t2, t3, t4);
			};
		}

		public static Action<T1, T2, T3, T4, T5> Curry<C, T1, T2, T3, T4, T5>(Action<C, T1, T2, T3, T4, T5> f, C c)
		{
			return delegate(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
			{
				f(c, t1, t2, t3, t4, t5);
			};
		}

		public static Action<T1, T2, T3, T4, T5, T6> Curry<C, T1, T2, T3, T4, T5, T6>(Action<C, T1, T2, T3, T4, T5, T6> f, C c)
		{
			return delegate(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
			{
				f(c, t1, t2, t3, t4, t5, t6);
			};
		}

		public static Action<T1, T2, T3, T4, T5, T6, T7> Curry<C, T1, T2, T3, T4, T5, T6, T7>(Action<C, T1, T2, T3, T4, T5, T6, T7> f, C c)
		{
			return delegate(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
			{
				f(c, t1, t2, t3, t4, t5, t6, t7);
			};
		}

		public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Curry<C, T1, T2, T3, T4, T5, T6, T7, T8>(Action<C, T1, T2, T3, T4, T5, T6, T7, T8> f, C c)
		{
			return delegate(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
			{
				f(c, t1, t2, t3, t4, t5, t6, t7, t8);
			};
		}

		public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Curry<C, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<C, T1, T2, T3, T4, T5, T6, T7, T8, T9> f, C c)
		{
			return delegate(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
			{
				f(c, t1, t2, t3, t4, t5, t6, t7, t8, t9);
			};
		}

		public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Curry<C, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<C, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> f, C c)
		{
			return delegate(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
			{
				f(c, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
			};
		}
	}

	[Flags]
	public enum ParentFlags : ushort
	{
		Empty = 0,
		IgnoreResult = 2,
		Call = 4,
		MemberAccess = 8,
		Arithmetic = 0x10,
		Coalesce = 0x20,
		InstanceAccess = 0x40,
		DupMemberOwner = 0x80,
		TryCatch = 0x100,
		InstanceCall = 0x44,
		CtorCall = 0x204,
		IndexAccess = 0x400,
		InlinedLambdaInvoke = 0x800
	}

	public static class EmittingVisitor
	{
		private static readonly MethodInfo _getTypeFromHandleMethod = new Func<RuntimeTypeHandle, Type>(Type.GetTypeFromHandle).Method;

		private static readonly MethodInfo _objectEqualsMethod = new Func<object, object, bool>(object.Equals).Method;

		private static readonly Lazy<ConstructorInfo> _decimalCtor = new Lazy<ConstructorInfo>(delegate
		{
			foreach (ConstructorInfo declaredConstructor in typeof(decimal).GetTypeInfo().DeclaredConstructors)
			{
				if (declaredConstructor.GetParameters().Length == 5)
				{
					return declaredConstructor;
				}
			}
			return (ConstructorInfo)null;
		});

		public static bool TryEmit(Expression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent, int byRefIndex = -1)
		{
			while (true)
			{
				closure.LastEmitIsAddress = false;
				if (expr.IsIntrinsic)
				{
					break;
				}
				switch (expr.NodeType)
				{
				case ExpressionType.Parameter:
					if ((parent & ParentFlags.IgnoreResult) == 0)
					{
						return TryEmitParameter((ParameterExpression)expr, paramExprs, il, ref closure, parent, byRefIndex);
					}
					return true;
				case ExpressionType.Negate:
				case ExpressionType.UnaryPlus:
				case ExpressionType.NegateChecked:
				case ExpressionType.TypeAs:
				case ExpressionType.Decrement:
				case ExpressionType.Increment:
				case ExpressionType.Unbox:
				case ExpressionType.OnesComplement:
				case ExpressionType.IsTrue:
				case ExpressionType.IsFalse:
					return TryEmitSimpleUnaryExpression((UnaryExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.TypeIs:
				case ExpressionType.TypeEqual:
					return TryEmitTypeIsOrEqual((TypeBinaryExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Not:
					return TryEmitNot((UnaryExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
					return TryEmitConvert((UnaryExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.ArrayIndex:
				{
					BinaryExpression binaryExpression2 = (BinaryExpression)expr;
					if (TryEmit(binaryExpression2.Left, paramExprs, il, ref closure, setup, parent | ParentFlags.IndexAccess) && TryEmit(binaryExpression2.Right, paramExprs, il, ref closure, setup, parent | ParentFlags.IndexAccess))
					{
						return TryEmitArrayIndex(expr.Type, il, parent, ref closure);
					}
					return false;
				}
				case ExpressionType.ArrayLength:
					if (!TryEmit(((UnaryExpression)expr).Operand, paramExprs, il, ref closure, setup, parent))
					{
						return false;
					}
					if ((parent & ParentFlags.IgnoreResult) == 0)
					{
						il.Emit(OpCodes.Ldlen);
					}
					return true;
				case ExpressionType.Constant:
				{
					if ((parent & ParentFlags.IgnoreResult) != ParentFlags.Empty)
					{
						return true;
					}
					if (expr is IntConstantExpression intConstantExpression)
					{
						EmitLoadConstantInt(il, intConstantExpression.IntValue);
						return true;
					}
					ConstantExpression constantExpression = (ConstantExpression)expr;
					if (constantExpression.Value == null)
					{
						if (constantExpression.Type.IsValueType)
						{
							EmitLoadLocalVariable(il, InitValueTypeVariable(il, constantExpression.Type));
						}
						else
						{
							il.Emit(OpCodes.Ldnull);
						}
						return true;
					}
					return TryEmitConstantOfNotNullValue(closure.ContainsConstantsOrNestedLambdas(), constantExpression.Type, constantExpression.Value, il, ref closure, byRefIndex);
				}
				case ExpressionType.Call:
					return TryEmitMethodCall(expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.MemberAccess:
					return TryEmitMemberAccess((MemberExpression)expr, paramExprs, il, ref closure, setup, parent, byRefIndex);
				case ExpressionType.New:
					return TryEmitNew(expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.NewArrayBounds:
					return EmitNewArrayBounds((NewArrayExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.NewArrayInit:
					return EmitNewArrayInit((NewArrayExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.MemberInit:
					return EmitMemberInit((MemberInitExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.ListInit:
					return TryEmitListInit((ListInitExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Lambda:
					return TryEmitNestedLambda((LambdaExpression)expr, paramExprs, il, ref closure);
				case ExpressionType.Invoke:
					return TryEmitInvoke((InvocationExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Equal:
				case ExpressionType.GreaterThan:
				case ExpressionType.GreaterThanOrEqual:
				case ExpressionType.LessThan:
				case ExpressionType.LessThanOrEqual:
				case ExpressionType.NotEqual:
				{
					BinaryExpression binaryExpression = (BinaryExpression)expr;
					return TryEmitComparison(binaryExpression.Left, binaryExpression.Right, binaryExpression.NodeType, expr.Type, paramExprs, il, ref closure, setup, parent);
				}
				case ExpressionType.Add:
				case ExpressionType.AddChecked:
				case ExpressionType.And:
				case ExpressionType.Divide:
				case ExpressionType.ExclusiveOr:
				case ExpressionType.LeftShift:
				case ExpressionType.Modulo:
				case ExpressionType.Multiply:
				case ExpressionType.MultiplyChecked:
				case ExpressionType.Or:
				case ExpressionType.Power:
				case ExpressionType.RightShift:
				case ExpressionType.Subtract:
				case ExpressionType.SubtractChecked:
					return TryEmitArithmetic((BinaryExpression)expr, expr.NodeType, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.AndAlso:
				case ExpressionType.OrElse:
					return TryEmitLogicalOperator((BinaryExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Coalesce:
					return TryEmitCoalesceOperator((BinaryExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Conditional:
					return TryEmitConditional((ConditionalExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.PreIncrementAssign:
				case ExpressionType.PreDecrementAssign:
				case ExpressionType.PostIncrementAssign:
				case ExpressionType.PostDecrementAssign:
					return TryEmitIncDecAssign((UnaryExpression)expr, expr.NodeType, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Assign:
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
					return TryEmitAssign((BinaryExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Block:
				{
					BlockExpression blockExpression = (BlockExpression)expr;
					IReadOnlyList<ParameterExpression> variables = blockExpression.Variables;
					int count = variables.Count;
					if (count == 1)
					{
						closure.PushBlockWithVars(variables[0], il.GetNextLocalVarIndex(variables[0].Type));
					}
					else if (count > 1)
					{
						closure.PushBlockAndConstructLocalVars(variables, il);
					}
					IReadOnlyList<Expression> expressions = blockExpression.Expressions;
					int num = expressions.Count;
					if (num == 0)
					{
						return true;
					}
					expr = expressions[num - 1];
					if (num > 1)
					{
						int num2 = num - 1;
						while (num2 != -1 && expressions[num2].NodeType != ExpressionType.Throw)
						{
							num2--;
						}
						if (num2 != -1 && num2 != num - 1)
						{
							expr = Expression.Throw(((UnaryExpression)expressions[num2]).Operand, blockExpression.Type);
							num = num2 + 1;
						}
					}
					if (num > 1)
					{
						for (int i = 0; i < num - 1; i++)
						{
							Expression expression = expressions[i];
							if (expression.NodeType == ExpressionType.Default && expression.Type == typeof(void))
							{
								continue;
							}
							if (expression is GotoExpression { Kind: GotoExpressionKind.Return } gotoExpression && expressions[i + 1] is LabelExpression labelExpression && labelExpression.Target == gotoExpression.Target)
							{
								if ((parent & ParentFlags.TryCatch) != ParentFlags.Empty)
								{
									if ((setup & CompilerFlags.ThrowOnNotSupportedExpression) != CompilerFlags.Default)
									{
										throw new NotSupportedExpressionException(NotSupported.Try_GotoReturnToTheFollowupLabel);
									}
									return false;
								}
								Expression expression2 = gotoExpression.Value ?? labelExpression.DefaultValue;
								if (expression2 != null)
								{
									if (!TryEmit(expression2, paramExprs, il, ref closure, setup, parent & ~ParentFlags.IgnoreResult))
									{
										return false;
									}
									if ((parent & ParentFlags.InlinedLambdaInvoke) != ParentFlags.Empty)
									{
										short labelOrInvokeIndex = closure.GetLabelOrInvokeIndex(gotoExpression.Target);
										short inlinedLambdaInvokeIndex = closure.Labels.Items[labelOrInvokeIndex].InlinedLambdaInvokeIndex;
										if (inlinedLambdaInvokeIndex == -1)
										{
											return false;
										}
										ref LabelInfo reference = ref closure.Labels.Items[inlinedLambdaInvokeIndex];
										short num3 = (short)((reference.ReturnVariableIndexPlusOneAndIsDefined >> 1) - 1);
										if (num3 == -1)
										{
											num3 = (short)il.GetNextLocalVarIndex(expression2.Type);
											reference.ReturnVariableIndexPlusOneAndIsDefined = (short)(num3 + 1 << 1);
											reference.ReturnLabel = il.DefineLabel();
										}
										EmitStoreLocalVariable(il, num3);
										il.Emit(OpCodes.Br, reference.ReturnLabel);
									}
									else if ((parent & ParentFlags.IgnoreResult) != ParentFlags.Empty)
									{
										il.Emit(OpCodes.Ret);
									}
								}
								return true;
							}
							if (!TryEmit(expression, paramExprs, il, ref closure, setup, parent | ParentFlags.IgnoreResult))
							{
								return false;
							}
						}
					}
					if (count != 0)
					{
						if (!TryEmit(expr, paramExprs, il, ref closure, setup, parent))
						{
							return false;
						}
						closure.PopBlock();
						return true;
					}
					break;
				}
				case ExpressionType.Loop:
					return TryEmitLoop((LoopExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Try:
					return TryEmitTryCatchFinallyBlock((TryExpression)expr, paramExprs, il, ref closure, setup, parent | ParentFlags.TryCatch);
				case ExpressionType.Throw:
					if (!TryEmit(((UnaryExpression)expr).Operand, paramExprs, il, ref closure, setup, parent & ~ParentFlags.IgnoreResult))
					{
						return false;
					}
					il.Emit(OpCodes.Throw);
					return true;
				case ExpressionType.Default:
					if (expr.Type != typeof(void) && (parent & ParentFlags.IgnoreResult) == 0)
					{
						EmitDefault(expr.Type, il);
					}
					return true;
				case ExpressionType.Index:
					return TryEmitIndex((IndexExpression)expr, paramExprs, il, ref closure, setup, parent | ParentFlags.IndexAccess);
				case ExpressionType.Goto:
					return TryEmitGoto((GotoExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Label:
					return TryEmitLabel((LabelExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Switch:
					return TryEmitSwitch((SwitchExpression)expr, paramExprs, il, ref closure, setup, parent);
				case ExpressionType.Extension:
					expr = expr.Reduce();
					break;
				case ExpressionType.DebugInfo:
					return true;
				default:
					return false;
				}
			}
			return expr.TryEmit(setup, ref closure, paramExprs, il, parent, byRefIndex);
		}

		private static bool TryEmitNew(Expression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			parent |= ParentFlags.CtorCall;
			NewExpression newExpression = (NewExpression)expr;
			IArgumentProvider argumentProvider = newExpression;
			int argumentCount = argumentProvider.ArgumentCount;
			ConstructorInfo constructor = newExpression.Constructor;
			if (argumentCount > 0)
			{
				ParameterInfo[] array = (newExpression.NoByRefArgs ? null : constructor.GetParameters());
				if (array == null)
				{
					for (int i = 0; i < argumentCount; i++)
					{
						if (!TryEmit(argumentProvider.GetArgument(i), paramExprs, il, ref closure, setup, parent))
						{
							return false;
						}
					}
				}
				else
				{
					for (int j = 0; j < argumentCount; j++)
					{
						if (!TryEmit(argumentProvider.GetArgument(j), paramExprs, il, ref closure, setup, parent, array[j].ParameterType.IsByRef ? j : (-1)))
						{
							return false;
						}
					}
				}
			}
			if (constructor != null)
			{
				il.Emit(OpCodes.Newobj, constructor);
			}
			else
			{
				if (!newExpression.Type.IsValueType)
				{
					return false;
				}
				EmitLoadLocalVariable(il, InitValueTypeVariable(il, newExpression.Type));
			}
			return true;
		}

		private static bool TryEmitLoop(LoopExpression loopExpr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Label label = il.DefineLabel();
			il.MarkLabel(label);
			if (loopExpr.ContinueLabel != null)
			{
				closure.TryMarkDefinedLabel(closure.GetLabelOrInvokeIndex(loopExpr.ContinueLabel), il);
			}
			if (!TryEmit(loopExpr.Body, paramExprs, il, ref closure, setup, parent))
			{
				return false;
			}
			il.Emit(OpCodes.Br, label);
			if (loopExpr.BreakLabel != null)
			{
				closure.TryMarkDefinedLabel(closure.GetLabelOrInvokeIndex(loopExpr.BreakLabel), il);
			}
			return true;
		}

		private static bool TryEmitIndex(IndexExpression indexExpr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			if (indexExpr.Object != null && !TryEmit(indexExpr.Object, paramExprs, il, ref closure, setup, parent))
			{
				return false;
			}
			int argumentCount = ((IArgumentProvider)indexExpr).ArgumentCount;
			PropertyInfo indexer = indexExpr.Indexer;
			MethodInfo methodInfo = null;
			if (indexer != null)
			{
				methodInfo = indexer.GetMethod;
			}
			ParentFlags parent2 = parent | ParentFlags.IndexAccess;
			if (methodInfo == null)
			{
				for (int i = 0; i < argumentCount; i++)
				{
					if (!TryEmit(((IArgumentProvider)indexExpr).GetArgument(i), paramExprs, il, ref closure, setup, parent2))
					{
						return false;
					}
				}
			}
			else
			{
				ParameterInfo[] parameters = methodInfo.GetParameters();
				for (int j = 0; j < argumentCount; j++)
				{
					if (!TryEmit(((IArgumentProvider)indexExpr).GetArgument(j), paramExprs, il, ref closure, setup, parent2, parameters[j].ParameterType.IsByRef ? j : (-1)))
					{
						return false;
					}
				}
			}
			if (methodInfo != null)
			{
				return EmitMethodCallOrVirtualCall(il, methodInfo);
			}
			if (argumentCount == 1)
			{
				return TryEmitArrayIndex(indexExpr.Type, il, parent, ref closure);
			}
			methodInfo = indexExpr.Object?.Type.FindMethod("Get");
			if (methodInfo != null)
			{
				return EmitMethodCallOrVirtualCall(il, methodInfo);
			}
			return false;
		}

		private static bool TryEmitLabel(LabelExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			short labelOrInvokeIndex = closure.GetLabelOrInvokeIndex(expr.Target);
			if (labelOrInvokeIndex == -1)
			{
				return false;
			}
			ref LabelInfo reference = ref closure.Labels.Items[labelOrInvokeIndex];
			if ((reference.ReturnVariableIndexPlusOneAndIsDefined & 1) == 1)
			{
				il.MarkLabel(reference.Label);
			}
			else
			{
				reference.ReturnVariableIndexPlusOneAndIsDefined |= 1;
				il.MarkLabel(reference.Label = il.DefineLabel());
			}
			Expression defaultValue = expr.DefaultValue;
			if (defaultValue != null)
			{
				TryEmit(defaultValue, paramExprs, il, ref closure, setup, parent);
			}
			int num = reference.ReturnVariableIndexPlusOneAndIsDefined >> 1;
			if (num != 0)
			{
				if (defaultValue != null)
				{
					EmitStoreLocalVariable(il, num - 1);
				}
				il.MarkLabel(reference.ReturnLabel);
				if (!parent.IgnoresResult())
				{
					EmitLoadLocalVariable(il, num - 1);
				}
			}
			return true;
		}

		private static bool TryEmitGoto(GotoExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			short labelOrInvokeIndex = closure.GetLabelOrInvokeIndex(expr.Target);
			if (labelOrInvokeIndex == -1)
			{
				if ((closure.Status & ClosureStatus.ToBeCollected) == 0)
				{
					return false;
				}
				throw new InvalidOperationException($"Cannot jump, no labels found for the target `{expr.Target}`");
			}
			Expression value = expr.Value;
			if (value != null && !TryEmit(value, paramExprs, il, ref closure, setup, parent & ~ParentFlags.IgnoreResult))
			{
				return false;
			}
			switch (expr.Kind)
			{
			case GotoExpressionKind.Break:
			case GotoExpressionKind.Continue:
				il.Emit(OpCodes.Br, closure.GetDefinedLabel(labelOrInvokeIndex, il));
				return true;
			case GotoExpressionKind.Goto:
				if (value == null)
				{
					il.Emit(OpCodes.Br, closure.GetDefinedLabel(labelOrInvokeIndex, il));
					return true;
				}
				goto case GotoExpressionKind.Return;
			case GotoExpressionKind.Return:
				if ((parent & ParentFlags.TryCatch) != ParentFlags.Empty)
				{
					if (value != null)
					{
						ref LabelInfo reference = ref closure.Labels.Items[labelOrInvokeIndex];
						int num = (short)(reference.ReturnVariableIndexPlusOneAndIsDefined >> 1) - 1;
						if (num == -1)
						{
							num = il.GetNextLocalVarIndex(value.Type);
							reference.ReturnVariableIndexPlusOneAndIsDefined = (short)(num + 1 << 1);
							reference.ReturnLabel = il.DefineLabel();
						}
						EmitStoreLocalVariable(il, num);
						il.Emit(OpCodes.Leave, reference.ReturnLabel);
					}
					else
					{
						il.Emit(OpCodes.Leave, closure.GetDefinedLabel(labelOrInvokeIndex, il));
					}
				}
				else if ((parent & ParentFlags.InlinedLambdaInvoke) != ParentFlags.Empty)
				{
					if (value != null)
					{
						short inlinedLambdaInvokeIndex = closure.Labels.Items[labelOrInvokeIndex].InlinedLambdaInvokeIndex;
						if (inlinedLambdaInvokeIndex == -1)
						{
							return false;
						}
						ref LabelInfo reference2 = ref closure.Labels.Items[inlinedLambdaInvokeIndex];
						int num2 = (short)(reference2.ReturnVariableIndexPlusOneAndIsDefined >> 1) - 1;
						if (num2 == -1)
						{
							num2 = il.GetNextLocalVarIndex(value.Type);
							reference2.ReturnVariableIndexPlusOneAndIsDefined = (short)(num2 + 1 << 1);
							reference2.ReturnLabel = il.DefineLabel();
						}
						EmitStoreLocalVariable(il, num2);
						il.Emit(OpCodes.Br, reference2.ReturnLabel);
					}
				}
				else
				{
					il.Emit(OpCodes.Ret);
				}
				return true;
			default:
				return false;
			}
		}

		private static bool TryEmitCoalesceOperator(BinaryExpression exprObj, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Label label = il.DefineLabel();
			Label label2 = il.DefineLabel();
			Expression left = exprObj.Left;
			Expression right = exprObj.Right;
			ParentFlags parent2 = (parent & ~ParentFlags.IgnoreResult) | ParentFlags.Coalesce;
			if (!TryEmit(left, paramExprs, il, ref closure, setup, parent2))
			{
				return false;
			}
			Type type = left.Type;
			if (type.IsValueType)
			{
				int location = EmitStoreAndLoadLocalVariableAddress(il, type);
				il.Emit(OpCodes.Call, type.FindNullableHasValueGetterMethod());
				il.Emit(OpCodes.Brfalse, label);
				EmitLoadLocalVariableAddress(il, location);
				il.Emit(OpCodes.Call, type.FindNullableGetValueOrDefaultMethod());
				il.Emit(OpCodes.Br, label2);
				il.MarkLabel(label);
				if (!TryEmit(right, paramExprs, il, ref closure, setup, parent2))
				{
					return false;
				}
				il.MarkLabel(label2);
			}
			else
			{
				il.Emit(OpCodes.Dup);
				il.Emit(OpCodes.Brtrue, label);
				il.Emit(OpCodes.Pop);
				if (!TryEmit(right, paramExprs, il, ref closure, setup, parent2))
				{
					return false;
				}
				if (right.Type != exprObj.Type && right.Type.IsValueType)
				{
					il.Emit(OpCodes.Box, right.Type);
				}
				if (left.Type == exprObj.Type)
				{
					il.MarkLabel(label);
				}
				else
				{
					il.Emit(OpCodes.Br, label2);
					il.MarkLabel(label);
					il.Emit(OpCodes.Castclass, exprObj.Type);
					il.MarkLabel(label2);
				}
			}
			return il.EmitPopIfIgnoreResult(parent);
		}

		private static void EmitDefault(Type type, ILGenerator il)
		{
			if (!type.GetTypeInfo().IsValueType)
			{
				il.Emit(OpCodes.Ldnull);
			}
			else if (type == typeof(bool) || type == typeof(byte) || type == typeof(char) || type == typeof(sbyte) || type == typeof(int) || type == typeof(uint) || type == typeof(short) || type == typeof(ushort))
			{
				il.Emit(OpCodes.Ldc_I4_0);
			}
			else if (type == typeof(long) || type == typeof(ulong))
			{
				il.Emit(OpCodes.Ldc_I4_0);
				il.Emit(OpCodes.Conv_I8);
			}
			else if (type == typeof(float))
			{
				il.Emit(OpCodes.Ldc_R4, 0f);
			}
			else if (type == typeof(double))
			{
				il.Emit(OpCodes.Ldc_R8, 0.0);
			}
			else
			{
				EmitLoadLocalVariable(il, InitValueTypeVariable(il, type));
			}
		}

		private static bool TryEmitTryCatchFinallyBlock(TryExpression tryExpr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			il.BeginExceptionBlock();
			if (!TryEmit(tryExpr.Body, paramExprs, il, ref closure, setup, parent))
			{
				return false;
			}
			Type type = tryExpr.Type;
			bool flag = type != typeof(void) && !parent.IgnoresResult();
			int location = -1;
			if (flag)
			{
				EmitStoreLocalVariable(il, location = il.GetNextLocalVarIndex(type));
			}
			IReadOnlyList<CatchBlock> handlers = tryExpr.Handlers;
			for (int i = 0; i < handlers.Count; i++)
			{
				CatchBlock catchBlock = handlers[i];
				if (catchBlock.Filter != null)
				{
					return false;
				}
				il.BeginCatchBlock(catchBlock.Test);
				ParameterExpression variable = catchBlock.Variable;
				if (variable != null)
				{
					int nextLocalVarIndex = il.GetNextLocalVarIndex(variable.Type);
					closure.PushBlockWithVars(variable, nextLocalVarIndex);
					EmitStoreLocalVariable(il, nextLocalVarIndex);
				}
				if (!TryEmit(catchBlock.Body, paramExprs, il, ref closure, setup, parent))
				{
					return false;
				}
				if (variable != null)
				{
					closure.PopBlock();
				}
				if (flag)
				{
					EmitStoreLocalVariable(il, location);
				}
			}
			Expression expression = tryExpr.Finally;
			if (expression != null)
			{
				il.BeginFinallyBlock();
				if (!TryEmit(expression, paramExprs, il, ref closure, setup, parent))
				{
					return false;
				}
			}
			il.EndExceptionBlock();
			if (flag)
			{
				EmitLoadLocalVariable(il, location);
			}
			return true;
		}

		public static bool TryEmitParameter(ParameterExpression paramExpr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, ParentFlags parent, int byRefIndex = -1)
		{
			int parameterCount = paramExprs.ParameterCount;
			Type type = paramExpr.Type;
			bool isByRef = paramExpr.IsByRef;
			int num = parameterCount - 1;
			while (num != -1 && paramExprs.GetParameter(num) != paramExpr)
			{
				num--;
			}
			if (num != -1)
			{
				bool flag = byRefIndex != -1;
				closure.LastEmitIsAddress = !isByRef && (flag || (type.IsValueType && (parent & ParentFlags.InstanceAccess) != ParentFlags.Empty && (parent & ParentFlags.IndexAccess) == 0));
				if ((closure.Status & ClosureStatus.ShouldBeStaticMethod) == 0)
				{
					num++;
				}
				if (closure.LastEmitIsAddress)
				{
					EmitLoadArgAddress(il, num);
				}
				else
				{
					EmitLoadArg(il, num);
				}
				if (isByRef)
				{
					if (type.IsValueType)
					{
						if ((!flag && (parent & ParentFlags.Call) != ParentFlags.Empty && (parent & ParentFlags.InstanceAccess) == 0) || (parent & ParentFlags.Arithmetic) != ParentFlags.Empty)
						{
							EmitValueTypeDereference(il, type);
						}
					}
					else if ((!flag && (parent & ParentFlags.Call) != ParentFlags.Empty) || (parent & (ParentFlags.MemberAccess | ParentFlags.Coalesce | ParentFlags.IndexAccess)) != ParentFlags.Empty)
					{
						il.Emit(OpCodes.Ldind_Ref);
					}
				}
				return true;
			}
			int definedLocalVarOrDefault = closure.GetDefinedLocalVarOrDefault(paramExpr);
			if (definedLocalVarOrDefault != -1)
			{
				if (byRefIndex != -1 || (type.IsValueType && (parent & ParentFlags.IndexAccess) == 0 && (parent & (ParentFlags.MemberAccess | ParentFlags.InstanceAccess)) != ParentFlags.Empty))
				{
					EmitLoadLocalVariableAddress(il, definedLocalVarOrDefault);
					closure.LastEmitIsAddress = true;
				}
				else
				{
					EmitLoadLocalVariable(il, definedLocalVarOrDefault);
				}
				return true;
			}
			if (isByRef)
			{
				EmitLoadLocalVariableAddress(il, byRefIndex);
				return true;
			}
			ParameterExpression[] nonPassedParameters = closure.NonPassedParameters;
			int num2 = nonPassedParameters.Length - 1;
			while (num2 != -1 && nonPassedParameters[num2] != paramExpr)
			{
				num2--;
			}
			if (num2 == -1)
			{
				return false;
			}
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldfld, ArrayClosureWithNonPassedParamsField);
			EmitLoadConstantInt(il, num2);
			il.Emit(OpCodes.Ldelem_Ref);
			if (type.IsValueType)
			{
				il.Emit(OpCodes.Unbox_Any, type);
			}
			return true;
		}

		public static bool TryEmitNonByRefNonValueTypeParameter(ParameterExpression paramExpr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure)
		{
			int parameterCount = paramExprs.ParameterCount;
			Type type = paramExpr.Type;
			int num = parameterCount - 1;
			while (num != -1 && paramExprs.GetParameter(num) != paramExpr)
			{
				num--;
			}
			if (num != -1)
			{
				num++;
				if (closure.LastEmitIsAddress)
				{
					EmitLoadArgAddress(il, num);
				}
				else
				{
					EmitLoadArg(il, num);
				}
				return true;
			}
			ParameterExpression[] nonPassedParameters = closure.NonPassedParameters;
			int num2 = nonPassedParameters.Length - 1;
			while (num2 != -1 && nonPassedParameters[num2] != paramExpr)
			{
				num2--;
			}
			if (num2 == -1)
			{
				return false;
			}
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldfld, ArrayClosureWithNonPassedParamsField);
			EmitLoadConstantInt(il, num2);
			il.Emit(OpCodes.Ldelem_Ref);
			return true;
		}

		private static void EmitValueTypeDereference(ILGenerator il, Type type)
		{
			if (type == typeof(int))
			{
				il.Emit(OpCodes.Ldind_I4);
			}
			else if (type == typeof(long))
			{
				il.Emit(OpCodes.Ldind_I8);
			}
			else if (type == typeof(short))
			{
				il.Emit(OpCodes.Ldind_I2);
			}
			else if (type == typeof(sbyte))
			{
				il.Emit(OpCodes.Ldind_I1);
			}
			else if (type == typeof(float))
			{
				il.Emit(OpCodes.Ldind_R4);
			}
			else if (type == typeof(double))
			{
				il.Emit(OpCodes.Ldind_R8);
			}
			else if (type == typeof(nint))
			{
				il.Emit(OpCodes.Ldind_I);
			}
			else if (type == typeof(nuint))
			{
				il.Emit(OpCodes.Ldind_I);
			}
			else if (type == typeof(byte))
			{
				il.Emit(OpCodes.Ldind_U1);
			}
			else if (type == typeof(ushort))
			{
				il.Emit(OpCodes.Ldind_U2);
			}
			else if (type == typeof(uint))
			{
				il.Emit(OpCodes.Ldind_U4);
			}
			else
			{
				il.Emit(OpCodes.Ldobj, type);
			}
		}

		private static bool TryEmitSimpleUnaryExpression(UnaryExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Type type = expr.Type;
			if (!TryEmit(expr.Operand, paramExprs, il, ref closure, setup, parent))
			{
				return false;
			}
			if (expr.NodeType == ExpressionType.TypeAs)
			{
				il.Emit(OpCodes.Isinst, type);
				if (type.IsValueType)
				{
					il.Emit(OpCodes.Unbox_Any, type);
				}
			}
			else if (expr.NodeType == ExpressionType.IsFalse)
			{
				Label label = il.DefineLabel();
				Label label2 = il.DefineLabel();
				il.Emit(OpCodes.Brfalse, label);
				il.Emit(OpCodes.Ldc_I4_0);
				il.Emit(OpCodes.Br, label2);
				il.MarkLabel(label);
				il.Emit(OpCodes.Ldc_I4_1);
				il.MarkLabel(label2);
			}
			else if (expr.NodeType == ExpressionType.Increment)
			{
				TypeInfo typeInfo = type.GetTypeInfo();
				if (typeInfo.IsPrimitive)
				{
					if (!TryEmitNumberOne(il, type))
					{
						return false;
					}
					il.Emit(OpCodes.Add);
				}
				else
				{
					MethodInfo declaredMethod = typeInfo.GetDeclaredMethod("op_Increment");
					if (declaredMethod == null)
					{
						return false;
					}
					il.Emit(OpCodes.Call, declaredMethod);
				}
			}
			else if (expr.NodeType == ExpressionType.Decrement)
			{
				TypeInfo typeInfo2 = type.GetTypeInfo();
				if (typeInfo2.IsPrimitive)
				{
					if (!TryEmitNumberOne(il, type))
					{
						return false;
					}
					il.Emit(OpCodes.Sub);
				}
				else
				{
					MethodInfo declaredMethod2 = typeInfo2.GetDeclaredMethod("op_Decrement");
					if (declaredMethod2 == null)
					{
						return false;
					}
					il.Emit(OpCodes.Call, declaredMethod2);
				}
			}
			else if (expr.NodeType == ExpressionType.Negate || expr.NodeType == ExpressionType.NegateChecked)
			{
				TypeInfo typeInfo3 = type.GetTypeInfo();
				if (typeInfo3.IsPrimitive)
				{
					il.Emit(OpCodes.Neg);
				}
				else
				{
					MethodInfo declaredMethod3 = typeInfo3.GetDeclaredMethod("op_UnaryNegation");
					if (declaredMethod3 == null)
					{
						return false;
					}
					il.Emit(OpCodes.Call, declaredMethod3);
				}
			}
			else if (expr.NodeType == ExpressionType.OnesComplement)
			{
				il.Emit(OpCodes.Not);
			}
			else if (expr.NodeType == ExpressionType.Unbox)
			{
				il.Emit(OpCodes.Unbox_Any, type);
			}
			return il.EmitPopIfIgnoreResult(parent);
		}

		private static bool TryEmitTypeIsOrEqual(TypeBinaryExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			if (!TryEmit(expr.Expression, paramExprs, il, ref closure, setup, parent))
			{
				return false;
			}
			if ((parent & ParentFlags.IgnoreResult) != ParentFlags.Empty)
			{
				return true;
			}
			if (expr.NodeType == ExpressionType.TypeIs)
			{
				il.Emit(OpCodes.Isinst, expr.TypeOperand);
				il.Emit(OpCodes.Ldnull);
				il.Emit(OpCodes.Cgt_Un);
				return true;
			}
			if ((setup & CompilerFlags.ThrowOnNotSupportedExpression) != CompilerFlags.Default)
			{
				throw new NotSupportedExpressionException(NotSupported.TypeEqual);
			}
			return false;
		}

		private static bool TryEmitNot(UnaryExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			if (expr.Operand.NodeType == ExpressionType.Equal)
			{
				BinaryExpression binaryExpression = (BinaryExpression)expr.Operand;
				return TryEmitComparison(binaryExpression.Left, binaryExpression.Right, ExpressionType.NotEqual, binaryExpression.Type, paramExprs, il, ref closure, setup, parent);
			}
			if (!TryEmit(expr.Operand, paramExprs, il, ref closure, setup, parent))
			{
				return false;
			}
			if ((parent & ParentFlags.IgnoreResult) != ParentFlags.Empty)
			{
				il.Emit(OpCodes.Pop);
			}
			else if (expr.Type == typeof(bool))
			{
				il.Emit(OpCodes.Ldc_I4_0);
				il.Emit(OpCodes.Ceq);
			}
			else
			{
				il.Emit(OpCodes.Not);
			}
			return true;
		}

		private static bool TryEmitConvert(UnaryExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Expression operand = expr.Operand;
			MethodInfo method = expr.Method;
			if (method != null && method.Name != "op_Implicit" && method.Name != "op_Explicit")
			{
				if (TryEmit(operand, paramExprs, il, ref closure, setup, (parent & ~ParentFlags.IgnoreResult) | ParentFlags.InstanceCall))
				{
					return EmitMethodCallOrVirtualCall(il, method);
				}
				return false;
			}
			Type type = operand.Type;
			Type type2 = expr.Type;
			if (type2.IsAssignableFrom(type) && (parent & ParentFlags.IgnoreResult) != ParentFlags.Empty)
			{
				return TryEmit(operand, paramExprs, il, ref closure, setup, parent);
			}
			Type underlyingNullableTypeOrNull = type.GetUnderlyingNullableTypeOrNull();
			if (underlyingNullableTypeOrNull == type2)
			{
				if (!TryEmit(operand, paramExprs, il, ref closure, setup, (parent & ~ParentFlags.IgnoreResult) | ParentFlags.InstanceAccess))
				{
					return false;
				}
				if (!closure.LastEmitIsAddress)
				{
					EmitStoreAndLoadLocalVariableAddress(il, type);
				}
				il.Emit(OpCodes.Call, type.FindValueGetterMethod());
				return il.EmitPopIfIgnoreResult(parent);
			}
			if (!TryEmit(operand, paramExprs, il, ref closure, setup, parent & ~ParentFlags.IgnoreResult & ~ParentFlags.InstanceAccess))
			{
				return false;
			}
			Type underlyingNullableTypeOrNull2 = type2.GetUnderlyingNullableTypeOrNull();
			if (underlyingNullableTypeOrNull2 == type)
			{
				il.Emit(OpCodes.Newobj, type2.GetTypeInfo().DeclaredConstructors.GetFirst());
				return true;
			}
			if (type == type2 || type2 == typeof(object))
			{
				if (type2 == typeof(object) && type.IsValueType)
				{
					il.Emit(OpCodes.Box, type);
				}
				return il.EmitPopIfIgnoreResult(parent);
			}
			if (underlyingNullableTypeOrNull == null && !type.IsPrimitive)
			{
				Type targetType = underlyingNullableTypeOrNull2 ?? type2;
				MethodInfo methodInfo = method ?? type.FindConvertOperator(type, targetType);
				if (methodInfo != null)
				{
					il.Emit(OpCodes.Call, methodInfo);
					if (underlyingNullableTypeOrNull2 != null)
					{
						il.Emit(OpCodes.Newobj, type2.GetTypeInfo().DeclaredConstructors.GetFirst());
					}
					return il.EmitPopIfIgnoreResult(parent);
				}
			}
			else if (underlyingNullableTypeOrNull2 == null)
			{
				if (method != null && method.DeclaringType == type2 && method.GetParameters()[0].ParameterType == type)
				{
					il.Emit(OpCodes.Call, method);
					return il.EmitPopIfIgnoreResult(parent);
				}
				Type type3 = underlyingNullableTypeOrNull ?? type;
				MethodInfo methodInfo2 = method ?? type3.FindConvertOperator(type3, type2);
				if (methodInfo2 != null)
				{
					if (underlyingNullableTypeOrNull != null)
					{
						EmitStoreAndLoadLocalVariableAddress(il, type);
						il.Emit(OpCodes.Call, type.FindValueGetterMethod());
					}
					il.Emit(OpCodes.Call, methodInfo2);
					return il.EmitPopIfIgnoreResult(parent);
				}
			}
			if (type2 != typeof(string))
			{
				if (underlyingNullableTypeOrNull2 == null && !type2.IsPrimitive)
				{
					if (method != null && method.DeclaringType == type2 && method.GetParameters()[0].ParameterType == type)
					{
						il.Emit(OpCodes.Call, method);
						return il.EmitPopIfIgnoreResult(parent);
					}
					Type sourceType = underlyingNullableTypeOrNull ?? type;
					MethodInfo methodInfo3 = method ?? type2.FindConvertOperator(sourceType, type2);
					if (methodInfo3 != null)
					{
						if (underlyingNullableTypeOrNull != null)
						{
							EmitStoreAndLoadLocalVariableAddress(il, type);
							il.Emit(OpCodes.Call, type.FindValueGetterMethod());
						}
						il.Emit(OpCodes.Call, methodInfo3);
						return il.EmitPopIfIgnoreResult(parent);
					}
				}
				else if (underlyingNullableTypeOrNull == null)
				{
					Type type4 = underlyingNullableTypeOrNull2 ?? type2;
					MethodInfo methodInfo4 = method ?? type4.FindConvertOperator(type, type4);
					if (methodInfo4 != null)
					{
						il.Emit(OpCodes.Call, methodInfo4);
						if (underlyingNullableTypeOrNull2 != null)
						{
							il.Emit(OpCodes.Newobj, type2.GetTypeInfo().DeclaredConstructors.GetFirst());
						}
						return il.EmitPopIfIgnoreResult(parent);
					}
				}
			}
			if (type == typeof(object) && type2.IsValueType)
			{
				il.Emit(OpCodes.Unbox_Any, type2);
			}
			else if (underlyingNullableTypeOrNull2 != null)
			{
				if (underlyingNullableTypeOrNull == null)
				{
					if (!underlyingNullableTypeOrNull2.IsEnum && !TryEmitValueConvert(underlyingNullableTypeOrNull2, il, isChecked: false))
					{
						return false;
					}
					il.Emit(OpCodes.Newobj, type2.GetTypeInfo().DeclaredConstructors.GetFirst());
				}
				else
				{
					int location = EmitStoreAndLoadLocalVariableAddress(il, type);
					il.Emit(OpCodes.Call, type.FindNullableHasValueGetterMethod());
					Label label = il.DefineLabel();
					il.Emit(OpCodes.Brtrue_S, label);
					EmitLoadLocalVariable(il, InitValueTypeVariable(il, type2));
					Label label2 = il.DefineLabel();
					il.Emit(OpCodes.Br_S, label2);
					il.MarkLabel(label);
					EmitLoadLocalVariableAddress(il, location);
					il.Emit(OpCodes.Call, type.FindNullableGetValueOrDefaultMethod());
					if (!TryEmitValueConvert(underlyingNullableTypeOrNull2, il, expr.NodeType == ExpressionType.ConvertChecked))
					{
						MethodInfo methodInfo5 = method ?? underlyingNullableTypeOrNull2.FindConvertOperator(underlyingNullableTypeOrNull, underlyingNullableTypeOrNull2);
						if (methodInfo5 == null)
						{
							return false;
						}
						il.Emit(OpCodes.Call, methodInfo5);
					}
					il.Emit(OpCodes.Newobj, type2.GetTypeInfo().DeclaredConstructors.GetFirst());
					il.MarkLabel(label2);
				}
			}
			else
			{
				if (type2.IsEnum)
				{
					type2 = Enum.GetUnderlyingType(type2);
				}
				if (underlyingNullableTypeOrNull != null)
				{
					EmitStoreAndLoadLocalVariableAddress(il, type);
					il.Emit(OpCodes.Call, type.FindValueGetterMethod());
				}
				if (!TryEmitValueConvert(type2, il, expr.NodeType == ExpressionType.ConvertChecked))
				{
					if (type.IsValueType)
					{
						il.Emit(OpCodes.Box, type);
					}
					il.Emit(OpCodes.Castclass, type2);
				}
			}
			return il.EmitPopIfIgnoreResult(parent);
		}

		private static bool TryEmitValueConvert(Type targetType, ILGenerator il, bool isChecked)
		{
			if (targetType == typeof(int))
			{
				il.Emit(isChecked ? OpCodes.Conv_Ovf_I4 : OpCodes.Conv_I4);
			}
			else if (targetType == typeof(float))
			{
				il.Emit(OpCodes.Conv_R4);
			}
			else if (targetType == typeof(uint))
			{
				il.Emit(isChecked ? OpCodes.Conv_Ovf_U4 : OpCodes.Conv_U4);
			}
			else if (targetType == typeof(sbyte))
			{
				il.Emit(isChecked ? OpCodes.Conv_Ovf_I1 : OpCodes.Conv_I1);
			}
			else if (targetType == typeof(byte))
			{
				il.Emit(isChecked ? OpCodes.Conv_Ovf_U1 : OpCodes.Conv_U1);
			}
			else if (targetType == typeof(short))
			{
				il.Emit(isChecked ? OpCodes.Conv_Ovf_I2 : OpCodes.Conv_I2);
			}
			else if (targetType == typeof(ushort) || targetType == typeof(char))
			{
				il.Emit(isChecked ? OpCodes.Conv_Ovf_U2 : OpCodes.Conv_U2);
			}
			else if (targetType == typeof(long))
			{
				il.Emit(isChecked ? OpCodes.Conv_Ovf_I8 : OpCodes.Conv_I8);
			}
			else if (targetType == typeof(ulong))
			{
				il.Emit(isChecked ? OpCodes.Conv_Ovf_U8 : OpCodes.Conv_U8);
			}
			else
			{
				if (!(targetType == typeof(double)))
				{
					return false;
				}
				il.Emit(OpCodes.Conv_R8);
			}
			return true;
		}

		public static bool TryEmitConstantOfNotNullValue(bool considerClosure, Type exprType, object constantValue, ILGenerator il, ref ClosureInfo closure, int byRefIndex = -1)
		{
			Type type = constantValue.GetType();
			if (exprType == null)
			{
				exprType = type;
			}
			if (considerClosure && IsClosureBoundConstant(constantValue, type))
			{
				object[] items = closure.Constants.Items;
				int num = closure.Constants.Count - 1;
				while (num != -1 && items[num] != constantValue)
				{
					num--;
				}
				if (num == -1)
				{
					return false;
				}
				int num2 = closure.ConstantUsageThenVarIndex.Items[num] - 1;
				if (num2 > 0)
				{
					EmitLoadLocalVariable(il, num2);
				}
				else
				{
					EmitLoadClosureArrayItem(il, num);
					if (exprType.IsValueType)
					{
						il.Emit(OpCodes.Unbox_Any, exprType);
						if (byRefIndex != -1)
						{
							EmitStoreAndLoadLocalVariableAddress(il, exprType);
						}
					}
				}
			}
			else
			{
				if (constantValue is string str)
				{
					il.Emit(OpCodes.Ldstr, str);
					return true;
				}
				if (constantValue is Type cls)
				{
					il.Emit(OpCodes.Ldtoken, cls);
					il.Emit(OpCodes.Call, _getTypeFromHandleMethod);
					return true;
				}
				if (!TryEmitNumberConstant(il, constantValue, type))
				{
					return false;
				}
			}
			if (exprType.IsValueType)
			{
				if (exprType.IsNullable())
				{
					il.Emit(OpCodes.Newobj, exprType.GetConstructors().GetFirst());
				}
			}
			else if (exprType == typeof(object) && type.IsValueType)
			{
				il.Emit(OpCodes.Box, type);
			}
			return true;
		}

		private static bool TryEmitNumberConstant(ILGenerator il, object constantValue, Type constValueType)
		{
			if (constValueType.IsEnum)
			{
				constValueType = Enum.GetUnderlyingType(constValueType);
			}
			if (constValueType == typeof(int))
			{
				EmitLoadConstantInt(il, (int)constantValue);
			}
			else if (constValueType == typeof(bool))
			{
				il.Emit(((bool)constantValue) ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
			}
			else if (constValueType == typeof(char))
			{
				EmitLoadConstantInt(il, (char)constantValue);
			}
			else if (constValueType == typeof(short))
			{
				EmitLoadConstantInt(il, (short)constantValue);
			}
			else if (constValueType == typeof(byte))
			{
				EmitLoadConstantInt(il, (byte)constantValue);
			}
			else if (constValueType == typeof(ushort))
			{
				EmitLoadConstantInt(il, (ushort)constantValue);
			}
			else if (constValueType == typeof(sbyte))
			{
				EmitLoadConstantInt(il, (sbyte)constantValue);
			}
			else if (constValueType == typeof(uint))
			{
				EmitLoadConstantInt(il, (int)(uint)constantValue);
			}
			else if (constValueType == typeof(long))
			{
				il.Emit(OpCodes.Ldc_I8, (long)constantValue);
			}
			else if (constValueType == typeof(ulong))
			{
				il.Emit(OpCodes.Ldc_I8, (long)(ulong)constantValue);
			}
			else if (constValueType == typeof(float))
			{
				il.Emit(OpCodes.Ldc_R4, (float)constantValue);
			}
			else if (constValueType == typeof(double))
			{
				il.Emit(OpCodes.Ldc_R8, (double)constantValue);
			}
			else if (constValueType == typeof(nint))
			{
				il.Emit(OpCodes.Ldc_I8, ((IntPtr)(nint)constantValue).ToInt64());
			}
			else if (constValueType == typeof(nuint))
			{
				il.Emit(OpCodes.Ldc_I8, (long)((UIntPtr)(nuint)constantValue).ToUInt64());
			}
			else
			{
				if (!(constValueType == typeof(decimal)))
				{
					return false;
				}
				EmitDecimalConstant((decimal)constantValue, il);
			}
			return true;
		}

		internal static bool TryEmitNumberOne(ILGenerator il, Type type)
		{
			if (type == typeof(int) || type == typeof(char) || type == typeof(short) || type == typeof(byte) || type == typeof(ushort) || type == typeof(sbyte) || type == typeof(uint))
			{
				il.Emit(OpCodes.Ldc_I4_1);
			}
			else if (type == typeof(long) || type == typeof(ulong) || type == typeof(nint) || type == typeof(nuint))
			{
				il.Emit(OpCodes.Ldc_I8, 1L);
			}
			else if (type == typeof(float))
			{
				il.Emit(OpCodes.Ldc_R4, 1f);
			}
			else
			{
				if (!(type == typeof(double)))
				{
					return false;
				}
				il.Emit(OpCodes.Ldc_R8, 1.0);
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void EmitLoadClosureArrayItem(ILGenerator il, int i)
		{
			il.Emit(OpCodes.Ldloc_0);
			EmitLoadConstantInt(il, i);
			il.Emit(OpCodes.Ldelem_Ref);
		}

		internal static void EmitLoadConstantsAndNestedLambdasIntoVars(ILGenerator il, object nestedLambdaOrLambdas, ref ClosureInfo closure)
		{
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldfld, ArrayClosureArrayField);
			EmitStoreLocalVariable(il, il.GetNextLocalVarIndex(typeof(object[])));
			object[] items = closure.Constants.Items;
			int count = closure.Constants.Count;
			short[] items2 = closure.ConstantUsageThenVarIndex.Items;
			for (int i = 0; i < count; i++)
			{
				if (items2[i] > 1)
				{
					EmitLoadClosureArrayItem(il, i);
					Type type = items[i].GetType();
					if (type.IsValueType)
					{
						il.Emit(OpCodes.Unbox_Any, type);
					}
					short num = (short)il.GetNextLocalVarIndex(type);
					items2[i] = (short)(num + 1);
					EmitStoreLocalVariable(il, num);
				}
			}
			if (nestedLambdaOrLambdas == null)
			{
				return;
			}
			if (nestedLambdaOrLambdas is NestedLambdaInfo nestedLambdaInfo)
			{
				EmitLoadClosureArrayItem(il, count);
				EmitStoreLocalVariable(il, nestedLambdaInfo.LambdaVarIndex = (short)il.GetNextLocalVarIndex(nestedLambdaInfo.Lambda.GetType()));
				return;
			}
			NestedLambdaInfo[] array = (NestedLambdaInfo[])nestedLambdaOrLambdas;
			for (int j = 0; j < array.Length; j++)
			{
				EmitLoadClosureArrayItem(il, count + j);
				NestedLambdaInfo nestedLambdaInfo2 = array[j];
				EmitStoreLocalVariable(il, nestedLambdaInfo2.LambdaVarIndex = (short)il.GetNextLocalVarIndex(nestedLambdaInfo2.Lambda.GetType()));
			}
		}

		private static void EmitDecimalConstant(decimal value, ILGenerator il)
		{
			if (value % 1m == 0m)
			{
				if (value >= -2147483648m && value <= 2147483647m)
				{
					EmitLoadConstantInt(il, decimal.ToInt32(value));
					il.Emit(OpCodes.Newobj, typeof(decimal).FindSingleParamConstructor(typeof(int)));
					return;
				}
				if (value >= -9223372036854775808m && value <= 9223372036854775807m)
				{
					il.Emit(OpCodes.Ldc_I8, decimal.ToInt64(value));
					il.Emit(OpCodes.Newobj, typeof(decimal).FindSingleParamConstructor(typeof(long)));
					return;
				}
			}
			if (value == decimal.MinValue)
			{
				il.Emit(OpCodes.Ldsfld, typeof(decimal).GetField("MinValue"));
				return;
			}
			if (value == decimal.MaxValue)
			{
				il.Emit(OpCodes.Ldsfld, typeof(decimal).GetField("MaxValue"));
				return;
			}
			int[] bits = decimal.GetBits(value);
			bool flag = (bits[3] & 0x80000000u) != 0;
			byte i = (byte)((bits[3] >> 16) & 0x7F);
			EmitLoadConstantInt(il, bits[0]);
			EmitLoadConstantInt(il, bits[1]);
			EmitLoadConstantInt(il, bits[2]);
			il.Emit(flag ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
			EmitLoadConstantInt(il, i);
			il.Emit(OpCodes.Conv_U1);
			il.Emit(OpCodes.Newobj, _decimalCtor.Value);
		}

		private static int InitValueTypeVariable(ILGenerator il, Type exprType)
		{
			int nextLocalVarIndex = il.GetNextLocalVarIndex(exprType);
			EmitLoadLocalVariableAddress(il, nextLocalVarIndex);
			il.Emit(OpCodes.Initobj, exprType);
			return nextLocalVarIndex;
		}

		private static bool EmitNewArrayBounds(NewArrayExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			int argumentCount = ((IArgumentProvider)expr).ArgumentCount;
			if (argumentCount == 1)
			{
				if (!TryEmit(((IArgumentProvider)expr).GetArgument(0), paramExprs, il, ref closure, setup, parent))
				{
					return false;
				}
				Type elementType = expr.Type.GetElementType();
				if (elementType == null)
				{
					return false;
				}
				il.Emit(OpCodes.Newarr, elementType);
			}
			else
			{
				for (int i = 0; i < argumentCount; i++)
				{
					if (!TryEmit(((IArgumentProvider)expr).GetArgument(i), paramExprs, il, ref closure, setup, parent))
					{
						return false;
					}
				}
				il.Emit(OpCodes.Newobj, expr.Type.GetTypeInfo().DeclaredConstructors.GetFirst());
			}
			return true;
		}

		private static bool EmitNewArrayInit(NewArrayExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Type type = expr.Type;
			if (type.GetArrayRank() > 1)
			{
				return false;
			}
			Type elementType = type.GetElementType();
			if (elementType == null)
			{
				return false;
			}
			int argumentCount = ((IArgumentProvider)expr).ArgumentCount;
			EmitLoadConstantInt(il, argumentCount);
			il.Emit(OpCodes.Newarr, elementType);
			bool isValueType = elementType.IsValueType;
			for (int i = 0; i < argumentCount; i++)
			{
				il.Emit(OpCodes.Dup);
				EmitLoadConstantInt(il, i);
				if (isValueType)
				{
					il.Emit(OpCodes.Ldelema, elementType);
					if (!TryEmit(((IArgumentProvider)expr).GetArgument(i), paramExprs, il, ref closure, setup, parent))
					{
						return false;
					}
					il.Emit(OpCodes.Stobj, elementType);
				}
				else
				{
					if (!TryEmit(((IArgumentProvider)expr).GetArgument(i), paramExprs, il, ref closure, setup, parent))
					{
						return false;
					}
					il.Emit(OpCodes.Stelem_Ref);
				}
			}
			return true;
		}

		private static bool TryEmitArrayIndex(Type type, ILGenerator il, ParentFlags parent, ref ClosureInfo closure)
		{
			if (!type.IsValueType)
			{
				il.Emit(OpCodes.Ldelem_Ref);
				return true;
			}
			if ((parent & (ParentFlags.MemberAccess | ParentFlags.InstanceAccess)) != ParentFlags.Empty)
			{
				il.Emit(OpCodes.Ldelema, type);
				closure.LastEmitIsAddress = true;
				return true;
			}
			if (type == typeof(int))
			{
				il.Emit(OpCodes.Ldelem_I4);
			}
			else if (type == typeof(long))
			{
				il.Emit(OpCodes.Ldelem_I8);
			}
			else if (type == typeof(short))
			{
				il.Emit(OpCodes.Ldelem_I2);
			}
			else if (type == typeof(sbyte))
			{
				il.Emit(OpCodes.Ldelem_I1);
			}
			else if (type == typeof(float))
			{
				il.Emit(OpCodes.Ldelem_R4);
			}
			else if (type == typeof(double))
			{
				il.Emit(OpCodes.Ldelem_R8);
			}
			else if (type == typeof(nint))
			{
				il.Emit(OpCodes.Ldelem_I);
			}
			else if (type == typeof(nuint))
			{
				il.Emit(OpCodes.Ldelem_I);
			}
			else if (type == typeof(byte))
			{
				il.Emit(OpCodes.Ldelem_U1);
			}
			else if (type == typeof(ushort))
			{
				il.Emit(OpCodes.Ldelem_U2);
			}
			else if (type == typeof(uint))
			{
				il.Emit(OpCodes.Ldelem_U4);
			}
			else
			{
				il.Emit(OpCodes.Ldelem, type);
			}
			return true;
		}

		private static bool EmitMemberInit(MemberInitExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			int num = -1;
			if (expr.Type.IsValueType)
			{
				num = il.GetNextLocalVarIndex(expr.Type);
			}
			NewExpression newExpression = expr.NewExpression;
			if (newExpression == null)
			{
				if (!TryEmit(expr.Expression, paramExprs, il, ref closure, setup, parent))
				{
					return false;
				}
			}
			else
			{
				IArgumentProvider argumentProvider = newExpression;
				int argumentCount = argumentProvider.ArgumentCount;
				if (argumentCount > 0)
				{
					ParameterInfo[] parameters = newExpression.Constructor.GetParameters();
					for (int i = 0; i < argumentCount; i++)
					{
						if (!TryEmit(argumentProvider.GetArgument(i), paramExprs, il, ref closure, setup, parent, parameters[i].ParameterType.IsByRef ? i : (-1)))
						{
							return false;
						}
					}
				}
				if (newExpression.Constructor != null)
				{
					il.Emit(OpCodes.Newobj, newExpression.Constructor);
				}
				else
				{
					if (!newExpression.Type.IsValueType)
					{
						return false;
					}
					if (num == -1)
					{
						num = il.GetNextLocalVarIndex(expr.Type);
					}
					EmitLoadLocalVariableAddress(il, num);
					il.Emit(OpCodes.Initobj, newExpression.Type);
				}
			}
			int argumentCount2 = ((IArgumentProvider<MemberBinding>)expr).ArgumentCount;
			for (int j = 0; j < argumentCount2; j++)
			{
				MemberBinding argument = ((IArgumentProvider<MemberBinding>)expr).GetArgument(j);
				if (argument.BindingType != MemberBindingType.Assignment)
				{
					return false;
				}
				if (num != -1)
				{
					EmitLoadLocalVariableAddress(il, num);
				}
				else
				{
					il.Emit(OpCodes.Dup);
				}
				if (!TryEmit(((MemberAssignment)argument).Expression, paramExprs, il, ref closure, setup, parent) || !EmitMemberAssign(il, argument.Member))
				{
					return false;
				}
			}
			if (num != -1)
			{
				EmitLoadLocalVariable(il, num);
			}
			return true;
		}

		private static bool EmitMemberAssign(ILGenerator il, MemberInfo member)
		{
			if (member is PropertyInfo propertyInfo)
			{
				MethodInfo setMethod = propertyInfo.SetMethod;
				if (setMethod != null)
				{
					return EmitMethodCallOrVirtualCall(il, setMethod);
				}
				return false;
			}
			if (member is FieldInfo fieldInfo)
			{
				il.Emit(fieldInfo.IsStatic ? OpCodes.Stsfld : OpCodes.Stfld, fieldInfo);
				return true;
			}
			return false;
		}

		private static bool TryEmitListInit(ListInitExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			int num = -1;
			if (expr.Type.IsValueType)
			{
				num = il.GetNextLocalVarIndex(expr.Type);
			}
			NewExpression newExpression = expr.NewExpression;
			Type type = newExpression.Type;
			IArgumentProvider argumentProvider = newExpression;
			int argumentCount = argumentProvider.ArgumentCount;
			if (argumentCount > 0)
			{
				ParameterInfo[] parameters = newExpression.Constructor.GetParameters();
				for (int i = 0; i < argumentCount; i++)
				{
					if (!TryEmit(argumentProvider.GetArgument(i), paramExprs, il, ref closure, setup, parent, parameters[i].ParameterType.IsByRef ? i : (-1)))
					{
						return false;
					}
				}
			}
			if (newExpression.Constructor != null)
			{
				il.Emit(OpCodes.Newobj, newExpression.Constructor);
			}
			else
			{
				if (!type.IsValueType)
				{
					return false;
				}
				if (num == -1)
				{
					num = il.GetNextLocalVarIndex(expr.Type);
				}
				EmitLoadLocalVariableAddress(il, num);
				il.Emit(OpCodes.Initobj, type);
			}
			IReadOnlyList<ElementInit> initializers = expr.Initializers;
			int count = initializers.Count;
			bool flag = true;
			ParentFlags parent2 = (parent & ~ParentFlags.IgnoreResult & ~ParentFlags.MemberAccess & ~ParentFlags.InstanceAccess) | ParentFlags.Call;
			for (int j = 0; j < count; j++)
			{
				if (num != -1)
				{
					EmitLoadLocalVariableAddress(il, num);
				}
				else
				{
					il.Emit(OpCodes.Dup);
				}
				ElementInit argument = initializers.GetArgument(j);
				MethodInfo addMethod = argument.AddMethod;
				ParameterInfo[] parameters2 = addMethod.GetParameters();
				IArgumentProvider argumentProvider2 = argument;
				int argumentCount2 = argument.ArgumentCount;
				int num2 = 0;
				while (flag && num2 < argumentCount2)
				{
					flag = TryEmit(argumentProvider2.GetArgument(num2), paramExprs, il, ref closure, setup, parent2, parameters2[num2].ParameterType.IsByRef ? num2 : (-1));
					num2++;
				}
				if (!type.IsValueType)
				{
					flag = EmitMethodCallOrVirtualCall(il, addMethod);
					continue;
				}
				if (!addMethod.IsVirtual || addMethod.DeclaringType == type)
				{
					flag = EmitMethodCall(il, addMethod);
					continue;
				}
				il.Emit(OpCodes.Constrained, type);
				flag = EmitVirtualMethodCall(il, addMethod);
			}
			if (num != -1)
			{
				EmitLoadLocalVariable(il, num);
			}
			return flag;
		}

		private static bool TryEmitIncDecAssign(UnaryExpression expr, ExpressionType nodeType, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Expression operand = expr.Operand;
			int nextLocalVarIndex = il.GetNextLocalVarIndex(expr.Type);
			if (operand is ParameterExpression parameterExpression)
			{
				int parameterCount = paramExprs.ParameterCount;
				int num = -1;
				int definedLocalVarOrDefault = closure.GetDefinedLocalVarOrDefault(parameterExpression);
				if (definedLocalVarOrDefault != -1)
				{
					EmitLoadLocalVariable(il, definedLocalVarOrDefault);
				}
				else
				{
					num = parameterCount - 1;
					while (num != -1 && paramExprs.GetParameter(num) != parameterExpression)
					{
						num--;
					}
					if (num == -1)
					{
						return false;
					}
					if ((closure.Status & ClosureStatus.ShouldBeStaticMethod) == 0)
					{
						num++;
					}
					EmitLoadArg(il, num);
					if (parameterExpression.IsByRef)
					{
						EmitValueTypeDereference(il, parameterExpression.Type);
					}
				}
				if (nodeType == ExpressionType.PostIncrementAssign || nodeType == ExpressionType.PostDecrementAssign)
				{
					EmitStoreAndLoadLocalVariable(il, nextLocalVarIndex);
				}
				il.Emit(OpCodes.Ldc_I4_1);
				il.Emit((nodeType == ExpressionType.PostIncrementAssign || nodeType == ExpressionType.PreIncrementAssign) ? OpCodes.Add : OpCodes.Sub);
				if (nodeType == ExpressionType.PreIncrementAssign || nodeType == ExpressionType.PreDecrementAssign)
				{
					EmitStoreAndLoadLocalVariable(il, nextLocalVarIndex);
				}
				if (definedLocalVarOrDefault != -1)
				{
					EmitStoreLocalVariable(il, definedLocalVarOrDefault);
				}
				else if (parameterExpression.IsByRef)
				{
					int nextLocalVarIndex2 = il.GetNextLocalVarIndex(expr.Type);
					EmitStoreLocalVariable(il, nextLocalVarIndex2);
					EmitLoadArg(il, num);
					EmitLoadLocalVariable(il, nextLocalVarIndex2);
					EmitStoreByRefValueType(il, expr.Type);
				}
				else
				{
					il.Emit(OpCodes.Starg_S, num);
				}
			}
			else if (operand is MemberExpression memberExpression)
			{
				if (!TryEmitMemberAccess(memberExpression, paramExprs, il, ref closure, setup, parent | ParentFlags.DupMemberOwner))
				{
					return false;
				}
				if (nodeType == ExpressionType.PostIncrementAssign || nodeType == ExpressionType.PostDecrementAssign)
				{
					EmitStoreAndLoadLocalVariable(il, nextLocalVarIndex);
				}
				il.Emit(OpCodes.Ldc_I4_1);
				il.Emit((nodeType == ExpressionType.PostIncrementAssign || nodeType == ExpressionType.PreIncrementAssign) ? OpCodes.Add : OpCodes.Sub);
				if (nodeType == ExpressionType.PreIncrementAssign || nodeType == ExpressionType.PreDecrementAssign)
				{
					EmitStoreAndLoadLocalVariable(il, nextLocalVarIndex);
				}
				if (!EmitMemberAssign(il, memberExpression.Member))
				{
					return false;
				}
			}
			else
			{
				if (!(operand is IndexExpression indexExpression))
				{
					return false;
				}
				if (!TryEmitIndex(indexExpression, paramExprs, il, ref closure, setup, parent | ParentFlags.IndexAccess))
				{
					return false;
				}
				if (nodeType == ExpressionType.PostIncrementAssign || nodeType == ExpressionType.PostDecrementAssign)
				{
					EmitStoreAndLoadLocalVariable(il, nextLocalVarIndex);
				}
				il.Emit(OpCodes.Ldc_I4_1);
				il.Emit((nodeType == ExpressionType.PostIncrementAssign || nodeType == ExpressionType.PreIncrementAssign) ? OpCodes.Add : OpCodes.Sub);
				if (nodeType == ExpressionType.PreIncrementAssign || nodeType == ExpressionType.PreDecrementAssign)
				{
					EmitStoreAndLoadLocalVariable(il, nextLocalVarIndex);
				}
				if (!TryEmitIndexAssign(indexExpression, indexExpression.Object?.Type, expr.Type, il))
				{
					return false;
				}
			}
			if ((parent & ParentFlags.IgnoreResult) == 0)
			{
				EmitLoadLocalVariable(il, nextLocalVarIndex);
			}
			return true;
		}

		private static bool TryEmitAssign(BinaryExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Expression left = expr.Left;
			Expression right = expr.Right;
			ExpressionType nodeType = expr.Left.NodeType;
			ExpressionType nodeType2 = expr.NodeType;
			ParentFlags parentFlags = parent & ~ParentFlags.IgnoreResult;
			switch (nodeType)
			{
			case ExpressionType.Parameter:
			{
				ParameterExpression parameterExpression = (ParameterExpression)left;
				int parameterCount = paramExprs.ParameterCount;
				int num = parameterCount - 1;
				while (num != -1 && paramExprs.GetParameter(num) != parameterExpression)
				{
					num--;
				}
				ExpressionType expressionType = nodeType2;
				switch (nodeType2)
				{
				case ExpressionType.AddAssign:
					expressionType = ExpressionType.Add;
					break;
				case ExpressionType.AddAssignChecked:
					expressionType = ExpressionType.AddChecked;
					break;
				case ExpressionType.SubtractAssign:
					expressionType = ExpressionType.Subtract;
					break;
				case ExpressionType.SubtractAssignChecked:
					expressionType = ExpressionType.SubtractChecked;
					break;
				case ExpressionType.MultiplyAssign:
					expressionType = ExpressionType.Multiply;
					break;
				case ExpressionType.MultiplyAssignChecked:
					expressionType = ExpressionType.MultiplyChecked;
					break;
				case ExpressionType.DivideAssign:
					expressionType = ExpressionType.Divide;
					break;
				case ExpressionType.ModuloAssign:
					expressionType = ExpressionType.Modulo;
					break;
				case ExpressionType.PowerAssign:
					expressionType = ExpressionType.Power;
					break;
				case ExpressionType.AndAssign:
					expressionType = ExpressionType.And;
					break;
				case ExpressionType.OrAssign:
					expressionType = ExpressionType.Or;
					break;
				case ExpressionType.ExclusiveOrAssign:
					expressionType = ExpressionType.ExclusiveOr;
					break;
				case ExpressionType.LeftShiftAssign:
					expressionType = ExpressionType.LeftShift;
					break;
				case ExpressionType.RightShiftAssign:
					expressionType = ExpressionType.RightShift;
					break;
				}
				if (num != -1)
				{
					if ((closure.Status & ClosureStatus.ShouldBeStaticMethod) == 0)
					{
						num++;
					}
					if (parameterExpression.IsByRef)
					{
						EmitLoadArg(il, num);
					}
					if (expressionType == nodeType2)
					{
						if (!TryEmit(right, paramExprs, il, ref closure, setup, parentFlags))
						{
							return false;
						}
					}
					else if (!TryEmitArithmetic(expr, expressionType, paramExprs, il, ref closure, setup, parent))
					{
						return false;
					}
					if ((parent & ParentFlags.IgnoreResult) == 0)
					{
						il.Emit(OpCodes.Dup);
					}
					if (parameterExpression.IsByRef)
					{
						EmitStoreByRefValueType(il, parameterExpression.Type);
					}
					else
					{
						il.Emit(OpCodes.Starg_S, num);
					}
					return true;
				}
				if (expressionType != nodeType2)
				{
					int definedLocalVarOrDefault = closure.GetDefinedLocalVarOrDefault(parameterExpression);
					if (definedLocalVarOrDefault != -1)
					{
						if (!TryEmitArithmetic(expr, expressionType, paramExprs, il, ref closure, setup, parent))
						{
							return false;
						}
						EmitStoreLocalVariable(il, definedLocalVarOrDefault);
						return true;
					}
				}
				int definedLocalVarOrDefault2 = closure.GetDefinedLocalVarOrDefault(parameterExpression);
				if (definedLocalVarOrDefault2 != -1)
				{
					if (!TryEmit(right, paramExprs, il, ref closure, setup, parentFlags))
					{
						return false;
					}
					ParameterExpression obj = right as ParameterExpression;
					if (obj != null && obj.IsByRef)
					{
						il.Emit(OpCodes.Ldind_I4);
					}
					if ((parent & ParentFlags.IgnoreResult) == 0)
					{
						il.Emit(OpCodes.Dup);
					}
					EmitStoreLocalVariable(il, definedLocalVarOrDefault2);
					return true;
				}
				ParameterExpression[] nonPassedParameters = closure.NonPassedParameters;
				int num2 = nonPassedParameters.Length - 1;
				while (num2 != -1 && nonPassedParameters[num2] != parameterExpression)
				{
					num2--;
				}
				if (num2 == -1)
				{
					return false;
				}
				il.Emit(OpCodes.Ldarg_0);
				if ((parent & ParentFlags.IgnoreResult) == 0)
				{
					if (!TryEmit(right, paramExprs, il, ref closure, setup, parentFlags))
					{
						return false;
					}
					int nextLocalVarIndex = il.GetNextLocalVarIndex(expr.Type);
					EmitStoreLocalVariable(il, nextLocalVarIndex);
					il.Emit(OpCodes.Ldfld, ArrayClosureWithNonPassedParamsField);
					EmitLoadConstantInt(il, num2);
					EmitLoadLocalVariable(il, nextLocalVarIndex);
					if (expr.Type.IsValueType)
					{
						il.Emit(OpCodes.Box, expr.Type);
					}
					il.Emit(OpCodes.Stelem_Ref);
					EmitLoadLocalVariable(il, nextLocalVarIndex);
				}
				else
				{
					il.Emit(OpCodes.Ldfld, ArrayClosureWithNonPassedParamsField);
					EmitLoadConstantInt(il, num2);
					if (!TryEmit(right, paramExprs, il, ref closure, setup, parentFlags))
					{
						return false;
					}
					if (expr.Type.IsValueType)
					{
						il.Emit(OpCodes.Box, expr.Type);
					}
					il.Emit(OpCodes.Stelem_Ref);
				}
				return true;
			}
			case ExpressionType.MemberAccess:
			{
				bool flag = right.NodeType == ExpressionType.Try;
				int location = -1;
				if (flag)
				{
					location = il.GetNextLocalVarIndex(right.Type);
					if (!TryEmit(right, paramExprs, il, ref closure, setup, ParentFlags.Empty))
					{
						return false;
					}
					EmitStoreLocalVariable(il, location);
				}
				MemberExpression memberExpression = (MemberExpression)left;
				Expression expression = memberExpression.Expression;
				if (expression != null && !TryEmit(expression, paramExprs, il, ref closure, setup, parentFlags | ParentFlags.MemberAccess | ParentFlags.InstanceAccess))
				{
					return false;
				}
				if (flag)
				{
					EmitLoadLocalVariable(il, location);
				}
				else if (!TryEmit(right, paramExprs, il, ref closure, setup, ParentFlags.Empty))
				{
					return false;
				}
				MemberInfo member = memberExpression.Member;
				if ((parent & ParentFlags.IgnoreResult) != ParentFlags.Empty)
				{
					return EmitMemberAssign(il, member);
				}
				il.Emit(OpCodes.Dup);
				int nextLocalVarIndex2 = il.GetNextLocalVarIndex(expr.Type);
				EmitStoreLocalVariable(il, nextLocalVarIndex2);
				if (!EmitMemberAssign(il, member))
				{
					return false;
				}
				EmitLoadLocalVariable(il, nextLocalVarIndex2);
				return true;
			}
			case ExpressionType.Index:
			{
				IndexExpression indexExpression = (IndexExpression)left;
				Expression expression2 = indexExpression.Object;
				if (expression2 != null && !TryEmit(expression2, paramExprs, il, ref closure, setup, parentFlags))
				{
					return false;
				}
				IArgumentProvider argumentProvider = indexExpression;
				int argumentCount = argumentProvider.ArgumentCount;
				for (int i = 0; i < argumentCount; i++)
				{
					if (!TryEmit(argumentProvider.GetArgument(i), paramExprs, il, ref closure, setup, parentFlags))
					{
						return false;
					}
				}
				if (!TryEmit(right, paramExprs, il, ref closure, setup, parentFlags))
				{
					return false;
				}
				if ((parent & ParentFlags.IgnoreResult) != ParentFlags.Empty)
				{
					return TryEmitIndexAssign(indexExpression, expression2?.Type, expr.Type, il);
				}
				int nextLocalVarIndex3 = il.GetNextLocalVarIndex(expr.Type);
				il.Emit(OpCodes.Dup);
				EmitStoreLocalVariable(il, nextLocalVarIndex3);
				if (!TryEmitIndexAssign(indexExpression, expression2?.Type, expr.Type, il))
				{
					return false;
				}
				EmitLoadLocalVariable(il, nextLocalVarIndex3);
				return true;
			}
			default:
				if ((setup & CompilerFlags.ThrowOnNotSupportedExpression) != CompilerFlags.Default)
				{
					throw new NotSupportedExpressionException(NotSupported.Assign_Target, $"Assignment target `{nodeType2}` is not supported");
				}
				return false;
			}
		}

		private static void EmitStoreByRefValueType(ILGenerator il, Type type)
		{
			if (type == typeof(int) || type == typeof(uint))
			{
				il.Emit(OpCodes.Stind_I4);
			}
			else if (type == typeof(byte))
			{
				il.Emit(OpCodes.Stind_I1);
			}
			else if (type == typeof(short) || type == typeof(ushort))
			{
				il.Emit(OpCodes.Stind_I2);
			}
			else if (type == typeof(long) || type == typeof(ulong))
			{
				il.Emit(OpCodes.Stind_I8);
			}
			else if (type == typeof(float))
			{
				il.Emit(OpCodes.Stind_R4);
			}
			else if (type == typeof(double))
			{
				il.Emit(OpCodes.Stind_R8);
			}
			else if (type == typeof(object))
			{
				il.Emit(OpCodes.Stind_Ref);
			}
			else if (type == typeof(nint) || type == typeof(nuint))
			{
				il.Emit(OpCodes.Stind_I);
			}
			else
			{
				il.Emit(OpCodes.Stobj, type);
			}
		}

		private static bool TryEmitIndexAssign(IndexExpression indexExpr, Type instType, Type elementType, ILGenerator il)
		{
			if (indexExpr.Indexer != null)
			{
				return EmitMemberAssign(il, indexExpr.Indexer);
			}
			if (indexExpr.Arguments.Count == 1)
			{
				if (!elementType.IsValueType)
				{
					il.Emit(OpCodes.Stelem_Ref);
					return true;
				}
				if (elementType == typeof(int))
				{
					il.Emit(OpCodes.Stelem_I4);
				}
				else if (elementType == typeof(long))
				{
					il.Emit(OpCodes.Stelem_I8);
				}
				else if (elementType == typeof(short))
				{
					il.Emit(OpCodes.Stelem_I2);
				}
				else if (elementType == typeof(sbyte))
				{
					il.Emit(OpCodes.Stelem_I1);
				}
				else if (elementType == typeof(float))
				{
					il.Emit(OpCodes.Stelem_R4);
				}
				else if (elementType == typeof(double))
				{
					il.Emit(OpCodes.Stelem_R8);
				}
				else if (elementType == typeof(nint))
				{
					il.Emit(OpCodes.Stelem_I);
				}
				else if (elementType == typeof(nuint))
				{
					il.Emit(OpCodes.Stelem_I);
				}
				else
				{
					il.Emit(OpCodes.Stelem, elementType);
				}
				return true;
			}
			MethodInfo methodInfo = instType?.FindMethod("Set");
			if (methodInfo != null)
			{
				return EmitMethodCallOrVirtualCall(il, methodInfo);
			}
			return false;
		}

		private static bool TryEmitMethodCall(Expression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			ParentFlags parentFlags = (parent & ~ParentFlags.IgnoreResult) | ParentFlags.Call;
			MethodCallExpression methodCallExpression = (MethodCallExpression)expr;
			Expression expression = methodCallExpression.Object;
			MethodInfo method = methodCallExpression.Method;
			ParameterInfo[] parameters = method.GetParameters();
			bool flag = false;
			if (expression != null)
			{
				if (!TryEmit(expression, paramExprs, il, ref closure, setup, parentFlags | ParentFlags.InstanceAccess))
				{
					return false;
				}
				flag = expression.Type.IsValueType;
				if (flag && expression.NodeType != ExpressionType.Parameter && !closure.LastEmitIsAddress)
				{
					EmitStoreAndLoadLocalVariableAddress(il, expression.Type);
				}
			}
			if (parameters.Length != 0)
			{
				parentFlags = parentFlags & ~ParentFlags.MemberAccess & ~ParentFlags.InstanceAccess;
				IArgumentProvider argumentProvider = methodCallExpression;
				for (int i = 0; i < parameters.Length; i++)
				{
					if (!TryEmit(argumentProvider.GetArgument(i), paramExprs, il, ref closure, setup, parentFlags, parameters[i].ParameterType.IsByRef ? i : (-1)))
					{
						return false;
					}
				}
			}
			bool flag2 = true;
			if (!flag)
			{
				flag2 = EmitMethodCallOrVirtualCall(il, method);
			}
			else if (!method.IsVirtual || expression is ParameterExpression { IsByRef: not false } || method.DeclaringType == expression.Type)
			{
				flag2 = EmitMethodCall(il, method);
			}
			else
			{
				il.Emit(OpCodes.Constrained, expression.Type);
				flag2 = EmitVirtualMethodCall(il, method);
			}
			if (parent.IgnoresResult() && method.ReturnType != typeof(void))
			{
				il.Emit(OpCodes.Pop);
			}
			closure.LastEmitIsAddress = false;
			return flag2;
		}

		public static bool TryEmitMemberAccess(MemberExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent, int byRefIndex = -1)
		{
			if (expr.Member is PropertyInfo propertyInfo)
			{
				Expression expression = expr.Expression;
				if (expression != null)
				{
					ParentFlags parent2 = (parent | ParentFlags.Call | ParentFlags.MemberAccess | ParentFlags.InstanceAccess) & ~ParentFlags.IgnoreResult & ~ParentFlags.DupMemberOwner;
					if (!TryEmit(expression, paramExprs, il, ref closure, setup, parent2))
					{
						return false;
					}
					if ((parent & ParentFlags.DupMemberOwner) != ParentFlags.Empty)
					{
						il.Emit(OpCodes.Dup);
					}
					if (!closure.LastEmitIsAddress && expression.NodeType != ExpressionType.Parameter && expression.Type.IsValueType)
					{
						EmitStoreAndLoadLocalVariableAddress(il, expression.Type);
					}
				}
				closure.LastEmitIsAddress = false;
				return EmitMethodCallOrVirtualCall(il, propertyInfo.GetMethod);
			}
			if (expr.Member is FieldInfo fieldInfo)
			{
				Expression expression2 = expr.Expression;
				if (expression2 != null)
				{
					ParentFlags parent3 = (parent | ParentFlags.MemberAccess | ParentFlags.InstanceAccess) & ~ParentFlags.IgnoreResult & ~ParentFlags.DupMemberOwner;
					if (!TryEmit(expression2, paramExprs, il, ref closure, setup, parent3))
					{
						return false;
					}
					if ((parent & ParentFlags.DupMemberOwner) != ParentFlags.Empty)
					{
						il.Emit(OpCodes.Dup);
					}
					bool flag = byRefIndex != -1;
					if (fieldInfo.FieldType.IsValueType)
					{
						if ((parent & ParentFlags.InstanceAccess) != ParentFlags.Empty && (parent & ParentFlags.IndexAccess) == 0)
						{
							flag = true;
						}
						else if ((parent & ParentFlags.Call) != ParentFlags.Empty && byRefIndex != -1)
						{
							flag = true;
						}
					}
					closure.LastEmitIsAddress = flag;
					il.Emit(flag ? OpCodes.Ldflda : OpCodes.Ldfld, fieldInfo);
				}
				else if (fieldInfo.IsLiteral)
				{
					object value = fieldInfo.GetValue(null);
					if (value != null)
					{
						return TryEmitConstantOfNotNullValue(considerClosure: false, fieldInfo.FieldType, value, il, ref closure);
					}
					il.Emit(OpCodes.Ldnull);
				}
				else
				{
					il.Emit(OpCodes.Ldsfld, fieldInfo);
				}
				return true;
			}
			return false;
		}

		private static bool TryEmitNestedLambda(LambdaExpression lambdaExpr, IParameterProvider outerParamExprs, ILGenerator il, ref ClosureInfo closure)
		{
			int parameterCount = outerParamExprs.ParameterCount;
			int count = closure.Constants.Count;
			object nestedLambdaOrLambdas = closure.NestedLambdaOrLambdas;
			NestedLambdaInfo nestedLambdaInfo = nestedLambdaOrLambdas as NestedLambdaInfo;
			if (nestedLambdaInfo != null)
			{
				if (nestedLambdaInfo.LambdaExpression != lambdaExpr)
				{
					return false;
				}
			}
			else
			{
				NestedLambdaInfo[] array = (NestedLambdaInfo[])nestedLambdaOrLambdas;
				for (int i = 0; i < array.Length; i++)
				{
					if (nestedLambdaInfo != null)
					{
						break;
					}
					NestedLambdaInfo nestedLambdaInfo2 = array[i];
					if (nestedLambdaInfo2.LambdaExpression == lambdaExpr)
					{
						nestedLambdaInfo = nestedLambdaInfo2;
						count += i;
						break;
					}
				}
				if (nestedLambdaInfo == null)
				{
					return false;
				}
			}
			EmitLoadLocalVariable(il, nestedLambdaInfo.LambdaVarIndex);
			ref ClosureInfo closureInfo = ref nestedLambdaInfo.ClosureInfo;
			ParameterExpression[] nonPassedParameters = closureInfo.NonPassedParameters;
			if (nonPassedParameters.Length == 0)
			{
				return true;
			}
			bool flag = closureInfo.ContainsConstantsOrNestedLambdas();
			if (flag)
			{
				il.Emit(OpCodes.Ldfld, NestedLambdaWithConstantsAndNestedLambdas.NestedLambdaField);
				EmitLoadLocalVariable(il, nestedLambdaInfo.LambdaVarIndex);
				il.Emit(OpCodes.Ldfld, NestedLambdaWithConstantsAndNestedLambdas.ConstantsAndNestedLambdasField);
			}
			EmitLoadConstantInt(il, nonPassedParameters.Length);
			il.Emit(OpCodes.Newarr, typeof(object));
			ParameterExpression[] nonPassedParameters2 = closure.NonPassedParameters;
			for (int j = 0; j < nonPassedParameters.Length; j++)
			{
				ParameterExpression parameterExpression = nonPassedParameters[j];
				il.Emit(OpCodes.Dup);
				EmitLoadConstantInt(il, j);
				int num = parameterCount - 1;
				while (num != -1 && outerParamExprs.GetParameter(num) != parameterExpression)
				{
					num--;
				}
				if (num != -1)
				{
					EmitLoadArg(il, num + 1);
					if (parameterExpression.Type.IsValueType)
					{
						il.Emit(OpCodes.Box, parameterExpression.Type);
					}
				}
				else
				{
					if (nonPassedParameters2.Length == 0)
					{
						return false;
					}
					int definedLocalVarOrDefault = closure.GetDefinedLocalVarOrDefault(parameterExpression);
					if (definedLocalVarOrDefault != -1)
					{
						EmitLoadLocalVariable(il, definedLocalVarOrDefault);
						if (parameterExpression.Type.IsValueType)
						{
							il.Emit(OpCodes.Box, parameterExpression.Type);
						}
					}
					else
					{
						int num2 = nonPassedParameters2.Length - 1;
						while (num2 != -1 && nonPassedParameters2[num2] != parameterExpression)
						{
							num2--;
						}
						if (num2 == -1)
						{
							return false;
						}
						il.Emit(OpCodes.Ldarg_0);
						il.Emit(OpCodes.Ldfld, ArrayClosureWithNonPassedParamsField);
						EmitLoadConstantInt(il, num2);
						il.Emit(OpCodes.Ldelem_Ref);
					}
				}
				il.Emit(OpCodes.Stelem_Ref);
			}
			ConstructorInfo con = (flag ? ArrayClosureWithNonPassedParamsConstructor : ArrayClosureWithNonPassedParamsConstructorWithoutConstants);
			il.Emit(OpCodes.Newobj, con);
			Type[] genericArguments = nestedLambdaInfo.Lambda.GetType().GetGenericArguments();
			LambdaExpression lambdaExpression = nestedLambdaInfo.LambdaExpression;
			MethodInfo methodInfo = ((lambdaExpression.ReturnType == typeof(void)) ? CurryClosureActions.Methods[genericArguments.Length - 1].MakeGenericMethod(genericArguments) : CurryClosureFuncs.Methods[genericArguments.Length - 2].MakeGenericMethod(genericArguments));
			EmitMethodCall(il, methodInfo);
			if (methodInfo.ReturnType != lambdaExpression.Type)
			{
				il.Emit(OpCodes.Ldftn, methodInfo.ReturnType.FindDelegateInvokeMethod());
				il.Emit(OpCodes.Newobj, lambdaExpression.Type.GetConstructors()[0]);
			}
			return true;
		}

		private static bool TryEmitInvoke(InvocationExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			int parameterCount = paramExprs.ParameterCount;
			int argumentCount = ((IArgumentProvider)expr).ArgumentCount;
			Expression expression = expr.Expression;
			if ((setup & CompilerFlags.NoInvocationLambdaInlining) == 0 && expression is LambdaExpression lambdaExpression)
			{
				parent |= ParentFlags.InlinedLambdaInvoke;
				if (argumentCount == 0)
				{
					return TryEmit(lambdaExpression.Body, paramExprs, il, ref closure, setup, parent);
				}
				IParameterProvider parameterProvider = lambdaExpression;
				Expression[] array = new Expression[argumentCount + 1];
				List<ParameterExpression> list = null;
				for (int i = 0; i < argumentCount; i++)
				{
					ParameterExpression parameter = parameterProvider.GetParameter(i);
					int num = parameterCount - 1;
					while (num != -1 && parameter != paramExprs.GetParameter(num))
					{
						num--;
					}
					if (num != -1 || closure.IsLocalVar(parameter))
					{
						if (list == null)
						{
							list = new List<ParameterExpression>();
							for (int j = 0; j < i; j++)
							{
								list.Add(parameterProvider.GetParameter(j));
							}
						}
					}
					else
					{
						list?.Add(parameter);
					}
					array[i] = Expression.Assign(parameter, ((IArgumentProvider)expr).GetArgument(i));
				}
				array[argumentCount] = lambdaExpression.Body;
				IReadOnlyList<ParameterExpression> readOnlyList = list;
				if (!TryEmit(Expression.Block(readOnlyList ?? parameterProvider.ToReadOnlyList(), array), paramExprs, il, ref closure, setup, parent))
				{
					return false;
				}
				if ((parent & ParentFlags.IgnoreResult) == 0 && lambdaExpression.Body.Type != typeof(void))
				{
					short labelOrInvokeIndex = closure.GetLabelOrInvokeIndex(expr);
					if (labelOrInvokeIndex != -1)
					{
						ref LabelInfo reference = ref closure.Labels.Items[labelOrInvokeIndex];
						int num2 = reference.ReturnVariableIndexPlusOneAndIsDefined >> 1;
						if (num2 != 0)
						{
							il.MarkLabel(reference.ReturnLabel);
							EmitLoadLocalVariable(il, num2 - 1);
						}
					}
				}
				return true;
			}
			if (!TryEmit(expression, paramExprs, il, ref closure, setup, parent & ~ParentFlags.IgnoreResult))
			{
				return false;
			}
			MethodInfo methodInfo = expression.Type.FindDelegateInvokeMethod();
			if (argumentCount > 0)
			{
				ParentFlags parent2 = parent & ~ParentFlags.IgnoreResult & ~ParentFlags.InstanceAccess;
				ParameterInfo[] parameters = methodInfo.GetParameters();
				for (int k = 0; k < parameters.Length; k++)
				{
					Expression argument = ((IArgumentProvider)expr).GetArgument(k);
					if (!TryEmit(argument, paramExprs, il, ref closure, setup, parent2, parameters[k].ParameterType.IsByRef ? k : (-1)))
					{
						return false;
					}
				}
			}
			EmitMethodCall(il, methodInfo);
			if ((parent & ParentFlags.IgnoreResult) != ParentFlags.Empty && methodInfo.ReturnType != typeof(void))
			{
				il.Emit(OpCodes.Pop);
			}
			return true;
		}

		private static bool TryEmitSwitch(SwitchExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Label label = il.DefineLabel();
			IReadOnlyList<SwitchCase> cases = expr.Cases;
			Label[] array = new Label[cases.Count];
			ParentFlags parent2 = parent & ~ParentFlags.IgnoreResult;
			for (int i = 0; i < cases.Count; i++)
			{
				SwitchCase switchCase = cases[i];
				array[i] = il.DefineLabel();
				foreach (Expression testValue in switchCase.TestValues)
				{
					if (!TryEmitComparison(expr.SwitchValue, testValue, ExpressionType.Equal, typeof(bool), paramExprs, il, ref closure, setup, parent2))
					{
						return false;
					}
					il.Emit(OpCodes.Brtrue, array[i]);
				}
			}
			if (expr.DefaultBody != null)
			{
				if (!TryEmit(expr.DefaultBody, paramExprs, il, ref closure, setup, parent))
				{
					return false;
				}
				il.Emit(OpCodes.Br, label);
			}
			for (int j = 0; j < cases.Count; j++)
			{
				il.MarkLabel(array[j]);
				if (!TryEmit(cases[j].Body, paramExprs, il, ref closure, setup, parent))
				{
					return false;
				}
				if (j != cases.Count - 1)
				{
					il.Emit(OpCodes.Br, label);
				}
			}
			il.MarkLabel(label);
			return true;
		}

		private static bool TryEmitComparison(Expression exprLeft, Expression exprRight, ExpressionType expressionType, Type exprType, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Type type = exprLeft.Type;
			bool flag = type.IsNullable();
			Type type2 = exprRight.Type;
			if (exprRight is ConstantExpression { Value: null } && exprRight.Type == typeof(object))
			{
				type2 = type;
			}
			int location = -1;
			int location2 = -1;
			ParentFlags parent2 = parent & ~ParentFlags.IgnoreResult & ~ParentFlags.InstanceAccess;
			if (!TryEmit(exprLeft, paramExprs, il, ref closure, setup, parent2))
			{
				return false;
			}
			if (flag)
			{
				location = EmitStoreAndLoadLocalVariableAddress(il, type);
				EmitMethodCall(il, type.FindNullableGetValueOrDefaultMethod());
				type = Nullable.GetUnderlyingType(type);
			}
			if (!TryEmit(exprRight, paramExprs, il, ref closure, setup, parent2))
			{
				return false;
			}
			if (type != type2 && type.IsClass && type2.IsClass && (type == typeof(object) || type2 == typeof(object)))
			{
				switch (expressionType)
				{
				case ExpressionType.Equal:
					il.Emit(OpCodes.Ceq);
					break;
				case ExpressionType.NotEqual:
					il.Emit(OpCodes.Ceq);
					il.Emit(OpCodes.Ldc_I4_0);
					il.Emit(OpCodes.Ceq);
					break;
				default:
					return false;
				}
				return il.EmitPopIfIgnoreResult(parent);
			}
			if (type2.IsNullable())
			{
				location2 = EmitStoreAndLoadLocalVariableAddress(il, type2);
				EmitMethodCall(il, type2.FindNullableGetValueOrDefaultMethod());
				type2 = Nullable.GetUnderlyingType(type2);
			}
			if (!type.IsPrimitive && !type.IsEnum)
			{
				string text = expressionType switch
				{
					ExpressionType.LessThanOrEqual => "op_LessThanOrEqual", 
					ExpressionType.LessThan => "op_LessThan", 
					ExpressionType.GreaterThanOrEqual => "op_GreaterThanOrEqual", 
					ExpressionType.GreaterThan => "op_GreaterThan", 
					ExpressionType.NotEqual => "op_Inequality", 
					ExpressionType.Equal => "op_Equality", 
					_ => null, 
				};
				if (text == null)
				{
					return false;
				}
				MethodInfo[] methods = type.GetMethods();
				foreach (MethodInfo methodInfo in methods)
				{
					if (methodInfo.IsSpecialName && methodInfo.IsStatic && methodInfo.Name == text)
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						if (parameters.Length == 2 && parameters[0].ParameterType == type && parameters[1].ParameterType == type)
						{
							EmitMethodCall(il, methodInfo);
							return true;
						}
					}
				}
				if (expressionType != ExpressionType.Equal && expressionType != ExpressionType.NotEqual)
				{
					return false;
				}
				EmitMethodCall(il, _objectEqualsMethod);
				if (expressionType == ExpressionType.NotEqual)
				{
					il.Emit(OpCodes.Ldc_I4_0);
					il.Emit(OpCodes.Ceq);
				}
				if (!flag)
				{
					return il.EmitPopIfIgnoreResult(parent);
				}
			}
			else
			{
				switch (expressionType)
				{
				case ExpressionType.Equal:
					il.Emit(OpCodes.Ceq);
					break;
				case ExpressionType.NotEqual:
					il.Emit(OpCodes.Ceq);
					il.Emit(OpCodes.Ldc_I4_0);
					il.Emit(OpCodes.Ceq);
					break;
				case ExpressionType.LessThan:
					il.Emit(OpCodes.Clt);
					break;
				case ExpressionType.GreaterThan:
					il.Emit(OpCodes.Cgt);
					break;
				case ExpressionType.GreaterThanOrEqual:
					if (type.IsUnsigned() && type2.IsUnsigned())
					{
						il.Emit(OpCodes.Clt_Un);
					}
					else
					{
						il.Emit(OpCodes.Clt);
					}
					il.Emit(OpCodes.Ldc_I4_0);
					il.Emit(OpCodes.Ceq);
					break;
				case ExpressionType.LessThanOrEqual:
					if (type.IsUnsigned() && type2.IsUnsigned())
					{
						il.Emit(OpCodes.Cgt_Un);
					}
					else
					{
						il.Emit(OpCodes.Cgt);
					}
					il.Emit(OpCodes.Ldc_I4_0);
					il.Emit(OpCodes.Ceq);
					break;
				default:
					return false;
				}
			}
			if (flag)
			{
				MethodInfo method = exprLeft.Type.FindNullableHasValueGetterMethod();
				EmitLoadLocalVariableAddress(il, location);
				EmitMethodCall(il, method);
				bool flag2 = exprType == typeof(bool?);
				int location3 = -1;
				if (flag2)
				{
					EmitStoreAndLoadLocalVariable(il, location3 = il.GetNextLocalVarIndex(typeof(bool)));
				}
				EmitLoadLocalVariableAddress(il, location2);
				EmitMethodCall(il, method);
				int location4 = -1;
				if (flag2)
				{
					EmitStoreAndLoadLocalVariable(il, location4 = il.GetNextLocalVarIndex(typeof(bool)));
				}
				switch (expressionType)
				{
				case ExpressionType.Equal:
					il.Emit(OpCodes.Ceq);
					il.Emit(OpCodes.And);
					break;
				case ExpressionType.NotEqual:
					il.Emit(OpCodes.Ceq);
					il.Emit(OpCodes.Ldc_I4_0);
					il.Emit(OpCodes.Ceq);
					il.Emit(OpCodes.Or);
					break;
				case ExpressionType.GreaterThan:
				case ExpressionType.GreaterThanOrEqual:
				case ExpressionType.LessThan:
				case ExpressionType.LessThanOrEqual:
					il.Emit(OpCodes.Ceq);
					il.Emit(OpCodes.Ldc_I4_1);
					il.Emit(OpCodes.Ceq);
					il.Emit(OpCodes.And);
					break;
				default:
					return false;
				}
				if (flag2)
				{
					Label label = il.DefineLabel();
					Label label2 = il.DefineLabel();
					EmitLoadLocalVariable(il, location3);
					il.Emit(OpCodes.Brfalse, label2);
					EmitLoadLocalVariable(il, location4);
					il.Emit(OpCodes.Brtrue, label);
					il.MarkLabel(label2);
					il.Emit(OpCodes.Pop);
					il.Emit(OpCodes.Ldnull);
					il.MarkLabel(label);
				}
			}
			return il.EmitPopIfIgnoreResult(parent);
		}

		private static bool TryEmitArithmetic(BinaryExpression expr, ExpressionType exprNodeType, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			ParentFlags parentFlags = (parent & ~ParentFlags.IgnoreResult & ~ParentFlags.InstanceCall) | ParentFlags.Arithmetic;
			Label label = default(Label);
			Expression left = expr.Left;
			Type type = left.Type;
			bool flag = type.IsNullable();
			if (flag)
			{
				label = il.DefineLabel();
				if (!TryEmit(left, paramExprs, il, ref closure, setup, parentFlags | ParentFlags.InstanceCall))
				{
					return false;
				}
				if (!closure.LastEmitIsAddress)
				{
					EmitStoreAndLoadLocalVariableAddress(il, type);
				}
				il.Emit(OpCodes.Dup);
				EmitMethodCall(il, type.FindNullableHasValueGetterMethod());
				il.Emit(OpCodes.Brfalse, label);
				EmitMethodCall(il, type.FindNullableGetValueOrDefaultMethod());
			}
			else if (!TryEmit(left, paramExprs, il, ref closure, setup, parentFlags))
			{
				return false;
			}
			Label label2 = default(Label);
			Expression right = expr.Right;
			Type type2 = right.Type;
			bool flag2 = type2.IsNullable();
			if (flag2)
			{
				label2 = il.DefineLabel();
				if (!TryEmit(right, paramExprs, il, ref closure, setup, parentFlags | ParentFlags.InstanceCall))
				{
					return false;
				}
				if (!closure.LastEmitIsAddress)
				{
					EmitStoreAndLoadLocalVariableAddress(il, type2);
				}
				il.Emit(OpCodes.Dup);
				EmitMethodCall(il, type2.FindNullableHasValueGetterMethod());
				il.Emit(OpCodes.Brfalse, label2);
				EmitMethodCall(il, type2.FindNullableGetValueOrDefaultMethod());
			}
			else if (!TryEmit(right, paramExprs, il, ref closure, setup, parentFlags))
			{
				return false;
			}
			Type type3 = expr.Type;
			if (!TryEmitArithmeticOperation(expr, exprNodeType, type3, il))
			{
				return false;
			}
			if (flag || flag2)
			{
				Label label3 = il.DefineLabel();
				il.Emit(OpCodes.Br, label3);
				if (flag2)
				{
					il.MarkLabel(label2);
				}
				il.Emit(OpCodes.Pop);
				if (flag)
				{
					il.MarkLabel(label);
				}
				il.Emit(OpCodes.Pop);
				if (type3.IsNullable())
				{
					Label label4 = il.DefineLabel();
					EmitLoadLocalVariable(il, InitValueTypeVariable(il, type3));
					il.Emit(OpCodes.Br_S, label4);
					il.MarkLabel(label3);
					il.Emit(OpCodes.Newobj, type3.GetConstructors()[0]);
					il.MarkLabel(label4);
				}
				else
				{
					il.Emit(OpCodes.Ldc_I4_0);
					il.MarkLabel(label3);
				}
			}
			return true;
		}

		private static bool TryEmitArithmeticOperation(BinaryExpression expr, ExpressionType exprNodeType, Type exprType, ILGenerator il)
		{
			if (!exprType.IsPrimitive)
			{
				if (exprType.IsNullable())
				{
					exprType = Nullable.GetUnderlyingType(exprType);
				}
				if (!exprType.IsPrimitive)
				{
					MethodInfo methodInfo = null;
					if (exprType == typeof(string))
					{
						Type typeFromHandle = typeof(string);
						if (expr.Left.Type != expr.Right.Type || expr.Left.Type != typeof(string))
						{
							typeFromHandle = typeof(object);
						}
						MethodInfo[] methods = typeof(string).GetMethods();
						foreach (MethodInfo methodInfo2 in methods)
						{
							if (methodInfo2.IsStatic && methodInfo2.Name == "Concat" && methodInfo2.GetParameters().Length == 2 && methodInfo2.GetParameters()[0].ParameterType == typeFromHandle)
							{
								methodInfo = methodInfo2;
								break;
							}
						}
					}
					else
					{
						string arithmeticBinaryOperatorMethodName = exprNodeType.GetArithmeticBinaryOperatorMethodName();
						if (arithmeticBinaryOperatorMethodName != null)
						{
							MethodInfo[] methods2 = exprType.GetMethods();
							int num = 0;
							while (methodInfo == null && num < methods2.Length)
							{
								MethodInfo methodInfo3 = methods2[num];
								if (methodInfo3.IsSpecialName && methodInfo3.IsStatic && methodInfo3.Name == arithmeticBinaryOperatorMethodName)
								{
									methodInfo = methodInfo3;
								}
								num++;
							}
						}
					}
					if (methodInfo != null)
					{
						return EmitMethodCallOrVirtualCall(il, methodInfo);
					}
					return false;
				}
			}
			switch (exprNodeType)
			{
			case ExpressionType.Add:
			case ExpressionType.AddAssign:
				il.Emit(OpCodes.Add);
				return true;
			case ExpressionType.AddChecked:
			case ExpressionType.AddAssignChecked:
				il.Emit(exprType.IsUnsigned() ? OpCodes.Add_Ovf_Un : OpCodes.Add_Ovf);
				return true;
			case ExpressionType.Subtract:
			case ExpressionType.SubtractAssign:
				il.Emit(OpCodes.Sub);
				return true;
			case ExpressionType.SubtractChecked:
			case ExpressionType.SubtractAssignChecked:
				il.Emit(exprType.IsUnsigned() ? OpCodes.Sub_Ovf_Un : OpCodes.Sub_Ovf);
				return true;
			case ExpressionType.Multiply:
			case ExpressionType.MultiplyAssign:
				il.Emit(OpCodes.Mul);
				return true;
			case ExpressionType.MultiplyChecked:
			case ExpressionType.MultiplyAssignChecked:
				il.Emit(exprType.IsUnsigned() ? OpCodes.Mul_Ovf_Un : OpCodes.Mul_Ovf);
				return true;
			case ExpressionType.Divide:
			case ExpressionType.DivideAssign:
				il.Emit(OpCodes.Div);
				return true;
			case ExpressionType.Modulo:
			case ExpressionType.ModuloAssign:
				il.Emit(OpCodes.Rem);
				return true;
			case ExpressionType.And:
			case ExpressionType.AndAssign:
				il.Emit(OpCodes.And);
				return true;
			case ExpressionType.Or:
			case ExpressionType.OrAssign:
				il.Emit(OpCodes.Or);
				return true;
			case ExpressionType.ExclusiveOr:
			case ExpressionType.ExclusiveOrAssign:
				il.Emit(OpCodes.Xor);
				return true;
			case ExpressionType.LeftShift:
			case ExpressionType.LeftShiftAssign:
				il.Emit(OpCodes.Shl);
				return true;
			case ExpressionType.RightShift:
			case ExpressionType.RightShiftAssign:
				il.Emit(OpCodes.Shr);
				return true;
			case ExpressionType.Power:
				EmitMethodCall(il, typeof(Math).FindMethod("Pow"));
				return true;
			default:
				return false;
			}
		}

		private static bool TryEmitLogicalOperator(BinaryExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			if (!TryEmit(expr.Left, paramExprs, il, ref closure, setup, parent))
			{
				return false;
			}
			Label label = il.DefineLabel();
			il.Emit((expr.NodeType == ExpressionType.AndAlso) ? OpCodes.Brfalse : OpCodes.Brtrue, label);
			if (!TryEmit(expr.Right, paramExprs, il, ref closure, setup, parent))
			{
				return false;
			}
			Label label2 = il.DefineLabel();
			il.Emit(OpCodes.Br, label2);
			il.MarkLabel(label);
			il.Emit((expr.NodeType == ExpressionType.AndAlso) ? OpCodes.Ldc_I4_0 : OpCodes.Ldc_I4_1);
			il.MarkLabel(label2);
			return true;
		}

		private static bool TryEmitConditional(ConditionalExpression expr, IParameterProvider paramExprs, ILGenerator il, ref ClosureInfo closure, CompilerFlags setup, ParentFlags parent)
		{
			Expression expression = TryReduceCondition(expr.Test);
			int num = -1;
			Type type = null;
			if (expression is BinaryExpression binaryExpression && (binaryExpression.NodeType == ExpressionType.Equal || binaryExpression.NodeType == ExpressionType.NotEqual))
			{
				object obj = null;
				if (binaryExpression.Right is ConstantExpression { Value: var value })
				{
					if (value == null)
					{
						num = 0;
						if (binaryExpression.Left.Type.IsNullable())
						{
							type = binaryExpression.Left.Type;
							parent |= ParentFlags.MemberAccess;
						}
					}
					else if (value is bool flag)
					{
						num = (flag ? 1 : 0);
					}
					else if ((value is int && (int)value == 0) || (value is byte && (byte)value == 0))
					{
						num = 0;
					}
					if (num != -1 && !TryEmit(binaryExpression.Left, paramExprs, il, ref closure, setup, parent & ~ParentFlags.IgnoreResult))
					{
						return false;
					}
				}
				else if (binaryExpression.Left is ConstantExpression { Value: var value2 })
				{
					if (value2 == null)
					{
						num = 0;
						if (binaryExpression.Right.Type.IsNullable())
						{
							type = binaryExpression.Right.Type;
							parent |= ParentFlags.MemberAccess;
						}
					}
					else if (value2 is bool flag2)
					{
						num = (flag2 ? 1 : 0);
					}
					else if ((value2 is int && (int)value2 == 0) || (value2 is byte && (byte)value2 == 0))
					{
						num = 0;
					}
					if (num != -1 && !TryEmit(binaryExpression.Right, paramExprs, il, ref closure, setup, parent & ~ParentFlags.IgnoreResult))
					{
						return false;
					}
				}
			}
			if (num == -1 && !TryEmit(expression, paramExprs, il, ref closure, setup, parent & ~ParentFlags.IgnoreResult))
			{
				return false;
			}
			if (type != null)
			{
				if (!closure.LastEmitIsAddress)
				{
					EmitStoreAndLoadLocalVariableAddress(il, type);
				}
				EmitMethodCall(il, type.FindNullableHasValueGetterMethod());
			}
			Label label = il.DefineLabel();
			if ((expression.NodeType == ExpressionType.Equal && num == 0) || (expression.NodeType == ExpressionType.NotEqual && num == 1))
			{
				il.Emit(OpCodes.Brtrue, label);
			}
			else
			{
				il.Emit(OpCodes.Brfalse, label);
			}
			if (!TryEmit(expr.IfTrue, paramExprs, il, ref closure, setup, parent))
			{
				return false;
			}
			Expression ifFalse = expr.IfFalse;
			if (ifFalse.NodeType == ExpressionType.Default && ifFalse.Type == typeof(void))
			{
				il.MarkLabel(label);
			}
			else
			{
				Label label2 = il.DefineLabel();
				il.Emit(OpCodes.Br, label2);
				il.MarkLabel(label);
				if (!TryEmit(ifFalse, paramExprs, il, ref closure, setup, parent))
				{
					return false;
				}
				il.MarkLabel(label2);
			}
			return true;
		}

		private static Expression TryReduceCondition(Expression testExpr)
		{
			if (testExpr.NodeType == ExpressionType.Not)
			{
				Expression expression = TryReduceCondition(((UnaryExpression)testExpr).Operand);
				if (expression.NodeType == ExpressionType.Equal)
				{
					BinaryExpression binaryExpression = (BinaryExpression)expression;
					return Expression.NotEqual(binaryExpression.Left, binaryExpression.Right);
				}
				if (expression.NodeType == ExpressionType.NotEqual)
				{
					BinaryExpression binaryExpression2 = (BinaryExpression)expression;
					return Expression.Equal(binaryExpression2.Left, binaryExpression2.Right);
				}
			}
			else if (testExpr is BinaryExpression binaryExpression3)
			{
				if (binaryExpression3.NodeType == ExpressionType.OrElse || binaryExpression3.NodeType == ExpressionType.Or)
				{
					if (binaryExpression3.Left is ConstantExpression { Value: var value } constantExpression && value is bool)
					{
						if (!(bool)value)
						{
							return TryReduceCondition(binaryExpression3.Right);
						}
						return constantExpression;
					}
					if (binaryExpression3.Right is ConstantExpression { Value: var value2 } && value2 is bool && !(bool)value2)
					{
						return TryReduceCondition(binaryExpression3.Left);
					}
				}
				else if (binaryExpression3.NodeType == ExpressionType.AndAlso || binaryExpression3.NodeType == ExpressionType.And)
				{
					if (binaryExpression3.Left is ConstantExpression { Value: var value3 } constantExpression3 && value3 is bool)
					{
						if ((bool)value3)
						{
							return TryReduceCondition(binaryExpression3.Right);
						}
						return constantExpression3;
					}
					bool flag = default(bool);
					int num;
					if (binaryExpression3.Right is ConstantExpression { Value: var value4 })
					{
						if (value4 is bool)
						{
							flag = (bool)value4;
							num = 1;
						}
						else
						{
							num = 0;
						}
					}
					else
					{
						num = 0;
					}
					if (((uint)num & (flag ? 1u : 0u)) != 0)
					{
						return TryReduceCondition(binaryExpression3.Left);
					}
				}
			}
			return testExpr;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool EmitMethodCallOrVirtualCall(ILGenerator il, MethodInfo method)
		{
			bool result = (method.CallingConvention & CallingConventions.VarArgs) == 0;
			il.Emit(method.IsVirtual ? OpCodes.Callvirt : OpCodes.Call, method);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool EmitVirtualMethodCall(ILGenerator il, MethodInfo method)
		{
			bool result = (method.CallingConvention & CallingConventions.VarArgs) == 0;
			il.Emit(OpCodes.Callvirt, method);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool EmitMethodCall(ILGenerator il, MethodInfo method)
		{
			bool result = (method.CallingConvention & CallingConventions.VarArgs) == 0;
			il.Emit(OpCodes.Call, method);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void EmitLoadConstantInt(ILGenerator il, int i)
		{
			switch (i)
			{
			case -1:
				il.Emit(OpCodes.Ldc_I4_M1);
				return;
			case 0:
				il.Emit(OpCodes.Ldc_I4_0);
				return;
			case 1:
				il.Emit(OpCodes.Ldc_I4_1);
				return;
			case 2:
				il.Emit(OpCodes.Ldc_I4_2);
				return;
			case 3:
				il.Emit(OpCodes.Ldc_I4_3);
				return;
			case 4:
				il.Emit(OpCodes.Ldc_I4_4);
				return;
			case 5:
				il.Emit(OpCodes.Ldc_I4_5);
				return;
			case 6:
				il.Emit(OpCodes.Ldc_I4_6);
				return;
			case 7:
				il.Emit(OpCodes.Ldc_I4_7);
				return;
			case 8:
				il.Emit(OpCodes.Ldc_I4_8);
				return;
			}
			if (i > -129 && i < 128)
			{
				il.Emit(OpCodes.Ldc_I4_S, (sbyte)i);
			}
			else
			{
				il.Emit(OpCodes.Ldc_I4, i);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void EmitLoadLocalVariableAddress(ILGenerator il, int location)
		{
			if ((uint)location <= 255u)
			{
				il.Emit(OpCodes.Ldloca_S, (byte)location);
			}
			else
			{
				il.Emit(OpCodes.Ldloca, (short)location);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void EmitLoadLocalVariable(ILGenerator il, int location)
		{
			if (location == 0)
			{
				il.Emit(OpCodes.Ldloc_0);
			}
			else if (location == 1)
			{
				il.Emit(OpCodes.Ldloc_1);
			}
			else if (location == 2)
			{
				il.Emit(OpCodes.Ldloc_2);
			}
			else if (location == 3)
			{
				il.Emit(OpCodes.Ldloc_3);
			}
			else if ((uint)location <= 255u)
			{
				il.Emit(OpCodes.Ldloc_S, (byte)location);
			}
			else
			{
				il.Emit(OpCodes.Ldloc, (short)location);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void EmitStoreLocalVariable(ILGenerator il, int location)
		{
			if (location == 0)
			{
				il.Emit(OpCodes.Stloc_0);
			}
			else if (location == 1)
			{
				il.Emit(OpCodes.Stloc_1);
			}
			else if (location == 2)
			{
				il.Emit(OpCodes.Stloc_2);
			}
			else if (location == 3)
			{
				il.Emit(OpCodes.Stloc_3);
			}
			else if ((uint)location <= 255u)
			{
				il.Emit(OpCodes.Stloc_S, (byte)location);
			}
			else
			{
				il.Emit(OpCodes.Stloc, (short)location);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void EmitStoreAndLoadLocalVariable(ILGenerator il, int location)
		{
			if (location == 0)
			{
				il.Emit(OpCodes.Stloc_0);
				il.Emit(OpCodes.Ldloc_0);
			}
			else if (location == 1)
			{
				il.Emit(OpCodes.Stloc_1);
				il.Emit(OpCodes.Ldloc_1);
			}
			else if (location == 2)
			{
				il.Emit(OpCodes.Stloc_2);
				il.Emit(OpCodes.Ldloc_2);
			}
			else if (location == 3)
			{
				il.Emit(OpCodes.Stloc_3);
				il.Emit(OpCodes.Ldloc_3);
			}
			else if ((uint)location <= 255u)
			{
				il.Emit(OpCodes.Stloc_S, (byte)location);
				il.Emit(OpCodes.Ldloc_S, (byte)location);
			}
			else
			{
				il.Emit(OpCodes.Stloc, (short)location);
				il.Emit(OpCodes.Ldloc, (short)location);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int EmitStoreAndLoadLocalVariableAddress(ILGenerator il, Type type)
		{
			int nextLocalVarIndex = il.GetNextLocalVarIndex(type);
			if (nextLocalVarIndex == 0)
			{
				il.Emit(OpCodes.Stloc_0);
				il.Emit(OpCodes.Ldloca_S, (byte)0);
			}
			else if (nextLocalVarIndex == 1)
			{
				il.Emit(OpCodes.Stloc_1);
				il.Emit(OpCodes.Ldloca_S, (byte)1);
			}
			else if (nextLocalVarIndex == 2)
			{
				il.Emit(OpCodes.Stloc_2);
				il.Emit(OpCodes.Ldloca_S, (byte)2);
			}
			else if (nextLocalVarIndex == 3)
			{
				il.Emit(OpCodes.Stloc_3);
				il.Emit(OpCodes.Ldloca_S, (byte)3);
			}
			else if ((uint)nextLocalVarIndex <= 255u)
			{
				il.Emit(OpCodes.Stloc_S, (byte)nextLocalVarIndex);
				il.Emit(OpCodes.Ldloca_S, (byte)nextLocalVarIndex);
			}
			else
			{
				il.Emit(OpCodes.Stloc, (short)nextLocalVarIndex);
				il.Emit(OpCodes.Ldloca, (short)nextLocalVarIndex);
			}
			return nextLocalVarIndex;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void EmitLoadArg(ILGenerator il, int paramIndex)
		{
			if (paramIndex == 0)
			{
				il.Emit(OpCodes.Ldarg_0);
			}
			else if (paramIndex == 1)
			{
				il.Emit(OpCodes.Ldarg_1);
			}
			else if (paramIndex == 2)
			{
				il.Emit(OpCodes.Ldarg_2);
			}
			else if (paramIndex == 3)
			{
				il.Emit(OpCodes.Ldarg_3);
			}
			else if ((uint)paramIndex <= 255u)
			{
				il.Emit(OpCodes.Ldarg_S, (byte)paramIndex);
			}
			else
			{
				il.Emit(OpCodes.Ldarg, (short)paramIndex);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void EmitLoadArgAddress(ILGenerator il, int paramIndex)
		{
			if ((uint)paramIndex <= 255u)
			{
				il.Emit(OpCodes.Ldarga_S, (byte)paramIndex);
			}
			else
			{
				il.Emit(OpCodes.Ldarga, (short)paramIndex);
			}
		}
	}

	private static readonly Type[] _closureAsASingleParamType = new Type[1] { typeof(ArrayClosure) };

	private static readonly Type[][] _closureTypePlusParamTypesPool = new Type[8][];

	public static readonly ArrayClosure EmptyArrayClosure = new ArrayClosure(null);

	public static FieldInfo ArrayClosureArrayField = typeof(ArrayClosure).GetField("ConstantsAndNestedLambdas");

	public static FieldInfo ArrayClosureWithNonPassedParamsField = typeof(ArrayClosureWithNonPassedParams).GetField("NonPassedParams");

	private static ConstructorInfo[] _nonPassedParamsArrayClosureCtors = typeof(ArrayClosureWithNonPassedParams).GetConstructors();

	public static ConstructorInfo ArrayClosureWithNonPassedParamsConstructor = _nonPassedParamsArrayClosureCtors[0];

	public static ConstructorInfo ArrayClosureWithNonPassedParamsConstructorWithoutConstants = _nonPassedParamsArrayClosureCtors[1];

	public static TDelegate CompileFast<TDelegate>(this LambdaExpression lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default) where TDelegate : class
	{
		return (TDelegate)(TryCompileBoundToFirstClosureParam((typeof(TDelegate) == typeof(Delegate)) ? lambdaExpr.Type : typeof(TDelegate), lambdaExpr.Body, lambdaExpr, GetClosureTypeToParamTypes(lambdaExpr), lambdaExpr.ReturnType, flags) ?? (ifFastFailedReturnNull ? null : lambdaExpr.CompileSys()));
	}

	public static bool CompileFastToIL(this LambdaExpression lambdaExpr, ILGenerator il, CompilerFlags flags = CompilerFlags.Default)
	{
		if ((flags & CompilerFlags.EnableDelegateDebugInfo) != CompilerFlags.Default)
		{
			throw new NotSupportedException("The `CompilerFlags.EnableDelegateDebugInfo` is not supported because the debug info is gathered into the closure object which is not allowed for static lambda to be compiled to method.");
		}
		Expression body = lambdaExpr.Body;
		ClosureInfo closure = new ClosureInfo(ClosureStatus.ShouldBeStaticMethod);
		if (!TryCollectBoundConstants(ref closure, body, lambdaExpr, isNestedLambda: false, ref closure, flags))
		{
			return false;
		}
		if ((closure.Status & ClosureStatus.HasClosure) != 0)
		{
			return false;
		}
		ParentFlags parent = ((lambdaExpr.ReturnType == typeof(void)) ? ParentFlags.IgnoreResult : ParentFlags.Empty);
		if (!EmittingVisitor.TryEmit(body, lambdaExpr, il, ref closure, flags, parent))
		{
			return false;
		}
		il.Emit(OpCodes.Ret);
		return true;
	}

	public static Delegate CompileFast(this LambdaExpression lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Delegate)TryCompileBoundToFirstClosureParam(lambdaExpr.Type, lambdaExpr.Body, lambdaExpr, GetClosureTypeToParamTypes(lambdaExpr), lambdaExpr.ReturnType, flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Delegate)obj;
	}

	public static TDelegate CompileSys<TDelegate>(this Expression<TDelegate> lambdaExpr) where TDelegate : Delegate
	{
		return lambdaExpr.ToLambdaExpression().Compile();
	}

	public static Delegate CompileSys(this LambdaExpression lambdaExpr)
	{
		return lambdaExpr.ToLambdaExpression().Compile();
	}

	public static TDelegate CompileFast<TDelegate>(this Expression<TDelegate> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default) where TDelegate : Delegate
	{
		return ((LambdaExpression)lambdaExpr).CompileFast<TDelegate>(ifFastFailedReturnNull, flags);
	}

	public static Func<R> CompileFast<R>(this Expression<Func<R>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Func<R>)TryCompileBoundToFirstClosureParam(typeof(Func<R>), lambdaExpr.Body, lambdaExpr, _closureAsASingleParamType, typeof(R), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Func<R>)obj;
	}

	public static Func<T1, R> CompileFast<T1, R>(this Expression<Func<T1, R>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Func<T1, R>)TryCompileBoundToFirstClosureParam(typeof(Func<T1, R>), lambdaExpr.Body, lambdaExpr, new Type[2]
		{
			typeof(ArrayClosure),
			typeof(T1)
		}, typeof(R), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Func<T1, R>)obj;
	}

	public static Func<T1, T2, R> CompileFast<T1, T2, R>(this Expression<Func<T1, T2, R>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Func<T1, T2, R>)TryCompileBoundToFirstClosureParam(typeof(Func<T1, T2, R>), lambdaExpr.Body, lambdaExpr, new Type[3]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2)
		}, typeof(R), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Func<T1, T2, R>)obj;
	}

	public static Func<T1, T2, T3, R> CompileFast<T1, T2, T3, R>(this Expression<Func<T1, T2, T3, R>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Func<T1, T2, T3, R>)TryCompileBoundToFirstClosureParam(typeof(Func<T1, T2, T3, R>), lambdaExpr.Body, lambdaExpr, new Type[4]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2),
			typeof(T3)
		}, typeof(R), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Func<T1, T2, T3, R>)obj;
	}

	public static Func<T1, T2, T3, T4, R> CompileFast<T1, T2, T3, T4, R>(this Expression<Func<T1, T2, T3, T4, R>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Func<T1, T2, T3, T4, R>)TryCompileBoundToFirstClosureParam(typeof(Func<T1, T2, T3, T4, R>), lambdaExpr.Body, lambdaExpr, new Type[5]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2),
			typeof(T3),
			typeof(T4)
		}, typeof(R), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Func<T1, T2, T3, T4, R>)obj;
	}

	public static Func<T1, T2, T3, T4, T5, R> CompileFast<T1, T2, T3, T4, T5, R>(this Expression<Func<T1, T2, T3, T4, T5, R>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Func<T1, T2, T3, T4, T5, R>)TryCompileBoundToFirstClosureParam(typeof(Func<T1, T2, T3, T4, T5, R>), lambdaExpr.Body, lambdaExpr, new Type[6]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2),
			typeof(T3),
			typeof(T4),
			typeof(T5)
		}, typeof(R), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Func<T1, T2, T3, T4, T5, R>)obj;
	}

	public static Func<T1, T2, T3, T4, T5, T6, R> CompileFast<T1, T2, T3, T4, T5, T6, R>(this Expression<Func<T1, T2, T3, T4, T5, T6, R>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Func<T1, T2, T3, T4, T5, T6, R>)TryCompileBoundToFirstClosureParam(typeof(Func<T1, T2, T3, T4, T5, T6, R>), lambdaExpr.Body, lambdaExpr, new Type[7]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2),
			typeof(T3),
			typeof(T4),
			typeof(T5),
			typeof(T6)
		}, typeof(R), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Func<T1, T2, T3, T4, T5, T6, R>)obj;
	}

	public static Action CompileFast(this Expression<Action> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Action)TryCompileBoundToFirstClosureParam(typeof(Action), lambdaExpr.Body, lambdaExpr, _closureAsASingleParamType, typeof(void), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Action)obj;
	}

	public static Action<T1> CompileFast<T1>(this Expression<Action<T1>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Action<T1>)TryCompileBoundToFirstClosureParam(typeof(Action<T1>), lambdaExpr.Body, lambdaExpr, new Type[2]
		{
			typeof(ArrayClosure),
			typeof(T1)
		}, typeof(void), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Action<T1>)obj;
	}

	public static Action<T1, T2> CompileFast<T1, T2>(this Expression<Action<T1, T2>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Action<T1, T2>)TryCompileBoundToFirstClosureParam(typeof(Action<T1, T2>), lambdaExpr.Body, lambdaExpr, new Type[3]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2)
		}, typeof(void), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Action<T1, T2>)obj;
	}

	public static Action<T1, T2, T3> CompileFast<T1, T2, T3>(this Expression<Action<T1, T2, T3>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Action<T1, T2, T3>)TryCompileBoundToFirstClosureParam(typeof(Action<T1, T2, T3>), lambdaExpr.Body, lambdaExpr, new Type[4]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2),
			typeof(T3)
		}, typeof(void), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Action<T1, T2, T3>)obj;
	}

	public static Action<T1, T2, T3, T4> CompileFast<T1, T2, T3, T4>(this Expression<Action<T1, T2, T3, T4>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Action<T1, T2, T3, T4>)TryCompileBoundToFirstClosureParam(typeof(Action<T1, T2, T3, T4>), lambdaExpr.Body, lambdaExpr, new Type[5]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2),
			typeof(T3),
			typeof(T4)
		}, typeof(void), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Action<T1, T2, T3, T4>)obj;
	}

	public static Action<T1, T2, T3, T4, T5> CompileFast<T1, T2, T3, T4, T5>(this Expression<Action<T1, T2, T3, T4, T5>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Action<T1, T2, T3, T4, T5>)TryCompileBoundToFirstClosureParam(typeof(Action<T1, T2, T3, T4, T5>), lambdaExpr.Body, lambdaExpr, new Type[6]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2),
			typeof(T3),
			typeof(T4),
			typeof(T5)
		}, typeof(void), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Action<T1, T2, T3, T4, T5>)obj;
	}

	public static Action<T1, T2, T3, T4, T5, T6> CompileFast<T1, T2, T3, T4, T5, T6>(this Expression<Action<T1, T2, T3, T4, T5, T6>> lambdaExpr, bool ifFastFailedReturnNull = false, CompilerFlags flags = CompilerFlags.Default)
	{
		object obj = (Action<T1, T2, T3, T4, T5, T6>)TryCompileBoundToFirstClosureParam(typeof(Action<T1, T2, T3, T4, T5, T6>), lambdaExpr.Body, lambdaExpr, new Type[7]
		{
			typeof(ArrayClosure),
			typeof(T1),
			typeof(T2),
			typeof(T3),
			typeof(T4),
			typeof(T5),
			typeof(T6)
		}, typeof(void), flags);
		if (obj == null)
		{
			if (!ifFastFailedReturnNull)
			{
				return lambdaExpr.CompileSys();
			}
			obj = null;
		}
		return (Action<T1, T2, T3, T4, T5, T6>)obj;
	}

	public static TDelegate TryCompile<TDelegate>(this LambdaExpression lambdaExpr, CompilerFlags flags = CompilerFlags.Default) where TDelegate : class
	{
		return (TDelegate)TryCompileBoundToFirstClosureParam((typeof(TDelegate) == typeof(Delegate)) ? lambdaExpr.Type : typeof(TDelegate), lambdaExpr.Body, lambdaExpr, GetClosureTypeToParamTypes(lambdaExpr), lambdaExpr.ReturnType, flags);
	}

	public static TDelegate TryCompileWithPreCreatedClosure<TDelegate>(this LambdaExpression lambdaExpr, params ConstantExpression[] closureConstantsExprs) where TDelegate : class
	{
		return lambdaExpr.TryCompileWithPreCreatedClosure<TDelegate>(closureConstantsExprs, CompilerFlags.Default);
	}

	public static TDelegate TryCompileWithPreCreatedClosure<TDelegate>(this LambdaExpression lambdaExpr, ConstantExpression[] closureConstantsExprs, CompilerFlags flags) where TDelegate : class
	{
		object[] array = new object[closureConstantsExprs.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = closureConstantsExprs[i].Value;
		}
		ClosureInfo closureInfo = new ClosureInfo(ClosureStatus.UserProvided | ClosureStatus.HasClosure, array);
		return lambdaExpr.TryCompileWithPreCreatedClosure<TDelegate>(ref closureInfo, flags);
	}

	internal static TDelegate TryCompileWithPreCreatedClosure<TDelegate>(this LambdaExpression lambdaExpr, ref ClosureInfo closureInfo, CompilerFlags flags) where TDelegate : class
	{
		Type[] closureTypeToParamTypes = GetClosureTypeToParamTypes(lambdaExpr);
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, lambdaExpr.ReturnType, closureTypeToParamTypes, typeof(ExpressionCompiler), skipVisibility: true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		EmittingVisitor.EmitLoadConstantsAndNestedLambdasIntoVars(iLGenerator, closureInfo.NestedLambdaOrLambdas, ref closureInfo);
		ParentFlags parent = ((lambdaExpr.ReturnType == typeof(void)) ? ParentFlags.IgnoreResult : ParentFlags.Empty);
		if (!EmittingVisitor.TryEmit(lambdaExpr.Body, lambdaExpr, iLGenerator, ref closureInfo, flags, parent))
		{
			return null;
		}
		iLGenerator.Emit(OpCodes.Ret);
		Type delegateType = ((typeof(TDelegate) != typeof(Delegate)) ? typeof(TDelegate) : lambdaExpr.Type);
		TDelegate result = (TDelegate)(object)dynamicMethod.CreateDelegate(delegateType, new ArrayClosure(closureInfo.Constants.Items));
		ReturnClosureTypeToParamTypesToPool(closureTypeToParamTypes);
		return result;
	}

	public static TDelegate TryCompileWithoutClosure<TDelegate>(this LambdaExpression lambdaExpr, CompilerFlags flags = CompilerFlags.Default) where TDelegate : class
	{
		ClosureInfo closure = new ClosureInfo(ClosureStatus.UserProvided);
		Type[] closureTypeToParamTypes = GetClosureTypeToParamTypes(lambdaExpr);
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, lambdaExpr.ReturnType, closureTypeToParamTypes, typeof(ArrayClosure), skipVisibility: true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		if (!EmittingVisitor.TryEmit(lambdaExpr.Body, lambdaExpr, iLGenerator, ref closure, flags, (lambdaExpr.ReturnType == typeof(void)) ? ParentFlags.IgnoreResult : ParentFlags.Empty))
		{
			return null;
		}
		iLGenerator.Emit(OpCodes.Ret);
		Type delegateType = ((typeof(TDelegate) != typeof(Delegate)) ? typeof(TDelegate) : lambdaExpr.Type);
		TDelegate result = (TDelegate)(object)dynamicMethod.CreateDelegate(delegateType, EmptyArrayClosure);
		ReturnClosureTypeToParamTypesToPool(closureTypeToParamTypes);
		return result;
	}

	private static Delegate CompileNoArgsNew(ConstructorInfo ctor, Type delegateType, Type[] closurePlusParamTypes, Type returnType)
	{
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, returnType, closurePlusParamTypes, typeof(ArrayClosure), skipVisibility: true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator(16);
		iLGenerator.Emit(OpCodes.Newobj, ctor);
		if (returnType == typeof(void))
		{
			iLGenerator.Emit(OpCodes.Pop);
		}
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod.CreateDelegate(delegateType, EmptyArrayClosure);
	}

	internal static object TryCompileBoundToFirstClosureParam(Type delegateType, Expression bodyExpr, IParameterProvider paramExprs, Type[] closurePlusParamTypes, Type returnType, CompilerFlags flags)
	{
		if (bodyExpr is NoArgsNewClassIntrinsicExpression noArgsNewClassIntrinsicExpression)
		{
			return CompileNoArgsNew(noArgsNewClassIntrinsicExpression.Constructor, delegateType, closurePlusParamTypes, returnType);
		}
		ClosureInfo closure = new ClosureInfo(ClosureStatus.ToBeCollected);
		if (!TryCollectBoundConstants(ref closure, bodyExpr, paramExprs, isNestedLambda: false, ref closure, flags))
		{
			return null;
		}
		object nestedLambdaOrLambdas = closure.NestedLambdaOrLambdas;
		if (nestedLambdaOrLambdas != null)
		{
			if (nestedLambdaOrLambdas is NestedLambdaInfo[] array)
			{
				NestedLambdaInfo[] array2 = array;
				foreach (NestedLambdaInfo nestedLambdaInfo in array2)
				{
					if (nestedLambdaInfo.Lambda == null && !TryCompileNestedLambda(nestedLambdaInfo, flags))
					{
						return null;
					}
				}
			}
			else if (((NestedLambdaInfo)nestedLambdaOrLambdas).Lambda == null && !TryCompileNestedLambda((NestedLambdaInfo)nestedLambdaOrLambdas, flags))
			{
				return null;
			}
		}
		ArrayClosure arrayClosure;
		if ((flags & CompilerFlags.EnableDelegateDebugInfo) == 0)
		{
			arrayClosure = (((closure.Status & ClosureStatus.HasClosure) == 0) ? EmptyArrayClosure : new ArrayClosure(closure.GetArrayOfConstantsAndNestedLambdas()));
		}
		else
		{
			LambdaExpression expr = Expression.Lambda(delegateType, bodyExpr, paramExprs?.ToReadOnlyList() ?? Tools.Empty<ParameterExpression>());
			arrayClosure = (((closure.Status & ClosureStatus.HasClosure) == 0) ? new DebugArrayClosure(null, expr) : new DebugArrayClosure(closure.GetArrayOfConstantsAndNestedLambdas(), expr));
		}
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, returnType, closurePlusParamTypes, typeof(ArrayClosure), skipVisibility: true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator(64);
		if (arrayClosure.ConstantsAndNestedLambdas != null)
		{
			EmittingVisitor.EmitLoadConstantsAndNestedLambdasIntoVars(iLGenerator, nestedLambdaOrLambdas, ref closure);
		}
		ParentFlags parent = ((returnType == typeof(void)) ? ParentFlags.IgnoreResult : ParentFlags.Empty);
		if (!EmittingVisitor.TryEmit(bodyExpr, paramExprs, iLGenerator, ref closure, flags, parent))
		{
			return null;
		}
		iLGenerator.Emit(OpCodes.Ret);
		Delegate result = dynamicMethod.CreateDelegate(delegateType, arrayClosure);
		ReturnClosureTypeToParamTypesToPool(closurePlusParamTypes);
		return result;
	}

	private static Type[] GetClosureTypeToParamTypes(IParameterProvider paramExprs)
	{
		int parameterCount = paramExprs.ParameterCount;
		if (parameterCount == 0)
		{
			return _closureAsASingleParamType;
		}
		if (parameterCount < 8)
		{
			Type[] array = Interlocked.Exchange(ref _closureTypePlusParamTypesPool[parameterCount], null);
			if (array != null)
			{
				for (int i = 0; i < parameterCount; i++)
				{
					ParameterExpression parameter = paramExprs.GetParameter(i);
					array[i + 1] = (parameter.IsByRef ? parameter.Type.MakeByRefType() : parameter.Type);
				}
				return array;
			}
		}
		Type[] array2 = new Type[parameterCount + 1];
		array2[0] = typeof(ArrayClosure);
		for (int j = 0; j < parameterCount; j++)
		{
			ParameterExpression parameter2 = paramExprs.GetParameter(j);
			array2[j + 1] = (parameter2.IsByRef ? parameter2.Type.MakeByRefType() : parameter2.Type);
		}
		return array2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ReturnClosureTypeToParamTypesToPool(Type[] closurePlusParamTypes)
	{
		int num = closurePlusParamTypes.Length - 1;
		if (num != 0 && num < 8)
		{
			Interlocked.Exchange(ref _closureTypePlusParamTypesPool[num], closurePlusParamTypes);
		}
	}

	public static bool IsClosureBoundConstant(object value, Type type)
	{
		if (!(value is Delegate) && !type.IsArray)
		{
			if (!type.IsPrimitive && !type.IsEnum && !(value is string) && !(value is Type))
			{
				return !(value is decimal);
			}
			return false;
		}
		return true;
	}

	public static bool TryCollectBoundConstants(ref ClosureInfo closure, Expression expr, IParameterProvider paramExprs, bool isNestedLambda, ref ClosureInfo rootClosure, CompilerFlags flags)
	{
		while (true)
		{
			if (expr == null)
			{
				return false;
			}
			if (expr.IsIntrinsic)
			{
				break;
			}
			switch (expr.NodeType)
			{
			case ExpressionType.Constant:
			{
				if (expr is IntConstantExpression)
				{
					return true;
				}
				ConstantExpression constantExpression = (ConstantExpression)expr;
				object value = constantExpression.Value;
				if (value != null && IsClosureBoundConstant(value, value.GetType()))
				{
					closure.AddConstantOrIncrementUsageCount(value);
				}
				return true;
			}
			case ExpressionType.Parameter:
			{
				int parameterCount = paramExprs.ParameterCount;
				int num3 = parameterCount - 1;
				while (num3 != -1 && paramExprs.GetParameter(num3) != expr)
				{
					num3--;
				}
				if (num3 == -1 && !closure.IsLocalVar(expr))
				{
					if (!isNestedLambda)
					{
						return false;
					}
					closure.AddNonPassedParam((ParameterExpression)expr);
				}
				return true;
			}
			case ExpressionType.Call:
			{
				MethodCallExpression methodCallExpression = (MethodCallExpression)expr;
				Expression expression = methodCallExpression.Object;
				IArgumentProvider argumentProvider = methodCallExpression;
				int argumentCount = argumentProvider.ArgumentCount;
				if (argumentCount == 0)
				{
					if (expression != null)
					{
						expr = expression;
						continue;
					}
					return true;
				}
				if (expression != null && !TryCollectBoundConstants(ref closure, methodCallExpression.Object, paramExprs, isNestedLambda, ref rootClosure, flags))
				{
					return false;
				}
				int num = argumentCount - 1;
				for (int i = 0; i < num; i++)
				{
					if (!TryCollectBoundConstants(ref closure, argumentProvider.GetArgument(i), paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
				}
				expr = argumentProvider.GetArgument(num);
				continue;
			}
			case ExpressionType.MemberAccess:
			{
				Expression expression2 = ((MemberExpression)expr).Expression;
				if (expression2 == null)
				{
					return true;
				}
				expr = expression2;
				continue;
			}
			case ExpressionType.New:
			{
				NewExpression newExpression = (NewExpression)expr;
				IArgumentProvider argumentProvider2 = newExpression;
				int argumentCount2 = argumentProvider2.ArgumentCount;
				if (argumentCount2 == 0)
				{
					return true;
				}
				int num2 = argumentCount2 - 1;
				for (int j = 0; j < num2; j++)
				{
					if (!TryCollectBoundConstants(ref closure, argumentProvider2.GetArgument(j), paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
				}
				expr = argumentProvider2.GetArgument(num2);
				continue;
			}
			case ExpressionType.NewArrayInit:
			case ExpressionType.NewArrayBounds:
			{
				if (expr.NodeType == ExpressionType.NewArrayInit && expr.Type.GetArrayRank() > 1)
				{
					if ((flags & CompilerFlags.ThrowOnNotSupportedExpression) != CompilerFlags.Default)
					{
						throw new NotSupportedExpressionException(NotSupported.NewArrayInit_MultidimensionalArray);
					}
					return false;
				}
				IArgumentProvider argumentProvider3 = (IArgumentProvider)expr;
				int argumentCount3 = argumentProvider3.ArgumentCount;
				if (argumentCount3 == 0)
				{
					return true;
				}
				for (int k = 0; k < argumentCount3 - 1; k++)
				{
					if (!TryCollectBoundConstants(ref closure, argumentProvider3.GetArgument(k), paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
				}
				expr = argumentProvider3.GetArgument(argumentCount3 - 1);
				continue;
			}
			case ExpressionType.MemberInit:
				return TryCollectMemberInitExprConstants(ref closure, (MemberInitExpression)expr, paramExprs, isNestedLambda, ref rootClosure, flags);
			case ExpressionType.ListInit:
				return TryCollectListInitExprConstants(ref closure, (ListInitExpression)expr, paramExprs, isNestedLambda, ref rootClosure, flags);
			case ExpressionType.Lambda:
			{
				LambdaExpression lambdaExpression = (LambdaExpression)expr;
				object nestedLambdaOrLambdas = rootClosure.NestedLambdaOrLambdas;
				if (nestedLambdaOrLambdas != null)
				{
					object foundInLambdaOrLambdas;
					NestedLambdaInfo nestedLambdaInfo = FindAlreadyCollectedNestedLambdaInfo(nestedLambdaOrLambdas, lambdaExpression, out foundInLambdaOrLambdas);
					if (nestedLambdaInfo != null)
					{
						if (foundInLambdaOrLambdas != closure.NestedLambdaOrLambdas)
						{
							closure.AddNestedLambda(nestedLambdaInfo);
							ParameterExpression[] nonPassedParameters = nestedLambdaInfo.ClosureInfo.NonPassedParameters;
							if (nonPassedParameters.Length != 0)
							{
								PropagateNonPassedParamsToOuterLambda(ref closure, paramExprs, lambdaExpression, nonPassedParameters);
							}
						}
						return true;
					}
				}
				NestedLambdaInfo nestedLambdaInfo2 = new NestedLambdaInfo(lambdaExpression);
				if (!TryCollectBoundConstants(ref nestedLambdaInfo2.ClosureInfo, lambdaExpression.Body, lambdaExpression, isNestedLambda: true, ref rootClosure, flags))
				{
					return false;
				}
				closure.AddNestedLambda(nestedLambdaInfo2);
				ParameterExpression[] nonPassedParameters2 = nestedLambdaInfo2.ClosureInfo.NonPassedParameters;
				if (nonPassedParameters2.Length != 0)
				{
					PropagateNonPassedParamsToOuterLambda(ref closure, paramExprs, lambdaExpression, nonPassedParameters2);
				}
				return true;
			}
			case ExpressionType.Invoke:
			{
				InvocationExpression invocationExpression = (InvocationExpression)expr;
				IArgumentProvider argumentProvider5 = invocationExpression;
				int argumentCount5 = argumentProvider5.ArgumentCount;
				Expression expression3 = invocationExpression.Expression;
				if ((flags & CompilerFlags.NoInvocationLambdaInlining) == 0 && expression3 is LambdaExpression lambdaExpression2)
				{
					short currentInlinedLambdaInvokeIndex = closure.CurrentInlinedLambdaInvokeIndex;
					closure.CurrentInlinedLambdaInvokeIndex = closure.AddInlinedLambdaInvoke(invocationExpression);
					if (argumentCount5 == 0 && !TryCollectBoundConstants(ref closure, lambdaExpression2.Body, paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
					IParameterProvider parameterProvider = lambdaExpression2;
					int parameterCount2 = paramExprs.ParameterCount;
					Expression[] array = new Expression[argumentCount5 + 1];
					List<ParameterExpression> list = null;
					for (int num4 = 0; num4 < argumentCount5; num4++)
					{
						ParameterExpression parameter = parameterProvider.GetParameter(num4);
						int num5 = parameterCount2 - 1;
						while (num5 != -1 && parameter != paramExprs.GetParameter(num5))
						{
							num5--;
						}
						if (num5 != -1 || closure.IsLocalVar(parameter))
						{
							if (list == null)
							{
								list = new List<ParameterExpression>();
								for (int num6 = 0; num6 < num4; num6++)
								{
									list.Add(parameterProvider.GetParameter(num6));
								}
							}
						}
						else
						{
							list?.Add(parameter);
						}
						array[num4] = Expression.Assign(parameter, argumentProvider5.GetArgument(num4));
					}
					array[argumentCount5] = lambdaExpression2.Body;
					IReadOnlyList<ParameterExpression> readOnlyList = list;
					expr = Expression.Block(readOnlyList ?? parameterProvider.ToReadOnlyList(), array);
					if (!TryCollectBoundConstants(ref closure, expr, paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
					closure.CurrentInlinedLambdaInvokeIndex = currentInlinedLambdaInvokeIndex;
					return true;
				}
				if (argumentCount5 == 0)
				{
					expr = expression3;
					continue;
				}
				if (!TryCollectBoundConstants(ref closure, expression3, paramExprs, isNestedLambda, ref rootClosure, flags))
				{
					return false;
				}
				int num7 = argumentCount5 - 1;
				for (int num8 = 0; num8 < num7; num8++)
				{
					if (!TryCollectBoundConstants(ref closure, argumentProvider5.GetArgument(num8), paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
				}
				expr = argumentProvider5.GetArgument(num7);
				continue;
			}
			case ExpressionType.Conditional:
			{
				ConditionalExpression conditionalExpression = (ConditionalExpression)expr;
				if (!TryCollectBoundConstants(ref closure, conditionalExpression.Test, paramExprs, isNestedLambda, ref rootClosure, flags) || !TryCollectBoundConstants(ref closure, conditionalExpression.IfFalse, paramExprs, isNestedLambda, ref rootClosure, flags))
				{
					return false;
				}
				expr = conditionalExpression.IfTrue;
				continue;
			}
			case ExpressionType.Block:
			{
				BlockExpression blockExpression = (BlockExpression)expr;
				IReadOnlyList<Expression> expressions = blockExpression.Expressions;
				int count = expressions.Count;
				if (count == 0)
				{
					return true;
				}
				IReadOnlyList<ParameterExpression> variables = blockExpression.Variables;
				int count2 = variables.Count;
				switch (count2)
				{
				case 1:
					closure.PushBlockWithVars(variables[0]);
					break;
				default:
					closure.PushBlockWithVars(variables);
					break;
				case 0:
					break;
				}
				for (int n = 0; n < count - 1; n++)
				{
					if (!TryCollectBoundConstants(ref closure, expressions[n], paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
				}
				expr = expressions[count - 1];
				if (count2 != 0)
				{
					if (!TryCollectBoundConstants(ref closure, expr, paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
					closure.PopBlock();
					return true;
				}
				continue;
			}
			case ExpressionType.Loop:
			{
				LoopExpression loopExpression = (LoopExpression)expr;
				closure.AddLabel(loopExpression.BreakLabel, -1);
				closure.AddLabel(loopExpression.ContinueLabel, -1);
				expr = loopExpression.Body;
				continue;
			}
			case ExpressionType.Index:
			{
				IndexExpression indexExpression = (IndexExpression)expr;
				IArgumentProvider argumentProvider4 = indexExpression;
				int argumentCount4 = argumentProvider4.ArgumentCount;
				for (int l = 0; l < argumentCount4; l++)
				{
					if (!TryCollectBoundConstants(ref closure, argumentProvider4.GetArgument(l), paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
				}
				if (indexExpression.Object == null)
				{
					return true;
				}
				expr = indexExpression.Object;
				continue;
			}
			case ExpressionType.Try:
				return TryCollectTryExprConstants(ref closure, (TryExpression)expr, paramExprs, isNestedLambda, ref rootClosure, flags);
			case ExpressionType.Label:
			{
				LabelExpression labelExpression = (LabelExpression)expr;
				closure.AddLabel(labelExpression.Target, closure.CurrentInlinedLambdaInvokeIndex);
				if (labelExpression.DefaultValue == null)
				{
					return true;
				}
				expr = labelExpression.DefaultValue;
				continue;
			}
			case ExpressionType.Goto:
			{
				GotoExpression gotoExpression = (GotoExpression)expr;
				if (gotoExpression.Value == null)
				{
					return true;
				}
				expr = gotoExpression.Value;
				continue;
			}
			case ExpressionType.Switch:
			{
				SwitchExpression switchExpression = (SwitchExpression)expr;
				if (!TryCollectBoundConstants(ref closure, switchExpression.SwitchValue, paramExprs, isNestedLambda, ref rootClosure, flags) || (switchExpression.DefaultBody != null && !TryCollectBoundConstants(ref closure, switchExpression.DefaultBody, paramExprs, isNestedLambda, ref rootClosure, flags)))
				{
					return false;
				}
				IReadOnlyList<SwitchCase> cases = switchExpression.Cases;
				for (int m = 0; m < cases.Count - 1; m++)
				{
					if (!TryCollectBoundConstants(ref closure, cases[m].Body, paramExprs, isNestedLambda, ref rootClosure, flags))
					{
						return false;
					}
				}
				expr = cases[cases.Count - 1].Body;
				continue;
			}
			case ExpressionType.Extension:
				expr = expr.Reduce();
				continue;
			case ExpressionType.Default:
				return true;
			case ExpressionType.TypeIs:
			case ExpressionType.TypeEqual:
				expr = ((TypeBinaryExpression)expr).Expression;
				continue;
			case ExpressionType.Quote:
				if ((flags & CompilerFlags.ThrowOnNotSupportedExpression) != CompilerFlags.Default)
				{
					throw new NotSupportedExpressionException(NotSupported.Quote);
				}
				return false;
			case ExpressionType.Dynamic:
				if ((flags & CompilerFlags.ThrowOnNotSupportedExpression) != CompilerFlags.Default)
				{
					throw new NotSupportedExpressionException(NotSupported.Dynamic);
				}
				return false;
			case ExpressionType.RuntimeVariables:
				if ((flags & CompilerFlags.ThrowOnNotSupportedExpression) != CompilerFlags.Default)
				{
					throw new NotSupportedExpressionException(NotSupported.RuntimeVariables);
				}
				return false;
			case ExpressionType.DebugInfo:
				return true;
			}
			if (expr is UnaryExpression unaryExpression)
			{
				expr = unaryExpression.Operand;
				continue;
			}
			if (expr is BinaryExpression binaryExpression)
			{
				if (!TryCollectBoundConstants(ref closure, binaryExpression.Left, paramExprs, isNestedLambda, ref rootClosure, flags))
				{
					return false;
				}
				expr = binaryExpression.Right;
				continue;
			}
			return false;
		}
		return expr.TryCollectBoundConstants(flags, ref closure, paramExprs, isNestedLambda, ref rootClosure);
	}

	private static void PropagateNonPassedParamsToOuterLambda(ref ClosureInfo closure, IParameterProvider paramExprs, IParameterProvider nestedLambdaParamExprs, ParameterExpression[] nestedNonPassedParams)
	{
		int parameterCount = paramExprs.ParameterCount;
		int parameterCount2 = nestedLambdaParamExprs.ParameterCount;
		foreach (ParameterExpression parameterExpression in nestedNonPassedParams)
		{
			bool flag = false;
			if (parameterCount2 != 0)
			{
				int num = 0;
				while (!flag && num < parameterCount2)
				{
					flag = nestedLambdaParamExprs.GetParameter(num) == parameterExpression;
					num++;
				}
			}
			bool flag2 = false;
			if (parameterCount != 0)
			{
				int num2 = 0;
				while (!flag2 && num2 < parameterCount)
				{
					flag2 = paramExprs.GetParameter(num2) == parameterExpression;
					num2++;
				}
			}
			if (!flag && !flag2)
			{
				closure.AddNonPassedParam(parameterExpression);
			}
		}
	}

	private static NestedLambdaInfo FindAlreadyCollectedNestedLambdaInfo(NestedLambdaInfo nestedLambda, LambdaExpression nestedLambdaExpr, out object foundInLambdaOrLambdas)
	{
		if (nestedLambda.LambdaExpression == nestedLambdaExpr)
		{
			foundInLambdaOrLambdas = nestedLambda;
			return nestedLambda;
		}
		object nestedLambdaOrLambdas = nestedLambda.ClosureInfo.NestedLambdaOrLambdas;
		if (nestedLambdaOrLambdas != null)
		{
			NestedLambdaInfo nestedLambdaInfo = FindAlreadyCollectedNestedLambdaInfo(nestedLambdaOrLambdas, nestedLambdaExpr, out foundInLambdaOrLambdas);
			if (nestedLambdaInfo != null)
			{
				return nestedLambdaInfo;
			}
		}
		foundInLambdaOrLambdas = null;
		return null;
	}

	private static NestedLambdaInfo FindAlreadyCollectedNestedLambdaInfo(object nestedLambdaOrLambdas, LambdaExpression nestedLambdaExpr, out object foundInLambdaOrLambdas)
	{
		if (nestedLambdaOrLambdas is NestedLambdaInfo nestedLambda)
		{
			return FindAlreadyCollectedNestedLambdaInfo(nestedLambda, nestedLambdaExpr, out foundInLambdaOrLambdas);
		}
		NestedLambdaInfo[] array = (NestedLambdaInfo[])nestedLambdaOrLambdas;
		for (int i = 0; i < array.Length; i++)
		{
			NestedLambdaInfo nestedLambdaInfo = FindAlreadyCollectedNestedLambdaInfo(array[i], nestedLambdaExpr, out foundInLambdaOrLambdas);
			if (nestedLambdaInfo != null)
			{
				return nestedLambdaInfo;
			}
		}
		foundInLambdaOrLambdas = null;
		return null;
	}

	private static bool TryCompileNestedLambda(NestedLambdaInfo nestedLambdaInfo, CompilerFlags setup)
	{
		LambdaExpression lambdaExpression = nestedLambdaInfo.LambdaExpression;
		Type returnType = lambdaExpression.ReturnType;
		Expression body = lambdaExpression.Body;
		IParameterProvider paramExprs = lambdaExpression;
		if (body is NoArgsNewClassIntrinsicExpression noArgsNewClassIntrinsicExpression)
		{
			Type[] closureTypeToParamTypes = GetClosureTypeToParamTypes(paramExprs);
			nestedLambdaInfo.Lambda = CompileNoArgsNew(noArgsNewClassIntrinsicExpression.Constructor, lambdaExpression.Type, closureTypeToParamTypes, returnType);
			ReturnClosureTypeToParamTypesToPool(closureTypeToParamTypes);
			return true;
		}
		ref ClosureInfo closureInfo = ref nestedLambdaInfo.ClosureInfo;
		object nestedLambdaOrLambdas = closureInfo.NestedLambdaOrLambdas;
		if (nestedLambdaOrLambdas != null)
		{
			if (nestedLambdaOrLambdas is NestedLambdaInfo[] array)
			{
				NestedLambdaInfo[] array2 = array;
				foreach (NestedLambdaInfo nestedLambdaInfo2 in array2)
				{
					if (nestedLambdaInfo.Lambda == null && !TryCompileNestedLambda(nestedLambdaInfo2, setup))
					{
						return false;
					}
				}
			}
			else if (((NestedLambdaInfo)nestedLambdaOrLambdas).Lambda == null && !TryCompileNestedLambda((NestedLambdaInfo)nestedLambdaOrLambdas, setup))
			{
				return false;
			}
		}
		ArrayClosure arrayClosure = null;
		if (closureInfo.NonPassedParameters.Length == 0)
		{
			arrayClosure = (((closureInfo.Status & ClosureStatus.HasClosure) == 0) ? EmptyArrayClosure : new ArrayClosure(closureInfo.GetArrayOfConstantsAndNestedLambdas()));
		}
		Type[] closureTypeToParamTypes2 = GetClosureTypeToParamTypes(paramExprs);
		DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, returnType, closureTypeToParamTypes2, typeof(ArrayClosure), skipVisibility: true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		if ((closureInfo.Status & ClosureStatus.HasClosure) != 0 && closureInfo.ContainsConstantsOrNestedLambdas())
		{
			EmittingVisitor.EmitLoadConstantsAndNestedLambdasIntoVars(iLGenerator, nestedLambdaOrLambdas, ref closureInfo);
		}
		ParentFlags parent = ((returnType == typeof(void)) ? ParentFlags.IgnoreResult : ParentFlags.Empty);
		if (!EmittingVisitor.TryEmit(body, paramExprs, iLGenerator, ref closureInfo, setup, parent))
		{
			return false;
		}
		iLGenerator.Emit(OpCodes.Ret);
		if (arrayClosure != null)
		{
			nestedLambdaInfo.Lambda = dynamicMethod.CreateDelegate(lambdaExpression.Type, arrayClosure);
		}
		else
		{
			nestedLambdaInfo.Lambda = dynamicMethod.CreateDelegate(Tools.GetFuncOrActionType(closureTypeToParamTypes2, returnType), null);
		}
		ReturnClosureTypeToParamTypesToPool(closureTypeToParamTypes2);
		return true;
	}

	private static bool TryCollectMemberInitExprConstants(ref ClosureInfo closure, MemberInitExpression expr, IParameterProvider paramExprs, bool isNestedLambda, ref ClosureInfo rootClosure, CompilerFlags flags)
	{
		Expression expression = expr.Expression;
		int argumentCount = ((IArgumentProvider<MemberBinding>)expr).ArgumentCount;
		if (!TryCollectBoundConstants(ref closure, expression, paramExprs, isNestedLambda, ref rootClosure, flags))
		{
			return false;
		}
		for (int i = 0; i < argumentCount; i++)
		{
			MemberBinding argument = ((IArgumentProvider<MemberBinding>)expr).GetArgument(i);
			if (argument.BindingType != MemberBindingType.Assignment)
			{
				if ((flags & CompilerFlags.ThrowOnNotSupportedExpression) != CompilerFlags.Default)
				{
					throw new NotSupportedExpressionException((argument.BindingType == MemberBindingType.MemberBinding) ? NotSupported.MemberInit_MemberBinding : NotSupported.MemberInit_ListBinding);
				}
				return false;
			}
			if (!TryCollectBoundConstants(ref closure, ((MemberAssignment)argument).Expression, paramExprs, isNestedLambda, ref rootClosure, flags))
			{
				return false;
			}
		}
		return true;
	}

	private static bool TryCollectListInitExprConstants(ref ClosureInfo closure, ListInitExpression expr, IParameterProvider paramExprs, bool isNestedLambda, ref ClosureInfo rootClosure, CompilerFlags flags)
	{
		NewExpression newExpression = expr.NewExpression;
		IReadOnlyList<ElementInit> initializers = expr.Initializers;
		int count = initializers.Count;
		if (!TryCollectBoundConstants(ref closure, newExpression, paramExprs, isNestedLambda, ref rootClosure, flags))
		{
			return false;
		}
		for (int i = 0; i < count; i++)
		{
			ElementInit argument = initializers.GetArgument(i);
			IReadOnlyList<Expression> arguments = argument.Arguments;
			int count2 = arguments.Count;
			for (int j = 0; j < count2; j++)
			{
				if (!TryCollectBoundConstants(ref closure, arguments.GetArgument(j), paramExprs, isNestedLambda, ref rootClosure, flags))
				{
					return false;
				}
			}
		}
		return true;
	}

	private static bool TryCollectTryExprConstants(ref ClosureInfo closure, TryExpression tryExpr, IParameterProvider paramExprs, bool isNestedLambda, ref ClosureInfo rootClosure, CompilerFlags flags)
	{
		if (!TryCollectBoundConstants(ref closure, tryExpr.Body, paramExprs, isNestedLambda, ref rootClosure, flags))
		{
			return false;
		}
		IReadOnlyList<CatchBlock> handlers = tryExpr.Handlers;
		for (int i = 0; i < handlers.Count; i++)
		{
			CatchBlock catchBlock = handlers[i];
			ParameterExpression variable = catchBlock.Variable;
			if (variable != null)
			{
				closure.PushBlockWithVars(variable);
				if (!TryCollectBoundConstants(ref closure, variable, paramExprs, isNestedLambda, ref rootClosure, flags))
				{
					return false;
				}
			}
			if (catchBlock.Filter != null && !TryCollectBoundConstants(ref closure, catchBlock.Filter, paramExprs, isNestedLambda, ref rootClosure, flags))
			{
				return false;
			}
			if (!TryCollectBoundConstants(ref closure, catchBlock.Body, paramExprs, isNestedLambda, ref rootClosure, flags))
			{
				return false;
			}
			if (variable != null)
			{
				closure.PopBlock();
			}
		}
		if (tryExpr.Finally != null && !TryCollectBoundConstants(ref closure, tryExpr.Finally, paramExprs, isNestedLambda, ref rootClosure, flags))
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IgnoresResult(this ParentFlags parent)
	{
		return (parent & ParentFlags.IgnoreResult) != 0;
	}

	internal static bool EmitPopIfIgnoreResult(this ILGenerator il, ParentFlags parent)
	{
		if ((parent & ParentFlags.IgnoreResult) != ParentFlags.Empty)
		{
			il.Emit(OpCodes.Pop);
		}
		return true;
	}
}
