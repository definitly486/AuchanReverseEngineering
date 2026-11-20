using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public static class ToExpressionPrinter
{
	private const string NotSupportedExpression = "// NOT_SUPPORTED_EXPRESSION: ";

	public static string ToExpressionString(this Expression expr, TryPrintConstant tryPrintConstant = null)
	{
		List<ParameterExpression> paramsExprs;
		List<Expression> uniqueExprs;
		List<LabelTarget> lts;
		return expr.ToExpressionString(out paramsExprs, out uniqueExprs, out lts, stripNamespace: false, null, 2, tryPrintConstant);
	}

	public static string ToExpressionString(this Expression expr, out List<ParameterExpression> paramsExprs, out List<Expression> uniqueExprs, out List<LabelTarget> lts, bool stripNamespace = false, Func<Type, string, string> printType = null, int identSpaces = 2, TryPrintConstant tryPrintConstant = null)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		stringBuilder.Append("var expr = ");
		paramsExprs = new List<ParameterExpression>();
		uniqueExprs = new List<Expression>();
		lts = new List<LabelTarget>();
		stringBuilder = expr.CreateExpressionString(stringBuilder, paramsExprs, uniqueExprs, lts, 2, stripNamespace, printType, identSpaces, tryPrintConstant).Append(';');
		if (lts.Count > 0)
		{
			stringBuilder.Insert(0, $"var l = new LabelTarget[{lts.Count}]; // the labels{"\n"}");
		}
		if (uniqueExprs.Count > 0)
		{
			stringBuilder.Insert(0, $"var e = new Expression[{uniqueExprs.Count}]; // the unique expressions{"\n"}");
		}
		if (paramsExprs.Count > 0)
		{
			stringBuilder.Insert(0, $"var p = new ParameterExpression[{paramsExprs.Count}]; // the parameter expressions{"\n"}");
		}
		return stringBuilder.ToString();
	}

	internal static StringBuilder ToExpressionString(this Expression expr, StringBuilder sb, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		if (expr is ParameterExpression pe)
		{
			return pe.ToExpressionString(sb, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		}
		int num = uniqueExprs.Count - 1;
		while (num != -1 && uniqueExprs[num] != expr)
		{
			num--;
		}
		if (num != -1)
		{
			return sb.Append("e[").Append(num).Append(" // ")
				.Append(expr.NodeType.ToString())
				.Append(" of ")
				.Append(expr.Type.ToCode(stripNamespace, printType))
				.NewLineIdent(lineIdent)
				.Append("]");
		}
		uniqueExprs.Add(expr);
		sb.Append("e[").Append(uniqueExprs.Count - 1).Append("]=");
		return expr.CreateExpressionString(sb, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
	}

	internal static StringBuilder ToExpressionString(this ParameterExpression pe, StringBuilder sb, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		int num = paramsExprs.Count - 1;
		while (num != -1 && paramsExprs[num] != pe)
		{
			num--;
		}
		if (num != -1)
		{
			return sb.Append("p[").Append(num).Append(" // (")
				.Append((!pe.Type.IsPrimitive && pe.Type.IsValueType) ? "[struct] " : string.Empty)
				.Append(pe.Type.ToCode(stripNamespace, printType))
				.Append(' ')
				.AppendName(pe.Name, pe.Type, pe)
				.Append(')')
				.NewLineIdent(lineIdent)
				.Append(']');
		}
		paramsExprs.Add(pe);
		sb.Append("p[").Append(paramsExprs.Count - 1).Append("]=");
		return pe.CreateExpressionString(sb, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
	}

	internal static StringBuilder ToExpressionString(this LabelTarget lt, StringBuilder sb, List<LabelTarget> labelTargets, int lineIdent, bool stripNamespace, Func<Type, string, string> printType)
	{
		int num = labelTargets.Count - 1;
		while (num != -1 && labelTargets[num] != lt)
		{
			num--;
		}
		if (num != -1)
		{
			return sb.Append("l[").Append(num).Append(" // (")
				.AppendName(lt.Name, lt.Type, lt)
				.Append(')')
				.NewLineIdent(lineIdent)
				.Append(']');
		}
		labelTargets.Add(lt);
		sb.Append("l[").Append(labelTargets.Count - 1).Append("]=Label(");
		sb.AppendTypeof(lt.Type, stripNamespace, printType);
		return ((lt.Name != null) ? sb.Append(", \"").Append(lt.Name).Append("\"") : sb).Append(")");
	}

	private static StringBuilder ToExpressionString(this IReadOnlyList<CatchBlock> bs, StringBuilder sb, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		if (bs.Count == 0)
		{
			return sb.Append("new CatchBlock[0]");
		}
		for (int i = 0; i < bs.Count; i++)
		{
			bs[i].ToExpressionString(((i > 0) ? sb.Append(',') : sb).NewLineIdent(lineIdent), paramsExprs, uniqueExprs, lts, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
		}
		return sb;
	}

	private static StringBuilder ToExpressionString(this CatchBlock b, StringBuilder sb, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		sb.Append("MakeCatchBlock(");
		sb.NewLineIdent(lineIdent).AppendTypeof(b.Test, stripNamespace, printType).Append(',');
		sb.NewLineIdentExpr(b.Variable, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
		sb.NewLineIdentExpr(b.Body, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
		sb.NewLineIdentExpr(b.Filter, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		return sb.Append(')');
	}

	private static StringBuilder ToExpressionString(this IReadOnlyList<SwitchCase> items, StringBuilder sb, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		if (items.Count == 0)
		{
			return sb.Append("new SwitchCase[0]");
		}
		for (int i = 0; i < items.Count; i++)
		{
			items[i].ToExpressionString(((i > 0) ? sb.Append(',') : sb).NewLineIdent(lineIdent), paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		}
		return sb;
	}

	private static StringBuilder ToExpressionString(this SwitchCase s, StringBuilder sb, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		sb.Append("SwitchCase(");
		sb.NewLineIdentExpr(s.Body, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
		sb.NewLineIdentArgumentExprs(s.TestValues, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		return sb.Append(')');
	}

	private static StringBuilder ToExpressionString(this MemberBinding mb, StringBuilder sb, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		if (mb is MemberAssignment memberAssignment)
		{
			sb.Append("Bind(");
			sb.NewLineIdent(lineIdent).AppendMember(mb.Member, stripNamespace, printType).Append(", ");
			sb.NewLineIdentExpr(memberAssignment.Expression, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			return sb.Append(")");
		}
		if (mb is MemberMemberBinding memberMemberBinding)
		{
			sb.NewLineIdent(lineIdent).Append("// NOT_SUPPORTED_EXPRESSION: ").Append("MemberMemberBinding")
				.NewLineIdent(lineIdent);
			sb.Append("MemberBind(");
			sb.NewLineIdent(lineIdent).AppendMember(mb.Member, stripNamespace, printType);
			for (int i = 0; i < memberMemberBinding.Bindings.Count; i++)
			{
				memberMemberBinding.Bindings[i].ToExpressionString(sb.Append(", ").NewLineIdent(lineIdent), paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(")");
		}
		if (mb is MemberListBinding memberListBinding)
		{
			sb.NewLineIdent(lineIdent).Append("// NOT_SUPPORTED_EXPRESSION: ").Append("MemberListBinding")
				.NewLineIdent(lineIdent);
			sb.Append("ListBind(");
			sb.NewLineIdent(lineIdent).AppendMember(mb.Member, stripNamespace, printType);
			for (int j = 0; j < memberListBinding.Initializers.Count; j++)
			{
				memberListBinding.Initializers[j].ToExpressionString(sb.Append(", ").NewLineIdent(lineIdent), paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(")");
		}
		return sb;
	}

	private static StringBuilder ToExpressionString(this ElementInit ei, StringBuilder sb, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent, bool stripNamespace, Func<Type, string, string> printType, int identSpaces, TryPrintConstant tryPrintConstant)
	{
		sb.Append("ElementInit(");
		sb.NewLineIdent(lineIdent).AppendMethod(ei.AddMethod, stripNamespace, printType).Append(", ");
		sb.NewLineIdentArgumentExprs(ei.Arguments, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		return sb.Append(")");
	}

	internal static StringBuilder CreateExpressionString(this Expression e, StringBuilder sb, List<ParameterExpression> paramsExprs, List<Expression> uniqueExprs, List<LabelTarget> lts, int lineIdent = 0, bool stripNamespace = false, Func<Type, string, string> printType = null, int identSpaces = 2, TryPrintConstant tryPrintConstant = null)
	{
		switch (e.NodeType)
		{
		case ExpressionType.Constant:
		{
			ConstantExpression constantExpression = (ConstantExpression)e;
			sb.Append("Constant(");
			if (tryPrintConstant != null)
			{
				string text = tryPrintConstant(constantExpression);
				if (text != null)
				{
					return sb.Append(text).Append(')');
				}
			}
			if (constantExpression.Value == null)
			{
				sb.Append("null");
				if (constantExpression.Type != typeof(object))
				{
					sb.Append(", ").AppendTypeof(constantExpression.Type, stripNamespace, printType);
				}
			}
			else if (constantExpression.Value is Type type)
			{
				sb.AppendTypeof(type, stripNamespace, printType);
			}
			else
			{
				sb.Append(constantExpression.Value.ToCode(CodePrinter.DefaultConstantValueToCode, stripNamespace, printType));
				if (constantExpression.Value.GetType() != constantExpression.Type)
				{
					sb.Append(", ").AppendTypeof(constantExpression.Type, stripNamespace, printType);
				}
			}
			return sb.Append(')');
		}
		case ExpressionType.Parameter:
		{
			ParameterExpression parameterExpression = (ParameterExpression)e;
			sb.Append("Parameter(").AppendTypeof(parameterExpression.Type, stripNamespace, printType);
			if (parameterExpression.IsByRef)
			{
				sb.Append(".MakeByRefType()");
			}
			if (parameterExpression.Name != null)
			{
				sb.Append(", \"").Append(parameterExpression.Name).Append('"');
			}
			return sb.Append(')');
		}
		case ExpressionType.New:
		{
			NewExpression newExpression = (NewExpression)e;
			IReadOnlyList<Expression> arguments = newExpression.Arguments;
			if (arguments.Count == 0 && e.Type.IsValueType)
			{
				return sb.Append("New(").AppendTypeof(e.Type, stripNamespace, printType).Append(')');
			}
			sb.Append("New( // ").Append(arguments.Count).Append(" args");
			int firstIndexByReferenceEquals = newExpression.Constructor.DeclaringType.GetTypeInfo().DeclaredConstructors.ToArray().GetFirstIndexByReferenceEquals(newExpression.Constructor);
			sb.NewLineIdent(lineIdent).AppendTypeof(newExpression.Type, stripNamespace, printType).Append(".GetTypeInfo().DeclaredConstructors.ToArray()[")
				.Append(firstIndexByReferenceEquals)
				.Append("],");
			sb.NewLineIdentArgumentExprs(arguments, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			return sb.Append(')');
		}
		case ExpressionType.Call:
		{
			MethodCallExpression methodCallExpression = (MethodCallExpression)e;
			sb.Append("Call(");
			sb.NewLineIdentExpr(methodCallExpression.Object, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(", ");
			sb.NewLineIdent(lineIdent).AppendMethod(methodCallExpression.Method, stripNamespace, printType);
			if (methodCallExpression.Arguments.Count > 0)
			{
				sb.Append(',').NewLineIdentArgumentExprs(methodCallExpression.Arguments, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(')');
		}
		case ExpressionType.MemberAccess:
		{
			MemberExpression memberExpression = (MemberExpression)e;
			if (memberExpression.Member is PropertyInfo property)
			{
				sb.Append("Property(");
				sb.NewLineIdentExpr(memberExpression.Expression, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
				sb.NewLineIdent(lineIdent).AppendProperty(property, stripNamespace, printType);
			}
			else
			{
				sb.Append("Field(");
				sb.NewLineIdentExpr(memberExpression.Expression, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
				sb.NewLineIdent(lineIdent).AppendField((FieldInfo)memberExpression.Member, stripNamespace, printType);
			}
			return sb.Append(')');
		}
		case ExpressionType.NewArrayInit:
		case ExpressionType.NewArrayBounds:
		{
			NewArrayExpression newArrayExpression = (NewArrayExpression)e;
			if (e.NodeType == ExpressionType.NewArrayInit)
			{
				if (e.Type.GetArrayRank() > 1)
				{
					sb.NewLineIdent(lineIdent).Append("// NOT_SUPPORTED_EXPRESSION: ").Append(e.NodeType)
						.NewLineIdent(lineIdent);
				}
				sb.Append("NewArrayInit(");
			}
			else
			{
				sb.Append("NewArrayBounds(");
			}
			sb.NewLineIdent(lineIdent).AppendTypeof(newArrayExpression.Type.GetElementType(), stripNamespace, printType).Append(", ");
			sb.NewLineIdentArgumentExprs(newArrayExpression.Expressions, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			return sb.Append(')');
		}
		case ExpressionType.MemberInit:
		{
			MemberInitExpression memberInitExpression = (MemberInitExpression)e;
			sb.Append("MemberInit((NewExpression)(");
			sb.NewLineIdentExpr(memberInitExpression.NewExpression, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
			for (int l = 0; l < memberInitExpression.Bindings.Count; l++)
			{
				memberInitExpression.Bindings[l].ToExpressionString(sb.Append(", ").NewLineIdent(lineIdent), paramsExprs, uniqueExprs, lts, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(')');
		}
		case ExpressionType.Lambda:
		{
			LambdaExpression lambdaExpression = (LambdaExpression)e;
			sb.Append("Lambda<").Append(lambdaExpression.Type.ToCode(stripNamespace, printType)).Append(">( //$");
			sb.NewLineIdentExpr(lambdaExpression.Body, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdentArgumentExprs(lambdaExpression.Parameters, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			return sb.Append(')');
		}
		case ExpressionType.Invoke:
		{
			InvocationExpression invocationExpression = (InvocationExpression)e;
			sb.Append("Invoke(");
			sb.NewLineIdentExpr(invocationExpression.Expression, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdentArgumentExprs(invocationExpression.Arguments, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			return sb.Append(")");
		}
		case ExpressionType.Conditional:
		{
			ConditionalExpression conditionalExpression = (ConditionalExpression)e;
			sb.Append("Condition(");
			sb.NewLineIdentExpr(conditionalExpression.Test, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdentExpr(conditionalExpression.IfTrue, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdentExpr(conditionalExpression.IfFalse, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdent(lineIdent).AppendTypeof(conditionalExpression.Type, stripNamespace, printType);
			return sb.Append(')');
		}
		case ExpressionType.Block:
		{
			BlockExpression blockExpression = (BlockExpression)e;
			sb.Append("Block(");
			sb.NewLineIdent(lineIdent).AppendTypeof(blockExpression.Type, stripNamespace, printType).Append(',');
			if (blockExpression.Variables.Count == 0)
			{
				sb.NewLineIdent(lineIdent).Append("new ParameterExpression[0], ");
			}
			else
			{
				sb.NewLineIdent(lineIdent).Append("new[] {");
				for (int j = 0; j < blockExpression.Variables.Count; j++)
				{
					blockExpression.Variables[j].ToExpressionString(((j > 0) ? sb.Append(',') : sb).NewLineIdent(lineIdent), paramsExprs, uniqueExprs, lts, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
				}
				sb.NewLineIdent(lineIdent).Append("},");
			}
			sb.NewLineIdentArgumentExprs(blockExpression.Expressions, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			return sb.Append(')');
		}
		case ExpressionType.Loop:
		{
			LoopExpression loopExpression = (LoopExpression)e;
			sb.Append("Loop(");
			sb.NewLineIdentExpr(loopExpression.Body, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			if (loopExpression.BreakLabel != null)
			{
				loopExpression.BreakLabel.ToExpressionString(sb.Append(',').NewLineIdent(lineIdent), lts, lineIdent, stripNamespace, printType);
			}
			if (loopExpression.ContinueLabel != null)
			{
				loopExpression.ContinueLabel.ToExpressionString(sb.Append(',').NewLineIdent(lineIdent), lts, lineIdent, stripNamespace, printType);
			}
			return sb.Append(')');
		}
		case ExpressionType.Index:
		{
			IndexExpression indexExpression = (IndexExpression)e;
			sb.Append((indexExpression.Indexer != null) ? "MakeIndex(" : "ArrayAccess(");
			sb.NewLineIdentExpr(indexExpression.Object, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(", ");
			if (indexExpression.Indexer != null)
			{
				sb.NewLineIdent(lineIdent).AppendProperty(indexExpression.Indexer, stripNamespace, printType).Append(", ");
			}
			sb.Append("new Expression[] {");
			for (int i = 0; i < indexExpression.Arguments.Count; i++)
			{
				((i > 0) ? sb.Append(',') : sb).NewLineIdentExpr(indexExpression.Arguments[i], paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append("})");
		}
		case ExpressionType.Try:
		{
			TryExpression tryExpression = (TryExpression)e;
			if (tryExpression.Finally == null)
			{
				sb.Append("TryCatch(");
				sb.NewLineIdentExpr(tryExpression.Body, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
				tryExpression.Handlers.ToExpressionString(sb, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else if (tryExpression.Handlers == null)
			{
				sb.Append("TryFinally(");
				sb.NewLineIdentExpr(tryExpression.Body, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
				sb.NewLineIdentExpr(tryExpression.Finally, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else
			{
				sb.Append("TryCatchFinally(");
				sb.NewLineIdentExpr(tryExpression.Body, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
				sb.NewLineIdentExpr(tryExpression.Finally, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
				tryExpression.Handlers.ToExpressionString(sb, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(')');
		}
		case ExpressionType.Label:
		{
			LabelExpression labelExpression = (LabelExpression)e;
			sb.Append("Label(");
			labelExpression.Target.ToExpressionString(sb, lts, lineIdent, stripNamespace, printType);
			if (labelExpression.DefaultValue != null)
			{
				sb.Append(',').NewLineIdentExpr(labelExpression.DefaultValue, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(')');
		}
		case ExpressionType.Goto:
		{
			GotoExpression gotoExpression = (GotoExpression)e;
			sb.Append("MakeGoto(").AppendEnum(gotoExpression.Kind, stripNamespace, printType).Append(',');
			sb.NewLineIdent(lineIdent);
			gotoExpression.Target.ToExpressionString(sb, lts, lineIdent, stripNamespace, printType).Append(',');
			sb.NewLineIdentExpr(gotoExpression.Value, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdent(lineIdent).AppendTypeof(gotoExpression.Type, stripNamespace, printType);
			return sb.Append(')');
		}
		case ExpressionType.Switch:
		{
			SwitchExpression switchExpression = (SwitchExpression)e;
			sb.Append("Switch(");
			sb.NewLineIdentExpr(switchExpression.SwitchValue, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdentExpr(switchExpression.DefaultBody, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdent(lineIdent).AppendMethod(switchExpression.Comparison, stripNamespace, printType);
			switchExpression.Cases.ToExpressionString(sb, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			return sb.Append(')');
		}
		case ExpressionType.Default:
			if (!(e.Type == typeof(void)))
			{
				return sb.Append("Default(").AppendTypeof(e.Type, stripNamespace, printType).Append(')');
			}
			return sb.Append("Empty()");
		case ExpressionType.TypeIs:
		case ExpressionType.TypeEqual:
		{
			TypeBinaryExpression typeBinaryExpression = (TypeBinaryExpression)e;
			sb.Append((e.NodeType == ExpressionType.TypeIs) ? "TypeIs(" : "TypeEqual(");
			sb.NewLineIdentExpr(typeBinaryExpression.Expression, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdent(lineIdent).AppendTypeof(typeBinaryExpression.TypeOperand, stripNamespace, printType);
			return sb.Append(')');
		}
		case ExpressionType.Coalesce:
		{
			BinaryExpression binaryExpression2 = (BinaryExpression)e;
			sb.Append("Coalesce(");
			sb.NewLineIdentExpr(binaryExpression2.Left, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
			sb.NewLineIdentExpr(binaryExpression2.Right, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			if (binaryExpression2.Conversion != null)
			{
				sb.Append(',').NewLineIdentExpr(binaryExpression2.Conversion, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(')');
		}
		case ExpressionType.ListInit:
		{
			ListInitExpression listInitExpression = (ListInitExpression)e;
			sb.Append("ListInit((NewExpression)(");
			sb.NewLineIdentExpr(listInitExpression.NewExpression, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
			for (int k = 0; k < listInitExpression.Initializers.Count; k++)
			{
				listInitExpression.Initializers[k].ToExpressionString(sb.Append(", ").NewLineIdent(lineIdent), paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(")");
		}
		case ExpressionType.Extension:
		{
			Expression e2 = e.Reduce();
			return e2.CreateExpressionString(sb, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		}
		case ExpressionType.Quote:
		case ExpressionType.DebugInfo:
		case ExpressionType.Dynamic:
		case ExpressionType.RuntimeVariables:
			return sb.NewLineIdent(lineIdent).Append("// NOT_SUPPORTED_EXPRESSION: ").Append(e.NodeType)
				.NewLineIdent(lineIdent);
		default:
		{
			string name = Enum.GetName(typeof(ExpressionType), e.NodeType);
			if (e is UnaryExpression unaryExpression)
			{
				sb.Append(name).Append('(');
				sb.NewLineIdentExpr(unaryExpression.Operand, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
				if (e.NodeType == ExpressionType.Convert || e.NodeType == ExpressionType.ConvertChecked || e.NodeType == ExpressionType.Unbox || e.NodeType == ExpressionType.Throw || e.NodeType == ExpressionType.TypeAs)
				{
					sb.Append(',').NewLineIdent(lineIdent).AppendTypeof(e.Type, stripNamespace, printType);
				}
				if ((e.NodeType == ExpressionType.Convert || e.NodeType == ExpressionType.ConvertChecked) && unaryExpression.Method != null)
				{
					sb.Append(',').NewLineIdent(lineIdent).AppendMethod(unaryExpression.Method, stripNamespace, printType);
				}
			}
			if (e is BinaryExpression binaryExpression)
			{
				sb.Append("MakeBinary(").Append(typeof(ExpressionType).Name).Append('.')
					.Append(name)
					.Append(',');
				sb.NewLineIdentExpr(binaryExpression.Left, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(',');
				sb.NewLineIdentExpr(binaryExpression.Right, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
				if (binaryExpression.IsLiftedToNull || binaryExpression.Method != null)
				{
					sb.Append(',').NewLineIdent(lineIdent).Append("liftToNull: ")
						.Append(binaryExpression.IsLiftedToNull.ToCode());
					sb.Append(',').NewLineIdent(lineIdent).AppendMethod(binaryExpression.Method, stripNamespace, printType);
					if (binaryExpression.Conversion != null)
					{
						sb.Append(',').NewLineIdentExpr(binaryExpression.Conversion, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
					}
				}
				if (binaryExpression.Conversion != null)
				{
					sb.Append(',').NewLineIdentExpr(binaryExpression.Conversion, paramsExprs, uniqueExprs, lts, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
				}
			}
			return sb.Append(')');
		}
		}
	}
}
