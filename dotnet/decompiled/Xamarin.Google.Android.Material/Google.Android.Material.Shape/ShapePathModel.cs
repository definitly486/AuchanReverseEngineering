using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Shape;

[Obsolete("This class is obsoleted in this android platform")]
[Register("com/google/android/material/shape/ShapePathModel", DoNotGenerateAcw = true)]
public class ShapePathModel : ShapeAppearanceModel
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/ShapePathModel", typeof(ShapePathModel));

	private static Delegate? cb_setAllCorners_SetAllCorners_Lcom_google_android_material_shape_CornerTreatment__V;

	private static Delegate? cb_setAllEdges_SetAllEdges_Lcom_google_android_material_shape_EdgeTreatment__V;

	private static Delegate? cb_setBottomEdge_SetBottomEdge_Lcom_google_android_material_shape_EdgeTreatment__V;

	private static Delegate? cb_setBottomLeftCorner_SetBottomLeftCorner_Lcom_google_android_material_shape_CornerTreatment__V;

	private static Delegate? cb_setBottomRightCorner_SetBottomRightCorner_Lcom_google_android_material_shape_CornerTreatment__V;

	private static Delegate? cb_setCornerTreatments_SetCornerTreatments_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment__V;

	private static Delegate? cb_setEdgeTreatments_SetEdgeTreatments_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment__V;

	private static Delegate? cb_setLeftEdge_SetLeftEdge_Lcom_google_android_material_shape_EdgeTreatment__V;

	private static Delegate? cb_setRightEdge_SetRightEdge_Lcom_google_android_material_shape_EdgeTreatment__V;

	private static Delegate? cb_setTopEdge_SetTopEdge_Lcom_google_android_material_shape_EdgeTreatment__V;

	private static Delegate? cb_setTopLeftCorner_SetTopLeftCorner_Lcom_google_android_material_shape_CornerTreatment__V;

	private static Delegate? cb_setTopRightCorner_SetTopRightCorner_Lcom_google_android_material_shape_CornerTreatment__V;

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ShapePathModel(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ShapePathModel()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Obsolete]
	private static Delegate GetSetAllCorners_Lcom_google_android_material_shape_CornerTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetAllCorners_Lcom_google_android_material_shape_CornerTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAllCorners_Lcom_google_android_material_shape_CornerTreatment_(nint jnienv, nint native__this, nint native_cornerTreatment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CornerTreatment allCorners = Java.Lang.Object.GetObject<CornerTreatment>(native_cornerTreatment, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetAllCorners(allCorners);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setAllCorners", "(Lcom/google/android/material/shape/CornerTreatment;)V", "GetSetAllCorners_Lcom_google_android_material_shape_CornerTreatment_Handler")]
	public unsafe virtual void SetAllCorners(CornerTreatment? cornerTreatment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cornerTreatment?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAllCorners.(Lcom/google/android/material/shape/CornerTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cornerTreatment);
		}
	}

	[Obsolete]
	private static Delegate GetSetAllEdges_Lcom_google_android_material_shape_EdgeTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetAllEdges_Lcom_google_android_material_shape_EdgeTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAllEdges_Lcom_google_android_material_shape_EdgeTreatment_(nint jnienv, nint native__this, nint native_edgeTreatment)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EdgeTreatment allEdges = Java.Lang.Object.GetObject<EdgeTreatment>(native_edgeTreatment, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetAllEdges(allEdges);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setAllEdges", "(Lcom/google/android/material/shape/EdgeTreatment;)V", "GetSetAllEdges_Lcom_google_android_material_shape_EdgeTreatment_Handler")]
	public unsafe virtual void SetAllEdges(EdgeTreatment? edgeTreatment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(edgeTreatment?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAllEdges.(Lcom/google/android/material/shape/EdgeTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(edgeTreatment);
		}
	}

	[Obsolete]
	private static Delegate GetSetBottomEdge_Lcom_google_android_material_shape_EdgeTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBottomEdge_Lcom_google_android_material_shape_EdgeTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBottomEdge_Lcom_google_android_material_shape_EdgeTreatment_(nint jnienv, nint native__this, nint native_bottomEdge)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EdgeTreatment bottomEdge = Java.Lang.Object.GetObject<EdgeTreatment>(native_bottomEdge, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetBottomEdge(bottomEdge);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setBottomEdge", "(Lcom/google/android/material/shape/EdgeTreatment;)V", "GetSetBottomEdge_Lcom_google_android_material_shape_EdgeTreatment_Handler")]
	public unsafe virtual void SetBottomEdge(EdgeTreatment? bottomEdge)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bottomEdge?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBottomEdge.(Lcom/google/android/material/shape/EdgeTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bottomEdge);
		}
	}

	[Obsolete]
	private static Delegate GetSetBottomLeftCorner_Lcom_google_android_material_shape_CornerTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBottomLeftCorner_Lcom_google_android_material_shape_CornerTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBottomLeftCorner_Lcom_google_android_material_shape_CornerTreatment_(nint jnienv, nint native__this, nint native_bottomLeftCorner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CornerTreatment bottomLeftCorner = Java.Lang.Object.GetObject<CornerTreatment>(native_bottomLeftCorner, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetBottomLeftCorner(bottomLeftCorner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setBottomLeftCorner", "(Lcom/google/android/material/shape/CornerTreatment;)V", "GetSetBottomLeftCorner_Lcom_google_android_material_shape_CornerTreatment_Handler")]
	public unsafe virtual void SetBottomLeftCorner(CornerTreatment? bottomLeftCorner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bottomLeftCorner?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBottomLeftCorner.(Lcom/google/android/material/shape/CornerTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bottomLeftCorner);
		}
	}

	[Obsolete]
	private static Delegate GetSetBottomRightCorner_Lcom_google_android_material_shape_CornerTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBottomRightCorner_Lcom_google_android_material_shape_CornerTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBottomRightCorner_Lcom_google_android_material_shape_CornerTreatment_(nint jnienv, nint native__this, nint native_bottomRightCorner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CornerTreatment bottomRightCorner = Java.Lang.Object.GetObject<CornerTreatment>(native_bottomRightCorner, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetBottomRightCorner(bottomRightCorner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setBottomRightCorner", "(Lcom/google/android/material/shape/CornerTreatment;)V", "GetSetBottomRightCorner_Lcom_google_android_material_shape_CornerTreatment_Handler")]
	public unsafe virtual void SetBottomRightCorner(CornerTreatment? bottomRightCorner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bottomRightCorner?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBottomRightCorner.(Lcom/google/android/material/shape/CornerTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bottomRightCorner);
		}
	}

	[Obsolete]
	private static Delegate GetSetCornerTreatments_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Handler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_SetCornerTreatments_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCornerTreatments_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_(nint jnienv, nint native__this, nint native_topLeftCorner, nint native_topRightCorner, nint native_bottomRightCorner, nint native_bottomLeftCorner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CornerTreatment topLeftCorner = Java.Lang.Object.GetObject<CornerTreatment>(native_topLeftCorner, JniHandleOwnership.DoNotTransfer);
			CornerTreatment topRightCorner = Java.Lang.Object.GetObject<CornerTreatment>(native_topRightCorner, JniHandleOwnership.DoNotTransfer);
			CornerTreatment bottomRightCorner = Java.Lang.Object.GetObject<CornerTreatment>(native_bottomRightCorner, JniHandleOwnership.DoNotTransfer);
			CornerTreatment bottomLeftCorner = Java.Lang.Object.GetObject<CornerTreatment>(native_bottomLeftCorner, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetCornerTreatments(topLeftCorner, topRightCorner, bottomRightCorner, bottomLeftCorner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setCornerTreatments", "(Lcom/google/android/material/shape/CornerTreatment;Lcom/google/android/material/shape/CornerTreatment;Lcom/google/android/material/shape/CornerTreatment;Lcom/google/android/material/shape/CornerTreatment;)V", "GetSetCornerTreatments_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Lcom_google_android_material_shape_CornerTreatment_Handler")]
	public unsafe virtual void SetCornerTreatments(CornerTreatment? topLeftCorner, CornerTreatment? topRightCorner, CornerTreatment? bottomRightCorner, CornerTreatment? bottomLeftCorner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(topLeftCorner?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(topRightCorner?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(bottomRightCorner?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(bottomLeftCorner?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCornerTreatments.(Lcom/google/android/material/shape/CornerTreatment;Lcom/google/android/material/shape/CornerTreatment;Lcom/google/android/material/shape/CornerTreatment;Lcom/google/android/material/shape/CornerTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(topLeftCorner);
			GC.KeepAlive(topRightCorner);
			GC.KeepAlive(bottomRightCorner);
			GC.KeepAlive(bottomLeftCorner);
		}
	}

	[Obsolete]
	private static Delegate GetSetEdgeTreatments_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Handler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_SetEdgeTreatments_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEdgeTreatments_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_(nint jnienv, nint native__this, nint native_leftEdge, nint native_topEdge, nint native_rightEdge, nint native_bottomEdge)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EdgeTreatment leftEdge = Java.Lang.Object.GetObject<EdgeTreatment>(native_leftEdge, JniHandleOwnership.DoNotTransfer);
			EdgeTreatment topEdge = Java.Lang.Object.GetObject<EdgeTreatment>(native_topEdge, JniHandleOwnership.DoNotTransfer);
			EdgeTreatment rightEdge = Java.Lang.Object.GetObject<EdgeTreatment>(native_rightEdge, JniHandleOwnership.DoNotTransfer);
			EdgeTreatment bottomEdge = Java.Lang.Object.GetObject<EdgeTreatment>(native_bottomEdge, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetEdgeTreatments(leftEdge, topEdge, rightEdge, bottomEdge);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setEdgeTreatments", "(Lcom/google/android/material/shape/EdgeTreatment;Lcom/google/android/material/shape/EdgeTreatment;Lcom/google/android/material/shape/EdgeTreatment;Lcom/google/android/material/shape/EdgeTreatment;)V", "GetSetEdgeTreatments_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Lcom_google_android_material_shape_EdgeTreatment_Handler")]
	public unsafe virtual void SetEdgeTreatments(EdgeTreatment? leftEdge, EdgeTreatment? topEdge, EdgeTreatment? rightEdge, EdgeTreatment? bottomEdge)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(leftEdge?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(topEdge?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(rightEdge?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(bottomEdge?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEdgeTreatments.(Lcom/google/android/material/shape/EdgeTreatment;Lcom/google/android/material/shape/EdgeTreatment;Lcom/google/android/material/shape/EdgeTreatment;Lcom/google/android/material/shape/EdgeTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(leftEdge);
			GC.KeepAlive(topEdge);
			GC.KeepAlive(rightEdge);
			GC.KeepAlive(bottomEdge);
		}
	}

	[Obsolete]
	private static Delegate GetSetLeftEdge_Lcom_google_android_material_shape_EdgeTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLeftEdge_Lcom_google_android_material_shape_EdgeTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLeftEdge_Lcom_google_android_material_shape_EdgeTreatment_(nint jnienv, nint native__this, nint native_leftEdge)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EdgeTreatment leftEdge = Java.Lang.Object.GetObject<EdgeTreatment>(native_leftEdge, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetLeftEdge(leftEdge);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setLeftEdge", "(Lcom/google/android/material/shape/EdgeTreatment;)V", "GetSetLeftEdge_Lcom_google_android_material_shape_EdgeTreatment_Handler")]
	public unsafe virtual void SetLeftEdge(EdgeTreatment? leftEdge)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(leftEdge?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLeftEdge.(Lcom/google/android/material/shape/EdgeTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(leftEdge);
		}
	}

	[Obsolete]
	private static Delegate GetSetRightEdge_Lcom_google_android_material_shape_EdgeTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRightEdge_Lcom_google_android_material_shape_EdgeTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRightEdge_Lcom_google_android_material_shape_EdgeTreatment_(nint jnienv, nint native__this, nint native_rightEdge)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EdgeTreatment rightEdge = Java.Lang.Object.GetObject<EdgeTreatment>(native_rightEdge, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetRightEdge(rightEdge);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setRightEdge", "(Lcom/google/android/material/shape/EdgeTreatment;)V", "GetSetRightEdge_Lcom_google_android_material_shape_EdgeTreatment_Handler")]
	public unsafe virtual void SetRightEdge(EdgeTreatment? rightEdge)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rightEdge?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRightEdge.(Lcom/google/android/material/shape/EdgeTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(rightEdge);
		}
	}

	[Obsolete]
	private static Delegate GetSetTopEdge_Lcom_google_android_material_shape_EdgeTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTopEdge_Lcom_google_android_material_shape_EdgeTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTopEdge_Lcom_google_android_material_shape_EdgeTreatment_(nint jnienv, nint native__this, nint native_topEdge)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EdgeTreatment topEdge = Java.Lang.Object.GetObject<EdgeTreatment>(native_topEdge, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetTopEdge(topEdge);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setTopEdge", "(Lcom/google/android/material/shape/EdgeTreatment;)V", "GetSetTopEdge_Lcom_google_android_material_shape_EdgeTreatment_Handler")]
	public unsafe virtual void SetTopEdge(EdgeTreatment? topEdge)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(topEdge?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTopEdge.(Lcom/google/android/material/shape/EdgeTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(topEdge);
		}
	}

	[Obsolete]
	private static Delegate GetSetTopLeftCorner_Lcom_google_android_material_shape_CornerTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTopLeftCorner_Lcom_google_android_material_shape_CornerTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTopLeftCorner_Lcom_google_android_material_shape_CornerTreatment_(nint jnienv, nint native__this, nint native_topLeftCorner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CornerTreatment topLeftCorner = Java.Lang.Object.GetObject<CornerTreatment>(native_topLeftCorner, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetTopLeftCorner(topLeftCorner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setTopLeftCorner", "(Lcom/google/android/material/shape/CornerTreatment;)V", "GetSetTopLeftCorner_Lcom_google_android_material_shape_CornerTreatment_Handler")]
	public unsafe virtual void SetTopLeftCorner(CornerTreatment? topLeftCorner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(topLeftCorner?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTopLeftCorner.(Lcom/google/android/material/shape/CornerTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(topLeftCorner);
		}
	}

	[Obsolete]
	private static Delegate GetSetTopRightCorner_Lcom_google_android_material_shape_CornerTreatment_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTopRightCorner_Lcom_google_android_material_shape_CornerTreatment_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTopRightCorner_Lcom_google_android_material_shape_CornerTreatment_(nint jnienv, nint native__this, nint native_topRightCorner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ShapePathModel? shapePathModel = Java.Lang.Object.GetObject<ShapePathModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CornerTreatment topRightCorner = Java.Lang.Object.GetObject<CornerTreatment>(native_topRightCorner, JniHandleOwnership.DoNotTransfer);
			shapePathModel.SetTopRightCorner(topRightCorner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("setTopRightCorner", "(Lcom/google/android/material/shape/CornerTreatment;)V", "GetSetTopRightCorner_Lcom_google_android_material_shape_CornerTreatment_Handler")]
	public unsafe virtual void SetTopRightCorner(CornerTreatment? topRightCorner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(topRightCorner?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTopRightCorner.(Lcom/google/android/material/shape/CornerTreatment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(topRightCorner);
		}
	}
}
