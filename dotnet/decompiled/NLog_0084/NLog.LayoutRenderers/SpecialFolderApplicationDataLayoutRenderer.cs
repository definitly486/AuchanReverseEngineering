using System;

namespace NLog.LayoutRenderers;

[LayoutRenderer("userApplicationDataDir")]
public class SpecialFolderApplicationDataLayoutRenderer : SpecialFolderLayoutRenderer
{
	public SpecialFolderApplicationDataLayoutRenderer()
	{
		base.Folder = Environment.SpecialFolder.ApplicationData;
	}
}
