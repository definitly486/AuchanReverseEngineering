namespace Refit;

public interface IFormUrlEncodedParameterFormatter
{
	string? Format(object? value, string? formatString);
}
