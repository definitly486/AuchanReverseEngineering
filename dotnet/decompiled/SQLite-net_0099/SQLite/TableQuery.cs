using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SQLite;

public class TableQuery<T> : BaseTableQuery, IEnumerable<T>, IEnumerable
{
	private class CompileResult
	{
		public string CommandText { get; set; }

		public object Value { get; set; }
	}

	private Expression _where;

	private List<Ordering> _orderBys;

	private int? _limit;

	private int? _offset;

	private BaseTableQuery _joinInner;

	private Expression _joinInnerKeySelector;

	private BaseTableQuery _joinOuter;

	private Expression _joinOuterKeySelector;

	private Expression _joinSelector;

	private Expression _selector;

	private bool _deferred;

	public SQLiteConnection Connection { get; private set; }

	public TableMapping Table { get; private set; }

	private TableQuery(SQLiteConnection conn, TableMapping table)
	{
		Connection = conn;
		Table = table;
	}

	public TableQuery(SQLiteConnection conn)
	{
		Connection = conn;
		Table = Connection.GetMapping(typeof(T));
	}

	public TableQuery<U> Clone<U>()
	{
		TableQuery<U> tableQuery = new TableQuery<U>(Connection, Table);
		tableQuery._where = _where;
		tableQuery._deferred = _deferred;
		if (_orderBys != null)
		{
			tableQuery._orderBys = new List<Ordering>(_orderBys);
		}
		tableQuery._limit = _limit;
		tableQuery._offset = _offset;
		tableQuery._joinInner = _joinInner;
		tableQuery._joinInnerKeySelector = _joinInnerKeySelector;
		tableQuery._joinOuter = _joinOuter;
		tableQuery._joinOuterKeySelector = _joinOuterKeySelector;
		tableQuery._joinSelector = _joinSelector;
		tableQuery._selector = _selector;
		return tableQuery;
	}

	public TableQuery<T> Where(Expression<Func<T, bool>> predExpr)
	{
		if (predExpr.NodeType == ExpressionType.Lambda)
		{
			Expression body = predExpr.Body;
			TableQuery<T> tableQuery = Clone<T>();
			tableQuery.AddWhere(body);
			return tableQuery;
		}
		throw new NotSupportedException("Must be a predicate");
	}

	public TableQuery<T> Take(int n)
	{
		TableQuery<T> tableQuery = Clone<T>();
		tableQuery._limit = n;
		return tableQuery;
	}

	private void AddWhere(Expression pred)
	{
		if (_where == null)
		{
			_where = pred;
		}
		else
		{
			_where = Expression.AndAlso(_where, pred);
		}
	}

	private SQLiteCommand GenerateCommand(string selectionList)
	{
		if (_joinInner != null && _joinOuter != null)
		{
			throw new NotSupportedException("Joins are not supported.");
		}
		string text = "select " + selectionList + " from \"" + Table.TableName + "\"";
		List<object> list = new List<object>();
		if (_where != null)
		{
			CompileResult compileResult = CompileExpr(_where, list);
			text = text + " where " + compileResult.CommandText;
		}
		if (_orderBys != null && _orderBys.Count > 0)
		{
			string text2 = string.Join(", ", _orderBys.Select((Ordering o) => "\"" + o.ColumnName + "\"" + (o.Ascending ? "" : " desc")).ToArray());
			text = text + " order by " + text2;
		}
		if (_limit.HasValue)
		{
			text = text + " limit " + _limit.Value;
		}
		if (_offset.HasValue)
		{
			if (!_limit.HasValue)
			{
				text += " limit -1 ";
			}
			text = text + " offset " + _offset.Value;
		}
		return Connection.CreateCommand(text, list.ToArray());
	}

	private CompileResult CompileExpr(Expression expr, List<object> queryArgs)
	{
		if (expr == null)
		{
			throw new NotSupportedException("Expression is NULL");
		}
		if (expr is BinaryExpression)
		{
			BinaryExpression binaryExpression = (BinaryExpression)expr;
			if (binaryExpression.Left.NodeType == ExpressionType.Call)
			{
				MethodCallExpression methodCallExpression = (MethodCallExpression)binaryExpression.Left;
				if (methodCallExpression.Method.DeclaringType.FullName == "Microsoft.VisualBasic.CompilerServices.Operators" && methodCallExpression.Method.Name == "CompareString")
				{
					binaryExpression = Expression.MakeBinary(binaryExpression.NodeType, methodCallExpression.Arguments[0], methodCallExpression.Arguments[1]);
				}
			}
			CompileResult compileResult = CompileExpr(binaryExpression.Left, queryArgs);
			CompileResult compileResult2 = CompileExpr(binaryExpression.Right, queryArgs);
			string commandText = ((compileResult.CommandText == "?" && compileResult.Value == null) ? CompileNullBinaryExpression(binaryExpression, compileResult2) : ((!(compileResult2.CommandText == "?") || compileResult2.Value != null) ? ("(" + compileResult.CommandText + " " + GetSqlName(binaryExpression) + " " + compileResult2.CommandText + ")") : CompileNullBinaryExpression(binaryExpression, compileResult)));
			return new CompileResult
			{
				CommandText = commandText
			};
		}
		if (expr.NodeType == ExpressionType.Not)
		{
			Expression operand = ((UnaryExpression)expr).Operand;
			CompileResult compileResult3 = CompileExpr(operand, queryArgs);
			object obj = compileResult3.Value;
			if (obj is bool)
			{
				obj = !(bool)obj;
			}
			return new CompileResult
			{
				CommandText = "NOT(" + compileResult3.CommandText + ")",
				Value = obj
			};
		}
		if (expr.NodeType == ExpressionType.Call)
		{
			MethodCallExpression methodCallExpression2 = (MethodCallExpression)expr;
			CompileResult[] array = new CompileResult[methodCallExpression2.Arguments.Count];
			CompileResult compileResult4 = ((methodCallExpression2.Object != null) ? CompileExpr(methodCallExpression2.Object, queryArgs) : null);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = CompileExpr(methodCallExpression2.Arguments[i], queryArgs);
			}
			string commandText2 = "";
			if (methodCallExpression2.Method.Name == "Like" && array.Length == 2)
			{
				commandText2 = "(" + array[0].CommandText + " like " + array[1].CommandText + ")";
			}
			else if (methodCallExpression2.Method.Name == "Contains" && array.Length == 2)
			{
				commandText2 = "(" + array[1].CommandText + " in " + array[0].CommandText + ")";
			}
			else if (methodCallExpression2.Method.Name == "Contains" && array.Length == 1)
			{
				commandText2 = ((methodCallExpression2.Object == null || !(methodCallExpression2.Object.Type == typeof(string))) ? ("(" + array[0].CommandText + " in " + compileResult4.CommandText + ")") : ("( instr(" + compileResult4.CommandText + "," + array[0].CommandText + ") >0 )"));
			}
			else if (methodCallExpression2.Method.Name == "StartsWith" && array.Length >= 1)
			{
				StringComparison stringComparison = StringComparison.CurrentCulture;
				if (array.Length == 2)
				{
					stringComparison = (StringComparison)array[1].Value;
				}
				switch (stringComparison)
				{
				case StringComparison.CurrentCulture:
				case StringComparison.Ordinal:
					commandText2 = "( substr(" + compileResult4.CommandText + ", 1, " + array[0].Value.ToString().Length + ") =  " + array[0].CommandText + ")";
					break;
				case StringComparison.CurrentCultureIgnoreCase:
				case StringComparison.OrdinalIgnoreCase:
					commandText2 = "(" + compileResult4.CommandText + " like (" + array[0].CommandText + " || '%'))";
					break;
				}
			}
			else if (!(methodCallExpression2.Method.Name == "EndsWith") || array.Length < 1)
			{
				commandText2 = ((methodCallExpression2.Method.Name == "Equals" && array.Length == 1) ? ("(" + compileResult4.CommandText + " = (" + array[0].CommandText + "))") : ((methodCallExpression2.Method.Name == "ToLower") ? ("(lower(" + compileResult4.CommandText + "))") : ((methodCallExpression2.Method.Name == "ToUpper") ? ("(upper(" + compileResult4.CommandText + "))") : ((methodCallExpression2.Method.Name == "Replace" && array.Length == 2) ? ("(replace(" + compileResult4.CommandText + "," + array[0].CommandText + "," + array[1].CommandText + "))") : ((!(methodCallExpression2.Method.Name == "IsNullOrEmpty") || array.Length != 1) ? (methodCallExpression2.Method.Name.ToLower() + "(" + string.Join(",", array.Select((CompileResult a) => a.CommandText).ToArray()) + ")") : ("(" + array[0].CommandText + " is null or" + array[0].CommandText + " ='' )"))))));
			}
			else
			{
				StringComparison stringComparison2 = StringComparison.CurrentCulture;
				if (array.Length == 2)
				{
					stringComparison2 = (StringComparison)array[1].Value;
				}
				switch (stringComparison2)
				{
				case StringComparison.CurrentCulture:
				case StringComparison.Ordinal:
					commandText2 = "( substr(" + compileResult4.CommandText + ", length(" + compileResult4.CommandText + ") - " + array[0].Value.ToString().Length + "+1, " + array[0].Value.ToString().Length + ") =  " + array[0].CommandText + ")";
					break;
				case StringComparison.CurrentCultureIgnoreCase:
				case StringComparison.OrdinalIgnoreCase:
					commandText2 = "(" + compileResult4.CommandText + " like ('%' || " + array[0].CommandText + "))";
					break;
				}
			}
			return new CompileResult
			{
				CommandText = commandText2
			};
		}
		if (expr.NodeType == ExpressionType.Constant)
		{
			ConstantExpression constantExpression = (ConstantExpression)expr;
			queryArgs.Add(constantExpression.Value);
			return new CompileResult
			{
				CommandText = "?",
				Value = constantExpression.Value
			};
		}
		if (expr.NodeType == ExpressionType.Convert)
		{
			UnaryExpression unaryExpression = (UnaryExpression)expr;
			Type type = unaryExpression.Type;
			CompileResult compileResult5 = CompileExpr(unaryExpression.Operand, queryArgs);
			return new CompileResult
			{
				CommandText = compileResult5.CommandText,
				Value = ((compileResult5.Value != null) ? ConvertTo(compileResult5.Value, type) : null)
			};
		}
		if (expr.NodeType == ExpressionType.MemberAccess)
		{
			MemberExpression memberExpression = (MemberExpression)expr;
			ParameterExpression parameterExpression = memberExpression.Expression as ParameterExpression;
			if (parameterExpression == null && memberExpression.Expression is UnaryExpression { NodeType: ExpressionType.Convert } unaryExpression2)
			{
				parameterExpression = unaryExpression2.Operand as ParameterExpression;
			}
			if (parameterExpression != null)
			{
				string name = Table.FindColumnWithPropertyName(memberExpression.Member.Name).Name;
				return new CompileResult
				{
					CommandText = "\"" + name + "\""
				};
			}
			object obj2 = null;
			if (memberExpression.Expression != null)
			{
				CompileResult compileResult6 = CompileExpr(memberExpression.Expression, queryArgs);
				if (compileResult6.Value == null)
				{
					throw new NotSupportedException("Member access failed to compile expression");
				}
				if (compileResult6.CommandText == "?")
				{
					queryArgs.RemoveAt(queryArgs.Count - 1);
				}
				obj2 = compileResult6.Value;
			}
			object obj3 = null;
			if (memberExpression.Member is PropertyInfo)
			{
				obj3 = ((PropertyInfo)memberExpression.Member).GetValue(obj2, null);
			}
			else
			{
				if (!(memberExpression.Member is FieldInfo))
				{
					throw new NotSupportedException("MemberExpr: " + memberExpression.Member.GetType());
				}
				obj3 = ((FieldInfo)memberExpression.Member).GetValue(obj2);
			}
			if (obj3 != null && obj3 is IEnumerable && !(obj3 is string) && !(obj3 is IEnumerable<byte>))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("(");
				string value = "";
				foreach (object item in (IEnumerable)obj3)
				{
					queryArgs.Add(item);
					stringBuilder.Append(value);
					stringBuilder.Append("?");
					value = ",";
				}
				stringBuilder.Append(")");
				return new CompileResult
				{
					CommandText = stringBuilder.ToString(),
					Value = obj3
				};
			}
			queryArgs.Add(obj3);
			return new CompileResult
			{
				CommandText = "?",
				Value = obj3
			};
		}
		throw new NotSupportedException("Cannot compile: " + expr.NodeType);
	}

	private static object ConvertTo(object obj, Type t)
	{
		Type underlyingType = Nullable.GetUnderlyingType(t);
		if (underlyingType != null)
		{
			if (obj == null)
			{
				return null;
			}
			return Convert.ChangeType(obj, underlyingType);
		}
		return Convert.ChangeType(obj, t);
	}

	private string CompileNullBinaryExpression(BinaryExpression expression, CompileResult parameter)
	{
		if (expression.NodeType == ExpressionType.Equal)
		{
			return "(" + parameter.CommandText + " is ?)";
		}
		if (expression.NodeType == ExpressionType.NotEqual)
		{
			return "(" + parameter.CommandText + " is not ?)";
		}
		if (expression.NodeType == ExpressionType.GreaterThan || expression.NodeType == ExpressionType.GreaterThanOrEqual || expression.NodeType == ExpressionType.LessThan || expression.NodeType == ExpressionType.LessThanOrEqual)
		{
			return "(" + parameter.CommandText + " < ?)";
		}
		throw new NotSupportedException("Cannot compile Null-BinaryExpression with type " + expression.NodeType);
	}

	private string GetSqlName(Expression expr)
	{
		ExpressionType nodeType = expr.NodeType;
		return nodeType switch
		{
			ExpressionType.GreaterThan => ">", 
			ExpressionType.GreaterThanOrEqual => ">=", 
			ExpressionType.LessThan => "<", 
			ExpressionType.LessThanOrEqual => "<=", 
			ExpressionType.And => "&", 
			ExpressionType.AndAlso => "and", 
			ExpressionType.Or => "|", 
			ExpressionType.OrElse => "or", 
			ExpressionType.Equal => "=", 
			ExpressionType.NotEqual => "!=", 
			_ => throw new NotSupportedException("Cannot get SQL for: " + nodeType), 
		};
	}

	public IEnumerator<T> GetEnumerator()
	{
		if (!_deferred)
		{
			return GenerateCommand("*").ExecuteQuery<T>().GetEnumerator();
		}
		return GenerateCommand("*").ExecuteDeferredQuery<T>().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public List<T> ToList()
	{
		return GenerateCommand("*").ExecuteQuery<T>();
	}

	public T First()
	{
		return Take(1).ToList().First();
	}

	public T FirstOrDefault()
	{
		return Take(1).ToList().FirstOrDefault();
	}
}
