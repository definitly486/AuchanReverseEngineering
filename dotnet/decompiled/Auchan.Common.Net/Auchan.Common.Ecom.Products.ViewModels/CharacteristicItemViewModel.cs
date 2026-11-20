using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using AsyncAwaitBestPractices;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class CharacteristicItemViewModel : INotifyPropertyChanged
{
	private readonly Characteristic _characteristic;

	private readonly IInfoMessageService _infoMessageService;

	public int Id => _characteristic.Id;

	public string? Title => _characteristic.Title;

	public string? Value => _characteristic.Value;

	public bool IsArticle => Title == "Артикул";

	public event PropertyChangedEventHandler? PropertyChanged;

	public CharacteristicItemViewModel(Characteristic characteristic, IInfoMessageService infoMessageService)
	{
		_characteristic = characteristic;
		_infoMessageService = infoMessageService;
	}

	public void CopyNumber()
	{
		Clipboard.SetTextAsync(Value).SafeFireAndForget((Action<Exception>)null, false);
		_infoMessageService.ShowSnackbar("Артикул скопирован", SnackbarStyle.Success);
	}

	[GeneratedCode("PropertyChanged.Fody", "4.1.0.0")]
	[DebuggerNonUserCode]
	protected void _003C_003EOnPropertyChanged(PropertyChangedEventArgs? eventArgs)
	{
		this.PropertyChanged?.Invoke(this, eventArgs);
	}
}
