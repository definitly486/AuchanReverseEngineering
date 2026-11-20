using System;
using Android.Hardware;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Ecom.PriceChecker;

public class AutoFocusActionCallback : Java.Lang.Object, Camera.IAutoFocusCallback, IJavaObject, IDisposable, IJavaPeerable
{
	public Camera.Parameters Parameters { get; set; }

	public string DefaultFocusMode { get; set; }

	public void OnAutoFocus(bool success, Camera camera)
	{
		Log.Info("CameraController", $"AutoFocus done, result - {success}");
		if (Parameters != null && DefaultFocusMode != null && Parameters.FocusMode != DefaultFocusMode)
		{
			Parameters.FocusMode = DefaultFocusMode;
			camera.SetParameters(Parameters);
			Log.Info("CameraController", "AutoFocus done, focus reset");
			Parameters = null;
			DefaultFocusMode = null;
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
