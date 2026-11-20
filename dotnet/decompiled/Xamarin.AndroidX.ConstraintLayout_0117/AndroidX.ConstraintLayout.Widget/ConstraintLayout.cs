using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.ConstraintLayout.Core;
using AndroidX.ConstraintLayout.Core.Widgets;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Widget;

[Register("androidx/constraintlayout/widget/ConstraintLayout", DoNotGenerateAcw = true)]
public class ConstraintLayout : ViewGroup
{
	[Register("androidx/constraintlayout/widget/ConstraintLayout$LayoutParams", DoNotGenerateAcw = true)]
	public new class LayoutParams : MarginLayoutParams
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintLayout$LayoutParams", typeof(LayoutParams));

		private static Delegate? cb_getConstraintTag_GetConstraintTag_Ljava_lang_String_;

		private static Delegate? cb_getConstraintWidget_GetConstraintWidget_Landroidx_constraintlayout_core_widgets_ConstraintWidget_;

		private static Delegate? cb_reset_Reset_V;

		private static Delegate? cb_setWidgetDebugName_SetWidgetDebugName_Ljava_lang_String__V;

		private static Delegate? cb_validate_Validate_V;

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

		[Register("helped")]
		public bool Helped
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("helped.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("helped.Z", this, value ? ((sbyte)1) : ((sbyte)0));
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

		[Register("matchConstraintDefaultHeight")]
		public int MatchConstraintDefaultHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("matchConstraintDefaultHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConstraintDefaultHeight.I", this, value);
			}
		}

		[Register("matchConstraintDefaultWidth")]
		public int MatchConstraintDefaultWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("matchConstraintDefaultWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConstraintDefaultWidth.I", this, value);
			}
		}

		[Register("matchConstraintMaxHeight")]
		public int MatchConstraintMaxHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("matchConstraintMaxHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConstraintMaxHeight.I", this, value);
			}
		}

		[Register("matchConstraintMaxWidth")]
		public int MatchConstraintMaxWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("matchConstraintMaxWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConstraintMaxWidth.I", this, value);
			}
		}

		[Register("matchConstraintMinHeight")]
		public int MatchConstraintMinHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("matchConstraintMinHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConstraintMinHeight.I", this, value);
			}
		}

		[Register("matchConstraintMinWidth")]
		public int MatchConstraintMinWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("matchConstraintMinWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConstraintMinWidth.I", this, value);
			}
		}

		[Register("matchConstraintPercentHeight")]
		public float MatchConstraintPercentHeight
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("matchConstraintPercentHeight.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConstraintPercentHeight.F", this, value);
			}
		}

		[Register("matchConstraintPercentWidth")]
		public float MatchConstraintPercentWidth
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("matchConstraintPercentWidth.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConstraintPercentWidth.F", this, value);
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

		[Register("wrapBehaviorInParent")]
		public int WrapBehaviorInParent
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("wrapBehaviorInParent.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("wrapBehaviorInParent.I", this, value);
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

		public unsafe virtual string? ConstraintTag
		{
			[Register("getConstraintTag", "()Ljava/lang/String;", "GetGetConstraintTagHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintTag.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ConstraintWidget? ConstraintWidget
		{
			[Register("getConstraintWidget", "()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", "GetGetConstraintWidgetHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintWidget.()Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected LayoutParams(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe LayoutParams(Context? c, IAttributeSet? attrs)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
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

		[Register(".ctor", "(II)V", "")]
		public unsafe LayoutParams(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		private static Delegate GetGetConstraintTagHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetConstraintTag);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetConstraintTag(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstraintTag);
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

		private static Delegate GetGetConstraintWidgetHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetConstraintWidget);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetConstraintWidget(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ConstraintWidget);
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

		private static Delegate GetResetHandler()
		{
			return new global::_JniMarshal_PP_V(n_Reset);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Reset(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
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

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}

		private static Delegate GetSetWidgetDebugName_Ljava_lang_String_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_SetWidgetDebugName_Ljava_lang_String_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetWidgetDebugName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_text)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutParams? layoutParams = Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string widgetDebugName = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
				layoutParams.SetWidgetDebugName(widgetDebugName);
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

		[Register("setWidgetDebugName", "(Ljava/lang/String;)V", "GetSetWidgetDebugName_Ljava_lang_String_Handler")]
		public unsafe virtual void SetWidgetDebugName(string? text)
		{
			nint num = JNIEnv.NewString(text);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setWidgetDebugName.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetValidateHandler()
		{
			return new global::_JniMarshal_PP_V(n_Validate);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Validate(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Validate();
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

		[Register("validate", "()V", "GetValidateHandler")]
		public unsafe virtual void Validate()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("validate.()V", this, null);
		}
	}

	[Register("androidx/constraintlayout/widget/ConstraintLayout$ValueModifier", "", "AndroidX.ConstraintLayout.Widget.ConstraintLayout/IValueModifierInvoker")]
	public interface IValueModifier : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("update", "(IIILandroid/view/View;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)Z", "GetUpdate_IIILandroid_view_View_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler:AndroidX.ConstraintLayout.Widget.ConstraintLayout/IValueModifierInvoker, Xamarin.AndroidX.ConstraintLayout")]
		bool Update(int p0, int p1, int p2, View? p3, LayoutParams? p4);
	}

	[Register("androidx/constraintlayout/widget/ConstraintLayout$ValueModifier", DoNotGenerateAcw = true)]
	internal class IValueModifierInvoker : Java.Lang.Object, IValueModifier, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_constraintlayout_widget_ConstraintLayout_ValueModifier = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintLayout$ValueModifier", typeof(IValueModifierInvoker));

		private static Delegate? cb_update_Update_IIILandroid_view_View_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams__Z;

		private static nint java_class_ref => _members_androidx_constraintlayout_widget_ConstraintLayout_ValueModifier.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_constraintlayout_widget_ConstraintLayout_ValueModifier;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_constraintlayout_widget_ConstraintLayout_ValueModifier.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_constraintlayout_widget_ConstraintLayout_ValueModifier.ManagedPeerType;

		public IValueModifierInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetUpdate_IIILandroid_view_View_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Handler()
		{
			return new _JniMarshal_PPIIILL_B(n_Update_IIILandroid_view_View_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_Update_IIILandroid_view_View_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_(nint jnienv, nint native__this, int p0, int p1, int p2, nint native_p3, nint native_p4)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IValueModifier? valueModifier = Java.Lang.Object.GetObject<IValueModifier>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View p3 = Java.Lang.Object.GetObject<View>(native_p3, JniHandleOwnership.DoNotTransfer);
				LayoutParams p4 = Java.Lang.Object.GetObject<LayoutParams>(native_p4, JniHandleOwnership.DoNotTransfer);
				return valueModifier.Update(p0, p1, p2, p3, p4) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool Update(int p0, int p1, int p2, View? p3, LayoutParams? p4)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(p4?.Handle ?? IntPtr.Zero);
				return _members_androidx_constraintlayout_widget_ConstraintLayout_ValueModifier.InstanceMethods.InvokeAbstractBooleanMethod("update.(IIILandroid/view/View;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p3);
				GC.KeepAlive(p4);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/widget/ConstraintLayout", typeof(ConstraintLayout));

	private static Delegate? cb_isRtl_IsRtl_Z;

	private static Delegate? cb_getMaxHeight_GetMaxHeight_I;

	private static Delegate? cb_setMaxHeight_SetMaxHeight_I_V;

	private static Delegate? cb_getMaxWidth_GetMaxWidth_I;

	private static Delegate? cb_setMaxWidth_SetMaxWidth_I_V;

	private static Delegate? cb_getMinHeight_GetMinHeight_I;

	private static Delegate? cb_setMinHeight_SetMinHeight_I_V;

	private static Delegate? cb_getMinWidth_GetMinWidth_I;

	private static Delegate? cb_setMinWidth_SetMinWidth_I_V;

	private static Delegate? cb_getOptimizationLevel_GetOptimizationLevel_I;

	private static Delegate? cb_setOptimizationLevel_SetOptimizationLevel_I_V;

	private static Delegate? cb_getSceneString_GetSceneString_Ljava_lang_String_;

	private static Delegate? cb_addValueModifier_AddValueModifier_Landroidx_constraintlayout_widget_ConstraintLayout_ValueModifier__V;

	private static Delegate? cb_applyConstraintsFromLayoutParams_ApplyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray__V;

	private static Delegate? cb_dynamicUpdateConstraints_DynamicUpdateConstraints_II_Z;

	private static Delegate? cb_fillMetrics_FillMetrics_Landroidx_constraintlayout_core_Metrics__V;

	private static Delegate? cb_getDesignInformation_GetDesignInformation_ILjava_lang_Object__Ljava_lang_Object_;

	private static Delegate? cb_getViewById_GetViewById_I_Landroid_view_View_;

	private static Delegate? cb_loadLayoutDescription_LoadLayoutDescription_I_V;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_parseLayoutDescription_ParseLayoutDescription_I_V;

	private static Delegate? cb_resolveMeasuredDimension_ResolveMeasuredDimension_IIIIZZ_V;

	private static Delegate? cb_resolveSystem_ResolveSystem_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_III_V;

	private static Delegate? cb_setConstraintSet_SetConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet__V;

	private static Delegate? cb_setDesignInformation_SetDesignInformation_ILjava_lang_Object_Ljava_lang_Object__V;

	private static Delegate? cb_setOnConstraintsChanged_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener__V;

	private static Delegate? cb_setSelfDimensionBehaviour_SetSelfDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIII_V;

	private static Delegate? cb_setState_SetState_III_V;

	[Register("mConstraintLayoutSpec")]
	protected ConstraintLayoutStates? MConstraintLayoutSpec
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintLayoutStates>(_members.InstanceFields.GetObjectValue("mConstraintLayoutSpec.Landroidx/constraintlayout/widget/ConstraintLayoutStates;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mConstraintLayoutSpec.Landroidx/constraintlayout/widget/ConstraintLayoutStates;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mDirtyHierarchy")]
	protected bool MDirtyHierarchy
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mDirtyHierarchy.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mDirtyHierarchy.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mLayoutWidget")]
	protected ConstraintWidgetContainer? MLayoutWidget
	{
		get
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(_members.InstanceFields.GetObjectValue("mLayoutWidget.Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mLayoutWidget.Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;", this, new JniObjectReference(num));
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

	protected unsafe virtual bool IsRtl
	{
		[Register("isRtl", "()Z", "GetIsRtlHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRtl.()Z", this, null);
		}
	}

	public unsafe virtual int MaxHeight
	{
		[Register("getMaxHeight", "()I", "GetGetMaxHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxHeight.()I", this, null);
		}
		[Register("setMaxHeight", "(I)V", "GetSetMaxHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MaxWidth
	{
		[Register("getMaxWidth", "()I", "GetGetMaxWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxWidth.()I", this, null);
		}
		[Register("setMaxWidth", "(I)V", "GetSetMaxWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MinHeight
	{
		[Register("getMinHeight", "()I", "GetGetMinHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinHeight.()I", this, null);
		}
		[Register("setMinHeight", "(I)V", "GetSetMinHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MinWidth
	{
		[Register("getMinWidth", "()I", "GetGetMinWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinWidth.()I", this, null);
		}
		[Register("setMinWidth", "(I)V", "GetSetMinWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual int OptimizationLevel
	{
		[Register("getOptimizationLevel", "()I", "GetGetOptimizationLevelHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOptimizationLevel.()I", this, null);
		}
		[Register("setOptimizationLevel", "(I)V", "GetSetOptimizationLevel_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOptimizationLevel.(I)V", this, ptr);
		}
	}

	public unsafe virtual string? SceneString
	{
		[Register("getSceneString", "()Ljava/lang/String;", "GetGetSceneStringHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSceneString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static SharedValues? SharedValues
	{
		[Register("getSharedValues", "()Landroidx/constraintlayout/widget/SharedValues;", "")]
		get
		{
			return Java.Lang.Object.GetObject<SharedValues>(_members.StaticMethods.InvokeObjectMethod("getSharedValues.()Landroidx/constraintlayout/widget/SharedValues;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ConstraintLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe ConstraintLayout(Context context)
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
	public unsafe ConstraintLayout(Context context, IAttributeSet? attrs)
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
	public unsafe ConstraintLayout(Context context, IAttributeSet? attrs, int defStyleAttr)
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
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe ConstraintLayout(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetIsRtlHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsRtl);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRtl(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRtl ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetMaxHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight;
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

	private static Delegate GetSetMaxHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxHeight_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight = value;
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

	private static Delegate GetGetMaxWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth;
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

	private static Delegate GetSetMaxWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxWidth_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth = value;
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

	private static Delegate GetGetMinHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMinHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMinHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinHeight;
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

	private static Delegate GetSetMinHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMinHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinHeight_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinHeight = value;
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

	private static Delegate GetGetMinWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMinWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMinWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth;
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

	private static Delegate GetSetMinWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMinWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinWidth_I(nint jnienv, nint native__this, int value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth = value;
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

	private static Delegate GetGetOptimizationLevelHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOptimizationLevel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOptimizationLevel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizationLevel;
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

	private static Delegate GetSetOptimizationLevel_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetOptimizationLevel_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOptimizationLevel_I(nint jnienv, nint native__this, int level)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizationLevel = level;
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

	private static Delegate GetGetSceneStringHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSceneString);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSceneString(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SceneString);
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

	private static Delegate GetAddValueModifier_Landroidx_constraintlayout_widget_ConstraintLayout_ValueModifier_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddValueModifier_Landroidx_constraintlayout_widget_ConstraintLayout_ValueModifier_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddValueModifier_Landroidx_constraintlayout_widget_ConstraintLayout_ValueModifier_(nint jnienv, nint native__this, nint native_modifier)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IValueModifier modifier = Java.Lang.Object.GetObject<IValueModifier>(native_modifier, JniHandleOwnership.DoNotTransfer);
			constraintLayout.AddValueModifier(modifier);
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

	[Register("addValueModifier", "(Landroidx/constraintlayout/widget/ConstraintLayout$ValueModifier;)V", "GetAddValueModifier_Landroidx_constraintlayout_widget_ConstraintLayout_ValueModifier_Handler")]
	public unsafe virtual void AddValueModifier(IValueModifier? modifier)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((modifier == null) ? IntPtr.Zero : ((Java.Lang.Object)modifier).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addValueModifier.(Landroidx/constraintlayout/widget/ConstraintLayout$ValueModifier;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(modifier);
		}
	}

	private static Delegate GetApplyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler()
	{
		return new _JniMarshal_PPBLLLL_V(n_ApplyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ApplyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_(nint jnienv, nint native__this, sbyte native_isInEditMode, nint native_child, nint native_widget, nint native_layoutParams, nint native_idToWidget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool isInEditMode = native_isInEditMode != 0;
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			LayoutParams layoutParams = Java.Lang.Object.GetObject<LayoutParams>(native_layoutParams, JniHandleOwnership.DoNotTransfer);
			SparseArray idToWidget = Java.Lang.Object.GetObject<SparseArray>(native_idToWidget, JniHandleOwnership.DoNotTransfer);
			constraintLayout.ApplyConstraintsFromLayoutParams(isInEditMode, child, widget, layoutParams, idToWidget);
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

	[Register("applyConstraintsFromLayoutParams", "(ZLandroid/view/View;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", "GetApplyConstraintsFromLayoutParams_ZLandroid_view_View_Landroidx_constraintlayout_core_widgets_ConstraintWidget_Landroidx_constraintlayout_widget_ConstraintLayout_LayoutParams_Landroid_util_SparseArray_Handler")]
	protected unsafe virtual void ApplyConstraintsFromLayoutParams(bool isInEditMode, View? child, ConstraintWidget? widget, LayoutParams? layoutParams, SparseArray? idToWidget)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(isInEditMode ? ((sbyte)1) : ((sbyte)0));
			ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(layoutParams?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(idToWidget?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyConstraintsFromLayoutParams.(ZLandroid/view/View;Landroidx/constraintlayout/core/widgets/ConstraintWidget;Landroidx/constraintlayout/widget/ConstraintLayout$LayoutParams;Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
			GC.KeepAlive(widget);
			GC.KeepAlive(layoutParams);
			GC.KeepAlive(idToWidget);
		}
	}

	private static Delegate GetDynamicUpdateConstraints_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_DynamicUpdateConstraints_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DynamicUpdateConstraints_II(nint jnienv, nint native__this, int widthMeasureSpec, int heightMeasureSpec)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DynamicUpdateConstraints(widthMeasureSpec, heightMeasureSpec) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("dynamicUpdateConstraints", "(II)Z", "GetDynamicUpdateConstraints_IIHandler")]
	protected unsafe virtual bool DynamicUpdateConstraints(int widthMeasureSpec, int heightMeasureSpec)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(widthMeasureSpec);
		ptr[1] = new JniArgumentValue(heightMeasureSpec);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("dynamicUpdateConstraints.(II)Z", this, ptr);
	}

	private static Delegate GetFillMetrics_Landroidx_constraintlayout_core_Metrics_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_FillMetrics_Landroidx_constraintlayout_core_Metrics_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FillMetrics_Landroidx_constraintlayout_core_Metrics_(nint jnienv, nint native__this, nint native_metrics)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Metrics metrics = Java.Lang.Object.GetObject<Metrics>(native_metrics, JniHandleOwnership.DoNotTransfer);
			constraintLayout.FillMetrics(metrics);
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

	[Register("fillMetrics", "(Landroidx/constraintlayout/core/Metrics;)V", "GetFillMetrics_Landroidx_constraintlayout_core_Metrics_Handler")]
	public unsafe virtual void FillMetrics(Metrics? metrics)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(metrics?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("fillMetrics.(Landroidx/constraintlayout/core/Metrics;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(metrics);
		}
	}

	private static Delegate GetGetDesignInformation_ILjava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPIL_L(n_GetDesignInformation_ILjava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDesignInformation_ILjava_lang_Object_(nint jnienv, nint native__this, int type, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(constraintLayout.GetDesignInformation(type, value));
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

	[Register("getDesignInformation", "(ILjava/lang/Object;)Ljava/lang/Object;", "GetGetDesignInformation_ILjava_lang_Object_Handler")]
	public unsafe virtual Java.Lang.Object? GetDesignInformation(int type, Java.Lang.Object? value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDesignInformation.(ILjava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetGetViewById_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetViewById_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViewById_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetViewById(id));
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

	[Register("getViewById", "(I)Landroid/view/View;", "GetGetViewById_IHandler")]
	public unsafe virtual View? GetViewById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewById.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getViewWidget", "(Landroid/view/View;)Landroidx/constraintlayout/core/widgets/ConstraintWidget;", "")]
	public unsafe ConstraintWidget? GetViewWidget(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getViewWidget.(Landroid/view/View;)Landroidx/constraintlayout/core/widgets/ConstraintWidget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetLoadLayoutDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_LoadLayoutDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadLayoutDescription_I(nint jnienv, nint native__this, int layoutDescription)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LoadLayoutDescription(layoutDescription);
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

	[Register("loadLayoutDescription", "(I)V", "GetLoadLayoutDescription_IHandler")]
	public unsafe virtual void LoadLayoutDescription(int layoutDescription)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(layoutDescription);
		_members.InstanceMethods.InvokeVirtualVoidMethod("loadLayoutDescription.(I)V", this, ptr);
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
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			constraintLayout.OnLayout(changed, left, top, right, bottom);
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

	private static Delegate GetParseLayoutDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_ParseLayoutDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ParseLayoutDescription_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParseLayoutDescription(id);
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

	[Register("parseLayoutDescription", "(I)V", "GetParseLayoutDescription_IHandler")]
	protected unsafe virtual void ParseLayoutDescription(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("parseLayoutDescription.(I)V", this, ptr);
	}

	private static Delegate GetResolveMeasuredDimension_IIIIZZHandler()
	{
		return new _JniMarshal_PPIIIIBB_V(n_ResolveMeasuredDimension_IIIIZZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResolveMeasuredDimension_IIIIZZ(nint jnienv, nint native__this, int widthMeasureSpec, int heightMeasureSpec, int measuredWidth, int measuredHeight, sbyte native_isWidthMeasuredTooSmall, sbyte native_isHeightMeasuredTooSmall)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool isWidthMeasuredTooSmall = native_isWidthMeasuredTooSmall != 0;
			bool isHeightMeasuredTooSmall = native_isHeightMeasuredTooSmall != 0;
			constraintLayout.ResolveMeasuredDimension(widthMeasureSpec, heightMeasureSpec, measuredWidth, measuredHeight, isWidthMeasuredTooSmall, isHeightMeasuredTooSmall);
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

	[Register("resolveMeasuredDimension", "(IIIIZZ)V", "GetResolveMeasuredDimension_IIIIZZHandler")]
	protected unsafe virtual void ResolveMeasuredDimension(int widthMeasureSpec, int heightMeasureSpec, int measuredWidth, int measuredHeight, bool isWidthMeasuredTooSmall, bool isHeightMeasuredTooSmall)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(widthMeasureSpec);
		ptr[1] = new JniArgumentValue(heightMeasureSpec);
		ptr[2] = new JniArgumentValue(measuredWidth);
		ptr[3] = new JniArgumentValue(measuredHeight);
		ptr[4] = new JniArgumentValue(isWidthMeasuredTooSmall ? ((sbyte)1) : ((sbyte)0));
		ptr[5] = new JniArgumentValue(isHeightMeasuredTooSmall ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("resolveMeasuredDimension.(IIIIZZ)V", this, ptr);
	}

	private static Delegate GetResolveSystem_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIIHandler()
	{
		return new global::_JniMarshal_PPLIII_V(n_ResolveSystem_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ResolveSystem_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_III(nint jnienv, nint native__this, nint native_layout, int optimizationLevel, int widthMeasureSpec, int heightMeasureSpec)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer layout = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_layout, JniHandleOwnership.DoNotTransfer);
			constraintLayout.ResolveSystem(layout, optimizationLevel, widthMeasureSpec, heightMeasureSpec);
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

	[Register("resolveSystem", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;III)V", "GetResolveSystem_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIIHandler")]
	protected unsafe virtual void ResolveSystem(ConstraintWidgetContainer? layout, int optimizationLevel, int widthMeasureSpec, int heightMeasureSpec)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(optimizationLevel);
			ptr[2] = new JniArgumentValue(widthMeasureSpec);
			ptr[3] = new JniArgumentValue(heightMeasureSpec);
			_members.InstanceMethods.InvokeVirtualVoidMethod("resolveSystem.(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;III)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layout);
		}
	}

	private static Delegate GetSetConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_(nint jnienv, nint native__this, nint native_set)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet constraintSet = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			constraintLayout.SetConstraintSet(constraintSet);
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

	[Register("setConstraintSet", "(Landroidx/constraintlayout/widget/ConstraintSet;)V", "GetSetConstraintSet_Landroidx_constraintlayout_widget_ConstraintSet_Handler")]
	public unsafe virtual void SetConstraintSet(ConstraintSet? set)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setConstraintSet.(Landroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetSetDesignInformation_ILjava_lang_Object_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPILL_V(n_SetDesignInformation_ILjava_lang_Object_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDesignInformation_ILjava_lang_Object_Ljava_lang_Object_(nint jnienv, nint native__this, int type, nint native_value1, nint native_value2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value1, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value2, JniHandleOwnership.DoNotTransfer);
			constraintLayout.SetDesignInformation(type, value, value2);
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

	[Register("setDesignInformation", "(ILjava/lang/Object;Ljava/lang/Object;)V", "GetSetDesignInformation_ILjava_lang_Object_Ljava_lang_Object_Handler")]
	public unsafe virtual void SetDesignInformation(int type, Java.Lang.Object? value1, Java.Lang.Object? value2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(value1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(value2?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDesignInformation.(ILjava/lang/Object;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(value1);
			GC.KeepAlive(value2);
		}
	}

	private static Delegate GetSetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_(nint jnienv, nint native__this, nint native_constraintsChangedListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintsChangedListener onConstraintsChanged = Java.Lang.Object.GetObject<ConstraintsChangedListener>(native_constraintsChangedListener, JniHandleOwnership.DoNotTransfer);
			constraintLayout.SetOnConstraintsChanged(onConstraintsChanged);
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

	[Register("setOnConstraintsChanged", "(Landroidx/constraintlayout/widget/ConstraintsChangedListener;)V", "GetSetOnConstraintsChanged_Landroidx_constraintlayout_widget_ConstraintsChangedListener_Handler")]
	public unsafe virtual void SetOnConstraintsChanged(ConstraintsChangedListener? constraintsChangedListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(constraintsChangedListener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnConstraintsChanged.(Landroidx/constraintlayout/widget/ConstraintsChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(constraintsChangedListener);
		}
	}

	private static Delegate GetSetSelfDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIIIHandler()
	{
		return new global::_JniMarshal_PPLIIII_V(n_SetSelfDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelfDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIII(nint jnienv, nint native__this, nint native_layout, int widthMode, int widthSize, int heightMode, int heightSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ConstraintLayout? constraintLayout = Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer layout = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_layout, JniHandleOwnership.DoNotTransfer);
			constraintLayout.SetSelfDimensionBehaviour(layout, widthMode, widthSize, heightMode, heightSize);
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

	[Register("setSelfDimensionBehaviour", "(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;IIII)V", "GetSetSelfDimensionBehaviour_Landroidx_constraintlayout_core_widgets_ConstraintWidgetContainer_IIIIHandler")]
	protected unsafe virtual void SetSelfDimensionBehaviour(ConstraintWidgetContainer? layout, int widthMode, int widthSize, int heightMode, int heightSize)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(widthMode);
			ptr[2] = new JniArgumentValue(widthSize);
			ptr[3] = new JniArgumentValue(heightMode);
			ptr[4] = new JniArgumentValue(heightSize);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSelfDimensionBehaviour.(Landroidx/constraintlayout/core/widgets/ConstraintWidgetContainer;IIII)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layout);
		}
	}

	private static Delegate GetSetState_IIIHandler()
	{
		return new global::_JniMarshal_PPIII_V(n_SetState_III);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetState_III(nint jnienv, nint native__this, int id, int screenWidth, int screenHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ConstraintLayout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetState(id, screenWidth, screenHeight);
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

	[Register("setState", "(III)V", "GetSetState_IIIHandler")]
	public unsafe virtual void SetState(int id, int screenWidth, int screenHeight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(screenWidth);
		ptr[2] = new JniArgumentValue(screenHeight);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setState.(III)V", this, ptr);
	}
}
