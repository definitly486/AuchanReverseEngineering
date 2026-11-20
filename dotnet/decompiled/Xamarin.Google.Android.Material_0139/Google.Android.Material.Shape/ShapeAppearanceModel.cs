using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Shape;

[Register("com/google/android/material/shape/ShapeAppearanceModel", DoNotGenerateAcw = true)]
public class ShapeAppearanceModel : Java.Lang.Object
{
	[Register("com/google/android/material/shape/ShapeAppearanceModel$Builder", DoNotGenerateAcw = true)]
	public sealed class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/ShapeAppearanceModel$Builder", typeof(Builder));

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Builder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", "")]
		public unsafe Builder(ShapeAppearanceModel other)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register("build", "()Lcom/google/android/material/shape/ShapeAppearanceModel;", "")]
		public unsafe ShapeAppearanceModel Build()
		{
			return Java.Lang.Object.GetObject<ShapeAppearanceModel>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/google/android/material/shape/ShapeAppearanceModel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setAllCornerSizes", "(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetAllCornerSizes(ICornerSize cornerSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAllCornerSizes.(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerSize);
			}
		}

		[Register("setAllCornerSizes", "(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetAllCornerSizes(float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAllCornerSizes.(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setAllCorners", "(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetAllCorners(CornerTreatment cornerTreatment)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cornerTreatment?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAllCorners.(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerTreatment);
			}
		}

		[Register("setAllCorners", "(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetAllCorners(int cornerFamily, float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(cornerFamily);
			ptr[1] = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAllCorners.(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setAllEdges", "(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetAllEdges(EdgeTreatment edgeTreatment)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(edgeTreatment?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAllEdges.(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(edgeTreatment);
			}
		}

		[Register("setBottomEdge", "(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomEdge(EdgeTreatment bottomEdge)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bottomEdge?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomEdge.(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(bottomEdge);
			}
		}

		[Register("setBottomLeftCorner", "(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomLeftCorner(CornerTreatment bottomLeftCorner)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bottomLeftCorner?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomLeftCorner.(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(bottomLeftCorner);
			}
		}

		[Register("setBottomLeftCorner", "(ILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomLeftCorner(int cornerFamily, ICornerSize cornerSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(cornerFamily);
				ptr[1] = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomLeftCorner.(ILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerSize);
			}
		}

		[Register("setBottomLeftCorner", "(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomLeftCorner(int cornerFamily, float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(cornerFamily);
			ptr[1] = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomLeftCorner.(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setBottomLeftCornerSize", "(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomLeftCornerSize(ICornerSize cornerSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomLeftCornerSize.(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerSize);
			}
		}

		[Register("setBottomLeftCornerSize", "(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomLeftCornerSize(float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomLeftCornerSize.(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setBottomRightCorner", "(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomRightCorner(CornerTreatment bottomRightCorner)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bottomRightCorner?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomRightCorner.(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(bottomRightCorner);
			}
		}

		[Register("setBottomRightCorner", "(ILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomRightCorner(int cornerFamily, ICornerSize cornerSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(cornerFamily);
				ptr[1] = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomRightCorner.(ILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerSize);
			}
		}

		[Register("setBottomRightCorner", "(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomRightCorner(int cornerFamily, float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(cornerFamily);
			ptr[1] = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomRightCorner.(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setBottomRightCornerSize", "(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomRightCornerSize(ICornerSize cornerSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomRightCornerSize.(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerSize);
			}
		}

		[Register("setBottomRightCornerSize", "(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetBottomRightCornerSize(float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBottomRightCornerSize.(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setLeftEdge", "(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetLeftEdge(EdgeTreatment leftEdge)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(leftEdge?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLeftEdge.(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(leftEdge);
			}
		}

		[Register("setRightEdge", "(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetRightEdge(EdgeTreatment rightEdge)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(rightEdge?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setRightEdge.(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(rightEdge);
			}
		}

		[Register("setTopEdge", "(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopEdge(EdgeTreatment topEdge)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(topEdge?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopEdge.(Lcom/google/android/material/shape/EdgeTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(topEdge);
			}
		}

		[Register("setTopLeftCorner", "(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopLeftCorner(CornerTreatment topLeftCorner)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(topLeftCorner?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopLeftCorner.(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(topLeftCorner);
			}
		}

		[Register("setTopLeftCorner", "(ILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopLeftCorner(int cornerFamily, ICornerSize cornerSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(cornerFamily);
				ptr[1] = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopLeftCorner.(ILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerSize);
			}
		}

		[Register("setTopLeftCorner", "(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopLeftCorner(int cornerFamily, float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(cornerFamily);
			ptr[1] = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopLeftCorner.(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setTopLeftCornerSize", "(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopLeftCornerSize(ICornerSize cornerSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopLeftCornerSize.(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerSize);
			}
		}

		[Register("setTopLeftCornerSize", "(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopLeftCornerSize(float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopLeftCornerSize.(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setTopRightCorner", "(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopRightCorner(CornerTreatment topRightCorner)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(topRightCorner?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopRightCorner.(Lcom/google/android/material/shape/CornerTreatment;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(topRightCorner);
			}
		}

		[Register("setTopRightCorner", "(ILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopRightCorner(int cornerFamily, ICornerSize cornerSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(cornerFamily);
				ptr[1] = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopRightCorner.(ILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerSize);
			}
		}

		[Register("setTopRightCorner", "(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopRightCorner(int cornerFamily, float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(cornerFamily);
			ptr[1] = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopRightCorner.(IF)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setTopRightCornerSize", "(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopRightCornerSize(ICornerSize cornerSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopRightCornerSize.(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cornerSize);
			}
		}

		[Register("setTopRightCornerSize", "(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
		public unsafe Builder SetTopRightCornerSize(float cornerSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTopRightCornerSize.(F)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("com/google/android/material/shape/ShapeAppearanceModel$CornerSizeUnaryOperator", "", "Google.Android.Material.Shape.ShapeAppearanceModel/ICornerSizeUnaryOperatorInvoker")]
	public interface ICornerSizeUnaryOperator : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("apply", "(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/CornerSize;", "GetApply_Lcom_google_android_material_shape_CornerSize_Handler:Google.Android.Material.Shape.ShapeAppearanceModel/ICornerSizeUnaryOperatorInvoker, Xamarin.Google.Android.Material")]
		ICornerSize Apply(ICornerSize p0);
	}

	[Register("com/google/android/material/shape/ShapeAppearanceModel$CornerSizeUnaryOperator", DoNotGenerateAcw = true)]
	internal class ICornerSizeUnaryOperatorInvoker : Java.Lang.Object, ICornerSizeUnaryOperator, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator = new XAPeerMembers("com/google/android/material/shape/ShapeAppearanceModel$CornerSizeUnaryOperator", typeof(ICornerSizeUnaryOperatorInvoker));

		private static Delegate? cb_apply_Apply_Lcom_google_android_material_shape_CornerSize__Lcom_google_android_material_shape_CornerSize_;

		private static nint java_class_ref => _members_com_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator.ManagedPeerType;

		public ICornerSizeUnaryOperatorInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetApply_Lcom_google_android_material_shape_CornerSize_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_Apply_Lcom_google_android_material_shape_CornerSize_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Apply_Lcom_google_android_material_shape_CornerSize_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICornerSizeUnaryOperator? cornerSizeUnaryOperator = Java.Lang.Object.GetObject<ICornerSizeUnaryOperator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICornerSize p = Java.Lang.Object.GetObject<ICornerSize>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(cornerSizeUnaryOperator.Apply(p));
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe ICornerSize Apply(ICornerSize p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<ICornerSize>(_members_com_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator.InstanceMethods.InvokeAbstractObjectMethod("apply.(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/CornerSize;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/ShapeAppearanceModel", typeof(ShapeAppearanceModel));

	private static Delegate? cb_getBottomEdge_GetBottomEdge_Lcom_google_android_material_shape_EdgeTreatment_;

	private static Delegate? cb_getBottomLeftCorner_GetBottomLeftCorner_Lcom_google_android_material_shape_CornerTreatment_;

	private static Delegate? cb_getBottomLeftCornerSize_GetBottomLeftCornerSize_Lcom_google_android_material_shape_CornerSize_;

	private static Delegate? cb_getBottomRightCorner_GetBottomRightCorner_Lcom_google_android_material_shape_CornerTreatment_;

	private static Delegate? cb_getBottomRightCornerSize_GetBottomRightCornerSize_Lcom_google_android_material_shape_CornerSize_;

	private static Delegate? cb_getLeftEdge_GetLeftEdge_Lcom_google_android_material_shape_EdgeTreatment_;

	private static Delegate? cb_getRightEdge_GetRightEdge_Lcom_google_android_material_shape_EdgeTreatment_;

	private static Delegate? cb_getTopEdge_GetTopEdge_Lcom_google_android_material_shape_EdgeTreatment_;

	private static Delegate? cb_getTopLeftCorner_GetTopLeftCorner_Lcom_google_android_material_shape_CornerTreatment_;

	private static Delegate? cb_getTopLeftCornerSize_GetTopLeftCornerSize_Lcom_google_android_material_shape_CornerSize_;

	private static Delegate? cb_getTopRightCorner_GetTopRightCorner_Lcom_google_android_material_shape_CornerTreatment_;

	private static Delegate? cb_getTopRightCornerSize_GetTopRightCornerSize_Lcom_google_android_material_shape_CornerSize_;

	private static Delegate? cb_isRoundRect_IsRoundRect_Landroid_graphics_RectF__Z;

	private static Delegate? cb_toBuilder_ToBuilder_Lcom_google_android_material_shape_ShapeAppearanceModel_Builder_;

	private static Delegate? cb_withCornerSize_WithCornerSize_Lcom_google_android_material_shape_CornerSize__Lcom_google_android_material_shape_ShapeAppearanceModel_;

	private static Delegate? cb_withCornerSize_WithCornerSize_F_Lcom_google_android_material_shape_ShapeAppearanceModel_;

	private static Delegate? cb_withTransformedCornerSizes_WithTransformedCornerSizes_Lcom_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator__Lcom_google_android_material_shape_ShapeAppearanceModel_;

	[Register("PILL")]
	public static ICornerSize? Pill => Java.Lang.Object.GetObject<ICornerSize>(_members.StaticFields.GetObjectValue("PILL.Lcom/google/android/material/shape/CornerSize;").Handle, JniHandleOwnership.TransferLocalRef);

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual EdgeTreatment BottomEdge
	{
		[Register("getBottomEdge", "()Lcom/google/android/material/shape/EdgeTreatment;", "GetGetBottomEdgeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<EdgeTreatment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBottomEdge.()Lcom/google/android/material/shape/EdgeTreatment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual CornerTreatment BottomLeftCorner
	{
		[Register("getBottomLeftCorner", "()Lcom/google/android/material/shape/CornerTreatment;", "GetGetBottomLeftCornerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CornerTreatment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBottomLeftCorner.()Lcom/google/android/material/shape/CornerTreatment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICornerSize BottomLeftCornerSize
	{
		[Register("getBottomLeftCornerSize", "()Lcom/google/android/material/shape/CornerSize;", "GetGetBottomLeftCornerSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICornerSize>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBottomLeftCornerSize.()Lcom/google/android/material/shape/CornerSize;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual CornerTreatment BottomRightCorner
	{
		[Register("getBottomRightCorner", "()Lcom/google/android/material/shape/CornerTreatment;", "GetGetBottomRightCornerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CornerTreatment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBottomRightCorner.()Lcom/google/android/material/shape/CornerTreatment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICornerSize BottomRightCornerSize
	{
		[Register("getBottomRightCornerSize", "()Lcom/google/android/material/shape/CornerSize;", "GetGetBottomRightCornerSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICornerSize>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBottomRightCornerSize.()Lcom/google/android/material/shape/CornerSize;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual EdgeTreatment LeftEdge
	{
		[Register("getLeftEdge", "()Lcom/google/android/material/shape/EdgeTreatment;", "GetGetLeftEdgeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<EdgeTreatment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLeftEdge.()Lcom/google/android/material/shape/EdgeTreatment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual EdgeTreatment RightEdge
	{
		[Register("getRightEdge", "()Lcom/google/android/material/shape/EdgeTreatment;", "GetGetRightEdgeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<EdgeTreatment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRightEdge.()Lcom/google/android/material/shape/EdgeTreatment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual EdgeTreatment TopEdge
	{
		[Register("getTopEdge", "()Lcom/google/android/material/shape/EdgeTreatment;", "GetGetTopEdgeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<EdgeTreatment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTopEdge.()Lcom/google/android/material/shape/EdgeTreatment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual CornerTreatment TopLeftCorner
	{
		[Register("getTopLeftCorner", "()Lcom/google/android/material/shape/CornerTreatment;", "GetGetTopLeftCornerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CornerTreatment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTopLeftCorner.()Lcom/google/android/material/shape/CornerTreatment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICornerSize TopLeftCornerSize
	{
		[Register("getTopLeftCornerSize", "()Lcom/google/android/material/shape/CornerSize;", "GetGetTopLeftCornerSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICornerSize>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTopLeftCornerSize.()Lcom/google/android/material/shape/CornerSize;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual CornerTreatment TopRightCorner
	{
		[Register("getTopRightCorner", "()Lcom/google/android/material/shape/CornerTreatment;", "GetGetTopRightCornerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CornerTreatment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTopRightCorner.()Lcom/google/android/material/shape/CornerTreatment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICornerSize TopRightCornerSize
	{
		[Register("getTopRightCornerSize", "()Lcom/google/android/material/shape/CornerSize;", "GetGetTopRightCornerSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICornerSize>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTopRightCornerSize.()Lcom/google/android/material/shape/CornerSize;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ShapeAppearanceModel(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ShapeAppearanceModel()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetBottomEdgeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBottomEdge);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBottomEdge(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomEdge);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBottomLeftCornerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBottomLeftCorner);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBottomLeftCorner(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomLeftCorner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBottomLeftCornerSizeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBottomLeftCornerSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBottomLeftCornerSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomLeftCornerSize);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBottomRightCornerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBottomRightCorner);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBottomRightCorner(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomRightCorner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBottomRightCornerSizeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBottomRightCornerSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBottomRightCornerSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomRightCornerSize);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetLeftEdgeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLeftEdge);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLeftEdge(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LeftEdge);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetRightEdgeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRightEdge);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRightEdge(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RightEdge);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTopEdgeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTopEdge);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTopEdge(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopEdge);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTopLeftCornerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTopLeftCorner);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTopLeftCorner(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopLeftCorner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTopLeftCornerSizeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTopLeftCornerSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTopLeftCornerSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopLeftCornerSize);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTopRightCornerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTopRightCorner);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTopRightCorner(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopRightCorner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTopRightCornerSizeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTopRightCornerSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTopRightCornerSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopRightCornerSize);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("builder", "()Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
	public unsafe static Builder InvokeBuilder()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.()Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("builder", "(Landroid/content/Context;Landroid/util/AttributeSet;II)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
	public unsafe static Builder InvokeBuilder(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.(Landroid/content/Context;Landroid/util/AttributeSet;II)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register("builder", "(Landroid/content/Context;Landroid/util/AttributeSet;IILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
	public unsafe static Builder InvokeBuilder(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes, ICornerSize defaultCornerSize)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			ptr[4] = new JniArgumentValue((defaultCornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)defaultCornerSize).Handle);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.(Landroid/content/Context;Landroid/util/AttributeSet;IILcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
			GC.KeepAlive(defaultCornerSize);
		}
	}

	[Register("builder", "(Landroid/content/Context;Landroid/util/AttributeSet;III)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
	public unsafe static Builder InvokeBuilder(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes, int defaultCornerSize)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			ptr[4] = new JniArgumentValue(defaultCornerSize);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.(Landroid/content/Context;Landroid/util/AttributeSet;III)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register("builder", "(Landroid/content/Context;II)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "")]
	public unsafe static Builder InvokeBuilder(Context? context, int shapeAppearanceResId, int shapeAppearanceOverlayResId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(shapeAppearanceResId);
			ptr[2] = new JniArgumentValue(shapeAppearanceOverlayResId);
			return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.(Landroid/content/Context;II)Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetIsRoundRect_Landroid_graphics_RectF_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsRoundRect_Landroid_graphics_RectF_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRoundRect_Landroid_graphics_RectF_(nint jnienv, nint native__this, nint native_bounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ShapeAppearanceModel? shapeAppearanceModel = Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RectF bounds = Java.Lang.Object.GetObject<RectF>(native_bounds, JniHandleOwnership.DoNotTransfer);
			return shapeAppearanceModel.IsRoundRect(bounds) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isRoundRect", "(Landroid/graphics/RectF;)Z", "GetIsRoundRect_Landroid_graphics_RectF_Handler")]
	public unsafe virtual bool IsRoundRect(RectF bounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRoundRect.(Landroid/graphics/RectF;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bounds);
		}
	}

	private static Delegate GetToBuilderHandler()
	{
		return new global::_JniMarshal_PP_L(n_ToBuilder);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToBuilder(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToBuilder());
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("toBuilder", "()Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", "GetToBuilderHandler")]
	public unsafe virtual Builder ToBuilder()
	{
		return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("toBuilder.()Lcom/google/android/material/shape/ShapeAppearanceModel$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithCornerSize_Lcom_google_android_material_shape_CornerSize_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_WithCornerSize_Lcom_google_android_material_shape_CornerSize_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_WithCornerSize_Lcom_google_android_material_shape_CornerSize_(nint jnienv, nint native__this, nint native_cornerSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ShapeAppearanceModel? shapeAppearanceModel = Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICornerSize cornerSize = Java.Lang.Object.GetObject<ICornerSize>(native_cornerSize, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(shapeAppearanceModel.WithCornerSize(cornerSize));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("withCornerSize", "(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel;", "GetWithCornerSize_Lcom_google_android_material_shape_CornerSize_Handler")]
	public unsafe virtual ShapeAppearanceModel WithCornerSize(ICornerSize cornerSize)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
			return Java.Lang.Object.GetObject<ShapeAppearanceModel>(_members.InstanceMethods.InvokeVirtualObjectMethod("withCornerSize.(Lcom/google/android/material/shape/CornerSize;)Lcom/google/android/material/shape/ShapeAppearanceModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cornerSize);
		}
	}

	private static Delegate GetWithCornerSize_FHandler()
	{
		return new global::_JniMarshal_PPF_L(n_WithCornerSize_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_WithCornerSize_F(nint jnienv, nint native__this, float cornerSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithCornerSize(cornerSize));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("withCornerSize", "(F)Lcom/google/android/material/shape/ShapeAppearanceModel;", "GetWithCornerSize_FHandler")]
	public unsafe virtual ShapeAppearanceModel WithCornerSize(float cornerSize)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(cornerSize);
		return Java.Lang.Object.GetObject<ShapeAppearanceModel>(_members.InstanceMethods.InvokeVirtualObjectMethod("withCornerSize.(F)Lcom/google/android/material/shape/ShapeAppearanceModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithTransformedCornerSizes_Lcom_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_WithTransformedCornerSizes_Lcom_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_WithTransformedCornerSizes_Lcom_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator_(nint jnienv, nint native__this, nint native_op)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ShapeAppearanceModel? shapeAppearanceModel = Java.Lang.Object.GetObject<ShapeAppearanceModel>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICornerSizeUnaryOperator op = Java.Lang.Object.GetObject<ICornerSizeUnaryOperator>(native_op, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(shapeAppearanceModel.WithTransformedCornerSizes(op));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("withTransformedCornerSizes", "(Lcom/google/android/material/shape/ShapeAppearanceModel$CornerSizeUnaryOperator;)Lcom/google/android/material/shape/ShapeAppearanceModel;", "GetWithTransformedCornerSizes_Lcom_google_android_material_shape_ShapeAppearanceModel_CornerSizeUnaryOperator_Handler")]
	public unsafe virtual ShapeAppearanceModel WithTransformedCornerSizes(ICornerSizeUnaryOperator op)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((op == null) ? IntPtr.Zero : ((Java.Lang.Object)op).Handle);
			return Java.Lang.Object.GetObject<ShapeAppearanceModel>(_members.InstanceMethods.InvokeVirtualObjectMethod("withTransformedCornerSizes.(Lcom/google/android/material/shape/ShapeAppearanceModel$CornerSizeUnaryOperator;)Lcom/google/android/material/shape/ShapeAppearanceModel;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(op);
		}
	}
}
