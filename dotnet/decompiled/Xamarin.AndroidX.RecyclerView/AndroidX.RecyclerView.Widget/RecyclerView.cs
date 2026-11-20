using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Accessibility;
using Android.Views.Animations;
using Android.Widget;
using AndroidX.Core.View.Accessibility;
using Java.Interop;
using Java.Lang;

namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/RecyclerView", DoNotGenerateAcw = true)]
public class RecyclerView : ViewGroup, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/recyclerview/widget/RecyclerView$Adapter", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "VH extends androidx.recyclerview.widget.RecyclerView.ViewHolder" })]
	public abstract class Adapter : Java.Lang.Object
	{
		[Register("androidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy", DoNotGenerateAcw = true)]
		public sealed class StateRestorationPolicy : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy", typeof(StateRestorationPolicy));

			[Register("ALLOW")]
			public static StateRestorationPolicy? Allow => Java.Lang.Object.GetObject<StateRestorationPolicy>(_members.StaticFields.GetObjectValue("ALLOW.Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("PREVENT")]
			public static StateRestorationPolicy? Prevent => Java.Lang.Object.GetObject<StateRestorationPolicy>(_members.StaticFields.GetObjectValue("PREVENT.Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("PREVENT_WHEN_EMPTY")]
			public static StateRestorationPolicy? PreventWhenEmpty => Java.Lang.Object.GetObject<StateRestorationPolicy>(_members.StaticFields.GetObjectValue("PREVENT_WHEN_EMPTY.Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

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

			internal StateRestorationPolicy(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;", "")]
			public unsafe static StateRestorationPolicy? ValueOf(string? name)
			{
				nint num = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					return Java.Lang.Object.GetObject<StateRestorationPolicy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}

			[Register("values", "()[Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;", "")]
			public unsafe static StateRestorationPolicy[]? Values()
			{
				return (StateRestorationPolicy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(StateRestorationPolicy));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$Adapter", typeof(Adapter));

		private static Delegate? cb_getItemCount_GetItemCount_I;

		private static Delegate? cb_findRelativeAdapterPositionIn_FindRelativeAdapterPositionIn_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I_I;

		private static Delegate? cb_getItemId_GetItemId_I_J;

		private static Delegate? cb_getItemViewType_GetItemViewType_I_I;

		private static Delegate? cb_onAttachedToRecyclerView_OnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView__V;

		private static Delegate? cb_onBindViewHolder_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I_V;

		private static Delegate? cb_onBindViewHolder_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List__V;

		private static Delegate? cb_onCreateViewHolder_OnCreateViewHolder_Landroid_view_ViewGroup_I_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate? cb_onDetachedFromRecyclerView_OnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView__V;

		private static Delegate? cb_onFailedToRecycleView_OnFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__Z;

		private static Delegate? cb_onViewAttachedToWindow_OnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__V;

		private static Delegate? cb_onViewDetachedFromWindow_OnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__V;

		private static Delegate? cb_onViewRecycled_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__V;

		private static Delegate? cb_registerAdapterDataObserver_RegisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver__V;

		private static Delegate? cb_setStateRestorationPolicy_SetStateRestorationPolicy_Landroidx_recyclerview_widget_RecyclerView_Adapter_StateRestorationPolicy__V;

		private static Delegate? cb_unregisterAdapterDataObserver_UnregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver__V;

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

		public unsafe bool HasObservers
		{
			[Register("hasObservers", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasObservers.()Z", this, null);
			}
		}

		public unsafe bool HasStableIds
		{
			[Register("hasStableIds", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("hasStableIds.()Z", this, null);
			}
			[Register("setHasStableIds", "(Z)V", "GetSetHasStableIds_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHasStableIds.(Z)V", this, ptr);
			}
		}

		public abstract int ItemCount
		{
			[Register("getItemCount", "()I", "GetGetItemCountHandler")]
			get;
		}

		protected Adapter(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Adapter()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
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
				return Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCount;
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

		[Register("bindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "")]
		public unsafe void BindViewHolder(ViewHolder holder, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("bindViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(holder);
			}
		}

		[Register("createViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "")]
		public unsafe Java.Lang.Object CreateViewHolder(ViewGroup parent, int viewType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewType);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createViewHolder.(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(parent);
			}
		}

		private static Delegate GetFindRelativeAdapterPositionIn_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler()
		{
			return new global::_JniMarshal_PPLLI_I(n_FindRelativeAdapterPositionIn_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_FindRelativeAdapterPositionIn_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I(nint jnienv, nint native__this, nint native_adapter, nint native_viewHolder, int localPosition)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Adapter adapter2 = Java.Lang.Object.GetObject<Adapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				return adapter.FindRelativeAdapterPositionIn(adapter2, viewHolder, localPosition);
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

		[Register("findRelativeAdapterPositionIn", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)I", "GetFindRelativeAdapterPositionIn_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
		public unsafe virtual int FindRelativeAdapterPositionIn(Adapter adapter, ViewHolder viewHolder, int localPosition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(adapter?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(localPosition);
				return _members.InstanceMethods.InvokeVirtualInt32Method("findRelativeAdapterPositionIn.(Landroidx/recyclerview/widget/RecyclerView$Adapter;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(adapter);
				GC.KeepAlive(viewHolder);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static long n_GetItemId_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0L;
			}
			try
			{
				return Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemId(position);
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

		[Register("getItemId", "(I)J", "GetGetItemId_IHandler")]
		public unsafe virtual long GetItemId(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeVirtualInt64Method("getItemId.(I)J", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetItemViewType_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemViewType(position);
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

		[Register("getItemViewType", "(I)I", "GetGetItemViewType_IHandler")]
		public unsafe virtual int GetItemViewType(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemViewType.(I)I", this, ptr);
		}

		[Register("getStateRestorationPolicy", "()Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;", "")]
		public unsafe StateRestorationPolicy GetStateRestorationPolicy()
		{
			return Java.Lang.Object.GetObject<StateRestorationPolicy>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getStateRestorationPolicy.()Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("notifyDataSetChanged", "()V", "")]
		public unsafe void NotifyDataSetChanged()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyDataSetChanged.()V", this, null);
		}

		[Register("notifyItemChanged", "(I)V", "")]
		public unsafe void NotifyItemChanged(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemChanged.(I)V", this, ptr);
		}

		[Register("notifyItemChanged", "(ILjava/lang/Object;)V", "")]
		public unsafe void NotifyItemChanged(int position, Java.Lang.Object? payload)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(position);
				ptr[1] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemChanged.(ILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(payload);
			}
		}

		[Register("notifyItemInserted", "(I)V", "")]
		public unsafe void NotifyItemInserted(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemInserted.(I)V", this, ptr);
		}

		[Register("notifyItemMoved", "(II)V", "")]
		public unsafe void NotifyItemMoved(int fromPosition, int toPosition)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fromPosition);
			ptr[1] = new JniArgumentValue(toPosition);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemMoved.(II)V", this, ptr);
		}

		[Register("notifyItemRangeChanged", "(II)V", "")]
		public unsafe void NotifyItemRangeChanged(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRangeChanged.(II)V", this, ptr);
		}

		[Register("notifyItemRangeChanged", "(IILjava/lang/Object;)V", "")]
		public unsafe void NotifyItemRangeChanged(int positionStart, int itemCount, Java.Lang.Object? payload)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(positionStart);
				ptr[1] = new JniArgumentValue(itemCount);
				ptr[2] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRangeChanged.(IILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(payload);
			}
		}

		[Register("notifyItemRangeInserted", "(II)V", "")]
		public unsafe void NotifyItemRangeInserted(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRangeInserted.(II)V", this, ptr);
		}

		[Register("notifyItemRangeRemoved", "(II)V", "")]
		public unsafe void NotifyItemRangeRemoved(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRangeRemoved.(II)V", this, ptr);
		}

		[Register("notifyItemRemoved", "(I)V", "")]
		public unsafe void NotifyItemRemoved(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyItemRemoved.(I)V", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_(nint jnienv, nint native__this, nint native_recyclerView)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				adapter.OnAttachedToRecyclerView(recyclerView);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onAttachedToRecyclerView", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnAttachedToRecyclerView(RecyclerView recyclerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToRecyclerView.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I(nint jnienv, nint native__this, nint native_holder, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder holder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
				adapter.OnBindViewHolder(holder, position);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onBindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
		public abstract void OnBindViewHolder(ViewHolder holder, int position);

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_(nint jnienv, nint native__this, nint native_holder, int position, nint native_payloads)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder holder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
				IList<Java.Lang.Object> payloads = JavaList<Java.Lang.Object>.FromJniHandle(native_payloads, JniHandleOwnership.DoNotTransfer);
				adapter.OnBindViewHolder(holder, position, payloads);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onBindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)V", "GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_Handler")]
		public unsafe virtual void OnBindViewHolder(ViewHolder holder, int position, IList<Java.Lang.Object> payloads)
		{
			nint num = JavaList<Java.Lang.Object>.ToLocalJniHandle(payloads);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onBindViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(holder);
				GC.KeepAlive(payloads);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_OnCreateViewHolder_Landroid_view_ViewGroup_I(nint jnienv, nint native__this, nint native_parent, int viewType)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(adapter.OnCreateViewHolder(parent, viewType));
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

		[Register("onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler")]
		public abstract ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType);

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_(nint jnienv, nint native__this, nint native_recyclerView)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				adapter.OnDetachedFromRecyclerView(recyclerView);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onDetachedFromRecyclerView", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnDetachedFromRecyclerView(RecyclerView recyclerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromRecyclerView.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_holder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object holder = Java.Lang.Object.GetObject<Java.Lang.Object>(native_holder, JniHandleOwnership.DoNotTransfer);
				return adapter.OnFailedToRecycleView(holder) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onFailedToRecycleView", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", "GetOnFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual bool OnFailedToRecycleView(Java.Lang.Object holder)
		{
			nint num = JNIEnv.ToLocalJniHandle(holder);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onFailedToRecycleView.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(holder);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_holder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object holder = Java.Lang.Object.GetObject<Java.Lang.Object>(native_holder, JniHandleOwnership.DoNotTransfer);
				adapter.OnViewAttachedToWindow(holder);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onViewAttachedToWindow", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnViewAttachedToWindow(Java.Lang.Object holder)
		{
			nint num = JNIEnv.ToLocalJniHandle(holder);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onViewAttachedToWindow.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(holder);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_holder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object holder = Java.Lang.Object.GetObject<Java.Lang.Object>(native_holder, JniHandleOwnership.DoNotTransfer);
				adapter.OnViewDetachedFromWindow(holder);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onViewDetachedFromWindow", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnViewDetachedFromWindow(Java.Lang.Object holder)
		{
			nint num = JNIEnv.ToLocalJniHandle(holder);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onViewDetachedFromWindow.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(holder);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_holder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object holder = Java.Lang.Object.GetObject<Java.Lang.Object>(native_holder, JniHandleOwnership.DoNotTransfer);
				adapter.OnViewRecycled(holder);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onViewRecycled", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnViewRecycled(Java.Lang.Object holder)
		{
			nint num = JNIEnv.ToLocalJniHandle(holder);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onViewRecycled.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(holder);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RegisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_(nint jnienv, nint native__this, nint native_observer)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AdapterDataObserver observer = Java.Lang.Object.GetObject<AdapterDataObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
				adapter.RegisterAdapterDataObserver(observer);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("registerAdapterDataObserver", "(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V", "GetRegisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_Handler")]
		public unsafe virtual void RegisterAdapterDataObserver(AdapterDataObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("registerAdapterDataObserver.(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		private static Delegate GetSetStateRestorationPolicy_Landroidx_recyclerview_widget_RecyclerView_Adapter_StateRestorationPolicy_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_SetStateRestorationPolicy_Landroidx_recyclerview_widget_RecyclerView_Adapter_StateRestorationPolicy_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetStateRestorationPolicy_Landroidx_recyclerview_widget_RecyclerView_Adapter_StateRestorationPolicy_(nint jnienv, nint native__this, nint native_strategy)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				StateRestorationPolicy stateRestorationPolicy = Java.Lang.Object.GetObject<StateRestorationPolicy>(native_strategy, JniHandleOwnership.DoNotTransfer);
				adapter.SetStateRestorationPolicy(stateRestorationPolicy);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("setStateRestorationPolicy", "(Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;)V", "GetSetStateRestorationPolicy_Landroidx_recyclerview_widget_RecyclerView_Adapter_StateRestorationPolicy_Handler")]
		public unsafe virtual void SetStateRestorationPolicy(StateRestorationPolicy strategy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(strategy?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStateRestorationPolicy.(Landroidx/recyclerview/widget/RecyclerView$Adapter$StateRestorationPolicy;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(strategy);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_UnregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_(nint jnienv, nint native__this, nint native_observer)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Adapter? adapter = Java.Lang.Object.GetObject<Adapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AdapterDataObserver observer = Java.Lang.Object.GetObject<AdapterDataObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
				adapter.UnregisterAdapterDataObserver(observer);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("unregisterAdapterDataObserver", "(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V", "GetUnregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_Handler")]
		public unsafe virtual void UnregisterAdapterDataObserver(AdapterDataObserver observer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterAdapterDataObserver.(Landroidx/recyclerview/widget/RecyclerView$AdapterDataObserver;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(observer);
			}
		}

		[UnmanagedCallersOnly]
		private static int n_GetItemCount_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_GetItemCount(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static long n_GetItemId_I_mm_wrapper(nint jnienv, nint native__this, int position)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_GetItemId_I(jnienv, native__this, position);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0L;
			}
		}

		[UnmanagedCallersOnly]
		private static int n_GetItemViewType_I_mm_wrapper(nint jnienv, nint native__this, int position)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_GetItemViewType_I(jnienv, native__this, position);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView__mm_wrapper(nint jnienv, nint native__this, nint native_recyclerView)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_(jnienv, native__this, native_recyclerView);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I_mm_wrapper(nint jnienv, nint native__this, nint native_holder, int position)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I(jnienv, native__this, native_holder, position);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List__mm_wrapper(nint jnienv, nint native__this, nint native_holder, int position, nint native_payloads)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_(jnienv, native__this, native_holder, position, native_payloads);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static nint n_OnCreateViewHolder_Landroid_view_ViewGroup_I_mm_wrapper(nint jnienv, nint native__this, nint native_parent, int viewType)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnCreateViewHolder_Landroid_view_ViewGroup_I(jnienv, native__this, native_parent, viewType);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView__mm_wrapper(nint jnienv, nint native__this, nint native_recyclerView)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_(jnienv, native__this, native_recyclerView);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_OnFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__mm_wrapper(nint jnienv, nint native__this, nint native_holder)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnFailedToRecycleView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(jnienv, native__this, native_holder);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__mm_wrapper(nint jnienv, nint native__this, nint native_holder)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnViewAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(jnienv, native__this, native_holder);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__mm_wrapper(nint jnienv, nint native__this, nint native_holder)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnViewDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(jnienv, native__this, native_holder);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__mm_wrapper(nint jnienv, nint native__this, nint native_holder)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(jnienv, native__this, native_holder);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_RegisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver__mm_wrapper(nint jnienv, nint native__this, nint native_observer)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_RegisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_(jnienv, native__this, native_observer);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_UnregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver__mm_wrapper(nint jnienv, nint native__this, nint native_observer)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_UnregisterAdapterDataObserver_Landroidx_recyclerview_widget_RecyclerView_AdapterDataObserver_(jnienv, native__this, native_observer);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$Adapter", DoNotGenerateAcw = true)]
	internal class AdapterInvoker : Adapter
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$Adapter", typeof(AdapterInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override int ItemCount
		{
			[Register("getItemCount", "()I", "GetGetItemCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getItemCount.()I", this, null);
			}
		}

		public AdapterInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onBindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", "GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
		public unsafe override void OnBindViewHolder(ViewHolder holder, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onBindViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(holder);
			}
		}

		[Register("onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler")]
		public unsafe override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewType);
				return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeAbstractObjectMethod("onCreateViewHolder.(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(parent);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$AdapterDataObserver", DoNotGenerateAcw = true)]
	public abstract class AdapterDataObserver : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$AdapterDataObserver", typeof(AdapterDataObserver));

		private static Delegate? cb_onChanged_OnChanged_V;

		private static Delegate? cb_onItemRangeChanged_OnItemRangeChanged_II_V;

		private static Delegate? cb_onItemRangeChanged_OnItemRangeChanged_IILjava_lang_Object__V;

		private static Delegate? cb_onItemRangeInserted_OnItemRangeInserted_II_V;

		private static Delegate? cb_onItemRangeMoved_OnItemRangeMoved_III_V;

		private static Delegate? cb_onItemRangeRemoved_OnItemRangeRemoved_II_V;

		private static Delegate? cb_onStateRestorationPolicyChanged_OnStateRestorationPolicyChanged_V;

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

		protected AdapterDataObserver(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AdapterDataObserver()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnChanged(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnChanged();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onChanged", "()V", "GetOnChangedHandler")]
		public unsafe virtual void OnChanged()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onChanged.()V", this, null);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemRangeChanged_II(nint jnienv, nint native__this, int positionStart, int itemCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnItemRangeChanged(positionStart, itemCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemRangeChanged", "(II)V", "GetOnItemRangeChanged_IIHandler")]
		public unsafe virtual void OnItemRangeChanged(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeChanged.(II)V", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemRangeChanged_IILjava_lang_Object_(nint jnienv, nint native__this, int positionStart, int itemCount, nint native_payload)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				AdapterDataObserver? adapterDataObserver = Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object payload = Java.Lang.Object.GetObject<Java.Lang.Object>(native_payload, JniHandleOwnership.DoNotTransfer);
				adapterDataObserver.OnItemRangeChanged(positionStart, itemCount, payload);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemRangeChanged", "(IILjava/lang/Object;)V", "GetOnItemRangeChanged_IILjava_lang_Object_Handler")]
		public unsafe virtual void OnItemRangeChanged(int positionStart, int itemCount, Java.Lang.Object? payload)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(positionStart);
				ptr[1] = new JniArgumentValue(itemCount);
				ptr[2] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeChanged.(IILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(payload);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemRangeInserted_II(nint jnienv, nint native__this, int positionStart, int itemCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnItemRangeInserted(positionStart, itemCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemRangeInserted", "(II)V", "GetOnItemRangeInserted_IIHandler")]
		public unsafe virtual void OnItemRangeInserted(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeInserted.(II)V", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemRangeMoved_III(nint jnienv, nint native__this, int fromPosition, int toPosition, int itemCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnItemRangeMoved(fromPosition, toPosition, itemCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemRangeMoved", "(III)V", "GetOnItemRangeMoved_IIIHandler")]
		public unsafe virtual void OnItemRangeMoved(int fromPosition, int toPosition, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(fromPosition);
			ptr[1] = new JniArgumentValue(toPosition);
			ptr[2] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeMoved.(III)V", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemRangeRemoved_II(nint jnienv, nint native__this, int positionStart, int itemCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnItemRangeRemoved(positionStart, itemCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemRangeRemoved", "(II)V", "GetOnItemRangeRemoved_IIHandler")]
		public unsafe virtual void OnItemRangeRemoved(int positionStart, int itemCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(positionStart);
			ptr[1] = new JniArgumentValue(itemCount);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onItemRangeRemoved.(II)V", this, ptr);
		}

		private static Delegate GetOnStateRestorationPolicyChangedHandler()
		{
			return new global::_JniMarshal_PP_V(n_OnStateRestorationPolicyChanged);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStateRestorationPolicyChanged(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<AdapterDataObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStateRestorationPolicyChanged();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onStateRestorationPolicyChanged", "()V", "GetOnStateRestorationPolicyChangedHandler")]
		public unsafe virtual void OnStateRestorationPolicyChanged()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStateRestorationPolicyChanged.()V", this, null);
		}

		[UnmanagedCallersOnly]
		private static void n_OnChanged_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnChanged(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnItemRangeChanged_II_mm_wrapper(nint jnienv, nint native__this, int positionStart, int itemCount)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnItemRangeChanged_II(jnienv, native__this, positionStart, itemCount);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnItemRangeChanged_IILjava_lang_Object__mm_wrapper(nint jnienv, nint native__this, int positionStart, int itemCount, nint native_payload)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnItemRangeChanged_IILjava_lang_Object_(jnienv, native__this, positionStart, itemCount, native_payload);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnItemRangeInserted_II_mm_wrapper(nint jnienv, nint native__this, int positionStart, int itemCount)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnItemRangeInserted_II(jnienv, native__this, positionStart, itemCount);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnItemRangeMoved_III_mm_wrapper(nint jnienv, nint native__this, int fromPosition, int toPosition, int itemCount)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnItemRangeMoved_III(jnienv, native__this, fromPosition, toPosition, itemCount);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnItemRangeRemoved_II_mm_wrapper(nint jnienv, nint native__this, int positionStart, int itemCount)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnItemRangeRemoved_II(jnienv, native__this, positionStart, itemCount);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$AdapterDataObserver", DoNotGenerateAcw = true)]
	internal class AdapterDataObserverInvoker : AdapterDataObserver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$AdapterDataObserver", typeof(AdapterDataObserverInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public AdapterDataObserverInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback", "", "AndroidX.RecyclerView.Widget.RecyclerView/IChildDrawingOrderCallbackInvoker")]
	public interface IChildDrawingOrderCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onGetChildDrawingOrder", "(II)I", "GetOnGetChildDrawingOrder_IIHandler:AndroidX.RecyclerView.Widget.RecyclerView/IChildDrawingOrderCallbackInvoker, Xamarin.AndroidX.RecyclerView")]
		int OnGetChildDrawingOrder(int childCount, int i);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback", DoNotGenerateAcw = true)]
	internal class IChildDrawingOrderCallbackInvoker : Java.Lang.Object, IChildDrawingOrderCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback", typeof(IChildDrawingOrderCallbackInvoker));

		private static Delegate? cb_onGetChildDrawingOrder_OnGetChildDrawingOrder_II_I;

		private static nint java_class_ref => _members_androidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback.ManagedPeerType;

		public IChildDrawingOrderCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnGetChildDrawingOrder_IIHandler()
		{
			return new global::_JniMarshal_PPII_I(n_OnGetChildDrawingOrder_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_OnGetChildDrawingOrder_II(nint jnienv, nint native__this, int childCount, int i)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IChildDrawingOrderCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnGetChildDrawingOrder(childCount, i);
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

		public unsafe int OnGetChildDrawingOrder(int childCount, int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(childCount);
			ptr[1] = new JniArgumentValue(i);
			return _members_androidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback.InstanceMethods.InvokeAbstractInt32Method("onGetChildDrawingOrder.(II)I", this, ptr);
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

	[Register("androidx/recyclerview/widget/RecyclerView$EdgeEffectFactory", DoNotGenerateAcw = true)]
	public class EdgeEffectFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$EdgeEffectFactory", typeof(EdgeEffectFactory));

		private static Delegate? cb_createEdgeEffect_CreateEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_I_Landroid_widget_EdgeEffect_;

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

		protected EdgeEffectFactory(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe EdgeEffectFactory()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCreateEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_IHandler()
		{
			return new global::_JniMarshal_PPLI_L(n_CreateEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_CreateEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_I(nint jnienv, nint native__this, nint native_view, int direction)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				EdgeEffectFactory? edgeEffectFactory = Java.Lang.Object.GetObject<EdgeEffectFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView view = Java.Lang.Object.GetObject<RecyclerView>(native_view, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(edgeEffectFactory.CreateEdgeEffect(view, direction));
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

		[Register("createEdgeEffect", "(Landroidx/recyclerview/widget/RecyclerView;I)Landroid/widget/EdgeEffect;", "GetCreateEdgeEffect_Landroidx_recyclerview_widget_RecyclerView_IHandler")]
		protected unsafe virtual EdgeEffect CreateEdgeEffect(RecyclerView view, int direction)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(direction);
				return Java.Lang.Object.GetObject<EdgeEffect>(_members.InstanceMethods.InvokeVirtualObjectMethod("createEdgeEffect.(Landroidx/recyclerview/widget/RecyclerView;I)Landroid/widget/EdgeEffect;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator", DoNotGenerateAcw = true)]
	public abstract class ItemAnimator : Java.Lang.Object
	{
		[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener", "", "AndroidX.RecyclerView.Widget.RecyclerView/ItemAnimator/IItemAnimatorFinishedListenerInvoker")]
		public interface IItemAnimatorFinishedListener : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("onAnimationsFinished", "()V", "GetOnAnimationsFinishedHandler:AndroidX.RecyclerView.Widget.RecyclerView/ItemAnimator/IItemAnimatorFinishedListenerInvoker, Xamarin.AndroidX.RecyclerView")]
			void OnAnimationsFinished();
		}

		[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener", DoNotGenerateAcw = true)]
		internal class IItemAnimatorFinishedListenerInvoker : Java.Lang.Object, IItemAnimatorFinishedListener, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members_androidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemAnimatorFinishedListener = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener", typeof(IItemAnimatorFinishedListenerInvoker));

			private static Delegate? cb_onAnimationsFinished_OnAnimationsFinished_V;

			private static nint java_class_ref => _members_androidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemAnimatorFinishedListener.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members_androidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemAnimatorFinishedListener;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override nint ThresholdClass => _members_androidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemAnimatorFinishedListener.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members_androidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemAnimatorFinishedListener.ManagedPeerType;

			public IItemAnimatorFinishedListenerInvoker(nint handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			private static Delegate GetOnAnimationsFinishedHandler()
			{
				return new global::_JniMarshal_PP_V(n_OnAnimationsFinished);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_OnAnimationsFinished(nint jnienv, nint native__this)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					Java.Lang.Object.GetObject<IItemAnimatorFinishedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAnimationsFinished();
				}
				catch (System.Exception e)
				{
					runtime.OnUserUnhandledException(ref transition, e);
				}
				finally
				{
					JniEnvironment.EndMarshalMethod(ref transition);
				}
			}

			public unsafe void OnAnimationsFinished()
			{
				_members_androidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemAnimatorFinishedListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationsFinished.()V", this, null);
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

		[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo", DoNotGenerateAcw = true)]
		public class ItemHolderInfo : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo", typeof(ItemHolderInfo));

			private static Delegate? cb_setFrom_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;

			private static Delegate? cb_setFrom_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;

			[Register("bottom")]
			public int Bottom
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("bottom.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("bottom.I", this, value);
				}
			}

			[Register("changeFlags")]
			public int ChangeFlags
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("changeFlags.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("changeFlags.I", this, value);
				}
			}

			[Register("left")]
			public int Left
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("left.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("left.I", this, value);
				}
			}

			[Register("right")]
			public int Right
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("right.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("right.I", this, value);
				}
			}

			[Register("top")]
			public int Top
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("top.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("top.I", this, value);
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

			protected ItemHolderInfo(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe ItemHolderInfo()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle == IntPtr.Zero)
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetSetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
			{
				return new global::_JniMarshal_PPL_L(n_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_holder)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					ItemHolderInfo? itemHolderInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
					return JNIEnv.ToLocalJniHandle(itemHolderInfo.SetFrom(viewHolder));
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

			[Register("setFrom", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetSetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
			public unsafe virtual ItemHolderInfo SetFrom(ViewHolder holder)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFrom.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(holder);
				}
			}

			private static Delegate GetSetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler()
			{
				return new global::_JniMarshal_PPLI_L(n_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static nint n_SetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_I(nint jnienv, nint native__this, nint native_holder, int flags)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					ItemHolderInfo? itemHolderInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					ViewHolder holder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
					return JNIEnv.ToLocalJniHandle(itemHolderInfo.SetFrom(holder, flags));
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

			[Register("setFrom", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetSetFrom_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler")]
			public unsafe virtual ItemHolderInfo SetFrom(ViewHolder holder, int flags)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(flags);
					return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("setFrom.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(holder);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemAnimator", typeof(ItemAnimator));

		private static Delegate? cb_getAddDuration_GetAddDuration_J;

		private static Delegate? cb_setAddDuration_SetAddDuration_J_V;

		private static Delegate? cb_getChangeDuration_GetChangeDuration_J;

		private static Delegate? cb_setChangeDuration_SetChangeDuration_J_V;

		private static Delegate? cb_isRunning_IsRunning_Z;

		private static Delegate? cb_getMoveDuration_GetMoveDuration_J;

		private static Delegate? cb_setMoveDuration_SetMoveDuration_J_V;

		private static Delegate? cb_getRemoveDuration_GetRemoveDuration_J;

		private static Delegate? cb_setRemoveDuration_SetRemoveDuration_J_V;

		private static Delegate? cb_animateAppearance_AnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo__Z;

		private static Delegate? cb_animateChange_AnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo__Z;

		private static Delegate? cb_animateDisappearance_AnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo__Z;

		private static Delegate? cb_animatePersistence_AnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo__Z;

		private static Delegate? cb_canReuseUpdatedViewHolder_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__Z;

		private static Delegate? cb_canReuseUpdatedViewHolder_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List__Z;

		private static Delegate? cb_endAnimation_EndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__V;

		private static Delegate? cb_endAnimations_EndAnimations_V;

		private static Delegate? cb_obtainHolderInfo_ObtainHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;

		private static Delegate? cb_onAnimationFinished_OnAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__V;

		private static Delegate? cb_onAnimationStarted_OnAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__V;

		private static Delegate? cb_recordPostLayoutInformation_RecordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;

		private static Delegate? cb_recordPreLayoutInformation_RecordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List__Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_;

		private static Delegate? cb_runPendingAnimations_RunPendingAnimations_V;

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

		public unsafe virtual long AddDuration
		{
			[Register("getAddDuration", "()J", "GetGetAddDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getAddDuration.()J", this, null);
			}
			[Register("setAddDuration", "(J)V", "GetSetAddDuration_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAddDuration.(J)V", this, ptr);
			}
		}

		public unsafe virtual long ChangeDuration
		{
			[Register("getChangeDuration", "()J", "GetGetChangeDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getChangeDuration.()J", this, null);
			}
			[Register("setChangeDuration", "(J)V", "GetSetChangeDuration_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setChangeDuration.(J)V", this, ptr);
			}
		}

		public abstract bool IsRunning
		{
			[Register("isRunning", "()Z", "GetIsRunningHandler")]
			get;
		}

		public unsafe virtual long MoveDuration
		{
			[Register("getMoveDuration", "()J", "GetGetMoveDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getMoveDuration.()J", this, null);
			}
			[Register("setMoveDuration", "(J)V", "GetSetMoveDuration_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMoveDuration.(J)V", this, ptr);
			}
		}

		public unsafe virtual long RemoveDuration
		{
			[Register("getRemoveDuration", "()J", "GetGetRemoveDurationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getRemoveDuration.()J", this, null);
			}
			[Register("setRemoveDuration", "(J)V", "GetSetRemoveDuration_JHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRemoveDuration.(J)V", this, ptr);
			}
		}

		protected ItemAnimator(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ItemAnimator()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetAddDurationHandler()
		{
			return new global::_JniMarshal_PP_J(n_GetAddDuration);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static long n_GetAddDuration(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0L;
			}
			try
			{
				return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddDuration;
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

		private static Delegate GetSetAddDuration_JHandler()
		{
			return new global::_JniMarshal_PPJ_V(n_SetAddDuration_J);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetAddDuration_J(nint jnienv, nint native__this, long addDuration)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddDuration = addDuration;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetGetChangeDurationHandler()
		{
			return new global::_JniMarshal_PP_J(n_GetChangeDuration);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static long n_GetChangeDuration(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0L;
			}
			try
			{
				return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChangeDuration;
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

		private static Delegate GetSetChangeDuration_JHandler()
		{
			return new global::_JniMarshal_PPJ_V(n_SetChangeDuration_J);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetChangeDuration_J(nint jnienv, nint native__this, long changeDuration)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChangeDuration = changeDuration;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetIsRunningHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsRunning);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsRunning(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRunning ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetGetMoveDurationHandler()
		{
			return new global::_JniMarshal_PP_J(n_GetMoveDuration);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static long n_GetMoveDuration(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0L;
			}
			try
			{
				return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveDuration;
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

		private static Delegate GetSetMoveDuration_JHandler()
		{
			return new global::_JniMarshal_PPJ_V(n_SetMoveDuration_J);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetMoveDuration_J(nint jnienv, nint native__this, long moveDuration)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveDuration = moveDuration;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetGetRemoveDurationHandler()
		{
			return new global::_JniMarshal_PP_J(n_GetRemoveDuration);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static long n_GetRemoveDuration(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0L;
			}
			try
			{
				return Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveDuration;
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

		private static Delegate GetSetRemoveDuration_JHandler()
		{
			return new global::_JniMarshal_PPJ_V(n_SetRemoveDuration_J);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetRemoveDuration_J(nint jnienv, nint native__this, long removeDuration)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveDuration = removeDuration;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetAnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_AnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_AnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_(nint jnienv, nint native__this, nint native_viewHolder, nint native_preLayoutInfo, nint native_postLayoutInfo)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				ItemHolderInfo preLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_preLayoutInfo, JniHandleOwnership.DoNotTransfer);
				ItemHolderInfo postLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_postLayoutInfo, JniHandleOwnership.DoNotTransfer);
				return itemAnimator.AnimateAppearance(viewHolder, preLayoutInfo, postLayoutInfo) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("animateAppearance", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public abstract bool AnimateAppearance(ViewHolder viewHolder, ItemHolderInfo? preLayoutInfo, ItemHolderInfo postLayoutInfo);

		private static Delegate GetAnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler()
		{
			return new global::_JniMarshal_PPLLLL_B(n_AnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_AnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_(nint jnienv, nint native__this, nint native_oldHolder, nint native_newHolder, nint native_preLayoutInfo, nint native_postLayoutInfo)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder oldHolder = Java.Lang.Object.GetObject<ViewHolder>(native_oldHolder, JniHandleOwnership.DoNotTransfer);
				ViewHolder newHolder = Java.Lang.Object.GetObject<ViewHolder>(native_newHolder, JniHandleOwnership.DoNotTransfer);
				ItemHolderInfo preLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_preLayoutInfo, JniHandleOwnership.DoNotTransfer);
				ItemHolderInfo postLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_postLayoutInfo, JniHandleOwnership.DoNotTransfer);
				return itemAnimator.AnimateChange(oldHolder, newHolder, preLayoutInfo, postLayoutInfo) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("animateChange", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public abstract bool AnimateChange(ViewHolder oldHolder, ViewHolder newHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo);

		private static Delegate GetAnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_AnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_AnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_(nint jnienv, nint native__this, nint native_viewHolder, nint native_preLayoutInfo, nint native_postLayoutInfo)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				ItemHolderInfo preLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_preLayoutInfo, JniHandleOwnership.DoNotTransfer);
				ItemHolderInfo postLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_postLayoutInfo, JniHandleOwnership.DoNotTransfer);
				return itemAnimator.AnimateDisappearance(viewHolder, preLayoutInfo, postLayoutInfo) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("animateDisappearance", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public abstract bool AnimateDisappearance(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo? postLayoutInfo);

		private static Delegate GetAnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_AnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_AnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_(nint jnienv, nint native__this, nint native_viewHolder, nint native_preLayoutInfo, nint native_postLayoutInfo)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				ItemHolderInfo preLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_preLayoutInfo, JniHandleOwnership.DoNotTransfer);
				ItemHolderInfo postLayoutInfo = Java.Lang.Object.GetObject<ItemHolderInfo>(native_postLayoutInfo, JniHandleOwnership.DoNotTransfer);
				return itemAnimator.AnimatePersistence(viewHolder, preLayoutInfo, postLayoutInfo) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("animatePersistence", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public abstract bool AnimatePersistence(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo);

		private static Delegate GetCanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			return new global::_JniMarshal_PPL_B(n_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_viewHolder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				return itemAnimator.CanReuseUpdatedViewHolder(viewHolder) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("canReuseUpdatedViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", "GetCanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual bool CanReuseUpdatedViewHolder(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canReuseUpdatedViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetCanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_CanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_(nint jnienv, nint native__this, nint native_viewHolder, nint native_payloads)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				IList<Java.Lang.Object> payloads = JavaList<Java.Lang.Object>.FromJniHandle(native_payloads, JniHandleOwnership.DoNotTransfer);
				return itemAnimator.CanReuseUpdatedViewHolder(viewHolder, payloads) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("canReuseUpdatedViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Ljava/util/List;)Z", "GetCanReuseUpdatedViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Ljava_util_List_Handler")]
		public unsafe virtual bool CanReuseUpdatedViewHolder(ViewHolder viewHolder, IList<Java.Lang.Object> payloads)
		{
			nint num = JavaList<Java.Lang.Object>.ToLocalJniHandle(payloads);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("canReuseUpdatedViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Ljava/util/List;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(payloads);
			}
		}

		[Register("dispatchAnimationFinished", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "")]
		public unsafe void DispatchAnimationFinished(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchAnimationFinished.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		[Register("dispatchAnimationStarted", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "")]
		public unsafe void DispatchAnimationStarted(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchAnimationStarted.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		[Register("dispatchAnimationsFinished", "()V", "")]
		public unsafe void DispatchAnimationsFinished()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchAnimationsFinished.()V", this, null);
		}

		private static Delegate GetEndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_EndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_EndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_item)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder item = Java.Lang.Object.GetObject<ViewHolder>(native_item, JniHandleOwnership.DoNotTransfer);
				itemAnimator.EndAnimation(item);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("endAnimation", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetEndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public abstract void EndAnimation(ViewHolder item);

		private static Delegate GetEndAnimationsHandler()
		{
			return new global::_JniMarshal_PP_V(n_EndAnimations);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_EndAnimations(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EndAnimations();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("endAnimations", "()V", "GetEndAnimationsHandler")]
		public abstract void EndAnimations();

		[Register("isRunning", "(Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener;)Z", "")]
		public unsafe bool InvokeIsRunning(IItemAnimatorFinishedListener? listener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isRunning.(Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(listener);
			}
		}

		private static Delegate GetObtainHolderInfoHandler()
		{
			return new global::_JniMarshal_PP_L(n_ObtainHolderInfo);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_ObtainHolderInfo(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ObtainHolderInfo());
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

		[Register("obtainHolderInfo", "()Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetObtainHolderInfoHandler")]
		public unsafe virtual ItemHolderInfo ObtainHolderInfo()
		{
			return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("obtainHolderInfo.()Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetOnAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_viewHolder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				itemAnimator.OnAnimationFinished(viewHolder);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onAnimationFinished", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnAnimationFinished_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnAnimationFinished(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAnimationFinished.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetOnAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_viewHolder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				itemAnimator.OnAnimationStarted(viewHolder);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onAnimationStarted", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnAnimationStarted_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void OnAnimationStarted(ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAnimationStarted.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetRecordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_RecordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_RecordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_state, nint native_viewHolder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(itemAnimator.RecordPostLayoutInformation(state, viewHolder));
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

		[Register("recordPostLayoutInformation", "(Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetRecordPostLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual ItemHolderInfo RecordPostLayoutInformation(State state, ViewHolder viewHolder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("recordPostLayoutInformation.(Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(state);
				GC.KeepAlive(viewHolder);
			}
		}

		private static Delegate GetRecordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_Handler()
		{
			return new _JniMarshal_PPLLIL_L(n_RecordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_RecordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_(nint jnienv, nint native__this, nint native_state, nint native_viewHolder, int changeFlags, nint native_payloads)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ItemAnimator? itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				ViewHolder viewHolder = Java.Lang.Object.GetObject<ViewHolder>(native_viewHolder, JniHandleOwnership.DoNotTransfer);
				IList<Java.Lang.Object> payloads = JavaList<Java.Lang.Object>.FromJniHandle(native_payloads, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(itemAnimator.RecordPreLayoutInformation(state, viewHolder, changeFlags, payloads));
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

		[Register("recordPreLayoutInformation", "(Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", "GetRecordPreLayoutInformation_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_Handler")]
		public unsafe virtual ItemHolderInfo RecordPreLayoutInformation(State state, ViewHolder viewHolder, int changeFlags, IList<Java.Lang.Object> payloads)
		{
			nint num = JavaList<Java.Lang.Object>.ToLocalJniHandle(payloads);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(changeFlags);
				ptr[3] = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<ItemHolderInfo>(_members.InstanceMethods.InvokeVirtualObjectMethod("recordPreLayoutInformation.(Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(state);
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(payloads);
			}
		}

		private static Delegate GetRunPendingAnimationsHandler()
		{
			return new global::_JniMarshal_PP_V(n_RunPendingAnimations);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RunPendingAnimations(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<ItemAnimator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RunPendingAnimations();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("runPendingAnimations", "()V", "GetRunPendingAnimationsHandler")]
		public abstract void RunPendingAnimations();
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ItemAnimator", DoNotGenerateAcw = true)]
	internal class ItemAnimatorInvoker : ItemAnimator
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemAnimator", typeof(ItemAnimatorInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override bool IsRunning
		{
			[Register("isRunning", "()Z", "GetIsRunningHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isRunning.()Z", this, null);
			}
		}

		public ItemAnimatorInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("animateAppearance", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateAppearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public unsafe override bool AnimateAppearance(ViewHolder viewHolder, ItemHolderInfo? preLayoutInfo, ItemHolderInfo postLayoutInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(preLayoutInfo?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(postLayoutInfo?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("animateAppearance.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(preLayoutInfo);
				GC.KeepAlive(postLayoutInfo);
			}
		}

		[Register("animateChange", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateChange_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public unsafe override bool AnimateChange(ViewHolder oldHolder, ViewHolder newHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(oldHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newHolder?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(preLayoutInfo?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(postLayoutInfo?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("animateChange.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(oldHolder);
				GC.KeepAlive(newHolder);
				GC.KeepAlive(preLayoutInfo);
				GC.KeepAlive(postLayoutInfo);
			}
		}

		[Register("animateDisappearance", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimateDisappearance_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public unsafe override bool AnimateDisappearance(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo? postLayoutInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(preLayoutInfo?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(postLayoutInfo?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("animateDisappearance.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(preLayoutInfo);
				GC.KeepAlive(postLayoutInfo);
			}
		}

		[Register("animatePersistence", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", "GetAnimatePersistence_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_ItemHolderInfo_Handler")]
		public unsafe override bool AnimatePersistence(ViewHolder viewHolder, ItemHolderInfo preLayoutInfo, ItemHolderInfo postLayoutInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(viewHolder?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(preLayoutInfo?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(postLayoutInfo?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("animatePersistence.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;Landroidx/recyclerview/widget/RecyclerView$ItemAnimator$ItemHolderInfo;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(viewHolder);
				GC.KeepAlive(preLayoutInfo);
				GC.KeepAlive(postLayoutInfo);
			}
		}

		[Register("endAnimation", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetEndAnimation_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe override void EndAnimation(ViewHolder item)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(item?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("endAnimation.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(item);
			}
		}

		[Register("endAnimations", "()V", "GetEndAnimationsHandler")]
		public unsafe override void EndAnimations()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("endAnimations.()V", this, null);
		}

		[Register("runPendingAnimations", "()V", "GetRunPendingAnimationsHandler")]
		public unsafe override void RunPendingAnimations()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("runPendingAnimations.()V", this, null);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ItemDecoration", DoNotGenerateAcw = true)]
	public abstract class ItemDecoration : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemDecoration", typeof(ItemDecoration));

		private static Delegate? cb_getItemOffsets_GetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State__V;

		private static Delegate? cb_getItemOffsets_GetItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView__V;

		private static Delegate? cb_onDraw_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView__V;

		private static Delegate? cb_onDraw_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State__V;

		private static Delegate? cb_onDrawOver_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView__V;

		private static Delegate? cb_onDrawOver_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State__V;

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

		protected ItemDecoration(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ItemDecoration()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_GetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_outRect, nint native_view, nint native_parent, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ItemDecoration? itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Rect outRect = Java.Lang.Object.GetObject<Rect>(native_outRect, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				itemDecoration.GetItemOffsets(outRect, view, parent, state);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("getItemOffsets", "(Landroid/graphics/Rect;Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetGetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void GetItemOffsets(Rect outRect, View view, RecyclerView parent, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(outRect?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getItemOffsets.(Landroid/graphics/Rect;Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(outRect);
				GC.KeepAlive(view);
				GC.KeepAlive(parent);
				GC.KeepAlive(state);
			}
		}

		[Obsolete]
		private static Delegate GetGetItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_Handler()
		{
			return new global::_JniMarshal_PPLIL_V(n_GetItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_GetItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_(nint jnienv, nint native__this, nint native_outRect, int itemPosition, nint native_parent)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ItemDecoration? itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Rect outRect = Java.Lang.Object.GetObject<Rect>(native_outRect, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				itemDecoration.GetItemOffsets(outRect, itemPosition, parent);
			}
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
		[Register("getItemOffsets", "(Landroid/graphics/Rect;ILandroidx/recyclerview/widget/RecyclerView;)V", "GetGetItemOffsets_Landroid_graphics_Rect_ILandroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void GetItemOffsets(Rect outRect, int itemPosition, RecyclerView parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(outRect?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(itemPosition);
				ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getItemOffsets.(Landroid/graphics/Rect;ILandroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(outRect);
				GC.KeepAlive(parent);
			}
		}

		[Obsolete]
		private static Delegate GetOnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_(nint jnienv, nint native__this, nint native_c, nint native_parent)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ItemDecoration? itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				itemDecoration.OnDraw(c, parent);
			}
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
		[Register("onDraw", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnDraw(Canvas c, RecyclerView parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(parent);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_c, nint native_parent, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ItemDecoration? itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				itemDecoration.OnDraw(c, parent, state);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onDraw", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetOnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void OnDraw(Canvas c, RecyclerView parent, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(parent);
				GC.KeepAlive(state);
			}
		}

		[Obsolete]
		private static Delegate GetOnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_(nint jnienv, nint native__this, nint native_c, nint native_parent)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ItemDecoration? itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				itemDecoration.OnDrawOver(c, parent);
			}
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
		[Register("onDrawOver", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnDrawOver(Canvas c, RecyclerView parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDrawOver.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(parent);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_c, nint native_parent, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ItemDecoration? itemDecoration = Java.Lang.Object.GetObject<ItemDecoration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				itemDecoration.OnDrawOver(c, parent, state);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onDrawOver", "(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetOnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void OnDrawOver(Canvas c, RecyclerView parent, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDrawOver.(Landroid/graphics/Canvas;Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(parent);
				GC.KeepAlive(state);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_GetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State__mm_wrapper(nint jnienv, nint native__this, nint native_outRect, nint native_view, nint native_parent, nint native_state)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_GetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_(jnienv, native__this, native_outRect, native_view, native_parent, native_state);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State__mm_wrapper(nint jnienv, nint native__this, nint native_c, nint native_parent, nint native_state)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDraw_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_(jnienv, native__this, native_c, native_parent, native_state);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State__mm_wrapper(nint jnienv, nint native__this, nint native_c, nint native_parent, nint native_state)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnDrawOver_Landroid_graphics_Canvas_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_(jnienv, native__this, native_c, native_parent, native_state);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ItemDecoration", DoNotGenerateAcw = true)]
	internal class ItemDecorationInvoker : ItemDecoration
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ItemDecoration", typeof(ItemDecorationInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ItemDecorationInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager", DoNotGenerateAcw = true)]
	public abstract class LayoutManager : Java.Lang.Object
	{
		[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry", "", "AndroidX.RecyclerView.Widget.RecyclerView/LayoutManager/ILayoutPrefetchRegistryInvoker")]
		public interface ILayoutPrefetchRegistry : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("addPosition", "(II)V", "GetAddPosition_IIHandler:AndroidX.RecyclerView.Widget.RecyclerView/LayoutManager/ILayoutPrefetchRegistryInvoker, Xamarin.AndroidX.RecyclerView")]
			void AddPosition(int layoutPosition, int pixelDistance);
		}

		[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry", DoNotGenerateAcw = true)]
		internal class ILayoutPrefetchRegistryInvoker : Java.Lang.Object, ILayoutPrefetchRegistry, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members_androidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry", typeof(ILayoutPrefetchRegistryInvoker));

			private static Delegate? cb_addPosition_AddPosition_II_V;

			private static nint java_class_ref => _members_androidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members_androidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override nint ThresholdClass => _members_androidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members_androidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry.ManagedPeerType;

			public ILayoutPrefetchRegistryInvoker(nint handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			private static Delegate GetAddPosition_IIHandler()
			{
				return new global::_JniMarshal_PPII_V(n_AddPosition_II);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_AddPosition_II(nint jnienv, nint native__this, int layoutPosition, int pixelDistance)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					Java.Lang.Object.GetObject<ILayoutPrefetchRegistry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddPosition(layoutPosition, pixelDistance);
				}
				catch (System.Exception e)
				{
					runtime.OnUserUnhandledException(ref transition, e);
				}
				finally
				{
					JniEnvironment.EndMarshalMethod(ref transition);
				}
			}

			public unsafe void AddPosition(int layoutPosition, int pixelDistance)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(layoutPosition);
				ptr[1] = new JniArgumentValue(pixelDistance);
				_members_androidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry.InstanceMethods.InvokeAbstractVoidMethod("addPosition.(II)V", this, ptr);
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

		[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager$Properties", DoNotGenerateAcw = true)]
		public class Properties : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutManager$Properties", typeof(Properties));

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

			[Register("reverseLayout")]
			public bool ReverseLayout
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("reverseLayout.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("reverseLayout.Z", this, value ? ((sbyte)1) : ((sbyte)0));
				}
			}

			[Register("spanCount")]
			public int SpanCount
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("spanCount.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("spanCount.I", this, value);
				}
			}

			[Register("stackFromEnd")]
			public bool StackFromEnd
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("stackFromEnd.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("stackFromEnd.Z", this, value ? ((sbyte)1) : ((sbyte)0));
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

			protected Properties(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Properties()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle == IntPtr.Zero)
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutManager", typeof(LayoutManager));

		private static Delegate? cb_isAutoMeasureEnabled_IsAutoMeasureEnabled_Z;

		private static Delegate? cb_setAutoMeasureEnabled_SetAutoMeasureEnabled_Z_V;

		private static Delegate? cb_getBaseline_GetBaseline_I;

		private static Delegate? cb_getChildCount_GetChildCount_I;

		private static Delegate? cb_getClipToPadding_GetClipToPadding_Z;

		private static Delegate? cb_getFocusedChild_GetFocusedChild_Landroid_view_View_;

		private static Delegate? cb_hasFocus_HasFocus_Z;

		private static Delegate? cb_getHeight_GetHeight_I;

		private static Delegate? cb_getHeightMode_GetHeightMode_I;

		private static Delegate? cb_isAttachedToWindow_IsAttachedToWindow_Z;

		private static Delegate? cb_isFocused_IsFocused_Z;

		private static Delegate? cb_isLayoutReversed_IsLayoutReversed_Z;

		private static Delegate? cb_isSmoothScrolling_IsSmoothScrolling_Z;

		private static Delegate? cb_getItemCount_GetItemCount_I;

		private static Delegate? cb_getLayoutDirection_GetLayoutDirection_I;

		private static Delegate? cb_isMeasurementCacheEnabled_IsMeasurementCacheEnabled_Z;

		private static Delegate? cb_setMeasurementCacheEnabled_SetMeasurementCacheEnabled_Z_V;

		private static Delegate? cb_getMinimumHeight_GetMinimumHeight_I;

		private static Delegate? cb_getMinimumWidth_GetMinimumWidth_I;

		private static Delegate? cb_getPaddingBottom_GetPaddingBottom_I;

		private static Delegate? cb_getPaddingEnd_GetPaddingEnd_I;

		private static Delegate? cb_getPaddingLeft_GetPaddingLeft_I;

		private static Delegate? cb_getPaddingRight_GetPaddingRight_I;

		private static Delegate? cb_getPaddingStart_GetPaddingStart_I;

		private static Delegate? cb_getPaddingTop_GetPaddingTop_I;

		private static Delegate? cb_getWidth_GetWidth_I;

		private static Delegate? cb_getWidthMode_GetWidthMode_I;

		private static Delegate? cb_addDisappearingView_AddDisappearingView_Landroid_view_View__V;

		private static Delegate? cb_addDisappearingView_AddDisappearingView_Landroid_view_View_I_V;

		private static Delegate? cb_addView_AddView_Landroid_view_View__V;

		private static Delegate? cb_addView_AddView_Landroid_view_View_I_V;

		private static Delegate? cb_assertInLayoutOrScroll_AssertInLayoutOrScroll_Ljava_lang_String__V;

		private static Delegate? cb_assertNotInLayoutOrScroll_AssertNotInLayoutOrScroll_Ljava_lang_String__V;

		private static Delegate? cb_attachView_AttachView_Landroid_view_View__V;

		private static Delegate? cb_attachView_AttachView_Landroid_view_View_I_V;

		private static Delegate? cb_attachView_AttachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams__V;

		private static Delegate? cb_calculateItemDecorationsForChild_CalculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect__V;

		private static Delegate? cb_canScrollHorizontally_CanScrollHorizontally_Z;

		private static Delegate? cb_canScrollVertically_CanScrollVertically_Z;

		private static Delegate? cb_checkLayoutParams_CheckLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams__Z;

		private static Delegate? cb_collectAdjacentPrefetchPositions_CollectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry__V;

		private static Delegate? cb_collectInitialPrefetchPositions_CollectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry__V;

		private static Delegate? cb_computeHorizontalScrollExtent_ComputeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_computeHorizontalScrollOffset_ComputeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_computeHorizontalScrollRange_ComputeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_computeVerticalScrollExtent_ComputeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_computeVerticalScrollOffset_ComputeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_computeVerticalScrollRange_ComputeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_detachAndScrapAttachedViews_DetachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler__V;

		private static Delegate? cb_detachAndScrapView_DetachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler__V;

		private static Delegate? cb_detachAndScrapViewAt_DetachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler__V;

		private static Delegate? cb_detachView_DetachView_Landroid_view_View__V;

		private static Delegate? cb_detachViewAt_DetachViewAt_I_V;

		private static Delegate? cb_endAnimation_EndAnimation_Landroid_view_View__V;

		private static Delegate? cb_findContainingItemView_FindContainingItemView_Landroid_view_View__Landroid_view_View_;

		private static Delegate? cb_findViewByPosition_FindViewByPosition_I_Landroid_view_View_;

		private static Delegate? cb_generateDefaultLayoutParams_GenerateDefaultLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_;

		private static Delegate? cb_generateLayoutParams_GenerateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet__Landroidx_recyclerview_widget_RecyclerView_LayoutParams_;

		private static Delegate? cb_generateLayoutParams_GenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams__Landroidx_recyclerview_widget_RecyclerView_LayoutParams_;

		private static Delegate? cb_getBottomDecorationHeight_GetBottomDecorationHeight_Landroid_view_View__I;

		private static Delegate? cb_getChildAt_GetChildAt_I_Landroid_view_View_;

		private static Delegate? cb_getColumnCountForAccessibility_GetColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_getDecoratedBottom_GetDecoratedBottom_Landroid_view_View__I;

		private static Delegate? cb_getDecoratedBoundsWithMargins_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect__V;

		private static Delegate? cb_getDecoratedLeft_GetDecoratedLeft_Landroid_view_View__I;

		private static Delegate? cb_getDecoratedMeasuredHeight_GetDecoratedMeasuredHeight_Landroid_view_View__I;

		private static Delegate? cb_getDecoratedMeasuredWidth_GetDecoratedMeasuredWidth_Landroid_view_View__I;

		private static Delegate? cb_getDecoratedRight_GetDecoratedRight_Landroid_view_View__I;

		private static Delegate? cb_getDecoratedTop_GetDecoratedTop_Landroid_view_View__I;

		private static Delegate? cb_getItemViewType_GetItemViewType_Landroid_view_View__I;

		private static Delegate? cb_getLeftDecorationWidth_GetLeftDecorationWidth_Landroid_view_View__I;

		private static Delegate? cb_getPosition_GetPosition_Landroid_view_View__I;

		private static Delegate? cb_getRightDecorationWidth_GetRightDecorationWidth_Landroid_view_View__I;

		private static Delegate? cb_getRowCountForAccessibility_GetRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_getSelectionModeForAccessibility_GetSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_getTopDecorationHeight_GetTopDecorationHeight_Landroid_view_View__I;

		private static Delegate? cb_getTransformedBoundingBox_GetTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect__V;

		private static Delegate? cb_ignoreView_IgnoreView_Landroid_view_View__V;

		private static Delegate? cb_isLayoutHierarchical_IsLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__Z;

		private static Delegate? cb_isViewPartiallyVisible_IsViewPartiallyVisible_Landroid_view_View_ZZ_Z;

		private static Delegate? cb_layoutDecorated_LayoutDecorated_Landroid_view_View_IIII_V;

		private static Delegate? cb_layoutDecoratedWithMargins_LayoutDecoratedWithMargins_Landroid_view_View_IIII_V;

		private static Delegate? cb_measureChild_MeasureChild_Landroid_view_View_II_V;

		private static Delegate? cb_measureChildWithMargins_MeasureChildWithMargins_Landroid_view_View_II_V;

		private static Delegate? cb_moveView_MoveView_II_V;

		private static Delegate? cb_offsetChildrenHorizontal_OffsetChildrenHorizontal_I_V;

		private static Delegate? cb_offsetChildrenVertical_OffsetChildrenVertical_I_V;

		private static Delegate? cb_onAdapterChanged_OnAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter__V;

		private static Delegate? cb_onAddFocusables_OnAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_II_Z;

		private static Delegate? cb_onAttachedToWindow_OnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView__V;

		private static Delegate? cb_onDetachedFromWindow_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView__V;

		private static Delegate? cb_onDetachedFromWindow_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler__V;

		private static Delegate? cb_onFocusSearchFailed_OnFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__Landroid_view_View_;

		private static Delegate? cb_onInitializeAccessibilityEvent_OnInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent__V;

		private static Delegate? cb_onInitializeAccessibilityEvent_OnInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent__V;

		private static Delegate? cb_onInitializeAccessibilityNodeInfo_OnInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat__V;

		private static Delegate? cb_onInitializeAccessibilityNodeInfoForItem_OnInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat__V;

		private static Delegate? cb_onInterceptFocusSearch_OnInterceptFocusSearch_Landroid_view_View_I_Landroid_view_View_;

		private static Delegate? cb_onItemsAdded_OnItemsAdded_Landroidx_recyclerview_widget_RecyclerView_II_V;

		private static Delegate? cb_onItemsChanged_OnItemsChanged_Landroidx_recyclerview_widget_RecyclerView__V;

		private static Delegate? cb_onItemsMoved_OnItemsMoved_Landroidx_recyclerview_widget_RecyclerView_III_V;

		private static Delegate? cb_onItemsRemoved_OnItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_II_V;

		private static Delegate? cb_onItemsUpdated_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_II_V;

		private static Delegate? cb_onItemsUpdated_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object__V;

		private static Delegate? cb_onLayoutChildren_OnLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__V;

		private static Delegate? cb_onLayoutCompleted_OnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State__V;

		private static Delegate? cb_onMeasure_OnMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_II_V;

		private static Delegate? cb_onRequestChildFocus_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View__Z;

		private static Delegate? cb_onRequestChildFocus_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View__Z;

		private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroid_os_Parcelable__V;

		private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Parcelable_;

		private static Delegate? cb_onScrollStateChanged_OnScrollStateChanged_I_V;

		private static Delegate? cb_performAccessibilityAction_PerformAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle__Z;

		private static Delegate? cb_performAccessibilityActionForItem_PerformAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle__Z;

		private static Delegate? cb_postOnAnimation_PostOnAnimation_Ljava_lang_Runnable__V;

		private static Delegate? cb_removeAllViews_RemoveAllViews_V;

		private static Delegate? cb_removeAndRecycleAllViews_RemoveAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler__V;

		private static Delegate? cb_removeAndRecycleView_RemoveAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler__V;

		private static Delegate? cb_removeAndRecycleViewAt_RemoveAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler__V;

		private static Delegate? cb_removeCallbacks_RemoveCallbacks_Ljava_lang_Runnable__Z;

		private static Delegate? cb_removeDetachedView_RemoveDetachedView_Landroid_view_View__V;

		private static Delegate? cb_removeView_RemoveView_Landroid_view_View__V;

		private static Delegate? cb_removeViewAt_RemoveViewAt_I_V;

		private static Delegate? cb_requestChildRectangleOnScreen_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_Z_Z;

		private static Delegate? cb_requestChildRectangleOnScreen_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZ_Z;

		private static Delegate? cb_requestLayout_RequestLayout_V;

		private static Delegate? cb_requestSimpleAnimationsInNextLayout_RequestSimpleAnimationsInNextLayout_V;

		private static Delegate? cb_scrollHorizontallyBy_ScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_scrollToPosition_ScrollToPosition_I_V;

		private static Delegate? cb_scrollVerticallyBy_ScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__I;

		private static Delegate? cb_setMeasuredDimension_SetMeasuredDimension_Landroid_graphics_Rect_II_V;

		private static Delegate? cb_setMeasuredDimension_SetMeasuredDimension_II_V;

		private static Delegate? cb_smoothScrollToPosition_SmoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I_V;

		private static Delegate? cb_startSmoothScroll_StartSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller__V;

		private static Delegate? cb_stopIgnoringView_StopIgnoringView_Landroid_view_View__V;

		private static Delegate? cb_supportsPredictiveItemAnimations_SupportsPredictiveItemAnimations_Z;

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

		public unsafe virtual bool AutoMeasureEnabled
		{
			[Register("isAutoMeasureEnabled", "()Z", "GetIsAutoMeasureEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAutoMeasureEnabled.()Z", this, null);
			}
			[Obsolete("deprecated")]
			[Register("setAutoMeasureEnabled", "(Z)V", "GetSetAutoMeasureEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAutoMeasureEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int Baseline
		{
			[Register("getBaseline", "()I", "GetGetBaselineHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBaseline.()I", this, null);
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

		public unsafe virtual bool ClipToPadding
		{
			[Register("getClipToPadding", "()Z", "GetGetClipToPaddingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("getClipToPadding.()Z", this, null);
			}
		}

		public unsafe virtual View? FocusedChild
		{
			[Register("getFocusedChild", "()Landroid/view/View;", "GetGetFocusedChildHandler")]
			get
			{
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFocusedChild.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool HasFocus
		{
			[Register("hasFocus", "()Z", "GetHasFocusHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasFocus.()Z", this, null);
			}
		}

		public unsafe virtual int Height
		{
			[Register("getHeight", "()I", "GetGetHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getHeight.()I", this, null);
			}
		}

		public unsafe virtual int HeightMode
		{
			[Register("getHeightMode", "()I", "GetGetHeightModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getHeightMode.()I", this, null);
			}
		}

		public unsafe virtual bool IsAttachedToWindow
		{
			[Register("isAttachedToWindow", "()Z", "GetIsAttachedToWindowHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAttachedToWindow.()Z", this, null);
			}
		}

		public unsafe virtual bool IsFocused
		{
			[Register("isFocused", "()Z", "GetIsFocusedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isFocused.()Z", this, null);
			}
		}

		public unsafe virtual bool IsLayoutReversed
		{
			[Register("isLayoutReversed", "()Z", "GetIsLayoutReversedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutReversed.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSmoothScrolling
		{
			[Register("isSmoothScrolling", "()Z", "GetIsSmoothScrollingHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSmoothScrolling.()Z", this, null);
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

		public unsafe bool ItemPrefetchEnabled
		{
			[Register("isItemPrefetchEnabled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isItemPrefetchEnabled.()Z", this, null);
			}
			[Register("setItemPrefetchEnabled", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setItemPrefetchEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int LayoutDirection
		{
			[Register("getLayoutDirection", "()I", "GetGetLayoutDirectionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLayoutDirection.()I", this, null);
			}
		}

		public unsafe virtual bool MeasurementCacheEnabled
		{
			[Register("isMeasurementCacheEnabled", "()Z", "GetIsMeasurementCacheEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMeasurementCacheEnabled.()Z", this, null);
			}
			[Register("setMeasurementCacheEnabled", "(Z)V", "GetSetMeasurementCacheEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasurementCacheEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int MinimumHeight
		{
			[Register("getMinimumHeight", "()I", "GetGetMinimumHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinimumHeight.()I", this, null);
			}
		}

		public unsafe virtual int MinimumWidth
		{
			[Register("getMinimumWidth", "()I", "GetGetMinimumWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinimumWidth.()I", this, null);
			}
		}

		public unsafe virtual int PaddingBottom
		{
			[Register("getPaddingBottom", "()I", "GetGetPaddingBottomHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingBottom.()I", this, null);
			}
		}

		public unsafe virtual int PaddingEnd
		{
			[Register("getPaddingEnd", "()I", "GetGetPaddingEndHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingEnd.()I", this, null);
			}
		}

		public unsafe virtual int PaddingLeft
		{
			[Register("getPaddingLeft", "()I", "GetGetPaddingLeftHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingLeft.()I", this, null);
			}
		}

		public unsafe virtual int PaddingRight
		{
			[Register("getPaddingRight", "()I", "GetGetPaddingRightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingRight.()I", this, null);
			}
		}

		public unsafe virtual int PaddingStart
		{
			[Register("getPaddingStart", "()I", "GetGetPaddingStartHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingStart.()I", this, null);
			}
		}

		public unsafe virtual int PaddingTop
		{
			[Register("getPaddingTop", "()I", "GetGetPaddingTopHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPaddingTop.()I", this, null);
			}
		}

		public unsafe virtual int Width
		{
			[Register("getWidth", "()I", "GetGetWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getWidth.()I", this, null);
			}
		}

		public unsafe virtual int WidthMode
		{
			[Register("getWidthMode", "()I", "GetGetWidthModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getWidthMode.()I", this, null);
			}
		}

		protected LayoutManager(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LayoutManager()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsAutoMeasureEnabled(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoMeasureEnabled ? ((sbyte)1) : ((sbyte)0);
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
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetAutoMeasureEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool autoMeasureEnabled = native_enabled != 0;
				layoutManager.AutoMeasureEnabled = autoMeasureEnabled;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetGetBaselineHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetBaseline);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetBaseline(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Baseline;
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
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChildCount;
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

		private static Delegate GetGetClipToPaddingHandler()
		{
			return new global::_JniMarshal_PP_B(n_GetClipToPadding);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_GetClipToPadding(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClipToPadding ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetGetFocusedChildHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetFocusedChild);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetFocusedChild(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusedChild);
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

		private static Delegate GetHasFocusHandler()
		{
			return new global::_JniMarshal_PP_B(n_HasFocus);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_HasFocus(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFocus ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetGetHeightHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetHeight);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetHeight(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
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

		private static Delegate GetGetHeightModeHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetHeightMode);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetHeightMode(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeightMode;
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

		private static Delegate GetIsAttachedToWindowHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsAttachedToWindow);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsAttachedToWindow(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAttachedToWindow ? ((sbyte)1) : ((sbyte)0);
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
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFocused ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetIsLayoutReversedHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsLayoutReversed);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsLayoutReversed(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsLayoutReversed ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetIsSmoothScrollingHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsSmoothScrolling);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsSmoothScrolling(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSmoothScrolling ? ((sbyte)1) : ((sbyte)0);
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
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCount;
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

		private static Delegate GetGetLayoutDirectionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetLayoutDirection);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetLayoutDirection(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutDirection;
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

		private static Delegate GetIsMeasurementCacheEnabledHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsMeasurementCacheEnabled);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsMeasurementCacheEnabled(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MeasurementCacheEnabled ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetSetMeasurementCacheEnabled_ZHandler()
		{
			return new global::_JniMarshal_PPB_V(n_SetMeasurementCacheEnabled_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetMeasurementCacheEnabled_Z(nint jnienv, nint native__this, sbyte native_measurementCacheEnabled)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool measurementCacheEnabled = native_measurementCacheEnabled != 0;
				layoutManager.MeasurementCacheEnabled = measurementCacheEnabled;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetGetMinimumHeightHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetMinimumHeight);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetMinimumHeight(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumHeight;
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

		private static Delegate GetGetMinimumWidthHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetMinimumWidth);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetMinimumWidth(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinimumWidth;
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

		private static Delegate GetGetPaddingBottomHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetPaddingBottom);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPaddingBottom(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingBottom;
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

		private static Delegate GetGetPaddingEndHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetPaddingEnd);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPaddingEnd(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingEnd;
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

		private static Delegate GetGetPaddingLeftHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetPaddingLeft);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPaddingLeft(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingLeft;
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

		private static Delegate GetGetPaddingRightHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetPaddingRight);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPaddingRight(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingRight;
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

		private static Delegate GetGetPaddingStartHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetPaddingStart);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPaddingStart(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingStart;
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

		private static Delegate GetGetPaddingTopHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetPaddingTop);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPaddingTop(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaddingTop;
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

		private static Delegate GetGetWidthHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetWidth);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetWidth(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
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

		private static Delegate GetGetWidthModeHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetWidthMode);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetWidthMode(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WidthMode;
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

		private static Delegate GetAddDisappearingView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_AddDisappearingView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AddDisappearingView_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.AddDisappearingView(child);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("addDisappearingView", "(Landroid/view/View;)V", "GetAddDisappearingView_Landroid_view_View_Handler")]
		public unsafe virtual void AddDisappearingView(View? child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addDisappearingView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAddDisappearingView_Landroid_view_View_IHandler()
		{
			return new global::_JniMarshal_PPLI_V(n_AddDisappearingView_Landroid_view_View_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AddDisappearingView_Landroid_view_View_I(nint jnienv, nint native__this, nint native_child, int index)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.AddDisappearingView(child, index);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("addDisappearingView", "(Landroid/view/View;I)V", "GetAddDisappearingView_Landroid_view_View_IHandler")]
		public unsafe virtual void AddDisappearingView(View? child, int index)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(index);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addDisappearingView.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAddView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_AddView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AddView_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.AddView(child);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("addView", "(Landroid/view/View;)V", "GetAddView_Landroid_view_View_Handler")]
		public unsafe virtual void AddView(View? child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAddView_Landroid_view_View_IHandler()
		{
			return new global::_JniMarshal_PPLI_V(n_AddView_Landroid_view_View_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AddView_Landroid_view_View_I(nint jnienv, nint native__this, nint native_child, int index)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.AddView(child, index);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("addView", "(Landroid/view/View;I)V", "GetAddView_Landroid_view_View_IHandler")]
		public unsafe virtual void AddView(View? child, int index)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(index);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addView.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAssertInLayoutOrScroll_Ljava_lang_String_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_AssertInLayoutOrScroll_Ljava_lang_String_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AssertInLayoutOrScroll_Ljava_lang_String_(nint jnienv, nint native__this, nint native_message)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string message = JNIEnv.GetString(native_message, JniHandleOwnership.DoNotTransfer);
				layoutManager.AssertInLayoutOrScroll(message);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("assertInLayoutOrScroll", "(Ljava/lang/String;)V", "GetAssertInLayoutOrScroll_Ljava_lang_String_Handler")]
		public unsafe virtual void AssertInLayoutOrScroll(string? message)
		{
			nint num = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("assertInLayoutOrScroll.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetAssertNotInLayoutOrScroll_Ljava_lang_String_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_AssertNotInLayoutOrScroll_Ljava_lang_String_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AssertNotInLayoutOrScroll_Ljava_lang_String_(nint jnienv, nint native__this, nint native_message)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string message = JNIEnv.GetString(native_message, JniHandleOwnership.DoNotTransfer);
				layoutManager.AssertNotInLayoutOrScroll(message);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("assertNotInLayoutOrScroll", "(Ljava/lang/String;)V", "GetAssertNotInLayoutOrScroll_Ljava_lang_String_Handler")]
		public unsafe virtual void AssertNotInLayoutOrScroll(string? message)
		{
			nint num = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("assertNotInLayoutOrScroll.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		private static Delegate GetAttachView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_AttachView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AttachView_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.AttachView(child);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("attachView", "(Landroid/view/View;)V", "GetAttachView_Landroid_view_View_Handler")]
		public unsafe virtual void AttachView(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("attachView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAttachView_Landroid_view_View_IHandler()
		{
			return new global::_JniMarshal_PPLI_V(n_AttachView_Landroid_view_View_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AttachView_Landroid_view_View_I(nint jnienv, nint native__this, nint native_child, int index)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.AttachView(child, index);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("attachView", "(Landroid/view/View;I)V", "GetAttachView_Landroid_view_View_IHandler")]
		public unsafe virtual void AttachView(View child, int index)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(index);
				_members.InstanceMethods.InvokeVirtualVoidMethod("attachView.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetAttachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_Handler()
		{
			return new global::_JniMarshal_PPLIL_V(n_AttachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_AttachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_(nint jnienv, nint native__this, nint native_child, int index, nint native_lp)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				LayoutParams lp = Java.Lang.Object.GetObject<LayoutParams>(native_lp, JniHandleOwnership.DoNotTransfer);
				layoutManager.AttachView(child, index, lp);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("attachView", "(Landroid/view/View;ILandroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", "GetAttachView_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_LayoutParams_Handler")]
		public unsafe virtual void AttachView(View child, int index, LayoutParams? lp)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(index);
				ptr[2] = new JniArgumentValue(lp?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("attachView.(Landroid/view/View;ILandroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(lp);
			}
		}

		private static Delegate GetCalculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_CalculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_CalculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_child, nint native_outRect)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				Rect outRect = Java.Lang.Object.GetObject<Rect>(native_outRect, JniHandleOwnership.DoNotTransfer);
				layoutManager.CalculateItemDecorationsForChild(child, outRect);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("calculateItemDecorationsForChild", "(Landroid/view/View;Landroid/graphics/Rect;)V", "GetCalculateItemDecorationsForChild_Landroid_view_View_Landroid_graphics_Rect_Handler")]
		public unsafe virtual void CalculateItemDecorationsForChild(View child, Rect outRect)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(outRect?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("calculateItemDecorationsForChild.(Landroid/view/View;Landroid/graphics/Rect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(outRect);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_CanScrollHorizontally(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanScrollHorizontally() ? ((sbyte)1) : ((sbyte)0);
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

		[Register("canScrollHorizontally", "()Z", "GetCanScrollHorizontallyHandler")]
		public unsafe virtual bool CanScrollHorizontally()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canScrollHorizontally.()Z", this, null);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_CanScrollVertically(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanScrollVertically() ? ((sbyte)1) : ((sbyte)0);
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

		[Register("canScrollVertically", "()Z", "GetCanScrollVerticallyHandler")]
		public unsafe virtual bool CanScrollVertically()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("canScrollVertically.()Z", this, null);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_CheckLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_(nint jnienv, nint native__this, nint native_lp)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				LayoutParams lp = Java.Lang.Object.GetObject<LayoutParams>(native_lp, JniHandleOwnership.DoNotTransfer);
				return layoutManager.CheckLayoutParams(lp) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("checkLayoutParams", "(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)Z", "GetCheckLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_Handler")]
		public unsafe virtual bool CheckLayoutParams(LayoutParams? lp)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(lp?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("checkLayoutParams.(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(lp);
			}
		}

		[Register("chooseSize", "(III)I", "")]
		public unsafe static int ChooseSize(int spec, int desired, int min)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(spec);
			ptr[1] = new JniArgumentValue(desired);
			ptr[2] = new JniArgumentValue(min);
			return _members.StaticMethods.InvokeInt32Method("chooseSize.(III)I", ptr);
		}

		private static Delegate GetCollectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_Handler()
		{
			return new _JniMarshal_PPIILL_V(n_CollectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_CollectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_(nint jnienv, nint native__this, int dx, int dy, nint native_state, nint native_layoutPrefetchRegistry)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				ILayoutPrefetchRegistry layoutPrefetchRegistry = Java.Lang.Object.GetObject<ILayoutPrefetchRegistry>(native_layoutPrefetchRegistry, JniHandleOwnership.DoNotTransfer);
				layoutManager.CollectAdjacentPrefetchPositions(dx, dy, state, layoutPrefetchRegistry);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("collectAdjacentPrefetchPositions", "(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry;)V", "GetCollectAdjacentPrefetchPositions_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_Handler")]
		public unsafe virtual void CollectAdjacentPrefetchPositions(int dx, int dy, State? state, ILayoutPrefetchRegistry? layoutPrefetchRegistry)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(dx);
				ptr[1] = new JniArgumentValue(dy);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue((layoutPrefetchRegistry == null) ? IntPtr.Zero : ((Java.Lang.Object)layoutPrefetchRegistry).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("collectAdjacentPrefetchPositions.(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
				GC.KeepAlive(layoutPrefetchRegistry);
			}
		}

		private static Delegate GetCollectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_Handler()
		{
			return new global::_JniMarshal_PPIL_V(n_CollectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_CollectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_(nint jnienv, nint native__this, int adapterItemCount, nint native_layoutPrefetchRegistry)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ILayoutPrefetchRegistry layoutPrefetchRegistry = Java.Lang.Object.GetObject<ILayoutPrefetchRegistry>(native_layoutPrefetchRegistry, JniHandleOwnership.DoNotTransfer);
				layoutManager.CollectInitialPrefetchPositions(adapterItemCount, layoutPrefetchRegistry);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("collectInitialPrefetchPositions", "(ILandroidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry;)V", "GetCollectInitialPrefetchPositions_ILandroidx_recyclerview_widget_RecyclerView_LayoutManager_LayoutPrefetchRegistry_Handler")]
		public unsafe virtual void CollectInitialPrefetchPositions(int adapterItemCount, ILayoutPrefetchRegistry? layoutPrefetchRegistry)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(adapterItemCount);
				ptr[1] = new JniArgumentValue((layoutPrefetchRegistry == null) ? IntPtr.Zero : ((Java.Lang.Object)layoutPrefetchRegistry).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("collectInitialPrefetchPositions.(ILandroidx/recyclerview/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layoutPrefetchRegistry);
			}
		}

		private static Delegate GetComputeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_ComputeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_ComputeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.ComputeHorizontalScrollExtent(state);
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

		[Register("computeHorizontalScrollExtent", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeHorizontalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeHorizontalScrollExtent(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollExtent.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_ComputeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_ComputeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.ComputeHorizontalScrollOffset(state);
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

		[Register("computeHorizontalScrollOffset", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeHorizontalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeHorizontalScrollOffset(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollOffset.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_ComputeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_ComputeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.ComputeHorizontalScrollRange(state);
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

		[Register("computeHorizontalScrollRange", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeHorizontalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeHorizontalScrollRange(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollRange.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_ComputeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_ComputeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.ComputeVerticalScrollExtent(state);
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

		[Register("computeVerticalScrollExtent", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeVerticalScrollExtent_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeVerticalScrollExtent(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollExtent.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_ComputeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_ComputeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.ComputeVerticalScrollOffset(state);
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

		[Register("computeVerticalScrollOffset", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeVerticalScrollOffset_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeVerticalScrollOffset(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollOffset.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetComputeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_ComputeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_ComputeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.ComputeVerticalScrollRange(state);
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

		[Register("computeVerticalScrollRange", "(Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetComputeVerticalScrollRange_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ComputeVerticalScrollRange(State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollRange.(Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetDetachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_DetachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_DetachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_(nint jnienv, nint native__this, nint native_recycler)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				layoutManager.DetachAndScrapAttachedViews(recycler);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("detachAndScrapAttachedViews", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetDetachAndScrapAttachedViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void DetachAndScrapAttachedViews(Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("detachAndScrapAttachedViews.(Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetDetachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_DetachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_DetachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_(nint jnienv, nint native__this, nint native_child, nint native_recycler)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				layoutManager.DetachAndScrapView(child, recycler);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("detachAndScrapView", "(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetDetachAndScrapView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void DetachAndScrapView(View child, Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("detachAndScrapView.(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetDetachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			return new global::_JniMarshal_PPIL_V(n_DetachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_DetachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_(nint jnienv, nint native__this, int index, nint native_recycler)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				layoutManager.DetachAndScrapViewAt(index, recycler);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("detachAndScrapViewAt", "(ILandroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetDetachAndScrapViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void DetachAndScrapViewAt(int index, Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(index);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("detachAndScrapViewAt.(ILandroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetDetachView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_DetachView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_DetachView_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.DetachView(child);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("detachView", "(Landroid/view/View;)V", "GetDetachView_Landroid_view_View_Handler")]
		public unsafe virtual void DetachView(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("detachView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetDetachViewAt_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_DetachViewAt_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_DetachViewAt_I(nint jnienv, nint native__this, int index)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DetachViewAt(index);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("detachViewAt", "(I)V", "GetDetachViewAt_IHandler")]
		public unsafe virtual void DetachViewAt(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			_members.InstanceMethods.InvokeVirtualVoidMethod("detachViewAt.(I)V", this, ptr);
		}

		private static Delegate GetEndAnimation_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_EndAnimation_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_EndAnimation_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				layoutManager.EndAnimation(view);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("endAnimation", "(Landroid/view/View;)V", "GetEndAnimation_Landroid_view_View_Handler")]
		public unsafe virtual void EndAnimation(View? view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("endAnimation.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetFindContainingItemView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_FindContainingItemView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_FindContainingItemView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(layoutManager.FindContainingItemView(view));
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

		[Register("findContainingItemView", "(Landroid/view/View;)Landroid/view/View;", "GetFindContainingItemView_Landroid_view_View_Handler")]
		public unsafe virtual View? FindContainingItemView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findContainingItemView.(Landroid/view/View;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetFindViewByPosition_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_FindViewByPosition_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_FindViewByPosition_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewByPosition(position));
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

		[Register("findViewByPosition", "(I)Landroid/view/View;", "GetFindViewByPosition_IHandler")]
		public unsafe virtual View? FindViewByPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewByPosition.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GenerateDefaultLayoutParams(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GenerateDefaultLayoutParams());
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

		[Register("generateDefaultLayoutParams", "()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateDefaultLayoutParamsHandler")]
		public abstract LayoutParams? GenerateDefaultLayoutParams();

		private static Delegate GetGenerateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_Handler()
		{
			return new global::_JniMarshal_PPLL_L(n_GenerateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GenerateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_(nint jnienv, nint native__this, nint native_c, nint native_attrs)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Context c = Java.Lang.Object.GetObject<Context>(native_c, JniHandleOwnership.DoNotTransfer);
				IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(layoutManager.GenerateLayoutParams(c, attrs));
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

		[Register("generateLayoutParams", "(Landroid/content/Context;Landroid/util/AttributeSet;)Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateLayoutParams_Landroid_content_Context_Landroid_util_AttributeSet_Handler")]
		public unsafe virtual LayoutParams? GenerateLayoutParams(Context? c, IAttributeSet? attrs)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				return Java.Lang.Object.GetObject<LayoutParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("generateLayoutParams.(Landroid/content/Context;Landroid/util/AttributeSet;)Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(c);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams_Handler()
		{
			return new global::_JniMarshal_PPL_L(n_GenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams_(nint jnienv, nint native__this, nint native_lp)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewGroup.LayoutParams lp = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native_lp, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(layoutManager.GenerateLayoutParams(lp));
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

		[Register("generateLayoutParams", "(Landroid/view/ViewGroup$LayoutParams;)Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateLayoutParams_Landroid_view_ViewGroup_LayoutParams_Handler")]
		public unsafe virtual LayoutParams? GenerateLayoutParams(ViewGroup.LayoutParams? lp)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(lp?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LayoutParams>(_members.InstanceMethods.InvokeVirtualObjectMethod("generateLayoutParams.(Landroid/view/ViewGroup$LayoutParams;)Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(lp);
			}
		}

		private static Delegate GetGetBottomDecorationHeight_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetBottomDecorationHeight_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetBottomDecorationHeight_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetBottomDecorationHeight(child);
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

		[Register("getBottomDecorationHeight", "(Landroid/view/View;)I", "GetGetBottomDecorationHeight_Landroid_view_View_Handler")]
		public unsafe virtual int GetBottomDecorationHeight(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBottomDecorationHeight.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetChildAt_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_GetChildAt_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetChildAt_I(nint jnienv, nint native__this, int index)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetChildAt(index));
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

		[Register("getChildAt", "(I)Landroid/view/View;", "GetGetChildAt_IHandler")]
		public unsafe virtual View? GetChildAt(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChildAt.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("getChildMeasureSpec", "(IIIZ)I", "")]
		public unsafe static int GetChildMeasureSpec(int parentSize, int padding, int childDimension, bool canScroll)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(parentSize);
			ptr[1] = new JniArgumentValue(padding);
			ptr[2] = new JniArgumentValue(childDimension);
			ptr[3] = new JniArgumentValue(canScroll ? ((sbyte)1) : ((sbyte)0));
			return _members.StaticMethods.InvokeInt32Method("getChildMeasureSpec.(IIIZ)I", ptr);
		}

		[Register("getChildMeasureSpec", "(IIIIZ)I", "")]
		public unsafe static int GetChildMeasureSpec(int parentSize, int parentMode, int padding, int childDimension, bool canScroll)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(parentSize);
			ptr[1] = new JniArgumentValue(parentMode);
			ptr[2] = new JniArgumentValue(padding);
			ptr[3] = new JniArgumentValue(childDimension);
			ptr[4] = new JniArgumentValue(canScroll ? ((sbyte)1) : ((sbyte)0));
			return _members.StaticMethods.InvokeInt32Method("getChildMeasureSpec.(IIIIZ)I", ptr);
		}

		private static Delegate GetGetColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPLL_I(n_GetColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_recycler, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetColumnCountForAccessibility(recycler, state);
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

		[Register("getColumnCountForAccessibility", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetGetColumnCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int GetColumnCountForAccessibility(Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getColumnCountForAccessibility.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetGetDecoratedBottom_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetDecoratedBottom_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetDecoratedBottom_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetDecoratedBottom(child);
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

		[Register("getDecoratedBottom", "(Landroid/view/View;)I", "GetGetDecoratedBottom_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedBottom(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedBottom.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_view, nint native_outBounds)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				Rect outBounds = Java.Lang.Object.GetObject<Rect>(native_outBounds, JniHandleOwnership.DoNotTransfer);
				layoutManager.GetDecoratedBoundsWithMargins(view, outBounds);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("getDecoratedBoundsWithMargins", "(Landroid/view/View;Landroid/graphics/Rect;)V", "GetGetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_Handler")]
		public unsafe virtual void GetDecoratedBoundsWithMargins(View view, Rect outBounds)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(outBounds?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getDecoratedBoundsWithMargins.(Landroid/view/View;Landroid/graphics/Rect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
				GC.KeepAlive(outBounds);
			}
		}

		private static Delegate GetGetDecoratedLeft_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetDecoratedLeft_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetDecoratedLeft_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetDecoratedLeft(child);
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

		[Register("getDecoratedLeft", "(Landroid/view/View;)I", "GetGetDecoratedLeft_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedLeft(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedLeft.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedMeasuredHeight_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetDecoratedMeasuredHeight_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetDecoratedMeasuredHeight_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetDecoratedMeasuredHeight(child);
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

		[Register("getDecoratedMeasuredHeight", "(Landroid/view/View;)I", "GetGetDecoratedMeasuredHeight_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedMeasuredHeight(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedMeasuredHeight.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedMeasuredWidth_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetDecoratedMeasuredWidth_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetDecoratedMeasuredWidth_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetDecoratedMeasuredWidth(child);
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

		[Register("getDecoratedMeasuredWidth", "(Landroid/view/View;)I", "GetGetDecoratedMeasuredWidth_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedMeasuredWidth(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedMeasuredWidth.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedRight_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetDecoratedRight_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetDecoratedRight_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetDecoratedRight(child);
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

		[Register("getDecoratedRight", "(Landroid/view/View;)I", "GetGetDecoratedRight_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedRight(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedRight.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetDecoratedTop_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetDecoratedTop_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetDecoratedTop_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetDecoratedTop(child);
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

		[Register("getDecoratedTop", "(Landroid/view/View;)I", "GetGetDecoratedTop_Landroid_view_View_Handler")]
		public unsafe virtual int GetDecoratedTop(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDecoratedTop.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetItemViewType_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetItemViewType_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetItemViewType_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetItemViewType(view);
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

		[Register("getItemViewType", "(Landroid/view/View;)I", "GetGetItemViewType_Landroid_view_View_Handler")]
		public unsafe virtual int GetItemViewType(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getItemViewType.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetGetLeftDecorationWidth_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetLeftDecorationWidth_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetLeftDecorationWidth_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetLeftDecorationWidth(child);
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

		[Register("getLeftDecorationWidth", "(Landroid/view/View;)I", "GetGetLeftDecorationWidth_Landroid_view_View_Handler")]
		public unsafe virtual int GetLeftDecorationWidth(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLeftDecorationWidth.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetPosition_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetPosition_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetPosition_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetPosition(view);
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

		[Register("getPosition", "(Landroid/view/View;)I", "GetGetPosition_Landroid_view_View_Handler")]
		public unsafe virtual int GetPosition(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getPosition.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Register("getProperties", "(Landroid/content/Context;Landroid/util/AttributeSet;II)Landroidx/recyclerview/widget/RecyclerView$LayoutManager$Properties;", "")]
		public unsafe static Properties? GetProperties(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
				ptr[2] = new JniArgumentValue(defStyleAttr);
				ptr[3] = new JniArgumentValue(defStyleRes);
				return Java.Lang.Object.GetObject<Properties>(_members.StaticMethods.InvokeObjectMethod("getProperties.(Landroid/content/Context;Landroid/util/AttributeSet;II)Landroidx/recyclerview/widget/RecyclerView$LayoutManager$Properties;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(attrs);
			}
		}

		private static Delegate GetGetRightDecorationWidth_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetRightDecorationWidth_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetRightDecorationWidth_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetRightDecorationWidth(child);
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

		[Register("getRightDecorationWidth", "(Landroid/view/View;)I", "GetGetRightDecorationWidth_Landroid_view_View_Handler")]
		public unsafe virtual int GetRightDecorationWidth(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRightDecorationWidth.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPLL_I(n_GetRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_recycler, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetRowCountForAccessibility(recycler, state);
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

		[Register("getRowCountForAccessibility", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetGetRowCountForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int GetRowCountForAccessibility(Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRowCountForAccessibility.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetGetSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPLL_I(n_GetSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_recycler, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetSelectionModeForAccessibility(recycler, state);
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

		[Register("getSelectionModeForAccessibility", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetGetSelectionModeForAccessibility_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int GetSelectionModeForAccessibility(Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getSelectionModeForAccessibility.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetGetTopDecorationHeight_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetTopDecorationHeight_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetTopDecorationHeight_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				return layoutManager.GetTopDecorationHeight(child);
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

		[Register("getTopDecorationHeight", "(Landroid/view/View;)I", "GetGetTopDecorationHeight_Landroid_view_View_Handler")]
		public unsafe virtual int GetTopDecorationHeight(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTopDecorationHeight.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetGetTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_Handler()
		{
			return new _JniMarshal_PPLBL_V(n_GetTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_GetTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_(nint jnienv, nint native__this, nint native_child, sbyte native_includeDecorInsets, nint native__out)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				bool includeDecorInsets = native_includeDecorInsets != 0;
				Rect rect = Java.Lang.Object.GetObject<Rect>(native__out, JniHandleOwnership.DoNotTransfer);
				layoutManager.GetTransformedBoundingBox(child, includeDecorInsets, rect);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("getTransformedBoundingBox", "(Landroid/view/View;ZLandroid/graphics/Rect;)V", "GetGetTransformedBoundingBox_Landroid_view_View_ZLandroid_graphics_Rect_Handler")]
		public unsafe virtual void GetTransformedBoundingBox(View child, bool includeDecorInsets, Rect @out)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(includeDecorInsets ? ((sbyte)1) : ((sbyte)0));
				ptr[2] = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("getTransformedBoundingBox.(Landroid/view/View;ZLandroid/graphics/Rect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(@out);
			}
		}

		private static Delegate GetIgnoreView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_IgnoreView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_IgnoreView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				layoutManager.IgnoreView(view);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("ignoreView", "(Landroid/view/View;)V", "GetIgnoreView_Landroid_view_View_Handler")]
		public unsafe virtual void IgnoreView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("ignoreView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetIsLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_IsLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_recycler, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.IsLayoutHierarchical(recycler, state) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("isLayoutHierarchical", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)Z", "GetIsLayoutHierarchical_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual bool IsLayoutHierarchical(Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutHierarchical.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetIsViewPartiallyVisible_Landroid_view_View_ZZHandler()
		{
			return new _JniMarshal_PPLBB_B(n_IsViewPartiallyVisible_Landroid_view_View_ZZ);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsViewPartiallyVisible_Landroid_view_View_ZZ(nint jnienv, nint native__this, nint native_child, sbyte native_completelyVisible, sbyte native_acceptEndPointInclusion)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				bool completelyVisible = native_completelyVisible != 0;
				bool acceptEndPointInclusion = native_acceptEndPointInclusion != 0;
				return layoutManager.IsViewPartiallyVisible(child, completelyVisible, acceptEndPointInclusion) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("isViewPartiallyVisible", "(Landroid/view/View;ZZ)Z", "GetIsViewPartiallyVisible_Landroid_view_View_ZZHandler")]
		public unsafe virtual bool IsViewPartiallyVisible(View child, bool completelyVisible, bool acceptEndPointInclusion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(completelyVisible ? ((sbyte)1) : ((sbyte)0));
				ptr[2] = new JniArgumentValue(acceptEndPointInclusion ? ((sbyte)1) : ((sbyte)0));
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isViewPartiallyVisible.(Landroid/view/View;ZZ)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetLayoutDecorated_Landroid_view_View_IIIIHandler()
		{
			return new global::_JniMarshal_PPLIIII_V(n_LayoutDecorated_Landroid_view_View_IIII);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_LayoutDecorated_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_child, int left, int top, int right, int bottom)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.LayoutDecorated(child, left, top, right, bottom);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("layoutDecorated", "(Landroid/view/View;IIII)V", "GetLayoutDecorated_Landroid_view_View_IIIIHandler")]
		public unsafe virtual void LayoutDecorated(View child, int left, int top, int right, int bottom)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(left);
				ptr[2] = new JniArgumentValue(top);
				ptr[3] = new JniArgumentValue(right);
				ptr[4] = new JniArgumentValue(bottom);
				_members.InstanceMethods.InvokeVirtualVoidMethod("layoutDecorated.(Landroid/view/View;IIII)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetLayoutDecoratedWithMargins_Landroid_view_View_IIIIHandler()
		{
			return new global::_JniMarshal_PPLIIII_V(n_LayoutDecoratedWithMargins_Landroid_view_View_IIII);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_LayoutDecoratedWithMargins_Landroid_view_View_IIII(nint jnienv, nint native__this, nint native_child, int left, int top, int right, int bottom)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.LayoutDecoratedWithMargins(child, left, top, right, bottom);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("layoutDecoratedWithMargins", "(Landroid/view/View;IIII)V", "GetLayoutDecoratedWithMargins_Landroid_view_View_IIIIHandler")]
		public unsafe virtual void LayoutDecoratedWithMargins(View child, int left, int top, int right, int bottom)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(left);
				ptr[2] = new JniArgumentValue(top);
				ptr[3] = new JniArgumentValue(right);
				ptr[4] = new JniArgumentValue(bottom);
				_members.InstanceMethods.InvokeVirtualVoidMethod("layoutDecoratedWithMargins.(Landroid/view/View;IIII)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetMeasureChild_Landroid_view_View_IIHandler()
		{
			return new global::_JniMarshal_PPLII_V(n_MeasureChild_Landroid_view_View_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_MeasureChild_Landroid_view_View_II(nint jnienv, nint native__this, nint native_child, int widthUsed, int heightUsed)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.MeasureChild(child, widthUsed, heightUsed);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("measureChild", "(Landroid/view/View;II)V", "GetMeasureChild_Landroid_view_View_IIHandler")]
		public unsafe virtual void MeasureChild(View child, int widthUsed, int heightUsed)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(widthUsed);
				ptr[2] = new JniArgumentValue(heightUsed);
				_members.InstanceMethods.InvokeVirtualVoidMethod("measureChild.(Landroid/view/View;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetMeasureChildWithMargins_Landroid_view_View_IIHandler()
		{
			return new global::_JniMarshal_PPLII_V(n_MeasureChildWithMargins_Landroid_view_View_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_MeasureChildWithMargins_Landroid_view_View_II(nint jnienv, nint native__this, nint native_child, int widthUsed, int heightUsed)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.MeasureChildWithMargins(child, widthUsed, heightUsed);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("measureChildWithMargins", "(Landroid/view/View;II)V", "GetMeasureChildWithMargins_Landroid_view_View_IIHandler")]
		public unsafe virtual void MeasureChildWithMargins(View child, int widthUsed, int heightUsed)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(widthUsed);
				ptr[2] = new JniArgumentValue(heightUsed);
				_members.InstanceMethods.InvokeVirtualVoidMethod("measureChildWithMargins.(Landroid/view/View;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetMoveView_IIHandler()
		{
			return new global::_JniMarshal_PPII_V(n_MoveView_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_MoveView_II(nint jnienv, nint native__this, int fromIndex, int toIndex)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MoveView(fromIndex, toIndex);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("moveView", "(II)V", "GetMoveView_IIHandler")]
		public unsafe virtual void MoveView(int fromIndex, int toIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(fromIndex);
			ptr[1] = new JniArgumentValue(toIndex);
			_members.InstanceMethods.InvokeVirtualVoidMethod("moveView.(II)V", this, ptr);
		}

		private static Delegate GetOffsetChildrenHorizontal_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_OffsetChildrenHorizontal_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OffsetChildrenHorizontal_I(nint jnienv, nint native__this, int dx)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetChildrenHorizontal(dx);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("offsetChildrenHorizontal", "(I)V", "GetOffsetChildrenHorizontal_IHandler")]
		public unsafe virtual void OffsetChildrenHorizontal(int dx)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dx);
			_members.InstanceMethods.InvokeVirtualVoidMethod("offsetChildrenHorizontal.(I)V", this, ptr);
		}

		private static Delegate GetOffsetChildrenVertical_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_OffsetChildrenVertical_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OffsetChildrenVertical_I(nint jnienv, nint native__this, int dy)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetChildrenVertical(dy);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("offsetChildrenVertical", "(I)V", "GetOffsetChildrenVertical_IHandler")]
		public unsafe virtual void OffsetChildrenVertical(int dy)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(dy);
			_members.InstanceMethods.InvokeVirtualVoidMethod("offsetChildrenVertical.(I)V", this, ptr);
		}

		private static Delegate GetOnAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_(nint jnienv, nint native__this, nint native_oldAdapter, nint native_newAdapter)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Adapter oldAdapter = Java.Lang.Object.GetObject<Adapter>(native_oldAdapter, JniHandleOwnership.DoNotTransfer);
				Adapter newAdapter = Java.Lang.Object.GetObject<Adapter>(native_newAdapter, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnAdapterChanged(oldAdapter, newAdapter);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onAdapterChanged", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", "GetOnAdapterChanged_Landroidx_recyclerview_widget_RecyclerView_Adapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Handler")]
		public unsafe virtual void OnAdapterChanged(Adapter? oldAdapter, Adapter? newAdapter)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(oldAdapter?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newAdapter?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAdapterChanged.(Landroidx/recyclerview/widget/RecyclerView$Adapter;Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(oldAdapter);
				GC.KeepAlive(newAdapter);
			}
		}

		private static Delegate GetOnAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_IIHandler()
		{
			return new global::_JniMarshal_PPLLII_B(n_OnAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_II(nint jnienv, nint native__this, nint native_recyclerView, nint native_views, int direction, int focusableMode)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
				return layoutManager.OnAddFocusables(recyclerView, views, direction, focusableMode) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onAddFocusables", "(Landroidx/recyclerview/widget/RecyclerView;Ljava/util/ArrayList;II)Z", "GetOnAddFocusables_Landroidx_recyclerview_widget_RecyclerView_Ljava_util_ArrayList_IIHandler")]
		public unsafe virtual bool OnAddFocusables(RecyclerView recyclerView, IList<View> views, int direction, int focusableMode)
		{
			nint num = JavaList<View>.ToLocalJniHandle(views);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(num);
				ptr[2] = new JniArgumentValue(direction);
				ptr[3] = new JniArgumentValue(focusableMode);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onAddFocusables.(Landroidx/recyclerview/widget/RecyclerView;Ljava/util/ArrayList;II)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(views);
			}
		}

		private static Delegate GetOnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView view = Java.Lang.Object.GetObject<RecyclerView>(native_view, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnAttachedToWindow(view);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onAttachedToWindow", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnAttachedToWindow_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnAttachedToWindow(RecyclerView? view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onAttachedToWindow.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Obsolete]
		private static Delegate GetOnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView view = Java.Lang.Object.GetObject<RecyclerView>(native_view, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnDetachedFromWindow(view);
			}
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
		[Register("onDetachedFromWindow", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnDetachedFromWindow(RecyclerView? view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromWindow.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		private static Delegate GetOnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_(nint jnienv, nint native__this, nint native_view, nint native_recycler)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView view = Java.Lang.Object.GetObject<RecyclerView>(native_view, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnDetachedFromWindow(view, recycler);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onDetachedFromWindow", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetOnDetachedFromWindow_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void OnDetachedFromWindow(RecyclerView? view, Recycler? recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onDetachedFromWindow.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetOnFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new _JniMarshal_PPLILL_L(n_OnFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_OnFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_focused, int direction, nint native_recycler, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(layoutManager.OnFocusSearchFailed(focused, direction, recycler, state));
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

		[Register("onFocusSearchFailed", "(Landroid/view/View;ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)Landroid/view/View;", "GetOnFocusSearchFailed_Landroid_view_View_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual View? OnFocusSearchFailed(View focused, int direction, Recycler recycler, State state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(direction);
				ptr[2] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onFocusSearchFailed.(Landroid/view/View;ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(focused);
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_(nint jnienv, nint native__this, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnInitializeAccessibilityEvent(e);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onInitializeAccessibilityEvent", "(Landroid/view/accessibility/AccessibilityEvent;)V", "GetOnInitializeAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_Handler")]
		public unsafe virtual void OnInitializeAccessibilityEvent(AccessibilityEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityEvent.(Landroid/view/accessibility/AccessibilityEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_(nint jnienv, nint native__this, nint native_recycler, nint native_state, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				AccessibilityEvent e = Java.Lang.Object.GetObject<AccessibilityEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnInitializeAccessibilityEvent(recycler, state, e);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onInitializeAccessibilityEvent", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/accessibility/AccessibilityEvent;)V", "GetOnInitializeAccessibilityEvent_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_accessibility_AccessibilityEvent_Handler")]
		public unsafe virtual void OnInitializeAccessibilityEvent(Recycler recycler, State state, AccessibilityEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityEvent.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/accessibility/AccessibilityEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_(nint jnienv, nint native__this, nint native_recycler, nint native_state, nint native_info)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				AccessibilityNodeInfoCompat info = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(native_info, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnInitializeAccessibilityNodeInfo(recycler, state, info);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onInitializeAccessibilityNodeInfo", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", "GetOnInitializeAccessibilityNodeInfo_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler")]
		public unsafe virtual void OnInitializeAccessibilityNodeInfo(Recycler recycler, State state, AccessibilityNodeInfoCompat info)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityNodeInfo.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(info);
			}
		}

		private static Delegate GetOnInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler()
		{
			return new global::_JniMarshal_PPLLLL_V(n_OnInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_(nint jnienv, nint native__this, nint native_recycler, nint native_state, nint native_host, nint native_info)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				View host = Java.Lang.Object.GetObject<View>(native_host, JniHandleOwnership.DoNotTransfer);
				AccessibilityNodeInfoCompat info = Java.Lang.Object.GetObject<AccessibilityNodeInfoCompat>(native_info, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnInitializeAccessibilityNodeInfoForItem(recycler, state, host, info);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onInitializeAccessibilityNodeInfoForItem", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", "GetOnInitializeAccessibilityNodeInfoForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler")]
		public unsafe virtual void OnInitializeAccessibilityNodeInfoForItem(Recycler recycler, State state, View host, AccessibilityNodeInfoCompat info)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(host?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(info?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onInitializeAccessibilityNodeInfoForItem.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(host);
				GC.KeepAlive(info);
			}
		}

		private static Delegate GetOnInterceptFocusSearch_Landroid_view_View_IHandler()
		{
			return new global::_JniMarshal_PPLI_L(n_OnInterceptFocusSearch_Landroid_view_View_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_OnInterceptFocusSearch_Landroid_view_View_I(nint jnienv, nint native__this, nint native_focused, int direction)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(layoutManager.OnInterceptFocusSearch(focused, direction));
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

		[Register("onInterceptFocusSearch", "(Landroid/view/View;I)Landroid/view/View;", "GetOnInterceptFocusSearch_Landroid_view_View_IHandler")]
		public unsafe virtual View? OnInterceptFocusSearch(View focused, int direction)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(direction);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("onInterceptFocusSearch.(Landroid/view/View;I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(focused);
			}
		}

		private static Delegate GetOnItemsAdded_Landroidx_recyclerview_widget_RecyclerView_IIHandler()
		{
			return new global::_JniMarshal_PPLII_V(n_OnItemsAdded_Landroidx_recyclerview_widget_RecyclerView_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemsAdded_Landroidx_recyclerview_widget_RecyclerView_II(nint jnienv, nint native__this, nint native_recyclerView, int positionStart, int itemCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnItemsAdded(recyclerView, positionStart, itemCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemsAdded", "(Landroidx/recyclerview/widget/RecyclerView;II)V", "GetOnItemsAdded_Landroidx_recyclerview_widget_RecyclerView_IIHandler")]
		public unsafe virtual void OnItemsAdded(RecyclerView recyclerView, int positionStart, int itemCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(positionStart);
				ptr[2] = new JniArgumentValue(itemCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsAdded.(Landroidx/recyclerview/widget/RecyclerView;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsChanged_Landroidx_recyclerview_widget_RecyclerView_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnItemsChanged_Landroidx_recyclerview_widget_RecyclerView_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemsChanged_Landroidx_recyclerview_widget_RecyclerView_(nint jnienv, nint native__this, nint native_recyclerView)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnItemsChanged(recyclerView);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemsChanged", "(Landroidx/recyclerview/widget/RecyclerView;)V", "GetOnItemsChanged_Landroidx_recyclerview_widget_RecyclerView_Handler")]
		public unsafe virtual void OnItemsChanged(RecyclerView recyclerView)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsChanged.(Landroidx/recyclerview/widget/RecyclerView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsMoved_Landroidx_recyclerview_widget_RecyclerView_IIIHandler()
		{
			return new global::_JniMarshal_PPLIII_V(n_OnItemsMoved_Landroidx_recyclerview_widget_RecyclerView_III);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemsMoved_Landroidx_recyclerview_widget_RecyclerView_III(nint jnienv, nint native__this, nint native_recyclerView, int from, int to, int itemCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnItemsMoved(recyclerView, from, to, itemCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemsMoved", "(Landroidx/recyclerview/widget/RecyclerView;III)V", "GetOnItemsMoved_Landroidx_recyclerview_widget_RecyclerView_IIIHandler")]
		public unsafe virtual void OnItemsMoved(RecyclerView recyclerView, int from, int to, int itemCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(from);
				ptr[2] = new JniArgumentValue(to);
				ptr[3] = new JniArgumentValue(itemCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsMoved.(Landroidx/recyclerview/widget/RecyclerView;III)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_IIHandler()
		{
			return new global::_JniMarshal_PPLII_V(n_OnItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_II(nint jnienv, nint native__this, nint native_recyclerView, int positionStart, int itemCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnItemsRemoved(recyclerView, positionStart, itemCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemsRemoved", "(Landroidx/recyclerview/widget/RecyclerView;II)V", "GetOnItemsRemoved_Landroidx_recyclerview_widget_RecyclerView_IIHandler")]
		public unsafe virtual void OnItemsRemoved(RecyclerView recyclerView, int positionStart, int itemCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(positionStart);
				ptr[2] = new JniArgumentValue(itemCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsRemoved.(Landroidx/recyclerview/widget/RecyclerView;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IIHandler()
		{
			return new global::_JniMarshal_PPLII_V(n_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_II(nint jnienv, nint native__this, nint native_recyclerView, int positionStart, int itemCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnItemsUpdated(recyclerView, positionStart, itemCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemsUpdated", "(Landroidx/recyclerview/widget/RecyclerView;II)V", "GetOnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IIHandler")]
		public unsafe virtual void OnItemsUpdated(RecyclerView recyclerView, int positionStart, int itemCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(positionStart);
				ptr[2] = new JniArgumentValue(itemCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsUpdated.(Landroidx/recyclerview/widget/RecyclerView;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		private static Delegate GetOnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_Handler()
		{
			return new global::_JniMarshal_PPLIIL_V(n_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_(nint jnienv, nint native__this, nint native_recyclerView, int positionStart, int itemCount, nint native_payload)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object payload = Java.Lang.Object.GetObject<Java.Lang.Object>(native_payload, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnItemsUpdated(recyclerView, positionStart, itemCount, payload);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onItemsUpdated", "(Landroidx/recyclerview/widget/RecyclerView;IILjava/lang/Object;)V", "GetOnItemsUpdated_Landroidx_recyclerview_widget_RecyclerView_IILjava_lang_Object_Handler")]
		public unsafe virtual void OnItemsUpdated(RecyclerView recyclerView, int positionStart, int itemCount, Java.Lang.Object? payload)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(positionStart);
				ptr[2] = new JniArgumentValue(itemCount);
				ptr[3] = new JniArgumentValue(payload?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsUpdated.(Landroidx/recyclerview/widget/RecyclerView;IILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(payload);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_recycler, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnLayoutChildren(recycler, state);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onLayoutChildren", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetOnLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void OnLayoutChildren(Recycler? recycler, State? state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLayoutChildren.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnLayoutCompleted(state);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onLayoutCompleted", "(Landroidx/recyclerview/widget/RecyclerView$State;)V", "GetOnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual void OnLayoutCompleted(State? state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onLayoutCompleted.(Landroidx/recyclerview/widget/RecyclerView$State;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_IIHandler()
		{
			return new global::_JniMarshal_PPLLII_V(n_OnMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_II(nint jnienv, nint native__this, nint native_recycler, nint native_state, int widthSpec, int heightSpec)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnMeasure(recycler, state, widthSpec, heightSpec);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onMeasure", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;II)V", "GetOnMeasure_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_IIHandler")]
		public unsafe virtual void OnMeasure(Recycler recycler, State state, int widthSpec, int heightSpec)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(widthSpec);
				ptr[3] = new JniArgumentValue(heightSpec);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onMeasure.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		[Obsolete]
		private static Delegate GetOnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLLL_B(n_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_focused)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
				return layoutManager.OnRequestChildFocus(parent, child, focused) ? ((sbyte)1) : ((sbyte)0);
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

		[Obsolete("deprecated")]
		[Register("onRequestChildFocus", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/view/View;)Z", "GetOnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_view_View_Handler")]
		public unsafe virtual bool OnRequestChildFocus(RecyclerView parent, View child, View? focused)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onRequestChildFocus.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(focused);
			}
		}

		private static Delegate GetOnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPLLLL_B(n_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_(nint jnienv, nint native__this, nint native_parent, nint native_state, nint native_child, nint native_focused)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				View focused = Java.Lang.Object.GetObject<View>(native_focused, JniHandleOwnership.DoNotTransfer);
				return layoutManager.OnRequestChildFocus(parent, state, child, focused) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onRequestChildFocus", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;Landroid/view/View;)Z", "GetOnRequestChildFocus_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_Landroid_view_View_Handler")]
		public unsafe virtual bool OnRequestChildFocus(RecyclerView parent, State state, View child, View? focused)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(focused?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onRequestChildFocus.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;Landroid/view/View;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(state);
				GC.KeepAlive(child);
				GC.KeepAlive(focused);
			}
		}

		private static Delegate GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnRestoreInstanceState_Landroid_os_Parcelable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnRestoreInstanceState_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
				layoutManager.OnRestoreInstanceState(state);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onRestoreInstanceState", "(Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler")]
		public unsafe virtual void OnRestoreInstanceState(IParcelable? state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroid/os/Parcelable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnSaveInstanceStateHandler()
		{
			return new global::_JniMarshal_PP_L(n_OnSaveInstanceState);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_OnSaveInstanceState(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
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

		[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler")]
		public unsafe virtual IParcelable? OnSaveInstanceState()
		{
			return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetOnScrollStateChanged_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_OnScrollStateChanged_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnScrollStateChanged_I(nint jnienv, nint native__this, int state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScrollStateChanged(state);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onScrollStateChanged", "(I)V", "GetOnScrollStateChanged_IHandler")]
		public unsafe virtual void OnScrollStateChanged(int state)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onScrollStateChanged.(I)V", this, ptr);
		}

		private static Delegate GetPerformAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_Handler()
		{
			return new global::_JniMarshal_PPLLIL_B(n_PerformAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_PerformAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_recycler, nint native_state, int action, nint native_args)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				Bundle args = Java.Lang.Object.GetObject<Bundle>(native_args, JniHandleOwnership.DoNotTransfer);
				return layoutManager.PerformAccessibilityAction(recycler, state, action, args) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("performAccessibilityAction", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;ILandroid/os/Bundle;)Z", "GetPerformAccessibilityAction_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_ILandroid_os_Bundle_Handler")]
		public unsafe virtual bool PerformAccessibilityAction(Recycler recycler, State state, int action, Bundle? args)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(action);
				ptr[3] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("performAccessibilityAction.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;ILandroid/os/Bundle;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(args);
			}
		}

		private static Delegate GetPerformAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_Handler()
		{
			return new global::_JniMarshal_PPLLLIL_B(n_PerformAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_PerformAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_recycler, nint native_state, nint native_view, int action, nint native_args)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				Bundle args = Java.Lang.Object.GetObject<Bundle>(native_args, JniHandleOwnership.DoNotTransfer);
				return layoutManager.PerformAccessibilityActionForItem(recycler, state, view, action, args) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("performAccessibilityActionForItem", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;ILandroid/os/Bundle;)Z", "GetPerformAccessibilityActionForItem_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Landroid_view_View_ILandroid_os_Bundle_Handler")]
		public unsafe virtual bool PerformAccessibilityActionForItem(Recycler recycler, State state, View view, int action, Bundle? args)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(action);
				ptr[4] = new JniArgumentValue(args?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("performAccessibilityActionForItem.(Landroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;Landroid/view/View;ILandroid/os/Bundle;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
				GC.KeepAlive(view);
				GC.KeepAlive(args);
			}
		}

		private static Delegate GetPostOnAnimation_Ljava_lang_Runnable_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_PostOnAnimation_Ljava_lang_Runnable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_PostOnAnimation_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_action)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IRunnable action = Java.Lang.Object.GetObject<IRunnable>(native_action, JniHandleOwnership.DoNotTransfer);
				layoutManager.PostOnAnimation(action);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("postOnAnimation", "(Ljava/lang/Runnable;)V", "GetPostOnAnimation_Ljava_lang_Runnable_Handler")]
		public unsafe virtual void PostOnAnimation(IRunnable? action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("postOnAnimation.(Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(action);
			}
		}

		private static Delegate GetRemoveAllViewsHandler()
		{
			return new global::_JniMarshal_PP_V(n_RemoveAllViews);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RemoveAllViews(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllViews();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("removeAllViews", "()V", "GetRemoveAllViewsHandler")]
		public unsafe virtual void RemoveAllViews()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeAllViews.()V", this, null);
		}

		private static Delegate GetRemoveAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_RemoveAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RemoveAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_(nint jnienv, nint native__this, nint native_recycler)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				layoutManager.RemoveAndRecycleAllViews(recycler);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("removeAndRecycleAllViews", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetRemoveAndRecycleAllViews_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void RemoveAndRecycleAllViews(Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeAndRecycleAllViews.(Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetRemoveAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_RemoveAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RemoveAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_(nint jnienv, nint native__this, nint native_child, nint native_recycler)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				layoutManager.RemoveAndRecycleView(child, recycler);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("removeAndRecycleView", "(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetRemoveAndRecycleView_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void RemoveAndRecycleView(View child, Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeAndRecycleView.(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetRemoveAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Handler()
		{
			return new global::_JniMarshal_PPIL_V(n_RemoveAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RemoveAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_(nint jnienv, nint native__this, int index, nint native_recycler)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				layoutManager.RemoveAndRecycleViewAt(index, recycler);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("removeAndRecycleViewAt", "(ILandroidx/recyclerview/widget/RecyclerView$Recycler;)V", "GetRemoveAndRecycleViewAt_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Handler")]
		public unsafe virtual void RemoveAndRecycleViewAt(int index, Recycler recycler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(index);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeAndRecycleViewAt.(ILandroidx/recyclerview/widget/RecyclerView$Recycler;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}

		private static Delegate GetRemoveCallbacks_Ljava_lang_Runnable_Handler()
		{
			return new global::_JniMarshal_PPL_B(n_RemoveCallbacks_Ljava_lang_Runnable_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_RemoveCallbacks_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_action)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IRunnable action = Java.Lang.Object.GetObject<IRunnable>(native_action, JniHandleOwnership.DoNotTransfer);
				return layoutManager.RemoveCallbacks(action) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("removeCallbacks", "(Ljava/lang/Runnable;)Z", "GetRemoveCallbacks_Ljava_lang_Runnable_Handler")]
		public unsafe virtual bool RemoveCallbacks(IRunnable? action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeCallbacks.(Ljava/lang/Runnable;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(action);
			}
		}

		private static Delegate GetRemoveDetachedView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_RemoveDetachedView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RemoveDetachedView_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.RemoveDetachedView(child);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("removeDetachedView", "(Landroid/view/View;)V", "GetRemoveDetachedView_Landroid_view_View_Handler")]
		public unsafe virtual void RemoveDetachedView(View child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeDetachedView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetRemoveView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_RemoveView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RemoveView_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				layoutManager.RemoveView(child);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("removeView", "(Landroid/view/View;)V", "GetRemoveView_Landroid_view_View_Handler")]
		public unsafe virtual void RemoveView(View? child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetRemoveViewAt_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_RemoveViewAt_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RemoveViewAt_I(nint jnienv, nint native__this, int index)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveViewAt(index);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("removeViewAt", "(I)V", "GetRemoveViewAt_IHandler")]
		public unsafe virtual void RemoveViewAt(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeViewAt.(I)V", this, ptr);
		}

		private static Delegate GetRequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZHandler()
		{
			return new _JniMarshal_PPLLLB_B(n_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_Z(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_rect, sbyte native_immediate)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
				bool immediate = native_immediate != 0;
				return layoutManager.RequestChildRectangleOnScreen(parent, child, rect, immediate) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("requestChildRectangleOnScreen", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/graphics/Rect;Z)Z", "GetRequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZHandler")]
		public unsafe virtual bool RequestChildRectangleOnScreen(RecyclerView parent, View child, Rect rect, bool immediate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(immediate ? ((sbyte)1) : ((sbyte)0));
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("requestChildRectangleOnScreen.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/graphics/Rect;Z)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(rect);
			}
		}

		private static Delegate GetRequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZHandler()
		{
			return new _JniMarshal_PPLLLBB_B(n_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZ);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_RequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZ(nint jnienv, nint native__this, nint native_parent, nint native_child, nint native_rect, sbyte native_immediate, sbyte native_focusedChildVisible)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView parent = Java.Lang.Object.GetObject<RecyclerView>(native_parent, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
				bool immediate = native_immediate != 0;
				bool focusedChildVisible = native_focusedChildVisible != 0;
				return layoutManager.RequestChildRectangleOnScreen(parent, child, rect, immediate, focusedChildVisible) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("requestChildRectangleOnScreen", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/graphics/Rect;ZZ)Z", "GetRequestChildRectangleOnScreen_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_View_Landroid_graphics_Rect_ZZHandler")]
		public unsafe virtual bool RequestChildRectangleOnScreen(RecyclerView parent, View child, Rect rect, bool immediate, bool focusedChildVisible)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(immediate ? ((sbyte)1) : ((sbyte)0));
				ptr[4] = new JniArgumentValue(focusedChildVisible ? ((sbyte)1) : ((sbyte)0));
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("requestChildRectangleOnScreen.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/View;Landroid/graphics/Rect;ZZ)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(parent);
				GC.KeepAlive(child);
				GC.KeepAlive(rect);
			}
		}

		private static Delegate GetRequestLayoutHandler()
		{
			return new global::_JniMarshal_PP_V(n_RequestLayout);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RequestLayout(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestLayout();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("requestLayout", "()V", "GetRequestLayoutHandler")]
		public unsafe virtual void RequestLayout()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("requestLayout.()V", this, null);
		}

		private static Delegate GetRequestSimpleAnimationsInNextLayoutHandler()
		{
			return new global::_JniMarshal_PP_V(n_RequestSimpleAnimationsInNextLayout);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_RequestSimpleAnimationsInNextLayout(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestSimpleAnimationsInNextLayout();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("requestSimpleAnimationsInNextLayout", "()V", "GetRequestSimpleAnimationsInNextLayoutHandler")]
		public unsafe virtual void RequestSimpleAnimationsInNextLayout()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("requestSimpleAnimationsInNextLayout.()V", this, null);
		}

		private static Delegate GetScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler()
		{
			return new _JniMarshal_PPILL_I(n_ScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_ScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, int dx, nint native_recycler, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.ScrollHorizontallyBy(dx, recycler, state);
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

		[Register("scrollHorizontallyBy", "(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetScrollHorizontallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ScrollHorizontallyBy(int dx, Recycler? recycler, State? state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(dx);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("scrollHorizontallyBy.(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetScrollToPosition_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_ScrollToPosition_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_ScrollToPosition_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollToPosition(position);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("scrollToPosition", "(I)V", "GetScrollToPosition_IHandler")]
		public unsafe virtual void ScrollToPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("scrollToPosition.(I)V", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_ScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(nint jnienv, nint native__this, int dy, nint native_recycler, nint native_state)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				return layoutManager.ScrollVerticallyBy(dy, recycler, state);
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

		[Register("scrollVerticallyBy", "(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", "GetScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_Handler")]
		public unsafe virtual int ScrollVerticallyBy(int dy, Recycler? recycler, State? state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(dy);
				ptr[1] = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("scrollVerticallyBy.(ILandroidx/recyclerview/widget/RecyclerView$Recycler;Landroidx/recyclerview/widget/RecyclerView$State;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recycler);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetSetMeasuredDimension_Landroid_graphics_Rect_IIHandler()
		{
			return new global::_JniMarshal_PPLII_V(n_SetMeasuredDimension_Landroid_graphics_Rect_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetMeasuredDimension_Landroid_graphics_Rect_II(nint jnienv, nint native__this, nint native_childrenBounds, int wSpec, int hSpec)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Rect childrenBounds = Java.Lang.Object.GetObject<Rect>(native_childrenBounds, JniHandleOwnership.DoNotTransfer);
				layoutManager.SetMeasuredDimension(childrenBounds, wSpec, hSpec);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("setMeasuredDimension", "(Landroid/graphics/Rect;II)V", "GetSetMeasuredDimension_Landroid_graphics_Rect_IIHandler")]
		public unsafe virtual void SetMeasuredDimension(Rect? childrenBounds, int wSpec, int hSpec)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(childrenBounds?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(wSpec);
				ptr[2] = new JniArgumentValue(hSpec);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasuredDimension.(Landroid/graphics/Rect;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(childrenBounds);
			}
		}

		private static Delegate GetSetMeasuredDimension_IIHandler()
		{
			return new global::_JniMarshal_PPII_V(n_SetMeasuredDimension_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetMeasuredDimension_II(nint jnienv, nint native__this, int widthSize, int heightSize)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMeasuredDimension(widthSize, heightSize);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("setMeasuredDimension", "(II)V", "GetSetMeasuredDimension_IIHandler")]
		public unsafe virtual void SetMeasuredDimension(int widthSize, int heightSize)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(widthSize);
			ptr[1] = new JniArgumentValue(heightSize);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasuredDimension.(II)V", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SmoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I(nint jnienv, nint native__this, nint native_recyclerView, nint native_state, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				State state = Java.Lang.Object.GetObject<State>(native_state, JniHandleOwnership.DoNotTransfer);
				layoutManager.SmoothScrollToPosition(recyclerView, state, position);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("smoothScrollToPosition", "(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;I)V", "GetSmoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_IHandler")]
		public unsafe virtual void SmoothScrollToPosition(RecyclerView? recyclerView, State? state, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollToPosition.(Landroidx/recyclerview/widget/RecyclerView;Landroidx/recyclerview/widget/RecyclerView$State;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetStartSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_StartSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_StartSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_(nint jnienv, nint native__this, nint native_smoothScroller)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SmoothScroller smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(native_smoothScroller, JniHandleOwnership.DoNotTransfer);
				layoutManager.StartSmoothScroll(smoothScroller);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("startSmoothScroll", "(Landroidx/recyclerview/widget/RecyclerView$SmoothScroller;)V", "GetStartSmoothScroll_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Handler")]
		public unsafe virtual void StartSmoothScroll(SmoothScroller? smoothScroller)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(smoothScroller?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("startSmoothScroll.(Landroidx/recyclerview/widget/RecyclerView$SmoothScroller;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(smoothScroller);
			}
		}

		private static Delegate GetStopIgnoringView_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_StopIgnoringView_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_StopIgnoringView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				LayoutManager? layoutManager = Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				layoutManager.StopIgnoringView(view);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("stopIgnoringView", "(Landroid/view/View;)V", "GetStopIgnoringView_Landroid_view_View_Handler")]
		public unsafe virtual void StopIgnoringView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("stopIgnoringView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_SupportsPredictiveItemAnimations(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportsPredictiveItemAnimations() ? ((sbyte)1) : ((sbyte)0);
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

		[Register("supportsPredictiveItemAnimations", "()Z", "GetSupportsPredictiveItemAnimationsHandler")]
		public unsafe virtual bool SupportsPredictiveItemAnimations()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("supportsPredictiveItemAnimations.()Z", this, null);
		}

		[UnmanagedCallersOnly]
		private static nint n_GenerateDefaultLayoutParams_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_GenerateDefaultLayoutParams(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_IsAutoMeasureEnabled_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_IsAutoMeasureEnabled(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_SetAutoMeasureEnabled_Z_mm_wrapper(nint jnienv, nint native__this, sbyte native_enabled)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_SetAutoMeasureEnabled_Z(jnienv, native__this, native_enabled);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__mm_wrapper(nint jnienv, nint native__this, nint native_recycler, nint native_state)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnLayoutChildren_Landroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(jnienv, native__this, native_recycler, native_state);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_SmoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I_mm_wrapper(nint jnienv, nint native__this, nint native_recyclerView, nint native_state, int position)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_SmoothScrollToPosition_Landroidx_recyclerview_widget_RecyclerView_Landroidx_recyclerview_widget_RecyclerView_State_I(jnienv, native__this, native_recyclerView, native_state, position);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_CanScrollVertically_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_CanScrollVertically(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_CanScrollHorizontally_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_CanScrollHorizontally(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static int n_ScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State__mm_wrapper(nint jnienv, nint native__this, int dy, nint native_recycler, nint native_state)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_ScrollVerticallyBy_ILandroidx_recyclerview_widget_RecyclerView_Recycler_Landroidx_recyclerview_widget_RecyclerView_State_(jnienv, native__this, dy, native_recycler, native_state);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_SupportsPredictiveItemAnimations_mm_wrapper(nint jnienv, nint native__this)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_SupportsPredictiveItemAnimations(jnienv, native__this);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static sbyte n_CheckLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams__mm_wrapper(nint jnienv, nint native__this, nint native_lp)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_CheckLayoutParams_Landroidx_recyclerview_widget_RecyclerView_LayoutParams_(jnienv, native__this, native_lp);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$LayoutManager", DoNotGenerateAcw = true)]
	internal class LayoutManagerInvoker : LayoutManager
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutManager", typeof(LayoutManagerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public LayoutManagerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("generateDefaultLayoutParams", "()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", "GetGenerateDefaultLayoutParamsHandler")]
		public unsafe override LayoutParams? GenerateDefaultLayoutParams()
		{
			return Java.Lang.Object.GetObject<LayoutParams>(_members.InstanceMethods.InvokeAbstractObjectMethod("generateDefaultLayoutParams.()Landroidx/recyclerview/widget/RecyclerView$LayoutParams;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$LayoutParams", DoNotGenerateAcw = true)]
	public new class LayoutParams : MarginLayoutParams
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$LayoutParams", typeof(LayoutParams));

		private static Delegate? cb_getAbsoluteAdapterPosition_GetAbsoluteAdapterPosition_I;

		private static Delegate? cb_getBindingAdapterPosition_GetBindingAdapterPosition_I;

		private static Delegate? cb_isItemChanged_IsItemChanged_Z;

		private static Delegate? cb_isItemRemoved_IsItemRemoved_Z;

		private static Delegate? cb_isViewInvalid_IsViewInvalid_Z;

		private static Delegate? cb_getViewAdapterPosition_GetViewAdapterPosition_I;

		private static Delegate? cb_getViewLayoutPosition_GetViewLayoutPosition_I;

		private static Delegate? cb_getViewPosition_GetViewPosition_I;

		private static Delegate? cb_viewNeedsUpdate_ViewNeedsUpdate_Z;

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

		public unsafe virtual int AbsoluteAdapterPosition
		{
			[Register("getAbsoluteAdapterPosition", "()I", "GetGetAbsoluteAdapterPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getAbsoluteAdapterPosition.()I", this, null);
			}
		}

		public unsafe virtual int BindingAdapterPosition
		{
			[Register("getBindingAdapterPosition", "()I", "GetGetBindingAdapterPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBindingAdapterPosition.()I", this, null);
			}
		}

		public unsafe virtual bool IsItemChanged
		{
			[Register("isItemChanged", "()Z", "GetIsItemChangedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isItemChanged.()Z", this, null);
			}
		}

		public unsafe virtual bool IsItemRemoved
		{
			[Register("isItemRemoved", "()Z", "GetIsItemRemovedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isItemRemoved.()Z", this, null);
			}
		}

		public unsafe virtual bool IsViewInvalid
		{
			[Register("isViewInvalid", "()Z", "GetIsViewInvalidHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isViewInvalid.()Z", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual int ViewAdapterPosition
		{
			[Register("getViewAdapterPosition", "()I", "GetGetViewAdapterPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getViewAdapterPosition.()I", this, null);
			}
		}

		public unsafe virtual int ViewLayoutPosition
		{
			[Register("getViewLayoutPosition", "()I", "GetGetViewLayoutPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getViewLayoutPosition.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe virtual int ViewPosition
		{
			[Register("getViewPosition", "()I", "GetGetViewPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getViewPosition.()I", this, null);
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
		public unsafe LayoutParams(ViewGroup.LayoutParams? source)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Landroid/view/ViewGroup$MarginLayoutParams;)V", "")]
		public unsafe LayoutParams(MarginLayoutParams? source)
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/ViewGroup$MarginLayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register(".ctor", "(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", "")]
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
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/recyclerview/widget/RecyclerView$LayoutParams;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
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

		private static Delegate GetGetAbsoluteAdapterPositionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetAbsoluteAdapterPosition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetAbsoluteAdapterPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AbsoluteAdapterPosition;
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

		private static Delegate GetGetBindingAdapterPositionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetBindingAdapterPosition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetBindingAdapterPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BindingAdapterPosition;
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

		private static Delegate GetIsItemChangedHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsItemChanged);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsItemChanged(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsItemChanged ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetIsItemRemovedHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsItemRemoved);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsItemRemoved(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsItemRemoved ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetIsViewInvalidHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsViewInvalid);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsViewInvalid(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsViewInvalid ? ((sbyte)1) : ((sbyte)0);
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
		private static Delegate GetGetViewAdapterPositionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetViewAdapterPosition);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetViewAdapterPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewAdapterPosition;
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

		private static Delegate GetGetViewLayoutPositionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetViewLayoutPosition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetViewLayoutPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewLayoutPosition;
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
		private static Delegate GetGetViewPositionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetViewPosition);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetViewPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewPosition;
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

		private static Delegate GetViewNeedsUpdateHandler()
		{
			return new global::_JniMarshal_PP_B(n_ViewNeedsUpdate);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_ViewNeedsUpdate(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<LayoutParams>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewNeedsUpdate() ? ((sbyte)1) : ((sbyte)0);
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

		[Register("viewNeedsUpdate", "()Z", "GetViewNeedsUpdateHandler")]
		public unsafe virtual bool ViewNeedsUpdate()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("viewNeedsUpdate.()Z", this, null);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener", "", "AndroidX.RecyclerView.Widget.RecyclerView/IOnChildAttachStateChangeListenerInvoker")]
	public interface IOnChildAttachStateChangeListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onChildViewAttachedToWindow", "(Landroid/view/View;)V", "GetOnChildViewAttachedToWindow_Landroid_view_View_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IOnChildAttachStateChangeListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnChildViewAttachedToWindow(View view);

		[Register("onChildViewDetachedFromWindow", "(Landroid/view/View;)V", "GetOnChildViewDetachedFromWindow_Landroid_view_View_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IOnChildAttachStateChangeListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnChildViewDetachedFromWindow(View view);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener", DoNotGenerateAcw = true)]
	internal class IOnChildAttachStateChangeListenerInvoker : Java.Lang.Object, IOnChildAttachStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener", typeof(IOnChildAttachStateChangeListenerInvoker));

		private static Delegate? cb_onChildViewAttachedToWindow_OnChildViewAttachedToWindow_Landroid_view_View__V;

		private static Delegate? cb_onChildViewDetachedFromWindow_OnChildViewDetachedFromWindow_Landroid_view_View__V;

		private static nint java_class_ref => _members_androidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener.ManagedPeerType;

		public IOnChildAttachStateChangeListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnChildViewAttachedToWindow_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnChildAttachStateChangeListener? onChildAttachStateChangeListener = Java.Lang.Object.GetObject<IOnChildAttachStateChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				onChildAttachStateChangeListener.OnChildViewAttachedToWindow(view);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnChildViewAttachedToWindow(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members_androidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onChildViewAttachedToWindow.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnChildViewDetachedFromWindow_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnChildAttachStateChangeListener? onChildAttachStateChangeListener = Java.Lang.Object.GetObject<IOnChildAttachStateChangeListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				onChildAttachStateChangeListener.OnChildViewDetachedFromWindow(view);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnChildViewDetachedFromWindow(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members_androidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener.InstanceMethods.InvokeAbstractVoidMethod("onChildViewDetachedFromWindow.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
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

		[UnmanagedCallersOnly]
		private static void n_OnChildViewAttachedToWindow_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_view)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnChildViewAttachedToWindow_Landroid_view_View_(jnienv, native__this, native_view);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnChildViewDetachedFromWindow_Landroid_view_View__mm_wrapper(nint jnienv, nint native__this, nint native_view)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnChildViewDetachedFromWindow_Landroid_view_View_(jnienv, native__this, native_view);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class ChildViewAttachedToWindowEventArgs : EventArgs
	{
		private View view;

		public ChildViewAttachedToWindowEventArgs(View view)
		{
			this.view = view;
		}
	}

	public class ChildViewDetachedFromWindowEventArgs : EventArgs
	{
		private View view;

		public ChildViewDetachedFromWindowEventArgs(View view)
		{
			this.view = view;
		}
	}

	[Register("mono/androidx/recyclerview/widget/RecyclerView_OnChildAttachStateChangeListenerImplementor")]
	internal sealed class IOnChildAttachStateChangeListenerImplementor : Java.Lang.Object, IOnChildAttachStateChangeListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<ChildViewAttachedToWindowEventArgs>? OnChildViewAttachedToWindowHandler;

		public EventHandler<ChildViewDetachedFromWindowEventArgs>? OnChildViewDetachedFromWindowHandler;

		public unsafe IOnChildAttachStateChangeListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnChildViewAttachedToWindow(View view)
		{
			OnChildViewAttachedToWindowHandler?.Invoke(sender, new ChildViewAttachedToWindowEventArgs(view));
		}

		public void OnChildViewDetachedFromWindow(View view)
		{
			OnChildViewDetachedFromWindowHandler?.Invoke(sender, new ChildViewDetachedFromWindowEventArgs(view));
		}

		internal static bool __IsEmpty(IOnChildAttachStateChangeListenerImplementor value)
		{
			if (value.OnChildViewAttachedToWindowHandler == null)
			{
				return value.OnChildViewDetachedFromWindowHandler == null;
			}
			return false;
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

	[Register("androidx/recyclerview/widget/RecyclerView$OnFlingListener", DoNotGenerateAcw = true)]
	public abstract class OnFlingListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnFlingListener", typeof(OnFlingListener));

		private static Delegate? cb_onFling_OnFling_II_Z;

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

		protected OnFlingListener(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OnFlingListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnFling_IIHandler()
		{
			return new global::_JniMarshal_PPII_B(n_OnFling_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnFling_II(nint jnienv, nint native__this, int velocityX, int velocityY)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<OnFlingListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFling(velocityX, velocityY) ? ((sbyte)1) : ((sbyte)0);
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

		[Register("onFling", "(II)Z", "GetOnFling_IIHandler")]
		public abstract bool OnFling(int velocityX, int velocityY);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnFlingListener", DoNotGenerateAcw = true)]
	internal class OnFlingListenerInvoker : OnFlingListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnFlingListener", typeof(OnFlingListenerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OnFlingListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onFling", "(II)Z", "GetOnFling_IIHandler")]
		public unsafe override bool OnFling(int velocityX, int velocityY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(velocityX);
			ptr[1] = new JniArgumentValue(velocityY);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("onFling.(II)Z", this, ptr);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnItemTouchListener", "", "AndroidX.RecyclerView.Widget.RecyclerView/IOnItemTouchListenerInvoker")]
	public interface IOnItemTouchListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onInterceptTouchEvent", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IOnItemTouchListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		bool OnInterceptTouchEvent(RecyclerView recyclerView, MotionEvent @event);

		[Register("onRequestDisallowInterceptTouchEvent", "(Z)V", "GetOnRequestDisallowInterceptTouchEvent_ZHandler:AndroidX.RecyclerView.Widget.RecyclerView/IOnItemTouchListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnRequestDisallowInterceptTouchEvent(bool disallow);

		[Register("onTouchEvent", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)V", "GetOnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IOnItemTouchListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnTouchEvent(RecyclerView recyclerView, MotionEvent @event);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnItemTouchListener", DoNotGenerateAcw = true)]
	internal class IOnItemTouchListenerInvoker : Java.Lang.Object, IOnItemTouchListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_recyclerview_widget_RecyclerView_OnItemTouchListener = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnItemTouchListener", typeof(IOnItemTouchListenerInvoker));

		private static Delegate? cb_onInterceptTouchEvent_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onRequestDisallowInterceptTouchEvent_OnRequestDisallowInterceptTouchEvent_Z_V;

		private static Delegate? cb_onTouchEvent_OnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent__V;

		private static nint java_class_ref => _members_androidx_recyclerview_widget_RecyclerView_OnItemTouchListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_recyclerview_widget_RecyclerView_OnItemTouchListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_recyclerview_widget_RecyclerView_OnItemTouchListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_recyclerview_widget_RecyclerView_OnItemTouchListener.ManagedPeerType;

		public IOnItemTouchListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_recyclerView, nint native__event)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnItemTouchListener? onItemTouchListener = Java.Lang.Object.GetObject<IOnItemTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				MotionEvent motionEvent = Java.Lang.Object.GetObject<MotionEvent>(native__event, JniHandleOwnership.DoNotTransfer);
				return onItemTouchListener.OnInterceptTouchEvent(recyclerView, motionEvent) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnInterceptTouchEvent(RecyclerView recyclerView, MotionEvent @event)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(@event?.Handle ?? IntPtr.Zero);
				return _members_androidx_recyclerview_widget_RecyclerView_OnItemTouchListener.InstanceMethods.InvokeAbstractBooleanMethod("onInterceptTouchEvent.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(@event);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnRequestDisallowInterceptTouchEvent_Z(nint jnienv, nint native__this, sbyte native_disallow)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnItemTouchListener? onItemTouchListener = Java.Lang.Object.GetObject<IOnItemTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool disallow = native_disallow != 0;
				onItemTouchListener.OnRequestDisallowInterceptTouchEvent(disallow);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnRequestDisallowInterceptTouchEvent(bool disallow)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(disallow ? ((sbyte)1) : ((sbyte)0));
			_members_androidx_recyclerview_widget_RecyclerView_OnItemTouchListener.InstanceMethods.InvokeAbstractVoidMethod("onRequestDisallowInterceptTouchEvent.(Z)V", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_recyclerView, nint native__event)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IOnItemTouchListener? onItemTouchListener = Java.Lang.Object.GetObject<IOnItemTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				MotionEvent motionEvent = Java.Lang.Object.GetObject<MotionEvent>(native__event, JniHandleOwnership.DoNotTransfer);
				onItemTouchListener.OnTouchEvent(recyclerView, motionEvent);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnTouchEvent(RecyclerView recyclerView, MotionEvent @event)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(@event?.Handle ?? IntPtr.Zero);
				_members_androidx_recyclerview_widget_RecyclerView_OnItemTouchListener.InstanceMethods.InvokeAbstractVoidMethod("onTouchEvent.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
				GC.KeepAlive(@event);
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

		[UnmanagedCallersOnly]
		private static sbyte n_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_recyclerView, nint native__event)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_(jnienv, native__this, native_recyclerView, native__event);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnRequestDisallowInterceptTouchEvent_Z_mm_wrapper(nint jnienv, nint native__this, sbyte native_disallow)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnRequestDisallowInterceptTouchEvent_Z(jnienv, native__this, native_disallow);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_recyclerView, nint native__event)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_(jnienv, native__this, native_recyclerView, native__event);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class InterceptTouchEventEventArgs : EventArgs
	{
		private bool handled;

		private RecyclerView recyclerView;

		private MotionEvent @event;

		public bool Handled => handled;

		public InterceptTouchEventEventArgs(bool handled, RecyclerView recyclerView, MotionEvent @event)
		{
			this.handled = handled;
			this.recyclerView = recyclerView;
			this.@event = @event;
		}
	}

	public class RequestDisallowInterceptTouchEventEventArgs : EventArgs
	{
		private bool disallow;

		public RequestDisallowInterceptTouchEventEventArgs(bool disallow)
		{
			this.disallow = disallow;
		}
	}

	public class TouchEventEventArgs : EventArgs
	{
		private RecyclerView recyclerView;

		private MotionEvent @event;

		public TouchEventEventArgs(RecyclerView recyclerView, MotionEvent @event)
		{
			this.recyclerView = recyclerView;
			this.@event = @event;
		}
	}

	[Register("mono/androidx/recyclerview/widget/RecyclerView_OnItemTouchListenerImplementor")]
	internal sealed class IOnItemTouchListenerImplementor : Java.Lang.Object, IOnItemTouchListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<InterceptTouchEventEventArgs>? OnInterceptTouchEventHandler;

		public EventHandler<RequestDisallowInterceptTouchEventEventArgs>? OnRequestDisallowInterceptTouchEventHandler;

		public EventHandler<TouchEventEventArgs>? OnTouchEventHandler;

		public unsafe IOnItemTouchListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public bool OnInterceptTouchEvent(RecyclerView recyclerView, MotionEvent @event)
		{
			EventHandler<InterceptTouchEventEventArgs> onInterceptTouchEventHandler = OnInterceptTouchEventHandler;
			if (onInterceptTouchEventHandler == null)
			{
				return false;
			}
			InterceptTouchEventEventArgs e = new InterceptTouchEventEventArgs(handled: true, recyclerView, @event);
			onInterceptTouchEventHandler(sender, e);
			return e.Handled;
		}

		public void OnRequestDisallowInterceptTouchEvent(bool disallow)
		{
			OnRequestDisallowInterceptTouchEventHandler?.Invoke(sender, new RequestDisallowInterceptTouchEventEventArgs(disallow));
		}

		public void OnTouchEvent(RecyclerView recyclerView, MotionEvent @event)
		{
			OnTouchEventHandler?.Invoke(sender, new TouchEventEventArgs(recyclerView, @event));
		}

		internal static bool __IsEmpty(IOnItemTouchListenerImplementor value)
		{
			if (value.OnInterceptTouchEventHandler == null && value.OnRequestDisallowInterceptTouchEventHandler == null)
			{
				return value.OnTouchEventHandler == null;
			}
			return false;
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

	[Register("androidx/recyclerview/widget/RecyclerView$OnScrollListener", DoNotGenerateAcw = true)]
	public abstract class OnScrollListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnScrollListener", typeof(OnScrollListener));

		private static Delegate? cb_onScrollStateChanged_OnScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_I_V;

		private static Delegate? cb_onScrolled_OnScrolled_Landroidx_recyclerview_widget_RecyclerView_II_V;

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

		protected OnScrollListener(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OnScrollListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_IHandler()
		{
			return new global::_JniMarshal_PPLI_V(n_OnScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_I(nint jnienv, nint native__this, nint native_recyclerView, int newState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				OnScrollListener? onScrollListener = Java.Lang.Object.GetObject<OnScrollListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				onScrollListener.OnScrollStateChanged(recyclerView, newState);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onScrollStateChanged", "(Landroidx/recyclerview/widget/RecyclerView;I)V", "GetOnScrollStateChanged_Landroidx_recyclerview_widget_RecyclerView_IHandler")]
		public unsafe virtual void OnScrollStateChanged(RecyclerView recyclerView, int newState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(newState);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onScrollStateChanged.(Landroidx/recyclerview/widget/RecyclerView;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnScrolled_Landroidx_recyclerview_widget_RecyclerView_II(nint jnienv, nint native__this, nint native_recyclerView, int dx, int dy)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				OnScrollListener? onScrollListener = Java.Lang.Object.GetObject<OnScrollListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView recyclerView = Java.Lang.Object.GetObject<RecyclerView>(native_recyclerView, JniHandleOwnership.DoNotTransfer);
				onScrollListener.OnScrolled(recyclerView, dx, dy);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onScrolled", "(Landroidx/recyclerview/widget/RecyclerView;II)V", "GetOnScrolled_Landroidx_recyclerview_widget_RecyclerView_IIHandler")]
		public unsafe virtual void OnScrolled(RecyclerView recyclerView, int dx, int dy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recyclerView?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(dx);
				ptr[2] = new JniArgumentValue(dy);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onScrolled.(Landroidx/recyclerview/widget/RecyclerView;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(recyclerView);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnScrolled_Landroidx_recyclerview_widget_RecyclerView_II_mm_wrapper(nint jnienv, nint native__this, nint native_recyclerView, int dx, int dy)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnScrolled_Landroidx_recyclerview_widget_RecyclerView_II(jnienv, native__this, native_recyclerView, dx, dy);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$OnScrollListener", DoNotGenerateAcw = true)]
	internal class OnScrollListenerInvoker : OnScrollListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$OnScrollListener", typeof(OnScrollListenerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OnScrollListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$RecycledViewPool", DoNotGenerateAcw = true)]
	public class RecycledViewPool : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$RecycledViewPool", typeof(RecycledViewPool));

		private static Delegate? cb_clear_Clear_V;

		private static Delegate? cb_getRecycledView_GetRecycledView_I_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

		private static Delegate? cb_getRecycledViewCount_GetRecycledViewCount_I_I;

		private static Delegate? cb_putRecycledView_PutRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__V;

		private static Delegate? cb_setMaxRecycledViews_SetMaxRecycledViews_II_V;

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

		protected RecycledViewPool(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe RecycledViewPool()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetClearHandler()
		{
			return new global::_JniMarshal_PP_V(n_Clear);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Clear(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("clear", "()V", "GetClearHandler")]
		public unsafe virtual void Clear()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
		}

		private static Delegate GetGetRecycledView_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_GetRecycledView_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetRecycledView_I(nint jnienv, nint native__this, int viewType)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRecycledView(viewType));
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

		[Register("getRecycledView", "(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetGetRecycledView_IHandler")]
		public unsafe virtual ViewHolder? GetRecycledView(int viewType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewType);
			return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRecycledView.(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetRecycledViewCount_IHandler()
		{
			return new global::_JniMarshal_PPI_I(n_GetRecycledViewCount_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetRecycledViewCount_I(nint jnienv, nint native__this, int viewType)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRecycledViewCount(viewType);
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

		[Register("getRecycledViewCount", "(I)I", "GetGetRecycledViewCount_IHandler")]
		public unsafe virtual int GetRecycledViewCount(int viewType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewType);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRecycledViewCount.(I)I", this, ptr);
		}

		private static Delegate GetPutRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_PutRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_PutRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_scrap)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				RecycledViewPool? recycledViewPool = Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder scrap = Java.Lang.Object.GetObject<ViewHolder>(native_scrap, JniHandleOwnership.DoNotTransfer);
				recycledViewPool.PutRecycledView(scrap);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("putRecycledView", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetPutRecycledView_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler")]
		public unsafe virtual void PutRecycledView(ViewHolder? scrap)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(scrap?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("putRecycledView.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(scrap);
			}
		}

		private static Delegate GetSetMaxRecycledViews_IIHandler()
		{
			return new global::_JniMarshal_PPII_V(n_SetMaxRecycledViews_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetMaxRecycledViews_II(nint jnienv, nint native__this, int viewType, int max)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<RecycledViewPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxRecycledViews(viewType, max);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("setMaxRecycledViews", "(II)V", "GetSetMaxRecycledViews_IIHandler")]
		public unsafe virtual void SetMaxRecycledViews(int viewType, int max)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(viewType);
			ptr[1] = new JniArgumentValue(max);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxRecycledViews.(II)V", this, ptr);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$Recycler", DoNotGenerateAcw = true)]
	public sealed class Recycler : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$Recycler", typeof(Recycler));

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

		public unsafe IList<ViewHolder> ScrapList
		{
			[Register("getScrapList", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<ViewHolder>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getScrapList.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Recycler(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/recyclerview/widget/RecyclerView;)V", "")]
		public unsafe Recycler(RecyclerView? __self)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			string constructorSignature = "(L" + JNIEnv.GetJniName(GetType().DeclaringType) + ";)V";
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(__self?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance(constructorSignature, GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance(constructorSignature, this, ptr);
			}
			finally
			{
				GC.KeepAlive(__self);
			}
		}

		[Register("bindViewToPosition", "(Landroid/view/View;I)V", "")]
		public unsafe void BindViewToPosition(View view, int position)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeAbstractVoidMethod("bindViewToPosition.(Landroid/view/View;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Register("clear", "()V", "")]
		public unsafe void Clear()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
		}

		[Register("convertPreLayoutPositionToPostLayout", "(I)I", "")]
		public unsafe int ConvertPreLayoutPositionToPostLayout(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeAbstractInt32Method("convertPreLayoutPositionToPostLayout.(I)I", this, ptr);
		}

		[Register("getViewForPosition", "(I)Landroid/view/View;", "")]
		public unsafe View GetViewForPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getViewForPosition.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("recycleView", "(Landroid/view/View;)V", "")]
		public unsafe void RecycleView(View view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("recycleView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Register("setViewCacheSize", "(I)V", "")]
		public unsafe void SetViewCacheSize(int viewCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(viewCount);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setViewCacheSize.(I)V", this, ptr);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$RecyclerListener", "", "AndroidX.RecyclerView.Widget.RecyclerView/IRecyclerListenerInvoker")]
	public interface IRecyclerListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onViewRecycled", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", "GetOnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IRecyclerListenerInvoker, Xamarin.AndroidX.RecyclerView")]
		void OnViewRecycled(ViewHolder holder);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$RecyclerListener", DoNotGenerateAcw = true)]
	internal class IRecyclerListenerInvoker : Java.Lang.Object, IRecyclerListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_recyclerview_widget_RecyclerView_RecyclerListener = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$RecyclerListener", typeof(IRecyclerListenerInvoker));

		private static Delegate? cb_onViewRecycled_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__V;

		private static nint java_class_ref => _members_androidx_recyclerview_widget_RecyclerView_RecyclerListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_recyclerview_widget_RecyclerView_RecyclerListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_recyclerview_widget_RecyclerView_RecyclerListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_recyclerview_widget_RecyclerView_RecyclerListener.ManagedPeerType;

		public IRecyclerListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(nint jnienv, nint native__this, nint native_holder)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IRecyclerListener? recyclerListener = Java.Lang.Object.GetObject<IRecyclerListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ViewHolder holder = Java.Lang.Object.GetObject<ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
				recyclerListener.OnViewRecycled(holder);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		public unsafe void OnViewRecycled(ViewHolder holder)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(holder?.Handle ?? IntPtr.Zero);
				_members_androidx_recyclerview_widget_RecyclerView_RecyclerListener.InstanceMethods.InvokeAbstractVoidMethod("onViewRecycled.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(holder);
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

		[UnmanagedCallersOnly]
		private static void n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder__mm_wrapper(nint jnienv, nint native__this, nint native_holder)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_(jnienv, native__this, native_holder);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	public class RecyclerEventArgs : EventArgs
	{
		private ViewHolder holder;

		public RecyclerEventArgs(ViewHolder holder)
		{
			this.holder = holder;
		}
	}

	[Register("mono/androidx/recyclerview/widget/RecyclerView_RecyclerListenerImplementor")]
	internal sealed class IRecyclerListenerImplementor : Java.Lang.Object, IRecyclerListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<RecyclerEventArgs>? Handler;

		public unsafe IRecyclerListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public void OnViewRecycled(ViewHolder holder)
		{
			Handler?.Invoke(sender, new RecyclerEventArgs(holder));
		}

		internal static bool __IsEmpty(IRecyclerListenerImplementor value)
		{
			return value.Handler == null;
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

	[Register("androidx/recyclerview/widget/RecyclerView$SimpleOnItemTouchListener", DoNotGenerateAcw = true)]
	public class SimpleOnItemTouchListener : Java.Lang.Object, IOnItemTouchListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$SimpleOnItemTouchListener", typeof(SimpleOnItemTouchListener));

		private static Delegate? cb_onInterceptTouchEvent_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent__Z;

		private static Delegate? cb_onRequestDisallowInterceptTouchEvent_OnRequestDisallowInterceptTouchEvent_Z_V;

		private static Delegate? cb_onTouchEvent_OnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent__V;

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

		protected SimpleOnItemTouchListener(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SimpleOnItemTouchListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_rv, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				SimpleOnItemTouchListener? simpleOnItemTouchListener = Java.Lang.Object.GetObject<SimpleOnItemTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView rv = Java.Lang.Object.GetObject<RecyclerView>(native_rv, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				return simpleOnItemTouchListener.OnInterceptTouchEvent(rv, e) ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onInterceptTouchEvent", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)Z", "GetOnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual bool OnInterceptTouchEvent(RecyclerView rv, MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(rv?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("onInterceptTouchEvent.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(rv);
				GC.KeepAlive(e);
			}
		}

		private static Delegate GetOnRequestDisallowInterceptTouchEvent_ZHandler()
		{
			return new global::_JniMarshal_PPB_V(n_OnRequestDisallowInterceptTouchEvent_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnRequestDisallowInterceptTouchEvent_Z(nint jnienv, nint native__this, sbyte native_disallowIntercept)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SimpleOnItemTouchListener? simpleOnItemTouchListener = Java.Lang.Object.GetObject<SimpleOnItemTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool disallowIntercept = native_disallowIntercept != 0;
				simpleOnItemTouchListener.OnRequestDisallowInterceptTouchEvent(disallowIntercept);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onRequestDisallowInterceptTouchEvent", "(Z)V", "GetOnRequestDisallowInterceptTouchEvent_ZHandler")]
		public unsafe virtual void OnRequestDisallowInterceptTouchEvent(bool disallowIntercept)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(disallowIntercept ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRequestDisallowInterceptTouchEvent.(Z)V", this, ptr);
		}

		private static Delegate GetOnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler()
		{
			return new global::_JniMarshal_PPLL_V(n_OnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_rv, nint native_e)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SimpleOnItemTouchListener? simpleOnItemTouchListener = Java.Lang.Object.GetObject<SimpleOnItemTouchListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				RecyclerView rv = Java.Lang.Object.GetObject<RecyclerView>(native_rv, JniHandleOwnership.DoNotTransfer);
				MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_e, JniHandleOwnership.DoNotTransfer);
				simpleOnItemTouchListener.OnTouchEvent(rv, e);
			}
			catch (System.Exception e2)
			{
				runtime.OnUserUnhandledException(ref transition, e2);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onTouchEvent", "(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)V", "GetOnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler")]
		public unsafe virtual void OnTouchEvent(RecyclerView rv, MotionEvent e)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(rv?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onTouchEvent.(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(rv);
				GC.KeepAlive(e);
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

		[UnmanagedCallersOnly]
		private static sbyte n_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent__mm_wrapper(nint jnienv, nint native__this, nint native_rv, nint native_e)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_(jnienv, native__this, native_rv, native_e);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$SmoothScroller", DoNotGenerateAcw = true)]
	public abstract class SmoothScroller : Java.Lang.Object
	{
		[Register("androidx/recyclerview/widget/RecyclerView$SmoothScroller$Action", DoNotGenerateAcw = true)]
		public class Action : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$SmoothScroller$Action", typeof(Action));

			private static Delegate? cb_getDuration_GetDuration_I;

			private static Delegate? cb_setDuration_SetDuration_I_V;

			private static Delegate? cb_getDx_GetDx_I;

			private static Delegate? cb_setDx_SetDx_I_V;

			private static Delegate? cb_getDy_GetDy_I;

			private static Delegate? cb_setDy_SetDy_I_V;

			private static Delegate? cb_getInterpolator_GetInterpolator_Landroid_view_animation_Interpolator_;

			private static Delegate? cb_setInterpolator_SetInterpolator_Landroid_view_animation_Interpolator__V;

			private static Delegate? cb_jumpTo_JumpTo_I_V;

			private static Delegate? cb_update_Update_IIILandroid_view_animation_Interpolator__V;

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

			public unsafe virtual int Dx
			{
				[Register("getDx", "()I", "GetGetDxHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getDx.()I", this, null);
				}
				[Register("setDx", "(I)V", "GetSetDx_IHandler")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDx.(I)V", this, ptr);
				}
			}

			public unsafe virtual int Dy
			{
				[Register("getDy", "()I", "GetGetDyHandler")]
				get
				{
					return _members.InstanceMethods.InvokeVirtualInt32Method("getDy.()I", this, null);
				}
				[Register("setDy", "(I)V", "GetSetDy_IHandler")]
				set
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDy.(I)V", this, ptr);
				}
			}

			public unsafe virtual IInterpolator? Interpolator
			{
				[Register("getInterpolator", "()Landroid/view/animation/Interpolator;", "GetGetInterpolatorHandler")]
				get
				{
					return Java.Lang.Object.GetObject<IInterpolator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterpolator.()Landroid/view/animation/Interpolator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
				[Register("setInterpolator", "(Landroid/view/animation/Interpolator;)V", "GetSetInterpolator_Landroid_view_animation_Interpolator_Handler")]
				set
				{
					try
					{
						JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
						*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
						_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolator.(Landroid/view/animation/Interpolator;)V", this, ptr);
					}
					finally
					{
						GC.KeepAlive(value);
					}
				}
			}

			protected Action(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(II)V", "")]
			public unsafe Action(int dx, int dy)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle == IntPtr.Zero)
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(dx);
					ptr[1] = new JniArgumentValue(dy);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
				}
			}

			[Register(".ctor", "(III)V", "")]
			public unsafe Action(int dx, int dy, int duration)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle == IntPtr.Zero)
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(dx);
					ptr[1] = new JniArgumentValue(dy);
					ptr[2] = new JniArgumentValue(duration);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(III)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(III)V", this, ptr);
				}
			}

			[Register(".ctor", "(IIILandroid/view/animation/Interpolator;)V", "")]
			public unsafe Action(int dx, int dy, int duration, IInterpolator? interpolator)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(dx);
					ptr[1] = new JniArgumentValue(dy);
					ptr[2] = new JniArgumentValue(duration);
					ptr[3] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(IIILandroid/view/animation/Interpolator;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(IIILandroid/view/animation/Interpolator;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(interpolator);
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
					return Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
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
					Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration = duration;
				}
				catch (System.Exception e)
				{
					runtime.OnUserUnhandledException(ref transition, e);
				}
				finally
				{
					JniEnvironment.EndMarshalMethod(ref transition);
				}
			}

			private static Delegate GetGetDxHandler()
			{
				return new global::_JniMarshal_PP_I(n_GetDx);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static int n_GetDx(nint jnienv, nint native__this)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					return Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dx;
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

			private static Delegate GetSetDx_IHandler()
			{
				return new global::_JniMarshal_PPI_V(n_SetDx_I);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_SetDx_I(nint jnienv, nint native__this, int dx)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dx = dx;
				}
				catch (System.Exception e)
				{
					runtime.OnUserUnhandledException(ref transition, e);
				}
				finally
				{
					JniEnvironment.EndMarshalMethod(ref transition);
				}
			}

			private static Delegate GetGetDyHandler()
			{
				return new global::_JniMarshal_PP_I(n_GetDy);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static int n_GetDy(nint jnienv, nint native__this)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return 0;
				}
				try
				{
					return Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dy;
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

			private static Delegate GetSetDy_IHandler()
			{
				return new global::_JniMarshal_PPI_V(n_SetDy_I);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_SetDy_I(nint jnienv, nint native__this, int dy)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dy = dy;
				}
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
					return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolator);
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

			private static Delegate GetSetInterpolator_Landroid_view_animation_Interpolator_Handler()
			{
				return new global::_JniMarshal_PPL_V(n_SetInterpolator_Landroid_view_animation_Interpolator_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_SetInterpolator_Landroid_view_animation_Interpolator_(nint jnienv, nint native__this, nint native_interpolator)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					Action? action = Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					IInterpolator interpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
					action.Interpolator = interpolator;
				}
				catch (System.Exception e)
				{
					runtime.OnUserUnhandledException(ref transition, e);
				}
				finally
				{
					JniEnvironment.EndMarshalMethod(ref transition);
				}
			}

			private static Delegate GetJumpTo_IHandler()
			{
				return new global::_JniMarshal_PPI_V(n_JumpTo_I);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_JumpTo_I(nint jnienv, nint native__this, int targetPosition)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).JumpTo(targetPosition);
				}
				catch (System.Exception e)
				{
					runtime.OnUserUnhandledException(ref transition, e);
				}
				finally
				{
					JniEnvironment.EndMarshalMethod(ref transition);
				}
			}

			[Register("jumpTo", "(I)V", "GetJumpTo_IHandler")]
			public unsafe virtual void JumpTo(int targetPosition)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(targetPosition);
				_members.InstanceMethods.InvokeVirtualVoidMethod("jumpTo.(I)V", this, ptr);
			}

			private static Delegate GetUpdate_IIILandroid_view_animation_Interpolator_Handler()
			{
				return new global::_JniMarshal_PPIIIL_V(n_Update_IIILandroid_view_animation_Interpolator_);
			}

			[DebuggerDisableUserUnhandledExceptions]
			private static void n_Update_IIILandroid_view_animation_Interpolator_(nint jnienv, nint native__this, int dx, int dy, int duration, nint native_interpolator)
			{
				if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
				{
					return;
				}
				try
				{
					Action? action = Java.Lang.Object.GetObject<Action>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
					IInterpolator interpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
					action.Update(dx, dy, duration, interpolator);
				}
				catch (System.Exception e)
				{
					runtime.OnUserUnhandledException(ref transition, e);
				}
				finally
				{
					JniEnvironment.EndMarshalMethod(ref transition);
				}
			}

			[Register("update", "(IIILandroid/view/animation/Interpolator;)V", "GetUpdate_IIILandroid_view_animation_Interpolator_Handler")]
			public unsafe virtual void Update(int dx, int dy, int duration, IInterpolator? interpolator)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(dx);
					ptr[1] = new JniArgumentValue(dy);
					ptr[2] = new JniArgumentValue(duration);
					ptr[3] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
					_members.InstanceMethods.InvokeVirtualVoidMethod("update.(IIILandroid/view/animation/Interpolator;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(interpolator);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$SmoothScroller", typeof(SmoothScroller));

		private static Delegate? cb_getChildCount_GetChildCount_I;

		private static Delegate? cb_isPendingInitialRun_IsPendingInitialRun_Z;

		private static Delegate? cb_isRunning_IsRunning_Z;

		private static Delegate? cb_getLayoutManager_GetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_;

		private static Delegate? cb_getTargetPosition_GetTargetPosition_I;

		private static Delegate? cb_setTargetPosition_SetTargetPosition_I_V;

		private static Delegate? cb_computeScrollVectorForPosition_ComputeScrollVectorForPosition_I_Landroid_graphics_PointF_;

		private static Delegate? cb_findViewByPosition_FindViewByPosition_I_Landroid_view_View_;

		private static Delegate? cb_getChildPosition_GetChildPosition_Landroid_view_View__I;

		private static Delegate? cb_instantScrollToPosition_InstantScrollToPosition_I_V;

		private static Delegate? cb_normalize_Normalize_Landroid_graphics_PointF__V;

		private static Delegate? cb_onChildAttachedToWindow_OnChildAttachedToWindow_Landroid_view_View__V;

		private static Delegate? cb_onSeekTargetStep_OnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action__V;

		private static Delegate? cb_onStart_OnStart_V;

		private static Delegate? cb_onStop_OnStop_V;

		private static Delegate? cb_onTargetFound_OnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action__V;

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

		public unsafe virtual int ChildCount
		{
			[Register("getChildCount", "()I", "GetGetChildCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getChildCount.()I", this, null);
			}
		}

		public unsafe virtual bool IsPendingInitialRun
		{
			[Register("isPendingInitialRun", "()Z", "GetIsPendingInitialRunHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPendingInitialRun.()Z", this, null);
			}
		}

		public unsafe virtual bool IsRunning
		{
			[Register("isRunning", "()Z", "GetIsRunningHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRunning.()Z", this, null);
			}
		}

		public unsafe virtual LayoutManager? LayoutManager
		{
			[Register("getLayoutManager", "()Landroidx/recyclerview/widget/RecyclerView$LayoutManager;", "GetGetLayoutManagerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LayoutManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLayoutManager.()Landroidx/recyclerview/widget/RecyclerView$LayoutManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int TargetPosition
		{
			[Register("getTargetPosition", "()I", "GetGetTargetPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTargetPosition.()I", this, null);
			}
			[Register("setTargetPosition", "(I)V", "GetSetTargetPosition_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTargetPosition.(I)V", this, ptr);
			}
		}

		protected SmoothScroller(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SmoothScroller()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
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
				return Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChildCount;
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

		private static Delegate GetIsPendingInitialRunHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsPendingInitialRun);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsPendingInitialRun(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPendingInitialRun ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetIsRunningHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsRunning);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsRunning(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRunning ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetGetLayoutManagerHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetLayoutManager);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetLayoutManager(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutManager);
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

		private static Delegate GetGetTargetPositionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetTargetPosition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetTargetPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetPosition;
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

		private static Delegate GetSetTargetPosition_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetTargetPosition_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetTargetPosition_I(nint jnienv, nint native__this, int targetPosition)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetPosition = targetPosition;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_ComputeScrollVectorForPosition_I(nint jnienv, nint native__this, int targetPosition)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeScrollVectorForPosition(targetPosition));
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

		[Register("computeScrollVectorForPosition", "(I)Landroid/graphics/PointF;", "GetComputeScrollVectorForPosition_IHandler")]
		public unsafe virtual PointF? ComputeScrollVectorForPosition(int targetPosition)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(targetPosition);
			return Java.Lang.Object.GetObject<PointF>(_members.InstanceMethods.InvokeVirtualObjectMethod("computeScrollVectorForPosition.(I)Landroid/graphics/PointF;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetFindViewByPosition_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_FindViewByPosition_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_FindViewByPosition_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewByPosition(position));
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

		[Register("findViewByPosition", "(I)Landroid/view/View;", "GetFindViewByPosition_IHandler")]
		public unsafe virtual View? FindViewByPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewByPosition.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetChildPosition_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_I(n_GetChildPosition_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetChildPosition_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				SmoothScroller? smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
				return smoothScroller.GetChildPosition(view);
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

		[Register("getChildPosition", "(Landroid/view/View;)I", "GetGetChildPosition_Landroid_view_View_Handler")]
		public unsafe virtual int GetChildPosition(View? view)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getChildPosition.(Landroid/view/View;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
			}
		}

		[Obsolete]
		private static Delegate GetInstantScrollToPosition_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_InstantScrollToPosition_I);
		}

		[Obsolete]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_InstantScrollToPosition_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InstantScrollToPosition(position);
			}
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
		[Register("instantScrollToPosition", "(I)V", "GetInstantScrollToPosition_IHandler")]
		public unsafe virtual void InstantScrollToPosition(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("instantScrollToPosition.(I)V", this, ptr);
		}

		private static Delegate GetNormalize_Landroid_graphics_PointF_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_Normalize_Landroid_graphics_PointF_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Normalize_Landroid_graphics_PointF_(nint jnienv, nint native__this, nint native_scrollVector)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SmoothScroller? smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				PointF scrollVector = Java.Lang.Object.GetObject<PointF>(native_scrollVector, JniHandleOwnership.DoNotTransfer);
				smoothScroller.Normalize(scrollVector);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("normalize", "(Landroid/graphics/PointF;)V", "GetNormalize_Landroid_graphics_PointF_Handler")]
		protected unsafe virtual void Normalize(PointF scrollVector)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(scrollVector?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("normalize.(Landroid/graphics/PointF;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(scrollVector);
			}
		}

		private static Delegate GetOnChildAttachedToWindow_Landroid_view_View_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnChildAttachedToWindow_Landroid_view_View_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnChildAttachedToWindow_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SmoothScroller? smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
				smoothScroller.OnChildAttachedToWindow(child);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onChildAttachedToWindow", "(Landroid/view/View;)V", "GetOnChildAttachedToWindow_Landroid_view_View_Handler")]
		protected unsafe virtual void OnChildAttachedToWindow(View? child)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onChildAttachedToWindow.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(child);
			}
		}

		private static Delegate GetOnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler()
		{
			return new _JniMarshal_PPIILL_V(n_OnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_(nint jnienv, nint native__this, int p0, int p1, nint native_p2, nint native_p3)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SmoothScroller? smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				State p2 = Java.Lang.Object.GetObject<State>(native_p2, JniHandleOwnership.DoNotTransfer);
				Action p3 = Java.Lang.Object.GetObject<Action>(native_p3, JniHandleOwnership.DoNotTransfer);
				smoothScroller.OnSeekTargetStep(p0, p1, p2, p3);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onSeekTargetStep", "(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
		protected abstract void OnSeekTargetStep(int p0, int p1, State p2, Action p3);

		private static Delegate GetOnStartHandler()
		{
			return new global::_JniMarshal_PP_V(n_OnStart);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStart(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onStart", "()V", "GetOnStartHandler")]
		protected abstract void OnStart();

		private static Delegate GetOnStopHandler()
		{
			return new global::_JniMarshal_PP_V(n_OnStop);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnStop(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onStop", "()V", "GetOnStopHandler")]
		protected abstract void OnStop();

		private static Delegate GetOnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler()
		{
			return new global::_JniMarshal_PPLLL_V(n_OnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SmoothScroller? smoothScroller = Java.Lang.Object.GetObject<SmoothScroller>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				View p = Java.Lang.Object.GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
				State p2 = Java.Lang.Object.GetObject<State>(native_p1, JniHandleOwnership.DoNotTransfer);
				Action p3 = Java.Lang.Object.GetObject<Action>(native_p2, JniHandleOwnership.DoNotTransfer);
				smoothScroller.OnTargetFound(p, p2, p3);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("onTargetFound", "(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
		protected abstract void OnTargetFound(View p0, State p1, Action p2);

		[Register("stop", "()V", "")]
		protected unsafe void Stop()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("stop.()V", this, null);
		}

		[UnmanagedCallersOnly]
		private static nint n_ComputeScrollVectorForPosition_I_mm_wrapper(nint jnienv, nint native__this, int targetPosition)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_ComputeScrollVectorForPosition_I(jnienv, native__this, targetPosition);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$SmoothScroller", DoNotGenerateAcw = true)]
	internal class SmoothScrollerInvoker : SmoothScroller
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$SmoothScroller", typeof(SmoothScrollerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public SmoothScrollerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onSeekTargetStep", "(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnSeekTargetStep_IILandroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
		protected unsafe override void OnSeekTargetStep(int p0, int p1, State p2, Action p3)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onSeekTargetStep.(IILandroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p2);
				GC.KeepAlive(p3);
			}
		}

		[Register("onStart", "()V", "GetOnStartHandler")]
		protected unsafe override void OnStart()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("onStart.()V", this, null);
		}

		[Register("onStop", "()V", "GetOnStopHandler")]
		protected unsafe override void OnStop()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("onStop.()V", this, null);
		}

		[Register("onTargetFound", "(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", "GetOnTargetFound_Landroid_view_View_Landroidx_recyclerview_widget_RecyclerView_State_Landroidx_recyclerview_widget_RecyclerView_SmoothScroller_Action_Handler")]
		protected unsafe override void OnTargetFound(View p0, State p1, Action p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onTargetFound.(Landroid/view/View;Landroidx/recyclerview/widget/RecyclerView$State;Landroidx/recyclerview/widget/RecyclerView$SmoothScroller$Action;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$State", DoNotGenerateAcw = true)]
	public class State : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$State", typeof(State));

		private static Delegate? cb_hasTargetScrollPosition_HasTargetScrollPosition_Z;

		private static Delegate? cb_isMeasuring_IsMeasuring_Z;

		private static Delegate? cb_isPreLayout_IsPreLayout_Z;

		private static Delegate? cb_getItemCount_GetItemCount_I;

		private static Delegate? cb_getRemainingScrollHorizontal_GetRemainingScrollHorizontal_I;

		private static Delegate? cb_getRemainingScrollVertical_GetRemainingScrollVertical_I;

		private static Delegate? cb_getTargetScrollPosition_GetTargetScrollPosition_I;

		private static Delegate? cb_didStructureChange_DidStructureChange_Z;

		private static Delegate? cb_get_Get_I_Ljava_lang_Object_;

		private static Delegate? cb_put_Put_ILjava_lang_Object__V;

		private static Delegate? cb_remove_Remove_I_V;

		private static Delegate? cb_willRunPredictiveAnimations_WillRunPredictiveAnimations_Z;

		private static Delegate? cb_willRunSimpleAnimations_WillRunSimpleAnimations_Z;

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

		public unsafe virtual bool HasTargetScrollPosition
		{
			[Register("hasTargetScrollPosition", "()Z", "GetHasTargetScrollPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasTargetScrollPosition.()Z", this, null);
			}
		}

		public unsafe virtual bool IsMeasuring
		{
			[Register("isMeasuring", "()Z", "GetIsMeasuringHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMeasuring.()Z", this, null);
			}
		}

		public unsafe virtual bool IsPreLayout
		{
			[Register("isPreLayout", "()Z", "GetIsPreLayoutHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPreLayout.()Z", this, null);
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

		public unsafe virtual int RemainingScrollHorizontal
		{
			[Register("getRemainingScrollHorizontal", "()I", "GetGetRemainingScrollHorizontalHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRemainingScrollHorizontal.()I", this, null);
			}
		}

		public unsafe virtual int RemainingScrollVertical
		{
			[Register("getRemainingScrollVertical", "()I", "GetGetRemainingScrollVerticalHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRemainingScrollVertical.()I", this, null);
			}
		}

		public unsafe virtual int TargetScrollPosition
		{
			[Register("getTargetScrollPosition", "()I", "GetGetTargetScrollPositionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTargetScrollPosition.()I", this, null);
			}
		}

		protected State(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe State()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetHasTargetScrollPositionHandler()
		{
			return new global::_JniMarshal_PP_B(n_HasTargetScrollPosition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_HasTargetScrollPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasTargetScrollPosition ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetIsMeasuringHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsMeasuring);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsMeasuring(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsMeasuring ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetIsPreLayoutHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsPreLayout);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsPreLayout(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPreLayout ? ((sbyte)1) : ((sbyte)0);
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
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemCount;
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

		private static Delegate GetGetRemainingScrollHorizontalHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetRemainingScrollHorizontal);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetRemainingScrollHorizontal(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemainingScrollHorizontal;
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

		private static Delegate GetGetRemainingScrollVerticalHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetRemainingScrollVertical);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetRemainingScrollVertical(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemainingScrollVertical;
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

		private static Delegate GetGetTargetScrollPositionHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetTargetScrollPosition);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetTargetScrollPosition(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TargetScrollPosition;
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

		private static Delegate GetDidStructureChangeHandler()
		{
			return new global::_JniMarshal_PP_B(n_DidStructureChange);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_DidStructureChange(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DidStructureChange() ? ((sbyte)1) : ((sbyte)0);
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

		[Register("didStructureChange", "()Z", "GetDidStructureChangeHandler")]
		public unsafe virtual bool DidStructureChange()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("didStructureChange.()Z", this, null);
		}

		private static Delegate GetGet_IHandler()
		{
			return new global::_JniMarshal_PPI_L(n_Get_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Get_I(nint jnienv, nint native__this, int resourceId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get(resourceId));
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

		[Register("get", "(I)Ljava/lang/Object;", "GetGet_IHandler")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe virtual Java.Lang.Object? Get(int resourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceId);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPut_ILjava_lang_Object_Handler()
		{
			return new global::_JniMarshal_PPIL_V(n_Put_ILjava_lang_Object_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Put_ILjava_lang_Object_(nint jnienv, nint native__this, int resourceId, nint native_data)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				State? state = Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object data = Java.Lang.Object.GetObject<Java.Lang.Object>(native_data, JniHandleOwnership.DoNotTransfer);
				state.Put(resourceId, data);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("put", "(ILjava/lang/Object;)V", "GetPut_ILjava_lang_Object_Handler")]
		public unsafe virtual void Put(int resourceId, Java.Lang.Object? data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(resourceId);
				ptr[1] = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("put.(ILjava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetRemove_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_Remove_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_Remove_I(nint jnienv, nint native__this, int resourceId)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove(resourceId);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("remove", "(I)V", "GetRemove_IHandler")]
		public unsafe virtual void Remove(int resourceId)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(I)V", this, ptr);
		}

		private static Delegate GetWillRunPredictiveAnimationsHandler()
		{
			return new global::_JniMarshal_PP_B(n_WillRunPredictiveAnimations);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_WillRunPredictiveAnimations(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WillRunPredictiveAnimations() ? ((sbyte)1) : ((sbyte)0);
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

		[Register("willRunPredictiveAnimations", "()Z", "GetWillRunPredictiveAnimationsHandler")]
		public unsafe virtual bool WillRunPredictiveAnimations()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("willRunPredictiveAnimations.()Z", this, null);
		}

		private static Delegate GetWillRunSimpleAnimationsHandler()
		{
			return new global::_JniMarshal_PP_B(n_WillRunSimpleAnimations);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_WillRunSimpleAnimations(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<State>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WillRunSimpleAnimations() ? ((sbyte)1) : ((sbyte)0);
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

		[Register("willRunSimpleAnimations", "()Z", "GetWillRunSimpleAnimationsHandler")]
		public unsafe virtual bool WillRunSimpleAnimations()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("willRunSimpleAnimations.()Z", this, null);
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ViewCacheExtension", DoNotGenerateAcw = true)]
	public abstract class ViewCacheExtension : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ViewCacheExtension", typeof(ViewCacheExtension));

		private static Delegate? cb_getViewForPositionAndType_GetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_II_Landroid_view_View_;

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

		protected ViewCacheExtension(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ViewCacheExtension()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_IIHandler()
		{
			return new global::_JniMarshal_PPLII_L(n_GetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_II(nint jnienv, nint native__this, nint native_recycler, int position, int type)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ViewCacheExtension? viewCacheExtension = Java.Lang.Object.GetObject<ViewCacheExtension>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Recycler recycler = Java.Lang.Object.GetObject<Recycler>(native_recycler, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(viewCacheExtension.GetViewForPositionAndType(recycler, position, type));
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

		[Register("getViewForPositionAndType", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;II)Landroid/view/View;", "GetGetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_IIHandler")]
		public abstract View? GetViewForPositionAndType(Recycler recycler, int position, int type);
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ViewCacheExtension", DoNotGenerateAcw = true)]
	internal class ViewCacheExtensionInvoker : ViewCacheExtension
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ViewCacheExtension", typeof(ViewCacheExtensionInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ViewCacheExtensionInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getViewForPositionAndType", "(Landroidx/recyclerview/widget/RecyclerView$Recycler;II)Landroid/view/View;", "GetGetViewForPositionAndType_Landroidx_recyclerview_widget_RecyclerView_Recycler_IIHandler")]
		public unsafe override View? GetViewForPositionAndType(Recycler recycler, int position, int type)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(recycler?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(position);
				ptr[2] = new JniArgumentValue(type);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getViewForPositionAndType.(Landroidx/recyclerview/widget/RecyclerView$Recycler;II)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(recycler);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ViewHolder", DoNotGenerateAcw = true)]
	public abstract class ViewHolder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ViewHolder", typeof(ViewHolder));

		[Register("itemView")]
		public View ItemView
		{
			get
			{
				return Java.Lang.Object.GetObject<View>(_members.InstanceFields.GetObjectValue("itemView.Landroid/view/View;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				nint num = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("itemView.Landroid/view/View;", this, new JniObjectReference(num));
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

		public unsafe int AbsoluteAdapterPosition
		{
			[Register("getAbsoluteAdapterPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getAbsoluteAdapterPosition.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe int AdapterPosition
		{
			[Register("getAdapterPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getAdapterPosition.()I", this, null);
			}
		}

		public unsafe Adapter? BindingAdapter
		{
			[Register("getBindingAdapter", "()Landroidx/recyclerview/widget/RecyclerView$Adapter;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Adapter>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getBindingAdapter.()Landroidx/recyclerview/widget/RecyclerView$Adapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int BindingAdapterPosition
		{
			[Register("getBindingAdapterPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getBindingAdapterPosition.()I", this, null);
			}
		}

		public unsafe bool IsRecyclable
		{
			[Register("isRecyclable", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isRecyclable.()Z", this, null);
			}
			[Register("setIsRecyclable", "(Z)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("setIsRecyclable.(Z)V", this, ptr);
			}
		}

		public unsafe long ItemId
		{
			[Register("getItemId", "()J", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt64Method("getItemId.()J", this, null);
			}
		}

		public unsafe int ItemViewType
		{
			[Register("getItemViewType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getItemViewType.()I", this, null);
			}
		}

		public unsafe int LayoutPosition
		{
			[Register("getLayoutPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getLayoutPosition.()I", this, null);
			}
		}

		public unsafe int OldPosition
		{
			[Register("getOldPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getOldPosition.()I", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe int Position
		{
			[Register("getPosition", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getPosition.()I", this, null);
			}
		}

		protected ViewHolder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/view/View;)V", "")]
		public unsafe ViewHolder(View itemView)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(itemView?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/view/View;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(itemView);
			}
		}
	}

	[Register("androidx/recyclerview/widget/RecyclerView$ViewHolder", DoNotGenerateAcw = true)]
	internal class ViewHolderInvoker : ViewHolder
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView$ViewHolder", typeof(ViewHolderInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ViewHolderInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/RecyclerView", typeof(RecyclerView));

	private static Delegate? cb_getCompatAccessibilityDelegate_GetCompatAccessibilityDelegate_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_;

	private static Delegate? cb_hasFixedSize_HasFixedSize_Z;

	private static Delegate? cb_setHasFixedSize_SetHasFixedSize_Z_V;

	private static Delegate? cb_hasPendingAdapterUpdates_HasPendingAdapterUpdates_Z;

	private static Delegate? cb_isAnimating_IsAnimating_Z;

	private static Delegate? cb_isComputingLayout_IsComputingLayout_Z;

	private static Delegate? cb_getItemDecorationCount_GetItemDecorationCount_I;

	private static Delegate? cb_isLayoutFrozen_IsLayoutFrozen_Z;

	private static Delegate? cb_setLayoutFrozen_SetLayoutFrozen_Z_V;

	private static Delegate? cb_getMaxFlingVelocity_GetMaxFlingVelocity_I;

	private static Delegate? cb_getMinFlingVelocity_GetMinFlingVelocity_I;

	private static Delegate? cb_getPreserveFocusAfterLayout_GetPreserveFocusAfterLayout_Z;

	private static Delegate? cb_setPreserveFocusAfterLayout_SetPreserveFocusAfterLayout_Z_V;

	private static Delegate? cb_getScrollState_GetScrollState_I;

	private static Delegate? cb_addFocusables_AddFocusables_Ljava_util_ArrayList_II_V;

	private static Delegate? cb_addItemDecoration_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration__V;

	private static Delegate? cb_addItemDecoration_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_I_V;

	private static Delegate? cb_addOnChildAttachStateChangeListener_AddOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener__V;

	private static Delegate? cb_addOnItemTouchListener_AddOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener__V;

	private static Delegate? cb_addOnScrollListener_AddOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener__V;

	private static Delegate? cb_addRecyclerListener_AddRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener__V;

	private static Delegate? cb_clearOnChildAttachStateChangeListeners_ClearOnChildAttachStateChangeListeners_V;

	private static Delegate? cb_clearOnScrollListeners_ClearOnScrollListeners_V;

	private static Delegate? cb_computeHorizontalScrollExtent_ComputeHorizontalScrollExtent_I;

	private static Delegate? cb_computeHorizontalScrollOffset_ComputeHorizontalScrollOffset_I;

	private static Delegate? cb_computeHorizontalScrollRange_ComputeHorizontalScrollRange_I;

	private static Delegate? cb_computeVerticalScrollExtent_ComputeVerticalScrollExtent_I;

	private static Delegate? cb_computeVerticalScrollOffset_ComputeVerticalScrollOffset_I;

	private static Delegate? cb_computeVerticalScrollRange_ComputeVerticalScrollRange_I;

	private static Delegate? cb_dispatchNestedPreScroll_DispatchNestedPreScroll_IIarrayIarrayII_Z;

	private static Delegate? cb_dispatchNestedScroll_DispatchNestedScroll_IIIIarrayII_Z;

	private static Delegate? cb_dispatchRestoreInstanceState_DispatchRestoreInstanceState_Landroid_util_SparseArray__V;

	private static Delegate? cb_dispatchSaveInstanceState_DispatchSaveInstanceState_Landroid_util_SparseArray__V;

	private static Delegate? cb_drawChild_DrawChild_Landroid_graphics_Canvas_Landroid_view_View_J_Z;

	private static Delegate? cb_findChildViewUnder_FindChildViewUnder_FF_Landroid_view_View_;

	private static Delegate? cb_findContainingItemView_FindContainingItemView_Landroid_view_View__Landroid_view_View_;

	private static Delegate? cb_findContainingViewHolder_FindContainingViewHolder_Landroid_view_View__Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

	private static Delegate? cb_findViewHolderForAdapterPosition_FindViewHolderForAdapterPosition_I_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

	private static Delegate? cb_findViewHolderForItemId_FindViewHolderForItemId_J_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

	private static Delegate? cb_findViewHolderForLayoutPosition_FindViewHolderForLayoutPosition_I_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

	private static Delegate? cb_findViewHolderForPosition_FindViewHolderForPosition_I_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

	private static Delegate? cb_fling_Fling_II_Z;

	private static Delegate? cb_getAdapter_GetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_;

	private static Delegate? cb_getChildAdapterPosition_GetChildAdapterPosition_Landroid_view_View__I;

	private static Delegate? cb_getChildItemId_GetChildItemId_Landroid_view_View__J;

	private static Delegate? cb_getChildLayoutPosition_GetChildLayoutPosition_Landroid_view_View__I;

	private static Delegate? cb_getChildPosition_GetChildPosition_Landroid_view_View__I;

	private static Delegate? cb_getChildViewHolder_GetChildViewHolder_Landroid_view_View__Landroidx_recyclerview_widget_RecyclerView_ViewHolder_;

	private static Delegate? cb_getDecoratedBoundsWithMargins_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect__V;

	private static Delegate? cb_getEdgeEffectFactory_GetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_;

	private static Delegate? cb_getItemAnimator_GetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_;

	private static Delegate? cb_getItemDecorationAt_GetItemDecorationAt_I_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_;

	private static Delegate? cb_getLayoutManager_GetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_;

	private static Delegate? cb_getOnFlingListener_GetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_;

	private static Delegate? cb_getRecycledViewPool_GetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_;

	private static Delegate? cb_hasNestedScrollingParent_InvokeHasNestedScrollingParent_I_Z;

	private static Delegate? cb_invalidateItemDecorations_InvalidateItemDecorations_V;

	private static Delegate? cb_nestedScrollBy_NestedScrollBy_II_V;

	private static Delegate? cb_offsetChildrenHorizontal_OffsetChildrenHorizontal_I_V;

	private static Delegate? cb_offsetChildrenVertical_OffsetChildrenVertical_I_V;

	private static Delegate? cb_onChildAttachedToWindow_OnChildAttachedToWindow_Landroid_view_View__V;

	private static Delegate? cb_onChildDetachedFromWindow_OnChildDetachedFromWindow_Landroid_view_View__V;

	private static Delegate? cb_onDraw_OnDraw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_onScrollStateChanged_OnScrollStateChanged_I_V;

	private static Delegate? cb_onScrolled_OnScrolled_II_V;

	private static Delegate? cb_removeItemDecoration_RemoveItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration__V;

	private static Delegate? cb_removeItemDecorationAt_RemoveItemDecorationAt_I_V;

	private static Delegate? cb_removeOnChildAttachStateChangeListener_RemoveOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener__V;

	private static Delegate? cb_removeOnItemTouchListener_RemoveOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener__V;

	private static Delegate? cb_removeOnScrollListener_RemoveOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener__V;

	private static Delegate? cb_removeRecyclerListener_RemoveRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener__V;

	private static Delegate? cb_scrollToPosition_ScrollToPosition_I_V;

	private static Delegate? cb_setAccessibilityDelegateCompat_SetAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate__V;

	private static Delegate? cb_setAdapter_SetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter__V;

	private static Delegate? cb_setChildDrawingOrderCallback_SetChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback__V;

	private static Delegate? cb_setEdgeEffectFactory_SetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory__V;

	private static Delegate? cb_setItemAnimator_SetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator__V;

	private static Delegate? cb_setItemViewCacheSize_SetItemViewCacheSize_I_V;

	private static Delegate? cb_setLayoutManager_SetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager__V;

	private static Delegate? cb_setOnFlingListener_SetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener__V;

	private static Delegate? cb_setOnScrollListener_SetOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener__V;

	private static Delegate? cb_setRecycledViewPool_SetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool__V;

	private static Delegate? cb_setRecyclerListener_SetRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener__V;

	private static Delegate? cb_setScrollingTouchSlop_SetScrollingTouchSlop_I_V;

	private static Delegate? cb_setViewCacheExtension_SetViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension__V;

	private static Delegate? cb_smoothScrollBy_SmoothScrollBy_II_V;

	private static Delegate? cb_smoothScrollBy_SmoothScrollBy_IILandroid_view_animation_Interpolator__V;

	private static Delegate? cb_smoothScrollBy_SmoothScrollBy_IILandroid_view_animation_Interpolator_I_V;

	private static Delegate? cb_smoothScrollToPosition_SmoothScrollToPosition_I_V;

	private static Delegate? cb_startNestedScroll_StartNestedScroll_II_Z;

	private static Delegate? cb_stopNestedScroll_StopNestedScroll_I_V;

	private static Delegate? cb_stopScroll_StopScroll_V;

	private static Delegate? cb_swapAdapter_SwapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Z_V;

	private WeakReference? weak_implementor_AddOnChildAttachStateChangeListener;

	private WeakReference? weak_implementor_AddOnItemTouchListener;

	private WeakReference? weak_implementor_SetRecyclerListener;

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

	public unsafe virtual RecyclerViewAccessibilityDelegate? CompatAccessibilityDelegate
	{
		[Register("getCompatAccessibilityDelegate", "()Landroidx/recyclerview/widget/RecyclerViewAccessibilityDelegate;", "GetGetCompatAccessibilityDelegateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<RecyclerViewAccessibilityDelegate>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCompatAccessibilityDelegate.()Landroidx/recyclerview/widget/RecyclerViewAccessibilityDelegate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool HasFixedSize
	{
		[Register("hasFixedSize", "()Z", "GetHasFixedSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasFixedSize.()Z", this, null);
		}
		[Register("setHasFixedSize", "(Z)V", "GetSetHasFixedSize_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHasFixedSize.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool HasPendingAdapterUpdates
	{
		[Register("hasPendingAdapterUpdates", "()Z", "GetHasPendingAdapterUpdatesHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasPendingAdapterUpdates.()Z", this, null);
		}
	}

	public unsafe virtual bool IsAnimating
	{
		[Register("isAnimating", "()Z", "GetIsAnimatingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAnimating.()Z", this, null);
		}
	}

	public unsafe virtual bool IsComputingLayout
	{
		[Register("isComputingLayout", "()Z", "GetIsComputingLayoutHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isComputingLayout.()Z", this, null);
		}
	}

	public unsafe override bool IsLayoutSuppressed
	{
		[Register("isLayoutSuppressed", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isLayoutSuppressed.()Z", this, null);
		}
	}

	public unsafe virtual int ItemDecorationCount
	{
		[Register("getItemDecorationCount", "()I", "GetGetItemDecorationCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemDecorationCount.()I", this, null);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual bool LayoutFrozen
	{
		[Register("isLayoutFrozen", "()Z", "GetIsLayoutFrozenHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLayoutFrozen.()Z", this, null);
		}
		[Register("setLayoutFrozen", "(Z)V", "GetSetLayoutFrozen_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLayoutFrozen.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int MaxFlingVelocity
	{
		[Register("getMaxFlingVelocity", "()I", "GetGetMaxFlingVelocityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxFlingVelocity.()I", this, null);
		}
	}

	public unsafe virtual int MinFlingVelocity
	{
		[Register("getMinFlingVelocity", "()I", "GetGetMinFlingVelocityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMinFlingVelocity.()I", this, null);
		}
	}

	public unsafe virtual bool PreserveFocusAfterLayout
	{
		[Register("getPreserveFocusAfterLayout", "()Z", "GetGetPreserveFocusAfterLayoutHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getPreserveFocusAfterLayout.()Z", this, null);
		}
		[Register("setPreserveFocusAfterLayout", "(Z)V", "GetSetPreserveFocusAfterLayout_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPreserveFocusAfterLayout.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int ScrollState
	{
		[Register("getScrollState", "()I", "GetGetScrollStateHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getScrollState.()I", this, null);
		}
	}

	public event EventHandler<ChildViewAttachedToWindowEventArgs> ChildViewAttachedToWindow
	{
		add
		{
			EventHelper.AddEventHandler<IOnChildAttachStateChangeListener, IOnChildAttachStateChangeListenerImplementor>(ref weak_implementor_AddOnChildAttachStateChangeListener, __CreateIOnChildAttachStateChangeListenerImplementor, AddOnChildAttachStateChangeListener, delegate(IOnChildAttachStateChangeListenerImplementor __h)
			{
				__h.OnChildViewAttachedToWindowHandler = (EventHandler<ChildViewAttachedToWindowEventArgs>)Delegate.Combine(__h.OnChildViewAttachedToWindowHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnChildAttachStateChangeListener, IOnChildAttachStateChangeListenerImplementor.__IsEmpty, delegate(IOnChildAttachStateChangeListener __v)
			{
				RemoveOnChildAttachStateChangeListener(__v);
			}, delegate(IOnChildAttachStateChangeListenerImplementor __h)
			{
				__h.OnChildViewAttachedToWindowHandler = (EventHandler<ChildViewAttachedToWindowEventArgs>)Delegate.Remove(__h.OnChildViewAttachedToWindowHandler, value);
			});
		}
	}

	public event EventHandler<ChildViewDetachedFromWindowEventArgs> ChildViewDetachedFromWindow
	{
		add
		{
			EventHelper.AddEventHandler<IOnChildAttachStateChangeListener, IOnChildAttachStateChangeListenerImplementor>(ref weak_implementor_AddOnChildAttachStateChangeListener, __CreateIOnChildAttachStateChangeListenerImplementor, AddOnChildAttachStateChangeListener, delegate(IOnChildAttachStateChangeListenerImplementor __h)
			{
				__h.OnChildViewDetachedFromWindowHandler = (EventHandler<ChildViewDetachedFromWindowEventArgs>)Delegate.Combine(__h.OnChildViewDetachedFromWindowHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnChildAttachStateChangeListener, IOnChildAttachStateChangeListenerImplementor.__IsEmpty, delegate(IOnChildAttachStateChangeListener __v)
			{
				RemoveOnChildAttachStateChangeListener(__v);
			}, delegate(IOnChildAttachStateChangeListenerImplementor __h)
			{
				__h.OnChildViewDetachedFromWindowHandler = (EventHandler<ChildViewDetachedFromWindowEventArgs>)Delegate.Remove(__h.OnChildViewDetachedFromWindowHandler, value);
			});
		}
	}

	public event EventHandler<InterceptTouchEventEventArgs> InterceptTouchEvent
	{
		add
		{
			EventHelper.AddEventHandler<IOnItemTouchListener, IOnItemTouchListenerImplementor>(ref weak_implementor_AddOnItemTouchListener, __CreateIOnItemTouchListenerImplementor, AddOnItemTouchListener, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnInterceptTouchEventHandler = (EventHandler<InterceptTouchEventEventArgs>)Delegate.Combine(__h.OnInterceptTouchEventHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnItemTouchListener, IOnItemTouchListenerImplementor.__IsEmpty, delegate(IOnItemTouchListener __v)
			{
				RemoveOnItemTouchListener(__v);
			}, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnInterceptTouchEventHandler = (EventHandler<InterceptTouchEventEventArgs>)Delegate.Remove(__h.OnInterceptTouchEventHandler, value);
			});
		}
	}

	public new event EventHandler<RequestDisallowInterceptTouchEventEventArgs> RequestDisallowInterceptTouchEvent
	{
		add
		{
			EventHelper.AddEventHandler<IOnItemTouchListener, IOnItemTouchListenerImplementor>(ref weak_implementor_AddOnItemTouchListener, __CreateIOnItemTouchListenerImplementor, AddOnItemTouchListener, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnRequestDisallowInterceptTouchEventHandler = (EventHandler<RequestDisallowInterceptTouchEventEventArgs>)Delegate.Combine(__h.OnRequestDisallowInterceptTouchEventHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnItemTouchListener, IOnItemTouchListenerImplementor.__IsEmpty, delegate(IOnItemTouchListener __v)
			{
				RemoveOnItemTouchListener(__v);
			}, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnRequestDisallowInterceptTouchEventHandler = (EventHandler<RequestDisallowInterceptTouchEventEventArgs>)Delegate.Remove(__h.OnRequestDisallowInterceptTouchEventHandler, value);
			});
		}
	}

	public event EventHandler<TouchEventEventArgs> TouchEvent
	{
		add
		{
			EventHelper.AddEventHandler<IOnItemTouchListener, IOnItemTouchListenerImplementor>(ref weak_implementor_AddOnItemTouchListener, __CreateIOnItemTouchListenerImplementor, AddOnItemTouchListener, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnTouchEventHandler = (EventHandler<TouchEventEventArgs>)Delegate.Combine(__h.OnTouchEventHandler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler(ref weak_implementor_AddOnItemTouchListener, IOnItemTouchListenerImplementor.__IsEmpty, delegate(IOnItemTouchListener __v)
			{
				RemoveOnItemTouchListener(__v);
			}, delegate(IOnItemTouchListenerImplementor __h)
			{
				__h.OnTouchEventHandler = (EventHandler<TouchEventEventArgs>)Delegate.Remove(__h.OnTouchEventHandler, value);
			});
		}
	}

	public event EventHandler<RecyclerEventArgs> RecyclerEvent
	{
		add
		{
			EventHelper.AddEventHandler<IRecyclerListener, IRecyclerListenerImplementor>(ref weak_implementor_SetRecyclerListener, __CreateIRecyclerListenerImplementor, SetRecyclerListener, delegate(IRecyclerListenerImplementor __h)
			{
				__h.Handler = (EventHandler<RecyclerEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IRecyclerListener, IRecyclerListenerImplementor>(ref weak_implementor_SetRecyclerListener, IRecyclerListenerImplementor.__IsEmpty, delegate
			{
				SetRecyclerListener(null);
			}, delegate(IRecyclerListenerImplementor __h)
			{
				__h.Handler = (EventHandler<RecyclerEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected RecyclerView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe RecyclerView(Context context)
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
	public unsafe RecyclerView(Context context, IAttributeSet? attrs)
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
	public unsafe RecyclerView(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetGetCompatAccessibilityDelegateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCompatAccessibilityDelegate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCompatAccessibilityDelegate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatAccessibilityDelegate);
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

	private static Delegate GetHasFixedSizeHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasFixedSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasFixedSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFixedSize ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetHasFixedSize_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHasFixedSize_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHasFixedSize_Z(nint jnienv, nint native__this, sbyte native_hasFixedSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool hasFixedSize = native_hasFixedSize != 0;
			recyclerView.HasFixedSize = hasFixedSize;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetHasPendingAdapterUpdatesHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasPendingAdapterUpdates);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasPendingAdapterUpdates(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasPendingAdapterUpdates ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsAnimatingHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAnimating);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAnimating(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAnimating ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsComputingLayoutHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsComputingLayout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsComputingLayout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsComputingLayout ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetItemDecorationCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetItemDecorationCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemDecorationCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemDecorationCount;
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
	private static Delegate GetIsLayoutFrozenHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsLayoutFrozen);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsLayoutFrozen(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LayoutFrozen ? ((sbyte)1) : ((sbyte)0);
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
	private static Delegate GetSetLayoutFrozen_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetLayoutFrozen_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLayoutFrozen_Z(nint jnienv, nint native__this, sbyte native_frozen)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool layoutFrozen = native_frozen != 0;
			recyclerView.LayoutFrozen = layoutFrozen;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetMaxFlingVelocityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxFlingVelocity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxFlingVelocity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxFlingVelocity;
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

	private static Delegate GetGetMinFlingVelocityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMinFlingVelocity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMinFlingVelocity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinFlingVelocity;
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

	private static Delegate GetGetPreserveFocusAfterLayoutHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetPreserveFocusAfterLayout);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetPreserveFocusAfterLayout(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreserveFocusAfterLayout ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetPreserveFocusAfterLayout_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetPreserveFocusAfterLayout_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPreserveFocusAfterLayout_Z(nint jnienv, nint native__this, sbyte native_preserveFocusAfterLayout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool preserveFocusAfterLayout = native_preserveFocusAfterLayout != 0;
			recyclerView.PreserveFocusAfterLayout = preserveFocusAfterLayout;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetScrollStateHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetScrollState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetScrollState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollState;
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

	private static Delegate GetAddFocusables_Ljava_util_ArrayList_IIHandler()
	{
		return new global::_JniMarshal_PPLII_V(n_AddFocusables_Ljava_util_ArrayList_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddFocusables_Ljava_util_ArrayList_II(nint jnienv, nint native__this, nint native_views, int direction, int focusableMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<View> views = JavaList<View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			recyclerView.AddFocusables(views, direction, focusableMode);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addFocusables", "(Ljava/util/ArrayList;II)V", "GetAddFocusables_Ljava_util_ArrayList_IIHandler")]
	public unsafe virtual void AddFocusables(IList<View>? views, int direction, int focusableMode)
	{
		nint num = JavaList<View>.ToLocalJniHandle(views);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(direction);
			ptr[2] = new JniArgumentValue(focusableMode);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addFocusables.(Ljava/util/ArrayList;II)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(views);
		}
	}

	private static Delegate GetAddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_(nint jnienv, nint native__this, nint native_decor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ItemDecoration decor = Java.Lang.Object.GetObject<ItemDecoration>(native_decor, JniHandleOwnership.DoNotTransfer);
			recyclerView.AddItemDecoration(decor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addItemDecoration", "(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", "GetAddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_Handler")]
	public unsafe virtual void AddItemDecoration(ItemDecoration decor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(decor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addItemDecoration.(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decor);
		}
	}

	private static Delegate GetAddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_I(nint jnienv, nint native__this, nint native_decor, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ItemDecoration decor = Java.Lang.Object.GetObject<ItemDecoration>(native_decor, JniHandleOwnership.DoNotTransfer);
			recyclerView.AddItemDecoration(decor, index);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addItemDecoration", "(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;I)V", "GetAddItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_IHandler")]
	public unsafe virtual void AddItemDecoration(ItemDecoration decor, int index)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(decor?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(index);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addItemDecoration.(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decor);
		}
	}

	private static Delegate GetAddOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnChildAttachStateChangeListener listener = Java.Lang.Object.GetObject<IOnChildAttachStateChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.AddOnChildAttachStateChangeListener(listener);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addOnChildAttachStateChangeListener", "(Landroidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener;)V", "GetAddOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_Handler")]
	public unsafe virtual void AddOnChildAttachStateChangeListener(IOnChildAttachStateChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnChildAttachStateChangeListener.(Landroidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnItemTouchListener listener = Java.Lang.Object.GetObject<IOnItemTouchListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.AddOnItemTouchListener(listener);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addOnItemTouchListener", "(Landroidx/recyclerview/widget/RecyclerView$OnItemTouchListener;)V", "GetAddOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_Handler")]
	public unsafe virtual void AddOnItemTouchListener(IOnItemTouchListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnItemTouchListener.(Landroidx/recyclerview/widget/RecyclerView$OnItemTouchListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OnScrollListener listener = Java.Lang.Object.GetObject<OnScrollListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.AddOnScrollListener(listener);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addOnScrollListener", "(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", "GetAddOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler")]
	public unsafe virtual void AddOnScrollListener(OnScrollListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnScrollListener.(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRecyclerListener listener = Java.Lang.Object.GetObject<IRecyclerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.AddRecyclerListener(listener);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("addRecyclerListener", "(Landroidx/recyclerview/widget/RecyclerView$RecyclerListener;)V", "GetAddRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_Handler")]
	public unsafe virtual void AddRecyclerListener(IRecyclerListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addRecyclerListener.(Landroidx/recyclerview/widget/RecyclerView$RecyclerListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetClearOnChildAttachStateChangeListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnChildAttachStateChangeListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnChildAttachStateChangeListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnChildAttachStateChangeListeners();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("clearOnChildAttachStateChangeListeners", "()V", "GetClearOnChildAttachStateChangeListenersHandler")]
	public unsafe virtual void ClearOnChildAttachStateChangeListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnChildAttachStateChangeListeners.()V", this, null);
	}

	private static Delegate GetClearOnScrollListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnScrollListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnScrollListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnScrollListeners();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("clearOnScrollListeners", "()V", "GetClearOnScrollListenersHandler")]
	public unsafe virtual void ClearOnScrollListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnScrollListeners.()V", this, null);
	}

	private static Delegate GetComputeHorizontalScrollExtentHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeHorizontalScrollExtent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeHorizontalScrollExtent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollExtent();
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

	[Register("computeHorizontalScrollExtent", "()I", "GetComputeHorizontalScrollExtentHandler")]
	public new unsafe virtual int ComputeHorizontalScrollExtent()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollExtent.()I", this, null);
	}

	private static Delegate GetComputeHorizontalScrollOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeHorizontalScrollOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeHorizontalScrollOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollOffset();
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

	[Register("computeHorizontalScrollOffset", "()I", "GetComputeHorizontalScrollOffsetHandler")]
	public new unsafe virtual int ComputeHorizontalScrollOffset()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollOffset.()I", this, null);
	}

	private static Delegate GetComputeHorizontalScrollRangeHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeHorizontalScrollRange);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeHorizontalScrollRange(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeHorizontalScrollRange();
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

	[Register("computeHorizontalScrollRange", "()I", "GetComputeHorizontalScrollRangeHandler")]
	public new unsafe virtual int ComputeHorizontalScrollRange()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeHorizontalScrollRange.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollExtentHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeVerticalScrollExtent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeVerticalScrollExtent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollExtent();
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

	[Register("computeVerticalScrollExtent", "()I", "GetComputeVerticalScrollExtentHandler")]
	public new unsafe virtual int ComputeVerticalScrollExtent()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollExtent.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeVerticalScrollOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeVerticalScrollOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollOffset();
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

	[Register("computeVerticalScrollOffset", "()I", "GetComputeVerticalScrollOffsetHandler")]
	public new unsafe virtual int ComputeVerticalScrollOffset()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollOffset.()I", this, null);
	}

	private static Delegate GetComputeVerticalScrollRangeHandler()
	{
		return new global::_JniMarshal_PP_I(n_ComputeVerticalScrollRange);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_ComputeVerticalScrollRange(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ComputeVerticalScrollRange();
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

	[Register("computeVerticalScrollRange", "()I", "GetComputeVerticalScrollRangeHandler")]
	public new unsafe virtual int ComputeVerticalScrollRange()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("computeVerticalScrollRange.()I", this, null);
	}

	private static Delegate GetDispatchNestedPreScroll_IIarrayIarrayIIHandler()
	{
		return new global::_JniMarshal_PPIILLI_B(n_DispatchNestedPreScroll_IIarrayIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchNestedPreScroll_IIarrayIarrayII(nint jnienv, nint native__this, int dx, int dy, nint native_consumed, nint native_offsetInWindow, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_consumed, JniHandleOwnership.DoNotTransfer, typeof(int));
			int[] array2 = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (recyclerView.DispatchNestedPreScroll(dx, dy, array, array2, type) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_consumed);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_offsetInWindow);
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

	[Register("dispatchNestedPreScroll", "(II[I[II)Z", "GetDispatchNestedPreScroll_IIarrayIarrayIIHandler")]
	public unsafe virtual bool DispatchNestedPreScroll(int dx, int dy, int[]? consumed, int[]? offsetInWindow, int type)
	{
		nint num = JNIEnv.NewArray(consumed);
		nint num2 = JNIEnv.NewArray(offsetInWindow);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(dx);
			ptr[1] = new JniArgumentValue(dy);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(num2);
			ptr[4] = new JniArgumentValue(type);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchNestedPreScroll.(II[I[II)Z", this, ptr);
		}
		finally
		{
			if (consumed != null)
			{
				JNIEnv.CopyArray(num, consumed);
				JNIEnv.DeleteLocalRef(num);
			}
			if (offsetInWindow != null)
			{
				JNIEnv.CopyArray(num2, offsetInWindow);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(consumed);
			GC.KeepAlive(offsetInWindow);
		}
	}

	private static Delegate GetDispatchNestedScroll_IIIIarrayIIHandler()
	{
		return new global::_JniMarshal_PPIIIILI_B(n_DispatchNestedScroll_IIIIarrayII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchNestedScroll_IIIIarrayII(nint jnienv, nint native__this, int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, nint native_offsetInWindow, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_offsetInWindow, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (recyclerView.DispatchNestedScroll(dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, array, type) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_offsetInWindow);
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

	[Register("dispatchNestedScroll", "(IIII[II)Z", "GetDispatchNestedScroll_IIIIarrayIIHandler")]
	public unsafe virtual bool DispatchNestedScroll(int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[]? offsetInWindow, int type)
	{
		nint num = JNIEnv.NewArray(offsetInWindow);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(dxConsumed);
			ptr[1] = new JniArgumentValue(dyConsumed);
			ptr[2] = new JniArgumentValue(dxUnconsumed);
			ptr[3] = new JniArgumentValue(dyUnconsumed);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(type);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchNestedScroll.(IIII[II)Z", this, ptr);
		}
		finally
		{
			if (offsetInWindow != null)
			{
				JNIEnv.CopyArray(num, offsetInWindow);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(offsetInWindow);
		}
	}

	[Register("dispatchNestedScroll", "(IIII[II[I)V", "")]
	public unsafe void DispatchNestedScroll(int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[]? offsetInWindow, int type, int[] consumed)
	{
		nint num = JNIEnv.NewArray(offsetInWindow);
		nint num2 = JNIEnv.NewArray(consumed);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
			*ptr = new JniArgumentValue(dxConsumed);
			ptr[1] = new JniArgumentValue(dyConsumed);
			ptr[2] = new JniArgumentValue(dxUnconsumed);
			ptr[3] = new JniArgumentValue(dyUnconsumed);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(type);
			ptr[6] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("dispatchNestedScroll.(IIII[II[I)V", this, ptr);
		}
		finally
		{
			if (offsetInWindow != null)
			{
				JNIEnv.CopyArray(num, offsetInWindow);
				JNIEnv.DeleteLocalRef(num);
			}
			if (consumed != null)
			{
				JNIEnv.CopyArray(num2, consumed);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(offsetInWindow);
			GC.KeepAlive(consumed);
		}
	}

	private static Delegate GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_DispatchRestoreInstanceState_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchRestoreInstanceState_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SparseArray container = Java.Lang.Object.GetObject<SparseArray>(native_container, JniHandleOwnership.DoNotTransfer);
			recyclerView.DispatchRestoreInstanceState(container);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dispatchRestoreInstanceState", "(Landroid/util/SparseArray;)V", "GetDispatchRestoreInstanceState_Landroid_util_SparseArray_Handler")]
	protected unsafe override void DispatchRestoreInstanceState(SparseArray? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchRestoreInstanceState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetDispatchSaveInstanceState_Landroid_util_SparseArray_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_DispatchSaveInstanceState_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DispatchSaveInstanceState_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SparseArray container = Java.Lang.Object.GetObject<SparseArray>(native_container, JniHandleOwnership.DoNotTransfer);
			recyclerView.DispatchSaveInstanceState(container);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dispatchSaveInstanceState", "(Landroid/util/SparseArray;)V", "GetDispatchSaveInstanceState_Landroid_util_SparseArray_Handler")]
	protected unsafe override void DispatchSaveInstanceState(SparseArray? container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchSaveInstanceState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetDrawChild_Landroid_graphics_Canvas_Landroid_view_View_JHandler()
	{
		return new global::_JniMarshal_PPLLJ_B(n_DrawChild_Landroid_graphics_Canvas_Landroid_view_View_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DrawChild_Landroid_graphics_Canvas_Landroid_view_View_J(nint jnienv, nint native__this, nint native_canvas, nint native_child, long drawingTime)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return recyclerView.DrawChild(canvas, child, drawingTime) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("drawChild", "(Landroid/graphics/Canvas;Landroid/view/View;J)Z", "GetDrawChild_Landroid_graphics_Canvas_Landroid_view_View_JHandler")]
	public new unsafe virtual bool DrawChild(Canvas canvas, View? child, long drawingTime)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(drawingTime);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("drawChild.(Landroid/graphics/Canvas;Landroid/view/View;J)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetFindChildViewUnder_FFHandler()
	{
		return new _JniMarshal_PPFF_L(n_FindChildViewUnder_FF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindChildViewUnder_FF(nint jnienv, nint native__this, float x, float y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindChildViewUnder(x, y));
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

	[Register("findChildViewUnder", "(FF)Landroid/view/View;", "GetFindChildViewUnder_FFHandler")]
	public unsafe virtual View? FindChildViewUnder(float x, float y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findChildViewUnder.(FF)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindContainingItemView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_FindContainingItemView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindContainingItemView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(recyclerView.FindContainingItemView(view));
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

	[Register("findContainingItemView", "(Landroid/view/View;)Landroid/view/View;", "GetFindContainingItemView_Landroid_view_View_Handler")]
	public unsafe virtual View? FindContainingItemView(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("findContainingItemView.(Landroid/view/View;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetFindContainingViewHolder_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_FindContainingViewHolder_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindContainingViewHolder_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(recyclerView.FindContainingViewHolder(view));
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

	[Register("findContainingViewHolder", "(Landroid/view/View;)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindContainingViewHolder_Landroid_view_View_Handler")]
	public unsafe virtual ViewHolder? FindContainingViewHolder(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findContainingViewHolder.(Landroid/view/View;)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetFindViewHolderForAdapterPosition_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindViewHolderForAdapterPosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindViewHolderForAdapterPosition_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewHolderForAdapterPosition(position));
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

	[Register("findViewHolderForAdapterPosition", "(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindViewHolderForAdapterPosition_IHandler")]
	public unsafe virtual ViewHolder? FindViewHolderForAdapterPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewHolderForAdapterPosition.(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindViewHolderForItemId_JHandler()
	{
		return new global::_JniMarshal_PPJ_L(n_FindViewHolderForItemId_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindViewHolderForItemId_J(nint jnienv, nint native__this, long id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewHolderForItemId(id));
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

	[Register("findViewHolderForItemId", "(J)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindViewHolderForItemId_JHandler")]
	public unsafe virtual ViewHolder? FindViewHolderForItemId(long id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewHolderForItemId.(J)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindViewHolderForLayoutPosition_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindViewHolderForLayoutPosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindViewHolderForLayoutPosition_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewHolderForLayoutPosition(position));
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

	[Register("findViewHolderForLayoutPosition", "(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindViewHolderForLayoutPosition_IHandler")]
	public unsafe virtual ViewHolder? FindViewHolderForLayoutPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewHolderForLayoutPosition.(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetFindViewHolderForPosition_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindViewHolderForPosition_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindViewHolderForPosition_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewHolderForPosition(position));
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

	[Obsolete("deprecated")]
	[Register("findViewHolderForPosition", "(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetFindViewHolderForPosition_IHandler")]
	public unsafe virtual ViewHolder? FindViewHolderForPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("findViewHolderForPosition.(I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFling_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_Fling_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Fling_II(nint jnienv, nint native__this, int velocityX, int velocityY)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Fling(velocityX, velocityY) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("fling", "(II)Z", "GetFling_IIHandler")]
	public unsafe virtual bool Fling(int velocityX, int velocityY)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(velocityX);
		ptr[1] = new JniArgumentValue(velocityY);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("fling.(II)Z", this, ptr);
	}

	private static Delegate GetGetAdapterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAdapter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAdapter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAdapter());
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

	[Register("getAdapter", "()Landroidx/recyclerview/widget/RecyclerView$Adapter;", "GetGetAdapterHandler")]
	public unsafe virtual Adapter? GetAdapter()
	{
		return Java.Lang.Object.GetObject<Adapter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAdapter.()Landroidx/recyclerview/widget/RecyclerView$Adapter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetChildAdapterPosition_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetChildAdapterPosition_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetChildAdapterPosition_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return recyclerView.GetChildAdapterPosition(child);
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

	[Register("getChildAdapterPosition", "(Landroid/view/View;)I", "GetGetChildAdapterPosition_Landroid_view_View_Handler")]
	public unsafe virtual int GetChildAdapterPosition(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getChildAdapterPosition.(Landroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetChildItemId_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_J(n_GetChildItemId_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetChildItemId_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return recyclerView.GetChildItemId(child);
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

	[Register("getChildItemId", "(Landroid/view/View;)J", "GetGetChildItemId_Landroid_view_View_Handler")]
	public unsafe virtual long GetChildItemId(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt64Method("getChildItemId.(Landroid/view/View;)J", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetChildLayoutPosition_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetChildLayoutPosition_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetChildLayoutPosition_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return recyclerView.GetChildLayoutPosition(child);
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

	[Register("getChildLayoutPosition", "(Landroid/view/View;)I", "GetGetChildLayoutPosition_Landroid_view_View_Handler")]
	public unsafe virtual int GetChildLayoutPosition(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getChildLayoutPosition.(Landroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	[Obsolete]
	private static Delegate GetGetChildPosition_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetChildPosition_Landroid_view_View_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetChildPosition_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return recyclerView.GetChildPosition(child);
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

	[Obsolete("deprecated")]
	[Register("getChildPosition", "(Landroid/view/View;)I", "GetGetChildPosition_Landroid_view_View_Handler")]
	public unsafe virtual int GetChildPosition(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getChildPosition.(Landroid/view/View;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetChildViewHolder_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetChildViewHolder_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetChildViewHolder_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(recyclerView.GetChildViewHolder(child));
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

	[Register("getChildViewHolder", "(Landroid/view/View;)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", "GetGetChildViewHolder_Landroid_view_View_Handler")]
	public unsafe virtual ViewHolder? GetChildViewHolder(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ViewHolder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChildViewHolder.(Landroid/view/View;)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetGetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_view, nint native_outBounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			Rect outBounds = Java.Lang.Object.GetObject<Rect>(native_outBounds, JniHandleOwnership.DoNotTransfer);
			recyclerView.GetDecoratedBoundsWithMargins(view, outBounds);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getDecoratedBoundsWithMargins", "(Landroid/view/View;Landroid/graphics/Rect;)V", "GetGetDecoratedBoundsWithMargins_Landroid_view_View_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void GetDecoratedBoundsWithMargins(View view, Rect outBounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(outBounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getDecoratedBoundsWithMargins.(Landroid/view/View;Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(outBounds);
		}
	}

	private static Delegate GetGetEdgeEffectFactoryHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetEdgeEffectFactory);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEdgeEffectFactory(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetEdgeEffectFactory());
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

	[Register("getEdgeEffectFactory", "()Landroidx/recyclerview/widget/RecyclerView$EdgeEffectFactory;", "GetGetEdgeEffectFactoryHandler")]
	public unsafe virtual EdgeEffectFactory GetEdgeEffectFactory()
	{
		return Java.Lang.Object.GetObject<EdgeEffectFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEdgeEffectFactory.()Landroidx/recyclerview/widget/RecyclerView$EdgeEffectFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetItemAnimatorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetItemAnimator);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemAnimator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemAnimator());
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

	[Register("getItemAnimator", "()Landroidx/recyclerview/widget/RecyclerView$ItemAnimator;", "GetGetItemAnimatorHandler")]
	public unsafe virtual ItemAnimator? GetItemAnimator()
	{
		return Java.Lang.Object.GetObject<ItemAnimator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemAnimator.()Landroidx/recyclerview/widget/RecyclerView$ItemAnimator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetItemDecorationAt_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetItemDecorationAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItemDecorationAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemDecorationAt(index));
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

	[Register("getItemDecorationAt", "(I)Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;", "GetGetItemDecorationAt_IHandler")]
	public unsafe virtual ItemDecoration GetItemDecorationAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<ItemDecoration>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItemDecorationAt.(I)Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetLayoutManagerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLayoutManager);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLayoutManager(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLayoutManager());
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

	[Register("getLayoutManager", "()Landroidx/recyclerview/widget/RecyclerView$LayoutManager;", "GetGetLayoutManagerHandler")]
	public unsafe virtual LayoutManager? GetLayoutManager()
	{
		return Java.Lang.Object.GetObject<LayoutManager>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLayoutManager.()Landroidx/recyclerview/widget/RecyclerView$LayoutManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetOnFlingListenerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetOnFlingListener);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetOnFlingListener(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetOnFlingListener());
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

	[Register("getOnFlingListener", "()Landroidx/recyclerview/widget/RecyclerView$OnFlingListener;", "GetGetOnFlingListenerHandler")]
	public unsafe virtual OnFlingListener? GetOnFlingListener()
	{
		return Java.Lang.Object.GetObject<OnFlingListener>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOnFlingListener.()Landroidx/recyclerview/widget/RecyclerView$OnFlingListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetRecycledViewPoolHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRecycledViewPool);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRecycledViewPool(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRecycledViewPool());
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

	[Register("getRecycledViewPool", "()Landroidx/recyclerview/widget/RecyclerView$RecycledViewPool;", "GetGetRecycledViewPoolHandler")]
	public unsafe virtual RecycledViewPool GetRecycledViewPool()
	{
		return Java.Lang.Object.GetObject<RecycledViewPool>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRecycledViewPool.()Landroidx/recyclerview/widget/RecyclerView$RecycledViewPool;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetInvokeHasNestedScrollingParent_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_InvokeHasNestedScrollingParent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_InvokeHasNestedScrollingParent_I(nint jnienv, nint native__this, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvokeHasNestedScrollingParent(type) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hasNestedScrollingParent", "(I)Z", "GetInvokeHasNestedScrollingParent_IHandler")]
	public unsafe virtual bool InvokeHasNestedScrollingParent(int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(type);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasNestedScrollingParent.(I)Z", this, ptr);
	}

	private static Delegate GetInvalidateItemDecorationsHandler()
	{
		return new global::_JniMarshal_PP_V(n_InvalidateItemDecorations);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InvalidateItemDecorations(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateItemDecorations();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("invalidateItemDecorations", "()V", "GetInvalidateItemDecorationsHandler")]
	public unsafe virtual void InvalidateItemDecorations()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateItemDecorations.()V", this, null);
	}

	private static Delegate GetNestedScrollBy_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_NestedScrollBy_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_NestedScrollBy_II(nint jnienv, nint native__this, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NestedScrollBy(x, y);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("nestedScrollBy", "(II)V", "GetNestedScrollBy_IIHandler")]
	public unsafe virtual void NestedScrollBy(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		_members.InstanceMethods.InvokeVirtualVoidMethod("nestedScrollBy.(II)V", this, ptr);
	}

	private static Delegate GetOffsetChildrenHorizontal_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_OffsetChildrenHorizontal_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OffsetChildrenHorizontal_I(nint jnienv, nint native__this, int dx)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetChildrenHorizontal(dx);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("offsetChildrenHorizontal", "(I)V", "GetOffsetChildrenHorizontal_IHandler")]
	public unsafe virtual void OffsetChildrenHorizontal(int dx)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dx);
		_members.InstanceMethods.InvokeVirtualVoidMethod("offsetChildrenHorizontal.(I)V", this, ptr);
	}

	private static Delegate GetOffsetChildrenVertical_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_OffsetChildrenVertical_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OffsetChildrenVertical_I(nint jnienv, nint native__this, int dy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OffsetChildrenVertical(dy);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("offsetChildrenVertical", "(I)V", "GetOffsetChildrenVertical_IHandler")]
	public unsafe virtual void OffsetChildrenVertical(int dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("offsetChildrenVertical.(I)V", this, ptr);
	}

	private static Delegate GetOnChildAttachedToWindow_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnChildAttachedToWindow_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnChildAttachedToWindow_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			recyclerView.OnChildAttachedToWindow(child);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onChildAttachedToWindow", "(Landroid/view/View;)V", "GetOnChildAttachedToWindow_Landroid_view_View_Handler")]
	public unsafe virtual void OnChildAttachedToWindow(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onChildAttachedToWindow.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnChildDetachedFromWindow_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnChildDetachedFromWindow_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnChildDetachedFromWindow_Landroid_view_View_(nint jnienv, nint native__this, nint native_child)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View child = Java.Lang.Object.GetObject<View>(native_child, JniHandleOwnership.DoNotTransfer);
			recyclerView.OnChildDetachedFromWindow(child);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onChildDetachedFromWindow", "(Landroid/view/View;)V", "GetOnChildDetachedFromWindow_Landroid_view_View_Handler")]
	public unsafe virtual void OnChildDetachedFromWindow(View child)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(child?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onChildDetachedFromWindow.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(child);
		}
	}

	private static Delegate GetOnDraw_Landroid_graphics_Canvas_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnDraw_Landroid_graphics_Canvas_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDraw_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas c = Java.Lang.Object.GetObject<Canvas>(native_c, JniHandleOwnership.DoNotTransfer);
			recyclerView.OnDraw(c);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onDraw", "(Landroid/graphics/Canvas;)V", "GetOnDraw_Landroid_graphics_Canvas_Handler")]
	public new unsafe virtual void OnDraw(Canvas c)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDraw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetOnLayout_ZIIIIHandler()
	{
		return new global::_JniMarshal_PPBIIII_V(n_OnLayout_ZIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLayout_ZIIII(nint jnienv, nint native__this, sbyte native_changed, int l, int t, int r, int b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			recyclerView.OnLayout(changed, l, t, r, b);
		}
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
	protected unsafe override void OnLayout(bool changed, int l, int t, int r, int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(l);
		ptr[2] = new JniArgumentValue(t);
		ptr[3] = new JniArgumentValue(r);
		ptr[4] = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}

	private static Delegate GetOnScrollStateChanged_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_OnScrollStateChanged_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnScrollStateChanged_I(nint jnienv, nint native__this, int state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScrollStateChanged(state);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onScrollStateChanged", "(I)V", "GetOnScrollStateChanged_IHandler")]
	public unsafe virtual void OnScrollStateChanged(int state)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(state);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onScrollStateChanged.(I)V", this, ptr);
	}

	private static Delegate GetOnScrolled_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_OnScrolled_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnScrolled_II(nint jnienv, nint native__this, int dx, int dy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScrolled(dx, dy);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onScrolled", "(II)V", "GetOnScrolled_IIHandler")]
	public unsafe virtual void OnScrolled(int dx, int dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dx);
		ptr[1] = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onScrolled.(II)V", this, ptr);
	}

	private static Delegate GetRemoveItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_(nint jnienv, nint native__this, nint native_decor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ItemDecoration decor = Java.Lang.Object.GetObject<ItemDecoration>(native_decor, JniHandleOwnership.DoNotTransfer);
			recyclerView.RemoveItemDecoration(decor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeItemDecoration", "(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", "GetRemoveItemDecoration_Landroidx_recyclerview_widget_RecyclerView_ItemDecoration_Handler")]
	public unsafe virtual void RemoveItemDecoration(ItemDecoration decor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(decor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeItemDecoration.(Landroidx/recyclerview/widget/RecyclerView$ItemDecoration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(decor);
		}
	}

	private static Delegate GetRemoveItemDecorationAt_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveItemDecorationAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveItemDecorationAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveItemDecorationAt(index);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeItemDecorationAt", "(I)V", "GetRemoveItemDecorationAt_IHandler")]
	public unsafe virtual void RemoveItemDecorationAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeItemDecorationAt.(I)V", this, ptr);
	}

	private static Delegate GetRemoveOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnChildAttachStateChangeListener listener = Java.Lang.Object.GetObject<IOnChildAttachStateChangeListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.RemoveOnChildAttachStateChangeListener(listener);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeOnChildAttachStateChangeListener", "(Landroidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener;)V", "GetRemoveOnChildAttachStateChangeListener_Landroidx_recyclerview_widget_RecyclerView_OnChildAttachStateChangeListener_Handler")]
	public unsafe virtual void RemoveOnChildAttachStateChangeListener(IOnChildAttachStateChangeListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnChildAttachStateChangeListener.(Landroidx/recyclerview/widget/RecyclerView$OnChildAttachStateChangeListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnItemTouchListener listener = Java.Lang.Object.GetObject<IOnItemTouchListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.RemoveOnItemTouchListener(listener);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeOnItemTouchListener", "(Landroidx/recyclerview/widget/RecyclerView$OnItemTouchListener;)V", "GetRemoveOnItemTouchListener_Landroidx_recyclerview_widget_RecyclerView_OnItemTouchListener_Handler")]
	public unsafe virtual void RemoveOnItemTouchListener(IOnItemTouchListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnItemTouchListener.(Landroidx/recyclerview/widget/RecyclerView$OnItemTouchListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OnScrollListener listener = Java.Lang.Object.GetObject<OnScrollListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.RemoveOnScrollListener(listener);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeOnScrollListener", "(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", "GetRemoveOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler")]
	public unsafe virtual void RemoveOnScrollListener(OnScrollListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnScrollListener.(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRecyclerListener listener = Java.Lang.Object.GetObject<IRecyclerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.RemoveRecyclerListener(listener);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeRecyclerListener", "(Landroidx/recyclerview/widget/RecyclerView$RecyclerListener;)V", "GetRemoveRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_Handler")]
	public unsafe virtual void RemoveRecyclerListener(IRecyclerListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeRecyclerListener.(Landroidx/recyclerview/widget/RecyclerView$RecyclerListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetScrollToPosition_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_ScrollToPosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ScrollToPosition_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollToPosition(position);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("scrollToPosition", "(I)V", "GetScrollToPosition_IHandler")]
	public unsafe virtual void ScrollToPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("scrollToPosition.(I)V", this, ptr);
	}

	private static Delegate GetSetAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_(nint jnienv, nint native__this, nint native_accessibilityDelegate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecyclerViewAccessibilityDelegate accessibilityDelegateCompat = Java.Lang.Object.GetObject<RecyclerViewAccessibilityDelegate>(native_accessibilityDelegate, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetAccessibilityDelegateCompat(accessibilityDelegateCompat);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setAccessibilityDelegateCompat", "(Landroidx/recyclerview/widget/RecyclerViewAccessibilityDelegate;)V", "GetSetAccessibilityDelegateCompat_Landroidx_recyclerview_widget_RecyclerViewAccessibilityDelegate_Handler")]
	public unsafe virtual void SetAccessibilityDelegateCompat(RecyclerViewAccessibilityDelegate? accessibilityDelegate)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(accessibilityDelegate?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAccessibilityDelegateCompat.(Landroidx/recyclerview/widget/RecyclerViewAccessibilityDelegate;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(accessibilityDelegate);
		}
	}

	private static Delegate GetSetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_(nint jnienv, nint native__this, nint native_adapter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetAdapter(adapter);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setAdapter", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", "GetSetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Handler")]
	public unsafe virtual void SetAdapter(Adapter? adapter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(adapter?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setAdapter.(Landroidx/recyclerview/widget/RecyclerView$Adapter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapter);
		}
	}

	private static Delegate GetSetChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_(nint jnienv, nint native__this, nint native_childDrawingOrderCallback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IChildDrawingOrderCallback childDrawingOrderCallback = Java.Lang.Object.GetObject<IChildDrawingOrderCallback>(native_childDrawingOrderCallback, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetChildDrawingOrderCallback(childDrawingOrderCallback);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setChildDrawingOrderCallback", "(Landroidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback;)V", "GetSetChildDrawingOrderCallback_Landroidx_recyclerview_widget_RecyclerView_ChildDrawingOrderCallback_Handler")]
	public unsafe virtual void SetChildDrawingOrderCallback(IChildDrawingOrderCallback? childDrawingOrderCallback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((childDrawingOrderCallback == null) ? IntPtr.Zero : ((Java.Lang.Object)childDrawingOrderCallback).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setChildDrawingOrderCallback.(Landroidx/recyclerview/widget/RecyclerView$ChildDrawingOrderCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(childDrawingOrderCallback);
		}
	}

	[Register("setDebugAssertionsEnabled", "(Z)V", "")]
	public unsafe static void SetDebugAssertionsEnabled(bool debugAssertionsEnabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(debugAssertionsEnabled ? ((sbyte)1) : ((sbyte)0));
		_members.StaticMethods.InvokeVoidMethod("setDebugAssertionsEnabled.(Z)V", ptr);
	}

	private static Delegate GetSetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_(nint jnienv, nint native__this, nint native_edgeEffectFactory)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EdgeEffectFactory edgeEffectFactory = Java.Lang.Object.GetObject<EdgeEffectFactory>(native_edgeEffectFactory, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetEdgeEffectFactory(edgeEffectFactory);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setEdgeEffectFactory", "(Landroidx/recyclerview/widget/RecyclerView$EdgeEffectFactory;)V", "GetSetEdgeEffectFactory_Landroidx_recyclerview_widget_RecyclerView_EdgeEffectFactory_Handler")]
	public unsafe virtual void SetEdgeEffectFactory(EdgeEffectFactory edgeEffectFactory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(edgeEffectFactory?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setEdgeEffectFactory.(Landroidx/recyclerview/widget/RecyclerView$EdgeEffectFactory;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(edgeEffectFactory);
		}
	}

	private static Delegate GetSetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_(nint jnienv, nint native__this, nint native_animator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ItemAnimator itemAnimator = Java.Lang.Object.GetObject<ItemAnimator>(native_animator, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetItemAnimator(itemAnimator);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setItemAnimator", "(Landroidx/recyclerview/widget/RecyclerView$ItemAnimator;)V", "GetSetItemAnimator_Landroidx_recyclerview_widget_RecyclerView_ItemAnimator_Handler")]
	public unsafe virtual void SetItemAnimator(ItemAnimator? animator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animator?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setItemAnimator.(Landroidx/recyclerview/widget/RecyclerView$ItemAnimator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(animator);
		}
	}

	private static Delegate GetSetItemViewCacheSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetItemViewCacheSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetItemViewCacheSize_I(nint jnienv, nint native__this, int size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetItemViewCacheSize(size);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setItemViewCacheSize", "(I)V", "GetSetItemViewCacheSize_IHandler")]
	public unsafe virtual void SetItemViewCacheSize(int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(size);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setItemViewCacheSize.(I)V", this, ptr);
	}

	private static Delegate GetSetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_(nint jnienv, nint native__this, nint native_layout)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LayoutManager layoutManager = Java.Lang.Object.GetObject<LayoutManager>(native_layout, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetLayoutManager(layoutManager);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setLayoutManager", "(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)V", "GetSetLayoutManager_Landroidx_recyclerview_widget_RecyclerView_LayoutManager_Handler")]
	public unsafe virtual void SetLayoutManager(LayoutManager? layout)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLayoutManager.(Landroidx/recyclerview/widget/RecyclerView$LayoutManager;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(layout);
		}
	}

	private static Delegate GetSetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_(nint jnienv, nint native__this, nint native_onFlingListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OnFlingListener onFlingListener = Java.Lang.Object.GetObject<OnFlingListener>(native_onFlingListener, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetOnFlingListener(onFlingListener);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setOnFlingListener", "(Landroidx/recyclerview/widget/RecyclerView$OnFlingListener;)V", "GetSetOnFlingListener_Landroidx_recyclerview_widget_RecyclerView_OnFlingListener_Handler")]
	public unsafe virtual void SetOnFlingListener(OnFlingListener? onFlingListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(onFlingListener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnFlingListener.(Landroidx/recyclerview/widget/RecyclerView$OnFlingListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(onFlingListener);
		}
	}

	[Obsolete]
	private static Delegate GetSetOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OnScrollListener onScrollListener = Java.Lang.Object.GetObject<OnScrollListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetOnScrollListener(onScrollListener);
		}
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
	[Register("setOnScrollListener", "(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", "GetSetOnScrollListener_Landroidx_recyclerview_widget_RecyclerView_OnScrollListener_Handler")]
	public unsafe virtual void SetOnScrollListener(OnScrollListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnScrollListener.(Landroidx/recyclerview/widget/RecyclerView$OnScrollListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_(nint jnienv, nint native__this, nint native_pool)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RecycledViewPool recycledViewPool = Java.Lang.Object.GetObject<RecycledViewPool>(native_pool, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetRecycledViewPool(recycledViewPool);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setRecycledViewPool", "(Landroidx/recyclerview/widget/RecyclerView$RecycledViewPool;)V", "GetSetRecycledViewPool_Landroidx_recyclerview_widget_RecyclerView_RecycledViewPool_Handler")]
	public unsafe virtual void SetRecycledViewPool(RecycledViewPool? pool)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pool?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRecycledViewPool.(Landroidx/recyclerview/widget/RecyclerView$RecycledViewPool;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pool);
		}
	}

	[Obsolete]
	private static Delegate GetSetRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRecyclerListener recyclerListener = Java.Lang.Object.GetObject<IRecyclerListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetRecyclerListener(recyclerListener);
		}
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
	[Register("setRecyclerListener", "(Landroidx/recyclerview/widget/RecyclerView$RecyclerListener;)V", "GetSetRecyclerListener_Landroidx_recyclerview_widget_RecyclerView_RecyclerListener_Handler")]
	public unsafe virtual void SetRecyclerListener(IRecyclerListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRecyclerListener.(Landroidx/recyclerview/widget/RecyclerView$RecyclerListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetScrollingTouchSlop_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetScrollingTouchSlop_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScrollingTouchSlop_I(nint jnienv, nint native__this, int slopConstant)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetScrollingTouchSlop(slopConstant);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setScrollingTouchSlop", "(I)V", "GetSetScrollingTouchSlop_IHandler")]
	public unsafe virtual void SetScrollingTouchSlop(int slopConstant)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(slopConstant);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setScrollingTouchSlop.(I)V", this, ptr);
	}

	[Register("setVerboseLoggingEnabled", "(Z)V", "")]
	public unsafe static void SetVerboseLoggingEnabled(bool verboseLoggingEnabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(verboseLoggingEnabled ? ((sbyte)1) : ((sbyte)0));
		_members.StaticMethods.InvokeVoidMethod("setVerboseLoggingEnabled.(Z)V", ptr);
	}

	private static Delegate GetSetViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_(nint jnienv, nint native__this, nint native_extension)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewCacheExtension viewCacheExtension = Java.Lang.Object.GetObject<ViewCacheExtension>(native_extension, JniHandleOwnership.DoNotTransfer);
			recyclerView.SetViewCacheExtension(viewCacheExtension);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setViewCacheExtension", "(Landroidx/recyclerview/widget/RecyclerView$ViewCacheExtension;)V", "GetSetViewCacheExtension_Landroidx_recyclerview_widget_RecyclerView_ViewCacheExtension_Handler")]
	public unsafe virtual void SetViewCacheExtension(ViewCacheExtension? extension)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(extension?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setViewCacheExtension.(Landroidx/recyclerview/widget/RecyclerView$ViewCacheExtension;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(extension);
		}
	}

	private static Delegate GetSmoothScrollBy_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SmoothScrollBy_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SmoothScrollBy_II(nint jnienv, nint native__this, int dx, int dy)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothScrollBy(dx, dy);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("smoothScrollBy", "(II)V", "GetSmoothScrollBy_IIHandler")]
	public unsafe virtual void SmoothScrollBy(int dx, int dy)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(dx);
		ptr[1] = new JniArgumentValue(dy);
		_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollBy.(II)V", this, ptr);
	}

	private static Delegate GetSmoothScrollBy_IILandroid_view_animation_Interpolator_Handler()
	{
		return new global::_JniMarshal_PPIIL_V(n_SmoothScrollBy_IILandroid_view_animation_Interpolator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SmoothScrollBy_IILandroid_view_animation_Interpolator_(nint jnienv, nint native__this, int dx, int dy, nint native_interpolator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInterpolator interpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
			recyclerView.SmoothScrollBy(dx, dy, interpolator);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("smoothScrollBy", "(IILandroid/view/animation/Interpolator;)V", "GetSmoothScrollBy_IILandroid_view_animation_Interpolator_Handler")]
	public unsafe virtual void SmoothScrollBy(int dx, int dy, IInterpolator? interpolator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(dx);
			ptr[1] = new JniArgumentValue(dy);
			ptr[2] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollBy.(IILandroid/view/animation/Interpolator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(interpolator);
		}
	}

	private static Delegate GetSmoothScrollBy_IILandroid_view_animation_Interpolator_IHandler()
	{
		return new global::_JniMarshal_PPIILI_V(n_SmoothScrollBy_IILandroid_view_animation_Interpolator_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SmoothScrollBy_IILandroid_view_animation_Interpolator_I(nint jnienv, nint native__this, int dx, int dy, nint native_interpolator, int duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInterpolator interpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
			recyclerView.SmoothScrollBy(dx, dy, interpolator, duration);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("smoothScrollBy", "(IILandroid/view/animation/Interpolator;I)V", "GetSmoothScrollBy_IILandroid_view_animation_Interpolator_IHandler")]
	public unsafe virtual void SmoothScrollBy(int dx, int dy, IInterpolator? interpolator, int duration)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(dx);
			ptr[1] = new JniArgumentValue(dy);
			ptr[2] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
			ptr[3] = new JniArgumentValue(duration);
			_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollBy.(IILandroid/view/animation/Interpolator;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(interpolator);
		}
	}

	private static Delegate GetSmoothScrollToPosition_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SmoothScrollToPosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SmoothScrollToPosition_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SmoothScrollToPosition(position);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("smoothScrollToPosition", "(I)V", "GetSmoothScrollToPosition_IHandler")]
	public unsafe virtual void SmoothScrollToPosition(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		_members.InstanceMethods.InvokeVirtualVoidMethod("smoothScrollToPosition.(I)V", this, ptr);
	}

	private static Delegate GetStartNestedScroll_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_StartNestedScroll_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_StartNestedScroll_II(nint jnienv, nint native__this, int native_axes, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartNestedScroll((ScrollAxis)native_axes, type) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("startNestedScroll", "(II)Z", "GetStartNestedScroll_IIHandler")]
	public unsafe virtual bool StartNestedScroll(ScrollAxis axes, int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((int)axes);
		ptr[1] = new JniArgumentValue(type);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("startNestedScroll.(II)Z", this, ptr);
	}

	private static Delegate GetStopNestedScroll_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_StopNestedScroll_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StopNestedScroll_I(nint jnienv, nint native__this, int type)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopNestedScroll(type);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("stopNestedScroll", "(I)V", "GetStopNestedScroll_IHandler")]
	public unsafe virtual void StopNestedScroll(int type)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(type);
		_members.InstanceMethods.InvokeVirtualVoidMethod("stopNestedScroll.(I)V", this, ptr);
	}

	private static Delegate GetStopScrollHandler()
	{
		return new global::_JniMarshal_PP_V(n_StopScroll);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StopScroll(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopScroll();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("stopScroll", "()V", "GetStopScrollHandler")]
	public unsafe virtual void StopScroll()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("stopScroll.()V", this, null);
	}

	[Register("suppressLayout", "(Z)V", "")]
	public unsafe sealed override void SuppressLayout(bool suppress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(suppress ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("suppressLayout.(Z)V", this, ptr);
	}

	private static Delegate GetSwapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_SwapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SwapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Z(nint jnienv, nint native__this, nint native_adapter, sbyte native_removeAndRecycleExistingViews)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			RecyclerView? recyclerView = Java.Lang.Object.GetObject<RecyclerView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Adapter adapter = Java.Lang.Object.GetObject<Adapter>(native_adapter, JniHandleOwnership.DoNotTransfer);
			bool removeAndRecycleExistingViews = native_removeAndRecycleExistingViews != 0;
			recyclerView.SwapAdapter(adapter, removeAndRecycleExistingViews);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("swapAdapter", "(Landroidx/recyclerview/widget/RecyclerView$Adapter;Z)V", "GetSwapAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_ZHandler")]
	public unsafe virtual void SwapAdapter(Adapter? adapter, bool removeAndRecycleExistingViews)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(adapter?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(removeAndRecycleExistingViews ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("swapAdapter.(Landroidx/recyclerview/widget/RecyclerView$Adapter;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(adapter);
		}
	}

	private IOnChildAttachStateChangeListenerImplementor __CreateIOnChildAttachStateChangeListenerImplementor()
	{
		return new IOnChildAttachStateChangeListenerImplementor(this);
	}

	private IOnItemTouchListenerImplementor __CreateIOnItemTouchListenerImplementor()
	{
		return new IOnItemTouchListenerImplementor(this);
	}

	private IRecyclerListenerImplementor __CreateIRecyclerListenerImplementor()
	{
		return new IRecyclerListenerImplementor(this);
	}
}
