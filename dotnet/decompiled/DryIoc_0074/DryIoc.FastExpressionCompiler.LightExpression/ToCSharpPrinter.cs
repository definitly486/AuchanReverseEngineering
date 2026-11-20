using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public static class ToCSharpPrinter
{
	private const string NotSupportedExpression = "// NOT_SUPPORTED_EXPRESSION: ";

	public static string ToCSharpString(this Expression expr)
	{
		return expr.ToCSharpString(new StringBuilder(1024), 4, stripNamespace: true).Append(';').ToString();
	}

	public static string ToCSharpString(this Expression expr, TryPrintConstant tryPrintConstant)
	{
		return expr.ToCSharpString(new StringBuilder(1024), 4, stripNamespace: true, null, 4, tryPrintConstant).Append(';').ToString();
	}

	public static StringBuilder ToCSharpString(this Expression e, StringBuilder sb, int lineIdent = 0, bool stripNamespace = false, Func<Type, string, string> printType = null, int identSpaces = 4, TryPrintConstant tryPrintConstant = null)
	{
		switch (e.NodeType)
		{
		case ExpressionType.Constant:
		{
			ConstantExpression constantExpression3 = (ConstantExpression)e;
			if (tryPrintConstant != null)
			{
				string text = tryPrintConstant(constantExpression3);
				if (text != null)
				{
					return sb.Append(text);
				}
			}
			if (constantExpression3.Value == null)
			{
				return sb.Append("null");
			}
			if (constantExpression3.Value is Type type)
			{
				return sb.AppendTypeof(type, stripNamespace, printType);
			}
			if (constantExpression3.Value.GetType() != constantExpression3.Type)
			{
				sb.Append('(').Append(constantExpression3.Type.ToCode(stripNamespace, printType)).Append(')');
			}
			return sb.Append(constantExpression3.Value.ToCode(CodePrinter.DefaultConstantValueToCode, stripNamespace, printType));
		}
		case ExpressionType.Parameter:
			return sb.AppendName(((ParameterExpression)e).Name, e.Type, e);
		case ExpressionType.New:
		{
			NewExpression newExpression = (NewExpression)e;
			sb.Append("new ").Append(e.Type.ToCode(stripNamespace, printType)).Append('(');
			IReadOnlyList<Expression> arguments = newExpression.Arguments;
			if (arguments.Count == 1)
			{
				arguments[0].ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else if (arguments.Count > 1)
			{
				for (int j = 0; j < arguments.Count; j++)
				{
					((j > 0) ? sb.Append(',') : sb).NewLineIdent(lineIdent);
					arguments[j].ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
				}
			}
			return sb.Append(')');
		}
		case ExpressionType.Call:
		{
			MethodCallExpression methodCallExpression = (MethodCallExpression)e;
			if (methodCallExpression.Object != null)
			{
				methodCallExpression.Object.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else
			{
				sb.Append(methodCallExpression.Method.DeclaringType.ToCode(stripNamespace, printType));
			}
			string name2 = methodCallExpression.Method.Name;
			if (methodCallExpression.Method.IsSpecialName && (name2.StartsWith("get_") || name2.StartsWith("set_")))
			{
				return sb.Append('.').Append(name2.Substring(4));
			}
			sb.Append('.').Append(name2);
			if (methodCallExpression.Method.IsGenericMethod)
			{
				sb.Append('<');
				Type[] genericArguments = methodCallExpression.Method.GetGenericArguments();
				for (int num4 = 0; num4 < genericArguments.Length; num4++)
				{
					((num4 == 0) ? sb : sb.Append(", ")).Append(genericArguments[num4].ToCode(stripNamespace, printType));
				}
				sb.Append('>');
			}
			sb.Append('(');
			ParameterInfo[] parameters2 = methodCallExpression.Method.GetParameters();
			IReadOnlyList<Expression> arguments3 = methodCallExpression.Arguments;
			if (arguments3.Count == 1)
			{
				ParameterInfo parameterInfo2 = parameters2[0];
				if (parameterInfo2.ParameterType.IsByRef)
				{
					sb.Append(parameterInfo2.IsOut ? "out " : (parameterInfo2.IsIn ? "in" : "ref "));
				}
				arguments3[0].ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else if (arguments3.Count > 1)
			{
				for (int num5 = 0; num5 < arguments3.Count; num5++)
				{
					((num5 == 0) ? sb : sb.Append(',')).NewLineIdent(lineIdent);
					ParameterInfo parameterInfo3 = parameters2[num5];
					if (parameterInfo3.ParameterType.IsByRef)
					{
						sb.Append(parameterInfo3.IsOut ? "out " : (parameterInfo3.IsIn ? "in " : "ref "));
					}
					arguments3[num5].ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
				}
			}
			return sb.Append(')');
		}
		case ExpressionType.MemberAccess:
		{
			MemberExpression memberExpression = (MemberExpression)e;
			if (memberExpression.Expression != null)
			{
				memberExpression.Expression.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else
			{
				sb.Append(memberExpression.Member.DeclaringType.ToCode(stripNamespace, printType));
			}
			return sb.Append('.').Append(memberExpression.Member.GetCSharpName());
		}
		case ExpressionType.NewArrayInit:
		case ExpressionType.NewArrayBounds:
		{
			NewArrayExpression newArrayExpression = (NewArrayExpression)e;
			sb.Append("new ").Append(e.Type.GetElementType().ToCode(stripNamespace, printType));
			sb.Append((e.NodeType == ExpressionType.NewArrayInit) ? "[] {" : "[");
			IReadOnlyList<Expression> expressions = newArrayExpression.Expressions;
			if (expressions.Count == 1)
			{
				expressions[0].ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else if (expressions.Count > 1)
			{
				for (int num2 = 0; num2 < expressions.Count; num2++)
				{
					expressions[num2].ToCSharpString(((num2 > 0) ? sb.Append(',') : sb).NewLineIdent(lineIdent), lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
				}
			}
			return sb.Append((e.NodeType == ExpressionType.NewArrayInit) ? "}" : "]");
		}
		case ExpressionType.MemberInit:
		{
			MemberInitExpression memberInitExpression = (MemberInitExpression)e;
			memberInitExpression.NewExpression.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			sb.NewLine(lineIdent, identSpaces).Append('{');
			memberInitExpression.Bindings.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			return sb.NewLine(lineIdent, identSpaces).Append('}');
		}
		case ExpressionType.ListInit:
		{
			ListInitExpression listInitExpression = (ListInitExpression)e;
			listInitExpression.NewExpression.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			sb.NewLine(lineIdent, identSpaces).Append('{');
			IReadOnlyList<ElementInit> initializers = listInitExpression.Initializers;
			for (int l = 0; l < initializers.Count; l++)
			{
				((l == 0) ? sb : sb.Append(", ")).NewLineIdent(lineIdent);
				ElementInit elementInit = initializers[l];
				IReadOnlyList<Expression> arguments2 = elementInit.Arguments;
				if (arguments2.Count == 1)
				{
					arguments2.GetArgument(0).ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
					continue;
				}
				sb.Append('{');
				for (int m = 0; m < arguments2.Count; m++)
				{
					arguments2.GetArgument(m).ToCSharpString((m == 0) ? sb : sb.Append(", "), lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
				}
				sb.Append('}');
			}
			return sb.NewLine(lineIdent, identSpaces).Append("};");
		}
		case ExpressionType.Lambda:
		{
			LambdaExpression lambdaExpression = (LambdaExpression)e;
			sb.Append('(').Append(e.Type.ToCode(stripNamespace, printType)).Append(")((");
			int count = lambdaExpression.Parameters.Count;
			if (count > 0)
			{
				ParameterInfo[] parameters = lambdaExpression.Type.FindDelegateInvokeMethod().GetParameters();
				for (int k = 0; k < count; k++)
				{
					if (k > 0)
					{
						sb.Append(", ");
					}
					if (count > 1)
					{
						sb.NewLineIdent(lineIdent);
					}
					ParameterExpression parameterExpression = lambdaExpression.Parameters[k];
					ParameterInfo parameterInfo = parameters[k];
					if (parameterExpression.IsByRef)
					{
						sb.Append(parameterInfo.IsOut ? "out " : (parameterInfo.IsIn ? "in " : "ref "));
					}
					sb.Append(parameterExpression.Type.ToCode(stripNamespace, printType)).Append(' ');
					sb.AppendName(parameterExpression.Name, parameterExpression.Type, parameterExpression);
				}
			}
			sb.Append(") => //$");
			Expression body = lambdaExpression.Body;
			ExpressionType nodeType2 = body.NodeType;
			bool flag2 = nodeType2 != ExpressionType.Block && nodeType2 != ExpressionType.Try && nodeType2 != ExpressionType.Loop;
			if (flag2 && lambdaExpression.ReturnType != typeof(void))
			{
				sb.NewLineIdentCs(body, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else
			{
				sb.NewLine(lineIdent, identSpaces).Append('{');
				if (body is BlockExpression b2)
				{
					b2.BlockToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant, inTheLastBlock: true);
				}
				else
				{
					sb.NewLineIdentCs(body, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
					if (flag2)
					{
						sb.AddSemicolonIfFits();
					}
				}
				sb.NewLine(lineIdent, identSpaces).Append('}');
			}
			return sb.Append(')');
		}
		case ExpressionType.Invoke:
		{
			InvocationExpression invocationExpression = (InvocationExpression)e;
			sb.Append("new ").Append(invocationExpression.Expression.Type.ToCode(stripNamespace, printType)).Append("(");
			sb.NewLineIdentCs(invocationExpression.Expression, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			sb.Append(").Invoke(");
			for (int num3 = 0; num3 < invocationExpression.Arguments.Count; num3++)
			{
				((num3 > 0) ? sb.Append(',') : sb).NewLineIdentCs(invocationExpression.Arguments[num3], lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(")");
		}
		case ExpressionType.Conditional:
		{
			ConditionalExpression conditionalExpression = (ConditionalExpression)e;
			if (e.Type == typeof(void))
			{
				sb.NewLine(lineIdent, identSpaces);
				sb.Append("if (");
				conditionalExpression.Test.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
				sb.Append(')');
				sb.NewLine(lineIdent, identSpaces).Append('{');
				if (conditionalExpression.IfTrue is BlockExpression b3)
				{
					b3.BlockToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
				}
				else
				{
					sb.NewLineIdentCs(conditionalExpression.IfTrue, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).AddSemicolonIfFits();
				}
				sb.NewLine(lineIdent, identSpaces).Append('}');
				if (conditionalExpression.IfFalse.NodeType != ExpressionType.Default || conditionalExpression.IfFalse.Type != typeof(void))
				{
					sb.NewLine(lineIdent, identSpaces).Append("else");
					sb.NewLine(lineIdent, identSpaces).Append('{');
					if (conditionalExpression.IfFalse is BlockExpression e3)
					{
						e3.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
					}
					else
					{
						sb.NewLineIdentCs(conditionalExpression.IfFalse, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(';');
					}
					sb.NewLine(lineIdent, identSpaces).Append('}');
				}
			}
			else
			{
				conditionalExpression.Test.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(" ?");
				sb.NewLineIdentCs(conditionalExpression.IfTrue, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(" :");
				sb.NewLineIdentCs(conditionalExpression.IfFalse, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb;
		}
		case ExpressionType.Block:
			return ((BlockExpression)e).BlockToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		case ExpressionType.Loop:
		{
			LoopExpression loopExpression = (LoopExpression)e;
			sb.NewLine(lineIdent, identSpaces).Append("while (true)");
			sb.NewLine(lineIdent, identSpaces).Append("{");
			if (loopExpression.ContinueLabel != null)
			{
				sb.NewLine(lineIdent, identSpaces);
				loopExpression.ContinueLabel.ToCSharpString(sb).Append(": ");
			}
			loopExpression.Body.ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
			sb.NewLine(lineIdent, identSpaces).Append("}");
			if (loopExpression.BreakLabel != null)
			{
				sb.NewLine(lineIdent, identSpaces);
				loopExpression.BreakLabel.ToCSharpString(sb).Append(": ");
			}
			return sb;
		}
		case ExpressionType.Index:
		{
			IndexExpression indexExpression = (IndexExpression)e;
			indexExpression.Object.ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
			bool flag3 = indexExpression.Indexer == null || indexExpression.Indexer.Name == "Item";
			if (flag3)
			{
				sb.Append('[');
			}
			else
			{
				sb.Append('.').Append(indexExpression.Indexer.Name).Append('(');
			}
			for (int n = 0; n < indexExpression.Arguments.Count; n++)
			{
				indexExpression.Arguments[n].ToCSharpString((n > 0) ? sb.Append(", ") : sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			return sb.Append(flag3 ? ']' : ')');
		}
		case ExpressionType.Try:
		{
			TryExpression tryExpression = (TryExpression)e;
			bool returnsValue = e.Type != typeof(void);
			sb.Append("try");
			sb.NewLine(lineIdent, identSpaces).Append('{');
			PrintPart(tryExpression.Body);
			sb.NewLine(lineIdent, identSpaces).Append('}');
			IReadOnlyList<CatchBlock> handlers = tryExpression.Handlers;
			if (handlers != null && handlers.Count > 0)
			{
				for (int i = 0; i < handlers.Count; i++)
				{
					CatchBlock catchBlock = handlers[i];
					sb.NewLine(lineIdent, identSpaces).Append("catch (");
					string value3 = catchBlock.Test.ToCode(stripNamespace, printType);
					sb.Append(value3);
					if (catchBlock.Variable != null)
					{
						sb.Append(' ').AppendName(catchBlock.Variable.Name, catchBlock.Variable.Type, catchBlock.Variable);
					}
					sb.Append(')');
					if (catchBlock.Filter != null)
					{
						sb.Append("when (");
						sb.NewLineIdentCs(catchBlock.Filter, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
						sb.NewLine(lineIdent, identSpaces).Append(')');
					}
					sb.NewLine(lineIdent, identSpaces).Append('{');
					PrintPart(catchBlock.Body);
					sb.NewLine(lineIdent, identSpaces).Append('}');
				}
			}
			if (tryExpression.Finally != null)
			{
				sb.NewLine(lineIdent, identSpaces).Append("finally");
				sb.NewLine(lineIdent, identSpaces).Append('{');
				PrintPart(tryExpression.Finally);
				sb.NewLine(lineIdent, identSpaces).Append('}');
			}
			return sb;
		}
		case ExpressionType.Label:
		{
			LabelExpression labelExpression = (LabelExpression)e;
			sb.NewLineIdent(lineIdent);
			labelExpression.Target.ToCSharpString(sb).Append(':');
			return sb;
		}
		case ExpressionType.Goto:
		{
			GotoExpression gotoExpression = (GotoExpression)e;
			if (gotoExpression.Kind == GotoExpressionKind.Return || gotoExpression.Value != null)
			{
				Expression value4 = gotoExpression.Value;
				if (value4 == null)
				{
					return sb.Append("return;");
				}
				if (CanBeReturned(value4.NodeType))
				{
					sb.Append("return ");
				}
				value4.ToCSharpString(sb, lineIdent - identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
				return sb;
			}
			return gotoExpression.Target.ToCSharpString(sb.Append("goto "));
		}
		case ExpressionType.Switch:
		{
			SwitchExpression switchExpression = (SwitchExpression)e;
			sb.Append("switch (");
			switchExpression.SwitchValue.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
			sb.NewLine(lineIdent, identSpaces).Append('{');
			foreach (SwitchCase @case in switchExpression.Cases)
			{
				foreach (Expression testValue in @case.TestValues)
				{
					sb.NewLineIdent(lineIdent).Append("case ");
					testValue.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(':');
				}
				sb.NewLineIdent(lineIdent + identSpaces);
				@case.Body.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).AddSemicolonIfFits();
			}
			if (switchExpression.DefaultBody != null)
			{
				sb.NewLineIdent(lineIdent).Append("default:").NewLineIdent(lineIdent + identSpaces);
				switchExpression.DefaultBody.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).AddSemicolonIfFits();
			}
			return sb.NewLine(lineIdent, identSpaces).Append("}");
		}
		case ExpressionType.Default:
			if (!(e.Type == typeof(void)))
			{
				return sb.Append("default(").Append(e.Type.ToCode(stripNamespace, printType)).Append(')');
			}
			return sb;
		case ExpressionType.TypeIs:
		case ExpressionType.TypeEqual:
		{
			TypeBinaryExpression typeBinaryExpression = (TypeBinaryExpression)e;
			sb.Append('(');
			typeBinaryExpression.Expression.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			sb.Append(" is ").Append(typeBinaryExpression.TypeOperand.ToCode(stripNamespace, printType));
			return sb.Append(')');
		}
		case ExpressionType.Coalesce:
		{
			BinaryExpression binaryExpression2 = (BinaryExpression)e;
			binaryExpression2.Left.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces);
			sb.Append(" ?? ").NewLineIdent(lineIdent);
			return binaryExpression2.Right.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		}
		case ExpressionType.Extension:
		{
			Expression e2 = e.Reduce();
			return e2.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
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
			if (e is UnaryExpression { Operand: var operand })
			{
				switch (e.NodeType)
				{
				case ExpressionType.ArrayLength:
					return operand.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(".Length");
				case ExpressionType.Not:
					return operand.ToCSharpString((e.Type == typeof(bool)) ? sb.Append("!(") : sb.Append("~("), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
					sb.Append("((").Append(e.Type.ToCode(stripNamespace, printType)).Append(')');
					return operand.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
				case ExpressionType.Decrement:
					return operand.ToCSharpString(sb.Append('('), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(" - 1)");
				case ExpressionType.Increment:
					return operand.ToCSharpString(sb.Append('('), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(" + 1)");
				case ExpressionType.Negate:
				case ExpressionType.NegateChecked:
					return operand.ToCSharpString(sb.Append("(-"), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
				case ExpressionType.PostIncrementAssign:
					return operand.ToCSharpString(sb.Append('('), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append("++)");
				case ExpressionType.PreIncrementAssign:
					return operand.ToCSharpString(sb.Append("(++"), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
				case ExpressionType.PostDecrementAssign:
					return operand.ToCSharpString(sb.Append('('), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append("--)");
				case ExpressionType.PreDecrementAssign:
					return operand.ToCSharpString(sb.Append("(--"), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
				case ExpressionType.IsTrue:
					return operand.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append("==true");
				case ExpressionType.IsFalse:
					return operand.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append("==false");
				case ExpressionType.TypeAs:
					operand.ToCSharpString(sb.Append('('), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
					return sb.Append(" as ").Append(e.Type.ToCode(stripNamespace, printType)).Append(')');
				case ExpressionType.TypeIs:
					operand.ToCSharpString(sb.Append('('), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
					return sb.Append(" is ").Append(e.Type.ToCode(stripNamespace, printType)).Append(')');
				case ExpressionType.Throw:
					sb.Append("throw ");
					return operand.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(';');
				case ExpressionType.Unbox:
					sb.Append("((").Append(e.Type.ToCode(stripNamespace, printType)).Append(')');
					return operand.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
				default:
					return sb.Append(e.ToString());
				}
			}
			if (e is BinaryExpression binaryExpression)
			{
				ExpressionType nodeType = e.NodeType;
				switch (nodeType)
				{
				case ExpressionType.ArrayIndex:
					binaryExpression.Left.ToCSharpString(sb.Append('('), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
					return binaryExpression.Right.ToCSharpString(sb.Append("["), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append("]");
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
					if (binaryExpression.Right is BlockExpression b)
					{
						sb.Append("// { The block result will be assigned to `").Append(binaryExpression.Left.ToCSharpString(new StringBuilder(), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant)).Append('`');
						b.BlockToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant, inTheLastBlock: false, binaryExpression);
						return sb.NewLineIdent(lineIdent).Append("// } end of block assignment");
					}
					binaryExpression.Left.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
					if (nodeType == ExpressionType.PowerAssign)
					{
						sb.Append(" = System.Math.Pow(");
						binaryExpression.Left.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(", ");
						return binaryExpression.Right.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(")");
					}
					sb.Append(OperatorToCSharpString(nodeType));
					return binaryExpression.Right.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
				default:
					binaryExpression.Left.ToCSharpString(sb.Append('('), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
					switch (nodeType)
					{
					case ExpressionType.Equal:
					{
						bool flag = default(bool);
						int num;
						if (binaryExpression.Right is ConstantExpression { Value: var value2 })
						{
							if (value2 is bool)
							{
								flag = (bool)value2;
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
							return sb;
						}
						sb.Append(" == ");
						break;
					}
					case ExpressionType.NotEqual:
						if (binaryExpression.Right is ConstantExpression { Value: var value } && value is bool)
						{
							if (!(bool)value)
							{
								return sb;
							}
							return sb.Append(" == false");
						}
						sb.Append(" != ");
						break;
					default:
						sb.Append(OperatorToCSharpString(nodeType));
						break;
					}
					return binaryExpression.Right.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(')');
				}
			}
			return sb.Append(e.ToString());
		}
		}
	}

	private static StringBuilder AddSemicolonIfFits(this StringBuilder sb)
	{
		char c = sb[sb.Length - 1];
		if (c != ';')
		{
			return sb.Append(";");
		}
		return sb;
	}

	private static bool CanBeReturned(ExpressionType nt)
	{
		if (nt != ExpressionType.Goto && nt != ExpressionType.Throw && nt != ExpressionType.Block && nt != ExpressionType.Try)
		{
			return nt != ExpressionType.Loop;
		}
		return false;
	}

	private static string GetCSharpName(this MemberInfo m)
	{
		string text = m.Name;
		if (m is FieldInfo && m.DeclaringType.IsValueType && text[0] == '<')
		{
			int num = text.IndexOf('>');
			if (num > 1)
			{
				text = text.Substring(1, num - 1);
			}
		}
		return text;
	}

	internal static StringBuilder ToCSharpString(this LabelTarget target, StringBuilder sb)
	{
		return sb.AppendName(target.Name, target.Type, target);
	}

	private static StringBuilder ToCSharpString(this IReadOnlyList<MemberBinding> bindings, StringBuilder sb, int lineIdent = 0, bool stripNamespace = false, Func<Type, string, string> printType = null, int identSpaces = 4, TryPrintConstant tryPrintConstant = null)
	{
		foreach (MemberBinding binding in bindings)
		{
			sb.NewLineIdent(lineIdent);
			sb.Append(binding.Member.Name).Append(" = ");
			if (binding is MemberAssignment memberAssignment)
			{
				memberAssignment.Expression.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else if (binding is MemberMemberBinding memberMemberBinding)
			{
				sb.Append("{");
				memberMemberBinding.Bindings.ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
				sb.NewLineIdent(lineIdent + identSpaces).Append("}");
			}
			else if (binding is MemberListBinding memberListBinding)
			{
				sb.Append("{");
				foreach (ElementInit initializer in memberListBinding.Initializers)
				{
					sb.NewLineIdent(lineIdent + identSpaces);
					if (initializer.Arguments.Count > 1)
					{
						sb.Append("(");
					}
					int num = 0;
					foreach (Expression argument in initializer.Arguments)
					{
						argument.ToCSharpString((++num > 1) ? sb.Append(", ") : sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
					}
					if (initializer.Arguments.Count > 1)
					{
						sb.Append(")");
					}
					sb.Append(",");
				}
				sb.NewLineIdent(lineIdent + identSpaces).Append("}");
			}
			sb.Append(",");
		}
		return sb;
	}

	private static StringBuilder BlockToCSharpString(this BlockExpression b, StringBuilder sb, int lineIdent = 0, bool stripNamespace = false, Func<Type, string, string> printType = null, int identSpaces = 4, TryPrintConstant tryPrintConstant = null, bool inTheLastBlock = false, BinaryExpression blockResultAssignment = null)
	{
		IReadOnlyList<ParameterExpression> variables = b.Variables;
		if (variables.Count != 0)
		{
			for (int i = 0; i < variables.Count; i++)
			{
				ParameterExpression parameterExpression = variables[i];
				sb.NewLineIdent(lineIdent);
				sb.Append(parameterExpression.Type.ToCode(stripNamespace, printType)).Append(' ');
				sb.AppendName(parameterExpression.Name, parameterExpression.Type, parameterExpression).Append(';');
			}
		}
		IReadOnlyList<Expression> expressions = b.Expressions;
		for (int j = 0; j < expressions.Count - 1; j++)
		{
			Expression expression = expressions[j];
			if (expression is GotoExpression { Kind: GotoExpressionKind.Return } gotoExpression && expressions[j + 1] is LabelExpression labelExpression && labelExpression.Target == gotoExpression.Target)
			{
				sb.NewLineIdent(lineIdent);
				if (gotoExpression.Value == null)
				{
					sb.Append("return;");
				}
				else
				{
					gotoExpression.Value.ToCSharpString(sb.Append("return "), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).AddSemicolonIfFits();
				}
				sb.NewLineIdent(lineIdent);
				labelExpression.Target.ToCSharpString(sb).Append(':');
				if (labelExpression.DefaultValue == null)
				{
					return sb.AppendLine();
				}
				sb.NewLineIdent(lineIdent);
				return labelExpression.DefaultValue.ToCSharpString(sb.Append("return "), lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).AddSemicolonIfFits();
			}
			if (expression is BlockExpression b2)
			{
				b2.BlockToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
				continue;
			}
			sb.NewLineIdent(lineIdent);
			if (expression is LabelExpression)
			{
				expression.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			else
			{
				expression.ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
			}
			if (expression is BlockExpression || expression is ConditionalExpression || expression is TryExpression || expression is LoopExpression || expression is SwitchExpression)
			{
				sb.NewLineIdent(lineIdent);
			}
			else if (!(expression is LabelExpression) && !(expression is DefaultExpression))
			{
				sb.AddSemicolonIfFits();
			}
		}
		Expression expression2 = expressions[expressions.Count - 1];
		if (expression2.NodeType == ExpressionType.Default && expression2.Type == typeof(void))
		{
			return sb;
		}
		if (expression2 is BlockExpression b3)
		{
			return b3.BlockToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant, inTheLastBlock, blockResultAssignment);
		}
		if (expression2 is LabelExpression)
		{
			expression2.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			if (inTheLastBlock)
			{
				sb.AddSemicolonIfFits();
			}
			return sb;
		}
		sb.NewLineIdent(lineIdent);
		if (blockResultAssignment != null)
		{
			blockResultAssignment.Left.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
			if (blockResultAssignment.NodeType != ExpressionType.PowerAssign)
			{
				sb.Append(OperatorToCSharpString(blockResultAssignment.NodeType));
			}
			else
			{
				sb.Append(" = System.Math.Pow(");
				blockResultAssignment.Left.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant).Append(", ");
			}
		}
		else if (inTheLastBlock && b.Type != typeof(void))
		{
			sb.Append("return ");
		}
		if (expression2 is ConditionalExpression || expression2 is TryExpression || expression2 is LoopExpression || expression2 is SwitchExpression || (expression2 is DefaultExpression defaultExpression && defaultExpression.Type == typeof(void)))
		{
			expression2.ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
		}
		else if (expression2.NodeType == ExpressionType.Assign && ((BinaryExpression)expression2).Right is BlockExpression)
		{
			expression2.ToCSharpString(sb, lineIdent, stripNamespace, printType, identSpaces, tryPrintConstant);
		}
		else
		{
			expression2.ToCSharpString(sb, lineIdent + identSpaces, stripNamespace, printType, identSpaces, tryPrintConstant);
			if (blockResultAssignment != null && blockResultAssignment.NodeType == ExpressionType.PowerAssign)
			{
				sb.Append(')');
			}
			sb.AddSemicolonIfFits();
		}
		return sb;
	}

	private static string OperatorToCSharpString(ExpressionType nodeType)
	{
		return nodeType switch
		{
			ExpressionType.And => " & ", 
			ExpressionType.AndAssign => " &= ", 
			ExpressionType.AndAlso => " && ", 
			ExpressionType.Or => " | ", 
			ExpressionType.OrAssign => " |= ", 
			ExpressionType.OrElse => " || ", 
			ExpressionType.GreaterThan => " > ", 
			ExpressionType.GreaterThanOrEqual => " >= ", 
			ExpressionType.LessThan => " < ", 
			ExpressionType.LessThanOrEqual => " <= ", 
			ExpressionType.Equal => " == ", 
			ExpressionType.NotEqual => " != ", 
			ExpressionType.Add => " + ", 
			ExpressionType.AddChecked => " + ", 
			ExpressionType.AddAssign => " += ", 
			ExpressionType.AddAssignChecked => " += ", 
			ExpressionType.Subtract => " - ", 
			ExpressionType.SubtractChecked => " - ", 
			ExpressionType.SubtractAssign => " -= ", 
			ExpressionType.SubtractAssignChecked => " -= ", 
			ExpressionType.Assign => " = ", 
			ExpressionType.ExclusiveOr => " ^ ", 
			ExpressionType.ExclusiveOrAssign => " ^= ", 
			ExpressionType.LeftShift => " << ", 
			ExpressionType.LeftShiftAssign => " <<= ", 
			ExpressionType.RightShift => " >> ", 
			ExpressionType.RightShiftAssign => " >>= ", 
			ExpressionType.Modulo => " % ", 
			ExpressionType.ModuloAssign => " %= ", 
			ExpressionType.Multiply => " * ", 
			ExpressionType.MultiplyChecked => " * ", 
			ExpressionType.MultiplyAssign => " *= ", 
			ExpressionType.MultiplyAssignChecked => " *= ", 
			ExpressionType.Divide => " / ", 
			ExpressionType.DivideAssign => " /= ", 
			_ => "???", 
		};
	}
}
