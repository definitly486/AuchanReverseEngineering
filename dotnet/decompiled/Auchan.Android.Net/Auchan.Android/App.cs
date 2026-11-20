using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Webkit;
using AndroidX.AppCompat.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.AppAnalytics.YandexMetrica;
using Auchan.Android.Common;
using Auchan.Android.DependencyInjection;
using Auchan.Common;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Logs;
using Auchan.Common.PersonalCabinet.DomainModels;
using Bumptech.Glide;
using Bumptech.Glide.Load.Engine.Cache;
using DryIoc;
using IO.Appmetrica.Analytics;
using Microsoft.Maui.ApplicationModel;
using Newtonsoft.Json;

namespace Auchan.Android;

[Application(AllowBackup = true, Label = "@string/app_name", SupportsRtl = false, LargeHeap = true, Theme = "@style/AppTheme", HardwareAccelerated = true, NetworkSecurityConfig = "@xml/network_security_config")]
[RequiresUnreferencedCode("DI Registrations")]
[RequiresDynamicCode("DI Registrations")]
internal class App : Application
{
	private bool IsMainProcess => PackageName?.Equals(CurrentProcessName) ?? false;

	private string? CurrentProcessName
	{
		get
		{
			if (OperatingSystem.IsAndroidVersionAtLeast(28))
			{
				return Application.ProcessName;
			}
			int currentProcessPid = Process.MyPid();
			return ActivityManager.FromContext(Application.Context)?.RunningAppProcesses?.First((ActivityManager.RunningAppProcessInfo p) => p.Pid == currentProcessPid).ProcessName;
		}
	}

	protected App(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public override void OnCreate()
	{
		base.OnCreate();
		Auchan.Common.Analytics.YandexAppMetrica.AppMetrica.ColdStartWatch.Start();
		WarmUpNewtonsoftJsonWithProfile();
		SetupWebviewForCurrentProcess();
		Container resolver = Auchan.Common.Setup.DIContainer(DependencyRegistry.Register);
		resolver.Resolve<DIBackgroundFragmentRegistrar>();
		if (IsMainProcess)
		{
			AppMetricaConfig config = AppMetricaConfig.NewConfigBuilder("29ce206c-cd70-4273-abb2-b43217df70a9").WithAnrMonitoring(enabled: true).WithAppOpenTrackingEnabled(enabled: true)
				.Build();
			IO.Appmetrica.Analytics.AppMetrica.Activate(Application.Context, config);
			IO.Appmetrica.Analytics.AppMetrica.EnableActivityAutoTracking(this);
			IO.Appmetrica.Analytics.AppMetrica.RequestStartupParams(Application.Context, resolver.Resolve<YandexMetricaDeviceIdListener>(), new List<string>());
			AppMetricaCrashes.Init(resolver.Resolve<ILogService>());
		}
		if (OperatingSystem.IsAndroidVersionAtLeast(29))
		{
			AppCompatDelegate.DefaultNightMode = 1;
		}
		ProcessLifecycleOwner.Get().Lifecycle.AddObserver(resolver.Resolve<ProcessLifecycleObserver>());
		Platform.Init(this);
		GlideBuilder glideBuilder = new GlideBuilder();
		glideBuilder.SetDiskCache(new InternalCacheDiskCacheFactory(Application.Context, 31457280L));
		Glide.Init(Application.Context, glideBuilder);
	}

	public override void OnTrimMemory(TrimMemory level)
	{
		switch (level)
		{
		case TrimMemory.RunningModerate:
		case TrimMemory.UiHidden:
		case TrimMemory.Background:
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Optimized, blocking: false);
			break;
		case TrimMemory.RunningLow:
		case TrimMemory.Moderate:
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: false);
			break;
		case TrimMemory.RunningCritical:
		case TrimMemory.Complete:
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true);
			break;
		}
		Glide.Get(Application.Context).OnTrimMemory(level);
		base.OnTrimMemory(level);
	}

	private void SetupWebviewForCurrentProcess()
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(28) && Application.ProcessName != PackageName)
		{
			WebView.SetDataDirectorySuffix(Application.ProcessName);
		}
	}

	private void WarmUpNewtonsoftJsonWithProfile()
	{
		Task.Run(delegate
		{
			JsonConvert.DeserializeObject<ProfileModel>("\n{'FirstName':'Ss','LastName':'Ппппр','Patronymic':null,'Email':'auc1@yopmail.com','Phone':'76666666666','IsVirtualCard':false,'Gender':2,'Birthday':'2003-04-13T00:00:00','Region':null,'City':null,'Subscribes':[{'Id':11199,'CommunicationType':{'Id':3,'Title':'mobile_push'},'Type':{'Id':1,'Title':'Общая'},'StartDate':'2022-02-11T15:33:21.164+07:00','EndDate':null},{'Id':9474,'CommunicationType':{'Id':1,'Title':'e-mail'},'Type':{'Id':1,'Title':'Общая'},'StartDate':'2021-08-17T16:12:51.819+07:00','EndDate':null}],'Stores':[],'Addresses':[],'UserStatus':'active','ConfirmPhoneDt':'2021-04-15T14:47:05.312+0000','ClientAccountId':'546cba5b-ef6a-40fe-b22c-234173726d7c','MagentoAccountId':6003241,'PhoneConfirmation':true,'PrivacyPolicyFlag':true,'FullName':'Ss Ппппр','CashbackQrCode':'002546cba5b-ef6a-40fe-b22c-234173726d7c','LoyaltyFlag':true,'IsConfirmedSocialStatus':false,'LoyaltyId':'8052','CardNumber':null,'Cvc':null,'QrCode':null,'PointsAmount':0,'EPointsAmount':0,'MarksAmount':0,'CardStatus':0}");
		}).SafeFireAndForget((Action<Exception>)null, false);
	}
}
