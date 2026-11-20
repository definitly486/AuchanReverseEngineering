using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Extensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

public class SumDetailsSectionViewModel : BaseItemViewModel
{
	private readonly Subject<Unit> _wasInitialized = new Subject<Unit>();

	[CompilerGenerated]
	private string _003CResultSum_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAddedPoints_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAddedExpressPoints_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAddedStamps_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSpentPoints_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSpentExpressPoints_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSpentStamps_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDelayedPoints_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDelayedPointsBookDate_003Ek__BackingField;

	public IObservable<Unit> WasInitializedCommand => _wasInitialized.Debounce();

	public bool HasAddedPoints => !string.IsNullOrWhiteSpace(AddedPoints);

	public bool HasAddedExpressPoints => !string.IsNullOrWhiteSpace(AddedExpressPoints);

	public bool HasAddedStamps => !string.IsNullOrWhiteSpace(AddedStamps);

	public bool HasDelayedPoints => !string.IsNullOrWhiteSpace(DelayedPoints);

	public bool HasDelayedPointsBookDate => !string.IsNullOrWhiteSpace(DelayedPointsBookDate);

	public bool HasSpentPoints => !string.IsNullOrWhiteSpace(SpentPoints);

	public bool HasSpentExpressPoints => !string.IsNullOrWhiteSpace(SpentExpressPoints);

	public bool HasSpentStamps => !string.IsNullOrWhiteSpace(SpentStamps);

	public string ResultSumTitle => "Сумма";

	public string AddedPointsSectionTitle => "Начислено баллов";

	public string SpentPointsSectionTitle => "Списано баллов";

	public string StampsSectionTitle => "Марки";

	public string DelayedPointsSectionTitle { get; } = "Станут активными";

	public string ResultSum
	{
		[CompilerGenerated]
		get
		{
			return _003CResultSum_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CResultSum_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CResultSum_003Ek__BackingField = value;
				RaisePropertyChanged("ResultSum");
			}
		}
	} = "";

	public string AddedPoints
	{
		[CompilerGenerated]
		get
		{
			return _003CAddedPoints_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAddedPoints_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddedPoints_003Ek__BackingField = value;
				RaisePropertyChanged("HasAddedPoints");
				RaisePropertyChanged("AddedPoints");
			}
		}
	} = "";

	public string AddedExpressPoints
	{
		[CompilerGenerated]
		get
		{
			return _003CAddedExpressPoints_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAddedExpressPoints_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddedExpressPoints_003Ek__BackingField = value;
				RaisePropertyChanged("HasAddedExpressPoints");
				RaisePropertyChanged("AddedExpressPoints");
			}
		}
	} = "";

	public string AddedStamps
	{
		[CompilerGenerated]
		get
		{
			return _003CAddedStamps_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAddedStamps_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddedStamps_003Ek__BackingField = value;
				RaisePropertyChanged("HasAddedStamps");
				RaisePropertyChanged("AddedStamps");
			}
		}
	} = "";

	public string SpentPoints
	{
		[CompilerGenerated]
		get
		{
			return _003CSpentPoints_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CSpentPoints_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSpentPoints_003Ek__BackingField = value;
				RaisePropertyChanged("HasSpentPoints");
				RaisePropertyChanged("SpentPoints");
			}
		}
	} = "";

	public string SpentExpressPoints
	{
		[CompilerGenerated]
		get
		{
			return _003CSpentExpressPoints_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CSpentExpressPoints_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSpentExpressPoints_003Ek__BackingField = value;
				RaisePropertyChanged("HasSpentExpressPoints");
				RaisePropertyChanged("SpentExpressPoints");
			}
		}
	} = "";

	public string SpentStamps
	{
		[CompilerGenerated]
		get
		{
			return _003CSpentStamps_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CSpentStamps_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSpentStamps_003Ek__BackingField = value;
				RaisePropertyChanged("HasSpentStamps");
				RaisePropertyChanged("SpentStamps");
			}
		}
	} = "";

	public string DelayedPoints
	{
		[CompilerGenerated]
		get
		{
			return _003CDelayedPoints_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDelayedPoints_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDelayedPoints_003Ek__BackingField = value;
				RaisePropertyChanged("HasDelayedPoints");
				RaisePropertyChanged("DelayedPoints");
			}
		}
	} = string.Empty;

	public string DelayedPointsBookDate
	{
		[CompilerGenerated]
		get
		{
			return _003CDelayedPointsBookDate_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDelayedPointsBookDate_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDelayedPointsBookDate_003Ek__BackingField = value;
				RaisePropertyChanged("HasDelayedPointsBookDate");
				RaisePropertyChanged("DelayedPointsBookDate");
			}
		}
	} = string.Empty;

	public void Initialize(string resultSum, string addedPoints, string addedExpressPoints, string addedStamps, string spentPoints, string spentExpressPoints, string spentStamps, string delayedPoints, string delayedPointsBookDate)
	{
		ResultSum = resultSum;
		AddedPoints = addedPoints;
		AddedExpressPoints = addedExpressPoints;
		AddedStamps = addedStamps;
		SpentPoints = spentPoints;
		SpentExpressPoints = spentExpressPoints;
		SpentStamps = spentStamps;
		DelayedPoints = delayedPoints;
		DelayedPointsBookDate = delayedPointsBookDate;
		Task.Delay(200).ContinueWith(delegate
		{
			_wasInitialized.OnNext(Unit.Default);
		}).SafeFireAndForget((Action<Exception>)null, false);
	}
}
