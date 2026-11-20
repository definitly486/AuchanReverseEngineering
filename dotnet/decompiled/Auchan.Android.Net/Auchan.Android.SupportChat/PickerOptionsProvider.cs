using System;
using System.Collections.Generic;
using Auchan.Common.SupportChat;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Storage;

namespace Auchan.Android.SupportChat;

internal sealed class PickerOptionsProvider : IPickerOptionsProvider
{
	private Lazy<PickOptions> _lazyPickOptions = new Lazy<PickOptions>(new PickOptions
	{
		FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>> { 
		{
			DevicePlatform.Android,
			new string[43]
			{
				"image/jpeg", "image/heic", "image/png", "image/gif", "video/x-ms-wmv", "video/mp4", "video/x-msvideo", "video/quicktime", "application/x-troff-msvideo", "video/avi",
				"video/msvideo", "video/x-msvideo", "text/html", "text/plain", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/pdf", "application/vnd.oasis.opendocument.text", "application/vnd.ms-excel", "application/excel",
				"application/x-excel", "application/x-msexcel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.oasis.opendocument.spreadsheet", "text/csv", "text/comma-separated-values", "application/vnd.ms-powerpoint", "application/vnd.openxmlformats-officedocument.presentationml.presentation", "audio/wav", "audio/vnd.wav",
				"audio/vnd.wave", "audio/wave", "audio/x-pn-wav", "audio/x-wav", "audio/mpeg", "audio/flac", "audio/x-flac", "audio/aac", "application/zip", "application/vnd.rar",
				"application/rar", "application/x-rar", "application/x-rar-compressed"
			}
		} })
	});

	public PickOptions FilePickOptions => _lazyPickOptions.Value;
}
