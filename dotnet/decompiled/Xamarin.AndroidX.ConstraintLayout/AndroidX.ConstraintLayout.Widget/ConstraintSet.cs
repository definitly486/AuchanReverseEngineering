using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.ConstraintLayout.Core.Widgets;
using AndroidX.ConstraintLayout.Motion.Widget;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Widget;

[Register("androidx/constraintlayout/widget/ConstraintSet", DoNotGenerateAcw = true)]
public class ConstraintSet : Java.Lang.Object
{
	[Register("androidx/constraintlayout/widget/ConstraintSet$Constraint", DoNotGenerateAcw = true)]
	public class Constraint : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$Constraint", typeof(Constraint));

		private static Delegate? cb_applyDelta_ApplyDelta_Landroidx_constraintlayout_widget_ConstraintSet_Constraint__V;

		private static Delegate? cb_applyTo_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams__V;

		private static Delegate? cb_clone_Clone_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_;

		private static Delegate? cb_printDelta_PrintDelta_Ljava_lang_String__V;

		[Register("layout")]
		public Layout? Layout
		{
			get
			{
				return Java.Lang.Object.GetObject<Layout>(_members.InstanceFields.GetObjectValue("layout.Landroidx/constraintlayout/widget/ConstraintSet$Layout;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("layout.Landroidx/constraintlayout/widget/ConstraintSet$Layout;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("mCustomConstraints")]
		public IDictionary? MCustomConstraints
		{
			get
			{
				return JavaDictionary.FromJniHandle(_members.InstanceFields.GetObjectValue("mCustomConstraints.Ljava/util/HashMap;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JavaDictionary.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mCustomConstraints.Ljava/util/HashMap;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("motion")]
		public Motion? Motion
		{
			get
			{
				return Java.Lang.Object.GetObject<Motion>(_members.InstanceFields.GetObjectValue("motion.Landroidx/constraintlayout/widget/ConstraintSet$Motion;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("motion.Landroidx/constraintlayout/widget/ConstraintSet$Motion;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("propertySet")]
		public PropertySet? PropertySet
		{
			get
			{
				return Java.Lang.Object.GetObject<PropertySet>(_members.InstanceFields.GetObjectValue("propertySet.Landroidx/constraintlayout/widget/ConstraintSet$PropertySet;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("propertySet.Landroidx/constraintlayout/widget/ConstraintSet$PropertySet;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("transform")]
		public Transform? Transform
		{
			get
			{
				return Java.Lang.Object.GetObject<Transform>(_members.InstanceFields.GetObjectValue("transform.Landroidx/constraintlayout/widget/ConstraintSet$Transform;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("transform.Landroidx/constraintlayout/widget/ConstraintSet$Transform;", this, new JniObjectReference(num));
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

		protected Constraint(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Constraint()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetApplyDelta_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_ApplyDelta_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_ApplyDelta_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_(nint jnienv, nint native__this, nint native_c)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Constraint? constraint = Java.Lang.Object.GetObject<Constraint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Constraint c = Java.Lang.Object.GetObject<Constraint>(native_c, JniHandleOwnership.DoNotTransfer);
				constraint.ApplyDelta(c);
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

		[Register("applyDelta", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;)V", "GetApplyDelta_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Handler")]
		public unsafe virtual void ApplyDelta(Constraint? c)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("applyDelta.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
			}
		}

		private static Delegate GetApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_(nint jnienv, nint native__this, nint native_param)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Constraint? constraint = Java.Lang.Object.GetObject<Constraint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ConstraintLayout.LayoutParams param = Java.Lang.Object.GetObject<ConstraintLayout.LayoutParams>(native_param, JniHandleOwnership.DoNotTransfer);
				constraint.ApplyTo(param);
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

		[Register("applyTo", "(Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", "GetApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler")]
		public unsafe virtual void ApplyTo(ConstraintLayout.LayoutParams? param)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(param?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("applyTo.(Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(param);
			}
		}

		private static Delegate GetCloneHandler()
		{
			return new global::_JniMarshal_PP_L(n_Clone);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Clone(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Constraint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
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

		[Register("clone", "()Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", "GetCloneHandler")]
		public new unsafe virtual Constraint? Clone()
		{
			return Java.Lang.Object.GetObject<Constraint>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPrintDelta_Ljava_lang_String_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_PrintDelta_Ljava_lang_String_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_PrintDelta_Ljava_lang_String_(nint jnienv, nint native__this, nint native_tag)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Constraint? constraint = Java.Lang.Object.GetObject<Constraint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
				constraint.PrintDelta(tag);
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

		[Register("printDelta", "(Ljava/lang/String;)V", "GetPrintDelta_Ljava_lang_String_Handler")]
		public unsafe virtual void PrintDelta(string? tag)
		{
			nint num = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("printDelta.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("androidx/constraintlayout/widget/ConstraintSet$Layout", DoNotGenerateAcw = true)]
	public class Layout : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$Layout", typeof(Layout));

		private static Delegate? cb_copyFrom_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout__V;

		private static Delegate? cb_dump_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder__V;

		[Register("baselineMargin")]
		public int BaselineMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("baselineMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("baselineMargin.I", this, value);
			}
		}

		[Register("baselineToBaseline")]
		public int BaselineToBaseline
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("baselineToBaseline.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("baselineToBaseline.I", this, value);
			}
		}

		[Register("baselineToBottom")]
		public int BaselineToBottom
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("baselineToBottom.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("baselineToBottom.I", this, value);
			}
		}

		[Register("baselineToTop")]
		public int BaselineToTop
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("baselineToTop.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("baselineToTop.I", this, value);
			}
		}

		[Register("bottomMargin")]
		public int BottomMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("bottomMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("bottomMargin.I", this, value);
			}
		}

		[Register("bottomToBottom")]
		public int BottomToBottom
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("bottomToBottom.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("bottomToBottom.I", this, value);
			}
		}

		[Register("bottomToTop")]
		public int BottomToTop
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("bottomToTop.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("bottomToTop.I", this, value);
			}
		}

		[Register("circleAngle")]
		public float CircleAngle
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("circleAngle.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("circleAngle.F", this, value);
			}
		}

		[Register("circleConstraint")]
		public int CircleConstraint
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("circleConstraint.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("circleConstraint.I", this, value);
			}
		}

		[Register("circleRadius")]
		public int CircleRadius
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("circleRadius.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("circleRadius.I", this, value);
			}
		}

		[Register("constrainedHeight")]
		public bool ConstrainedHeight
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("constrainedHeight.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("constrainedHeight.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("constrainedWidth")]
		public bool ConstrainedWidth
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("constrainedWidth.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("constrainedWidth.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("dimensionRatio")]
		public string? DimensionRatio
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("dimensionRatio.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("dimensionRatio.Ljava/lang/String;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("editorAbsoluteX")]
		public int EditorAbsoluteX
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("editorAbsoluteX.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("editorAbsoluteX.I", this, value);
			}
		}

		[Register("editorAbsoluteY")]
		public int EditorAbsoluteY
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("editorAbsoluteY.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("editorAbsoluteY.I", this, value);
			}
		}

		[Register("endMargin")]
		public int EndMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("endMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("endMargin.I", this, value);
			}
		}

		[Register("endToEnd")]
		public int EndToEnd
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("endToEnd.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("endToEnd.I", this, value);
			}
		}

		[Register("endToStart")]
		public int EndToStart
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("endToStart.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("endToStart.I", this, value);
			}
		}

		[Register("goneBaselineMargin")]
		public int GoneBaselineMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("goneBaselineMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("goneBaselineMargin.I", this, value);
			}
		}

		[Register("goneBottomMargin")]
		public int GoneBottomMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("goneBottomMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("goneBottomMargin.I", this, value);
			}
		}

		[Register("goneEndMargin")]
		public int GoneEndMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("goneEndMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("goneEndMargin.I", this, value);
			}
		}

		[Register("goneLeftMargin")]
		public int GoneLeftMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("goneLeftMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("goneLeftMargin.I", this, value);
			}
		}

		[Register("goneRightMargin")]
		public int GoneRightMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("goneRightMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("goneRightMargin.I", this, value);
			}
		}

		[Register("goneStartMargin")]
		public int GoneStartMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("goneStartMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("goneStartMargin.I", this, value);
			}
		}

		[Register("goneTopMargin")]
		public int GoneTopMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("goneTopMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("goneTopMargin.I", this, value);
			}
		}

		[Register("guideBegin")]
		public int GuideBegin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("guideBegin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("guideBegin.I", this, value);
			}
		}

		[Register("guideEnd")]
		public int GuideEnd
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("guideEnd.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("guideEnd.I", this, value);
			}
		}

		[Register("guidelineUseRtl")]
		public bool GuidelineUseRtl
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("guidelineUseRtl.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("guidelineUseRtl.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("guidePercent")]
		public float GuidePercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("guidePercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("guidePercent.F", this, value);
			}
		}

		[Register("heightDefault")]
		public int HeightDefault
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("heightDefault.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("heightDefault.I", this, value);
			}
		}

		[Register("heightMax")]
		public int HeightMax
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("heightMax.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("heightMax.I", this, value);
			}
		}

		[Register("heightMin")]
		public int HeightMin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("heightMin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("heightMin.I", this, value);
			}
		}

		[Register("heightPercent")]
		public float HeightPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("heightPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("heightPercent.F", this, value);
			}
		}

		[Register("horizontalBias")]
		public float HorizontalBias
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("horizontalBias.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("horizontalBias.F", this, value);
			}
		}

		[Register("horizontalChainStyle")]
		public int HorizontalChainStyle
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("horizontalChainStyle.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("horizontalChainStyle.I", this, value);
			}
		}

		[Register("horizontalWeight")]
		public float HorizontalWeight
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("horizontalWeight.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("horizontalWeight.F", this, value);
			}
		}

		[Register("leftMargin")]
		public int LeftMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("leftMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("leftMargin.I", this, value);
			}
		}

		[Register("leftToLeft")]
		public int LeftToLeft
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("leftToLeft.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("leftToLeft.I", this, value);
			}
		}

		[Register("leftToRight")]
		public int LeftToRight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("leftToRight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("leftToRight.I", this, value);
			}
		}

		[Register("mApply")]
		public bool MApply
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mApply.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mApply.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("mBarrierAllowsGoneWidgets")]
		public bool MBarrierAllowsGoneWidgets
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mBarrierAllowsGoneWidgets.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mBarrierAllowsGoneWidgets.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("mBarrierDirection")]
		public int MBarrierDirection
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mBarrierDirection.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mBarrierDirection.I", this, value);
			}
		}

		[Register("mBarrierMargin")]
		public int MBarrierMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mBarrierMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mBarrierMargin.I", this, value);
			}
		}

		[Register("mConstraintTag")]
		public string? MConstraintTag
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mConstraintTag.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("mConstraintTag.Ljava/lang/String;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("mHeight")]
		public int MHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mHeight.I", this, value);
			}
		}

		[Register("mHelperType")]
		public int MHelperType
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mHelperType.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mHelperType.I", this, value);
			}
		}

		[Register("mIsGuideline")]
		public bool MIsGuideline
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mIsGuideline.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mIsGuideline.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("mOverride")]
		public bool MOverride
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mOverride.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mOverride.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("mReferenceIds")]
		public IList<int>? MReferenceIds
		{
			get
			{
				return Android.Runtime.JavaArray<int>.FromJniHandle(_members.InstanceFields.GetObjectValue("mReferenceIds.[I", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = Android.Runtime.JavaArray<int>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mReferenceIds.[I", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("mReferenceIdString")]
		public string? MReferenceIdString
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mReferenceIdString.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("mReferenceIdString.Ljava/lang/String;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("mWidth")]
		public int MWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mWidth.I", this, value);
			}
		}

		[Register("mWrapBehavior")]
		public int MWrapBehavior
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mWrapBehavior.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mWrapBehavior.I", this, value);
			}
		}

		[Register("orientation")]
		public int Orientation
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("orientation.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("orientation.I", this, value);
			}
		}

		[Register("rightMargin")]
		public int RightMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("rightMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("rightMargin.I", this, value);
			}
		}

		[Register("rightToLeft")]
		public int RightToLeft
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("rightToLeft.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("rightToLeft.I", this, value);
			}
		}

		[Register("rightToRight")]
		public int RightToRight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("rightToRight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("rightToRight.I", this, value);
			}
		}

		[Register("startMargin")]
		public int StartMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("startMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("startMargin.I", this, value);
			}
		}

		[Register("startToEnd")]
		public int StartToEnd
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("startToEnd.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("startToEnd.I", this, value);
			}
		}

		[Register("startToStart")]
		public int StartToStart
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("startToStart.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("startToStart.I", this, value);
			}
		}

		[Register("topMargin")]
		public int TopMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("topMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("topMargin.I", this, value);
			}
		}

		[Register("topToBottom")]
		public int TopToBottom
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("topToBottom.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("topToBottom.I", this, value);
			}
		}

		[Register("topToTop")]
		public int TopToTop
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("topToTop.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("topToTop.I", this, value);
			}
		}

		[Register("verticalBias")]
		public float VerticalBias
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("verticalBias.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("verticalBias.F", this, value);
			}
		}

		[Register("verticalChainStyle")]
		public int VerticalChainStyle
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("verticalChainStyle.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("verticalChainStyle.I", this, value);
			}
		}

		[Register("verticalWeight")]
		public float VerticalWeight
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("verticalWeight.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("verticalWeight.F", this, value);
			}
		}

		[Register("widthDefault")]
		public int WidthDefault
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("widthDefault.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("widthDefault.I", this, value);
			}
		}

		[Register("widthMax")]
		public int WidthMax
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("widthMax.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("widthMax.I", this, value);
			}
		}

		[Register("widthMin")]
		public int WidthMin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("widthMin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("widthMin.I", this, value);
			}
		}

		[Register("widthPercent")]
		public float WidthPercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("widthPercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("widthPercent.F", this, value);
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

		protected Layout(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Layout()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_(nint jnienv, nint native__this, nint native_src)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Layout? layout = Java.Lang.Object.GetObject<Layout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Layout src = Java.Lang.Object.GetObject<Layout>(native_src, JniHandleOwnership.DoNotTransfer);
				layout.CopyFrom(src);
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

		[Register("copyFrom", "(Landroidx/constraintlayout/widget/ConstraintSet$Layout;)V", "GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Layout_Handler")]
		public unsafe virtual void CopyFrom(Layout? src)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/widget/ConstraintSet$Layout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(src);
			}
		}

		private static Delegate GetDump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_(nint jnienv, nint native__this, nint native_scene, nint native_stringBuilder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Layout? layout = Java.Lang.Object.GetObject<Layout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MotionScene scene = Java.Lang.Object.GetObject<MotionScene>(native_scene, JniHandleOwnership.DoNotTransfer);
				StringBuilder stringBuilder = Java.Lang.Object.GetObject<StringBuilder>(native_stringBuilder, JniHandleOwnership.DoNotTransfer);
				layout.Dump(scene, stringBuilder);
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

		[Register("dump", "(Landroidx/constraintlayout/motion/widget/MotionScene;Ljava/lang/StringBuilder;)V", "GetDump_Landroidx_constraintlayout_motion_widget_MotionScene_Ljava_lang_StringBuilder_Handler")]
		public unsafe virtual void Dump(MotionScene? scene, StringBuilder? stringBuilder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(scene?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(stringBuilder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Landroidx/constraintlayout/motion/widget/MotionScene;Ljava/lang/StringBuilder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(scene);
				GC.KeepAlive(stringBuilder);
			}
		}
	}

	[Register("androidx/constraintlayout/widget/ConstraintSet$Motion", DoNotGenerateAcw = true)]
	public class Motion : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$Motion", typeof(Motion));

		private static Delegate? cb_copyFrom_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion__V;

		[Register("mAnimateCircleAngleTo")]
		public int MAnimateCircleAngleTo
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mAnimateCircleAngleTo.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mAnimateCircleAngleTo.I", this, value);
			}
		}

		[Register("mAnimateRelativeTo")]
		public int MAnimateRelativeTo
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mAnimateRelativeTo.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mAnimateRelativeTo.I", this, value);
			}
		}

		[Register("mApply")]
		public bool MApply
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mApply.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mApply.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("mDrawPath")]
		public int MDrawPath
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mDrawPath.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mDrawPath.I", this, value);
			}
		}

		[Register("mMotionStagger")]
		public float MMotionStagger
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("mMotionStagger.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMotionStagger.F", this, value);
			}
		}

		[Register("mPathMotionArc")]
		public int MPathMotionArc
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mPathMotionArc.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mPathMotionArc.I", this, value);
			}
		}

		[Register("mPathRotate")]
		public float MPathRotate
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("mPathRotate.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mPathRotate.F", this, value);
			}
		}

		[Register("mPolarRelativeTo")]
		public int MPolarRelativeTo
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mPolarRelativeTo.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mPolarRelativeTo.I", this, value);
			}
		}

		[Register("mQuantizeInterpolatorID")]
		public int MQuantizeInterpolatorID
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mQuantizeInterpolatorID.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mQuantizeInterpolatorID.I", this, value);
			}
		}

		[Register("mQuantizeInterpolatorString")]
		public string? MQuantizeInterpolatorString
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mQuantizeInterpolatorString.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("mQuantizeInterpolatorString.Ljava/lang/String;", this, new JniObjectReference(num));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}
		}

		[Register("mQuantizeInterpolatorType")]
		public int MQuantizeInterpolatorType
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mQuantizeInterpolatorType.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mQuantizeInterpolatorType.I", this, value);
			}
		}

		[Register("mQuantizeMotionPhase")]
		public float MQuantizeMotionPhase
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("mQuantizeMotionPhase.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mQuantizeMotionPhase.F", this, value);
			}
		}

		[Register("mQuantizeMotionSteps")]
		public int MQuantizeMotionSteps
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mQuantizeMotionSteps.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mQuantizeMotionSteps.I", this, value);
			}
		}

		[Register("mTransitionEasing")]
		public string? MTransitionEasing
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mTransitionEasing.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("mTransitionEasing.Ljava/lang/String;", this, new JniObjectReference(num));
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

		protected Motion(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Motion()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_(nint jnienv, nint native__this, nint native_src)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Motion? motion = Java.Lang.Object.GetObject<Motion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Motion src = Java.Lang.Object.GetObject<Motion>(native_src, JniHandleOwnership.DoNotTransfer);
				motion.CopyFrom(src);
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

		[Register("copyFrom", "(Landroidx/constraintlayout/widget/ConstraintSet$Motion;)V", "GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Motion_Handler")]
		public unsafe virtual void CopyFrom(Motion? src)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/widget/ConstraintSet$Motion;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(src);
			}
		}
	}

	[Register("androidx/constraintlayout/widget/ConstraintSet$PropertySet", DoNotGenerateAcw = true)]
	public class PropertySet : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$PropertySet", typeof(PropertySet));

		private static Delegate? cb_copyFrom_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet__V;

		[Register("alpha")]
		public float Alpha
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("alpha.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("alpha.F", this, value);
			}
		}

		[Register("mApply")]
		public bool MApply
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mApply.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mApply.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("mProgress")]
		public float MProgress
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("mProgress.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mProgress.F", this, value);
			}
		}

		[Register("mVisibilityMode")]
		public int MVisibilityMode
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mVisibilityMode.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mVisibilityMode.I", this, value);
			}
		}

		[Register("visibility")]
		public int Visibility
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("visibility.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("visibility.I", this, value);
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

		protected PropertySet(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe PropertySet()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_(nint jnienv, nint native__this, nint native_src)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				PropertySet? propertySet = Java.Lang.Object.GetObject<PropertySet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				PropertySet src = Java.Lang.Object.GetObject<PropertySet>(native_src, JniHandleOwnership.DoNotTransfer);
				propertySet.CopyFrom(src);
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

		[Register("copyFrom", "(Landroidx/constraintlayout/widget/ConstraintSet$PropertySet;)V", "GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_PropertySet_Handler")]
		public unsafe virtual void CopyFrom(PropertySet? src)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/widget/ConstraintSet$PropertySet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(src);
			}
		}
	}

	[Register("androidx/constraintlayout/widget/ConstraintSet$Transform", DoNotGenerateAcw = true)]
	public class Transform : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet$Transform", typeof(Transform));

		private static Delegate? cb_copyFrom_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform__V;

		[Register("applyElevation")]
		public bool ApplyElevation
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("applyElevation.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("applyElevation.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("elevation")]
		public float Elevation
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("elevation.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("elevation.F", this, value);
			}
		}

		[Register("mApply")]
		public bool MApply
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mApply.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mApply.Z", this, value ? ((sbyte)1) : ((sbyte)0));
			}
		}

		[Register("rotation")]
		public float Rotation
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("rotation.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("rotation.F", this, value);
			}
		}

		[Register("rotationX")]
		public float RotationX
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("rotationX.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("rotationX.F", this, value);
			}
		}

		[Register("rotationY")]
		public float RotationY
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("rotationY.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("rotationY.F", this, value);
			}
		}

		[Register("scaleX")]
		public float ScaleX
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("scaleX.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("scaleX.F", this, value);
			}
		}

		[Register("scaleY")]
		public float ScaleY
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("scaleY.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("scaleY.F", this, value);
			}
		}

		[Register("transformPivotTarget")]
		public int TransformPivotTarget
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("transformPivotTarget.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("transformPivotTarget.I", this, value);
			}
		}

		[Register("transformPivotX")]
		public float TransformPivotX
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("transformPivotX.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("transformPivotX.F", this, value);
			}
		}

		[Register("transformPivotY")]
		public float TransformPivotY
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("transformPivotY.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("transformPivotY.F", this, value);
			}
		}

		[Register("translationX")]
		public float TranslationX
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("translationX.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("translationX.F", this, value);
			}
		}

		[Register("translationY")]
		public float TranslationY
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("translationY.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("translationY.F", this, value);
			}
		}

		[Register("translationZ")]
		public float TranslationZ
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("translationZ.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("translationZ.F", this, value);
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

		protected Transform(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Transform()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_CopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_(nint jnienv, nint native__this, nint native_src)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Transform? transform = Java.Lang.Object.GetObject<Transform>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Transform src = Java.Lang.Object.GetObject<Transform>(native_src, JniHandleOwnership.DoNotTransfer);
				transform.CopyFrom(src);
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

		[Register("copyFrom", "(Landroidx/constraintlayout/widget/ConstraintSet$Transform;)V", "GetCopyFrom_Landroidx_constraintlayout_widget_ConstraintSet_Transform_Handler")]
		public unsafe virtual void CopyFrom(Transform? src)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/widget/ConstraintSet$Transform;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(src);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintSet", typeof(ConstraintSet));

	private static Delegate? cb_getCustomAttributeSet_GetCustomAttributeSet_Ljava_util_HashMap_;

	private static Delegate? cb_isForceId_IsForceId_Z;

	private static Delegate? cb_setForceId_SetForceId_Z_V;

	private static Delegate? cb_isValidateOnParse_IsValidateOnParse_Z;

	private static Delegate? cb_setValidateOnParse_SetValidateOnParse_Z_V;

	private static Delegate? cb_addColorAttributes_AddColorAttributes_arrayLjava_lang_String__V;

	private static Delegate? cb_addFloatAttributes_AddFloatAttributes_arrayLjava_lang_String__V;

	private static Delegate? cb_addIntAttributes_AddIntAttributes_arrayLjava_lang_String__V;

	private static Delegate? cb_addStringAttributes_AddStringAttributes_arrayLjava_lang_String__V;

	private static Delegate? cb_addToHorizontalChain_AddToHorizontalChain_III_V;

	private static Delegate? cb_addToHorizontalChainRTL_AddToHorizontalChainRTL_III_V;

	private static Delegate? cb_addToVerticalChain_AddToVerticalChain_III_V;

	private static Delegate? cb_applyCustomAttributes_ApplyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_applyDeltaFrom_ApplyDeltaFrom_Landroidx_constraintlayout_widget_ConstraintSet__V;

	private static Delegate? cb_applyTo_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_applyToHelper_ApplyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray__V;

	private static Delegate? cb_applyToLayoutParams_ApplyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams__V;

	private static Delegate? cb_applyToWithoutCustom_ApplyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_center_Center_IIIIIIIF_V;

	private static Delegate? cb_centerHorizontally_CenterHorizontally_II_V;

	private static Delegate? cb_centerHorizontally_CenterHorizontally_IIIIIIIF_V;

	private static Delegate? cb_centerHorizontallyRtl_CenterHorizontallyRtl_II_V;

	private static Delegate? cb_centerHorizontallyRtl_CenterHorizontallyRtl_IIIIIIIF_V;

	private static Delegate? cb_centerVertically_CenterVertically_II_V;

	private static Delegate? cb_centerVertically_CenterVertically_IIIIIIIF_V;

	private static Delegate? cb_clear_Clear_I_V;

	private static Delegate? cb_clear_Clear_II_V;

	private static Delegate? cb_clone_Clone_Landroid_content_Context_I_V;

	private static Delegate? cb_clone_Clone_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_clone_Clone_Landroidx_constraintlayout_widget_Constraints__V;

	private static Delegate? cb_clone_Clone_Landroidx_constraintlayout_widget_ConstraintSet__V;

	private static Delegate? cb_connect_Connect_IIII_V;

	private static Delegate? cb_connect_Connect_IIIII_V;

	private static Delegate? cb_constrainCircle_ConstrainCircle_IIIF_V;

	private static Delegate? cb_constrainDefaultHeight_ConstrainDefaultHeight_II_V;

	private static Delegate? cb_constrainDefaultWidth_ConstrainDefaultWidth_II_V;

	private static Delegate? cb_constrainHeight_ConstrainHeight_II_V;

	private static Delegate? cb_constrainMaxHeight_ConstrainMaxHeight_II_V;

	private static Delegate? cb_constrainMaxWidth_ConstrainMaxWidth_II_V;

	private static Delegate? cb_constrainMinHeight_ConstrainMinHeight_II_V;

	private static Delegate? cb_constrainMinWidth_ConstrainMinWidth_II_V;

	private static Delegate? cb_constrainPercentHeight_ConstrainPercentHeight_IF_V;

	private static Delegate? cb_constrainPercentWidth_ConstrainPercentWidth_IF_V;

	private static Delegate? cb_constrainWidth_ConstrainWidth_II_V;

	private static Delegate? cb_constrainedHeight_ConstrainedHeight_IZ_V;

	private static Delegate? cb_constrainedWidth_ConstrainedWidth_IZ_V;

	private static Delegate? cb_create_Create_II_V;

	private static Delegate? cb_createBarrier_CreateBarrier_IIIarrayI_V;

	private static Delegate? cb_createHorizontalChain_CreateHorizontalChain_IIIIarrayIarrayFI_V;

	private static Delegate? cb_createHorizontalChainRtl_CreateHorizontalChainRtl_IIIIarrayIarrayFI_V;

	private static Delegate? cb_createVerticalChain_CreateVerticalChain_IIIIarrayIarrayFI_V;

	private static Delegate? cb_dump_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayI_V;

	private static Delegate? cb_getApplyElevation_GetApplyElevation_I_Z;

	private static Delegate? cb_getConstraint_GetConstraint_I_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_;

	private static Delegate? cb_getHeight_GetHeight_I_I;

	private static Delegate? cb_getKnownIds_GetKnownIds_arrayI;

	private static Delegate? cb_getParameters_GetParameters_I_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_;

	private static Delegate? cb_getReferencedIds_GetReferencedIds_I_arrayI;

	private static Delegate? cb_getStateLabels_GetStateLabels_arrayLjava_lang_String_;

	private static Delegate? cb_getVisibility_GetVisibility_I_I;

	private static Delegate? cb_getVisibilityMode_GetVisibilityMode_I_I;

	private static Delegate? cb_getWidth_GetWidth_I_I;

	private static Delegate? cb_load_Load_Landroid_content_Context_I_V;

	private static Delegate? cb_load_Load_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser__V;

	private static Delegate? cb_matchesLabels_MatchesLabels_arrayLjava_lang_String__Z;

	private static Delegate? cb_parseColorAttributes_ParseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String__V;

	private static Delegate? cb_parseFloatAttributes_ParseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String__V;

	private static Delegate? cb_parseIntAttributes_ParseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String__V;

	private static Delegate? cb_parseStringAttributes_ParseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String__V;

	private static Delegate? cb_readFallback_ReadFallback_Landroidx_constraintlayout_widget_ConstraintLayout__V;

	private static Delegate? cb_readFallback_ReadFallback_Landroidx_constraintlayout_widget_ConstraintSet__V;

	private static Delegate? cb_removeAttribute_RemoveAttribute_Ljava_lang_String__V;

	private static Delegate? cb_removeFromHorizontalChain_RemoveFromHorizontalChain_I_V;

	private static Delegate? cb_removeFromVerticalChain_RemoveFromVerticalChain_I_V;

	private static Delegate? cb_setAlpha_SetAlpha_IF_V;

	private static Delegate? cb_setApplyElevation_SetApplyElevation_IZ_V;

	private static Delegate? cb_setBarrierType_SetBarrierType_II_V;

	private static Delegate? cb_setColorValue_SetColorValue_ILjava_lang_String_I_V;

	private static Delegate? cb_setDimensionRatio_SetDimensionRatio_ILjava_lang_String__V;

	private static Delegate? cb_setEditorAbsoluteX_SetEditorAbsoluteX_II_V;

	private static Delegate? cb_setEditorAbsoluteY_SetEditorAbsoluteY_II_V;

	private static Delegate? cb_setElevation_SetElevation_IF_V;

	private static Delegate? cb_setFloatValue_SetFloatValue_ILjava_lang_String_F_V;

	private static Delegate? cb_setGoneMargin_SetGoneMargin_III_V;

	private static Delegate? cb_setGuidelineBegin_SetGuidelineBegin_II_V;

	private static Delegate? cb_setGuidelineEnd_SetGuidelineEnd_II_V;

	private static Delegate? cb_setGuidelinePercent_SetGuidelinePercent_IF_V;

	private static Delegate? cb_setHorizontalBias_SetHorizontalBias_IF_V;

	private static Delegate? cb_setHorizontalChainStyle_SetHorizontalChainStyle_II_V;

	private static Delegate? cb_setHorizontalWeight_SetHorizontalWeight_IF_V;

	private static Delegate? cb_setIntValue_SetIntValue_ILjava_lang_String_I_V;

	private static Delegate? cb_setLayoutWrapBehavior_SetLayoutWrapBehavior_II_V;

	private static Delegate? cb_setMargin_SetMargin_III_V;

	private static Delegate? cb_setReferencedIds_SetReferencedIds_IarrayI_V;

	private static Delegate? cb_setRotation_SetRotation_IF_V;

	private static Delegate? cb_setRotationX_SetRotationX_IF_V;

	private static Delegate? cb_setRotationY_SetRotationY_IF_V;

	private static Delegate? cb_setScaleX_SetScaleX_IF_V;

	private static Delegate? cb_setScaleY_SetScaleY_IF_V;

	private static Delegate? cb_setStateLabels_SetStateLabels_Ljava_lang_String__V;

	private static Delegate? cb_setStateLabelsList_SetStateLabelsList_arrayLjava_lang_String__V;

	private static Delegate? cb_setStringValue_SetStringValue_ILjava_lang_String_Ljava_lang_String__V;

	private static Delegate? cb_setTransformPivot_SetTransformPivot_IFF_V;

	private static Delegate? cb_setTransformPivotX_SetTransformPivotX_IF_V;

	private static Delegate? cb_setTransformPivotY_SetTransformPivotY_IF_V;

	private static Delegate? cb_setTranslation_SetTranslation_IFF_V;

	private static Delegate? cb_setTranslationX_SetTranslationX_IF_V;

	private static Delegate? cb_setTranslationY_SetTranslationY_IF_V;

	private static Delegate? cb_setTranslationZ_SetTranslationZ_IF_V;

	private static Delegate? cb_setVerticalBias_SetVerticalBias_IF_V;

	private static Delegate? cb_setVerticalChainStyle_SetVerticalChainStyle_II_V;

	private static Delegate? cb_setVerticalWeight_SetVerticalWeight_IF_V;

	private static Delegate? cb_setVisibility_SetVisibility_II_V;

	private static Delegate? cb_setVisibilityMode_SetVisibilityMode_II_V;

	private static Delegate? cb_writeState_WriteState_Ljava_io_Writer_Landroidx_constraintlayout_widget_ConstraintLayout_I_V;

	[Register("derivedState")]
	public string? DerivedState
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("derivedState.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("derivedState.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mIdString")]
	public string? MIdString
	{
		get
		{
			return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("mIdString.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				_members.InstanceFields.SetValue("mIdString.Ljava/lang/String;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mRotate")]
	public int MRotate
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mRotate.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mRotate.I", this, value);
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

	public unsafe virtual IDictionary<string, ConstraintAttribute>? CustomAttributeSet
	{
		[Register("getCustomAttributeSet", "()Ljava/util/HashMap;", "GetGetCustomAttributeSetHandler")]
		get
		{
			return JavaDictionary<string, ConstraintAttribute>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getCustomAttributeSet.()Ljava/util/HashMap;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool ForceId
	{
		[Register("isForceId", "()Z", "GetIsForceIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isForceId.()Z", this, null);
		}
		[Register("setForceId", "(Z)V", "GetSetForceId_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setForceId.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool ValidateOnParse
	{
		[Register("isValidateOnParse", "()Z", "GetIsValidateOnParseHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isValidateOnParse.()Z", this, null);
		}
		[Register("setValidateOnParse", "(Z)V", "GetSetValidateOnParse_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValidateOnParse.(Z)V", this, ptr);
		}
	}

	protected ConstraintSet(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ConstraintSet()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCustomAttributeSetHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCustomAttributeSet);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCustomAttributeSet(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaDictionary<string, ConstraintAttribute>.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomAttributeSet);
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

	private static Delegate GetIsForceIdHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsForceId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsForceId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ForceId ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetForceId_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetForceId_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetForceId_Z(nint jnienv, nint native__this, sbyte native_forceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool forceId = native_forceId != 0;
			constraintSet.ForceId = forceId;
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

	private static Delegate GetIsValidateOnParseHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsValidateOnParse);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsValidateOnParse(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValidateOnParse ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetValidateOnParse_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetValidateOnParse_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetValidateOnParse_Z(nint jnienv, nint native__this, sbyte native_validate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool validateOnParse = native_validate != 0;
			constraintSet.ValidateOnParse = validateOnParse;
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

	private static Delegate GetAddColorAttributes_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddColorAttributes_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddColorAttributes_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_attributeName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attributeName, JniHandleOwnership.DoNotTransfer, typeof(string));
			constraintSet.AddColorAttributes(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attributeName);
			}
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

	[Register("addColorAttributes", "([Ljava/lang/String;)V", "GetAddColorAttributes_arrayLjava_lang_String_Handler")]
	public unsafe virtual void AddColorAttributes(params string[]? attributeName)
	{
		nint num = JNIEnv.NewArray(attributeName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addColorAttributes.([Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			if (attributeName != null)
			{
				JNIEnv.CopyArray(num, attributeName);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(attributeName);
		}
	}

	private static Delegate GetAddFloatAttributes_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddFloatAttributes_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFloatAttributes_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_attributeName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attributeName, JniHandleOwnership.DoNotTransfer, typeof(string));
			constraintSet.AddFloatAttributes(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attributeName);
			}
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

	[Register("addFloatAttributes", "([Ljava/lang/String;)V", "GetAddFloatAttributes_arrayLjava_lang_String_Handler")]
	public unsafe virtual void AddFloatAttributes(params string[]? attributeName)
	{
		nint num = JNIEnv.NewArray(attributeName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFloatAttributes.([Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			if (attributeName != null)
			{
				JNIEnv.CopyArray(num, attributeName);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(attributeName);
		}
	}

	private static Delegate GetAddIntAttributes_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddIntAttributes_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddIntAttributes_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_attributeName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attributeName, JniHandleOwnership.DoNotTransfer, typeof(string));
			constraintSet.AddIntAttributes(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attributeName);
			}
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

	[Register("addIntAttributes", "([Ljava/lang/String;)V", "GetAddIntAttributes_arrayLjava_lang_String_Handler")]
	public unsafe virtual void AddIntAttributes(params string[]? attributeName)
	{
		nint num = JNIEnv.NewArray(attributeName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addIntAttributes.([Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			if (attributeName != null)
			{
				JNIEnv.CopyArray(num, attributeName);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(attributeName);
		}
	}

	private static Delegate GetAddStringAttributes_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddStringAttributes_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddStringAttributes_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_attributeName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_attributeName, JniHandleOwnership.DoNotTransfer, typeof(string));
			constraintSet.AddStringAttributes(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attributeName);
			}
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

	[Register("addStringAttributes", "([Ljava/lang/String;)V", "GetAddStringAttributes_arrayLjava_lang_String_Handler")]
	public unsafe virtual void AddStringAttributes(params string[]? attributeName)
	{
		nint num = JNIEnv.NewArray(attributeName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addStringAttributes.([Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			if (attributeName != null)
			{
				JNIEnv.CopyArray(num, attributeName);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(attributeName);
		}
	}

	private static Delegate GetAddToHorizontalChain_IIIHandler()
	{
		return new global::_JniMarshal_PPIII_V(n_AddToHorizontalChain_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddToHorizontalChain_III(nint jnienv, nint native__this, int viewId, int leftId, int rightId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddToHorizontalChain(viewId, leftId, rightId);
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

	[Register("addToHorizontalChain", "(III)V", "GetAddToHorizontalChain_IIIHandler")]
	public unsafe virtual void AddToHorizontalChain(int viewId, int leftId, int rightId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(leftId);
		ptr[2] = new JniArgumentValue(rightId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("addToHorizontalChain.(III)V", this, ptr);
	}

	private static Delegate GetAddToHorizontalChainRTL_IIIHandler()
	{
		return new global::_JniMarshal_PPIII_V(n_AddToHorizontalChainRTL_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddToHorizontalChainRTL_III(nint jnienv, nint native__this, int viewId, int leftId, int rightId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddToHorizontalChainRTL(viewId, leftId, rightId);
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

	[Register("addToHorizontalChainRTL", "(III)V", "GetAddToHorizontalChainRTL_IIIHandler")]
	public unsafe virtual void AddToHorizontalChainRTL(int viewId, int leftId, int rightId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(leftId);
		ptr[2] = new JniArgumentValue(rightId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("addToHorizontalChainRTL.(III)V", this, ptr);
	}

	private static Delegate GetAddToVerticalChain_IIIHandler()
	{
		return new global::_JniMarshal_PPIII_V(n_AddToVerticalChain_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddToVerticalChain_III(nint jnienv, nint native__this, int viewId, int topId, int bottomId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddToVerticalChain(viewId, topId, bottomId);
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

	[Register("addToVerticalChain", "(III)V", "GetAddToVerticalChain_IIIHandler")]
	public unsafe virtual void AddToVerticalChain(int viewId, int topId, int bottomId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(topId);
		ptr[2] = new JniArgumentValue(bottomId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("addToVerticalChain.(III)V", this, ptr);
	}

	private static Delegate GetApplyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_constraintLayout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyCustomAttributes(constraintLayout);
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

	[Register("applyCustomAttributes", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetApplyCustomAttributes_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void ApplyCustomAttributes(ConstraintLayout? constraintLayout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyCustomAttributes.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintLayout);
		}
	}

	private static Delegate GetApplyDeltaFrom_Landroidx_constraintlayout_widget_ConstraintSet_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyDeltaFrom_Landroidx_constraintlayout_widget_ConstraintSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyDeltaFrom_Landroidx_constraintlayout_widget_ConstraintSet_(nint jnienv, nint native__this, nint native_cs)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet cs = Java.Lang.Object.GetObject<ConstraintSet>(native_cs, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyDeltaFrom(cs);
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

	[Register("applyDeltaFrom", "(Landroidx/constraintlayout/widget/ConstraintSet;)V", "GetApplyDeltaFrom_Landroidx_constraintlayout_widget_ConstraintSet_Handler")]
	public unsafe virtual void ApplyDeltaFrom(ConstraintSet? cs)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cs?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyDeltaFrom.(Landroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cs);
		}
	}

	private static Delegate GetApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_constraintLayout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyTo(constraintLayout);
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

	[Register("applyTo", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetApplyTo_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void ApplyTo(ConstraintLayout? constraintLayout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyTo.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintLayout);
		}
	}

	private static Delegate GetApplyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_ApplyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_helper, nint native_child, nint native_layoutParams, nint native_mapIdToWidget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintHelper helper = Java.Lang.Object.GetObject<ConstraintHelper>(native_helper, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget child = Java.Lang.Object.GetObject<ConstraintWidget>(native_child, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout.LayoutParams layoutParams = Java.Lang.Object.GetObject<ConstraintLayout.LayoutParams>(native_layoutParams, JniHandleOwnership.DoNotTransfer);
			SparseArray mapIdToWidget = Java.Lang.Object.GetObject<SparseArray>(native_mapIdToWidget, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyToHelper(helper, child, layoutParams, mapIdToWidget);
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

	[Register("applyToHelper", "(Landroidx/constraintlayout/widget/ConstraintHelper;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", "GetApplyToHelper_Landroidx_constraintlayout_widget_ConstraintHelper_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler")]
	public unsafe virtual void ApplyToHelper(ConstraintHelper? helper, ConstraintWidget? child, ConstraintLayout.LayoutParams? layoutParams, SparseArray? mapIdToWidget)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(helper?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(layoutParams?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(mapIdToWidget?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyToHelper.(Landroidx/constraintlayout/widget/ConstraintHelper;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(helper);
			GC.KeepAlive(child);
			GC.KeepAlive(layoutParams);
			GC.KeepAlive(mapIdToWidget);
		}
	}

	private static Delegate GetApplyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_ApplyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_(nint jnienv, nint native__this, int id, nint native_layoutParams)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout.LayoutParams layoutParams = Java.Lang.Object.GetObject<ConstraintLayout.LayoutParams>(native_layoutParams, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyToLayoutParams(id, layoutParams);
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

	[Register("applyToLayoutParams", "(ILandroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", "GetApplyToLayoutParams_ILandroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler")]
	public unsafe virtual void ApplyToLayoutParams(int id, ConstraintLayout.LayoutParams? layoutParams)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(layoutParams?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyToLayoutParams.(ILandroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layoutParams);
		}
	}

	private static Delegate GetApplyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ApplyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_constraintLayout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.ApplyToWithoutCustom(constraintLayout);
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

	[Register("applyToWithoutCustom", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetApplyToWithoutCustom_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void ApplyToWithoutCustom(ConstraintLayout? constraintLayout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyToWithoutCustom.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintLayout);
		}
	}

	[Register("buildDelta", "(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", "")]
	public unsafe static Constraint? BuildDelta(Context? context, XmlReader? parser)
	{
		nint num = XmlReaderPullParser.ToLocalJniHandle(parser);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Constraint>(_members.StaticMethods.InvokeObjectMethod("buildDelta.(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(parser);
		}
	}

	private static Delegate GetCenter_IIIIIIIFHandler()
	{
		return new _JniMarshal_PPIIIIIIIF_V(n_Center_IIIIIIIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Center_IIIIIIIF(nint jnienv, nint native__this, int centerID, int firstID, int firstSide, int firstMargin, int secondId, int secondSide, int secondMargin, float bias)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Center(centerID, firstID, firstSide, firstMargin, secondId, secondSide, secondMargin, bias);
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

	[Register("center", "(IIIIIIIF)V", "GetCenter_IIIIIIIFHandler")]
	public unsafe virtual void Center(int centerID, int firstID, int firstSide, int firstMargin, int secondId, int secondSide, int secondMargin, float bias)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
		*ptr = new JniArgumentValue(centerID);
		ptr[1] = new JniArgumentValue(firstID);
		ptr[2] = new JniArgumentValue(firstSide);
		ptr[3] = new JniArgumentValue(firstMargin);
		ptr[4] = new JniArgumentValue(secondId);
		ptr[5] = new JniArgumentValue(secondSide);
		ptr[6] = new JniArgumentValue(secondMargin);
		ptr[7] = new JniArgumentValue(bias);
		_members.InstanceMethods.InvokeVirtualVoidMethod("center.(IIIIIIIF)V", this, ptr);
	}

	private static Delegate GetCenterHorizontally_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_CenterHorizontally_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CenterHorizontally_II(nint jnienv, nint native__this, int viewId, int toView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterHorizontally(viewId, toView);
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

	[Register("centerHorizontally", "(II)V", "GetCenterHorizontally_IIHandler")]
	public unsafe virtual void CenterHorizontally(int viewId, int toView)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(toView);
		_members.InstanceMethods.InvokeVirtualVoidMethod("centerHorizontally.(II)V", this, ptr);
	}

	private static Delegate GetCenterHorizontally_IIIIIIIFHandler()
	{
		return new _JniMarshal_PPIIIIIIIF_V(n_CenterHorizontally_IIIIIIIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CenterHorizontally_IIIIIIIF(nint jnienv, nint native__this, int centerID, int leftId, int leftSide, int leftMargin, int rightId, int rightSide, int rightMargin, float bias)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterHorizontally(centerID, leftId, leftSide, leftMargin, rightId, rightSide, rightMargin, bias);
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

	[Register("centerHorizontally", "(IIIIIIIF)V", "GetCenterHorizontally_IIIIIIIFHandler")]
	public unsafe virtual void CenterHorizontally(int centerID, int leftId, int leftSide, int leftMargin, int rightId, int rightSide, int rightMargin, float bias)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
		*ptr = new JniArgumentValue(centerID);
		ptr[1] = new JniArgumentValue(leftId);
		ptr[2] = new JniArgumentValue(leftSide);
		ptr[3] = new JniArgumentValue(leftMargin);
		ptr[4] = new JniArgumentValue(rightId);
		ptr[5] = new JniArgumentValue(rightSide);
		ptr[6] = new JniArgumentValue(rightMargin);
		ptr[7] = new JniArgumentValue(bias);
		_members.InstanceMethods.InvokeVirtualVoidMethod("centerHorizontally.(IIIIIIIF)V", this, ptr);
	}

	private static Delegate GetCenterHorizontallyRtl_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_CenterHorizontallyRtl_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CenterHorizontallyRtl_II(nint jnienv, nint native__this, int viewId, int toView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterHorizontallyRtl(viewId, toView);
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

	[Register("centerHorizontallyRtl", "(II)V", "GetCenterHorizontallyRtl_IIHandler")]
	public unsafe virtual void CenterHorizontallyRtl(int viewId, int toView)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(toView);
		_members.InstanceMethods.InvokeVirtualVoidMethod("centerHorizontallyRtl.(II)V", this, ptr);
	}

	private static Delegate GetCenterHorizontallyRtl_IIIIIIIFHandler()
	{
		return new _JniMarshal_PPIIIIIIIF_V(n_CenterHorizontallyRtl_IIIIIIIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CenterHorizontallyRtl_IIIIIIIF(nint jnienv, nint native__this, int centerID, int startId, int startSide, int startMargin, int endId, int endSide, int endMargin, float bias)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterHorizontallyRtl(centerID, startId, startSide, startMargin, endId, endSide, endMargin, bias);
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

	[Register("centerHorizontallyRtl", "(IIIIIIIF)V", "GetCenterHorizontallyRtl_IIIIIIIFHandler")]
	public unsafe virtual void CenterHorizontallyRtl(int centerID, int startId, int startSide, int startMargin, int endId, int endSide, int endMargin, float bias)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
		*ptr = new JniArgumentValue(centerID);
		ptr[1] = new JniArgumentValue(startId);
		ptr[2] = new JniArgumentValue(startSide);
		ptr[3] = new JniArgumentValue(startMargin);
		ptr[4] = new JniArgumentValue(endId);
		ptr[5] = new JniArgumentValue(endSide);
		ptr[6] = new JniArgumentValue(endMargin);
		ptr[7] = new JniArgumentValue(bias);
		_members.InstanceMethods.InvokeVirtualVoidMethod("centerHorizontallyRtl.(IIIIIIIF)V", this, ptr);
	}

	private static Delegate GetCenterVertically_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_CenterVertically_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CenterVertically_II(nint jnienv, nint native__this, int viewId, int toView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterVertically(viewId, toView);
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

	[Register("centerVertically", "(II)V", "GetCenterVertically_IIHandler")]
	public unsafe virtual void CenterVertically(int viewId, int toView)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(toView);
		_members.InstanceMethods.InvokeVirtualVoidMethod("centerVertically.(II)V", this, ptr);
	}

	private static Delegate GetCenterVertically_IIIIIIIFHandler()
	{
		return new _JniMarshal_PPIIIIIIIF_V(n_CenterVertically_IIIIIIIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CenterVertically_IIIIIIIF(nint jnienv, nint native__this, int centerID, int topId, int topSide, int topMargin, int bottomId, int bottomSide, int bottomMargin, float bias)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CenterVertically(centerID, topId, topSide, topMargin, bottomId, bottomSide, bottomMargin, bias);
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

	[Register("centerVertically", "(IIIIIIIF)V", "GetCenterVertically_IIIIIIIFHandler")]
	public unsafe virtual void CenterVertically(int centerID, int topId, int topSide, int topMargin, int bottomId, int bottomSide, int bottomMargin, float bias)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
		*ptr = new JniArgumentValue(centerID);
		ptr[1] = new JniArgumentValue(topId);
		ptr[2] = new JniArgumentValue(topSide);
		ptr[3] = new JniArgumentValue(topMargin);
		ptr[4] = new JniArgumentValue(bottomId);
		ptr[5] = new JniArgumentValue(bottomSide);
		ptr[6] = new JniArgumentValue(bottomMargin);
		ptr[7] = new JniArgumentValue(bias);
		_members.InstanceMethods.InvokeVirtualVoidMethod("centerVertically.(IIIIIIIF)V", this, ptr);
	}

	private static Delegate GetClear_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_Clear_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear_I(nint jnienv, nint native__this, int viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear(viewId);
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

	[Register("clear", "(I)V", "GetClear_IHandler")]
	public unsafe virtual void Clear(int viewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("clear.(I)V", this, ptr);
	}

	private static Delegate GetClear_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_Clear_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear_II(nint jnienv, nint native__this, int viewId, int anchor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear(viewId, anchor);
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

	[Register("clear", "(II)V", "GetClear_IIHandler")]
	public unsafe virtual void Clear(int viewId, int anchor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(anchor);
		_members.InstanceMethods.InvokeVirtualVoidMethod("clear.(II)V", this, ptr);
	}

	private static Delegate GetClone_Landroid_content_Context_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_Clone_Landroid_content_Context_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clone_Landroid_content_Context_I(nint jnienv, nint native__this, nint native_context, int constraintLayoutId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			constraintSet.Clone(context, constraintLayoutId);
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

	[Register("clone", "(Landroid/content/Context;I)V", "GetClone_Landroid_content_Context_IHandler")]
	public unsafe virtual void Clone(Context? context, int constraintLayoutId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(constraintLayoutId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clone.(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetClone_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Clone_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clone_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_constraintLayout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.Clone(constraintLayout);
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

	[Register("clone", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetClone_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void Clone(ConstraintLayout? constraintLayout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clone.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintLayout);
		}
	}

	private static Delegate GetClone_Landroidx_constraintlayout_widget_Constraints_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Clone_Landroidx_constraintlayout_widget_Constraints_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clone_Landroidx_constraintlayout_widget_Constraints_(nint jnienv, nint native__this, nint native_constraints)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraints constraints = Java.Lang.Object.GetObject<Constraints>(native_constraints, JniHandleOwnership.DoNotTransfer);
			constraintSet.Clone(constraints);
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

	[Register("clone", "(Landroidx/constraintlayout/widget/Constraints;)V", "GetClone_Landroidx_constraintlayout_widget_Constraints_Handler")]
	public unsafe virtual void Clone(Constraints? constraints)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraints?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clone.(Landroidx/constraintlayout/widget/Constraints;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraints);
		}
	}

	private static Delegate GetClone_Landroidx_constraintlayout_widget_ConstraintSet_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Clone_Landroidx_constraintlayout_widget_ConstraintSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clone_Landroidx_constraintlayout_widget_ConstraintSet_(nint jnienv, nint native__this, nint native_set)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet set = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			constraintSet.Clone(set);
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

	[Register("clone", "(Landroidx/constraintlayout/widget/ConstraintSet;)V", "GetClone_Landroidx_constraintlayout_widget_ConstraintSet_Handler")]
	public unsafe virtual void Clone(ConstraintSet? set)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("clone.(Landroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetConnect_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_Connect_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Connect_IIII(nint jnienv, nint native__this, int startID, int startSide, int endID, int endSide)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Connect(startID, startSide, endID, endSide);
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

	[Register("connect", "(IIII)V", "GetConnect_IIIIHandler")]
	public unsafe virtual void Connect(int startID, int startSide, int endID, int endSide)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(startID);
		ptr[1] = new JniArgumentValue(startSide);
		ptr[2] = new JniArgumentValue(endID);
		ptr[3] = new JniArgumentValue(endSide);
		_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(IIII)V", this, ptr);
	}

	private static Delegate GetConnect_IIIIIHandler()
	{
		return new global::_JniMarshal_PPIIIII_V(n_Connect_IIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Connect_IIIII(nint jnienv, nint native__this, int startID, int startSide, int endID, int endSide, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Connect(startID, startSide, endID, endSide, margin);
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

	[Register("connect", "(IIIII)V", "GetConnect_IIIIIHandler")]
	public unsafe virtual void Connect(int startID, int startSide, int endID, int endSide, int margin)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(startID);
		ptr[1] = new JniArgumentValue(startSide);
		ptr[2] = new JniArgumentValue(endID);
		ptr[3] = new JniArgumentValue(endSide);
		ptr[4] = new JniArgumentValue(margin);
		_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(IIIII)V", this, ptr);
	}

	private static Delegate GetConstrainCircle_IIIFHandler()
	{
		return new global::_JniMarshal_PPIIIF_V(n_ConstrainCircle_IIIF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainCircle_IIIF(nint jnienv, nint native__this, int viewId, int id, int radius, float angle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainCircle(viewId, id, radius, angle);
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

	[Register("constrainCircle", "(IIIF)V", "GetConstrainCircle_IIIFHandler")]
	public unsafe virtual void ConstrainCircle(int viewId, int id, int radius, float angle)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(id);
		ptr[2] = new JniArgumentValue(radius);
		ptr[3] = new JniArgumentValue(angle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainCircle.(IIIF)V", this, ptr);
	}

	private static Delegate GetConstrainDefaultHeight_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_ConstrainDefaultHeight_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainDefaultHeight_II(nint jnienv, nint native__this, int viewId, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainDefaultHeight(viewId, height);
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

	[Register("constrainDefaultHeight", "(II)V", "GetConstrainDefaultHeight_IIHandler")]
	public unsafe virtual void ConstrainDefaultHeight(int viewId, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(height);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainDefaultHeight.(II)V", this, ptr);
	}

	private static Delegate GetConstrainDefaultWidth_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_ConstrainDefaultWidth_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainDefaultWidth_II(nint jnienv, nint native__this, int viewId, int width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainDefaultWidth(viewId, width);
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

	[Register("constrainDefaultWidth", "(II)V", "GetConstrainDefaultWidth_IIHandler")]
	public unsafe virtual void ConstrainDefaultWidth(int viewId, int width)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(width);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainDefaultWidth.(II)V", this, ptr);
	}

	private static Delegate GetConstrainHeight_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_ConstrainHeight_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainHeight_II(nint jnienv, nint native__this, int viewId, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainHeight(viewId, height);
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

	[Register("constrainHeight", "(II)V", "GetConstrainHeight_IIHandler")]
	public unsafe virtual void ConstrainHeight(int viewId, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(height);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainHeight.(II)V", this, ptr);
	}

	private static Delegate GetConstrainMaxHeight_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_ConstrainMaxHeight_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainMaxHeight_II(nint jnienv, nint native__this, int viewId, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainMaxHeight(viewId, height);
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

	[Register("constrainMaxHeight", "(II)V", "GetConstrainMaxHeight_IIHandler")]
	public unsafe virtual void ConstrainMaxHeight(int viewId, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(height);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainMaxHeight.(II)V", this, ptr);
	}

	private static Delegate GetConstrainMaxWidth_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_ConstrainMaxWidth_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainMaxWidth_II(nint jnienv, nint native__this, int viewId, int width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainMaxWidth(viewId, width);
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

	[Register("constrainMaxWidth", "(II)V", "GetConstrainMaxWidth_IIHandler")]
	public unsafe virtual void ConstrainMaxWidth(int viewId, int width)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(width);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainMaxWidth.(II)V", this, ptr);
	}

	private static Delegate GetConstrainMinHeight_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_ConstrainMinHeight_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainMinHeight_II(nint jnienv, nint native__this, int viewId, int height)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainMinHeight(viewId, height);
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

	[Register("constrainMinHeight", "(II)V", "GetConstrainMinHeight_IIHandler")]
	public unsafe virtual void ConstrainMinHeight(int viewId, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(height);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainMinHeight.(II)V", this, ptr);
	}

	private static Delegate GetConstrainMinWidth_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_ConstrainMinWidth_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainMinWidth_II(nint jnienv, nint native__this, int viewId, int width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainMinWidth(viewId, width);
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

	[Register("constrainMinWidth", "(II)V", "GetConstrainMinWidth_IIHandler")]
	public unsafe virtual void ConstrainMinWidth(int viewId, int width)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(width);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainMinWidth.(II)V", this, ptr);
	}

	private static Delegate GetConstrainPercentHeight_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_ConstrainPercentHeight_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainPercentHeight_IF(nint jnienv, nint native__this, int viewId, float percent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainPercentHeight(viewId, percent);
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

	[Register("constrainPercentHeight", "(IF)V", "GetConstrainPercentHeight_IFHandler")]
	public unsafe virtual void ConstrainPercentHeight(int viewId, float percent)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(percent);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainPercentHeight.(IF)V", this, ptr);
	}

	private static Delegate GetConstrainPercentWidth_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_ConstrainPercentWidth_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainPercentWidth_IF(nint jnienv, nint native__this, int viewId, float percent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainPercentWidth(viewId, percent);
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

	[Register("constrainPercentWidth", "(IF)V", "GetConstrainPercentWidth_IFHandler")]
	public unsafe virtual void ConstrainPercentWidth(int viewId, float percent)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(percent);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainPercentWidth.(IF)V", this, ptr);
	}

	private static Delegate GetConstrainWidth_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_ConstrainWidth_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainWidth_II(nint jnienv, nint native__this, int viewId, int width)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstrainWidth(viewId, width);
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

	[Register("constrainWidth", "(II)V", "GetConstrainWidth_IIHandler")]
	public unsafe virtual void ConstrainWidth(int viewId, int width)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(width);
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainWidth.(II)V", this, ptr);
	}

	private static Delegate GetConstrainedHeight_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_ConstrainedHeight_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainedHeight_IZ(nint jnienv, nint native__this, int viewId, sbyte native_constrained)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool constrained = native_constrained != 0;
			constraintSet.ConstrainedHeight(viewId, constrained);
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

	[Register("constrainedHeight", "(IZ)V", "GetConstrainedHeight_IZHandler")]
	public unsafe virtual void ConstrainedHeight(int viewId, bool constrained)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(constrained ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainedHeight.(IZ)V", this, ptr);
	}

	private static Delegate GetConstrainedWidth_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_ConstrainedWidth_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ConstrainedWidth_IZ(nint jnienv, nint native__this, int viewId, sbyte native_constrained)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool constrained = native_constrained != 0;
			constraintSet.ConstrainedWidth(viewId, constrained);
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

	[Register("constrainedWidth", "(IZ)V", "GetConstrainedWidth_IZHandler")]
	public unsafe virtual void ConstrainedWidth(int viewId, bool constrained)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(constrained ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("constrainedWidth.(IZ)V", this, ptr);
	}

	private static Delegate GetCreate_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_Create_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Create_II(nint jnienv, nint native__this, int guidelineID, int orientation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Create(guidelineID, orientation);
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

	[Register("create", "(II)V", "GetCreate_IIHandler")]
	public unsafe virtual void Create(int guidelineID, int orientation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(guidelineID);
		ptr[1] = new JniArgumentValue(orientation);
		_members.InstanceMethods.InvokeVirtualVoidMethod("create.(II)V", this, ptr);
	}

	private static Delegate GetCreateBarrier_IIIarrayIHandler()
	{
		return new global::_JniMarshal_PPIIIL_V(n_CreateBarrier_IIIarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CreateBarrier_IIIarrayI(nint jnienv, nint native__this, int id, int direction, int margin, nint native_referenced)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_referenced, JniHandleOwnership.DoNotTransfer, typeof(int));
			constraintSet.CreateBarrier(id, direction, margin, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_referenced);
			}
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

	[Register("createBarrier", "(III[I)V", "GetCreateBarrier_IIIarrayIHandler")]
	public unsafe virtual void CreateBarrier(int id, int direction, int margin, params int[]? referenced)
	{
		nint num = JNIEnv.NewArray(referenced);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(direction);
			ptr[2] = new JniArgumentValue(margin);
			ptr[3] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("createBarrier.(III[I)V", this, ptr);
		}
		finally
		{
			if (referenced != null)
			{
				JNIEnv.CopyArray(num, referenced);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(referenced);
		}
	}

	private static Delegate GetCreateHorizontalChain_IIIIarrayIarrayFIHandler()
	{
		return new _JniMarshal_PPIIIILLI_V(n_CreateHorizontalChain_IIIIarrayIarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CreateHorizontalChain_IIIIarrayIarrayFI(nint jnienv, nint native__this, int leftId, int leftSide, int rightId, int rightSide, nint native_chainIds, nint native_weights, int style)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_chainIds, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_weights, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintSet.CreateHorizontalChain(leftId, leftSide, rightId, rightSide, array, array2, style);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chainIds);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_weights);
			}
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

	[Register("createHorizontalChain", "(IIII[I[FI)V", "GetCreateHorizontalChain_IIIIarrayIarrayFIHandler")]
	public unsafe virtual void CreateHorizontalChain(int leftId, int leftSide, int rightId, int rightSide, int[]? chainIds, float[]? weights, int style)
	{
		nint num = JNIEnv.NewArray(chainIds);
		nint num2 = JNIEnv.NewArray(weights);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(leftId);
			ptr[1] = new JniArgumentValue(leftSide);
			ptr[2] = new JniArgumentValue(rightId);
			ptr[3] = new JniArgumentValue(rightSide);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(num2);
			ptr[6] = new JniArgumentValue(style);
			_members.InstanceMethods.InvokeVirtualVoidMethod("createHorizontalChain.(IIII[I[FI)V", this, ptr);
		}
		finally
		{
			if (chainIds != null)
			{
				JNIEnv.CopyArray(num, chainIds);
				JNIEnv.DeleteLocalRef(num);
			}
			if (weights != null)
			{
				JNIEnv.CopyArray(num2, weights);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(chainIds);
			GC.KeepAlive(weights);
		}
	}

	private static Delegate GetCreateHorizontalChainRtl_IIIIarrayIarrayFIHandler()
	{
		return new _JniMarshal_PPIIIILLI_V(n_CreateHorizontalChainRtl_IIIIarrayIarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CreateHorizontalChainRtl_IIIIarrayIarrayFI(nint jnienv, nint native__this, int startId, int startSide, int endId, int endSide, nint native_chainIds, nint native_weights, int style)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_chainIds, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_weights, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintSet.CreateHorizontalChainRtl(startId, startSide, endId, endSide, array, array2, style);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chainIds);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_weights);
			}
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

	[Register("createHorizontalChainRtl", "(IIII[I[FI)V", "GetCreateHorizontalChainRtl_IIIIarrayIarrayFIHandler")]
	public unsafe virtual void CreateHorizontalChainRtl(int startId, int startSide, int endId, int endSide, int[]? chainIds, float[]? weights, int style)
	{
		nint num = JNIEnv.NewArray(chainIds);
		nint num2 = JNIEnv.NewArray(weights);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(startId);
			ptr[1] = new JniArgumentValue(startSide);
			ptr[2] = new JniArgumentValue(endId);
			ptr[3] = new JniArgumentValue(endSide);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(num2);
			ptr[6] = new JniArgumentValue(style);
			_members.InstanceMethods.InvokeVirtualVoidMethod("createHorizontalChainRtl.(IIII[I[FI)V", this, ptr);
		}
		finally
		{
			if (chainIds != null)
			{
				JNIEnv.CopyArray(num, chainIds);
				JNIEnv.DeleteLocalRef(num);
			}
			if (weights != null)
			{
				JNIEnv.CopyArray(num2, weights);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(chainIds);
			GC.KeepAlive(weights);
		}
	}

	private static Delegate GetCreateVerticalChain_IIIIarrayIarrayFIHandler()
	{
		return new _JniMarshal_PPIIIILLI_V(n_CreateVerticalChain_IIIIarrayIarrayFI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CreateVerticalChain_IIIIarrayIarrayFI(nint jnienv, nint native__this, int topId, int topSide, int bottomId, int bottomSide, nint native_chainIds, nint native_weights, int style)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_chainIds, JniHandleOwnership.DoNotTransfer, typeof(int));
			float[] array2 = (float[])JNIEnv.GetArray(native_weights, JniHandleOwnership.DoNotTransfer, typeof(float));
			constraintSet.CreateVerticalChain(topId, topSide, bottomId, bottomSide, array, array2, style);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chainIds);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_weights);
			}
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

	[Register("createVerticalChain", "(IIII[I[FI)V", "GetCreateVerticalChain_IIIIarrayIarrayFIHandler")]
	public unsafe virtual void CreateVerticalChain(int topId, int topSide, int bottomId, int bottomSide, int[]? chainIds, float[]? weights, int style)
	{
		nint num = JNIEnv.NewArray(chainIds);
		nint num2 = JNIEnv.NewArray(weights);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(topId);
			ptr[1] = new JniArgumentValue(topSide);
			ptr[2] = new JniArgumentValue(bottomId);
			ptr[3] = new JniArgumentValue(bottomSide);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(num2);
			ptr[6] = new JniArgumentValue(style);
			_members.InstanceMethods.InvokeVirtualVoidMethod("createVerticalChain.(IIII[I[FI)V", this, ptr);
		}
		finally
		{
			if (chainIds != null)
			{
				JNIEnv.CopyArray(num, chainIds);
				JNIEnv.DeleteLocalRef(num);
			}
			if (weights != null)
			{
				JNIEnv.CopyArray(num2, weights);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(chainIds);
			GC.KeepAlive(weights);
		}
	}

	private static Delegate GetDump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayIHandler()
	{
		return new global::_JniMarshal_PPLL_V(n_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Dump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayI(nint jnienv, nint native__this, nint native_scene, nint native_ids)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionScene scene = Java.Lang.Object.GetObject<MotionScene>(native_scene, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_ids, JniHandleOwnership.DoNotTransfer, typeof(int));
			constraintSet.Dump(scene, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_ids);
			}
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

	[Register("dump", "(Landroidx/constraintlayout/motion/widget/MotionScene;[I)V", "GetDump_Landroidx_constraintlayout_motion_widget_MotionScene_arrayIHandler")]
	public unsafe virtual void Dump(MotionScene? scene, params int[]? ids)
	{
		nint num = JNIEnv.NewArray(ids);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(scene?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dump.(Landroidx/constraintlayout/motion/widget/MotionScene;[I)V", this, ptr);
		}
		finally
		{
			if (ids != null)
			{
				JNIEnv.CopyArray(num, ids);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(scene);
			GC.KeepAlive(ids);
		}
	}

	private static Delegate GetGetApplyElevation_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_GetApplyElevation_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetApplyElevation_I(nint jnienv, nint native__this, int viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetApplyElevation(viewId) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("getApplyElevation", "(I)Z", "GetGetApplyElevation_IHandler")]
	public unsafe virtual bool GetApplyElevation(int viewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewId);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("getApplyElevation.(I)Z", this, ptr);
	}

	private static Delegate GetGetConstraint_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetConstraint_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetConstraint_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetConstraint(id));
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

	[Register("getConstraint", "(I)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", "GetGetConstraint_IHandler")]
	public unsafe virtual Constraint? GetConstraint(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<Constraint>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraint.(I)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHeight_I(nint jnienv, nint native__this, int viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHeight(viewId);
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

	[Register("getHeight", "(I)I", "GetGetHeight_IHandler")]
	public unsafe virtual int GetHeight(int viewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewId);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getHeight.(I)I", this, ptr);
	}

	private static Delegate GetGetKnownIdsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetKnownIds);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetKnownIds(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetKnownIds());
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

	[Register("getKnownIds", "()[I", "GetGetKnownIdsHandler")]
	public unsafe virtual int[]? GetKnownIds()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getKnownIds.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	private static Delegate GetGetParameters_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetParameters_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParameters_I(nint jnienv, nint native__this, int mId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetParameters(mId));
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

	[Register("getParameters", "(I)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", "GetGetParameters_IHandler")]
	public unsafe virtual Constraint? GetParameters(int mId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mId);
		return Java.Lang.Object.GetObject<Constraint>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParameters.(I)Landroidx/constraintlayout/widget/ConstraintSet$Constraint;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetReferencedIds_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetReferencedIds_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetReferencedIds_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetReferencedIds(id));
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

	[Register("getReferencedIds", "(I)[I", "GetGetReferencedIds_IHandler")]
	public unsafe virtual int[]? GetReferencedIds(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getReferencedIds.(I)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	private static Delegate GetGetStateLabelsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStateLabels);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStateLabels(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetStateLabels());
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

	[Register("getStateLabels", "()[Ljava/lang/String;", "GetGetStateLabelsHandler")]
	public unsafe virtual string[]? GetStateLabels()
	{
		return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getStateLabels.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
	}

	private static Delegate GetGetVisibility_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetVisibility_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVisibility_I(nint jnienv, nint native__this, int viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetVisibility(viewId);
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

	[Register("getVisibility", "(I)I", "GetGetVisibility_IHandler")]
	public unsafe virtual int GetVisibility(int viewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewId);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getVisibility.(I)I", this, ptr);
	}

	private static Delegate GetGetVisibilityMode_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetVisibilityMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVisibilityMode_I(nint jnienv, nint native__this, int viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetVisibilityMode(viewId);
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

	[Register("getVisibilityMode", "(I)I", "GetGetVisibilityMode_IHandler")]
	public unsafe virtual int GetVisibilityMode(int viewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewId);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getVisibilityMode.(I)I", this, ptr);
	}

	private static Delegate GetGetWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_GetWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetWidth_I(nint jnienv, nint native__this, int viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetWidth(viewId);
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

	[Register("getWidth", "(I)I", "GetGetWidth_IHandler")]
	public unsafe virtual int GetWidth(int viewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewId);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getWidth.(I)I", this, ptr);
	}

	private static Delegate GetLoad_Landroid_content_Context_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_Load_Landroid_content_Context_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Load_Landroid_content_Context_I(nint jnienv, nint native__this, nint native_context, int resourceId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			constraintSet.Load(context, resourceId);
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

	[Register("load", "(Landroid/content/Context;I)V", "GetLoad_Landroid_content_Context_IHandler")]
	public unsafe virtual void Load(Context? context, int resourceId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("load.(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetLoad_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_Load_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Load_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_(nint jnienv, nint native__this, nint native_context, nint native_parser)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			XmlReader parser = XmlPullParserReader.FromJniHandle(native_parser, JniHandleOwnership.DoNotTransfer);
			constraintSet.Load(context, parser);
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

	[Register("load", "(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", "GetLoad_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_Handler")]
	public unsafe virtual void Load(Context? context, XmlReader? parser)
	{
		nint num = XmlReaderPullParser.ToLocalJniHandle(parser);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("load.(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
			GC.KeepAlive(parser);
		}
	}

	private static Delegate GetMatchesLabels_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_MatchesLabels_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_MatchesLabels_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_types)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_types, JniHandleOwnership.DoNotTransfer, typeof(string));
			sbyte result = (constraintSet.MatchesLabels(array) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_types);
			}
			return result;
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

	[Register("matchesLabels", "([Ljava/lang/String;)Z", "GetMatchesLabels_arrayLjava_lang_String_Handler")]
	public unsafe virtual bool MatchesLabels(params string[]? types)
	{
		nint num = JNIEnv.NewArray(types);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("matchesLabels.([Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			if (types != null)
			{
				JNIEnv.CopyArray(num, types);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(types);
		}
	}

	private static Delegate GetParseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_ParseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ParseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_(nint jnienv, nint native__this, nint native_set, nint native_attributes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraint set = Java.Lang.Object.GetObject<Constraint>(native_set, JniHandleOwnership.DoNotTransfer);
			string attributes = JNIEnv.GetString(native_attributes, JniHandleOwnership.DoNotTransfer);
			constraintSet.ParseColorAttributes(set, attributes);
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

	[Register("parseColorAttributes", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", "GetParseColorAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler")]
	public unsafe virtual void ParseColorAttributes(Constraint? set, string? attributes)
	{
		nint num = JNIEnv.NewString(attributes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("parseColorAttributes.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetParseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_ParseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ParseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_(nint jnienv, nint native__this, nint native_set, nint native_attributes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraint set = Java.Lang.Object.GetObject<Constraint>(native_set, JniHandleOwnership.DoNotTransfer);
			string attributes = JNIEnv.GetString(native_attributes, JniHandleOwnership.DoNotTransfer);
			constraintSet.ParseFloatAttributes(set, attributes);
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

	[Register("parseFloatAttributes", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", "GetParseFloatAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler")]
	public unsafe virtual void ParseFloatAttributes(Constraint? set, string? attributes)
	{
		nint num = JNIEnv.NewString(attributes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("parseFloatAttributes.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetParseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_ParseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ParseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_(nint jnienv, nint native__this, nint native_set, nint native_attributes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraint set = Java.Lang.Object.GetObject<Constraint>(native_set, JniHandleOwnership.DoNotTransfer);
			string attributes = JNIEnv.GetString(native_attributes, JniHandleOwnership.DoNotTransfer);
			constraintSet.ParseIntAttributes(set, attributes);
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

	[Register("parseIntAttributes", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", "GetParseIntAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler")]
	public unsafe virtual void ParseIntAttributes(Constraint? set, string? attributes)
	{
		nint num = JNIEnv.NewString(attributes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("parseIntAttributes.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetParseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_ParseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ParseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_(nint jnienv, nint native__this, nint native_set, nint native_attributes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Constraint set = Java.Lang.Object.GetObject<Constraint>(native_set, JniHandleOwnership.DoNotTransfer);
			string attributes = JNIEnv.GetString(native_attributes, JniHandleOwnership.DoNotTransfer);
			constraintSet.ParseStringAttributes(set, attributes);
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

	[Register("parseStringAttributes", "(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", "GetParseStringAttributes_Landroidx_constraintlayout_widget_ConstraintSet_Constraint_Ljava_lang_String_Handler")]
	public unsafe virtual void ParseStringAttributes(Constraint? set, string? attributes)
	{
		nint num = JNIEnv.NewString(attributes);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("parseStringAttributes.(Landroidx/constraintlayout/widget/ConstraintSet$Constraint;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetReadFallback_Landroidx_constraintlayout_widget_ConstraintLayout_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ReadFallback_Landroidx_constraintlayout_widget_ConstraintLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ReadFallback_Landroidx_constraintlayout_widget_ConstraintLayout_(nint jnienv, nint native__this, nint native_constraintLayout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(native_constraintLayout, JniHandleOwnership.DoNotTransfer);
			constraintSet.ReadFallback(constraintLayout);
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

	[Register("readFallback", "(Landroidx/constraintlayout/widget/ConstraintLayout;)V", "GetReadFallback_Landroidx_constraintlayout_widget_ConstraintLayout_Handler")]
	public unsafe virtual void ReadFallback(ConstraintLayout? constraintLayout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraintLayout?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("readFallback.(Landroidx/constraintlayout/widget/ConstraintLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintLayout);
		}
	}

	private static Delegate GetReadFallback_Landroidx_constraintlayout_widget_ConstraintSet_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ReadFallback_Landroidx_constraintlayout_widget_ConstraintSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ReadFallback_Landroidx_constraintlayout_widget_ConstraintSet_(nint jnienv, nint native__this, nint native_set)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet set = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			constraintSet.ReadFallback(set);
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

	[Register("readFallback", "(Landroidx/constraintlayout/widget/ConstraintSet;)V", "GetReadFallback_Landroidx_constraintlayout_widget_ConstraintSet_Handler")]
	public unsafe virtual void ReadFallback(ConstraintSet? set)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("readFallback.(Landroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetRemoveAttribute_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveAttribute_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveAttribute_Ljava_lang_String_(nint jnienv, nint native__this, nint native_attributeName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			constraintSet.RemoveAttribute(attributeName);
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

	[Register("removeAttribute", "(Ljava/lang/String;)V", "GetRemoveAttribute_Ljava_lang_String_Handler")]
	public unsafe virtual void RemoveAttribute(string? attributeName)
	{
		nint num = JNIEnv.NewString(attributeName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeAttribute.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetRemoveFromHorizontalChain_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveFromHorizontalChain_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveFromHorizontalChain_I(nint jnienv, nint native__this, int viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveFromHorizontalChain(viewId);
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

	[Register("removeFromHorizontalChain", "(I)V", "GetRemoveFromHorizontalChain_IHandler")]
	public unsafe virtual void RemoveFromHorizontalChain(int viewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeFromHorizontalChain.(I)V", this, ptr);
	}

	private static Delegate GetRemoveFromVerticalChain_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveFromVerticalChain_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveFromVerticalChain_I(nint jnienv, nint native__this, int viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveFromVerticalChain(viewId);
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

	[Register("removeFromVerticalChain", "(I)V", "GetRemoveFromVerticalChain_IHandler")]
	public unsafe virtual void RemoveFromVerticalChain(int viewId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(viewId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeFromVerticalChain.(I)V", this, ptr);
	}

	private static Delegate GetSetAlpha_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetAlpha_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAlpha_IF(nint jnienv, nint native__this, int viewId, float alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAlpha(viewId, alpha);
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

	[Register("setAlpha", "(IF)V", "GetSetAlpha_IFHandler")]
	public unsafe virtual void SetAlpha(int viewId, float alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(alpha);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAlpha.(IF)V", this, ptr);
	}

	private static Delegate GetSetApplyElevation_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_SetApplyElevation_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetApplyElevation_IZ(nint jnienv, nint native__this, int viewId, sbyte native_apply)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool apply = native_apply != 0;
			constraintSet.SetApplyElevation(viewId, apply);
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

	[Register("setApplyElevation", "(IZ)V", "GetSetApplyElevation_IZHandler")]
	public unsafe virtual void SetApplyElevation(int viewId, bool apply)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(apply ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setApplyElevation.(IZ)V", this, ptr);
	}

	private static Delegate GetSetBarrierType_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetBarrierType_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBarrierType_II(nint jnienv, nint native__this, int id, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBarrierType(id, type);
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

	[Register("setBarrierType", "(II)V", "GetSetBarrierType_IIHandler")]
	public unsafe virtual void SetBarrierType(int id, int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(type);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBarrierType.(II)V", this, ptr);
	}

	private static Delegate GetSetColorValue_ILjava_lang_String_IHandler()
	{
		return new global::_JniMarshal_PPILI_V(n_SetColorValue_ILjava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColorValue_ILjava_lang_String_I(nint jnienv, nint native__this, int viewId, nint native_attributeName, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetColorValue(viewId, attributeName, value);
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

	[Register("setColorValue", "(ILjava/lang/String;I)V", "GetSetColorValue_ILjava_lang_String_IHandler")]
	public unsafe virtual void SetColorValue(int viewId, string? attributeName, int value)
	{
		nint num = JNIEnv.NewString(attributeName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColorValue.(ILjava/lang/String;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetDimensionRatio_ILjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_SetDimensionRatio_ILjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDimensionRatio_ILjava_lang_String_(nint jnienv, nint native__this, int viewId, nint native_ratio)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string ratio = JNIEnv.GetString(native_ratio, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetDimensionRatio(viewId, ratio);
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

	[Register("setDimensionRatio", "(ILjava/lang/String;)V", "GetSetDimensionRatio_ILjava_lang_String_Handler")]
	public unsafe virtual void SetDimensionRatio(int viewId, string? ratio)
	{
		nint num = JNIEnv.NewString(ratio);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDimensionRatio.(ILjava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetEditorAbsoluteX_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetEditorAbsoluteX_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEditorAbsoluteX_II(nint jnienv, nint native__this, int viewId, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEditorAbsoluteX(viewId, position);
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

	[Register("setEditorAbsoluteX", "(II)V", "GetSetEditorAbsoluteX_IIHandler")]
	public unsafe virtual void SetEditorAbsoluteX(int viewId, int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEditorAbsoluteX.(II)V", this, ptr);
	}

	private static Delegate GetSetEditorAbsoluteY_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetEditorAbsoluteY_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEditorAbsoluteY_II(nint jnienv, nint native__this, int viewId, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetEditorAbsoluteY(viewId, position);
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

	[Register("setEditorAbsoluteY", "(II)V", "GetSetEditorAbsoluteY_IIHandler")]
	public unsafe virtual void SetEditorAbsoluteY(int viewId, int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEditorAbsoluteY.(II)V", this, ptr);
	}

	private static Delegate GetSetElevation_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetElevation_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetElevation_IF(nint jnienv, nint native__this, int viewId, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetElevation(viewId, elevation);
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

	[Register("setElevation", "(IF)V", "GetSetElevation_IFHandler")]
	public unsafe virtual void SetElevation(int viewId, float elevation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(elevation);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setElevation.(IF)V", this, ptr);
	}

	private static Delegate GetSetFloatValue_ILjava_lang_String_FHandler()
	{
		return new _JniMarshal_PPILF_V(n_SetFloatValue_ILjava_lang_String_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFloatValue_ILjava_lang_String_F(nint jnienv, nint native__this, int viewId, nint native_attributeName, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetFloatValue(viewId, attributeName, value);
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

	[Register("setFloatValue", "(ILjava/lang/String;F)V", "GetSetFloatValue_ILjava_lang_String_FHandler")]
	public unsafe virtual void SetFloatValue(int viewId, string? attributeName, float value)
	{
		nint num = JNIEnv.NewString(attributeName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFloatValue.(ILjava/lang/String;F)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetGoneMargin_IIIHandler()
	{
		return new global::_JniMarshal_PPIII_V(n_SetGoneMargin_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGoneMargin_III(nint jnienv, nint native__this, int viewId, int anchor, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGoneMargin(viewId, anchor, value);
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

	[Register("setGoneMargin", "(III)V", "GetSetGoneMargin_IIIHandler")]
	public unsafe virtual void SetGoneMargin(int viewId, int anchor, int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(anchor);
		ptr[2] = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGoneMargin.(III)V", this, ptr);
	}

	private static Delegate GetSetGuidelineBegin_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetGuidelineBegin_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGuidelineBegin_II(nint jnienv, nint native__this, int guidelineID, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidelineBegin(guidelineID, margin);
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

	[Register("setGuidelineBegin", "(II)V", "GetSetGuidelineBegin_IIHandler")]
	public unsafe virtual void SetGuidelineBegin(int guidelineID, int margin)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(guidelineID);
		ptr[1] = new JniArgumentValue(margin);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidelineBegin.(II)V", this, ptr);
	}

	private static Delegate GetSetGuidelineEnd_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetGuidelineEnd_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGuidelineEnd_II(nint jnienv, nint native__this, int guidelineID, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidelineEnd(guidelineID, margin);
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

	[Register("setGuidelineEnd", "(II)V", "GetSetGuidelineEnd_IIHandler")]
	public unsafe virtual void SetGuidelineEnd(int guidelineID, int margin)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(guidelineID);
		ptr[1] = new JniArgumentValue(margin);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidelineEnd.(II)V", this, ptr);
	}

	private static Delegate GetSetGuidelinePercent_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetGuidelinePercent_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGuidelinePercent_IF(nint jnienv, nint native__this, int guidelineID, float ratio)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidelinePercent(guidelineID, ratio);
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

	[Register("setGuidelinePercent", "(IF)V", "GetSetGuidelinePercent_IFHandler")]
	public unsafe virtual void SetGuidelinePercent(int guidelineID, float ratio)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(guidelineID);
		ptr[1] = new JniArgumentValue(ratio);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidelinePercent.(IF)V", this, ptr);
	}

	private static Delegate GetSetHorizontalBias_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetHorizontalBias_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalBias_IF(nint jnienv, nint native__this, int viewId, float bias)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalBias(viewId, bias);
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

	[Register("setHorizontalBias", "(IF)V", "GetSetHorizontalBias_IFHandler")]
	public unsafe virtual void SetHorizontalBias(int viewId, float bias)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(bias);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalBias.(IF)V", this, ptr);
	}

	private static Delegate GetSetHorizontalChainStyle_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetHorizontalChainStyle_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalChainStyle_II(nint jnienv, nint native__this, int viewId, int chainStyle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalChainStyle(viewId, chainStyle);
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

	[Register("setHorizontalChainStyle", "(II)V", "GetSetHorizontalChainStyle_IIHandler")]
	public unsafe virtual void SetHorizontalChainStyle(int viewId, int chainStyle)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(chainStyle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalChainStyle.(II)V", this, ptr);
	}

	private static Delegate GetSetHorizontalWeight_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetHorizontalWeight_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalWeight_IF(nint jnienv, nint native__this, int viewId, float weight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalWeight(viewId, weight);
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

	[Register("setHorizontalWeight", "(IF)V", "GetSetHorizontalWeight_IFHandler")]
	public unsafe virtual void SetHorizontalWeight(int viewId, float weight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(weight);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalWeight.(IF)V", this, ptr);
	}

	private static Delegate GetSetIntValue_ILjava_lang_String_IHandler()
	{
		return new global::_JniMarshal_PPILI_V(n_SetIntValue_ILjava_lang_String_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIntValue_ILjava_lang_String_I(nint jnienv, nint native__this, int viewId, nint native_attributeName, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetIntValue(viewId, attributeName, value);
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

	[Register("setIntValue", "(ILjava/lang/String;I)V", "GetSetIntValue_ILjava_lang_String_IHandler")]
	public unsafe virtual void SetIntValue(int viewId, string? attributeName, int value)
	{
		nint num = JNIEnv.NewString(attributeName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setIntValue.(ILjava/lang/String;I)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetLayoutWrapBehavior_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetLayoutWrapBehavior_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLayoutWrapBehavior_II(nint jnienv, nint native__this, int viewId, int behavior)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLayoutWrapBehavior(viewId, behavior);
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

	[Register("setLayoutWrapBehavior", "(II)V", "GetSetLayoutWrapBehavior_IIHandler")]
	public unsafe virtual void SetLayoutWrapBehavior(int viewId, int behavior)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(behavior);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setLayoutWrapBehavior.(II)V", this, ptr);
	}

	private static Delegate GetSetMargin_IIIHandler()
	{
		return new global::_JniMarshal_PPIII_V(n_SetMargin_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMargin_III(nint jnienv, nint native__this, int viewId, int anchor, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMargin(viewId, anchor, value);
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

	[Register("setMargin", "(III)V", "GetSetMargin_IIIHandler")]
	public unsafe virtual void SetMargin(int viewId, int anchor, int value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(anchor);
		ptr[2] = new JniArgumentValue(value);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setMargin.(III)V", this, ptr);
	}

	private static Delegate GetSetReferencedIds_IarrayIHandler()
	{
		return new global::_JniMarshal_PPIL_V(n_SetReferencedIds_IarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetReferencedIds_IarrayI(nint jnienv, nint native__this, int id, nint native_referenced)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_referenced, JniHandleOwnership.DoNotTransfer, typeof(int));
			constraintSet.SetReferencedIds(id, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_referenced);
			}
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

	[Register("setReferencedIds", "(I[I)V", "GetSetReferencedIds_IarrayIHandler")]
	public unsafe virtual void SetReferencedIds(int id, params int[]? referenced)
	{
		nint num = JNIEnv.NewArray(referenced);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setReferencedIds.(I[I)V", this, ptr);
		}
		finally
		{
			if (referenced != null)
			{
				JNIEnv.CopyArray(num, referenced);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(referenced);
		}
	}

	private static Delegate GetSetRotation_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetRotation_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRotation_IF(nint jnienv, nint native__this, int viewId, float rotation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotation(viewId, rotation);
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

	[Register("setRotation", "(IF)V", "GetSetRotation_IFHandler")]
	public unsafe virtual void SetRotation(int viewId, float rotation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(rotation);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRotation.(IF)V", this, ptr);
	}

	private static Delegate GetSetRotationX_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetRotationX_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRotationX_IF(nint jnienv, nint native__this, int viewId, float rotationX)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotationX(viewId, rotationX);
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

	[Register("setRotationX", "(IF)V", "GetSetRotationX_IFHandler")]
	public unsafe virtual void SetRotationX(int viewId, float rotationX)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(rotationX);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRotationX.(IF)V", this, ptr);
	}

	private static Delegate GetSetRotationY_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetRotationY_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRotationY_IF(nint jnienv, nint native__this, int viewId, float rotationY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetRotationY(viewId, rotationY);
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

	[Register("setRotationY", "(IF)V", "GetSetRotationY_IFHandler")]
	public unsafe virtual void SetRotationY(int viewId, float rotationY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(rotationY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRotationY.(IF)V", this, ptr);
	}

	private static Delegate GetSetScaleX_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetScaleX_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScaleX_IF(nint jnienv, nint native__this, int viewId, float scaleX)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScaleX(viewId, scaleX);
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

	[Register("setScaleX", "(IF)V", "GetSetScaleX_IFHandler")]
	public unsafe virtual void SetScaleX(int viewId, float scaleX)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(scaleX);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScaleX.(IF)V", this, ptr);
	}

	private static Delegate GetSetScaleY_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetScaleY_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScaleY_IF(nint jnienv, nint native__this, int viewId, float scaleY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScaleY(viewId, scaleY);
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

	[Register("setScaleY", "(IF)V", "GetSetScaleY_IFHandler")]
	public unsafe virtual void SetScaleY(int viewId, float scaleY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(scaleY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScaleY.(IF)V", this, ptr);
	}

	private static Delegate GetSetStateLabels_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStateLabels_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStateLabels_Ljava_lang_String_(nint jnienv, nint native__this, nint native_types)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string stateLabels = JNIEnv.GetString(native_types, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetStateLabels(stateLabels);
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

	[Register("setStateLabels", "(Ljava/lang/String;)V", "GetSetStateLabels_Ljava_lang_String_Handler")]
	public unsafe virtual void SetStateLabels(string? types)
	{
		nint num = JNIEnv.NewString(types);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStateLabels.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetStateLabelsList_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStateLabelsList_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStateLabelsList_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_types)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_types, JniHandleOwnership.DoNotTransfer, typeof(string));
			constraintSet.SetStateLabelsList(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_types);
			}
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

	[Register("setStateLabelsList", "([Ljava/lang/String;)V", "GetSetStateLabelsList_arrayLjava_lang_String_Handler")]
	public unsafe virtual void SetStateLabelsList(params string[]? types)
	{
		nint num = JNIEnv.NewArray(types);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStateLabelsList.([Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			if (types != null)
			{
				JNIEnv.CopyArray(num, types);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(types);
		}
	}

	private static Delegate GetSetStringValue_ILjava_lang_String_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPILL_V(n_SetStringValue_ILjava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStringValue_ILjava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, int viewId, nint native_attributeName, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string attributeName = JNIEnv.GetString(native_attributeName, JniHandleOwnership.DoNotTransfer);
			string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
			constraintSet.SetStringValue(viewId, attributeName, value);
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

	[Register("setStringValue", "(ILjava/lang/String;Ljava/lang/String;)V", "GetSetStringValue_ILjava_lang_String_Ljava_lang_String_Handler")]
	public unsafe virtual void SetStringValue(int viewId, string? attributeName, string? value)
	{
		nint num = JNIEnv.NewString(attributeName);
		nint num2 = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(viewId);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStringValue.(ILjava/lang/String;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	private static Delegate GetSetTransformPivot_IFFHandler()
	{
		return new _JniMarshal_PPIFF_V(n_SetTransformPivot_IFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransformPivot_IFF(nint jnienv, nint native__this, int viewId, float transformPivotX, float transformPivotY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransformPivot(viewId, transformPivotX, transformPivotY);
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

	[Register("setTransformPivot", "(IFF)V", "GetSetTransformPivot_IFFHandler")]
	public unsafe virtual void SetTransformPivot(int viewId, float transformPivotX, float transformPivotY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(transformPivotX);
		ptr[2] = new JniArgumentValue(transformPivotY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTransformPivot.(IFF)V", this, ptr);
	}

	private static Delegate GetSetTransformPivotX_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetTransformPivotX_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransformPivotX_IF(nint jnienv, nint native__this, int viewId, float transformPivotX)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransformPivotX(viewId, transformPivotX);
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

	[Register("setTransformPivotX", "(IF)V", "GetSetTransformPivotX_IFHandler")]
	public unsafe virtual void SetTransformPivotX(int viewId, float transformPivotX)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(transformPivotX);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTransformPivotX.(IF)V", this, ptr);
	}

	private static Delegate GetSetTransformPivotY_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetTransformPivotY_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransformPivotY_IF(nint jnienv, nint native__this, int viewId, float transformPivotY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransformPivotY(viewId, transformPivotY);
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

	[Register("setTransformPivotY", "(IF)V", "GetSetTransformPivotY_IFHandler")]
	public unsafe virtual void SetTransformPivotY(int viewId, float transformPivotY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(transformPivotY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTransformPivotY.(IF)V", this, ptr);
	}

	private static Delegate GetSetTranslation_IFFHandler()
	{
		return new _JniMarshal_PPIFF_V(n_SetTranslation_IFF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslation_IFF(nint jnienv, nint native__this, int viewId, float translationX, float translationY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTranslation(viewId, translationX, translationY);
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

	[Register("setTranslation", "(IFF)V", "GetSetTranslation_IFFHandler")]
	public unsafe virtual void SetTranslation(int viewId, float translationX, float translationY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(translationX);
		ptr[2] = new JniArgumentValue(translationY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslation.(IFF)V", this, ptr);
	}

	private static Delegate GetSetTranslationX_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetTranslationX_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslationX_IF(nint jnienv, nint native__this, int viewId, float translationX)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTranslationX(viewId, translationX);
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

	[Register("setTranslationX", "(IF)V", "GetSetTranslationX_IFHandler")]
	public unsafe virtual void SetTranslationX(int viewId, float translationX)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(translationX);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationX.(IF)V", this, ptr);
	}

	private static Delegate GetSetTranslationY_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetTranslationY_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslationY_IF(nint jnienv, nint native__this, int viewId, float translationY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTranslationY(viewId, translationY);
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

	[Register("setTranslationY", "(IF)V", "GetSetTranslationY_IFHandler")]
	public unsafe virtual void SetTranslationY(int viewId, float translationY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(translationY);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationY.(IF)V", this, ptr);
	}

	private static Delegate GetSetTranslationZ_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetTranslationZ_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslationZ_IF(nint jnienv, nint native__this, int viewId, float translationZ)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTranslationZ(viewId, translationZ);
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

	[Register("setTranslationZ", "(IF)V", "GetSetTranslationZ_IFHandler")]
	public unsafe virtual void SetTranslationZ(int viewId, float translationZ)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(translationZ);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationZ.(IF)V", this, ptr);
	}

	private static Delegate GetSetVerticalBias_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetVerticalBias_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalBias_IF(nint jnienv, nint native__this, int viewId, float bias)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalBias(viewId, bias);
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

	[Register("setVerticalBias", "(IF)V", "GetSetVerticalBias_IFHandler")]
	public unsafe virtual void SetVerticalBias(int viewId, float bias)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(bias);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalBias.(IF)V", this, ptr);
	}

	private static Delegate GetSetVerticalChainStyle_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetVerticalChainStyle_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalChainStyle_II(nint jnienv, nint native__this, int viewId, int chainStyle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalChainStyle(viewId, chainStyle);
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

	[Register("setVerticalChainStyle", "(II)V", "GetSetVerticalChainStyle_IIHandler")]
	public unsafe virtual void SetVerticalChainStyle(int viewId, int chainStyle)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(chainStyle);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalChainStyle.(II)V", this, ptr);
	}

	private static Delegate GetSetVerticalWeight_IFHandler()
	{
		return new global::_JniMarshal_PPIF_V(n_SetVerticalWeight_IF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalWeight_IF(nint jnienv, nint native__this, int viewId, float weight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalWeight(viewId, weight);
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

	[Register("setVerticalWeight", "(IF)V", "GetSetVerticalWeight_IFHandler")]
	public unsafe virtual void SetVerticalWeight(int viewId, float weight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(weight);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalWeight.(IF)V", this, ptr);
	}

	private static Delegate GetSetVisibility_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetVisibility_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVisibility_II(nint jnienv, nint native__this, int viewId, int visibility)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVisibility(viewId, visibility);
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

	[Register("setVisibility", "(II)V", "GetSetVisibility_IIHandler")]
	public unsafe virtual void SetVisibility(int viewId, int visibility)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(visibility);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibility.(II)V", this, ptr);
	}

	private static Delegate GetSetVisibilityMode_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetVisibilityMode_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVisibilityMode_II(nint jnienv, nint native__this, int viewId, int visibilityMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVisibilityMode(viewId, visibilityMode);
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

	[Register("setVisibilityMode", "(II)V", "GetSetVisibilityMode_IIHandler")]
	public unsafe virtual void SetVisibilityMode(int viewId, int visibilityMode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(viewId);
		ptr[1] = new JniArgumentValue(visibilityMode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibilityMode.(II)V", this, ptr);
	}

	private static Delegate GetWriteState_Ljava_io_Writer_Landroidx_constraintlayout_widget_ConstraintLayout_IHandler()
	{
		return new global::_JniMarshal_PPLLI_V(n_WriteState_Ljava_io_Writer_Landroidx_constraintlayout_widget_ConstraintLayout_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_WriteState_Ljava_io_Writer_Landroidx_constraintlayout_widget_ConstraintLayout_I(nint jnienv, nint native__this, nint native_writer, nint native_layout, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintSet? constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Writer writer = Java.Lang.Object.GetObject<Writer>(native_writer, JniHandleOwnership.DoNotTransfer);
			ConstraintLayout layout = Java.Lang.Object.GetObject<ConstraintLayout>(native_layout, JniHandleOwnership.DoNotTransfer);
			constraintSet.WriteState(writer, layout, flags);
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

	[Register("writeState", "(Ljava/io/Writer;Landroidx/constraintlayout/widget/ConstraintLayout;I)V", "GetWriteState_Ljava_io_Writer_Landroidx_constraintlayout_widget_ConstraintLayout_IHandler")]
	public unsafe virtual void WriteState(Writer? writer, ConstraintLayout? layout, int flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(writer?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(flags);
			_members.InstanceMethods.InvokeVirtualVoidMethod("writeState.(Ljava/io/Writer;Landroidx/constraintlayout/widget/ConstraintLayout;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(writer);
			GC.KeepAlive(layout);
		}
	}
}
