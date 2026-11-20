using System.Text;

namespace NLog;

public interface IJsonConverter
{
	bool SerializeObject(object? value, StringBuilder builder);
}
