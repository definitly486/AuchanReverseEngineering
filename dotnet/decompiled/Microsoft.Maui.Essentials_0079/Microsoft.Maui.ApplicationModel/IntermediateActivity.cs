using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Microsoft.Maui.ApplicationModel;

[Activity(ConfigurationChanges = (ConfigChanges.Orientation | ConfigChanges.ScreenSize), Exported = false)]
internal class IntermediateActivity : Activity
{
	private class IntermediateTask
	{
		public string Id { get; }

		public TaskCompletionSource<Intent> TaskCompletionSource { get; }

		public Action<Intent>? OnCreate { get; }

		public Action<Intent>? OnResult { get; }

		public IntermediateTask(Action<Intent>? onCreate, Action<Intent>? onResult)
		{
			Id = Guid.NewGuid().ToString();
			TaskCompletionSource = new TaskCompletionSource<Intent>();
			OnCreate = onCreate;
			OnResult = onResult;
		}
	}

	private static readonly ConcurrentDictionary<string, IntermediateTask> pendingTasks = new ConcurrentDictionary<string, IntermediateTask>();

	private bool launched;

	private Intent? actualIntent;

	private string? guid;

	private int requestCode;

	protected override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		Bundle bundle = savedInstanceState ?? Intent?.Extras;
		launched = bundle?.GetBoolean("launched", defaultValue: false) ?? false;
		actualIntent = bundle?.GetParcelable("actual_intent") as Intent;
		guid = bundle?.GetString("guid");
		requestCode = bundle?.GetInt("request_code", -1) ?? (-1);
		GetIntermediateTask(guid)?.OnCreate?.Invoke(actualIntent);
		if (!launched)
		{
			StartActivityForResult(actualIntent, requestCode);
		}
	}

	protected override void OnSaveInstanceState(Bundle outState)
	{
		outState.PutBoolean("launched", value: true);
		outState.PutParcelable("actual_intent", actualIntent);
		outState.PutString("guid", guid);
		outState.PutInt("request_code", requestCode);
		base.OnSaveInstanceState(outState);
	}

	protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
	{
		base.OnActivityResult(requestCode, resultCode, data);
		IntermediateTask intermediateTask = GetIntermediateTask(guid, remove: true);
		Finish();
		if (intermediateTask == null)
		{
			return;
		}
		if (resultCode == Result.Canceled)
		{
			intermediateTask.TaskCompletionSource.TrySetCanceled();
			return;
		}
		try
		{
			if (data == null)
			{
				data = new Intent();
			}
			intermediateTask.OnResult?.Invoke(data);
			intermediateTask.TaskCompletionSource.TrySetResult(data);
		}
		catch (Exception exception)
		{
			intermediateTask.TaskCompletionSource.TrySetException(exception);
		}
	}

	public static Task<Intent> StartAsync(Intent intent, int requestCode, Action<Intent>? onCreate = null, Action<Intent>? onResult = null)
	{
		Activity currentActivity = ActivityStateManager.Default.GetCurrentActivity(throwOnNull: true);
		IntermediateTask intermediateTask = new IntermediateTask(onCreate, onResult);
		pendingTasks[intermediateTask.Id] = intermediateTask;
		Intent intent2 = new Intent(currentActivity, typeof(IntermediateActivity));
		intent2.PutExtra("actual_intent", intent);
		intent2.PutExtra("guid", intermediateTask.Id);
		intent2.PutExtra("request_code", requestCode);
		currentActivity.StartActivityForResult(intent2, requestCode);
		return intermediateTask.TaskCompletionSource.Task;
	}

	private static IntermediateTask? GetIntermediateTask(string? guid, bool remove = false)
	{
		if (string.IsNullOrEmpty(guid))
		{
			return null;
		}
		if (remove)
		{
			pendingTasks.TryRemove(guid, out IntermediateTask value);
			return value;
		}
		pendingTasks.TryGetValue(guid, out IntermediateTask value2);
		return value2;
	}
}
