namespace System.ComponentModel.DataAnnotations;

public abstract class ValidationAttribute : Attribute
{
	private Func<string> _errorMessageResourceAccessor;

	protected ValidationAttribute(Func<string> errorMessageAccessor)
	{
		_errorMessageResourceAccessor = errorMessageAccessor;
	}
}
