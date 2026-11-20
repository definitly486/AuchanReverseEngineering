using Auchan.Common.SupportChat.Models;

namespace Auchan.Common.SupportChat.DTO;

public static class UploadFileResponseDTO_Extensions
{
	public static UploadFileResult Map(this UploadFileResponseDTO @this)
	{
		if (!@this.IsValid())
		{
			return UploadFileResult.Invalid();
		}
		return new UploadFileResult(@this.Result.NumberOfDownloads, @this.Result.RealPath, @this.Result.DownloadLink, @this.Result.Size, @this.Result.ContentType);
	}

	public static bool IsValid(this UploadFileResponseDTO @this)
	{
		if (@this.Result != null && !string.IsNullOrEmpty(@this.Result.RealPath))
		{
			return !string.IsNullOrEmpty(@this.Result.DownloadLink);
		}
		return false;
	}
}
