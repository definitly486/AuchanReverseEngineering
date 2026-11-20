using NLog.Conditions;
using NLog.Config;

namespace NLog.Targets.Wrappers;

[NLogConfigurationItem]
public class FilteringRule
{
	public ConditionExpression? Exists { get; set; }

	public ConditionExpression? Filter { get; set; }

	public FilteringRule()
	{
	}

	public FilteringRule(ConditionExpression whenExistsExpression, ConditionExpression filterToApply)
	{
		Exists = whenExistsExpression;
		Filter = filterToApply;
	}
}
