using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel.DataTransfer;

public interface IClipboard
{
	Task SetTextAsync(string? text);
}
