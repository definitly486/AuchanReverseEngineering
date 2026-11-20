using System.Text;
using System.Threading;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Conditions;

internal sealed class ConditionLayoutExpression : ConditionExpression
{
	private readonly SimpleLayout _simpleLayout;

	private StringBuilder? _fastObjectPool;

	public Layout Layout => _simpleLayout;

	public ConditionLayoutExpression(SimpleLayout layout)
	{
		_simpleLayout = layout;
	}

	public override string ToString()
	{
		return "'" + _simpleLayout.ToString() + "'";
	}

	protected override object EvaluateNode(LogEventInfo context)
	{
		if (_simpleLayout.IsSimpleStringText || !_simpleLayout.ThreadAgnostic)
		{
			return _simpleLayout.Render(context);
		}
		StringBuilder stringBuilder = Interlocked.Exchange(ref _fastObjectPool, null) ?? new StringBuilder();
		try
		{
			_simpleLayout.Render(context, stringBuilder);
			return stringBuilder.ToString();
		}
		finally
		{
			stringBuilder.ClearBuilder();
			Interlocked.Exchange(ref _fastObjectPool, stringBuilder);
		}
	}
}
