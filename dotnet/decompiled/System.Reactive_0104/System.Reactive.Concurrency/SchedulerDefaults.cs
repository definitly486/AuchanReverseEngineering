namespace System.Reactive.Concurrency;

internal static class SchedulerDefaults
{
	internal static IScheduler ConstantTimeOperations => ImmediateScheduler.Instance;

	internal static IScheduler Iteration => CurrentThreadScheduler.Instance;

	internal static IScheduler TimeBasedOperations => DefaultScheduler.Instance;
}
