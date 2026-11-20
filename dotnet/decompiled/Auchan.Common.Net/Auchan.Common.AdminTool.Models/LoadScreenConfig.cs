namespace Auchan.Common.AdminTool.Models;

public class LoadScreenConfig
{
	public string Name { get; set; }

	public string LoadScreenAnimationUrl { get; set; }

	public LoadScreenConfig(string name, string loadScreenAnimationUrl)
	{
		Name = name;
		LoadScreenAnimationUrl = loadScreenAnimationUrl;
	}
}
