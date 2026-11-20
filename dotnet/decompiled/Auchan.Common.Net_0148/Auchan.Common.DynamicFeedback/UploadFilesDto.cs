using System.Collections.Generic;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback;

public class UploadFilesDto
{
	[JsonProperty("files")]
	public List<FileResult> Files { get; }

	public UploadFilesDto(List<FileResult> files)
	{
		Files = files;
	}
}
