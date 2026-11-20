using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.GridLayout.Widget;

[Register("androidx/gridlayout/widget/GridLayout", DoNotGenerateAcw = true)]
public class GridLayout : ViewGroup
{
	[Register("androidx/gridlayout/widget/GridLayout$Alignment", DoNotGenerateAcw = true)]
	public abstract class Alignment : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/gridlayout/widget/GridLayout$Alignment", typeof(Alignment));

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

		protected Alignment(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	[Register("androidx/gridlayout/widget/GridLayout$Alignment", DoNotGenerateAcw = true)]
	internal class AlignmentInvoker : Alignment
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/gridlayout/widget/GridLayout$Alignment", typeof(AlignmentInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public AlignmentInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/gridlayout/widget/GridLayout$LayoutParams", DoNotGenerateAcw = true)]
	public new class LayoutParams : MarginLayoutParams
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/gridlayout/widget/GridLayout$LayoutParams", typeof(LayoutParams));

		private static Delegate? cb_setGravity_SetGravity_I_V;

		[Register("columnSpec")]
		public Spec? ColumnSpec
		{
			get
			{
				return Java.Lang.Object.GetObject<Spec>(_members.InstanceFields.GetObjectValue("columnSpec.Landroidx/gridlayout/widget/GridLayout$Spec;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("columnSpec.Landroidx/gridlayout/widget/GridLayout$Spec;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("rowSpec")]
		public Spec? RowSpec
		{
			get
			{
				return Java.Lang.Object.GetObject<Spec>(_members.InstanceFields.GetObjectValue("rowSpec.Landroidx/gridlayout/widget/GridLayout$Spec;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("rowSpec.Landroidx/gridlayout/widget/GridLayout$Spec;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

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

		protected LayoutParams(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LayoutParams()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe LayoutParams(Context? context, IAttributeSet? attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
		public unsafe LayoutParams(ViewGroup.LayoutParams? @params)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@params);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$MarginLayoutParams;)V", "")]
		public unsafe LayoutParams(MarginLayoutParams? @params)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@params);
			}
		}

		[Register(".ctor", "(Landroidx/gridlayout/widget/GridLayout$LayoutParams;)V", "")]
		public unsafe LayoutParams(LayoutParams? source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/gridlayout/widget/GridLayout$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/gridlayout/widget/GridLayout$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Landroidx/gridlayout/widget/GridLayout$Spec;Landroidx/gridlayout/widget/GridLayout$Spec;)V", "")]
		public unsafe LayoutParams(Spec? rowSpec, Spec? columnSpec)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(rowSpec?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(columnSpec?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/gridlayout/widget/GridLayout$Spec;Landroidx/gridlayout/widget/GridLayout$Spec;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/gridlayout/widget/GridLayout$Spec;Landroidx/gridlayout/widget/GridLayout$Spec;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(rowSpec);
				GC.KeepAlive(columnSpec);
			}
		}

		private static Delegate GetSetGravity_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetGravity_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetGravity_I(nint jnienv, nint native__this, int gravity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGravity(gravity);
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

		[Register("setGravity", "(I)V", "GetSetGravity_IHandler")]
		public unsafe virtual void SetGravity(int gravity)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(gravity);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGravity.(I)V", this, ptr);
		}
	}

	[Register("androidx/gridlayout/widget/GridLayout$Spec", DoNotGenerateAcw = true)]
	public class Spec : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/gridlayout/widget/GridLayout$Spec", typeof(Spec));

		private static Delegate? cb_getAbsoluteAlignment_GetAbsoluteAlignment_Z_Landroidx_gridlayout_widget_GridLayout_Alignment_;

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

		protected Spec(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetAbsoluteAlignment_ZHandler()
		{
			return new global::_JniMarshal_PPB_L(n_GetAbsoluteAlignment_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetAbsoluteAlignment_Z(nint jnienv, nint native__this, sbyte native_horizontal)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Spec? spec = Java.Lang.Object.GetObject<Spec>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool horizontal = native_horizontal != 0;
				return JNIEnv.ToLocalJniHandle(spec.GetAbsoluteAlignment(horizontal));
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

		[Register("getAbsoluteAlignment", "(Z)Landroidx/gridlayout/widget/GridLayout$Alignment;", "GetGetAbsoluteAlignment_ZHandler")]
		public unsafe virtual Alignment? GetAbsoluteAlignment(bool horizontal)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(horizontal ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<Alignment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAbsoluteAlignment.(Z)Landroidx/gridlayout/widget/GridLayout$Alignment;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/gridlayout/widget/GridLayout", typeof(GridLayout));

	private static Delegate? cb_getAlignmentMode_GetAlignmentMode_I;

	private static Delegate? cb_setAlignmentMode_SetAlignmentMode_I_V;

	private static Delegate? cb_getColumnCount_GetColumnCount_I;

	private static Delegate? cb_setColumnCount_SetColumnCount_I_V;

	private static Delegate? cb_isColumnOrderPreserved_IsColumnOrderPreserved_Z;

	private static Delegate? cb_setColumnOrderPreserved_SetColumnOrderPreserved_Z_V;

	private static Delegate? cb_getOrientation_GetOrientation_I;

	private static Delegate? cb_setOrientation_SetOrientation_I_V;

	private static Delegate? cb_getPrinter_GetPrinter_Landroid_util_Printer_;

	private static Delegate? cb_setPrinter_SetPrinter_Landroid_util_Printer__V;

	private static Delegate? cb_getRowCount_GetRowCount_I;

	private static Delegate? cb_setRowCount_SetRowCount_I_V;

	private static Delegate? cb_isRowOrderPreserved_IsRowOrderPreserved_Z;

	private static Delegate? cb_setRowOrderPreserved_SetRowOrderPreserved_Z_V;

	private static Delegate? cb_getUseDefaultMargins_GetUseDefaultMargins_Z;

	private static Delegate? cb_setUseDefaultMargins_SetUseDefaultMargins_Z_V;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	[Register("BASELINE")]
	public static Alignment? BaselineAlignment => Java.Lang.Object.GetObject<Alignment>(_members.StaticFields.GetObjectValue("BASELINE.Landroidx/gridlayout/widget/GridLayout$Alignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("BOTTOM")]
	public static Alignment? BottomAlignment => Java.Lang.Object.GetObject<Alignment>(_members.StaticFields.GetObjectValue("BOTTOM.Landroidx/gridlayout/widget/GridLayout$Alignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("CENTER")]
	public static Alignment? CenterAlignment => Java.Lang.Object.GetObject<Alignment>(_members.StaticFields.GetObjectValue("CENTER.Landroidx/gridlayout/widget/GridLayout$Alignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("END")]
	public static Alignment? EndAlignment => Java.Lang.Object.GetObject<Alignment>(_members.StaticFields.GetObjectValue("END.Landroidx/gridlayout/widget/GridLayout$Alignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("FILL")]
	public static Alignment? FillAlignment => Java.Lang.Object.GetObject<Alignment>(_members.StaticFields.GetObjectValue("FILL.Landroidx/gridlayout/widget/GridLayout$Alignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("LEFT")]
	public static Alignment? LeftAlignment => Java.Lang.Object.GetObject<Alignment>(_members.StaticFields.GetObjectValue("LEFT.Landroidx/gridlayout/widget/GridLayout$Alignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RIGHT")]
	public static Alignment? RightAlignment => Java.Lang.Object.GetObject<Alignment>(_members.StaticFields.GetObjectValue("RIGHT.Landroidx/gridlayout/widget/GridLayout$Alignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("START")]
	public static Alignment? StartAlignment => Java.Lang.Object.GetObject<Alignment>(_members.StaticFields.GetObjectValue("START.Landroidx/gridlayout/widget/GridLayout$Alignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("TOP")]
	public static Alignment? TopAlignment => Java.Lang.Object.GetObject<Alignment>(_members.StaticFields.GetObjectValue("TOP.Landroidx/gridlayout/widget/GridLayout$Alignment;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe virtual int AlignmentMode
	{
		[Register("getAlignmentMode", "()I", "GetGetAlignmentModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAlignmentMode.()I", this, null);
		}
		[Register("setAlignmentMode", "(I)V", "GetSetAlignmentMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAlignmentMode.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ColumnCount
	{
		[Register("getColumnCount", "()I", "GetGetColumnCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getColumnCount.()I", this, null);
		}
		[Register("setColumnCount", "(I)V", "GetSetColumnCount_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColumnCount.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool ColumnOrderPreserved
	{
		[Register("isColumnOrderPreserved", "()Z", "GetIsColumnOrderPreservedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isColumnOrderPreserved.()Z", this, null);
		}
		[Register("setColumnOrderPreserved", "(Z)V", "GetSetColumnOrderPreserved_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColumnOrderPreserved.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int Orientation
	{
		[Register("getOrientation", "()I", "GetGetOrientationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOrientation.()I", this, null);
		}
		[Register("setOrientation", "(I)V", "GetSetOrientation_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOrientation.(I)V", this, ptr);
		}
	}

	public unsafe virtual IPrinter? Printer
	{
		[Register("getPrinter", "()Landroid/util/Printer;", "GetGetPrinterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IPrinter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrinter.()Landroid/util/Printer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPrinter", "(Landroid/util/Printer;)V", "GetSetPrinter_Landroid_util_Printer_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPrinter.(Landroid/util/Printer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int RowCount
	{
		[Register("getRowCount", "()I", "GetGetRowCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRowCount.()I", this, null);
		}
		[Register("setRowCount", "(I)V", "GetSetRowCount_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRowCount.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool RowOrderPreserved
	{
		[Register("isRowOrderPreserved", "()Z", "GetIsRowOrderPreservedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRowOrderPreserved.()Z", this, null);
		}
		[Register("setRowOrderPreserved", "(Z)V", "GetSetRowOrderPreserved_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRowOrderPreserved.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool UseDefaultMargins
	{
		[Register("getUseDefaultMargins", "()Z", "GetGetUseDefaultMarginsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getUseDefaultMargins.()Z", this, null);
		}
		[Register("setUseDefaultMargins", "(Z)V", "GetSetUseDefaultMargins_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setUseDefaultMargins.(Z)V", this, ptr);
		}
	}

	protected GridLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe GridLayout(Context? context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe GridLayout(Context? context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe GridLayout(Context? context, IAttributeSet? attrs, int defStyle)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetGetAlignmentModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetAlignmentMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAlignmentMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlignmentMode;
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

	private static Delegate GetSetAlignmentMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetAlignmentMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAlignmentMode_I(nint jnienv, nint native__this, int alignmentMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlignmentMode = alignmentMode;
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

	private static Delegate GetGetColumnCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetColumnCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetColumnCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnCount;
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

	private static Delegate GetSetColumnCount_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetColumnCount_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColumnCount_I(nint jnienv, nint native__this, int columnCount)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnCount = columnCount;
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

	private static Delegate GetIsColumnOrderPreservedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsColumnOrderPreserved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsColumnOrderPreserved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnOrderPreserved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetColumnOrderPreserved_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetColumnOrderPreserved_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColumnOrderPreserved_Z(nint jnienv, nint native__this, sbyte native_columnOrderPreserved)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GridLayout? gridLayout = Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool columnOrderPreserved = native_columnOrderPreserved != 0;
			gridLayout.ColumnOrderPreserved = columnOrderPreserved;
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

	private static Delegate GetGetOrientationHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOrientation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOrientation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation;
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

	private static Delegate GetSetOrientation_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetOrientation_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOrientation_I(nint jnienv, nint native__this, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation = orientation;
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

	private static Delegate GetGetPrinterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPrinter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPrinter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Printer);
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

	private static Delegate GetSetPrinter_Landroid_util_Printer_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPrinter_Landroid_util_Printer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPrinter_Landroid_util_Printer_(nint jnienv, nint native__this, nint native_printer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GridLayout? gridLayout = Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IPrinter printer = Java.Lang.Object.GetObject<IPrinter>(native_printer, JniHandleOwnership.DoNotTransfer);
			gridLayout.Printer = printer;
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

	private static Delegate GetGetRowCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRowCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRowCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RowCount;
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

	private static Delegate GetSetRowCount_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetRowCount_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRowCount_I(nint jnienv, nint native__this, int rowCount)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RowCount = rowCount;
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

	private static Delegate GetIsRowOrderPreservedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsRowOrderPreserved);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRowOrderPreserved(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RowOrderPreserved ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetRowOrderPreserved_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetRowOrderPreserved_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRowOrderPreserved_Z(nint jnienv, nint native__this, sbyte native_rowOrderPreserved)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GridLayout? gridLayout = Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool rowOrderPreserved = native_rowOrderPreserved != 0;
			gridLayout.RowOrderPreserved = rowOrderPreserved;
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

	private static Delegate GetGetUseDefaultMarginsHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetUseDefaultMargins);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetUseDefaultMargins(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseDefaultMargins ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetUseDefaultMargins_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUseDefaultMargins_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUseDefaultMargins_Z(nint jnienv, nint native__this, sbyte native_useDefaultMargins)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GridLayout? gridLayout = Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool useDefaultMargins = native_useDefaultMargins != 0;
			gridLayout.UseDefaultMargins = useDefaultMargins;
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

	private static Delegate GetOnLayout_ZIIIIHandler()
	{
		return new global::_JniMarshal_PPBIIII_V(n_OnLayout_ZIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLayout_ZIIII(nint jnienv, nint native__this, sbyte native_changed, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GridLayout? gridLayout = Java.Lang.Object.GetObject<GridLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			gridLayout.OnLayout(changed, left, top, right, bottom);
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

	[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
	protected unsafe override void OnLayout(bool changed, int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(left);
		ptr[2] = new JniArgumentValue(top);
		ptr[3] = new JniArgumentValue(right);
		ptr[4] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}

	[Register("spec", "(I)Landroidx/gridlayout/widget/GridLayout$Spec;", "")]
	public unsafe static Spec? InvokeSpec(int start)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(start);
		return Java.Lang.Object.GetObject<Spec>(_members.StaticMethods.InvokeObjectMethod("spec.(I)Landroidx/gridlayout/widget/GridLayout$Spec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("spec", "(ILandroidx/gridlayout/widget/GridLayout$Alignment;)Landroidx/gridlayout/widget/GridLayout$Spec;", "")]
	public unsafe static Spec? InvokeSpec(int start, Alignment? alignment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(alignment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Spec>(_members.StaticMethods.InvokeObjectMethod("spec.(ILandroidx/gridlayout/widget/GridLayout$Alignment;)Landroidx/gridlayout/widget/GridLayout$Spec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(alignment);
		}
	}

	[Register("spec", "(ILandroidx/gridlayout/widget/GridLayout$Alignment;F)Landroidx/gridlayout/widget/GridLayout$Spec;", "")]
	public unsafe static Spec? InvokeSpec(int start, Alignment? alignment, float weight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(alignment?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(weight);
			return Java.Lang.Object.GetObject<Spec>(_members.StaticMethods.InvokeObjectMethod("spec.(ILandroidx/gridlayout/widget/GridLayout$Alignment;F)Landroidx/gridlayout/widget/GridLayout$Spec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(alignment);
		}
	}

	[Register("spec", "(IF)Landroidx/gridlayout/widget/GridLayout$Spec;", "")]
	public unsafe static Spec? InvokeSpec(int start, float weight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(weight);
		return Java.Lang.Object.GetObject<Spec>(_members.StaticMethods.InvokeObjectMethod("spec.(IF)Landroidx/gridlayout/widget/GridLayout$Spec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("spec", "(II)Landroidx/gridlayout/widget/GridLayout$Spec;", "")]
	public unsafe static Spec? InvokeSpec(int start, int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(size);
		return Java.Lang.Object.GetObject<Spec>(_members.StaticMethods.InvokeObjectMethod("spec.(II)Landroidx/gridlayout/widget/GridLayout$Spec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("spec", "(IILandroidx/gridlayout/widget/GridLayout$Alignment;)Landroidx/gridlayout/widget/GridLayout$Spec;", "")]
	public unsafe static Spec? InvokeSpec(int start, int size, Alignment? alignment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(size);
			ptr[2] = new JniArgumentValue(alignment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Spec>(_members.StaticMethods.InvokeObjectMethod("spec.(IILandroidx/gridlayout/widget/GridLayout$Alignment;)Landroidx/gridlayout/widget/GridLayout$Spec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(alignment);
		}
	}

	[Register("spec", "(IILandroidx/gridlayout/widget/GridLayout$Alignment;F)Landroidx/gridlayout/widget/GridLayout$Spec;", "")]
	public unsafe static Spec? InvokeSpec(int start, int size, Alignment? alignment, float weight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(size);
			ptr[2] = new JniArgumentValue(alignment?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(weight);
			return Java.Lang.Object.GetObject<Spec>(_members.StaticMethods.InvokeObjectMethod("spec.(IILandroidx/gridlayout/widget/GridLayout$Alignment;F)Landroidx/gridlayout/widget/GridLayout$Spec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(alignment);
		}
	}

	[Register("spec", "(IIF)Landroidx/gridlayout/widget/GridLayout$Spec;", "")]
	public unsafe static Spec? InvokeSpec(int start, int size, float weight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(size);
		ptr[2] = new JniArgumentValue(weight);
		return Java.Lang.Object.GetObject<Spec>(_members.StaticMethods.InvokeObjectMethod("spec.(IIF)Landroidx/gridlayout/widget/GridLayout$Spec;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
