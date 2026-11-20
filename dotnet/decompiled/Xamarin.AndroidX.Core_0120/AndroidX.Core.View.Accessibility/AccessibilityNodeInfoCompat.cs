using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text.Style;
using Android.Views;
using Android.Views.Accessibility;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View.Accessibility;

[Register("androidx/core/view/accessibility/AccessibilityNodeInfoCompat", DoNotGenerateAcw = true)]
public class AccessibilityNodeInfoCompat : Java.Lang.Object
{
	[Register("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat", DoNotGenerateAcw = true)]
	public class AccessibilityActionCompat : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat", typeof(AccessibilityActionCompat));

		private static Delegate? cb_getId_GetId_I;

		private static Delegate? cb_getLabel_GetLabel_Ljava_lang_CharSequence_;

		private static Delegate? cb_createReplacementAction_CreateReplacementAction_Ljava_lang_CharSequence_Landroidx_core_view_accessibility_AccessibilityViewCommand__Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat_;

		private static Delegate? cb_perform_Perform_Landroid_view_View_Landroid_os_Bundle__Z;

		[Register("ACTION_ACCESSIBILITY_FOCUS")]
		public static AccessibilityActionCompat? ActionAccessibilityFocus => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_ACCESSIBILITY_FOCUS.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_CLEAR_ACCESSIBILITY_FOCUS")]
		public static AccessibilityActionCompat? ActionClearAccessibilityFocus => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_CLEAR_ACCESSIBILITY_FOCUS.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_CLEAR_FOCUS")]
		public static AccessibilityActionCompat? ActionClearFocus => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_CLEAR_FOCUS.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_CLEAR_SELECTION")]
		public static AccessibilityActionCompat? ActionClearSelection => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_CLEAR_SELECTION.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_CLICK")]
		public static AccessibilityActionCompat? ActionClick => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_CLICK.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_COLLAPSE")]
		public static AccessibilityActionCompat? ActionCollapse => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_COLLAPSE.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_CONTEXT_CLICK")]
		public static AccessibilityActionCompat? ActionContextClick => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_CONTEXT_CLICK.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_COPY")]
		public static AccessibilityActionCompat? ActionCopy => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_COPY.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_CUT")]
		public static AccessibilityActionCompat? ActionCut => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_CUT.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_DISMISS")]
		public static AccessibilityActionCompat? ActionDismiss => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_DISMISS.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_DRAG_CANCEL")]
		public static AccessibilityActionCompat? ActionDragCancel => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_DRAG_CANCEL.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_DRAG_DROP")]
		public static AccessibilityActionCompat? ActionDragDrop => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_DRAG_DROP.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_DRAG_START")]
		public static AccessibilityActionCompat? ActionDragStart => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_DRAG_START.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_EXPAND")]
		public static AccessibilityActionCompat? ActionExpand => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_EXPAND.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_FOCUS")]
		public static AccessibilityActionCompat? ActionFocus => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_FOCUS.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_HIDE_TOOLTIP")]
		public static AccessibilityActionCompat? ActionHideTooltip => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_HIDE_TOOLTIP.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_IME_ENTER")]
		public static AccessibilityActionCompat? ActionImeEnter => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_IME_ENTER.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_LONG_CLICK")]
		public static AccessibilityActionCompat? ActionLongClick => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_LONG_CLICK.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_MOVE_WINDOW")]
		public static AccessibilityActionCompat? ActionMoveWindow => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_MOVE_WINDOW.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_NEXT_AT_MOVEMENT_GRANULARITY")]
		public static AccessibilityActionCompat? ActionNextAtMovementGranularity => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_NEXT_AT_MOVEMENT_GRANULARITY.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_NEXT_HTML_ELEMENT")]
		public static AccessibilityActionCompat? ActionNextHtmlElement => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_NEXT_HTML_ELEMENT.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_PAGE_DOWN")]
		public static AccessibilityActionCompat? ActionPageDown => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_PAGE_DOWN.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_PAGE_LEFT")]
		public static AccessibilityActionCompat? ActionPageLeft => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_PAGE_LEFT.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_PAGE_RIGHT")]
		public static AccessibilityActionCompat? ActionPageRight => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_PAGE_RIGHT.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_PAGE_UP")]
		public static AccessibilityActionCompat? ActionPageUp => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_PAGE_UP.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_PASTE")]
		public static AccessibilityActionCompat? ActionPaste => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_PASTE.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_PRESS_AND_HOLD")]
		public static AccessibilityActionCompat? ActionPressAndHold => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_PRESS_AND_HOLD.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_PREVIOUS_AT_MOVEMENT_GRANULARITY")]
		public static AccessibilityActionCompat? ActionPreviousAtMovementGranularity => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_PREVIOUS_AT_MOVEMENT_GRANULARITY.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_PREVIOUS_HTML_ELEMENT")]
		public static AccessibilityActionCompat? ActionPreviousHtmlElement => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_PREVIOUS_HTML_ELEMENT.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SCROLL_BACKWARD")]
		public static AccessibilityActionCompat? ActionScrollBackward => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SCROLL_BACKWARD.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SCROLL_DOWN")]
		public static AccessibilityActionCompat? ActionScrollDown => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SCROLL_DOWN.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SCROLL_FORWARD")]
		public static AccessibilityActionCompat? ActionScrollForward => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SCROLL_FORWARD.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SCROLL_IN_DIRECTION")]
		public static AccessibilityActionCompat? ActionScrollInDirection => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SCROLL_IN_DIRECTION.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SCROLL_LEFT")]
		public static AccessibilityActionCompat? ActionScrollLeft => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SCROLL_LEFT.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SCROLL_RIGHT")]
		public static AccessibilityActionCompat? ActionScrollRight => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SCROLL_RIGHT.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SCROLL_TO_POSITION")]
		public static AccessibilityActionCompat? ActionScrollToPosition => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SCROLL_TO_POSITION.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SCROLL_UP")]
		public static AccessibilityActionCompat? ActionScrollUp => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SCROLL_UP.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SELECT")]
		public static AccessibilityActionCompat? ActionSelect => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SELECT.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SET_PROGRESS")]
		public static AccessibilityActionCompat? ActionSetProgress => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SET_PROGRESS.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SET_SELECTION")]
		public static AccessibilityActionCompat? ActionSetSelection => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SET_SELECTION.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SET_TEXT")]
		public static AccessibilityActionCompat? ActionSetText => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SET_TEXT.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SHOW_ON_SCREEN")]
		public static AccessibilityActionCompat? ActionShowOnScreen => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SHOW_ON_SCREEN.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SHOW_TEXT_SUGGESTIONS")]
		public static AccessibilityActionCompat? ActionShowTextSuggestions => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SHOW_TEXT_SUGGESTIONS.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("ACTION_SHOW_TOOLTIP")]
		public static AccessibilityActionCompat? ActionShowTooltip => Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.StaticFields.GetObjectValue("ACTION_SHOW_TOOLTIP.Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("mCommand")]
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		protected IAccessibilityViewCommand? MCommand
		{
			get
			{
				return Java.Lang.Object.GetObject<IAccessibilityViewCommand>(_members.InstanceFields.GetObjectValue("mCommand.Landroidx/core/view/accessibility/AccessibilityViewCommand;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mCommand.Landroidx/core/view/accessibility/AccessibilityViewCommand;", this, new JniObjectReference(num));
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

		public unsafe virtual int Id
		{
			[Register("getId", "()I", "GetGetIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
			}
		}

		public unsafe virtual ICharSequence? LabelFormatted
		{
			[Register("getLabel", "()Ljava/lang/CharSequence;", "GetGetLabelHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLabel.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public string? Label
		{
			get
			{
				if (LabelFormatted != null)
				{
					return LabelFormatted.ToString();
				}
				return null;
			}
		}

		protected AccessibilityActionCompat(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(ILjava/lang/CharSequence;)V", "")]
		public unsafe AccessibilityActionCompat(int actionId, ICharSequence? label)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = CharSequence.ToLocalJniHandle(label);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(actionId);
				ptr[1] = new JniArgumentValue(num);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/CharSequence;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(label);
			}
		}

		[Register(".ctor", "(ILjava/lang/CharSequence;)V", "")]
		public unsafe AccessibilityActionCompat(int actionId, string? label)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = CharSequence.ToLocalJniHandle(label);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(actionId);
				ptr[1] = new JniArgumentValue(num);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/CharSequence;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(label);
			}
		}

		[Register(".ctor", "(ILjava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)V", "")]
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		public unsafe AccessibilityActionCompat(int actionId, ICharSequence? label, IAccessibilityViewCommand? command)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = CharSequence.ToLocalJniHandle(label);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(actionId);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue((command == null) ? IntPtr.Zero : ((Java.Lang.Object)command).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(label);
				GC.KeepAlive(command);
			}
		}

		[Register(".ctor", "(ILjava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)V", "")]
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		public unsafe AccessibilityActionCompat(int actionId, string? label, IAccessibilityViewCommand? command)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = CharSequence.ToLocalJniHandle(label);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(actionId);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue((command == null) ? IntPtr.Zero : ((Java.Lang.Object)command).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILjava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILjava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(label);
				GC.KeepAlive(command);
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
				return Java.Lang.Object.GetObject<AccessibilityActionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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

		private static Delegate GetGetLabelHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetLabel);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetLabel(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityActionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LabelFormatted);
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

		private static Delegate GetCreateReplacementAction_Ljava_lang_CharSequence_Landroidx_core_view_accessibility_AccessibilityViewCommand_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_CreateReplacementAction_Ljava_lang_CharSequence_Landroidx_core_view_accessibility_AccessibilityViewCommand_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_CreateReplacementAction_Ljava_lang_CharSequence_Landroidx_core_view_accessibility_AccessibilityViewCommand_(nint jnienv, nint native__this, nint native_label, nint native_command)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				AccessibilityActionCompat? accessibilityActionCompat = Java.Lang.Object.GetObject<AccessibilityActionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ICharSequence label = Java.Lang.Object.GetObject<ICharSequence>(native_label, JniHandleOwnership.DoNotTransfer);
				IAccessibilityViewCommand command = Java.Lang.Object.GetObject<IAccessibilityViewCommand>(native_command, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(accessibilityActionCompat.CreateReplacementAction(label, command));
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
		[Register("createReplacementAction", "(Ljava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;", "GetCreateReplacementAction_Ljava_lang_CharSequence_Landroidx_core_view_accessibility_AccessibilityViewCommand_Handler")]
		public unsafe virtual AccessibilityActionCompat? CreateReplacementAction(ICharSequence? label, IAccessibilityViewCommand? command)
		{
			nint num = CharSequence.ToLocalJniHandle(label);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue((command == null) ? IntPtr.Zero : ((Java.Lang.Object)command).Handle);
				return Java.Lang.Object.GetObject<AccessibilityActionCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("createReplacementAction.(Ljava/lang/CharSequence;Landroidx/core/view/accessibility/AccessibilityViewCommand;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(label);
				GC.KeepAlive(command);
			}
		}

		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		public AccessibilityActionCompat? CreateReplacementAction(string? label, IAccessibilityViewCommand? command)
		{
			Java.Lang.String obj = ((label == null) ? null : new Java.Lang.String(label));
			AccessibilityActionCompat? result = CreateReplacementAction(obj, command);
			obj?.Dispose();
			return result;
		}

		private static Delegate GetPerform_Landroid_view_View_Landroid_os_Bundle_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_Perform_Landroid_view_View_Landroid_os_Bundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_Perform_Landroid_view_View_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_view, nint native_arguments)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				AccessibilityActionCompat? accessibilityActionCompat = Java.Lang.Object.GetObject<AccessibilityActionCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
				Bundle arguments = Java.Lang.Object.GetObject<Bundle>(native_arguments, JniHandleOwnership.DoNotTransfer);
				return accessibilityActionCompat.Perform(view, arguments) ? ((sbyte)1) : ((sbyte)0);
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
		[Register("perform", "(Landroid/view/View;Landroid/os/Bundle;)Z", "GetPerform_Landroid_view_View_Landroid_os_Bundle_Handler")]
		public unsafe virtual bool Perform(Android.Views.View? view, Bundle? arguments)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(arguments?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("perform.(Landroid/view/View;Landroid/os/Bundle;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
				GC.KeepAlive(arguments);
			}
		}
	}

	[Register("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionInfoCompat", DoNotGenerateAcw = true)]
	public class CollectionInfoCompat : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionInfoCompat", typeof(CollectionInfoCompat));

		private static Delegate? cb_getColumnCount_GetColumnCount_I;

		private static Delegate? cb_getImportantForAccessibilityItemCount_GetImportantForAccessibilityItemCount_I;

		private static Delegate? cb_isHierarchical_IsHierarchical_Z;

		private static Delegate? cb_getItemCount_GetItemCount_I;

		private static Delegate? cb_getRowCount_GetRowCount_I;

		private static Delegate? cb_getSelectionMode_GetSelectionMode_I;

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

		public unsafe virtual int ColumnCount
		{
			[Register("getColumnCount", "()I", "GetGetColumnCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getColumnCount.()I", this, null);
			}
		}

		public unsafe virtual int ImportantForAccessibilityItemCount
		{
			[Register("getImportantForAccessibilityItemCount", "()I", "GetGetImportantForAccessibilityItemCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getImportantForAccessibilityItemCount.()I", this, null);
			}
		}

		public unsafe virtual bool IsHierarchical
		{
			[Register("isHierarchical", "()Z", "GetIsHierarchicalHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHierarchical.()Z", this, null);
			}
		}

		public unsafe virtual int ItemCount
		{
			[Register("getItemCount", "()I", "GetGetItemCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getItemCount.()I", this, null);
			}
		}

		public unsafe virtual int RowCount
		{
			[Register("getRowCount", "()I", "GetGetRowCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRowCount.()I", this, null);
			}
		}

		public unsafe virtual int SelectionMode
		{
			[Register("getSelectionMode", "()I", "GetGetSelectionModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getSelectionMode.()I", this, null);
			}
		}

		protected CollectionInfoCompat(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
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
				return Java.Lang.Object.GetObject<CollectionInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnCount;
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

		private static Delegate GetGetImportantForAccessibilityItemCountHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetImportantForAccessibilityItemCount);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetImportantForAccessibilityItemCount(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImportantForAccessibilityItemCount;
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

		private static Delegate GetIsHierarchicalHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsHierarchical);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsHierarchical(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsHierarchical ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetGetItemCountHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetItemCount);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetItemCount(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCount;
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
				return Java.Lang.Object.GetObject<CollectionInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RowCount;
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

		private static Delegate GetGetSelectionModeHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetSelectionMode);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetSelectionMode(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SelectionMode;
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

		[Register("obtain", "(IIZ)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionInfoCompat;", "")]
		public unsafe static CollectionInfoCompat? Obtain(int rowCount, int columnCount, bool hierarchical)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(rowCount);
			ptr[1] = new JniArgumentValue(columnCount);
			ptr[2] = new JniArgumentValue(hierarchical ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<CollectionInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.(IIZ)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("obtain", "(IIZI)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionInfoCompat;", "")]
		public unsafe static CollectionInfoCompat? Obtain(int rowCount, int columnCount, bool hierarchical, int selectionMode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(rowCount);
			ptr[1] = new JniArgumentValue(columnCount);
			ptr[2] = new JniArgumentValue(hierarchical ? ((sbyte)1) : ((sbyte)0));
			ptr[3] = new JniArgumentValue(selectionMode);
			return Java.Lang.Object.GetObject<CollectionInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.(IIZI)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Register("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionItemInfoCompat", DoNotGenerateAcw = true)]
	public class CollectionItemInfoCompat : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionItemInfoCompat", typeof(CollectionItemInfoCompat));

		private static Delegate? cb_getColumnIndex_GetColumnIndex_I;

		private static Delegate? cb_getColumnSpan_GetColumnSpan_I;

		private static Delegate? cb_getColumnTitle_GetColumnTitle_Ljava_lang_String_;

		private static Delegate? cb_isHeading_IsHeading_Z;

		private static Delegate? cb_isSelected_IsSelected_Z;

		private static Delegate? cb_getRowIndex_GetRowIndex_I;

		private static Delegate? cb_getRowSpan_GetRowSpan_I;

		private static Delegate? cb_getRowTitle_GetRowTitle_Ljava_lang_String_;

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

		public unsafe virtual int ColumnIndex
		{
			[Register("getColumnIndex", "()I", "GetGetColumnIndexHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getColumnIndex.()I", this, null);
			}
		}

		public unsafe virtual int ColumnSpan
		{
			[Register("getColumnSpan", "()I", "GetGetColumnSpanHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getColumnSpan.()I", this, null);
			}
		}

		public unsafe virtual string? ColumnTitle
		{
			[Register("getColumnTitle", "()Ljava/lang/String;", "GetGetColumnTitleHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getColumnTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual bool IsHeading
		{
			[Register("isHeading", "()Z", "GetIsHeadingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHeading.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSelected
		{
			[Register("isSelected", "()Z", "GetIsSelectedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSelected.()Z", this, null);
			}
		}

		public unsafe virtual int RowIndex
		{
			[Register("getRowIndex", "()I", "GetGetRowIndexHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRowIndex.()I", this, null);
			}
		}

		public unsafe virtual int RowSpan
		{
			[Register("getRowSpan", "()I", "GetGetRowSpanHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRowSpan.()I", this, null);
			}
		}

		public unsafe virtual string? RowTitle
		{
			[Register("getRowTitle", "()Ljava/lang/String;", "GetGetRowTitleHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getRowTitle.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected CollectionItemInfoCompat(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetColumnIndexHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetColumnIndex);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetColumnIndex(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionItemInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnIndex;
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

		private static Delegate GetGetColumnSpanHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetColumnSpan);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetColumnSpan(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionItemInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnSpan;
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

		private static Delegate GetGetColumnTitleHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetColumnTitle);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetColumnTitle(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<CollectionItemInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ColumnTitle);
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

		[Obsolete]
		private static Delegate GetIsHeadingHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsHeading);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsHeading(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionItemInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsHeading ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetIsSelectedHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsSelected);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsSelected(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionItemInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSelected ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetGetRowIndexHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetRowIndex);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetRowIndex(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionItemInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RowIndex;
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

		private static Delegate GetGetRowSpanHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetRowSpan);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetRowSpan(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<CollectionItemInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RowSpan;
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

		private static Delegate GetGetRowTitleHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetRowTitle);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetRowTitle(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.NewString(Java.Lang.Object.GetObject<CollectionItemInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RowTitle);
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

		[Register("obtain", "(IIIIZ)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionItemInfoCompat;", "")]
		public unsafe static CollectionItemInfoCompat? Obtain(int rowIndex, int rowSpan, int columnIndex, int columnSpan, bool heading)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(rowIndex);
			ptr[1] = new JniArgumentValue(rowSpan);
			ptr[2] = new JniArgumentValue(columnIndex);
			ptr[3] = new JniArgumentValue(columnSpan);
			ptr[4] = new JniArgumentValue(heading ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<CollectionItemInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.(IIIIZ)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionItemInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("obtain", "(IIIIZZ)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionItemInfoCompat;", "")]
		public unsafe static CollectionItemInfoCompat? Obtain(int rowIndex, int rowSpan, int columnIndex, int columnSpan, bool heading, bool selected)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(rowIndex);
			ptr[1] = new JniArgumentValue(rowSpan);
			ptr[2] = new JniArgumentValue(columnIndex);
			ptr[3] = new JniArgumentValue(columnSpan);
			ptr[4] = new JniArgumentValue(heading ? ((sbyte)1) : ((sbyte)0));
			ptr[5] = new JniArgumentValue(selected ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<CollectionItemInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.(IIIIZZ)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionItemInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Register("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$RangeInfoCompat", DoNotGenerateAcw = true)]
	public class RangeInfoCompat : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$RangeInfoCompat", typeof(RangeInfoCompat));

		private static Delegate? cb_getCurrent_GetCurrent_F;

		private static Delegate? cb_getMax_GetMax_F;

		private static Delegate? cb_getMin_GetMin_F;

		private static Delegate? cb_getType_GetType_I;

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

		public unsafe virtual float Current
		{
			[Register("getCurrent", "()F", "GetGetCurrentHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getCurrent.()F", this, null);
			}
		}

		public unsafe virtual float Max
		{
			[Register("getMax", "()F", "GetGetMaxHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getMax.()F", this, null);
			}
		}

		public unsafe virtual float Min
		{
			[Register("getMin", "()F", "GetGetMinHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getMin.()F", this, null);
			}
		}

		public unsafe virtual int Type
		{
			[Register("getType", "()I", "GetGetTypeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getType.()I", this, null);
			}
		}

		protected RangeInfoCompat(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(IFFF)V", "")]
		public unsafe RangeInfoCompat(int type, float min, float max, float current)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(type);
				ptr[1] = new JniArgumentValue(min);
				ptr[2] = new JniArgumentValue(max);
				ptr[3] = new JniArgumentValue(current);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(IFFF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(IFFF)V", this, ptr);
			}
		}

		private static Delegate GetGetCurrentHandler()
		{
			return new global::_JniMarshal_PP_F(n_GetCurrent);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetCurrent(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				return Java.Lang.Object.GetObject<RangeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Current;
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

		private static Delegate GetGetMaxHandler()
		{
			return new global::_JniMarshal_PP_F(n_GetMax);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetMax(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				return Java.Lang.Object.GetObject<RangeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Max;
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

		private static Delegate GetGetMinHandler()
		{
			return new global::_JniMarshal_PP_F(n_GetMin);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static float n_GetMin(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0f;
			}
			try
			{
				return Java.Lang.Object.GetObject<RangeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Min;
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

		private static Delegate GetGetTypeHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetType);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetType(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<RangeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type;
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

		[Register("obtain", "(IFFF)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$RangeInfoCompat;", "")]
		public unsafe static RangeInfoCompat? Obtain(int type, float min, float max, float current)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(type);
			ptr[1] = new JniArgumentValue(min);
			ptr[2] = new JniArgumentValue(max);
			ptr[3] = new JniArgumentValue(current);
			return Java.Lang.Object.GetObject<RangeInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.(IFFF)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$RangeInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Register("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$TouchDelegateInfoCompat", DoNotGenerateAcw = true)]
	public sealed class TouchDelegateInfoCompat : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityNodeInfoCompat$TouchDelegateInfoCompat", typeof(TouchDelegateInfoCompat));

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

		public unsafe int RegionCount
		{
			[Register("getRegionCount", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getRegionCount.()I", this, null);
			}
		}

		internal TouchDelegateInfoCompat(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/Map;)V", "")]
		public unsafe TouchDelegateInfoCompat(IDictionary<Region, Android.Views.View>? targetMap)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			nint num = JavaDictionary<Region, Android.Views.View>.ToLocalJniHandle(targetMap);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Map;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Map;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(targetMap);
			}
		}

		[Register("getRegionAt", "(I)Landroid/graphics/Region;", "")]
		public unsafe Region? GetRegionAt(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return Java.Lang.Object.GetObject<Region>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRegionAt.(I)Landroid/graphics/Region;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getTargetForRegion", "(Landroid/graphics/Region;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "")]
		public unsafe AccessibilityNodeInfoCompat? GetTargetForRegion(Region? region)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(region?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTargetForRegion.(Landroid/graphics/Region;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(region);
			}
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityNodeInfoCompat", typeof(AccessibilityNodeInfoCompat));

	private static Delegate? cb_isAccessibilityDataSensitive_IsAccessibilityDataSensitive_Z;

	private static Delegate? cb_setAccessibilityDataSensitive_SetAccessibilityDataSensitive_Z_V;

	private static Delegate? cb_isAccessibilityFocused_IsAccessibilityFocused_Z;

	private static Delegate? cb_setAccessibilityFocused_SetAccessibilityFocused_Z_V;

	private static Delegate? cb_getActionList_GetActionList_Ljava_util_List_;

	private static Delegate? cb_getActions_GetActions_I;

	private static Delegate? cb_getAvailableExtraData_GetAvailableExtraData_Ljava_util_List_;

	private static Delegate? cb_setAvailableExtraData_SetAvailableExtraData_Ljava_util_List__V;

	private static Delegate? cb_isCheckable_IsCheckable_Z;

	private static Delegate? cb_setCheckable_SetCheckable_Z_V;

	private static Delegate? cb_isChecked_IsChecked_Z;

	private static Delegate? cb_setChecked_SetChecked_Z_V;

	private static Delegate? cb_getChildCount_GetChildCount_I;

	private static Delegate? cb_getClassName_GetClassName_Ljava_lang_CharSequence_;

	private static Delegate? cb_setClassName_SetClassName_Ljava_lang_CharSequence__V;

	private static Delegate? cb_isClickable_IsClickable_Z;

	private static Delegate? cb_setClickable_SetClickable_Z_V;

	private static Delegate? cb_getCollectionInfo_GetCollectionInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_CollectionInfoCompat_;

	private static Delegate? cb_getCollectionItemInfo_GetCollectionItemInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_CollectionItemInfoCompat_;

	private static Delegate? cb_getContainerTitle_GetContainerTitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setContainerTitle_SetContainerTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getContentDescription_GetContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setContentDescription_SetContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_isContentInvalid_IsContentInvalid_Z;

	private static Delegate? cb_setContentInvalid_SetContentInvalid_Z_V;

	private static Delegate? cb_isContextClickable_IsContextClickable_Z;

	private static Delegate? cb_setContextClickable_SetContextClickable_Z_V;

	private static Delegate? cb_isDismissable_IsDismissable_Z;

	private static Delegate? cb_setDismissable_SetDismissable_Z_V;

	private static Delegate? cb_getDrawingOrder_GetDrawingOrder_I;

	private static Delegate? cb_setDrawingOrder_SetDrawingOrder_I_V;

	private static Delegate? cb_isEditable_IsEditable_Z;

	private static Delegate? cb_setEditable_SetEditable_Z_V;

	private static Delegate? cb_isEnabled_IsEnabled_Z;

	private static Delegate? cb_setEnabled_SetEnabled_Z_V;

	private static Delegate? cb_getError_GetError_Ljava_lang_CharSequence_;

	private static Delegate? cb_setError_SetError_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getExtraRenderingInfo_GetExtraRenderingInfo_Landroid_view_accessibility_AccessibilityNodeInfo_ExtraRenderingInfo_;

	private static Delegate? cb_getExtras_GetExtras_Landroid_os_Bundle_;

	private static Delegate? cb_isFieldRequired_IsFieldRequired_Z;

	private static Delegate? cb_setFieldRequired_SetFieldRequired_Z_V;

	private static Delegate? cb_isFocusable_IsFocusable_Z;

	private static Delegate? cb_setFocusable_SetFocusable_Z_V;

	private static Delegate? cb_isFocused_IsFocused_Z;

	private static Delegate? cb_setFocused_SetFocused_Z_V;

	private static Delegate? cb_isGranularScrollingSupported_IsGranularScrollingSupported_Z;

	private static Delegate? cb_setGranularScrollingSupported_SetGranularScrollingSupported_Z_V;

	private static Delegate? cb_hasRequestInitialAccessibilityFocus_HasRequestInitialAccessibilityFocus_Z;

	private static Delegate? cb_isHeading_IsHeading_Z;

	private static Delegate? cb_setHeading_SetHeading_Z_V;

	private static Delegate? cb_getHintText_GetHintText_Ljava_lang_CharSequence_;

	private static Delegate? cb_setHintText_SetHintText_Ljava_lang_CharSequence__V;

	private static Delegate? cb_isImportantForAccessibility_IsImportantForAccessibility_Z;

	private static Delegate? cb_setImportantForAccessibility_SetImportantForAccessibility_Z_V;

	private static Delegate? cb_getInfo_GetInfo_Ljava_lang_Object_;

	private static Delegate? cb_getInputType_GetInputType_I;

	private static Delegate? cb_setInputType_SetInputType_I_V;

	private static Delegate? cb_getLabelFor_GetLabelFor_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_getLabeledBy_GetLabeledBy_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_getLiveRegion_GetLiveRegion_I;

	private static Delegate? cb_setLiveRegion_SetLiveRegion_I_V;

	private static Delegate? cb_isLongClickable_IsLongClickable_Z;

	private static Delegate? cb_setLongClickable_SetLongClickable_Z_V;

	private static Delegate? cb_getMaxTextLength_GetMaxTextLength_I;

	private static Delegate? cb_setMaxTextLength_SetMaxTextLength_I_V;

	private static Delegate? cb_getMinDurationBetweenContentChangesMillis_GetMinDurationBetweenContentChangesMillis_J;

	private static Delegate? cb_setMinDurationBetweenContentChangesMillis_SetMinDurationBetweenContentChangesMillis_J_V;

	private static Delegate? cb_getMovementGranularities_GetMovementGranularities_I;

	private static Delegate? cb_setMovementGranularities_SetMovementGranularities_I_V;

	private static Delegate? cb_isMultiLine_IsMultiLine_Z;

	private static Delegate? cb_setMultiLine_SetMultiLine_Z_V;

	private static Delegate? cb_getPackageName_GetPackageName_Ljava_lang_CharSequence_;

	private static Delegate? cb_setPackageName_SetPackageName_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getPaneTitle_GetPaneTitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setPaneTitle_SetPaneTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getParent_GetParent_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_isPassword_IsPassword_Z;

	private static Delegate? cb_setPassword_SetPassword_Z_V;

	private static Delegate? cb_getRangeInfo_GetRangeInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_RangeInfoCompat_;

	private static Delegate? cb_setRangeInfo_SetRangeInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_RangeInfoCompat__V;

	private static Delegate? cb_getRoleDescription_GetRoleDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setRoleDescription_SetRoleDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_isScreenReaderFocusable_IsScreenReaderFocusable_Z;

	private static Delegate? cb_setScreenReaderFocusable_SetScreenReaderFocusable_Z_V;

	private static Delegate? cb_isScrollable_IsScrollable_Z;

	private static Delegate? cb_setScrollable_SetScrollable_Z_V;

	private static Delegate? cb_isSelected_IsSelected_Z;

	private static Delegate? cb_setSelected_SetSelected_Z_V;

	private static Delegate? cb_isShowingHintText_IsShowingHintText_Z;

	private static Delegate? cb_setShowingHintText_SetShowingHintText_Z_V;

	private static Delegate? cb_getStateDescription_GetStateDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setStateDescription_SetStateDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getText_GetText_Ljava_lang_CharSequence_;

	private static Delegate? cb_setText_SetText_Ljava_lang_CharSequence__V;

	private static Delegate? cb_isTextEntryKey_IsTextEntryKey_Z;

	private static Delegate? cb_setTextEntryKey_SetTextEntryKey_Z_V;

	private static Delegate? cb_isTextSelectable_IsTextSelectable_Z;

	private static Delegate? cb_setTextSelectable_SetTextSelectable_Z_V;

	private static Delegate? cb_getTextSelectionEnd_GetTextSelectionEnd_I;

	private static Delegate? cb_getTextSelectionStart_GetTextSelectionStart_I;

	private static Delegate? cb_getTooltipText_GetTooltipText_Ljava_lang_CharSequence_;

	private static Delegate? cb_setTooltipText_SetTooltipText_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getTouchDelegateInfo_GetTouchDelegateInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_TouchDelegateInfoCompat_;

	private static Delegate? cb_setTouchDelegateInfo_SetTouchDelegateInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_TouchDelegateInfoCompat__V;

	private static Delegate? cb_getTraversalAfter_GetTraversalAfter_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_getTraversalBefore_GetTraversalBefore_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_getUniqueId_GetUniqueId_Ljava_lang_String_;

	private static Delegate? cb_setUniqueId_SetUniqueId_Ljava_lang_String__V;

	private static Delegate? cb_getViewIdResourceName_GetViewIdResourceName_Ljava_lang_String_;

	private static Delegate? cb_setViewIdResourceName_SetViewIdResourceName_Ljava_lang_String__V;

	private static Delegate? cb_isVisibleToUser_IsVisibleToUser_Z;

	private static Delegate? cb_setVisibleToUser_SetVisibleToUser_Z_V;

	private static Delegate? cb_getWindow_GetWindow_Landroidx_core_view_accessibility_AccessibilityWindowInfoCompat_;

	private static Delegate? cb_getWindowId_GetWindowId_I;

	private static Delegate? cb_addAction_AddAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat__V;

	private static Delegate? cb_addAction_AddAction_I_V;

	private static Delegate? cb_addChild_AddChild_Landroid_view_View__V;

	private static Delegate? cb_addChild_AddChild_Landroid_view_View_I_V;

	private static Delegate? cb_addSpansToExtras_AddSpansToExtras_Ljava_lang_CharSequence_Landroid_view_View__V;

	private static Delegate? cb_canOpenPopup_CanOpenPopup_Z;

	private static Delegate? cb_findAccessibilityNodeInfosByText_FindAccessibilityNodeInfosByText_Ljava_lang_String__Ljava_util_List_;

	private static Delegate? cb_findAccessibilityNodeInfosByViewId_FindAccessibilityNodeInfosByViewId_Ljava_lang_String__Ljava_util_List_;

	private static Delegate? cb_findFocus_FindFocus_I_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_focusSearch_FocusSearch_I_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_getBoundsInParent_GetBoundsInParent_Landroid_graphics_Rect__V;

	private static Delegate? cb_getBoundsInScreen_GetBoundsInScreen_Landroid_graphics_Rect__V;

	private static Delegate? cb_getBoundsInWindow_GetBoundsInWindow_Landroid_graphics_Rect__V;

	private static Delegate? cb_getChild_GetChild_I_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_getChild_GetChild_II_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_getParent_GetParent_I_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_;

	private static Delegate? cb_performAction_PerformAction_I_Z;

	private static Delegate? cb_performAction_PerformAction_ILandroid_os_Bundle__Z;

	private static Delegate? cb_recycle_Recycle_V;

	private static Delegate? cb_refresh_Refresh_Z;

	private static Delegate? cb_removeAction_RemoveAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat__Z;

	private static Delegate? cb_removeChild_RemoveChild_Landroid_view_View__Z;

	private static Delegate? cb_removeChild_RemoveChild_Landroid_view_View_I_Z;

	private static Delegate? cb_setBoundsInParent_SetBoundsInParent_Landroid_graphics_Rect__V;

	private static Delegate? cb_setBoundsInScreen_SetBoundsInScreen_Landroid_graphics_Rect__V;

	private static Delegate? cb_setBoundsInWindow_SetBoundsInWindow_Landroid_graphics_Rect__V;

	private static Delegate? cb_setCanOpenPopup_SetCanOpenPopup_Z_V;

	private static Delegate? cb_setCollectionInfo_SetCollectionInfo_Ljava_lang_Object__V;

	private static Delegate? cb_setCollectionItemInfo_SetCollectionItemInfo_Ljava_lang_Object__V;

	private static Delegate? cb_setLabelFor_SetLabelFor_Landroid_view_View__V;

	private static Delegate? cb_setLabelFor_SetLabelFor_Landroid_view_View_I_V;

	private static Delegate? cb_setLabeledBy_SetLabeledBy_Landroid_view_View__V;

	private static Delegate? cb_setLabeledBy_SetLabeledBy_Landroid_view_View_I_V;

	private static Delegate? cb_setParent_SetParent_Landroid_view_View__V;

	private static Delegate? cb_setParent_SetParent_Landroid_view_View_I_V;

	private static Delegate? cb_setQueryFromAppProcessEnabled_SetQueryFromAppProcessEnabled_Landroid_view_View_Z_V;

	private static Delegate? cb_setRequestInitialAccessibilityFocus_SetRequestInitialAccessibilityFocus_Z_V;

	private static Delegate? cb_setSource_SetSource_Landroid_view_View__V;

	private static Delegate? cb_setSource_SetSource_Landroid_view_View_I_V;

	private static Delegate? cb_setTextSelection_SetTextSelection_II_V;

	private static Delegate? cb_setTraversalAfter_SetTraversalAfter_Landroid_view_View__V;

	private static Delegate? cb_setTraversalAfter_SetTraversalAfter_Landroid_view_View_I_V;

	private static Delegate? cb_setTraversalBefore_SetTraversalBefore_Landroid_view_View__V;

	private static Delegate? cb_setTraversalBefore_SetTraversalBefore_Landroid_view_View_I_V;

	private static Delegate? cb_unwrap_Unwrap_Landroid_view_accessibility_AccessibilityNodeInfo_;

	[Register("mParentVirtualDescendantId")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public int MParentVirtualDescendantId
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mParentVirtualDescendantId.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mParentVirtualDescendantId.I", this, value);
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

	public unsafe virtual bool AccessibilityDataSensitive
	{
		[Register("isAccessibilityDataSensitive", "()Z", "GetIsAccessibilityDataSensitiveHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAccessibilityDataSensitive.()Z", this, null);
		}
		[Register("setAccessibilityDataSensitive", "(Z)V", "GetSetAccessibilityDataSensitive_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAccessibilityDataSensitive.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool AccessibilityFocused
	{
		[Register("isAccessibilityFocused", "()Z", "GetIsAccessibilityFocusedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAccessibilityFocused.()Z", this, null);
		}
		[Register("setAccessibilityFocused", "(Z)V", "GetSetAccessibilityFocused_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAccessibilityFocused.(Z)V", this, ptr);
		}
	}

	public unsafe virtual IList<AccessibilityActionCompat>? ActionList
	{
		[Register("getActionList", "()Ljava/util/List;", "GetGetActionListHandler")]
		get
		{
			return JavaList<AccessibilityActionCompat>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getActionList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int Actions
	{
		[Register("getActions", "()I", "GetGetActionsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getActions.()I", this, null);
		}
	}

	public unsafe virtual IList<string>? AvailableExtraData
	{
		[Register("getAvailableExtraData", "()Ljava/util/List;", "GetGetAvailableExtraDataHandler")]
		get
		{
			return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getAvailableExtraData.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setAvailableExtraData", "(Ljava/util/List;)V", "GetSetAvailableExtraData_Ljava_util_List_Handler")]
		set
		{
			nint num = JavaList<string>.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAvailableExtraData.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool Checkable
	{
		[Register("isCheckable", "()Z", "GetIsCheckableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCheckable.()Z", this, null);
		}
		[Register("setCheckable", "(Z)V", "GetSetCheckable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool Checked
	{
		[Register("isChecked", "()Z", "GetIsCheckedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isChecked.()Z", this, null);
		}
		[Register("setChecked", "(Z)V", "GetSetChecked_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setChecked.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int ChildCount
	{
		[Register("getChildCount", "()I", "GetGetChildCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getChildCount.()I", this, null);
		}
	}

	public unsafe virtual ICharSequence? ClassNameFormatted
	{
		[Register("getClassName", "()Ljava/lang/CharSequence;", "GetGetClassNameHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getClassName.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setClassName", "(Ljava/lang/CharSequence;)V", "GetSetClassName_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setClassName.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? ClassName
	{
		get
		{
			if (ClassNameFormatted != null)
			{
				return ClassNameFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(ClassNameFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual bool Clickable
	{
		[Register("isClickable", "()Z", "GetIsClickableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isClickable.()Z", this, null);
		}
		[Register("setClickable", "(Z)V", "GetSetClickable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setClickable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual CollectionInfoCompat? CollectionInfo
	{
		[Register("getCollectionInfo", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionInfoCompat;", "GetGetCollectionInfoHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CollectionInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCollectionInfo.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual CollectionItemInfoCompat? CollectionItemInfo
	{
		[Register("getCollectionItemInfo", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionItemInfoCompat;", "GetGetCollectionItemInfoHandler")]
		get
		{
			return Java.Lang.Object.GetObject<CollectionItemInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCollectionItemInfo.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$CollectionItemInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICharSequence? ContainerTitleFormatted
	{
		[Register("getContainerTitle", "()Ljava/lang/CharSequence;", "GetGetContainerTitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContainerTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setContainerTitle", "(Ljava/lang/CharSequence;)V", "GetSetContainerTitle_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setContainerTitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? ContainerTitle
	{
		get
		{
			if (ContainerTitleFormatted != null)
			{
				return ContainerTitleFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(ContainerTitleFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual ICharSequence? ContentDescriptionFormatted
	{
		[Register("getContentDescription", "()Ljava/lang/CharSequence;", "GetGetContentDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetContentDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? ContentDescription
	{
		get
		{
			if (ContentDescriptionFormatted != null)
			{
				return ContentDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(ContentDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual bool ContentInvalid
	{
		[Register("isContentInvalid", "()Z", "GetIsContentInvalidHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isContentInvalid.()Z", this, null);
		}
		[Register("setContentInvalid", "(Z)V", "GetSetContentInvalid_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContentInvalid.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool ContextClickable
	{
		[Register("isContextClickable", "()Z", "GetIsContextClickableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isContextClickable.()Z", this, null);
		}
		[Register("setContextClickable", "(Z)V", "GetSetContextClickable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContextClickable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool Dismissable
	{
		[Register("isDismissable", "()Z", "GetIsDismissableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDismissable.()Z", this, null);
		}
		[Register("setDismissable", "(Z)V", "GetSetDismissable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDismissable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int DrawingOrder
	{
		[Register("getDrawingOrder", "()I", "GetGetDrawingOrderHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getDrawingOrder.()I", this, null);
		}
		[Register("setDrawingOrder", "(I)V", "GetSetDrawingOrder_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawingOrder.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool Editable
	{
		[Register("isEditable", "()Z", "GetIsEditableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEditable.()Z", this, null);
		}
		[Register("setEditable", "(Z)V", "GetSetEditable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEditable.(Z)V", this, ptr);
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

	public unsafe virtual ICharSequence? ErrorFormatted
	{
		[Register("getError", "()Ljava/lang/CharSequence;", "GetGetErrorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getError.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setError", "(Ljava/lang/CharSequence;)V", "GetSetError_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setError.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? Error
	{
		get
		{
			if (ErrorFormatted != null)
			{
				return ErrorFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(ErrorFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual AccessibilityNodeInfo.ExtraRenderingInfo? ExtraRenderingInfo
	{
		[Register("getExtraRenderingInfo", "()Landroid/view/accessibility/AccessibilityNodeInfo$ExtraRenderingInfo;", "GetGetExtraRenderingInfoHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfo.ExtraRenderingInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExtraRenderingInfo.()Landroid/view/accessibility/AccessibilityNodeInfo$ExtraRenderingInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Bundle? Extras
	{
		[Register("getExtras", "()Landroid/os/Bundle;", "GetGetExtrasHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Bundle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExtras.()Landroid/os/Bundle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool FieldRequired
	{
		[Register("isFieldRequired", "()Z", "GetIsFieldRequiredHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFieldRequired.()Z", this, null);
		}
		[Register("setFieldRequired", "(Z)V", "GetSetFieldRequired_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFieldRequired.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool Focusable
	{
		[Register("isFocusable", "()Z", "GetIsFocusableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFocusable.()Z", this, null);
		}
		[Register("setFocusable", "(Z)V", "GetSetFocusable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFocusable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool Focused
	{
		[Register("isFocused", "()Z", "GetIsFocusedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFocused.()Z", this, null);
		}
		[Register("setFocused", "(Z)V", "GetSetFocused_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFocused.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool GranularScrollingSupported
	{
		[Register("isGranularScrollingSupported", "()Z", "GetIsGranularScrollingSupportedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isGranularScrollingSupported.()Z", this, null);
		}
		[Register("setGranularScrollingSupported", "(Z)V", "GetSetGranularScrollingSupported_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGranularScrollingSupported.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool HasRequestInitialAccessibilityFocus
	{
		[Register("hasRequestInitialAccessibilityFocus", "()Z", "GetHasRequestInitialAccessibilityFocusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasRequestInitialAccessibilityFocus.()Z", this, null);
		}
	}

	public unsafe virtual bool Heading
	{
		[Register("isHeading", "()Z", "GetIsHeadingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHeading.()Z", this, null);
		}
		[Register("setHeading", "(Z)V", "GetSetHeading_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHeading.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? HintTextFormatted
	{
		[Register("getHintText", "()Ljava/lang/CharSequence;", "GetGetHintTextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHintText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setHintText", "(Ljava/lang/CharSequence;)V", "GetSetHintText_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHintText.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? HintText
	{
		get
		{
			if (HintTextFormatted != null)
			{
				return HintTextFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(HintTextFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual bool ImportantForAccessibility
	{
		[Register("isImportantForAccessibility", "()Z", "GetIsImportantForAccessibilityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isImportantForAccessibility.()Z", this, null);
		}
		[Register("setImportantForAccessibility", "(Z)V", "GetSetImportantForAccessibility_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setImportantForAccessibility.(Z)V", this, ptr);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual Java.Lang.Object? Info
	{
		[Register("getInfo", "()Ljava/lang/Object;", "GetGetInfoHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInfo.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int InputType
	{
		[Register("getInputType", "()I", "GetGetInputTypeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getInputType.()I", this, null);
		}
		[Register("setInputType", "(I)V", "GetSetInputType_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInputType.(I)V", this, ptr);
		}
	}

	public unsafe virtual AccessibilityNodeInfoCompat? LabelFor
	{
		[Register("getLabelFor", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetLabelForHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLabelFor.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual AccessibilityNodeInfoCompat? LabeledBy
	{
		[Register("getLabeledBy", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetLabeledByHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLabeledBy.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int LiveRegion
	{
		[Register("getLiveRegion", "()I", "GetGetLiveRegionHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLiveRegion.()I", this, null);
		}
		[Register("setLiveRegion", "(I)V", "GetSetLiveRegion_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLiveRegion.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool LongClickable
	{
		[Register("isLongClickable", "()Z", "GetIsLongClickableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLongClickable.()Z", this, null);
		}
		[Register("setLongClickable", "(Z)V", "GetSetLongClickable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLongClickable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int MaxTextLength
	{
		[Register("getMaxTextLength", "()I", "GetGetMaxTextLengthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxTextLength.()I", this, null);
		}
		[Register("setMaxTextLength", "(I)V", "GetSetMaxTextLength_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxTextLength.(I)V", this, ptr);
		}
	}

	public unsafe virtual long MinDurationBetweenContentChangesMillis
	{
		[Register("getMinDurationBetweenContentChangesMillis", "()J", "GetGetMinDurationBetweenContentChangesMillisHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getMinDurationBetweenContentChangesMillis.()J", this, null);
		}
		[Register("setMinDurationBetweenContentChangesMillis", "(J)V", "GetSetMinDurationBetweenContentChangesMillis_JHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinDurationBetweenContentChangesMillis.(J)V", this, ptr);
		}
	}

	public unsafe virtual int MovementGranularities
	{
		[Register("getMovementGranularities", "()I", "GetGetMovementGranularitiesHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMovementGranularities.()I", this, null);
		}
		[Register("setMovementGranularities", "(I)V", "GetSetMovementGranularities_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMovementGranularities.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool MultiLine
	{
		[Register("isMultiLine", "()Z", "GetIsMultiLineHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMultiLine.()Z", this, null);
		}
		[Register("setMultiLine", "(Z)V", "GetSetMultiLine_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMultiLine.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? PackageNameFormatted
	{
		[Register("getPackageName", "()Ljava/lang/CharSequence;", "GetGetPackageNameHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPackageName.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPackageName", "(Ljava/lang/CharSequence;)V", "GetSetPackageName_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPackageName.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? PackageName
	{
		get
		{
			if (PackageNameFormatted != null)
			{
				return PackageNameFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(PackageNameFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual ICharSequence? PaneTitleFormatted
	{
		[Register("getPaneTitle", "()Ljava/lang/CharSequence;", "GetGetPaneTitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPaneTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPaneTitle", "(Ljava/lang/CharSequence;)V", "GetSetPaneTitle_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPaneTitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? PaneTitle
	{
		get
		{
			if (PaneTitleFormatted != null)
			{
				return PaneTitleFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(PaneTitleFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual AccessibilityNodeInfoCompat? Parent
	{
		[Register("getParent", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetParentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParent.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool Password
	{
		[Register("isPassword", "()Z", "GetIsPasswordHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPassword.()Z", this, null);
		}
		[Register("setPassword", "(Z)V", "GetSetPassword_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPassword.(Z)V", this, ptr);
		}
	}

	public unsafe virtual RangeInfoCompat? RangeInfo
	{
		[Register("getRangeInfo", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$RangeInfoCompat;", "GetGetRangeInfoHandler")]
		get
		{
			return Java.Lang.Object.GetObject<RangeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRangeInfo.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$RangeInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setRangeInfo", "(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$RangeInfoCompat;)V", "GetSetRangeInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_RangeInfoCompat_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRangeInfo.(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$RangeInfoCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ICharSequence? RoleDescriptionFormatted
	{
		[Register("getRoleDescription", "()Ljava/lang/CharSequence;", "GetGetRoleDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRoleDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setRoleDescription", "(Ljava/lang/CharSequence;)V", "GetSetRoleDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRoleDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? RoleDescription
	{
		get
		{
			if (RoleDescriptionFormatted != null)
			{
				return RoleDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(RoleDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual bool ScreenReaderFocusable
	{
		[Register("isScreenReaderFocusable", "()Z", "GetIsScreenReaderFocusableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isScreenReaderFocusable.()Z", this, null);
		}
		[Register("setScreenReaderFocusable", "(Z)V", "GetSetScreenReaderFocusable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScreenReaderFocusable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool Scrollable
	{
		[Register("isScrollable", "()Z", "GetIsScrollableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isScrollable.()Z", this, null);
		}
		[Register("setScrollable", "(Z)V", "GetSetScrollable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScrollable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool Selected
	{
		[Register("isSelected", "()Z", "GetIsSelectedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSelected.()Z", this, null);
		}
		[Register("setSelected", "(Z)V", "GetSetSelected_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSelected.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool ShowingHintText
	{
		[Register("isShowingHintText", "()Z", "GetIsShowingHintTextHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShowingHintText.()Z", this, null);
		}
		[Register("setShowingHintText", "(Z)V", "GetSetShowingHintText_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShowingHintText.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? StateDescriptionFormatted
	{
		[Register("getStateDescription", "()Ljava/lang/CharSequence;", "GetGetStateDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStateDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStateDescription", "(Ljava/lang/CharSequence;)V", "GetSetStateDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStateDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? StateDescription
	{
		get
		{
			if (StateDescriptionFormatted != null)
			{
				return StateDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(StateDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual ICharSequence? TextFormatted
	{
		[Register("getText", "()Ljava/lang/CharSequence;", "GetGetTextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setText", "(Ljava/lang/CharSequence;)V", "GetSetText_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setText.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? Text
	{
		get
		{
			if (TextFormatted != null)
			{
				return TextFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(TextFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual bool TextEntryKey
	{
		[Register("isTextEntryKey", "()Z", "GetIsTextEntryKeyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTextEntryKey.()Z", this, null);
		}
		[Register("setTextEntryKey", "(Z)V", "GetSetTextEntryKey_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTextEntryKey.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool TextSelectable
	{
		[Register("isTextSelectable", "()Z", "GetIsTextSelectableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTextSelectable.()Z", this, null);
		}
		[Register("setTextSelectable", "(Z)V", "GetSetTextSelectable_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTextSelectable.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int TextSelectionEnd
	{
		[Register("getTextSelectionEnd", "()I", "GetGetTextSelectionEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTextSelectionEnd.()I", this, null);
		}
	}

	public unsafe virtual int TextSelectionStart
	{
		[Register("getTextSelectionStart", "()I", "GetGetTextSelectionStartHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTextSelectionStart.()I", this, null);
		}
	}

	public unsafe virtual ICharSequence? TooltipTextFormatted
	{
		[Register("getTooltipText", "()Ljava/lang/CharSequence;", "GetGetTooltipTextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTooltipText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTooltipText", "(Ljava/lang/CharSequence;)V", "GetSetTooltipText_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTooltipText.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? TooltipText
	{
		get
		{
			if (TooltipTextFormatted != null)
			{
				return TooltipTextFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(TooltipTextFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual TouchDelegateInfoCompat? TouchDelegateInfo
	{
		[Register("getTouchDelegateInfo", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$TouchDelegateInfoCompat;", "GetGetTouchDelegateInfoHandler")]
		get
		{
			return Java.Lang.Object.GetObject<TouchDelegateInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTouchDelegateInfo.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$TouchDelegateInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTouchDelegateInfo", "(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$TouchDelegateInfoCompat;)V", "GetSetTouchDelegateInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_TouchDelegateInfoCompat_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTouchDelegateInfo.(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$TouchDelegateInfoCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual AccessibilityNodeInfoCompat? TraversalAfter
	{
		[Register("getTraversalAfter", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetTraversalAfterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTraversalAfter.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual AccessibilityNodeInfoCompat? TraversalBefore
	{
		[Register("getTraversalBefore", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetTraversalBeforeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTraversalBefore.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual string? UniqueId
	{
		[Register("getUniqueId", "()Ljava/lang/String;", "GetGetUniqueIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getUniqueId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setUniqueId", "(Ljava/lang/String;)V", "GetSetUniqueId_Ljava_lang_String_Handler")]
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setUniqueId.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe virtual string? ViewIdResourceName
	{
		[Register("getViewIdResourceName", "()Ljava/lang/String;", "GetGetViewIdResourceNameHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getViewIdResourceName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setViewIdResourceName", "(Ljava/lang/String;)V", "GetSetViewIdResourceName_Ljava_lang_String_Handler")]
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setViewIdResourceName.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe virtual bool VisibleToUser
	{
		[Register("isVisibleToUser", "()Z", "GetIsVisibleToUserHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isVisibleToUser.()Z", this, null);
		}
		[Register("setVisibleToUser", "(Z)V", "GetSetVisibleToUser_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibleToUser.(Z)V", this, ptr);
		}
	}

	public unsafe virtual AccessibilityWindowInfoCompat? Window
	{
		[Register("getWindow", "()Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", "GetGetWindowHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AccessibilityWindowInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWindow.()Landroidx/core/view/accessibility/AccessibilityWindowInfoCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int WindowId
	{
		[Register("getWindowId", "()I", "GetGetWindowIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getWindowId.()I", this, null);
		}
	}

	protected AccessibilityNodeInfoCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/Object;)V", "")]
	[Obsolete("deprecated")]
	public unsafe AccessibilityNodeInfoCompat(Java.Lang.Object? info)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(info);
		}
	}

	private static Delegate GetIsAccessibilityDataSensitiveHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAccessibilityDataSensitive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAccessibilityDataSensitive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AccessibilityDataSensitive ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetAccessibilityDataSensitive_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetAccessibilityDataSensitive_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAccessibilityDataSensitive_Z(nint jnienv, nint native__this, sbyte native_accessibilityDataSensitive)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool accessibilityDataSensitive = native_accessibilityDataSensitive != 0;
			accessibilityNodeInfoCompat.AccessibilityDataSensitive = accessibilityDataSensitive;
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

	private static Delegate GetIsAccessibilityFocusedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAccessibilityFocused);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAccessibilityFocused(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AccessibilityFocused ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetAccessibilityFocused_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetAccessibilityFocused_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAccessibilityFocused_Z(nint jnienv, nint native__this, sbyte native_focused)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool accessibilityFocused = native_focused != 0;
			accessibilityNodeInfoCompat.AccessibilityFocused = accessibilityFocused;
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

	private static Delegate GetGetActionListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetActionList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetActionList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<AccessibilityActionCompat>.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActionList);
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

	[Obsolete]
	private static Delegate GetGetActionsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetActions);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetActions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Actions;
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

	private static Delegate GetGetAvailableExtraDataHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAvailableExtraData);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAvailableExtraData(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AvailableExtraData);
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

	private static Delegate GetSetAvailableExtraData_Ljava_util_List_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetAvailableExtraData_Ljava_util_List_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAvailableExtraData_Ljava_util_List_(nint jnienv, nint native__this, nint native_extraDataKeys)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> availableExtraData = JavaList<string>.FromJniHandle(native_extraDataKeys, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.AvailableExtraData = availableExtraData;
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

	private static Delegate GetIsCheckableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCheckable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCheckable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Checkable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetCheckable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCheckable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCheckable_Z(nint jnienv, nint native__this, sbyte native_checkable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool checkable = native_checkable != 0;
			accessibilityNodeInfoCompat.Checkable = checkable;
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

	private static Delegate GetIsCheckedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsChecked);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsChecked(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Checked ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetChecked_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetChecked_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetChecked_Z(nint jnienv, nint native__this, sbyte native__checked)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native__checked != 0;
			accessibilityNodeInfoCompat.Checked = flag;
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

	private static Delegate GetGetChildCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetChildCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetChildCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChildCount;
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

	private static Delegate GetGetClassNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetClassName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetClassName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClassNameFormatted);
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

	private static Delegate GetSetClassName_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetClassName_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetClassName_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_className)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence classNameFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_className, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.ClassNameFormatted = classNameFormatted;
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

	private static Delegate GetIsClickableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsClickable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsClickable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clickable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetClickable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetClickable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetClickable_Z(nint jnienv, nint native__this, sbyte native_clickable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool clickable = native_clickable != 0;
			accessibilityNodeInfoCompat.Clickable = clickable;
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

	private static Delegate GetGetCollectionInfoHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCollectionInfo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCollectionInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CollectionInfo);
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

	private static Delegate GetGetCollectionItemInfoHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCollectionItemInfo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCollectionItemInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CollectionItemInfo);
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

	private static Delegate GetGetContainerTitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContainerTitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContainerTitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContainerTitleFormatted);
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

	private static Delegate GetSetContainerTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetContainerTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContainerTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_containerTitle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence containerTitleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_containerTitle, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.ContainerTitleFormatted = containerTitleFormatted;
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

	private static Delegate GetGetContentDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContentDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentDescriptionFormatted);
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

	private static Delegate GetSetContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_contentDescription)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence contentDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_contentDescription, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.ContentDescriptionFormatted = contentDescriptionFormatted;
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

	private static Delegate GetIsContentInvalidHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsContentInvalid);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsContentInvalid(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentInvalid ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetContentInvalid_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetContentInvalid_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentInvalid_Z(nint jnienv, nint native__this, sbyte native_contentInvalid)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool contentInvalid = native_contentInvalid != 0;
			accessibilityNodeInfoCompat.ContentInvalid = contentInvalid;
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

	private static Delegate GetIsContextClickableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsContextClickable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsContextClickable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContextClickable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetContextClickable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetContextClickable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContextClickable_Z(nint jnienv, nint native__this, sbyte native_contextClickable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool contextClickable = native_contextClickable != 0;
			accessibilityNodeInfoCompat.ContextClickable = contextClickable;
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

	private static Delegate GetIsDismissableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDismissable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDismissable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dismissable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetDismissable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDismissable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDismissable_Z(nint jnienv, nint native__this, sbyte native_dismissable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool dismissable = native_dismissable != 0;
			accessibilityNodeInfoCompat.Dismissable = dismissable;
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

	private static Delegate GetGetDrawingOrderHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDrawingOrder);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDrawingOrder(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawingOrder;
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

	private static Delegate GetSetDrawingOrder_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDrawingOrder_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawingOrder_I(nint jnienv, nint native__this, int drawingOrderInParent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawingOrder = drawingOrderInParent;
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

	private static Delegate GetIsEditableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsEditable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEditable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Editable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetEditable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetEditable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEditable_Z(nint jnienv, nint native__this, sbyte native_editable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool editable = native_editable != 0;
			accessibilityNodeInfoCompat.Editable = editable;
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
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Enabled ? ((sbyte)1) : ((sbyte)0);
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
	private static void n_SetEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enabled = native_enabled != 0;
			accessibilityNodeInfoCompat.Enabled = enabled;
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

	private static Delegate GetGetErrorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetError);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetError(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ErrorFormatted);
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

	private static Delegate GetSetError_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetError_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetError_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_error)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence errorFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_error, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.ErrorFormatted = errorFormatted;
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

	private static Delegate GetGetExtraRenderingInfoHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetExtraRenderingInfo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExtraRenderingInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExtraRenderingInfo);
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

	private static Delegate GetGetExtrasHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetExtras);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExtras(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Extras);
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

	private static Delegate GetIsFieldRequiredHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFieldRequired);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFieldRequired(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FieldRequired ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetFieldRequired_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetFieldRequired_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFieldRequired_Z(nint jnienv, nint native__this, sbyte native_required)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool fieldRequired = native_required != 0;
			accessibilityNodeInfoCompat.FieldRequired = fieldRequired;
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

	private static Delegate GetIsFocusableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFocusable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFocusable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Focusable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetFocusable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetFocusable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFocusable_Z(nint jnienv, nint native__this, sbyte native_focusable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool focusable = native_focusable != 0;
			accessibilityNodeInfoCompat.Focusable = focusable;
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

	private static Delegate GetIsFocusedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFocused);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFocused(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Focused ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetFocused_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetFocused_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFocused_Z(nint jnienv, nint native__this, sbyte native_focused)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool focused = native_focused != 0;
			accessibilityNodeInfoCompat.Focused = focused;
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

	private static Delegate GetIsGranularScrollingSupportedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsGranularScrollingSupported);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsGranularScrollingSupported(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GranularScrollingSupported ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetGranularScrollingSupported_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetGranularScrollingSupported_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGranularScrollingSupported_Z(nint jnienv, nint native__this, sbyte native_granularScrollingSupported)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool granularScrollingSupported = native_granularScrollingSupported != 0;
			accessibilityNodeInfoCompat.GranularScrollingSupported = granularScrollingSupported;
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

	private static Delegate GetHasRequestInitialAccessibilityFocusHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasRequestInitialAccessibilityFocus);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasRequestInitialAccessibilityFocus(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasRequestInitialAccessibilityFocus ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsHeadingHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHeading);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHeading(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Heading ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetHeading_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHeading_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHeading_Z(nint jnienv, nint native__this, sbyte native_isHeading)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool heading = native_isHeading != 0;
			accessibilityNodeInfoCompat.Heading = heading;
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

	private static Delegate GetGetHintTextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHintText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHintText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HintTextFormatted);
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

	private static Delegate GetSetHintText_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHintText_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHintText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_hintText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence hintTextFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_hintText, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.HintTextFormatted = hintTextFormatted;
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

	private static Delegate GetIsImportantForAccessibilityHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsImportantForAccessibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsImportantForAccessibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImportantForAccessibility ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetImportantForAccessibility_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetImportantForAccessibility_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetImportantForAccessibility_Z(nint jnienv, nint native__this, sbyte native_important)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool importantForAccessibility = native_important != 0;
			accessibilityNodeInfoCompat.ImportantForAccessibility = importantForAccessibility;
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

	[Obsolete]
	private static Delegate GetGetInfoHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetInfo);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Info);
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

	private static Delegate GetGetInputTypeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetInputType);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetInputType(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputType;
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

	private static Delegate GetSetInputType_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetInputType_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInputType_I(nint jnienv, nint native__this, int inputType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputType = inputType;
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

	private static Delegate GetGetLabelForHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLabelFor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLabelFor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LabelFor);
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

	private static Delegate GetGetLabeledByHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLabeledBy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLabeledBy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LabeledBy);
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

	private static Delegate GetGetLiveRegionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLiveRegion);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLiveRegion(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LiveRegion;
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

	private static Delegate GetSetLiveRegion_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLiveRegion_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLiveRegion_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LiveRegion = mode;
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

	private static Delegate GetIsLongClickableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsLongClickable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLongClickable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LongClickable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetLongClickable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetLongClickable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLongClickable_Z(nint jnienv, nint native__this, sbyte native_longClickable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool longClickable = native_longClickable != 0;
			accessibilityNodeInfoCompat.LongClickable = longClickable;
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

	private static Delegate GetGetMaxTextLengthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxTextLength);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxTextLength(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxTextLength;
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

	private static Delegate GetSetMaxTextLength_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxTextLength_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxTextLength_I(nint jnienv, nint native__this, int max)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxTextLength = max;
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

	private static Delegate GetGetMinDurationBetweenContentChangesMillisHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetMinDurationBetweenContentChangesMillis);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetMinDurationBetweenContentChangesMillis(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinDurationBetweenContentChangesMillis;
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

	private static Delegate GetSetMinDurationBetweenContentChangesMillis_JHandler()
	{
		return new global::_JniMarshal_PPJ_V(n_SetMinDurationBetweenContentChangesMillis_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMinDurationBetweenContentChangesMillis_J(nint jnienv, nint native__this, long duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinDurationBetweenContentChangesMillis = duration;
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

	private static Delegate GetGetMovementGranularitiesHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMovementGranularities);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMovementGranularities(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MovementGranularities;
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

	private static Delegate GetSetMovementGranularities_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMovementGranularities_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMovementGranularities_I(nint jnienv, nint native__this, int granularities)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MovementGranularities = granularities;
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

	private static Delegate GetIsMultiLineHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsMultiLine);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsMultiLine(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MultiLine ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetMultiLine_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetMultiLine_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMultiLine_Z(nint jnienv, nint native__this, sbyte native_multiLine)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool multiLine = native_multiLine != 0;
			accessibilityNodeInfoCompat.MultiLine = multiLine;
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

	private static Delegate GetGetPackageNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPackageName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPackageName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PackageNameFormatted);
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

	private static Delegate GetSetPackageName_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPackageName_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPackageName_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_packageName)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence packageNameFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_packageName, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.PackageNameFormatted = packageNameFormatted;
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

	private static Delegate GetGetPaneTitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPaneTitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPaneTitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaneTitleFormatted);
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

	private static Delegate GetSetPaneTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPaneTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPaneTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_paneTitle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence paneTitleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_paneTitle, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.PaneTitleFormatted = paneTitleFormatted;
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

	private static Delegate GetGetParentHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetParent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
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

	private static Delegate GetIsPasswordHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsPassword);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsPassword(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Password ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetPassword_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetPassword_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPassword_Z(nint jnienv, nint native__this, sbyte native_password)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool password = native_password != 0;
			accessibilityNodeInfoCompat.Password = password;
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

	private static Delegate GetGetRangeInfoHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRangeInfo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRangeInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RangeInfo);
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

	private static Delegate GetSetRangeInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_RangeInfoCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRangeInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_RangeInfoCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRangeInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_RangeInfoCompat_(nint jnienv, nint native__this, nint native_rangeInfo)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RangeInfoCompat rangeInfo = Java.Lang.Object.GetObject<RangeInfoCompat>(native_rangeInfo, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.RangeInfo = rangeInfo;
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

	private static Delegate GetGetRoleDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRoleDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRoleDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RoleDescriptionFormatted);
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

	private static Delegate GetSetRoleDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRoleDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRoleDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_roleDescription)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence roleDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_roleDescription, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.RoleDescriptionFormatted = roleDescriptionFormatted;
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

	private static Delegate GetIsScreenReaderFocusableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsScreenReaderFocusable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsScreenReaderFocusable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScreenReaderFocusable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetScreenReaderFocusable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetScreenReaderFocusable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScreenReaderFocusable_Z(nint jnienv, nint native__this, sbyte native_screenReaderFocusable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool screenReaderFocusable = native_screenReaderFocusable != 0;
			accessibilityNodeInfoCompat.ScreenReaderFocusable = screenReaderFocusable;
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

	private static Delegate GetIsScrollableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsScrollable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsScrollable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scrollable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetScrollable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetScrollable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScrollable_Z(nint jnienv, nint native__this, sbyte native_scrollable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool scrollable = native_scrollable != 0;
			accessibilityNodeInfoCompat.Scrollable = scrollable;
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

	private static Delegate GetIsSelectedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSelected);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSelected(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Selected ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetSelected_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSelected_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSelected_Z(nint jnienv, nint native__this, sbyte native_selected)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool selected = native_selected != 0;
			accessibilityNodeInfoCompat.Selected = selected;
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

	private static Delegate GetIsShowingHintTextHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsShowingHintText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShowingHintText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowingHintText ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetShowingHintText_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShowingHintText_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShowingHintText_Z(nint jnienv, nint native__this, sbyte native_showingHintText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool showingHintText = native_showingHintText != 0;
			accessibilityNodeInfoCompat.ShowingHintText = showingHintText;
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

	private static Delegate GetGetStateDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStateDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStateDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StateDescriptionFormatted);
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

	private static Delegate GetSetStateDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStateDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStateDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_stateDescription)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence stateDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_stateDescription, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.StateDescriptionFormatted = stateDescriptionFormatted;
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

	private static Delegate GetGetTextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextFormatted);
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

	private static Delegate GetSetText_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetText_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence textFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.TextFormatted = textFormatted;
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

	private static Delegate GetIsTextEntryKeyHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsTextEntryKey);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTextEntryKey(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextEntryKey ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetTextEntryKey_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetTextEntryKey_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextEntryKey_Z(nint jnienv, nint native__this, sbyte native_isTextEntryKey)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool textEntryKey = native_isTextEntryKey != 0;
			accessibilityNodeInfoCompat.TextEntryKey = textEntryKey;
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

	private static Delegate GetIsTextSelectableHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsTextSelectable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTextSelectable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextSelectable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetTextSelectable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetTextSelectable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextSelectable_Z(nint jnienv, nint native__this, sbyte native_selectableText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool textSelectable = native_selectableText != 0;
			accessibilityNodeInfoCompat.TextSelectable = textSelectable;
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

	private static Delegate GetGetTextSelectionEndHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTextSelectionEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTextSelectionEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextSelectionEnd;
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

	private static Delegate GetGetTextSelectionStartHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTextSelectionStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTextSelectionStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextSelectionStart;
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

	private static Delegate GetGetTooltipTextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTooltipText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTooltipText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TooltipTextFormatted);
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

	private static Delegate GetSetTooltipText_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTooltipText_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTooltipText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_tooltipText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence tooltipTextFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_tooltipText, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.TooltipTextFormatted = tooltipTextFormatted;
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

	private static Delegate GetGetTouchDelegateInfoHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTouchDelegateInfo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTouchDelegateInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TouchDelegateInfo);
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

	private static Delegate GetSetTouchDelegateInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_TouchDelegateInfoCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTouchDelegateInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_TouchDelegateInfoCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTouchDelegateInfo_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_TouchDelegateInfoCompat_(nint jnienv, nint native__this, nint native_delegatedInfo)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TouchDelegateInfoCompat touchDelegateInfo = Java.Lang.Object.GetObject<TouchDelegateInfoCompat>(native_delegatedInfo, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.TouchDelegateInfo = touchDelegateInfo;
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

	private static Delegate GetGetTraversalAfterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTraversalAfter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTraversalAfter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TraversalAfter);
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

	private static Delegate GetGetTraversalBeforeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTraversalBefore);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTraversalBefore(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TraversalBefore);
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

	private static Delegate GetGetUniqueIdHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetUniqueId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetUniqueId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UniqueId);
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

	private static Delegate GetSetUniqueId_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetUniqueId_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUniqueId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_uniqueId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uniqueId = JNIEnv.GetString(native_uniqueId, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.UniqueId = uniqueId;
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

	private static Delegate GetGetViewIdResourceNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetViewIdResourceName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViewIdResourceName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewIdResourceName);
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

	private static Delegate GetSetViewIdResourceName_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetViewIdResourceName_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetViewIdResourceName_Ljava_lang_String_(nint jnienv, nint native__this, nint native_viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string viewIdResourceName = JNIEnv.GetString(native_viewId, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.ViewIdResourceName = viewIdResourceName;
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

	private static Delegate GetIsVisibleToUserHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsVisibleToUser);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsVisibleToUser(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VisibleToUser ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetVisibleToUser_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetVisibleToUser_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVisibleToUser_Z(nint jnienv, nint native__this, sbyte native_visibleToUser)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool visibleToUser = native_visibleToUser != 0;
			accessibilityNodeInfoCompat.VisibleToUser = visibleToUser;
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

	private static Delegate GetGetWindowHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetWindow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetWindow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Window);
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

	private static Delegate GetGetWindowIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetWindowId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetWindowId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WindowId;
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

	private static Delegate GetAddAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat_(nint jnienv, nint native__this, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessibilityActionCompat action = Java.Lang.Object.GetObject<AccessibilityActionCompat>(native_action, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.AddAction(action);
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

	[Register("addAction", "(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;)V", "GetAddAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat_Handler")]
	public unsafe virtual void AddAction(AccessibilityActionCompat? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(action?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addAction.(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	private static Delegate GetAddAction_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_AddAction_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddAction_I(nint jnienv, nint native__this, int action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddAction(action);
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

	[Register("addAction", "(I)V", "GetAddAction_IHandler")]
	public unsafe virtual void AddAction(int action)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(action);
		_members.InstanceMethods.InvokeVirtualVoidMethod("addAction.(I)V", this, ptr);
	}

	private static Delegate GetAddChild_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddChild_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddChild_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View child = Java.Lang.Object.GetObject<Android.Views.View>(native_child, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.AddChild(child);
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

	[Register("addChild", "(Landroid/view/View;)V", "GetAddChild_Landroid_view_View_Handler")]
	public unsafe virtual void AddChild(Android.Views.View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addChild.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetAddChild_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_AddChild_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddChild_Landroid_view_View_I(nint jnienv, nint native__this, nint native_root, int virtualDescendantId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View root = Java.Lang.Object.GetObject<Android.Views.View>(native_root, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.AddChild(root, virtualDescendantId);
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

	[Register("addChild", "(Landroid/view/View;I)V", "GetAddChild_Landroid_view_View_IHandler")]
	public unsafe virtual void AddChild(Android.Views.View? root, int virtualDescendantId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualDescendantId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addChild.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetAddSpansToExtras_Ljava_lang_CharSequence_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_AddSpansToExtras_Ljava_lang_CharSequence_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddSpansToExtras_Ljava_lang_CharSequence_Landroid_view_View_(nint jnienv, nint native__this, nint native_text, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence text = Java.Lang.Object.GetObject<ICharSequence>(native_text, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.AddSpansToExtras(text, view);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("addSpansToExtras", "(Ljava/lang/CharSequence;Landroid/view/View;)V", "GetAddSpansToExtras_Ljava_lang_CharSequence_Landroid_view_View_Handler")]
	public unsafe virtual void AddSpansToExtras(ICharSequence? text, Android.Views.View? view)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addSpansToExtras.(Ljava/lang/CharSequence;Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
			GC.KeepAlive(view);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public void AddSpansToExtras(string? text, Android.Views.View? view)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		AddSpansToExtras(obj, view);
		obj?.Dispose();
	}

	private static Delegate GetCanOpenPopupHandler()
	{
		return new global::_JniMarshal_PP_B(n_CanOpenPopup);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanOpenPopup(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanOpenPopup() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("canOpenPopup", "()Z", "GetCanOpenPopupHandler")]
	public unsafe virtual bool CanOpenPopup()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canOpenPopup.()Z", this, null);
	}

	private static Delegate GetFindAccessibilityNodeInfosByText_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_FindAccessibilityNodeInfosByText_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindAccessibilityNodeInfosByText_Ljava_lang_String_(nint jnienv, nint native__this, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
			return JavaList<AccessibilityNodeInfoCompat>.ToLocalJniHandle(accessibilityNodeInfoCompat.FindAccessibilityNodeInfosByText(text));
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

	[Register("findAccessibilityNodeInfosByText", "(Ljava/lang/String;)Ljava/util/List;", "GetFindAccessibilityNodeInfosByText_Ljava_lang_String_Handler")]
	public unsafe virtual IList<AccessibilityNodeInfoCompat>? FindAccessibilityNodeInfosByText(string? text)
	{
		nint num = JNIEnv.NewString(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList<AccessibilityNodeInfoCompat>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("findAccessibilityNodeInfosByText.(Ljava/lang/String;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetFindAccessibilityNodeInfosByViewId_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_FindAccessibilityNodeInfosByViewId_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindAccessibilityNodeInfosByViewId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_viewId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string viewId = JNIEnv.GetString(native_viewId, JniHandleOwnership.DoNotTransfer);
			return JavaList<AccessibilityNodeInfoCompat>.ToLocalJniHandle(accessibilityNodeInfoCompat.FindAccessibilityNodeInfosByViewId(viewId));
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

	[Register("findAccessibilityNodeInfosByViewId", "(Ljava/lang/String;)Ljava/util/List;", "GetFindAccessibilityNodeInfosByViewId_Ljava_lang_String_Handler")]
	public unsafe virtual IList<AccessibilityNodeInfoCompat>? FindAccessibilityNodeInfosByViewId(string? viewId)
	{
		nint num = JNIEnv.NewString(viewId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList<AccessibilityNodeInfoCompat>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("findAccessibilityNodeInfosByViewId.(Ljava/lang/String;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetFindFocus_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindFocus_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindFocus_I(nint jnienv, nint native__this, int focus)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindFocus(focus));
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

	[Register("findFocus", "(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetFindFocus_IHandler")]
	public unsafe virtual AccessibilityNodeInfoCompat? FindFocus(int focus)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(focus);
		return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("findFocus.(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFocusSearch_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FocusSearch_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FocusSearch_I(nint jnienv, nint native__this, int direction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusSearch(direction));
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

	[Register("focusSearch", "(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetFocusSearch_IHandler")]
	public unsafe virtual AccessibilityNodeInfoCompat? FocusSearch(int direction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(direction);
		return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("focusSearch.(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetGetBoundsInParent_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetBoundsInParent_Landroid_graphics_Rect_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetBoundsInParent_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_outBounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect outBounds = Java.Lang.Object.GetObject<Rect>(native_outBounds, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.GetBoundsInParent(outBounds);
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
	[Register("getBoundsInParent", "(Landroid/graphics/Rect;)V", "GetGetBoundsInParent_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void GetBoundsInParent(Rect? outBounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outBounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getBoundsInParent.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outBounds);
		}
	}

	private static Delegate GetGetBoundsInScreen_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetBoundsInScreen_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetBoundsInScreen_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_outBounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect outBounds = Java.Lang.Object.GetObject<Rect>(native_outBounds, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.GetBoundsInScreen(outBounds);
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

	[Register("getBoundsInScreen", "(Landroid/graphics/Rect;)V", "GetGetBoundsInScreen_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void GetBoundsInScreen(Rect? outBounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outBounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getBoundsInScreen.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outBounds);
		}
	}

	private static Delegate GetGetBoundsInWindow_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetBoundsInWindow_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetBoundsInWindow_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_outBounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect outBounds = Java.Lang.Object.GetObject<Rect>(native_outBounds, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.GetBoundsInWindow(outBounds);
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

	[Register("getBoundsInWindow", "(Landroid/graphics/Rect;)V", "GetGetBoundsInWindow_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void GetBoundsInWindow(Rect? outBounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outBounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getBoundsInWindow.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outBounds);
		}
	}

	private static Delegate GetGetChild_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetChild_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetChild_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetChild(index));
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

	[Register("getChild", "(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetChild_IHandler")]
	public unsafe virtual AccessibilityNodeInfoCompat? GetChild(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChild.(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetChild_IIHandler()
	{
		return new global::_JniMarshal_PPII_L(n_GetChild_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetChild_II(nint jnienv, nint native__this, int index, int prefetchingStrategy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetChild(index, prefetchingStrategy));
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

	[Register("getChild", "(II)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetChild_IIHandler")]
	public unsafe virtual AccessibilityNodeInfoCompat? GetChild(int index, int prefetchingStrategy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(prefetchingStrategy);
		return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChild.(II)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getClickableSpans", "(Ljava/lang/CharSequence;)[Landroid/text/style/ClickableSpan;", "")]
	public unsafe static ClickableSpan[]? GetClickableSpans(ICharSequence? text)
	{
		nint num = CharSequence.ToLocalJniHandle(text);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return (ClickableSpan[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("getClickableSpans.(Ljava/lang/CharSequence;)[Landroid/text/style/ClickableSpan;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(ClickableSpan));
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(text);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	public static ClickableSpan[]? GetClickableSpans(string? text)
	{
		Java.Lang.String obj = ((text == null) ? null : new Java.Lang.String(text));
		ClickableSpan[]? clickableSpans = GetClickableSpans(obj);
		obj?.Dispose();
		return clickableSpans;
	}

	private static Delegate GetGetParent_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetParent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetParent_I(nint jnienv, nint native__this, int prefetchingStrategy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetParent(prefetchingStrategy));
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

	[Register("getParent", "(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "GetGetParent_IHandler")]
	public unsafe virtual AccessibilityNodeInfoCompat? GetParent(int prefetchingStrategy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(prefetchingStrategy);
		return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParent.(I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("obtain", "()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "")]
	public unsafe static AccessibilityNodeInfoCompat? Obtain()
	{
		return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.()Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("obtain", "(Landroid/view/View;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "")]
	public unsafe static AccessibilityNodeInfoCompat? Obtain(Android.Views.View? source)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.(Landroid/view/View;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(source);
		}
	}

	[Register("obtain", "(Landroid/view/View;I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "")]
	public unsafe static AccessibilityNodeInfoCompat? Obtain(Android.Views.View? root, int virtualDescendantId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualDescendantId);
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.(Landroid/view/View;I)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	[Register("obtain", "(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "")]
	public unsafe static AccessibilityNodeInfoCompat? Obtain(AccessibilityNodeInfoCompat? info)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.StaticMethods.InvokeObjectMethod("obtain.(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(info);
		}
	}

	private static Delegate GetPerformAction_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_PerformAction_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformAction_I(nint jnienv, nint native__this, int action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PerformAction(action) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("performAction", "(I)Z", "GetPerformAction_IHandler")]
	public unsafe virtual bool PerformAction(int action)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(action);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("performAction.(I)Z", this, ptr);
	}

	private static Delegate GetPerformAction_ILandroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_PerformAction_ILandroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformAction_ILandroid_os_Bundle_(nint jnienv, nint native__this, int action, nint native_arguments)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle arguments = Java.Lang.Object.GetObject<Bundle>(native_arguments, JniHandleOwnership.DoNotTransfer);
			return accessibilityNodeInfoCompat.PerformAction(action, arguments) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("performAction", "(ILandroid/os/Bundle;)Z", "GetPerformAction_ILandroid_os_Bundle_Handler")]
	public unsafe virtual bool PerformAction(int action, Bundle? arguments)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(action);
			ptr[1] = new JniArgumentValue(arguments?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("performAction.(ILandroid/os/Bundle;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(arguments);
		}
	}

	[Obsolete]
	private static Delegate GetRecycleHandler()
	{
		return new global::_JniMarshal_PP_V(n_Recycle);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Recycle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Recycle();
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
	[Register("recycle", "()V", "GetRecycleHandler")]
	public unsafe virtual void Recycle()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("recycle.()V", this, null);
	}

	private static Delegate GetRefreshHandler()
	{
		return new global::_JniMarshal_PP_B(n_Refresh);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Refresh(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Refresh() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("refresh", "()Z", "GetRefreshHandler")]
	public unsafe virtual bool Refresh()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("refresh.()Z", this, null);
	}

	private static Delegate GetRemoveAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_RemoveAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat_(nint jnienv, nint native__this, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AccessibilityActionCompat action = Java.Lang.Object.GetObject<AccessibilityActionCompat>(native_action, JniHandleOwnership.DoNotTransfer);
			return accessibilityNodeInfoCompat.RemoveAction(action) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("removeAction", "(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;)Z", "GetRemoveAction_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_AccessibilityActionCompat_Handler")]
	public unsafe virtual bool RemoveAction(AccessibilityActionCompat? action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(action?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeAction.(Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	private static Delegate GetRemoveChild_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_RemoveChild_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveChild_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View child = Java.Lang.Object.GetObject<Android.Views.View>(native_child, JniHandleOwnership.DoNotTransfer);
			return accessibilityNodeInfoCompat.RemoveChild(child) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("removeChild", "(Landroid/view/View;)Z", "GetRemoveChild_Landroid_view_View_Handler")]
	public unsafe virtual bool RemoveChild(Android.Views.View? child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeChild.(Landroid/view/View;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetRemoveChild_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_B(n_RemoveChild_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RemoveChild_Landroid_view_View_I(nint jnienv, nint native__this, nint native_root, int virtualDescendantId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View root = Java.Lang.Object.GetObject<Android.Views.View>(native_root, JniHandleOwnership.DoNotTransfer);
			return accessibilityNodeInfoCompat.RemoveChild(root, virtualDescendantId) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("removeChild", "(Landroid/view/View;I)Z", "GetRemoveChild_Landroid_view_View_IHandler")]
	public unsafe virtual bool RemoveChild(Android.Views.View? root, int virtualDescendantId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualDescendantId);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeChild.(Landroid/view/View;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	[Obsolete]
	private static Delegate GetSetBoundsInParent_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBoundsInParent_Landroid_graphics_Rect_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoundsInParent_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_bounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect boundsInParent = Java.Lang.Object.GetObject<Rect>(native_bounds, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetBoundsInParent(boundsInParent);
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
	[Register("setBoundsInParent", "(Landroid/graphics/Rect;)V", "GetSetBoundsInParent_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void SetBoundsInParent(Rect? bounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoundsInParent.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bounds);
		}
	}

	private static Delegate GetSetBoundsInScreen_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBoundsInScreen_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoundsInScreen_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_bounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect boundsInScreen = Java.Lang.Object.GetObject<Rect>(native_bounds, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetBoundsInScreen(boundsInScreen);
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

	[Register("setBoundsInScreen", "(Landroid/graphics/Rect;)V", "GetSetBoundsInScreen_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void SetBoundsInScreen(Rect? bounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoundsInScreen.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bounds);
		}
	}

	private static Delegate GetSetBoundsInWindow_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBoundsInWindow_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBoundsInWindow_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_bounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect boundsInWindow = Java.Lang.Object.GetObject<Rect>(native_bounds, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetBoundsInWindow(boundsInWindow);
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

	[Register("setBoundsInWindow", "(Landroid/graphics/Rect;)V", "GetSetBoundsInWindow_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void SetBoundsInWindow(Rect? bounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBoundsInWindow.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bounds);
		}
	}

	private static Delegate GetSetCanOpenPopup_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCanOpenPopup_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCanOpenPopup_Z(nint jnienv, nint native__this, sbyte native_opensPopup)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool canOpenPopup = native_opensPopup != 0;
			accessibilityNodeInfoCompat.SetCanOpenPopup(canOpenPopup);
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

	[Register("setCanOpenPopup", "(Z)V", "GetSetCanOpenPopup_ZHandler")]
	public unsafe virtual void SetCanOpenPopup(bool opensPopup)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(opensPopup ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCanOpenPopup.(Z)V", this, ptr);
	}

	private static Delegate GetSetCollectionInfo_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCollectionInfo_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCollectionInfo_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_collectionInfo)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object collectionInfo = Java.Lang.Object.GetObject<Java.Lang.Object>(native_collectionInfo, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetCollectionInfo(collectionInfo);
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

	[Register("setCollectionInfo", "(Ljava/lang/Object;)V", "GetSetCollectionInfo_Ljava_lang_Object_Handler")]
	public unsafe virtual void SetCollectionInfo(Java.Lang.Object? collectionInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(collectionInfo?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCollectionInfo.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(collectionInfo);
		}
	}

	private static Delegate GetSetCollectionItemInfo_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCollectionItemInfo_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCollectionItemInfo_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_collectionItemInfo)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object collectionItemInfo = Java.Lang.Object.GetObject<Java.Lang.Object>(native_collectionItemInfo, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetCollectionItemInfo(collectionItemInfo);
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

	[Register("setCollectionItemInfo", "(Ljava/lang/Object;)V", "GetSetCollectionItemInfo_Ljava_lang_Object_Handler")]
	public unsafe virtual void SetCollectionItemInfo(Java.Lang.Object? collectionItemInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(collectionItemInfo?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCollectionItemInfo.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(collectionItemInfo);
		}
	}

	private static Delegate GetSetLabelFor_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLabelFor_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLabelFor_Landroid_view_View_(nint jnienv, nint native__this, nint native_labeled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View labelFor = Java.Lang.Object.GetObject<Android.Views.View>(native_labeled, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetLabelFor(labelFor);
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

	[Register("setLabelFor", "(Landroid/view/View;)V", "GetSetLabelFor_Landroid_view_View_Handler")]
	public unsafe virtual void SetLabelFor(Android.Views.View? labeled)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(labeled?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLabelFor.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(labeled);
		}
	}

	private static Delegate GetSetLabelFor_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetLabelFor_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLabelFor_Landroid_view_View_I(nint jnienv, nint native__this, nint native_root, int virtualDescendantId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View root = Java.Lang.Object.GetObject<Android.Views.View>(native_root, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetLabelFor(root, virtualDescendantId);
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

	[Register("setLabelFor", "(Landroid/view/View;I)V", "GetSetLabelFor_Landroid_view_View_IHandler")]
	public unsafe virtual void SetLabelFor(Android.Views.View? root, int virtualDescendantId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualDescendantId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLabelFor.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetSetLabeledBy_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLabeledBy_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLabeledBy_Landroid_view_View_(nint jnienv, nint native__this, nint native_label)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View labeledBy = Java.Lang.Object.GetObject<Android.Views.View>(native_label, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetLabeledBy(labeledBy);
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

	[Register("setLabeledBy", "(Landroid/view/View;)V", "GetSetLabeledBy_Landroid_view_View_Handler")]
	public unsafe virtual void SetLabeledBy(Android.Views.View? label)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(label?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLabeledBy.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(label);
		}
	}

	private static Delegate GetSetLabeledBy_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetLabeledBy_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLabeledBy_Landroid_view_View_I(nint jnienv, nint native__this, nint native_root, int virtualDescendantId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View root = Java.Lang.Object.GetObject<Android.Views.View>(native_root, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetLabeledBy(root, virtualDescendantId);
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

	[Register("setLabeledBy", "(Landroid/view/View;I)V", "GetSetLabeledBy_Landroid_view_View_IHandler")]
	public unsafe virtual void SetLabeledBy(Android.Views.View? root, int virtualDescendantId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualDescendantId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLabeledBy.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetSetParent_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetParent_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetParent_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View parent = Java.Lang.Object.GetObject<Android.Views.View>(native_parent, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetParent(parent);
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

	[Register("setParent", "(Landroid/view/View;)V", "GetSetParent_Landroid_view_View_Handler")]
	public unsafe virtual void SetParent(Android.Views.View? parent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setParent.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(parent);
		}
	}

	private static Delegate GetSetParent_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetParent_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetParent_Landroid_view_View_I(nint jnienv, nint native__this, nint native_root, int virtualDescendantId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View root = Java.Lang.Object.GetObject<Android.Views.View>(native_root, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetParent(root, virtualDescendantId);
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

	[Register("setParent", "(Landroid/view/View;I)V", "GetSetParent_Landroid_view_View_IHandler")]
	public unsafe virtual void SetParent(Android.Views.View? root, int virtualDescendantId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualDescendantId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setParent.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetSetQueryFromAppProcessEnabled_Landroid_view_View_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_SetQueryFromAppProcessEnabled_Landroid_view_View_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetQueryFromAppProcessEnabled_Landroid_view_View_Z(nint jnienv, nint native__this, nint native_view, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			bool enabled = native_enabled != 0;
			accessibilityNodeInfoCompat.SetQueryFromAppProcessEnabled(view, enabled);
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

	[Register("setQueryFromAppProcessEnabled", "(Landroid/view/View;Z)V", "GetSetQueryFromAppProcessEnabled_Landroid_view_View_ZHandler")]
	public unsafe virtual void SetQueryFromAppProcessEnabled(Android.Views.View? view, bool enabled)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setQueryFromAppProcessEnabled.(Landroid/view/View;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetRequestInitialAccessibilityFocus_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetRequestInitialAccessibilityFocus_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRequestInitialAccessibilityFocus_Z(nint jnienv, nint native__this, sbyte native_requestInitialAccessibilityFocus)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool requestInitialAccessibilityFocus = native_requestInitialAccessibilityFocus != 0;
			accessibilityNodeInfoCompat.SetRequestInitialAccessibilityFocus(requestInitialAccessibilityFocus);
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

	[Register("setRequestInitialAccessibilityFocus", "(Z)V", "GetSetRequestInitialAccessibilityFocus_ZHandler")]
	public unsafe virtual void SetRequestInitialAccessibilityFocus(bool requestInitialAccessibilityFocus)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(requestInitialAccessibilityFocus ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setRequestInitialAccessibilityFocus.(Z)V", this, ptr);
	}

	private static Delegate GetSetSource_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSource_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSource_Landroid_view_View_(nint jnienv, nint native__this, nint native_source)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View source = Java.Lang.Object.GetObject<Android.Views.View>(native_source, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetSource(source);
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

	[Register("setSource", "(Landroid/view/View;)V", "GetSetSource_Landroid_view_View_Handler")]
	public unsafe virtual void SetSource(Android.Views.View? source)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSource.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(source);
		}
	}

	private static Delegate GetSetSource_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetSource_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSource_Landroid_view_View_I(nint jnienv, nint native__this, nint native_root, int virtualDescendantId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View root = Java.Lang.Object.GetObject<Android.Views.View>(native_root, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetSource(root, virtualDescendantId);
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

	[Register("setSource", "(Landroid/view/View;I)V", "GetSetSource_Landroid_view_View_IHandler")]
	public unsafe virtual void SetSource(Android.Views.View? root, int virtualDescendantId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualDescendantId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSource.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetSetTextSelection_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetTextSelection_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextSelection_II(nint jnienv, nint native__this, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTextSelection(start, end);
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

	[Register("setTextSelection", "(II)V", "GetSetTextSelection_IIHandler")]
	public unsafe virtual void SetTextSelection(int start, int end)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(end);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTextSelection.(II)V", this, ptr);
	}

	private static Delegate GetSetTraversalAfter_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTraversalAfter_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTraversalAfter_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View traversalAfter = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetTraversalAfter(traversalAfter);
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

	[Register("setTraversalAfter", "(Landroid/view/View;)V", "GetSetTraversalAfter_Landroid_view_View_Handler")]
	public unsafe virtual void SetTraversalAfter(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTraversalAfter.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetTraversalAfter_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetTraversalAfter_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTraversalAfter_Landroid_view_View_I(nint jnienv, nint native__this, nint native_root, int virtualDescendantId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View root = Java.Lang.Object.GetObject<Android.Views.View>(native_root, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetTraversalAfter(root, virtualDescendantId);
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

	[Register("setTraversalAfter", "(Landroid/view/View;I)V", "GetSetTraversalAfter_Landroid_view_View_IHandler")]
	public unsafe virtual void SetTraversalAfter(Android.Views.View? root, int virtualDescendantId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualDescendantId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTraversalAfter.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetSetTraversalBefore_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTraversalBefore_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTraversalBefore_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View traversalBefore = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetTraversalBefore(traversalBefore);
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

	[Register("setTraversalBefore", "(Landroid/view/View;)V", "GetSetTraversalBefore_Landroid_view_View_Handler")]
	public unsafe virtual void SetTraversalBefore(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTraversalBefore.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetTraversalBefore_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetTraversalBefore_Landroid_view_View_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTraversalBefore_Landroid_view_View_I(nint jnienv, nint native__this, nint native_root, int virtualDescendantId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AccessibilityNodeInfoCompat? accessibilityNodeInfoCompat = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View root = Java.Lang.Object.GetObject<Android.Views.View>(native_root, JniHandleOwnership.DoNotTransfer);
			accessibilityNodeInfoCompat.SetTraversalBefore(root, virtualDescendantId);
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

	[Register("setTraversalBefore", "(Landroid/view/View;I)V", "GetSetTraversalBefore_Landroid_view_View_IHandler")]
	public unsafe virtual void SetTraversalBefore(Android.Views.View? root, int virtualDescendantId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(virtualDescendantId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTraversalBefore.(Landroid/view/View;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetUnwrapHandler()
	{
		return new global::_JniMarshal_PP_L(n_Unwrap);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Unwrap(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Unwrap());
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

	[Register("unwrap", "()Landroid/view/accessibility/AccessibilityNodeInfo;", "GetUnwrapHandler")]
	public unsafe virtual AccessibilityNodeInfo? Unwrap()
	{
		return Java.Lang.Object.GetObject<AccessibilityNodeInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("unwrap.()Landroid/view/accessibility/AccessibilityNodeInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("wrap", "(Landroid/view/accessibility/AccessibilityNodeInfo;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", "")]
	public unsafe static AccessibilityNodeInfoCompat? Wrap(AccessibilityNodeInfo? info)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(_members.StaticMethods.InvokeObjectMethod("wrap.(Landroid/view/accessibility/AccessibilityNodeInfo;)Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(info);
		}
	}
}
