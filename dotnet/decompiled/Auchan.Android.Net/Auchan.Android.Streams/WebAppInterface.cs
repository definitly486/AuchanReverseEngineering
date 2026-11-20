using Android.Content;
using Android.Webkit;
using Auchan.Common.Streams;
using Java.Interop;
using Java.Lang;
using Newtonsoft.Json;

namespace Auchan.Android.Streams;

public class WebAppInterface : Object
{
	private readonly StreamViewModel _streamViewModel;

	public WebAppInterface(Context context, StreamViewModel streamViewModel)
	{
		_streamViewModel = streamViewModel;
	}

	[JavascriptInterface]
	[Export("addProduct")]
	public void AddProduct(string jsonData)
	{
		StreamsDtos.ProductJSDto productJSDto = JsonConvert.DeserializeObject<StreamsDtos.ProductJSDto>(jsonData);
		if (productJSDto != null)
		{
			_streamViewModel.OnAddProductClicked(productJSDto);
		}
	}

	[JavascriptInterface]
	[Export("openProduct")]
	public void OpenProduct(string jsonData)
	{
		StreamsDtos.ProductJSDto productJSDto = JsonConvert.DeserializeObject<StreamsDtos.ProductJSDto>(jsonData);
		if (productJSDto != null)
		{
			_streamViewModel.OnOpenProductClicked(productJSDto);
		}
	}
}
