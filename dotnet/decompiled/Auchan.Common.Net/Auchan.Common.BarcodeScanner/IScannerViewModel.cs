using System;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.PriceChecker;

namespace Auchan.Common.BarcodeScanner;

public interface IScannerViewModel
{
	UICommand<string> BarcodeResultCommand { get; }

	ScannerState ScannerState { get; }

	BarcodeType BarcodeType { get; }

	void OnDialogErrorOkClicked();

	void OnPlatformError(string description, Exception ex);
}
