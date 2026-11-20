using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Diagnostics.Metrics;

public sealed class MeterListener : IDisposable
{
	private readonly DiagLinkedList<Instrument> _enabledMeasurementInstruments = new DiagLinkedList<Instrument>();

	private MeasurementCallback<byte> _byteMeasurementCallback = delegate
	{
	};

	private MeasurementCallback<short> _shortMeasurementCallback = delegate
	{
	};

	private MeasurementCallback<int> _intMeasurementCallback = delegate
	{
	};

	private MeasurementCallback<long> _longMeasurementCallback = delegate
	{
	};

	private MeasurementCallback<float> _floatMeasurementCallback = delegate
	{
	};

	private MeasurementCallback<double> _doubleMeasurementCallback = delegate
	{
	};

	private MeasurementCallback<decimal> _decimalMeasurementCallback = delegate
	{
	};

	public Action<Instrument, MeterListener>? InstrumentPublished { get; set; }

	public Action<Instrument, object?>? MeasurementsCompleted { get; set; }

	public MeterListener()
	{
		RuntimeMetrics.EnsureInitialized();
	}

	public void EnableMeasurementEvents(Instrument instrument, object? state = null)
	{
		_ = 0;
	}

	public object? DisableMeasurementEvents(Instrument instrument)
	{
		_ = 0;
		return null;
	}

	public void SetMeasurementEventCallback<T>(MeasurementCallback<T>? measurementCallback) where T : struct
	{
		_ = 0;
	}

	public void Start()
	{
		_ = 0;
	}

	public void RecordObservableInstruments()
	{
		_ = 0;
	}

	public void Dispose()
	{
		_ = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void NotifyMeasurement<T>(Instrument instrument, T measurement, ReadOnlySpan<KeyValuePair<string, object>> tags, object state) where T : struct
	{
		if (typeof(T) == typeof(byte))
		{
			_byteMeasurementCallback(instrument, (byte)(object)measurement, tags, state);
		}
		if (typeof(T) == typeof(short))
		{
			_shortMeasurementCallback(instrument, (short)(object)measurement, tags, state);
		}
		if (typeof(T) == typeof(int))
		{
			_intMeasurementCallback(instrument, (int)(object)measurement, tags, state);
		}
		if (typeof(T) == typeof(long))
		{
			_longMeasurementCallback(instrument, (long)(object)measurement, tags, state);
		}
		if (typeof(T) == typeof(float))
		{
			_floatMeasurementCallback(instrument, (float)(object)measurement, tags, state);
		}
		if (typeof(T) == typeof(double))
		{
			_doubleMeasurementCallback(instrument, (double)(object)measurement, tags, state);
		}
		if (typeof(T) == typeof(decimal))
		{
			_decimalMeasurementCallback(instrument, (decimal)(object)measurement, tags, state);
		}
	}
}
