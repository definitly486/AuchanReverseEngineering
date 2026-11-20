using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace System.Threading;

internal sealed class PortableThreadPool
{
	[StructLayout(LayoutKind.Explicit, Size = 768)]
	private struct CacheLineSeparated
	{
		[FieldOffset(128)]
		public ThreadCounts counts;

		[FieldOffset(256)]
		public int lastDequeueTime;

		[FieldOffset(384)]
		public int priorCompletionCount;

		[FieldOffset(388)]
		public int priorCompletedWorkRequestsTime;

		[FieldOffset(392)]
		public int nextCompletedWorkRequestsTime;

		[FieldOffset(512)]
		public volatile int numRequestedWorkers;

		[FieldOffset(516)]
		public int gateThreadRunningState;
	}

	private enum PendingBlockingAdjustment : byte
	{
		None,
		Immediately,
		WithDelayIfNecessary
	}

	private static class BlockingConfig
	{
		public static readonly bool IsCooperativeBlockingEnabled;

		public static readonly bool IgnoreMemoryUsage;

		public static readonly short ThreadsToAddWithoutDelay;

		public static readonly short ThreadsPerDelayStep;

		public static readonly uint DelayStepMs;

		public static readonly uint MaxDelayMs;

		static BlockingConfig()
		{
			IsCooperativeBlockingEnabled = AppContextConfigHelper.GetBooleanConfig("System.Threading.ThreadPool.Blocking.CooperativeBlocking", defaultValue: true);
			IgnoreMemoryUsage = AppContextConfigHelper.GetBooleanConfig("System.Threading.ThreadPool.Blocking.IgnoreMemoryUsage", defaultValue: false);
			int int32Config = AppContextConfigHelper.GetInt32Config("System.Threading.ThreadPool.Blocking.ThreadsToAddWithoutDelay_ProcCountFactor", 1, allowNegative: false);
			int int32Config2 = AppContextConfigHelper.GetInt32Config("System.Threading.ThreadPool.Blocking.ThreadsPerDelayStep_ProcCountFactor", 1, allowNegative: false);
			DelayStepMs = (uint)AppContextConfigHelper.GetInt32Config("System.Threading.ThreadPool.Blocking.DelayStepMs", 25, allowNegative: false);
			MaxDelayMs = (uint)AppContextConfigHelper.GetInt32Config("System.Threading.ThreadPool.Blocking.MaxDelayMs", 250, allowNegative: false);
			int processorCount = Environment.ProcessorCount;
			ThreadsToAddWithoutDelay = (short)(processorCount * int32Config);
			if (ThreadsToAddWithoutDelay > short.MaxValue || ThreadsToAddWithoutDelay / processorCount != int32Config)
			{
				ThreadsToAddWithoutDelay = short.MaxValue;
			}
			int32Config2 = Math.Max(1, int32Config2);
			short num = (short)(32767 - ThreadsToAddWithoutDelay);
			ThreadsPerDelayStep = (short)(processorCount * int32Config2);
			if (ThreadsPerDelayStep > num || ThreadsPerDelayStep / processorCount != int32Config2)
			{
				ThreadsPerDelayStep = num;
			}
			MaxDelayMs = Math.Max(1u, Math.Min(MaxDelayMs, 500u));
			DelayStepMs = Math.Max(1u, Math.Min(DelayStepMs, MaxDelayMs));
		}
	}

	private static class GateThread
	{
		private struct DelayHelper
		{
			private int _previousGateActivitiesTimeMs;

			private int _previousBlockingAdjustmentDelayStartTimeMs;

			private uint _previousBlockingAdjustmentDelayMs;

			private bool _runGateActivitiesAfterNextDelay;

			private bool _adjustForBlockingAfterNextDelay;

			public bool HasBlockingAdjustmentDelay => _previousBlockingAdjustmentDelayMs != 0;

			public void SetGateActivitiesTime(int currentTimeMs)
			{
				_previousGateActivitiesTimeMs = currentTimeMs;
			}

			public void SetBlockingAdjustmentTimeAndDelay(int currentTimeMs, uint delayMs)
			{
				_previousBlockingAdjustmentDelayStartTimeMs = currentTimeMs;
				_previousBlockingAdjustmentDelayMs = delayMs;
			}

			public void ClearBlockingAdjustmentDelay()
			{
				_previousBlockingAdjustmentDelayMs = 0u;
			}

			public uint GetNextDelay(int currentTimeMs)
			{
				uint num = (uint)(currentTimeMs - _previousGateActivitiesTimeMs);
				uint num2 = ((num >= 500) ? 1u : (500 - num));
				if (_previousBlockingAdjustmentDelayMs == 0)
				{
					_runGateActivitiesAfterNextDelay = true;
					_adjustForBlockingAfterNextDelay = false;
					return num2;
				}
				uint num3 = (uint)(currentTimeMs - _previousBlockingAdjustmentDelayStartTimeMs);
				uint num4 = ((num3 >= _previousBlockingAdjustmentDelayMs) ? 1u : (_previousBlockingAdjustmentDelayMs - num3));
				uint num5 = Math.Min(num2, num4);
				_runGateActivitiesAfterNextDelay = num5 == num2;
				_adjustForBlockingAfterNextDelay = num5 == num4;
				return num5;
			}

			public bool ShouldPerformGateActivities(int currentTimeMs, bool wasSignaledToWake)
			{
				int num;
				if (wasSignaledToWake || !_runGateActivitiesAfterNextDelay)
				{
					num = (((uint)(currentTimeMs - _previousGateActivitiesTimeMs) >= 500u) ? 1 : 0);
					if (num == 0)
					{
						goto IL_002a;
					}
				}
				else
				{
					num = 1;
				}
				SetGateActivitiesTime(currentTimeMs);
				goto IL_002a;
				IL_002a:
				return (byte)num != 0;
			}

			public bool HasBlockingAdjustmentDelayElapsed(int currentTimeMs, bool wasSignaledToWake)
			{
				if (!wasSignaledToWake && _adjustForBlockingAfterNextDelay)
				{
					return true;
				}
				return (uint)(currentTimeMs - _previousBlockingAdjustmentDelayStartTimeMs) >= _previousBlockingAdjustmentDelayMs;
			}
		}

		private static readonly AutoResetEvent RunGateThreadEvent = new AutoResetEvent(initialState: true);

		private static readonly AutoResetEvent DelayEvent = new AutoResetEvent(initialState: false);

		private static void GateThreadStart()
		{
			bool booleanComPlusOrDotNetConfig = AppContextConfigHelper.GetBooleanComPlusOrDotNetConfig("System.Threading.ThreadPool.DisableStarvationDetection", "ThreadPool_DisableStarvationDetection", defaultValue: false);
			bool booleanComPlusOrDotNetConfig2 = AppContextConfigHelper.GetBooleanComPlusOrDotNetConfig("System.Threading.ThreadPool.DebugBreakOnWorkerStarvation", "ThreadPool_DebugBreakOnWorkerStarvation", defaultValue: false);
			int int32Config = AppContextConfigHelper.GetInt32Config("System.Threading.ThreadPool.CpuUtilizationIntervalMs", "DOTNET_ThreadPool_CpuUtilizationIntervalMs", 1, allowNegative: false);
			CpuUtilizationReader cpuUtilizationReader = default(CpuUtilizationReader);
			int num = 0;
			if (int32Config > 0)
			{
				num = Environment.TickCount;
				_ = cpuUtilizationReader.CurrentUtilization;
			}
			PortableThreadPool threadPoolInstance = ThreadPoolInstance;
			LowLevelLock threadAdjustmentLock = threadPoolInstance._threadAdjustmentLock;
			DelayHelper delayHelper = default(DelayHelper);
			if (BlockingConfig.IsCooperativeBlockingEnabled && !BlockingConfig.IgnoreMemoryUsage)
			{
				threadPoolInstance.OnGen2GCCallback();
				Gen2GcCallback.Register(threadPoolInstance.OnGen2GCCallback);
			}
			while (true)
			{
				RunGateThreadEvent.WaitOne();
				int tickCount = Environment.TickCount;
				delayHelper.SetGateActivitiesTime(tickCount);
				while (true)
				{
					bool wasSignaledToWake = DelayEvent.WaitOne((int)delayHelper.GetNextDelay(tickCount));
					tickCount = Environment.TickCount;
					PendingBlockingAdjustment pendingBlockingAdjustment = threadPoolInstance._pendingBlockingAdjustment;
					if (pendingBlockingAdjustment == PendingBlockingAdjustment.None)
					{
						delayHelper.ClearBlockingAdjustmentDelay();
					}
					else
					{
						bool flag = false;
						if (delayHelper.HasBlockingAdjustmentDelay)
						{
							flag = delayHelper.HasBlockingAdjustmentDelayElapsed(tickCount, wasSignaledToWake);
							if (pendingBlockingAdjustment == PendingBlockingAdjustment.WithDelayIfNecessary && !flag)
							{
								goto IL_0125;
							}
						}
						uint num2 = threadPoolInstance.PerformBlockingAdjustment(flag);
						if (num2 == 0)
						{
							delayHelper.ClearBlockingAdjustmentDelay();
						}
						else
						{
							delayHelper.SetBlockingAdjustmentTimeAndDelay(tickCount, num2);
						}
					}
					goto IL_0125;
					IL_0125:
					if (!delayHelper.ShouldPerformGateActivities(tickCount, wasSignaledToWake))
					{
						continue;
					}
					if (!ThreadPool.EnableWorkerTracking || NativeRuntimeEventSource.Log.IsEnabled())
					{
					}
					if (int32Config > 0 && threadPoolInstance._pendingBlockingAdjustment == PendingBlockingAdjustment.None && (uint)(tickCount - num) >= (uint)int32Config)
					{
						num = tickCount;
						int cpuUtilization = (int)cpuUtilizationReader.CurrentUtilization;
						threadPoolInstance._cpuUtilization = cpuUtilization;
					}
					if (!booleanComPlusOrDotNetConfig && threadPoolInstance._pendingBlockingAdjustment == PendingBlockingAdjustment.None && threadPoolInstance._separated.numRequestedWorkers > 0 && SufficientDelaySinceLastDequeue(threadPoolInstance))
					{
						bool flag2 = false;
						threadAdjustmentLock.Acquire();
						try
						{
							ThreadCounts threadCounts = threadPoolInstance._separated.counts;
							while (threadCounts.NumProcessingWork < threadPoolInstance._maxThreads && threadCounts.NumProcessingWork >= threadCounts.NumThreadsGoal)
							{
								if (booleanComPlusOrDotNetConfig2)
								{
									Debugger.Break();
								}
								ThreadCounts newCounts = threadCounts;
								short newThreadCount = (newCounts.NumThreadsGoal = (short)(threadCounts.NumProcessingWork + 1));
								ThreadCounts threadCounts2 = threadPoolInstance._separated.counts.InterlockedCompareExchange(newCounts, threadCounts);
								if (threadCounts2 == threadCounts)
								{
									HillClimbing.ThreadPoolHillClimber.ForceChange(newThreadCount, HillClimbing.StateOrTransition.Starvation);
									flag2 = true;
									break;
								}
								threadCounts = threadCounts2;
							}
						}
						finally
						{
							threadAdjustmentLock.Release();
						}
						if (flag2)
						{
							WorkerThread.MaybeAddWorkingWorker(threadPoolInstance);
						}
					}
					if (threadPoolInstance._separated.numRequestedWorkers <= 0 && threadPoolInstance._pendingBlockingAdjustment == PendingBlockingAdjustment.None && Interlocked.Decrement(ref threadPoolInstance._separated.gateThreadRunningState) <= GetRunningStateForNumRuns(0))
					{
						break;
					}
				}
			}
		}

		public static void Wake(PortableThreadPool threadPoolInstance)
		{
			DelayEvent.Set();
			EnsureRunning(threadPoolInstance);
		}

		private static bool SufficientDelaySinceLastDequeue(PortableThreadPool threadPoolInstance)
		{
			int num = Environment.TickCount - threadPoolInstance._separated.lastDequeueTime;
			uint num2 = ((threadPoolInstance._cpuUtilization >= 80) ? ((uint)(threadPoolInstance._separated.counts.NumThreadsGoal * 1000)) : 500u);
			return (uint)num > num2;
		}

		internal static void EnsureRunning(PortableThreadPool threadPoolInstance)
		{
			if (threadPoolInstance._separated.gateThreadRunningState != GetRunningStateForNumRuns(2))
			{
				EnsureRunningSlow(threadPoolInstance);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void EnsureRunningSlow(PortableThreadPool threadPoolInstance)
		{
			int num = Interlocked.Exchange(ref threadPoolInstance._separated.gateThreadRunningState, GetRunningStateForNumRuns(2));
			if (num == GetRunningStateForNumRuns(0))
			{
				RunGateThreadEvent.Set();
			}
			else if ((num & 4) == 0)
			{
				CreateGateThread();
			}
		}

		private static int GetRunningStateForNumRuns(int numRuns)
		{
			return 4 | numRuns;
		}

		private static void CreateGateThread()
		{
			try
			{
				Thread thread = new Thread(GateThreadStart, 262144);
				thread.IsThreadPoolThread = true;
				thread.IsBackground = true;
				thread.Name = ".NET TP Gate";
				thread.UnsafeStart();
			}
			catch (Exception exception)
			{
				Environment.FailFast("Failed to create the thread pool Gate thread.", exception);
			}
		}
	}

	private sealed class HillClimbing
	{
		public enum StateOrTransition
		{
			Warmup,
			Initializing,
			RandomMove,
			ClimbingMove,
			ChangePoint,
			Stabilizing,
			Starvation,
			ThreadTimedOut,
			CooperativeBlocking
		}

		private struct LogEntry
		{
			public int tickCount;

			public StateOrTransition stateOrTransition;

			public int newControlSetting;

			public int lastHistoryCount;

			public float lastHistoryMean;
		}

		private readonly struct Complex
		{
			public double Imaginary { get; }

			public double Real { get; }

			public Complex(double real, double imaginary)
			{
				Real = real;
				Imaginary = imaginary;
			}

			public static Complex operator *(double scalar, Complex complex)
			{
				return new Complex(scalar * complex.Real, scalar * complex.Imaginary);
			}

			public static Complex operator /(Complex complex, double scalar)
			{
				return new Complex(complex.Real / scalar, complex.Imaginary / scalar);
			}

			public static Complex operator -(Complex lhs, Complex rhs)
			{
				return new Complex(lhs.Real - rhs.Real, lhs.Imaginary - rhs.Imaginary);
			}

			public static Complex operator /(Complex lhs, Complex rhs)
			{
				double num = rhs.Real * rhs.Real + rhs.Imaginary * rhs.Imaginary;
				return new Complex((lhs.Real * rhs.Real + lhs.Imaginary * rhs.Imaginary) / num, ((0.0 - lhs.Real) * rhs.Imaginary + lhs.Imaginary * rhs.Real) / num);
			}

			public double Abs()
			{
				return Math.Sqrt(Real * Real + Imaginary * Imaginary);
			}
		}

		public static readonly bool IsDisabled = AppContextConfigHelper.GetBooleanComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.Disable", "HillClimbing_Disable", defaultValue: false);

		public static readonly HillClimbing ThreadPoolHillClimber = new HillClimbing();

		private readonly int _wavePeriod;

		private readonly int _samplesToMeasure;

		private readonly double _targetThroughputRatio;

		private readonly double _targetSignalToNoiseRatio;

		private readonly double _maxChangePerSecond;

		private readonly double _maxChangePerSample;

		private readonly int _maxThreadWaveMagnitude;

		private readonly int _sampleIntervalMsLow;

		private readonly double _threadMagnitudeMultiplier;

		private readonly int _sampleIntervalMsHigh;

		private readonly double _throughputErrorSmoothingFactor;

		private readonly double _gainExponent;

		private readonly double _maxSampleError;

		private double _currentControlSetting;

		private long _totalSamples;

		private int _lastThreadCount;

		private double _averageThroughputNoise;

		private double _secondsElapsedSinceLastChange;

		private double _completionsSinceLastChange;

		private int _accumulatedCompletionCount;

		private double _accumulatedSampleDurationSeconds;

		private readonly double[] _samples;

		private readonly double[] _threadCounts;

		private int _currentSampleMs;

		private readonly Random.XoshiroImpl _randomIntervalGenerator = new Random.XoshiroImpl();

		private readonly LogEntry[] _log = new LogEntry[200];

		private int _logStart;

		private int _logSize;

		public HillClimbing()
		{
			_wavePeriod = AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.WavePeriod", "HillClimbing_WavePeriod", 4, allowNegative: false);
			_maxThreadWaveMagnitude = AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.MaxWaveMagnitude", "HillClimbing_MaxWaveMagnitude", 20, allowNegative: false);
			_threadMagnitudeMultiplier = (double)AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.WaveMagnitudeMultiplier", "HillClimbing_WaveMagnitudeMultiplier", 100, allowNegative: false) / 100.0;
			_samplesToMeasure = _wavePeriod * AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.WaveHistorySize", "HillClimbing_WaveHistorySize", 8, allowNegative: false);
			_targetThroughputRatio = (double)AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.Bias", "HillClimbing_Bias", 15, allowNegative: false) / 100.0;
			_targetSignalToNoiseRatio = (double)AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.TargetSignalToNoiseRatio", "HillClimbing_TargetSignalToNoiseRatio", 300, allowNegative: false) / 100.0;
			_maxChangePerSecond = AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.MaxChangePerSecond", "HillClimbing_MaxChangePerSecond", 4, allowNegative: false);
			_maxChangePerSample = AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.MaxChangePerSample", "HillClimbing_MaxChangePerSample", 20, allowNegative: false);
			int int32ComPlusOrDotNetConfig = AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.SampleIntervalLow", "HillClimbing_SampleIntervalLow", 10, allowNegative: false);
			int int32ComPlusOrDotNetConfig2 = AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.SampleIntervalHigh", "HillClimbing_SampleIntervalHigh", 200, allowNegative: false);
			if (int32ComPlusOrDotNetConfig <= int32ComPlusOrDotNetConfig2)
			{
				_sampleIntervalMsLow = int32ComPlusOrDotNetConfig;
				_sampleIntervalMsHigh = int32ComPlusOrDotNetConfig2;
			}
			else
			{
				_sampleIntervalMsLow = 10;
				_sampleIntervalMsHigh = 200;
			}
			_throughputErrorSmoothingFactor = (double)AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.ErrorSmoothingFactor", "HillClimbing_ErrorSmoothingFactor", 1, allowNegative: false) / 100.0;
			_gainExponent = (double)AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.GainExponent", "HillClimbing_GainExponent", 200, allowNegative: false) / 100.0;
			_maxSampleError = (double)AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.HillClimbing.MaxSampleErrorPercent", "HillClimbing_MaxSampleErrorPercent", 15, allowNegative: false) / 100.0;
			_samples = new double[_samplesToMeasure];
			_threadCounts = new double[_samplesToMeasure];
			_currentSampleMs = _randomIntervalGenerator.Next(_sampleIntervalMsLow, _sampleIntervalMsHigh + 1);
		}

		public (int newThreadCount, int newSampleMs) Update(int currentThreadCount, double sampleDurationSeconds, int numCompletions)
		{
			if (currentThreadCount != _lastThreadCount)
			{
				ForceChange(currentThreadCount, StateOrTransition.Initializing);
			}
			_secondsElapsedSinceLastChange += sampleDurationSeconds;
			_completionsSinceLastChange += numCompletions;
			sampleDurationSeconds += _accumulatedSampleDurationSeconds;
			numCompletions += _accumulatedCompletionCount;
			if (_totalSamples > 0 && ((double)currentThreadCount - 1.0) / (double)numCompletions >= _maxSampleError)
			{
				_accumulatedSampleDurationSeconds = sampleDurationSeconds;
				_accumulatedCompletionCount = numCompletions;
				return (newThreadCount: currentThreadCount, newSampleMs: 10);
			}
			_accumulatedSampleDurationSeconds = 0.0;
			_accumulatedCompletionCount = 0;
			double num = (double)numCompletions / sampleDurationSeconds;
			if (NativeRuntimeEventSource.Log.IsEnabled())
			{
			}
			int num2 = (int)(_totalSamples % _samplesToMeasure);
			_samples[num2] = num;
			_threadCounts[num2] = currentThreadCount;
			_totalSamples++;
			Complex complex = default(Complex);
			Complex complex2 = default(Complex);
			double num3 = 0.0;
			Complex complex3 = default(Complex);
			double val = 0.0;
			StateOrTransition state = StateOrTransition.Warmup;
			int num4 = (int)Math.Min(_totalSamples - 1, _samplesToMeasure) / _wavePeriod * _wavePeriod;
			if (num4 > _wavePeriod)
			{
				double num5 = 0.0;
				double num6 = 0.0;
				for (int i = 0; i < num4; i++)
				{
					num5 += _samples[(_totalSamples - num4 + i) % _samplesToMeasure];
					num6 += _threadCounts[(_totalSamples - num4 + i) % _samplesToMeasure];
				}
				double num7 = num5 / (double)num4;
				double num8 = num6 / (double)num4;
				if (num7 > 0.0 && num8 > 0.0)
				{
					double period = (double)num4 / ((double)num4 / (double)_wavePeriod + 1.0);
					double num9 = (double)num4 / ((double)num4 / (double)_wavePeriod - 1.0);
					complex2 = GetWaveComponent(_samples, num4, _wavePeriod) / num7;
					num3 = (GetWaveComponent(_samples, num4, period) / num7).Abs();
					if (num9 <= (double)num4)
					{
						num3 = Math.Max(num3, (GetWaveComponent(_samples, num4, num9) / num7).Abs());
					}
					complex = GetWaveComponent(_threadCounts, num4, _wavePeriod) / num8;
					if (_averageThroughputNoise == 0.0)
					{
						_averageThroughputNoise = num3;
					}
					else
					{
						_averageThroughputNoise = _throughputErrorSmoothingFactor * num3 + (1.0 - _throughputErrorSmoothingFactor) * _averageThroughputNoise;
					}
					if (complex.Abs() > 0.0)
					{
						complex3 = (complex2 - _targetThroughputRatio * complex) / complex;
						state = StateOrTransition.ClimbingMove;
					}
					else
					{
						complex3 = new Complex(0.0, 0.0);
						state = StateOrTransition.Stabilizing;
					}
					double num10 = Math.Max(_averageThroughputNoise, num3);
					val = ((!(num10 > 0.0)) ? 1.0 : (complex.Abs() / num10 / _targetSignalToNoiseRatio));
				}
			}
			double num11 = Math.Min(1.0, Math.Max(-1.0, complex3.Real));
			num11 *= Math.Min(1.0, Math.Max(0.0, val));
			double num12 = _maxChangePerSecond * sampleDurationSeconds;
			num11 = Math.Pow(Math.Abs(num11), _gainExponent) * (double)((num11 >= 0.0) ? 1 : (-1)) * num12;
			num11 = Math.Min(num11, _maxChangePerSample);
			PortableThreadPool threadPoolInstance = ThreadPoolInstance;
			if (num11 > 0.0 && threadPoolInstance._cpuUtilization > 95)
			{
				num11 = 0.0;
			}
			_currentControlSetting += num11;
			int val2 = (int)(0.5 + _currentControlSetting * _averageThroughputNoise * _targetSignalToNoiseRatio * _threadMagnitudeMultiplier * 2.0);
			val2 = Math.Min(val2, _maxThreadWaveMagnitude);
			val2 = Math.Max(val2, 1);
			int maxThreads = threadPoolInstance._maxThreads;
			int minThreadsGoal = threadPoolInstance.MinThreadsGoal;
			_currentControlSetting = Math.Min(maxThreads - val2, _currentControlSetting);
			_currentControlSetting = Math.Max(minThreadsGoal, _currentControlSetting);
			int val3 = (int)(_currentControlSetting + (double)(val2 * (_totalSamples / (_wavePeriod / 2) % 2)));
			val3 = Math.Min(maxThreads, val3);
			val3 = Math.Max(minThreadsGoal, val3);
			if (NativeRuntimeEventSource.Log.IsEnabled())
			{
			}
			if (val3 != currentThreadCount)
			{
				ChangeThreadCount(val3, state);
				_secondsElapsedSinceLastChange = 0.0;
				_completionsSinceLastChange = 0.0;
			}
			int item = ((!(complex3.Real < 0.0) || val3 != minThreadsGoal) ? _currentSampleMs : ((int)(0.5 + (double)_currentSampleMs * (10.0 * Math.Min(0.0 - complex3.Real, 1.0)))));
			return (newThreadCount: val3, newSampleMs: item);
		}

		private void ChangeThreadCount(int newThreadCount, StateOrTransition state)
		{
			_lastThreadCount = newThreadCount;
			if (state != StateOrTransition.CooperativeBlocking)
			{
				_currentSampleMs = _randomIntervalGenerator.Next(_sampleIntervalMsLow, _sampleIntervalMsHigh + 1);
			}
			double throughput = ((_secondsElapsedSinceLastChange > 0.0) ? (_completionsSinceLastChange / _secondsElapsedSinceLastChange) : 0.0);
			LogTransition(newThreadCount, throughput, state);
		}

		private void LogTransition(int newThreadCount, double throughput, StateOrTransition stateOrTransition)
		{
			int num = (_logStart + _logSize) % 200;
			if (_logSize == 200)
			{
				_logStart = (_logStart + 1) % 200;
				_logSize--;
			}
			ref LogEntry reference = ref _log[num];
			reference.tickCount = Environment.TickCount;
			reference.stateOrTransition = stateOrTransition;
			reference.newControlSetting = newThreadCount;
			reference.lastHistoryCount = (int)(Math.Min(_totalSamples, _samplesToMeasure) / _wavePeriod) * _wavePeriod;
			reference.lastHistoryMean = (float)throughput;
			_logSize++;
			if (!NativeRuntimeEventSource.Log.IsEnabled())
			{
			}
		}

		public void ForceChange(int newThreadCount, StateOrTransition state)
		{
			if (_lastThreadCount != newThreadCount)
			{
				_currentControlSetting += newThreadCount - _lastThreadCount;
				ChangeThreadCount(newThreadCount, state);
			}
		}

		private Complex GetWaveComponent(double[] samples, int numSamples, double period)
		{
			double num = Math.PI * 2.0 / period;
			double num2 = Math.Cos(num);
			double num3 = 2.0 * num2;
			double num4 = 0.0;
			double num5 = 0.0;
			for (int i = 0; i < numSamples; i++)
			{
				double num6 = num3 * num4 - num5 + samples[(_totalSamples - numSamples + i) % _samplesToMeasure];
				num5 = num4;
				num4 = num6;
			}
			return new Complex(num4 - num5 * num2, num5 * Math.Sin(num)) / numSamples;
		}
	}

	private struct ThreadCounts : IEquatable<ThreadCounts>
	{
		private ulong _data;

		public short NumProcessingWork
		{
			get
			{
				return GetInt16Value(0);
			}
			set
			{
				SetInt16Value(Math.Max((short)0, value), 0);
			}
		}

		public short NumExistingThreads
		{
			get
			{
				return GetInt16Value(16);
			}
			set
			{
				SetInt16Value(Math.Max((short)0, value), 16);
			}
		}

		public short NumThreadsGoal
		{
			get
			{
				return GetInt16Value(32);
			}
			set
			{
				SetInt16Value(Math.Max((short)1, value), 32);
			}
		}

		private ThreadCounts(ulong data)
		{
			_data = data;
		}

		private short GetInt16Value(byte shift)
		{
			return (short)(_data >> (int)shift);
		}

		private void SetInt16Value(short value, byte shift)
		{
			_data = (_data & (ulong)(~(65535L << (int)shift))) | ((ulong)(ushort)value << (int)shift);
		}

		public ThreadCounts InterlockedSetNumThreadsGoal(short value)
		{
			ThreadCounts threadCounts = this;
			ThreadCounts threadCounts2;
			while (true)
			{
				threadCounts2 = threadCounts;
				threadCounts2.NumThreadsGoal = value;
				ThreadCounts threadCounts3 = InterlockedCompareExchange(threadCounts2, threadCounts);
				if (threadCounts3 == threadCounts)
				{
					break;
				}
				threadCounts = threadCounts3;
			}
			return threadCounts2;
		}

		public ThreadCounts VolatileRead()
		{
			return new ThreadCounts(Volatile.Read(in _data));
		}

		public ThreadCounts InterlockedCompareExchange(ThreadCounts newCounts, ThreadCounts oldCounts)
		{
			return new ThreadCounts(Interlocked.CompareExchange(ref _data, newCounts._data, oldCounts._data));
		}

		public static bool operator ==(ThreadCounts lhs, ThreadCounts rhs)
		{
			return lhs._data == rhs._data;
		}

		public override bool Equals([NotNullWhen(true)] object obj)
		{
			if (obj is ThreadCounts other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(ThreadCounts other)
		{
			return _data == other._data;
		}

		public override int GetHashCode()
		{
			return (int)_data + (int)(_data >> 32);
		}
	}

	private sealed class WaitThreadNode
	{
		public WaitThread Thread { get; }

		public WaitThreadNode Next { get; set; }

		public WaitThreadNode(WaitThread thread)
		{
			Thread = thread;
		}
	}

	internal sealed class WaitThread
	{
		private readonly RegisteredWaitHandle[] _registeredWaits = new RegisteredWaitHandle[63];

		private readonly SafeWaitHandle[] _waitHandles = new SafeWaitHandle[64];

		private int _numUserWaits;

		private readonly RegisteredWaitHandle[] _pendingRemoves = new RegisteredWaitHandle[63];

		private int _numPendingRemoves;

		private readonly AutoResetEvent _changeHandlesEvent = new AutoResetEvent(initialState: false);

		internal bool AnyUserWaits => _numUserWaits != 0;

		public WaitThread()
		{
			_waitHandles[0] = _changeHandlesEvent.SafeWaitHandle;
			Thread thread = new Thread(WaitThreadStart, 262144);
			thread.IsThreadPoolThread = true;
			thread.IsBackground = true;
			thread.Name = ".NET TP Wait";
			thread.UnsafeStart();
		}

		private void WaitThreadStart()
		{
			while (true)
			{
				int num = ProcessRemovals();
				int tickCount = Environment.TickCount;
				int num2 = -1;
				if (num == 0)
				{
					num2 = ThreadPoolThreadTimeoutMs;
				}
				else
				{
					for (int i = 0; i < num; i++)
					{
						RegisteredWaitHandle registeredWaitHandle = _registeredWaits[i];
						if (!registeredWaitHandle.IsInfiniteTimeout)
						{
							int num3 = Math.Max(0, registeredWaitHandle.TimeoutTimeMs - tickCount);
							num2 = ((num2 != -1) ? Math.Min(num3, num2) : num3);
							if (num2 == 0)
							{
								break;
							}
						}
					}
				}
				int num4 = WaitHandle.WaitAny(new ReadOnlySpan<SafeWaitHandle>(_waitHandles, 0, num + 1), num2);
				if (num4 >= 128 && num4 < 129 + num)
				{
					num4 += -128;
				}
				switch (num4)
				{
				case 0:
					break;
				default:
				{
					RegisteredWaitHandle registeredHandle = _registeredWaits[num4 - 1];
					QueueWaitCompletion(registeredHandle, timedOut: false);
					break;
				}
				case 258:
				{
					if (num == 0 && ThreadPoolInstance.TryRemoveWaitThread(this))
					{
						return;
					}
					tickCount = Environment.TickCount;
					for (int j = 0; j < num; j++)
					{
						RegisteredWaitHandle registeredWaitHandle2 = _registeredWaits[j];
						if (!registeredWaitHandle2.IsInfiniteTimeout && tickCount - registeredWaitHandle2.TimeoutTimeMs >= 0)
						{
							QueueWaitCompletion(registeredWaitHandle2, timedOut: true);
						}
					}
					break;
				}
				}
			}
		}

		private int ProcessRemovals()
		{
			PortableThreadPool threadPoolInstance = ThreadPoolInstance;
			threadPoolInstance._waitThreadLock.Acquire();
			try
			{
				if (_numPendingRemoves == 0 || _numUserWaits == 0)
				{
					return _numUserWaits;
				}
				_ = _numUserWaits;
				_ = _numPendingRemoves;
				for (int i = 0; i < _numPendingRemoves; i++)
				{
					RegisteredWaitHandle registeredWaitHandle = _pendingRemoves[i];
					int numUserWaits = _numUserWaits;
					int j;
					for (j = 0; j < numUserWaits && registeredWaitHandle != _registeredWaits[j]; j++)
					{
					}
					registeredWaitHandle.OnRemoveWait();
					if (j + 1 < numUserWaits)
					{
						int num = j;
						int num2 = numUserWaits;
						Array.Copy(_registeredWaits, num + 1, _registeredWaits, num, num2 - (num + 1));
						_registeredWaits[num2 - 1] = null;
						num++;
						num2++;
						Array.Copy(_waitHandles, num + 1, _waitHandles, num, num2 - (num + 1));
						_waitHandles[num2 - 1] = null;
					}
					else
					{
						_registeredWaits[j] = null;
						_waitHandles[j + 1] = null;
					}
					_numUserWaits = numUserWaits - 1;
					_pendingRemoves[i] = null;
					registeredWaitHandle.Handle.DangerousRelease();
				}
				_numPendingRemoves = 0;
				return _numUserWaits;
			}
			finally
			{
				threadPoolInstance._waitThreadLock.Release();
			}
		}

		private void QueueWaitCompletion(RegisteredWaitHandle registeredHandle, bool timedOut)
		{
			registeredHandle.RequestCallback();
			if (registeredHandle.Repeating)
			{
				if (!registeredHandle.IsInfiniteTimeout)
				{
					registeredHandle.RestartTimeout();
				}
			}
			else
			{
				UnregisterWait(registeredHandle, blocking: false);
			}
			ThreadPool.UnsafeQueueHighPriorityWorkItemInternal(new CompleteWaitThreadPoolWorkItem(registeredHandle, timedOut));
		}

		public bool RegisterWaitHandle(RegisteredWaitHandle handle)
		{
			if (_numUserWaits == 63)
			{
				return false;
			}
			bool success = false;
			handle.Handle.DangerousAddRef(ref success);
			_registeredWaits[_numUserWaits] = handle;
			_waitHandles[_numUserWaits + 1] = handle.Handle;
			_numUserWaits++;
			handle.WaitThread = this;
			_changeHandlesEvent.Set();
			return true;
		}

		public void UnregisterWait(RegisteredWaitHandle handle)
		{
			UnregisterWait(handle, blocking: true);
		}

		private void UnregisterWait(RegisteredWaitHandle handle, bool blocking)
		{
			bool flag = false;
			PortableThreadPool threadPoolInstance = ThreadPoolInstance;
			threadPoolInstance._waitThreadLock.Acquire();
			try
			{
				if (Array.IndexOf(_registeredWaits, handle) >= 0)
				{
					if (Array.IndexOf(_pendingRemoves, handle) < 0)
					{
						_pendingRemoves[_numPendingRemoves++] = handle;
						_changeHandlesEvent.Set();
					}
					flag = true;
				}
			}
			finally
			{
				threadPoolInstance._waitThreadLock.Release();
			}
			if (blocking)
			{
				if (handle.IsBlocking)
				{
					handle.WaitForCallbacks();
				}
				else if (flag)
				{
					handle.WaitForRemoval();
				}
			}
		}
	}

	private static class WorkerThread
	{
		private static readonly short ThreadsToKeepAlive = DetermineThreadsToKeepAlive();

		private static readonly LowLevelLifoSemaphore s_semaphore = new LowLevelLifoSemaphore(0, 32767, AppContextConfigHelper.GetInt32ComPlusOrDotNetConfig("System.Threading.ThreadPool.UnfairSemaphoreSpinLimit", "ThreadPool_UnfairSemaphoreSpinLimit", 70, allowNegative: false), delegate
		{
			if (!NativeRuntimeEventSource.Log.IsEnabled())
			{
			}
		});

		private static readonly ThreadStart s_workerThreadStart = WorkerThreadStart;

		private static short DetermineThreadsToKeepAlive()
		{
			short int16Config = AppContextConfigHelper.GetInt16Config("System.Threading.ThreadPool.ThreadsToKeepAlive", "DOTNET_ThreadPool_ThreadsToKeepAlive", 0);
			if (int16Config < -1)
			{
				return 0;
			}
			return int16Config;
		}

		private static void CreateWorkerThread()
		{
			Thread thread = new Thread(s_workerThreadStart);
			thread.IsThreadPoolThread = true;
			thread.IsBackground = true;
			thread.SetThreadPoolWorkerThreadName();
			thread.UnsafeStart();
		}

		private static void WorkerThreadStart()
		{
			PortableThreadPool threadPoolInstance = ThreadPoolInstance;
			if (NativeRuntimeEventSource.Log.IsEnabled())
			{
			}
			LowLevelLock threadAdjustmentLock = threadPoolInstance._threadAdjustmentLock;
			LowLevelLifoSemaphore lowLevelLifoSemaphore = s_semaphore;
			int timeoutMs = ThreadPoolThreadTimeoutMs;
			if (ThreadsToKeepAlive != 0)
			{
				if (ThreadsToKeepAlive < 0)
				{
					timeoutMs = -1;
				}
				else
				{
					int num = threadPoolInstance._numThreadsBeingKeptAlive;
					while (num < ThreadsToKeepAlive)
					{
						int num2 = Interlocked.CompareExchange(ref threadPoolInstance._numThreadsBeingKeptAlive, num + 1, num);
						if (num2 == num)
						{
							timeoutMs = -1;
							break;
						}
						num = num2;
					}
				}
			}
			do
			{
				bool spinWait = true;
				while (lowLevelLifoSemaphore.Wait(timeoutMs, spinWait))
				{
					WorkerDoWork(threadPoolInstance, ref spinWait);
				}
			}
			while (!ShouldExitWorker(threadPoolInstance, threadAdjustmentLock));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void WorkerDoWork(PortableThreadPool threadPoolInstance, ref bool spinWait)
		{
			bool flag = false;
			while (TakeActiveRequest(threadPoolInstance))
			{
				threadPoolInstance._separated.lastDequeueTime = Environment.TickCount;
				if (!ThreadPoolWorkQueue.Dispatch())
				{
					flag = true;
					break;
				}
				if (threadPoolInstance._separated.numRequestedWorkers <= 0)
				{
					break;
				}
				Thread.UninterruptibleSleep0();
				if (!Environment.IsSingleProcessor)
				{
					Thread.SpinWait(1);
				}
			}
			spinWait = !flag;
			if (!flag)
			{
				RemoveWorkingWorker(threadPoolInstance);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool ShouldExitWorker(PortableThreadPool threadPoolInstance, LowLevelLock threadAdjustmentLock)
		{
			if (false)
			{
			}
			threadAdjustmentLock.Acquire();
			try
			{
				ThreadCounts threadCounts = threadPoolInstance._separated.counts;
				short newThreadCount;
				while (true)
				{
					if (threadCounts.NumExistingThreads <= threadCounts.NumProcessingWork)
					{
						return false;
					}
					ThreadCounts newCounts = threadCounts;
					short val = --newCounts.NumExistingThreads;
					newThreadCount = (newCounts.NumThreadsGoal = Math.Max(threadPoolInstance.MinThreadsGoal, Math.Min(val, threadCounts.NumThreadsGoal)));
					ThreadCounts threadCounts2 = threadPoolInstance._separated.counts.InterlockedCompareExchange(newCounts, threadCounts);
					if (threadCounts2 == threadCounts)
					{
						break;
					}
					threadCounts = threadCounts2;
				}
				HillClimbing.ThreadPoolHillClimber.ForceChange(newThreadCount, HillClimbing.StateOrTransition.ThreadTimedOut);
				if (NativeRuntimeEventSource.Log.IsEnabled())
				{
				}
				return true;
			}
			finally
			{
				threadAdjustmentLock.Release();
			}
		}

		private static void RemoveWorkingWorker(PortableThreadPool threadPoolInstance)
		{
			ThreadCounts threadCounts = threadPoolInstance._separated.counts;
			while (true)
			{
				ThreadCounts newCounts = threadCounts;
				newCounts.NumProcessingWork--;
				ThreadCounts threadCounts2 = threadPoolInstance._separated.counts.InterlockedCompareExchange(newCounts, threadCounts);
				if (threadCounts2 == threadCounts)
				{
					break;
				}
				threadCounts = threadCounts2;
			}
			if (threadPoolInstance._separated.numRequestedWorkers > 0)
			{
				MaybeAddWorkingWorker(threadPoolInstance);
			}
		}

		internal static void MaybeAddWorkingWorker(PortableThreadPool threadPoolInstance)
		{
			ThreadCounts threadCounts = threadPoolInstance._separated.counts;
			short numProcessingWork;
			short num;
			short numExistingThreads;
			short num2;
			while (true)
			{
				numProcessingWork = threadCounts.NumProcessingWork;
				if (numProcessingWork >= threadCounts.NumThreadsGoal)
				{
					return;
				}
				num = (short)(numProcessingWork + 1);
				numExistingThreads = threadCounts.NumExistingThreads;
				num2 = Math.Max(numExistingThreads, num);
				ThreadCounts newCounts = threadCounts;
				newCounts.NumProcessingWork = num;
				newCounts.NumExistingThreads = num2;
				ThreadCounts threadCounts2 = threadPoolInstance._separated.counts.InterlockedCompareExchange(newCounts, threadCounts);
				if (threadCounts2 == threadCounts)
				{
					break;
				}
				threadCounts = threadCounts2;
			}
			int num3 = num2 - numExistingThreads;
			int num4 = num - numProcessingWork;
			if (num4 > 0)
			{
				s_semaphore.Release(num4);
			}
			while (num3 > 0)
			{
				CreateWorkerThread();
				num3--;
			}
		}

		internal static bool ShouldStopProcessingWorkNow(PortableThreadPool threadPoolInstance)
		{
			ThreadCounts threadCounts = threadPoolInstance._separated.counts;
			while (true)
			{
				if (threadCounts.NumProcessingWork <= threadCounts.NumThreadsGoal)
				{
					return false;
				}
				ThreadCounts newCounts = threadCounts;
				newCounts.NumProcessingWork--;
				ThreadCounts threadCounts2 = threadPoolInstance._separated.counts.InterlockedCompareExchange(newCounts, threadCounts);
				if (threadCounts2 == threadCounts)
				{
					break;
				}
				threadCounts = threadCounts2;
			}
			return true;
		}

		private static bool TakeActiveRequest(PortableThreadPool threadPoolInstance)
		{
			int num = threadPoolInstance._separated.numRequestedWorkers;
			while (num > 0)
			{
				int num2 = Interlocked.CompareExchange(ref threadPoolInstance._separated.numRequestedWorkers, num - 1, num);
				if (num2 == num)
				{
					return true;
				}
				num = num2;
			}
			return false;
		}
	}

	private struct CountsOfThreadsProcessingUserCallbacks : IEquatable<CountsOfThreadsProcessingUserCallbacks>
	{
		private uint _data;

		public short Current => GetInt16Value(0);

		public short HighWatermark => GetInt16Value(16);

		private CountsOfThreadsProcessingUserCallbacks(uint data)
		{
			_data = data;
		}

		private short GetInt16Value(byte shift)
		{
			return (short)(_data >> (int)shift);
		}

		private void SetInt16Value(short value, byte shift)
		{
			_data = (_data & (uint)(~(65535 << (int)shift))) | (uint)((ushort)value << (int)shift);
		}

		public void IncrementCurrent()
		{
			if (Current < HighWatermark)
			{
				_data++;
			}
			else
			{
				_data += 65537u;
			}
		}

		public void DecrementCurrent()
		{
			_data--;
		}

		public void ResetHighWatermark()
		{
			SetInt16Value(Current, 16);
		}

		public CountsOfThreadsProcessingUserCallbacks InterlockedCompareExchange(CountsOfThreadsProcessingUserCallbacks newCounts, CountsOfThreadsProcessingUserCallbacks oldCounts)
		{
			return new CountsOfThreadsProcessingUserCallbacks(Interlocked.CompareExchange(ref _data, newCounts._data, oldCounts._data));
		}

		public static bool operator ==(CountsOfThreadsProcessingUserCallbacks lhs, CountsOfThreadsProcessingUserCallbacks rhs)
		{
			return lhs.Equals(rhs);
		}

		public override bool Equals([NotNullWhen(true)] object obj)
		{
			if (obj is CountsOfThreadsProcessingUserCallbacks other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(CountsOfThreadsProcessingUserCallbacks other)
		{
			return _data == other._data;
		}

		public override int GetHashCode()
		{
			return (int)_data;
		}
	}

	private struct CpuUtilizationReader
	{
		private Interop.Sys.ProcessCpuInformation _cpuInfo;

		public double CurrentUtilization => Interop.Sys.GetCpuUtilization(ref _cpuInfo) / (double)Environment.ProcessorCount;
	}

	private static readonly short ForcedMinWorkerThreads = AppContextConfigHelper.GetInt16ComPlusOrDotNetConfig("System.Threading.ThreadPool.MinThreads", "ThreadPool_ForceMinWorkerThreads", 0, allowNegative: false);

	private static readonly short ForcedMaxWorkerThreads = AppContextConfigHelper.GetInt16ComPlusOrDotNetConfig("System.Threading.ThreadPool.MaxThreads", "ThreadPool_ForceMaxWorkerThreads", 0, allowNegative: false);

	private static readonly int ThreadPoolThreadTimeoutMs = DetermineThreadPoolThreadTimeoutMs();

	[ThreadStatic]
	private static object t_completionCountObject;

	public static readonly PortableThreadPool ThreadPoolInstance = new PortableThreadPool();

	private int _cpuUtilization;

	private short _minThreads;

	private short _maxThreads;

	private short _legacy_minIOCompletionThreads;

	private short _legacy_maxIOCompletionThreads;

	private int _numThreadsBeingKeptAlive;

	private long _currentSampleStartTime;

	private readonly ThreadInt64PersistentCounter _completionCounter = new ThreadInt64PersistentCounter();

	private int _threadAdjustmentIntervalMs;

	private short _numBlockedThreads;

	private short _numThreadsAddedDueToBlocking;

	private PendingBlockingAdjustment _pendingBlockingAdjustment;

	private long _memoryUsageBytes;

	private long _memoryLimitBytes;

	private readonly LowLevelLock _threadAdjustmentLock = new LowLevelLock();

	private CacheLineSeparated _separated;

	private WaitThreadNode _waitThreadsHead;

	private readonly LowLevelLock _waitThreadLock = new LowLevelLock();

	private CountsOfThreadsProcessingUserCallbacks _countsOfThreadsProcessingUserCallbacks;

	private static bool HasForcedMinThreads
	{
		get
		{
			if (ForcedMinWorkerThreads > 0)
			{
				if (ForcedMaxWorkerThreads > 0)
				{
					return ForcedMinWorkerThreads <= ForcedMaxWorkerThreads;
				}
				return true;
			}
			return false;
		}
	}

	private static bool HasForcedMaxThreads
	{
		get
		{
			if (ForcedMaxWorkerThreads > 0)
			{
				if (ForcedMinWorkerThreads > 0)
				{
					return ForcedMinWorkerThreads <= ForcedMaxWorkerThreads;
				}
				return true;
			}
			return false;
		}
	}

	public int ThreadCount => _separated.counts.VolatileRead().NumExistingThreads;

	public long CompletedWorkItemCount => _completionCounter.Count;

	public short MinThreadsGoal => Math.Min(_separated.counts.NumThreadsGoal, TargetThreadsGoalForBlockingAdjustment);

	private short TargetThreadsGoalForBlockingAdjustment
	{
		get
		{
			if (_numBlockedThreads > 0)
			{
				return (short)Math.Min((ushort)(_minThreads + _numBlockedThreads), (ushort)_maxThreads);
			}
			return _minThreads;
		}
	}

	private static int DetermineThreadPoolThreadTimeoutMs()
	{
		int int32Config = AppContextConfigHelper.GetInt32Config("System.Threading.ThreadPool.ThreadTimeoutMs", "DOTNET_ThreadPool_ThreadTimeoutMs", 20000);
		if (int32Config < -1)
		{
			return 20000;
		}
		return int32Config;
	}

	private PortableThreadPool()
	{
		_minThreads = (HasForcedMinThreads ? ForcedMinWorkerThreads : ((short)Environment.ProcessorCount));
		if (_minThreads > short.MaxValue)
		{
			_minThreads = short.MaxValue;
		}
		_maxThreads = (HasForcedMaxThreads ? ForcedMaxWorkerThreads : short.MaxValue);
		if (_maxThreads > short.MaxValue)
		{
			_maxThreads = short.MaxValue;
		}
		else if (_maxThreads < _minThreads)
		{
			_maxThreads = _minThreads;
		}
		_legacy_minIOCompletionThreads = 1;
		_legacy_maxIOCompletionThreads = 1000;
		if (NativeRuntimeEventSource.Log.IsEnabled())
		{
		}
		_separated.counts.NumThreadsGoal = _minThreads;
	}

	public bool SetMinThreads(int workerThreads, int ioCompletionThreads)
	{
		if (workerThreads < 0 || ioCompletionThreads < 0)
		{
			return false;
		}
		bool flag = false;
		bool flag2 = false;
		_threadAdjustmentLock.Acquire();
		try
		{
			if (workerThreads > _maxThreads)
			{
				return false;
			}
			if (ioCompletionThreads > _legacy_maxIOCompletionThreads)
			{
				return false;
			}
			if (HasForcedMinThreads && workerThreads != ForcedMinWorkerThreads)
			{
				return false;
			}
			_legacy_minIOCompletionThreads = (short)Math.Max(1, ioCompletionThreads);
			short num = (short)Math.Max(1, workerThreads);
			if (num == _minThreads)
			{
				return true;
			}
			_minThreads = num;
			if (_numBlockedThreads > 0)
			{
				if (_pendingBlockingAdjustment != PendingBlockingAdjustment.Immediately)
				{
					_pendingBlockingAdjustment = PendingBlockingAdjustment.Immediately;
					flag2 = true;
				}
			}
			else if (_separated.counts.NumThreadsGoal < num)
			{
				_separated.counts.InterlockedSetNumThreadsGoal(num);
				if (_separated.numRequestedWorkers > 0)
				{
					flag = true;
				}
			}
			if (!NativeRuntimeEventSource.Log.IsEnabled())
			{
			}
		}
		finally
		{
			_threadAdjustmentLock.Release();
		}
		if (flag)
		{
			WorkerThread.MaybeAddWorkingWorker(this);
		}
		else if (flag2)
		{
			GateThread.Wake(this);
		}
		return true;
	}

	public void GetMinThreads(out int workerThreads, out int ioCompletionThreads)
	{
		workerThreads = Volatile.Read(in _minThreads);
		ioCompletionThreads = _legacy_minIOCompletionThreads;
	}

	public bool SetMaxThreads(int workerThreads, int ioCompletionThreads)
	{
		if (workerThreads <= 0 || ioCompletionThreads <= 0)
		{
			return false;
		}
		_threadAdjustmentLock.Acquire();
		try
		{
			if (workerThreads < _minThreads)
			{
				return false;
			}
			if (ioCompletionThreads < _legacy_minIOCompletionThreads)
			{
				return false;
			}
			if (HasForcedMaxThreads && workerThreads != ForcedMaxWorkerThreads)
			{
				return false;
			}
			_legacy_maxIOCompletionThreads = (short)Math.Min(ioCompletionThreads, 32767);
			short num = (short)Math.Min(workerThreads, 32767);
			if (num == _maxThreads)
			{
				return true;
			}
			_maxThreads = num;
			if (_separated.counts.NumThreadsGoal > num)
			{
				_separated.counts.InterlockedSetNumThreadsGoal(num);
			}
			if (NativeRuntimeEventSource.Log.IsEnabled())
			{
			}
			return true;
		}
		finally
		{
			_threadAdjustmentLock.Release();
		}
	}

	public void GetMaxThreads(out int workerThreads, out int ioCompletionThreads)
	{
		workerThreads = Volatile.Read(in _maxThreads);
		ioCompletionThreads = _legacy_maxIOCompletionThreads;
	}

	public void GetAvailableThreads(out int workerThreads, out int ioCompletionThreads)
	{
		ThreadCounts threadCounts = _separated.counts.VolatileRead();
		workerThreads = Math.Max(0, _maxThreads - threadCounts.NumProcessingWork);
		ioCompletionThreads = _legacy_maxIOCompletionThreads;
	}

	public object GetOrCreateThreadLocalCompletionCountObject()
	{
		return t_completionCountObject ?? CreateThreadLocalCompletionCountObject();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private object CreateThreadLocalCompletionCountObject()
	{
		return t_completionCountObject = _completionCounter.CreateThreadLocalCountObject();
	}

	private void NotifyWorkItemProgress(object threadLocalCompletionCountObject, int currentTimeMs)
	{
		ThreadInt64PersistentCounter.Increment(threadLocalCompletionCountObject);
		_separated.lastDequeueTime = currentTimeMs;
		if (ShouldAdjustMaxWorkersActive(currentTimeMs))
		{
			AdjustMaxWorkersActive();
		}
	}

	internal void NotifyWorkItemProgress()
	{
		NotifyWorkItemProgress(GetOrCreateThreadLocalCompletionCountObject(), Environment.TickCount);
	}

	internal bool NotifyWorkItemComplete(object threadLocalCompletionCountObject, int currentTimeMs)
	{
		NotifyWorkItemProgress(threadLocalCompletionCountObject, currentTimeMs);
		return !WorkerThread.ShouldStopProcessingWorkNow(this);
	}

	private void AdjustMaxWorkersActive()
	{
		LowLevelLock threadAdjustmentLock = _threadAdjustmentLock;
		if (!threadAdjustmentLock.TryAcquire())
		{
			return;
		}
		bool flag = false;
		try
		{
			ThreadCounts counts = _separated.counts;
			if (counts.NumProcessingWork > counts.NumThreadsGoal || _pendingBlockingAdjustment != PendingBlockingAdjustment.None)
			{
				return;
			}
			long timestamp = Stopwatch.GetTimestamp();
			double totalSeconds = Stopwatch.GetElapsedTime(_currentSampleStartTime, timestamp).TotalSeconds;
			if (totalSeconds * 1000.0 >= (double)(_threadAdjustmentIntervalMs / 2))
			{
				int tickCount = Environment.TickCount;
				int num = (int)_completionCounter.Count;
				int numCompletions = num - _separated.priorCompletionCount;
				short numThreadsGoal = counts.NumThreadsGoal;
				int num2;
				(num2, _threadAdjustmentIntervalMs) = HillClimbing.ThreadPoolHillClimber.Update(numThreadsGoal, totalSeconds, numCompletions);
				if (numThreadsGoal != (short)num2)
				{
					_separated.counts.InterlockedSetNumThreadsGoal((short)num2);
					if (num2 > numThreadsGoal)
					{
						flag = true;
					}
				}
				_separated.priorCompletionCount = num;
				_separated.nextCompletedWorkRequestsTime = tickCount + _threadAdjustmentIntervalMs;
				Volatile.Write(ref _separated.priorCompletedWorkRequestsTime, tickCount);
				_currentSampleStartTime = timestamp;
			}
		}
		finally
		{
			threadAdjustmentLock.Release();
		}
		if (flag)
		{
			WorkerThread.MaybeAddWorkingWorker(this);
		}
	}

	private bool ShouldAdjustMaxWorkersActive(int currentTimeMs)
	{
		if (HillClimbing.IsDisabled)
		{
			return false;
		}
		int num = Volatile.Read(in _separated.priorCompletedWorkRequestsTime);
		uint num2 = (uint)(_separated.nextCompletedWorkRequestsTime - num);
		if ((uint)(currentTimeMs - num) < num2)
		{
			return false;
		}
		ThreadCounts counts = _separated.counts;
		if (counts.NumProcessingWork > counts.NumThreadsGoal)
		{
			return false;
		}
		return _pendingBlockingAdjustment == PendingBlockingAdjustment.None;
	}

	internal void RequestWorker()
	{
		Interlocked.Increment(ref _separated.numRequestedWorkers);
		WorkerThread.MaybeAddWorkingWorker(this);
		GateThread.EnsureRunning(this);
	}

	private bool OnGen2GCCallback()
	{
		GCMemoryInfo gCMemoryInfo = GC.GetGCMemoryInfo();
		_memoryLimitBytes = gCMemoryInfo.HighMemoryLoadThresholdBytes;
		_memoryUsageBytes = Math.Min(gCMemoryInfo.MemoryLoadBytes, gCMemoryInfo.HighMemoryLoadThresholdBytes);
		return true;
	}

	internal static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce, bool flowExecutionContext)
	{
		ArgumentNullException.ThrowIfNull(waitObject, "waitObject");
		ArgumentNullException.ThrowIfNull(callBack, "callBack");
		RegisteredWaitHandle registeredWaitHandle = new RegisteredWaitHandle(waitObject, new _ThreadPoolWaitOrTimerCallback(callBack, state, flowExecutionContext), (int)millisecondsTimeOutInterval, !executeOnlyOnce);
		ThreadPoolInstance.RegisterWaitHandle(registeredWaitHandle);
		return registeredWaitHandle;
	}

	public bool NotifyThreadBlocked()
	{
		if (!BlockingConfig.IsCooperativeBlockingEnabled || !Thread.CurrentThread.IsThreadPoolThread)
		{
			return false;
		}
		bool flag = false;
		_threadAdjustmentLock.Acquire();
		try
		{
			_numBlockedThreads++;
			if (_pendingBlockingAdjustment != PendingBlockingAdjustment.WithDelayIfNecessary && _separated.counts.NumThreadsGoal < TargetThreadsGoalForBlockingAdjustment)
			{
				if (_pendingBlockingAdjustment == PendingBlockingAdjustment.None)
				{
					flag = true;
				}
				_pendingBlockingAdjustment = PendingBlockingAdjustment.WithDelayIfNecessary;
			}
		}
		finally
		{
			_threadAdjustmentLock.Release();
		}
		if (flag)
		{
			GateThread.Wake(this);
		}
		return true;
	}

	public void NotifyThreadUnblocked()
	{
		bool flag = false;
		_threadAdjustmentLock.Acquire();
		try
		{
			_numBlockedThreads--;
			if (_pendingBlockingAdjustment != PendingBlockingAdjustment.Immediately && _numThreadsAddedDueToBlocking > 0 && _separated.counts.NumThreadsGoal > TargetThreadsGoalForBlockingAdjustment)
			{
				flag = true;
				_pendingBlockingAdjustment = PendingBlockingAdjustment.Immediately;
			}
		}
		finally
		{
			_threadAdjustmentLock.Release();
		}
		if (flag)
		{
			GateThread.Wake(this);
		}
	}

	private uint PerformBlockingAdjustment(bool previousDelayElapsed)
	{
		_threadAdjustmentLock.Acquire();
		uint result;
		bool addWorker;
		try
		{
			result = PerformBlockingAdjustment(previousDelayElapsed, out addWorker);
		}
		finally
		{
			_threadAdjustmentLock.Release();
		}
		if (addWorker)
		{
			WorkerThread.MaybeAddWorkingWorker(this);
		}
		return result;
	}

	private uint PerformBlockingAdjustment(bool previousDelayElapsed, out bool addWorker)
	{
		_pendingBlockingAdjustment = PendingBlockingAdjustment.None;
		addWorker = false;
		short targetThreadsGoalForBlockingAdjustment = TargetThreadsGoalForBlockingAdjustment;
		ThreadCounts counts = _separated.counts;
		short num = counts.NumThreadsGoal;
		if (num == targetThreadsGoalForBlockingAdjustment)
		{
			return 0u;
		}
		if (num > targetThreadsGoalForBlockingAdjustment)
		{
			if (_numThreadsAddedDueToBlocking <= 0)
			{
				return 0u;
			}
			short num2 = Math.Min((short)(num - targetThreadsGoalForBlockingAdjustment), _numThreadsAddedDueToBlocking);
			_numThreadsAddedDueToBlocking -= num2;
			num -= num2;
			_separated.counts.InterlockedSetNumThreadsGoal(num);
			HillClimbing.ThreadPoolHillClimber.ForceChange(num, HillClimbing.StateOrTransition.CooperativeBlocking);
			return 0u;
		}
		short num3 = (short)Math.Min((ushort)(_minThreads + BlockingConfig.ThreadsToAddWithoutDelay), (ushort)_maxThreads);
		short val = Math.Max(num3, Math.Min(counts.NumExistingThreads, _maxThreads));
		short num4 = Math.Min(targetThreadsGoalForBlockingAdjustment, val);
		short num5;
		if (num < num4)
		{
			num5 = num4;
		}
		else
		{
			if (!previousDelayElapsed)
			{
				goto IL_01a6;
			}
			num5 = (short)(num + 1);
		}
		if (num5 > counts.NumExistingThreads && !BlockingConfig.IgnoreMemoryUsage)
		{
			long memoryLimitBytes = _memoryLimitBytes;
			if (memoryLimitBytes > 0)
			{
				long num6 = _memoryUsageBytes + (long)counts.NumExistingThreads * 65536L;
				long num7 = memoryLimitBytes * 8 / 10;
				if (num6 >= num7)
				{
					return 0u;
				}
				long val2 = counts.NumExistingThreads + (num7 - num6) / 65536;
				num5 = (short)Math.Min(num5, val2);
				if (num5 <= num)
				{
					return 0u;
				}
			}
		}
		_numThreadsAddedDueToBlocking += (short)(num5 - num);
		counts = _separated.counts.InterlockedSetNumThreadsGoal(num5);
		HillClimbing.ThreadPoolHillClimber.ForceChange(num5, HillClimbing.StateOrTransition.CooperativeBlocking);
		if (counts.NumProcessingWork >= num && _separated.numRequestedWorkers > 0)
		{
			addWorker = true;
		}
		num = num5;
		if (num >= targetThreadsGoalForBlockingAdjustment)
		{
			return 0u;
		}
		goto IL_01a6;
		IL_01a6:
		_pendingBlockingAdjustment = PendingBlockingAdjustment.WithDelayIfNecessary;
		return Math.Min((uint)(1 + (num - num3) / BlockingConfig.ThreadsPerDelayStep) * BlockingConfig.DelayStepMs, BlockingConfig.MaxDelayMs);
	}

	internal void RegisterWaitHandle(RegisteredWaitHandle handle)
	{
		if (NativeRuntimeEventSource.Log.IsEnabled())
		{
		}
		_waitThreadLock.Acquire();
		try
		{
			WaitThreadNode waitThreadNode = _waitThreadsHead ?? (_waitThreadsHead = new WaitThreadNode(new WaitThread()));
			WaitThreadNode waitThreadNode2;
			do
			{
				if (waitThreadNode.Thread.RegisterWaitHandle(handle))
				{
					return;
				}
				waitThreadNode2 = waitThreadNode;
				waitThreadNode = waitThreadNode.Next;
			}
			while (waitThreadNode != null);
			waitThreadNode2.Next = new WaitThreadNode(new WaitThread());
			waitThreadNode2.Next.Thread.RegisterWaitHandle(handle);
		}
		finally
		{
			_waitThreadLock.Release();
		}
	}

	internal static void CompleteWait(RegisteredWaitHandle handle, bool timedOut)
	{
		if (NativeRuntimeEventSource.Log.IsEnabled())
		{
		}
		handle.PerformCallback(timedOut);
	}

	private bool TryRemoveWaitThread(WaitThread thread)
	{
		_waitThreadLock.Acquire();
		try
		{
			if (thread.AnyUserWaits)
			{
				return false;
			}
			RemoveWaitThread(thread);
		}
		finally
		{
			_waitThreadLock.Release();
		}
		return true;
	}

	private void RemoveWaitThread(WaitThread thread)
	{
		WaitThreadNode waitThreadNode = _waitThreadsHead;
		if (waitThreadNode.Thread == thread)
		{
			_waitThreadsHead = waitThreadNode.Next;
			return;
		}
		WaitThreadNode waitThreadNode2;
		do
		{
			waitThreadNode2 = waitThreadNode;
			waitThreadNode = waitThreadNode.Next;
		}
		while (waitThreadNode != null && waitThreadNode.Thread != thread);
		if (waitThreadNode != null)
		{
			waitThreadNode2.Next = waitThreadNode.Next;
		}
	}

	public void ReportThreadStatus(bool isProcessingUserCallback)
	{
		CountsOfThreadsProcessingUserCallbacks countsOfThreadsProcessingUserCallbacks = _countsOfThreadsProcessingUserCallbacks;
		while (true)
		{
			CountsOfThreadsProcessingUserCallbacks newCounts = countsOfThreadsProcessingUserCallbacks;
			if (isProcessingUserCallback)
			{
				newCounts.IncrementCurrent();
			}
			else
			{
				newCounts.DecrementCurrent();
			}
			CountsOfThreadsProcessingUserCallbacks countsOfThreadsProcessingUserCallbacks2 = _countsOfThreadsProcessingUserCallbacks.InterlockedCompareExchange(newCounts, countsOfThreadsProcessingUserCallbacks);
			if (!(countsOfThreadsProcessingUserCallbacks2 == countsOfThreadsProcessingUserCallbacks))
			{
				countsOfThreadsProcessingUserCallbacks = countsOfThreadsProcessingUserCallbacks2;
				continue;
			}
			break;
		}
	}

	private short GetAndResetHighWatermarkCountOfThreadsProcessingUserCallbacks()
	{
		CountsOfThreadsProcessingUserCallbacks countsOfThreadsProcessingUserCallbacks = _countsOfThreadsProcessingUserCallbacks;
		CountsOfThreadsProcessingUserCallbacks countsOfThreadsProcessingUserCallbacks2;
		while (true)
		{
			CountsOfThreadsProcessingUserCallbacks newCounts = countsOfThreadsProcessingUserCallbacks;
			newCounts.ResetHighWatermark();
			countsOfThreadsProcessingUserCallbacks2 = _countsOfThreadsProcessingUserCallbacks.InterlockedCompareExchange(newCounts, countsOfThreadsProcessingUserCallbacks);
			if (countsOfThreadsProcessingUserCallbacks2 == countsOfThreadsProcessingUserCallbacks || countsOfThreadsProcessingUserCallbacks2.HighWatermark == countsOfThreadsProcessingUserCallbacks2.Current)
			{
				break;
			}
			countsOfThreadsProcessingUserCallbacks = countsOfThreadsProcessingUserCallbacks2;
		}
		return countsOfThreadsProcessingUserCallbacks2.HighWatermark;
	}
}
