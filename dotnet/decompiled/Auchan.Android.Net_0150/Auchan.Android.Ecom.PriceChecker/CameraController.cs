using System;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Util;
using Java.Lang;
using Java.Lang.Reflect;

namespace Auchan.Android.Ecom.PriceChecker;

public class CameraController : Java.Lang.Object
{
	public const string Tag = "CameraController";

	private const int AreaPer1000 = 300;

	private bool _centering;

	private string _defaultFocusMode;

	private AutoFocusActionCallback _focusCallback;

	private static Method _cameraThreadEnqueue;

	public void Refresh()
	{
	}

	public void SetCentering(bool value)
	{
		_centering = value;
	}

	public void AutoFocus(int x, int y)
	{
	}

	public Camera.Parameters ChangeCameraParameters(Camera.Parameters parameters)
	{
		if (parameters == null)
		{
			Log.Error("CameraController", "ChangeCameraParameters called with NULL parameter");
			return null;
		}
		parameters.PreviewFormat = ImageFormatType.Nv21;
		UpdateFocusMode(parameters);
		UpdateFps(parameters);
		SetBarcodeSceneMode(parameters);
		SetCenteringFocusArea(parameters, _centering);
		SetCenteringMetering(parameters, _centering);
		int? num = null;
		int? num2 = null;
		IList<Camera.Size> supportedPreviewSizes = parameters.SupportedPreviewSizes;
		if (supportedPreviewSizes != null)
		{
			foreach (Camera.Size item in supportedPreviewSizes)
			{
				if (item.Width >= 640 && item.Width <= 1000 && item.Height >= 360 && item.Height <= 1000)
				{
					num = item.Width;
					num2 = item.Height;
					break;
				}
			}
		}
		if (Build.Model != null && Build.Model.Contains("Glass"))
		{
			num = 640;
			num2 = 360;
			parameters.SetPreviewFpsRange(30000, 30000);
		}
		if (num.HasValue)
		{
			int? num3 = num;
			string? text = num3.ToString();
			num3 = num2;
			Log.Debug("CameraController", "Selected Resolution: " + text + "x" + num3);
			parameters.SetPreviewSize(num.Value, num2.Value);
		}
		Log.Info("CameraController", "ChangeCameraParameters is done");
		return parameters;
	}

	private void UpdateFocusMode(Camera.Parameters parameters)
	{
		IList<string> supportedFocusModes = parameters.SupportedFocusModes;
		if (supportedFocusModes != null)
		{
			if (supportedFocusModes.Contains("continuous-picture"))
			{
				parameters.FocusMode = "continuous-picture";
			}
			else if (supportedFocusModes.Contains("continuous-video"))
			{
				parameters.FocusMode = "continuous-video";
			}
			else if (supportedFocusModes.Contains("auto"))
			{
				parameters.FocusMode = "auto";
			}
			else if (supportedFocusModes.Contains("fixed"))
			{
				parameters.FocusMode = "fixed";
			}
		}
		_defaultFocusMode = parameters.FocusMode;
		Log.Debug("CameraController", "FocusMode = " + parameters.FocusMode);
	}

	private void UpdateFps(Camera.Parameters parameters)
	{
		int[] array = parameters.SupportedPreviewFpsRange?.FirstOrDefault();
		if (array == null)
		{
			return;
		}
		Log.Debug("CameraController", $"Old Selected fps Min:{array[0]}, Max {array[1]}");
		foreach (int[] item in parameters.SupportedPreviewFpsRange)
		{
			if (item[1] > array[1] || (item[1] == array[1] && item[0] < array[0]))
			{
				array = item;
			}
		}
		Log.Debug("CameraController", $"Setting Selected fps to Min:{array[0]}, Max {array[1]}");
		parameters.SetPreviewFpsRange(array[0], array[1]);
	}

	private void SetCenteringFocusArea(Camera.Parameters parameters, bool enabled)
	{
		if (parameters.MaxNumFocusAreas == 0)
		{
			Log.Debug("CameraController", "Device does not support focus areas");
		}
		else if (enabled)
		{
			parameters.FocusAreas = BuildMiddleArea(300);
		}
	}

	private void SetCenteringMetering(Camera.Parameters parameters, bool enabled)
	{
		if (parameters.MaxNumMeteringAreas <= 0)
		{
			Log.Debug("CameraController", "Device does not support metering areas");
		}
		else if (enabled)
		{
			parameters.MeteringAreas = BuildMiddleArea(300);
		}
	}

	private List<Camera.Area> BuildMiddleArea(int areaPer1000)
	{
		return new List<Camera.Area>
		{
			new Camera.Area(new Rect(-areaPer1000, -areaPer1000, areaPer1000, areaPer1000), 1)
		};
	}

	private void SetBarcodeSceneMode(Camera.Parameters parameters)
	{
		if (parameters.SceneMode == "barcode")
		{
			Log.Debug("CameraController", "Barcode scene mode already set");
			return;
		}
		IList<string>? supportedSceneModes = parameters.SupportedSceneModes;
		if (supportedSceneModes != null && supportedSceneModes.Contains("barcode"))
		{
			Log.Debug("CameraController", "Previous SceneMode=" + parameters.SceneMode);
			parameters.SceneMode = "barcode";
			Log.Debug("CameraController", "Barcode scene mode is set");
		}
	}

	private void AutoFocus(Camera camera, int x, int y, bool useCoordinates)
	{
		if (camera == null)
		{
			Log.Error("CameraController", "AutoFocus failed - camera is null");
			return;
		}
		Log.Debug("CameraController", "AutoFocus Requested");
		camera.CancelAutoFocus();
		Camera.Parameters parameters = camera.GetParameters();
		try
		{
			if (useCoordinates && parameters.SupportedFocusModes.Contains("auto"))
			{
				x -= 10;
				y -= 10;
				if (x >= 1000)
				{
					x = 980;
				}
				if (x < -1000)
				{
					x = -1000;
				}
				if (y >= 1000)
				{
					y = 980;
				}
				if (y < -1000)
				{
					y = -1000;
				}
				Rect rect = new Rect(x, y, x + 20, y + 20);
				parameters.FocusMode = "auto";
				parameters.FocusAreas = new List<Camera.Area>
				{
					new Camera.Area(rect, 1000)
				};
				Log.Debug("CameraController", $"AutoFocus Area = {rect}");
				camera.SetParameters(parameters);
			}
			if (_focusCallback == null)
			{
				_focusCallback = new AutoFocusActionCallback();
			}
			_focusCallback.DefaultFocusMode = _defaultFocusMode;
			_focusCallback.Parameters = parameters;
			camera.AutoFocus(_focusCallback);
		}
		catch (System.Exception value)
		{
			Log.Error("CameraController", $"AutoFocus Failed: {value}");
		}
	}

	private void Enqueue(Action<Camera> action)
	{
	}
}
