using System;

namespace Splat;

public interface ILogManager
{
	IFullLogger GetLogger(Type type);
}
