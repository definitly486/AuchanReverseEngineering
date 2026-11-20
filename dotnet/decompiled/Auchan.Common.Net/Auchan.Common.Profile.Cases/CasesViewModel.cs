using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Profile.Cases.Api;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Cases;

public class CasesViewModel : ScreenViewModel
{
	private const int ItemCountPerPage = 10;

	private readonly CasesService _casesService;

	private readonly TaskQueue _loadQueue = new TaskQueue();

	private int _offset;

	private bool _isLoadingNextPage;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasNextPage_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public string Title { get; } = "Мои обращения";

	public string EmptyTitleText { get; } = "Здесь будут ваши обращения";

	public string ErrorTitleText { get; } = "Что-то пошло не так...";

	public string ErrorMessageText { get; } = "Повторите попытку позже";

	public string ErrorButtonText { get; } = "Повторить";

	public string ProgressTitle { get; } = "Загружаем ваши обращения…";

	public ObservableRangeCollection<CaseItemViewModel> Cases { get; } = new ObservableRangeCollection<CaseItemViewModel>();

	public UICommand<CaseDetailsViewModel.Parameter> CaseDetailsCommand { get; } = new UICommand<CaseDetailsViewModel.Parameter>();

	public UICommand InfoCommand { get; } = new UICommand();

	public bool HasNextPage
	{
		[CompilerGenerated]
		get
		{
			return _003CHasNextPage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CHasNextPage_003Ek__BackingField != value)
			{
				_003CHasNextPage_003Ek__BackingField = value;
				RaisePropertyChanged("HasNextPage");
			}
		}
	}

	public CasesViewModel(CasesService casesService)
	{
		_casesService = casesService;
	}

	protected override async Task Start()
	{
		await base.Start();
		LoadFirstPageQueued();
	}

	public void LoadNextPage()
	{
		if (HasNextPage && !_isLoadingNextPage)
		{
			_loadQueue.Enqueue(LoadNextPageInternal).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void Retry()
	{
		LoadFirstPageQueued();
	}

	private void LoadFirstPageQueued()
	{
		_loadQueue.Enqueue(LoadFirstPageInternal).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task LoadFirstPageInternal()
	{
		_offset = 0;
		HasNextPage = false;
		Cases.Clear();
		State = VisualState.InProgress;
		Result<CasesDtos.CasesResponseDto, DomainError> result = await _casesService.GetCases(_offset, 10);
		if (result.IsFailure)
		{
			ApplyError(result.Error);
			return;
		}
		IReadOnlyList<CaseItemViewModel> readOnlyList = MapCases(result.Value);
		if (readOnlyList.Count == 0)
		{
			State = VisualState.Empty;
			return;
		}
		_offset = readOnlyList.Count;
		Cases.AddRange(readOnlyList);
		UpdatePagination(result.Value.Meta?.Pagination, readOnlyList.Count);
		State = VisualState.Default;
	}

	private async Task LoadNextPageInternal()
	{
		if (!HasNextPage || _isLoadingNextPage)
		{
			return;
		}
		_isLoadingNextPage = true;
		Result<CasesDtos.CasesResponseDto, DomainError> result = await _casesService.GetCases(_offset, 10);
		if (result.IsFailure)
		{
			_isLoadingNextPage = false;
			return;
		}
		IReadOnlyList<CaseItemViewModel> readOnlyList = MapCases(result.Value);
		if (readOnlyList.Count > 0)
		{
			Cases.AddRange(readOnlyList);
			_offset += readOnlyList.Count;
		}
		UpdatePagination(result.Value.Meta?.Pagination, readOnlyList.Count);
		_isLoadingNextPage = false;
	}

	private void UpdatePagination(CasesDtos.PaginationResponseDto? pagination, int receivedCount)
	{
		int? num = pagination?.Total;
		if (num.HasValue)
		{
			HasNextPage = Cases.Count < num.Value;
		}
		else
		{
			HasNextPage = receivedCount >= 10;
		}
	}

	private void ApplyError(DomainError error)
	{
		if (error is NoDataError)
		{
			State = VisualState.Empty;
		}
		else
		{
			State = VisualState.Error;
		}
	}

	private static IReadOnlyList<CaseItemViewModel> MapCases(CasesDtos.CasesResponseDto response)
	{
		return (response.Data?.Cases ?? new List<CasesDtos.CaseDto>()).Select((CasesDtos.CaseDto item) => new CaseItemViewModel(item)).ToList();
	}
}
