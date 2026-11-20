using System;

namespace NLog.LayoutRenderers;

[LayoutRenderer("commonApplicationDataDir")]
public class SpecialFolderCommonApplicationDataLayoutRenderer : SpecialFolderLayoutRenderer
{
	public SpecialFolderCommonApplicationDataLayoutRenderer()
	{
		base.Folder = Environment.SpecialFolder.CommonApplicationData;
	}
}
