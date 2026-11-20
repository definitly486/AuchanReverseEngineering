using System;
using Android.App;
using Android.Content;
using Android.OS;
using Auchan.Common.AdminTool;
using Auchan.Common.HardUpdate;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.HardUpdate;

public class HardUpdateManager : BaseHardUpdateManager
{
	public HardUpdateManager(Lazy<IAdminContext> adminContext)
		: base(adminContext)
	{
	}

	public override void OnHardUpdateRequired(HardUpdateViewModel.Parameter parameter)
	{
		base.OnHardUpdateRequired(parameter);
		MainThread.BeginInvokeOnMainThread(delegate
		{
			Context context = Application.Context;
			Intent intent = new Intent(context, typeof(HardUpdateActivity));
			intent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.NewTask);
			Bundle bundle = new Bundle();
			bundle.PutString("message", parameter.Message);
			intent.PutExtra("bundle", bundle);
			context.StartActivity(intent);
		});
	}
}
