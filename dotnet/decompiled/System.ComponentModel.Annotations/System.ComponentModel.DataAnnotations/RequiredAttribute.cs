namespace System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class RequiredAttribute : ValidationAttribute
{
	public RequiredAttribute()
		: base(() => "The {0} field is required.")
	{
	}
}
