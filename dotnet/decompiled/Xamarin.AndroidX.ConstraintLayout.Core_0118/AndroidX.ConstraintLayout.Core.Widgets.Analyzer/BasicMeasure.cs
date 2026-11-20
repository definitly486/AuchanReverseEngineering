using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

[Register("androidx/constraintlayout/core/widgets/analyzer/BasicMeasure", DoNotGenerateAcw = true)]
public class BasicMeasure : Java.Lang.Object
{
	[Register("androidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measure", DoNotGenerateAcw = true)]
	public class Measure : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measure", typeof(Measure));

		[Register("horizontalBehavior")]
		public ConstraintWidget.DimensionBehaviour? HorizontalBehavior
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(_members.InstanceFields.GetObjectValue("horizontalBehavior.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("horizontalBehavior.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("horizontalDimension")]
		public int HorizontalDimension
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("horizontalDimension.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("horizontalDimension.I", this, value);
			}
		}

		[Register("measuredBaseline")]
		public int MeasuredBaseline
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("measuredBaseline.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuredBaseline.I", this, value);
			}
		}

		[Register("measuredHasBaseline")]
		public bool MeasuredHasBaseline
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("measuredHasBaseline.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuredHasBaseline.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("measuredHeight")]
		public int MeasuredHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("measuredHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuredHeight.I", this, value);
			}
		}

		[Register("measuredNeedsSolverPass")]
		public bool MeasuredNeedsSolverPass
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("measuredNeedsSolverPass.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuredNeedsSolverPass.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("measuredWidth")]
		public int MeasuredWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("measuredWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuredWidth.I", this, value);
			}
		}

		[Register("measureStrategy")]
		public int MeasureStrategy
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("measureStrategy.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measureStrategy.I", this, value);
			}
		}

		[Register("SELF_DIMENSIONS")]
		public static int SelfDimensions
		{
			get
			{
				return _members.StaticFields.GetInt32Value("SELF_DIMENSIONS.I");
			}
			set
			{
				_members.StaticFields.SetValue("SELF_DIMENSIONS.I", value);
			}
		}

		[Register("TRY_GIVEN_DIMENSIONS")]
		public static int TryGivenDimensions
		{
			get
			{
				return _members.StaticFields.GetInt32Value("TRY_GIVEN_DIMENSIONS.I");
			}
			set
			{
				_members.StaticFields.SetValue("TRY_GIVEN_DIMENSIONS.I", value);
			}
		}

		[Register("USE_GIVEN_DIMENSIONS")]
		public static int UseGivenDimensions
		{
			get
			{
				return _members.StaticFields.GetInt32Value("USE_GIVEN_DIMENSIONS.I");
			}
			set
			{
				_members.StaticFields.SetValue("USE_GIVEN_DIMENSIONS.I", value);
			}
		}

		[Register("verticalBehavior")]
		public ConstraintWidget.DimensionBehaviour? VerticalBehavior
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(_members.InstanceFields.GetObjectValue("verticalBehavior.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("verticalBehavior.Landroidx/constraintlayout/core/widgets/ConstraintWidget$DimensionBehaviour;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("verticalDimension")]
		public int VerticalDimension
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("verticalDimension.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("verticalDimension.I", this, value);
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

		protected Measure(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Measure()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}

	[Register("androidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer", "", "AndroidX.ConstraintLayout.Core.Widgets.Analyzer.BasicMeasure/IMeasurerInvoker")]
	public interface IMeasurer : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("didMeasures", "()V", "GetDidMeasuresHandler:AndroidX.ConstraintLayout.Core.Widgets.Analyzer.BasicMeasure/IMeasurerInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		void DidMeasures();

		[Register("measure", "(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measure;)V", "GetMeasure_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measure_Handler:AndroidX.ConstraintLayout.Core.Widgets.Analyzer.BasicMeasure/IMeasurerInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
		void Measure(ConstraintWidget? p0, Measure? p1);
	}

	[Register("androidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer", DoNotGenerateAcw = true)]
	internal class IMeasurerInvoker : Java.Lang.Object, IMeasurer, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measurer", typeof(IMeasurerInvoker));

		private static Delegate? cb_didMeasures_DidMeasures_V;

		private static Delegate? cb_measure_Measure_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measure__V;

		private static nint java_class_ref => _members_androidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer.ManagedPeerType;

		public IMeasurerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetDidMeasuresHandler()
		{
			return new global::_JniMarshal_PP_V(n_DidMeasures);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_DidMeasures(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IMeasurer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DidMeasures();
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

		public unsafe void DidMeasures()
		{
			_members_androidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer.InstanceMethods.InvokeAbstractVoidMethod("didMeasures.()V", this, null);
		}

		private static Delegate GetMeasure_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measure_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_Measure_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measure_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Measure_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measure_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IMeasurer? measurer = Java.Lang.Object.GetObject<IMeasurer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ConstraintWidget p = Java.Lang.Object.GetObject<ConstraintWidget>(native_p0, JniHandleOwnership.DoNotTransfer);
				Measure p2 = Java.Lang.Object.GetObject<Measure>(native_p1, JniHandleOwnership.DoNotTransfer);
				measurer.Measure(p, p2);
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

		public unsafe void Measure(ConstraintWidget? p0, Measure? p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members_androidx_constraintlayout_core_widgets_analyzer_BasicMeasure_Measurer.InstanceMethods.InvokeAbstractVoidMethod("measure.(Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/core/widgets/analyzer/BasicMeasure$Measure;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/widgets/analyzer/BasicMeasure", typeof(BasicMeasure));

	private static Delegate? cb_solverMeasure_SolverMeasure_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIIIIIIII_J;

	private static Delegate? cb_updateHierarchy_UpdateHierarchy_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer__V;

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

	protected BasicMeasure(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", "")]
	public unsafe BasicMeasure(ConstraintWidgetContainer? constraintWidgetContainer)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraintWidgetContainer?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintWidgetContainer);
		}
	}

	private static Delegate GetSolverMeasure_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIIIIIIIIHandler()
	{
		return new _JniMarshal_PPLIIIIIIIII_J(n_SolverMeasure_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIIIIIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_SolverMeasure_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIIIIIIII(nint jnienv, nint native__this, nint native_layout, int optimizationLevel, int paddingX, int paddingY, int widthMode, int widthSize, int heightMode, int heightSize, int lastMeasureWidth, int lastMeasureHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			BasicMeasure? basicMeasure = Java.Lang.Object.GetObject<BasicMeasure>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer layout = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_layout, JniHandleOwnership.DoNotTransfer);
			return basicMeasure.SolverMeasure(layout, optimizationLevel, paddingX, paddingY, widthMode, widthSize, heightMode, heightSize, lastMeasureWidth, lastMeasureHeight);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("solverMeasure", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;IIIIIIIII)J", "GetSolverMeasure_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIIIIIIIIHandler")]
	public unsafe virtual long SolverMeasure(ConstraintWidgetContainer? layout, int optimizationLevel, int paddingX, int paddingY, int widthMode, int widthSize, int heightMode, int heightSize, int lastMeasureWidth, int lastMeasureHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
			*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(optimizationLevel);
			ptr[2] = new JniArgumentValue(paddingX);
			ptr[3] = new JniArgumentValue(paddingY);
			ptr[4] = new JniArgumentValue(widthMode);
			ptr[5] = new JniArgumentValue(widthSize);
			ptr[6] = new JniArgumentValue(heightMode);
			ptr[7] = new JniArgumentValue(heightSize);
			ptr[8] = new JniArgumentValue(lastMeasureWidth);
			ptr[9] = new JniArgumentValue(lastMeasureHeight);
			return _members.InstanceMethods.InvokeVirtualInt64Method("solverMeasure.(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;IIIIIIIII)J", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layout);
		}
	}

	private static Delegate GetUpdateHierarchy_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateHierarchy_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateHierarchy_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_(nint jnienv, nint native__this, nint native_layout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BasicMeasure? basicMeasure = Java.Lang.Object.GetObject<BasicMeasure>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer layout = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_layout, JniHandleOwnership.DoNotTransfer);
			basicMeasure.UpdateHierarchy(layout);
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

	[Register("updateHierarchy", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", "GetUpdateHierarchy_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_Handler")]
	public unsafe virtual void UpdateHierarchy(ConstraintWidgetContainer? layout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateHierarchy.(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layout);
		}
	}
}
