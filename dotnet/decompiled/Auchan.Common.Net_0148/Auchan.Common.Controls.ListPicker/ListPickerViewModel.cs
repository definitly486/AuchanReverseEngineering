using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Extensions;

namespace Auchan.Common.Controls.ListPicker;

public class ListPickerViewModel : ScreenViewModel
{
	public class Parameter
	{
		public List<ListPickerItemViewModel> Items { get; }

		public Parameter(List<ListPickerItemViewModel> items)
		{
			Items = items;
		}
	}

	public sealed class Result
	{
		public int SelectedPosition { get; }

		public ListPickerItemViewModel SelectedItem { get; }

		public Result(int selectedPosition, ListPickerItemViewModel selectedItem)
		{
			SelectedPosition = selectedPosition;
			SelectedItem = selectedItem;
		}
	}

	private readonly Subject<Unit> _dismissSubject = new Subject<Unit>();

	private readonly Subject<Result> _returnSubject = new Subject<Result>();

	public string ScreenTitle => "Выберите";

	public string SaveButtonText => "Выбрать";

	public IReadOnlyList<ListPickerItemViewModel> Items { get; }

	public IObservable<Result> ReturnCommand => _returnSubject.Debounce();

	public IObservable<Unit> DismissCommand => _dismissSubject.Debounce();

	public ListPickerViewModel(Parameter parameter)
	{
		Items = parameter.Items;
	}

	protected override async Task Start()
	{
		await base.Start();
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
	}

	public void OnItemSelected(int index)
	{
		foreach (ListPickerItemViewModel item in Items)
		{
			item.Selected = false;
		}
		Items[index].Selected = true;
		_returnSubject.OnNext(new Result(index, Items[index]));
		_dismissSubject.OnNext(Unit.Default);
	}

	public void Close()
	{
		_dismissSubject.OnNext(Unit.Default);
	}
}
