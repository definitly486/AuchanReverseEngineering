using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using AndroidX.ConstraintLayout.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Motion.Widget;

[Register("androidx/constraintlayout/motion/widget/MotionScene", DoNotGenerateAcw = true)]
public class MotionScene : Java.Lang.Object
{
	[Register("androidx/constraintlayout/motion/widget/MotionScene$Transition", DoNotGenerateAcw = true)]
	public class Transition : Java.Lang.Object
	{
		[Register("androidx/constraintlayout/motion/widget/MotionScene$Transition$TransitionOnClick", DoNotGenerateAcw = true)]
		public class TransitionOnClick : Java.Lang.Object, View.IOnClickListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionScene$Transition$TransitionOnClick", typeof(TransitionOnClick));

			private static Delegate? cb_addOnClickListeners_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition__V;

			private static Delegate? cb_onClick_OnClick_Landroid_view_View__V;

			private static Delegate? cb_removeOnClickListeners_RemoveOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout__V;

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

			protected TransitionOnClick(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Landroid/content/Context;Landroidx/constraintlayout/motion/widget/MotionScene$Transition;Lorg/xmlpull/v1/XmlPullParser;)V", "")]
			public unsafe TransitionOnClick(Context? context, Transition? transition, XmlReader? parser)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				nint num = XmlReaderPullParser.ToLocalJniHandle(parser);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(num);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroidx/constraintlayout/motion/widget/MotionScene$Transition;Lorg/xmlpull/v1/XmlPullParser;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroidx/constraintlayout/motion/widget/MotionScene$Transition;Lorg/xmlpull/v1/XmlPullParser;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
					GC.KeepAlive(context);
					GC.KeepAlive(transition);
					GC.KeepAlive(parser);
				}
			}

			[Register(".ctor", "(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;II)V", "")]
			public unsafe TransitionOnClick(Transition? transition, int id, int action)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(id);
					ptr[2] = new JniArgumentValue(action);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;II)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(transition);
				}
			}

			private static Delegate GetAddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
			{
				return new global::_JniMarshal_PPLIL_V(n_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_(nint jnienv, nint native__this, nint native_motionLayout, int currentState, nint native_transition)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					TransitionOnClick? transitionOnClick = Java.Lang.Object.GetObject<TransitionOnClick>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
					Transition transition2 = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
					transitionOnClick.AddOnClickListeners(motionLayout, currentState, transition2);
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

			[Register("addOnClickListeners", "(Landroidx/constraintlayout/motion/widget/MotionLayout;ILandroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetAddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_ILandroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
			public unsafe virtual void AddOnClickListeners(MotionLayout? motionLayout, int currentState, Transition? transition)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(currentState);
					ptr[2] = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("addOnClickListeners.(Landroidx/constraintlayout/motion/widget/MotionLayout;ILandroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(motionLayout);
					GC.KeepAlive(transition);
				}
			}

			private static Delegate GetOnClick_Landroid_view_View_Handler()
			{
				return new global::_JniMarshal_PPL_V(n_OnClick_Landroid_view_View_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_OnClick_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					TransitionOnClick? transitionOnClick = Java.Lang.Object.GetObject<TransitionOnClick>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
					transitionOnClick.OnClick(view);
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

			[Register("onClick", "(Landroid/view/View;)V", "GetOnClick_Landroid_view_View_Handler")]
			public unsafe virtual void OnClick(View? view)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("onClick.(Landroid/view/View;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(view);
				}
			}

			private static Delegate GetRemoveOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_Handler()
			{
				return new global::_JniMarshal_PPL_V(n_RemoveOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_RemoveOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_(nint jnienv, nint native__this, nint native_motionLayout)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					TransitionOnClick? transitionOnClick = Java.Lang.Object.GetObject<TransitionOnClick>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
					transitionOnClick.RemoveOnClickListeners(motionLayout);
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

			[Register("removeOnClickListeners", "(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", "GetRemoveOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_Handler")]
			public unsafe virtual void RemoveOnClickListeners(MotionLayout? motionLayout)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnClickListeners.(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(motionLayout);
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

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionScene$Transition", typeof(Transition));

		private static Delegate? cb_getAutoTransition_GetAutoTransition_I;

		private static Delegate? cb_setAutoTransition_SetAutoTransition_I_V;

		private static Delegate? cb_getDuration_GetDuration_I;

		private static Delegate? cb_setDuration_SetDuration_I_V;

		private static Delegate? cb_isEnabled_IsEnabled_Z;

		private static Delegate? cb_setEnabled_SetEnabled_Z_V;

		private static Delegate? cb_getEndConstraintSetId_GetEndConstraintSetId_I;

		private static Delegate? cb_getId_GetId_I;

		private static Delegate? cb_getKeyFrameList_GetKeyFrameList_Ljava_util_List_;

		private static Delegate? cb_getLayoutDuringTransition_GetLayoutDuringTransition_I;

		private static Delegate? cb_setLayoutDuringTransition_SetLayoutDuringTransition_I_V;

		private static Delegate? cb_getOnClickList_GetOnClickList_Ljava_util_List_;

		private static Delegate? cb_getPathMotionArc_GetPathMotionArc_I;

		private static Delegate? cb_setPathMotionArc_SetPathMotionArc_I_V;

		private static Delegate? cb_getStagger_GetStagger_F;

		private static Delegate? cb_setStagger_SetStagger_F_V;

		private static Delegate? cb_getStartConstraintSetId_GetStartConstraintSetId_I;

		private static Delegate? cb_getTouchResponse_GetTouchResponse_Ljava_lang_Object_;

		private static Delegate? cb_addKeyFrame_AddKeyFrame_Landroidx_constraintlayout_motion_widget_KeyFrames__V;

		private static Delegate? cb_addOnClick_AddOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser__V;

		private static Delegate? cb_addOnClick_AddOnClick_II_V;

		private static Delegate? cb_debugString_DebugString_Landroid_content_Context__Ljava_lang_String_;

		private static Delegate? cb_isTransitionFlag_IsTransitionFlag_I_Z;

		private static Delegate? cb_removeOnClick_RemoveOnClick_I_V;

		private static Delegate? cb_setInterpolatorInfo_SetInterpolatorInfo_ILjava_lang_String_I_V;

		private static Delegate? cb_setOnSwipe_SetOnSwipe_Landroidx_constraintlayout_motion_widget_OnSwipe__V;

		private static Delegate? cb_setOnTouchUp_SetOnTouchUp_I_V;

		private static Delegate? cb_setTransitionFlag_SetTransitionFlag_I_V;

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

		public unsafe virtual int AutoTransition
		{
			[Register("getAutoTransition", "()I", "GetGetAutoTransitionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getAutoTransition.()I", this, null);
			}
			[Register("setAutoTransition", "(I)V", "GetSetAutoTransition_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAutoTransition.(I)V", this, ptr);
			}
		}

		public unsafe virtual int Duration
		{
			[Register("getDuration", "()I", "GetGetDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDuration.()I", this, null);
			}
			[Register("setDuration", "(I)V", "GetSetDuration_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDuration.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool Enabled
		{
			[Register("isEnabled", "()Z", "GetIsEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEnabled.()Z", this, null);
			}
			[Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int EndConstraintSetId
		{
			[Register("getEndConstraintSetId", "()I", "GetGetEndConstraintSetIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getEndConstraintSetId.()I", this, null);
			}
		}

		public unsafe virtual int Id
		{
			[Register("getId", "()I", "GetGetIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
			}
		}

		public unsafe virtual IList<KeyFrames>? KeyFrameList
		{
			[Register("getKeyFrameList", "()Ljava/util/List;", "GetGetKeyFrameListHandler")]
			get
			{
				return JavaList<KeyFrames>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getKeyFrameList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int LayoutDuringTransition
		{
			[Register("getLayoutDuringTransition", "()I", "GetGetLayoutDuringTransitionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLayoutDuringTransition.()I", this, null);
			}
			[Register("setLayoutDuringTransition", "(I)V", "GetSetLayoutDuringTransition_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLayoutDuringTransition.(I)V", this, ptr);
			}
		}

		public unsafe virtual IList<TransitionOnClick>? OnClickList
		{
			[Register("getOnClickList", "()Ljava/util/List;", "GetGetOnClickListHandler")]
			get
			{
				return JavaList<TransitionOnClick>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getOnClickList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int PathMotionArc
		{
			[Register("getPathMotionArc", "()I", "GetGetPathMotionArcHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPathMotionArc.()I", this, null);
			}
			[Register("setPathMotionArc", "(I)V", "GetSetPathMotionArc_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPathMotionArc.(I)V", this, ptr);
			}
		}

		public unsafe virtual float Stagger
		{
			[Register("getStagger", "()F", "GetGetStaggerHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getStagger.()F", this, null);
			}
			[Register("setStagger", "(F)V", "GetSetStagger_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStagger.(F)V", this, ptr);
			}
		}

		public unsafe virtual int StartConstraintSetId
		{
			[Register("getStartConstraintSetId", "()I", "GetGetStartConstraintSetIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getStartConstraintSetId.()I", this, null);
			}
		}

		public unsafe virtual Java.Lang.Object? TouchResponse
		{
			[Register("getTouchResponse", "()Ljava/lang/Object;", "GetGetTouchResponseHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTouchResponse.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Transition(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(ILandroidx/constraintlayout/motion/widget/MotionScene;II)V", "")]
		public unsafe Transition(int id, MotionScene? motionScene, int constraintSetStartId, int constraintSetEndId)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(id);
				ptr[1] = new JniArgumentValue(motionScene?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(constraintSetStartId);
				ptr[3] = new JniArgumentValue(constraintSetEndId);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILandroidx/constraintlayout/motion/widget/MotionScene;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILandroidx/constraintlayout/motion/widget/MotionScene;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(motionScene);
			}
		}

		private static Delegate GetGetAutoTransitionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetAutoTransition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetAutoTransition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoTransition;
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

		private static Delegate GetSetAutoTransition_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetAutoTransition_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetAutoTransition_I(nint jnienv, nint native__this, int type)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoTransition = type;
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

		private static Delegate GetGetDurationHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetDuration);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetDuration(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
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

		private static Delegate GetSetDuration_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetDuration_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetDuration_I(nint jnienv, nint native__this, int duration)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration = duration;
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

		private static Delegate GetIsEnabledHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsEnabled);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsEnabled(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Enabled ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetSetEnabled_ZHandler()
		{
			return new global::_JniMarshal_PPB_V(n_SetEnabled_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetEnabled_Z(nint jnienv, nint native__this, sbyte native_enable)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool enabled = native_enable != 0;
				transition2.Enabled = enabled;
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

		private static Delegate GetGetEndConstraintSetIdHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetEndConstraintSetId);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetEndConstraintSetId(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndConstraintSetId;
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

		private static Delegate GetGetIdHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetId);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetId(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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

		private static Delegate GetGetKeyFrameListHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetKeyFrameList);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetKeyFrameList(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JavaList<KeyFrames>.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).KeyFrameList);
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

		private static Delegate GetGetLayoutDuringTransitionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetLayoutDuringTransition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetLayoutDuringTransition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutDuringTransition;
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

		private static Delegate GetSetLayoutDuringTransition_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetLayoutDuringTransition_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetLayoutDuringTransition_I(nint jnienv, nint native__this, int mode)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutDuringTransition = mode;
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

		private static Delegate GetGetOnClickListHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetOnClickList);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetOnClickList(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JavaList<TransitionOnClick>.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnClickList);
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

		private static Delegate GetGetPathMotionArcHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetPathMotionArc);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPathMotionArc(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PathMotionArc;
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

		private static Delegate GetSetPathMotionArc_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetPathMotionArc_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetPathMotionArc_I(nint jnienv, nint native__this, int arcMode)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PathMotionArc = arcMode;
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

		private static Delegate GetGetStaggerHandler()
		{
			return new global::_JniMarshal_PP_F(n_GetStagger);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetStagger(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Stagger;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0f;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetSetStagger_FHandler()
		{
			return new global::_JniMarshal_PPF_V(n_SetStagger_F);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetStagger_F(nint jnienv, nint native__this, float stagger)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Stagger = stagger;
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

		private static Delegate GetGetStartConstraintSetIdHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetStartConstraintSetId);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetStartConstraintSetId(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartConstraintSetId;
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

		private static Delegate GetGetTouchResponseHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetTouchResponse);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetTouchResponse(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TouchResponse);
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

		private static Delegate GetAddKeyFrame_Landroidx_constraintlayout_motion_widget_KeyFrames_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_AddKeyFrame_Landroidx_constraintlayout_motion_widget_KeyFrames_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AddKeyFrame_Landroidx_constraintlayout_motion_widget_KeyFrames_(nint jnienv, nint native__this, nint native_keyFrames)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				KeyFrames keyFrames = Java.Lang.Object.GetObject<KeyFrames>(native_keyFrames, JniHandleOwnership.DoNotTransfer);
				transition2.AddKeyFrame(keyFrames);
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

		[Register("addKeyFrame", "(Landroidx/constraintlayout/motion/widget/KeyFrames;)V", "GetAddKeyFrame_Landroidx_constraintlayout_motion_widget_KeyFrames_Handler")]
		public unsafe virtual void AddKeyFrame(KeyFrames? keyFrames)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(keyFrames?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addKeyFrame.(Landroidx/constraintlayout/motion/widget/KeyFrames;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(keyFrames);
			}
		}

		private static Delegate GetAddOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_AddOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AddOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_(nint jnienv, nint native__this, nint native_context, nint native_parser)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
				XmlReader parser = XmlPullParserReader.FromJniHandle(native_parser, JniHandleOwnership.DoNotTransfer);
				transition2.AddOnClick(context, parser);
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

		[Register("addOnClick", "(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", "GetAddOnClick_Landroid_content_Context_Lorg_xmlpull_v1_XmlPullParser_Handler")]
		public unsafe virtual void AddOnClick(Context? context, XmlReader? parser)
		{
			nint num = XmlReaderPullParser.ToLocalJniHandle(parser);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addOnClick.(Landroid/content/Context;Lorg/xmlpull/v1/XmlPullParser;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(context);
				GC.KeepAlive(parser);
			}
		}

		private static Delegate GetAddOnClick_IIHandler()
		{
			return new global::_JniMarshal_PPII_V(n_AddOnClick_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AddOnClick_II(nint jnienv, nint native__this, int id, int action)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddOnClick(id, action);
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

		[Register("addOnClick", "(II)V", "GetAddOnClick_IIHandler")]
		public unsafe virtual void AddOnClick(int id, int action)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(action);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnClick.(II)V", this, ptr);
		}

		private static Delegate GetDebugString_Landroid_content_Context_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_DebugString_Landroid_content_Context_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_DebugString_Landroid_content_Context_(nint jnienv, nint native__this, nint native_context)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(transition2.DebugString(context));
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

		[Register("debugString", "(Landroid/content/Context;)Ljava/lang/String;", "GetDebugString_Landroid_content_Context_Handler")]
		public unsafe virtual string? DebugString(Context? context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("debugString.(Landroid/content/Context;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetIsTransitionFlag_IHandler()
		{
			return new global::_JniMarshal_PPI_B(n_IsTransitionFlag_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsTransitionFlag_I(nint jnienv, nint native__this, int flag)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTransitionFlag(flag) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("isTransitionFlag", "(I)Z", "GetIsTransitionFlag_IHandler")]
		public unsafe virtual bool IsTransitionFlag(int flag)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(flag);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTransitionFlag.(I)Z", this, ptr);
		}

		private static Delegate GetRemoveOnClick_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_RemoveOnClick_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RemoveOnClick_I(nint jnienv, nint native__this, int id)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveOnClick(id);
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

		[Register("removeOnClick", "(I)V", "GetRemoveOnClick_IHandler")]
		public unsafe virtual void RemoveOnClick(int id)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(id);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnClick.(I)V", this, ptr);
		}

		private static Delegate GetSetInterpolatorInfo_ILjava_lang_String_IHandler()
		{
			return new global::_JniMarshal_PPILI_V(n_SetInterpolatorInfo_ILjava_lang_String_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetInterpolatorInfo_ILjava_lang_String_I(nint jnienv, nint native__this, int interpolator, nint native_interpolatorString, int interpolatorID)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string interpolatorString = JNIEnv.GetString(native_interpolatorString, JniHandleOwnership.DoNotTransfer);
				transition2.SetInterpolatorInfo(interpolator, interpolatorString, interpolatorID);
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

		[Register("setInterpolatorInfo", "(ILjava/lang/String;I)V", "GetSetInterpolatorInfo_ILjava_lang_String_IHandler")]
		public unsafe virtual void SetInterpolatorInfo(int interpolator, string? interpolatorString, int interpolatorID)
		{
			nint num = JNIEnv.NewString(interpolatorString);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(interpolator);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(interpolatorID);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolatorInfo.(ILjava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetSetOnSwipe_Landroidx_constraintlayout_motion_widget_OnSwipe_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_SetOnSwipe_Landroidx_constraintlayout_motion_widget_OnSwipe_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetOnSwipe_Landroidx_constraintlayout_motion_widget_OnSwipe_(nint jnienv, nint native__this, nint native_onSwipe)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Transition? transition2 = Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				OnSwipe onSwipe = Java.Lang.Object.GetObject<OnSwipe>(native_onSwipe, JniHandleOwnership.DoNotTransfer);
				transition2.SetOnSwipe(onSwipe);
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

		[Register("setOnSwipe", "(Landroidx/constraintlayout/motion/widget/OnSwipe;)V", "GetSetOnSwipe_Landroidx_constraintlayout_motion_widget_OnSwipe_Handler")]
		public unsafe virtual void SetOnSwipe(OnSwipe? onSwipe)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(onSwipe?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOnSwipe.(Landroidx/constraintlayout/motion/widget/OnSwipe;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(onSwipe);
			}
		}

		private static Delegate GetSetOnTouchUp_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetOnTouchUp_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetOnTouchUp_I(nint jnienv, nint native__this, int touchUpMode)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOnTouchUp(touchUpMode);
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

		[Register("setOnTouchUp", "(I)V", "GetSetOnTouchUp_IHandler")]
		public unsafe virtual void SetOnTouchUp(int touchUpMode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(touchUpMode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnTouchUp.(I)V", this, ptr);
		}

		private static Delegate GetSetTransitionFlag_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetTransitionFlag_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetTransitionFlag_I(nint jnienv, nint native__this, int flag)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<Transition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTransitionFlag(flag);
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

		[Register("setTransitionFlag", "(I)V", "GetSetTransitionFlag_IHandler")]
		public unsafe virtual void SetTransitionFlag(int flag)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(flag);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransitionFlag.(I)V", this, ptr);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/widget/MotionScene", typeof(MotionScene));

	private static Delegate? cb_getDefinedTransitions_GetDefinedTransitions_Ljava_util_ArrayList_;

	private static Delegate? cb_getDuration_GetDuration_I;

	private static Delegate? cb_setDuration_SetDuration_I_V;

	private static Delegate? cb_getInterpolator_GetInterpolator_Landroid_view_animation_Interpolator_;

	private static Delegate? cb_getStaggered_GetStaggered_F;

	private static Delegate? cb_addOnClickListeners_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_I_V;

	private static Delegate? cb_addTransition_AddTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition__V;

	private static Delegate? cb_applyViewTransition_ApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController__Z;

	private static Delegate? cb_bestTransitionFor_BestTransitionFor_IFFLandroid_view_MotionEvent__Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;

	private static Delegate? cb_disableAutoTransition_DisableAutoTransition_Z_V;

	private static Delegate? cb_enableViewTransition_EnableViewTransition_IZ_V;

	private static Delegate? cb_gatPathMotionArc_GatPathMotionArc_I;

	private static Delegate? cb_getConstraintSet_GetConstraintSet_Landroid_content_Context_Ljava_lang_String__Landroidx_constraintlayout_widget_ConstraintSet_;

	private static Delegate? cb_getConstraintSetIds_GetConstraintSetIds_arrayI;

	private static Delegate? cb_getKeyFrames_GetKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController__V;

	private static Delegate? cb_getMatchingStateLabels_GetMatchingStateLabels_arrayLjava_lang_String__arrayI;

	private static Delegate? cb_getPathPercent_GetPathPercent_Landroid_view_View_I_F;

	private static Delegate? cb_getTransitionById_GetTransitionById_I_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_;

	private static Delegate? cb_getTransitionsWithState_GetTransitionsWithState_I_Ljava_util_List_;

	private static Delegate? cb_isViewTransitionEnabled_IsViewTransitionEnabled_I_Z;

	private static Delegate? cb_lookUpConstraintId_LookUpConstraintId_Ljava_lang_String__I;

	private static Delegate? cb_lookUpConstraintName_LookUpConstraintName_I_Ljava_lang_String_;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_removeTransition_RemoveTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition__V;

	private static Delegate? cb_setConstraintSet_SetConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet__V;

	private static Delegate? cb_setKeyframe_SetKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object__V;

	private static Delegate? cb_setRtl_SetRtl_Z_V;

	private static Delegate? cb_setTransition_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition__V;

	private static Delegate? cb_validateLayout_ValidateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout__Z;

	private static Delegate? cb_viewTransition_ViewTransition_IarrayLandroid_view_View__V;

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

	public unsafe virtual IList<Transition>? DefinedTransitions
	{
		[Register("getDefinedTransitions", "()Ljava/util/ArrayList;", "GetGetDefinedTransitionsHandler")]
		get
		{
			return JavaList<Transition>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getDefinedTransitions.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Duration
	{
		[Register("getDuration", "()I", "GetGetDurationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDuration.()I", this, null);
		}
		[Register("setDuration", "(I)V", "GetSetDuration_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDuration.(I)V", this, ptr);
		}
	}

	public unsafe virtual IInterpolator? Interpolator
	{
		[Register("getInterpolator", "()Landroid/view/animation/Interpolator;", "GetGetInterpolatorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IInterpolator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterpolator.()Landroid/view/animation/Interpolator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float Staggered
	{
		[Register("getStaggered", "()F", "GetGetStaggeredHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getStaggered.()F", this, null);
		}
	}

	protected MotionScene(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", "")]
	public unsafe MotionScene(MotionLayout? layout)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/motion/widget/MotionLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layout);
		}
	}

	private static Delegate GetGetDefinedTransitionsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDefinedTransitions);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDefinedTransitions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<Transition>.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefinedTransitions);
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

	private static Delegate GetGetDurationHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDuration);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDuration(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
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

	private static Delegate GetSetDuration_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDuration_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDuration_I(nint jnienv, nint native__this, int duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration = duration;
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

	private static Delegate GetGetInterpolatorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetInterpolator);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInterpolator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolator);
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

	private static Delegate GetGetStaggeredHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetStaggered);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetStaggered(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Staggered;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetAddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_I(nint jnienv, nint native__this, nint native_motionLayout, int currentState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionLayout motionLayout = Java.Lang.Object.GetObject<MotionLayout>(native_motionLayout, JniHandleOwnership.DoNotTransfer);
			motionScene.AddOnClickListeners(motionLayout, currentState);
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

	[Register("addOnClickListeners", "(Landroidx/constraintlayout/motion/widget/MotionLayout;I)V", "GetAddOnClickListeners_Landroidx_constraintlayout_motion_widget_MotionLayout_IHandler")]
	public unsafe virtual void AddOnClickListeners(MotionLayout? motionLayout, int currentState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(motionLayout?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(currentState);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnClickListeners.(Landroidx/constraintlayout/motion/widget/MotionLayout;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(motionLayout);
		}
	}

	private static Delegate GetAddTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Transition transition2 = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			motionScene.AddTransition(transition2);
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

	[Register("addTransition", "(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetAddTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
	public unsafe virtual void AddTransition(Transition? transition)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTransition.(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transition);
		}
	}

	private static Delegate GetApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_ApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController_(nint jnienv, nint native__this, int viewTransitionId, nint native_motionController)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(native_motionController, JniHandleOwnership.DoNotTransfer);
			return motionScene.ApplyViewTransition(viewTransitionId, motionController) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("applyViewTransition", "(ILandroidx/constraintlayout/motion/widget/MotionController;)Z", "GetApplyViewTransition_ILandroidx_constraintlayout_motion_widget_MotionController_Handler")]
	public unsafe virtual bool ApplyViewTransition(int viewTransitionId, MotionController? motionController)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewTransitionId);
			ptr[1] = new JniArgumentValue(motionController?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("applyViewTransition.(ILandroidx/constraintlayout/motion/widget/MotionController;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(motionController);
		}
	}

	private static Delegate GetBestTransitionFor_IFFLandroid_view_MotionEvent_Handler()
	{
		return new _JniMarshal_PPIFFL_L(n_BestTransitionFor_IFFLandroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_BestTransitionFor_IFFLandroid_view_MotionEvent_(nint jnienv, nint native__this, int currentState, float dx, float dy, nint native_lastTouchDown)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent lastTouchDown = Java.Lang.Object.GetObject<MotionEvent>(native_lastTouchDown, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(motionScene.BestTransitionFor(currentState, dx, dy, lastTouchDown));
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

	[Register("bestTransitionFor", "(IFFLandroid/view/MotionEvent;)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", "GetBestTransitionFor_IFFLandroid_view_MotionEvent_Handler")]
	public unsafe virtual Transition? BestTransitionFor(int currentState, float dx, float dy, MotionEvent? lastTouchDown)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(currentState);
			ptr[1] = new JniArgumentValue(dx);
			ptr[2] = new JniArgumentValue(dy);
			ptr[3] = new JniArgumentValue(lastTouchDown?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("bestTransitionFor.(IFFLandroid/view/MotionEvent;)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(lastTouchDown);
		}
	}

	private static Delegate GetDisableAutoTransition_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_DisableAutoTransition_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DisableAutoTransition_Z(nint jnienv, nint native__this, sbyte native_disable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool disable = native_disable != 0;
			motionScene.DisableAutoTransition(disable);
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

	[Register("disableAutoTransition", "(Z)V", "GetDisableAutoTransition_ZHandler")]
	public unsafe virtual void DisableAutoTransition(bool disable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(disable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("disableAutoTransition.(Z)V", this, ptr);
	}

	private static Delegate GetEnableViewTransition_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_EnableViewTransition_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_EnableViewTransition_IZ(nint jnienv, nint native__this, int id, sbyte native_enable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enable = native_enable != 0;
			motionScene.EnableViewTransition(id, enable);
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

	[Register("enableViewTransition", "(IZ)V", "GetEnableViewTransition_IZHandler")]
	public unsafe virtual void EnableViewTransition(int id, bool enable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue(enable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("enableViewTransition.(IZ)V", this, ptr);
	}

	private static Delegate GetGatPathMotionArcHandler()
	{
		return new global::_JniMarshal_PP_I(n_GatPathMotionArc);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GatPathMotionArc(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GatPathMotionArc();
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

	[Register("gatPathMotionArc", "()I", "GetGatPathMotionArcHandler")]
	public unsafe virtual int GatPathMotionArc()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("gatPathMotionArc.()I", this, null);
	}

	private static Delegate GetGetConstraintSet_Landroid_content_Context_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_GetConstraintSet_Landroid_content_Context_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetConstraintSet_Landroid_content_Context_Ljava_lang_String_(nint jnienv, nint native__this, nint native_context, nint native_id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(motionScene.GetConstraintSet(context, id));
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

	[Register("getConstraintSet", "(Landroid/content/Context;Ljava/lang/String;)Landroidx/constraintlayout/widget/ConstraintSet;", "GetGetConstraintSet_Landroid_content_Context_Ljava_lang_String_Handler")]
	public unsafe virtual ConstraintSet? GetConstraintSet(Context? context, string? id)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ConstraintSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintSet.(Landroid/content/Context;Ljava/lang/String;)Landroidx/constraintlayout/widget/ConstraintSet;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetConstraintSetIdsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetConstraintSetIds);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetConstraintSetIds(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetConstraintSetIds());
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

	[Register("getConstraintSetIds", "()[I", "GetGetConstraintSetIdsHandler")]
	public unsafe virtual int[]? GetConstraintSetIds()
	{
		return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getConstraintSetIds.()[I", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
	}

	private static Delegate GetGetKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_(nint jnienv, nint native__this, nint native_motionController)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionController motionController = Java.Lang.Object.GetObject<MotionController>(native_motionController, JniHandleOwnership.DoNotTransfer);
			motionScene.GetKeyFrames(motionController);
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

	[Register("getKeyFrames", "(Landroidx/constraintlayout/motion/widget/MotionController;)V", "GetGetKeyFrames_Landroidx_constraintlayout_motion_widget_MotionController_Handler")]
	public unsafe virtual void GetKeyFrames(MotionController? motionController)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(motionController?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getKeyFrames.(Landroidx/constraintlayout/motion/widget/MotionController;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(motionController);
		}
	}

	private static Delegate GetGetMatchingStateLabels_arrayLjava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetMatchingStateLabels_arrayLjava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMatchingStateLabels_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_types)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] array = (string[])JNIEnv.GetArray(native_types, JniHandleOwnership.DoNotTransfer, typeof(string));
			nint result = JNIEnv.NewArray(motionScene.GetMatchingStateLabels(array));
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

	[Register("getMatchingStateLabels", "([Ljava/lang/String;)[I", "GetGetMatchingStateLabels_arrayLjava_lang_String_Handler")]
	public unsafe virtual int[]? GetMatchingStateLabels(params string[]? types)
	{
		nint num = JNIEnv.NewArray(types);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getMatchingStateLabels.([Ljava/lang/String;)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
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

	private static Delegate GetGetPathPercent_Landroid_view_View_IHandler()
	{
		return new _JniMarshal_PPLI_F(n_GetPathPercent_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetPathPercent_Landroid_view_View_I(nint jnienv, nint native__this, nint native_view, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return motionScene.GetPathPercent(view, position);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getPathPercent", "(Landroid/view/View;I)F", "GetGetPathPercent_Landroid_view_View_IHandler")]
	public unsafe virtual float GetPathPercent(View? view, int position)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getPathPercent.(Landroid/view/View;I)F", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetGetTransitionById_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetTransitionById_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTransitionById_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTransitionById(id));
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

	[Register("getTransitionById", "(I)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", "GetGetTransitionById_IHandler")]
	public unsafe virtual Transition? GetTransitionById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<Transition>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransitionById.(I)Landroidx/constraintlayout/motion/widget/MotionScene$Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetTransitionsWithState_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetTransitionsWithState_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTransitionsWithState_I(nint jnienv, nint native__this, int stateId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<Transition>.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetTransitionsWithState(stateId));
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

	[Register("getTransitionsWithState", "(I)Ljava/util/List;", "GetGetTransitionsWithState_IHandler")]
	public unsafe virtual IList<Transition>? GetTransitionsWithState(int stateId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(stateId);
		return JavaList<Transition>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getTransitionsWithState.(I)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetIsViewTransitionEnabled_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_IsViewTransitionEnabled_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsViewTransitionEnabled_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsViewTransitionEnabled(id) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isViewTransitionEnabled", "(I)Z", "GetIsViewTransitionEnabled_IHandler")]
	public unsafe virtual bool IsViewTransitionEnabled(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isViewTransitionEnabled.(I)Z", this, ptr);
	}

	private static Delegate GetLookUpConstraintId_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_LookUpConstraintId_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_LookUpConstraintId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string id = JNIEnv.GetString(native_id, JniHandleOwnership.DoNotTransfer);
			return motionScene.LookUpConstraintId(id);
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

	[Register("lookUpConstraintId", "(Ljava/lang/String;)I", "GetLookUpConstraintId_Ljava_lang_String_Handler")]
	public unsafe virtual int LookUpConstraintId(string? id)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("lookUpConstraintId.(Ljava/lang/String;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetLookUpConstraintName_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_LookUpConstraintName_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_LookUpConstraintName_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LookUpConstraintName(id));
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

	[Register("lookUpConstraintName", "(I)Ljava/lang/String;", "GetLookUpConstraintName_IHandler")]
	public unsafe virtual string? LookUpConstraintName(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("lookUpConstraintName.(I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			motionScene.OnLayout(changed, left, top, right, bottom);
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
	protected unsafe virtual void OnLayout(bool changed, int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(left);
		ptr[2] = new JniArgumentValue(top);
		ptr[3] = new JniArgumentValue(right);
		ptr[4] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}

	private static Delegate GetRemoveTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Transition transition2 = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			motionScene.RemoveTransition(transition2);
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

	[Register("removeTransition", "(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetRemoveTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
	public unsafe virtual void RemoveTransition(Transition? transition)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeTransition.(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transition);
		}
	}

	private static Delegate GetSetConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_SetConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_(nint jnienv, nint native__this, int id, nint native_set)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintSet set = Java.Lang.Object.GetObject<ConstraintSet>(native_set, JniHandleOwnership.DoNotTransfer);
			motionScene.SetConstraintSet(id, set);
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

	[Register("setConstraintSet", "(ILandroidx/constraintlayout/widget/ConstraintSet;)V", "GetSetConstraintSet_ILandroidx_constraintlayout_widget_ConstraintSet_Handler")]
	public unsafe virtual void SetConstraintSet(int id, ConstraintSet? set)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(set?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setConstraintSet.(ILandroidx/constraintlayout/widget/ConstraintSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(set);
		}
	}

	private static Delegate GetSetKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPLILL_V(n_SetKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_view, int position, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			motionScene.SetKeyframe(view, position, name, value);
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

	[Register("setKeyframe", "(Landroid/view/View;ILjava/lang/String;Ljava/lang/Object;)V", "GetSetKeyframe_Landroid_view_View_ILjava_lang_String_Ljava_lang_Object_Handler")]
	public unsafe virtual void SetKeyframe(View? view, int position, string? name, Java.Lang.Object? value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setKeyframe.(Landroid/view/View;ILjava/lang/String;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(view);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetSetRtl_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetRtl_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRtl_Z(nint jnienv, nint native__this, sbyte native_rtl)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool rtl = native_rtl != 0;
			motionScene.SetRtl(rtl);
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

	[Register("setRtl", "(Z)V", "GetSetRtl_ZHandler")]
	public unsafe virtual void SetRtl(bool rtl)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(rtl ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRtl.(Z)V", this, ptr);
	}

	private static Delegate GetSetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_(nint jnienv, nint native__this, nint native_transition)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Transition transition2 = Java.Lang.Object.GetObject<Transition>(native_transition, JniHandleOwnership.DoNotTransfer);
			motionScene.SetTransition(transition2);
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

	[Register("setTransition", "(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", "GetSetTransition_Landroidx_constraintlayout_motion_widget_MotionScene_Transition_Handler")]
	public unsafe virtual void SetTransition(Transition? transition)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(transition?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTransition.(Landroidx/constraintlayout/motion/widget/MotionScene$Transition;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transition);
		}
	}

	[Register("stripID", "(Ljava/lang/String;)Ljava/lang/String;", "")]
	public unsafe static string? StripID(string? id)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("stripID.(Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetValidateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_ValidateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ValidateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_(nint jnienv, nint native__this, nint native_layout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionLayout layout = Java.Lang.Object.GetObject<MotionLayout>(native_layout, JniHandleOwnership.DoNotTransfer);
			return motionScene.ValidateLayout(layout) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("validateLayout", "(Landroidx/constraintlayout/motion/widget/MotionLayout;)Z", "GetValidateLayout_Landroidx_constraintlayout_motion_widget_MotionLayout_Handler")]
	public unsafe virtual bool ValidateLayout(MotionLayout? layout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("validateLayout.(Landroidx/constraintlayout/motion/widget/MotionLayout;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layout);
		}
	}

	private static Delegate GetViewTransition_IarrayLandroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPIL_V(n_ViewTransition_IarrayLandroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ViewTransition_IarrayLandroid_view_View_(nint jnienv, nint native__this, int id, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionScene? motionScene = Java.Lang.Object.GetObject<MotionScene>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View[] array = (View[])JNIEnv.GetArray(native_view, JniHandleOwnership.DoNotTransfer, typeof(View));
			motionScene.ViewTransition(id, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_view);
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

	[Register("viewTransition", "(I[Landroid/view/View;)V", "GetViewTransition_IarrayLandroid_view_View_Handler")]
	public unsafe virtual void ViewTransition(int id, params View[]? view)
	{
		nint num = JNIEnv.NewArray(view);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(id);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("viewTransition.(I[Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			if (view != null)
			{
				JNIEnv.CopyArray(num, view);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(view);
		}
	}
}
