namespace SkiaSharp.Internals;

public interface IPlatformLock
{
	void EnterWriteLock();

	void ExitWriteLock();

	void EnterUpgradeableReadLock();

	void ExitUpgradeableReadLock();
}
