using System;

namespace NLog.LayoutRenderers;

[LayoutRenderer("userLocalApplicationDataDir")]
public class SpecialFolderLocalApplicationDataLayoutRenderer : SpecialFolderLayoutRenderer
{
	public SpecialFolderLocalApplicationDataLayoutRenderer()
	{
		base.Folder = Environment.SpecialFolder.LocalApplicationData;
	}
}
