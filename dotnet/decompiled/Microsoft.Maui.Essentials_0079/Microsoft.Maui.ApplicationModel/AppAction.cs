using System;

namespace Microsoft.Maui.ApplicationModel;

public class AppAction
{
	public string Title { get; set; }

	public string? Subtitle { get; set; }

	public string Id { get; set; }

	internal string? Icon { get; set; }

	public AppAction(string id, string title, string? subtitle = null, string? icon = null)
	{
		Id = id ?? throw new ArgumentNullException("id");
		Title = title ?? throw new ArgumentNullException("title");
		Subtitle = subtitle;
		Icon = icon;
	}
}
