using System.Collections.Generic;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Common;

public interface IOptionSelectorViewModel<TOption, TItem> where TOption : ISelectionItemViewModel<TItem> where TItem : ITitle
{
	string Title { get; }

	string ApplyButtonTitle { get; }

	IReadOnlyList<TOption> Items { get; }

	UICommand ApplyCommand { get; }

	UICommand CloseDialogCommand { get; }

	UICommand<TOption> SelectItemCommand { get; }

	bool ShowPullIndicator => true;

	float TableTopMargin => 20f;

	float ApplyButtonTopMargin => 32f;

	float PaddingTop => 24f;

	float PaddingLeft => 20f;

	float PaddingRight => 20f;
}
