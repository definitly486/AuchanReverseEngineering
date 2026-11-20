using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.RecyclerView.Widget;

[Register("androidx/recyclerview/widget/GridLayoutManager", DoNotGenerateAcw = true)]
public class GridLayoutManager : LinearLayoutManager
{
	[Register("androidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup", DoNotGenerateAcw = true)]
	public abstract class SpanSizeLookup : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup", typeof(SpanSizeLookup));

		private static Delegate? cb_isSpanGroupIndexCacheEnabled_IsSpanGroupIndexCacheEnabled_Z;

		private static Delegate? cb_setSpanGroupIndexCacheEnabled_SetSpanGroupIndexCacheEnabled_Z_V;

		private static Delegate? cb_isSpanIndexCacheEnabled_IsSpanIndexCacheEnabled_Z;

		private static Delegate? cb_setSpanIndexCacheEnabled_SetSpanIndexCacheEnabled_Z_V;

		private static Delegate? cb_getSpanGroupIndex_GetSpanGroupIndex_II_I;

		private static Delegate? cb_getSpanIndex_GetSpanIndex_II_I;

		private static Delegate? cb_getSpanSize_GetSpanSize_I_I;

		private static Delegate? cb_invalidateSpanGroupIndexCache_InvalidateSpanGroupIndexCache_V;

		private static Delegate? cb_invalidateSpanIndexCache_InvalidateSpanIndexCache_V;

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

		public unsafe virtual bool SpanGroupIndexCacheEnabled
		{
			[Register("isSpanGroupIndexCacheEnabled", "()Z", "GetIsSpanGroupIndexCacheEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSpanGroupIndexCacheEnabled.()Z", this, null);
			}
			[Register("setSpanGroupIndexCacheEnabled", "(Z)V", "GetSetSpanGroupIndexCacheEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSpanGroupIndexCacheEnabled.(Z)V", this, ptr);
			}
		}

		public unsafe virtual bool SpanIndexCacheEnabled
		{
			[Register("isSpanIndexCacheEnabled", "()Z", "GetIsSpanIndexCacheEnabledHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSpanIndexCacheEnabled.()Z", this, null);
			}
			[Register("setSpanIndexCacheEnabled", "(Z)V", "GetSetSpanIndexCacheEnabled_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSpanIndexCacheEnabled.(Z)V", this, ptr);
			}
		}

		protected SpanSizeLookup(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe SpanSizeLookup()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetIsSpanGroupIndexCacheEnabledHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsSpanGroupIndexCacheEnabled);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsSpanGroupIndexCacheEnabled(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanGroupIndexCacheEnabled ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetSetSpanGroupIndexCacheEnabled_ZHandler()
		{
			return new global::_JniMarshal_PPB_V(n_SetSpanGroupIndexCacheEnabled_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetSpanGroupIndexCacheEnabled_Z(nint jnienv, nint native__this, sbyte native_cacheSpanGroupIndices)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SpanSizeLookup? spanSizeLookup = Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool spanGroupIndexCacheEnabled = native_cacheSpanGroupIndices != 0;
				spanSizeLookup.SpanGroupIndexCacheEnabled = spanGroupIndexCacheEnabled;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetIsSpanIndexCacheEnabledHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsSpanIndexCacheEnabled);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsSpanIndexCacheEnabled(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanIndexCacheEnabled ? ((sbyte)1) : ((sbyte)0);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetSetSpanIndexCacheEnabled_ZHandler()
		{
			return new global::_JniMarshal_PPB_V(n_SetSpanIndexCacheEnabled_Z);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetSpanIndexCacheEnabled_Z(nint jnienv, nint native__this, sbyte native_cacheSpanIndices)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				SpanSizeLookup? spanSizeLookup = Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				bool spanIndexCacheEnabled = native_cacheSpanIndices != 0;
				spanSizeLookup.SpanIndexCacheEnabled = spanIndexCacheEnabled;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetGetSpanGroupIndex_IIHandler()
		{
			return new global::_JniMarshal_PPII_I(n_GetSpanGroupIndex_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetSpanGroupIndex_II(nint jnienv, nint native__this, int adapterPosition, int spanCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSpanGroupIndex(adapterPosition, spanCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("getSpanGroupIndex", "(II)I", "GetGetSpanGroupIndex_IIHandler")]
		public unsafe virtual int GetSpanGroupIndex(int adapterPosition, int spanCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(adapterPosition);
			ptr[1] = new JniArgumentValue(spanCount);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanGroupIndex.(II)I", this, ptr);
		}

		private static Delegate GetGetSpanIndex_IIHandler()
		{
			return new global::_JniMarshal_PPII_I(n_GetSpanIndex_II);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetSpanIndex_II(nint jnienv, nint native__this, int position, int spanCount)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSpanIndex(position, spanCount);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("getSpanIndex", "(II)I", "GetGetSpanIndex_IIHandler")]
		public unsafe virtual int GetSpanIndex(int position, int spanCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(spanCount);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanIndex.(II)I", this, ptr);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetSpanSize_I(nint jnienv, nint native__this, int position)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSpanSize(position);
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("getSpanSize", "(I)I", "GetGetSpanSize_IHandler")]
		public abstract int GetSpanSize(int position);

		private static Delegate GetInvalidateSpanGroupIndexCacheHandler()
		{
			return new global::_JniMarshal_PP_V(n_InvalidateSpanGroupIndexCache);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_InvalidateSpanGroupIndexCache(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateSpanGroupIndexCache();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("invalidateSpanGroupIndexCache", "()V", "GetInvalidateSpanGroupIndexCacheHandler")]
		public unsafe virtual void InvalidateSpanGroupIndexCache()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateSpanGroupIndexCache.()V", this, null);
		}

		private static Delegate GetInvalidateSpanIndexCacheHandler()
		{
			return new global::_JniMarshal_PP_V(n_InvalidateSpanIndexCache);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_InvalidateSpanIndexCache(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<SpanSizeLookup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateSpanIndexCache();
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("invalidateSpanIndexCache", "()V", "GetInvalidateSpanIndexCacheHandler")]
		public unsafe virtual void InvalidateSpanIndexCache()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateSpanIndexCache.()V", this, null);
		}

		[UnmanagedCallersOnly]
		private static int n_GetSpanSize_I_mm_wrapper(nint jnienv, nint native__this, int position)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_GetSpanSize_I(jnienv, native__this, position);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	[Register("androidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup", DoNotGenerateAcw = true)]
	internal class SpanSizeLookupInvoker : SpanSizeLookup
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup", typeof(SpanSizeLookupInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public SpanSizeLookupInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("getSpanSize", "(I)I", "GetGetSpanSize_IHandler")]
		public unsafe override int GetSpanSize(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSpanSize.(I)I", this, ptr);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/recyclerview/widget/GridLayoutManager", typeof(GridLayoutManager));

	private static Delegate? cb_getSpanCount_GetSpanCount_I;

	private static Delegate? cb_setSpanCount_SetSpanCount_I_V;

	private static Delegate? cb_isUsingSpansToEstimateScrollbarDimensions_IsUsingSpansToEstimateScrollbarDimensions_Z;

	private static Delegate? cb_setUsingSpansToEstimateScrollbarDimensions_SetUsingSpansToEstimateScrollbarDimensions_Z_V;

	private static Delegate? cb_getSpanSizeLookup_GetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_;

	private static Delegate? cb_setSpanSizeLookup_SetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup__V;

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

	public unsafe virtual int SpanCount
	{
		[Register("getSpanCount", "()I", "GetGetSpanCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSpanCount.()I", this, null);
		}
		[Register("setSpanCount", "(I)V", "GetSetSpanCount_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSpanCount.(I)V", this, ptr);
		}
	}

	public unsafe virtual bool UsingSpansToEstimateScrollbarDimensions
	{
		[Register("isUsingSpansToEstimateScrollbarDimensions", "()Z", "GetIsUsingSpansToEstimateScrollbarDimensionsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUsingSpansToEstimateScrollbarDimensions.()Z", this, null);
		}
		[Register("setUsingSpansToEstimateScrollbarDimensions", "(Z)V", "GetSetUsingSpansToEstimateScrollbarDimensions_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setUsingSpansToEstimateScrollbarDimensions.(Z)V", this, ptr);
		}
	}

	protected GridLayoutManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe GridLayoutManager(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
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

	[Register(".ctor", "(Landroid/content/Context;I)V", "")]
	public unsafe GridLayoutManager(Context? context, int spanCount)
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
			ptr[1] = new JniArgumentValue(spanCount);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;IIZ)V", "")]
	public unsafe GridLayoutManager(Context? context, int spanCount, int orientation, bool reverseLayout)
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
			ptr[1] = new JniArgumentValue(spanCount);
			ptr[2] = new JniArgumentValue(orientation);
			ptr[3] = new JniArgumentValue(reverseLayout ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;IIZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;IIZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetSpanCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSpanCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSpanCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanCount;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetSpanCount_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSpanCount_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSpanCount_I(nint jnienv, nint native__this, int spanCount)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SpanCount = spanCount;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsUsingSpansToEstimateScrollbarDimensionsHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsUsingSpansToEstimateScrollbarDimensions);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsUsingSpansToEstimateScrollbarDimensions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UsingSpansToEstimateScrollbarDimensions ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetUsingSpansToEstimateScrollbarDimensions_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUsingSpansToEstimateScrollbarDimensions_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUsingSpansToEstimateScrollbarDimensions_Z(nint jnienv, nint native__this, sbyte native_useSpansToEstimateScrollBarDimensions)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GridLayoutManager? gridLayoutManager = Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool usingSpansToEstimateScrollbarDimensions = native_useSpansToEstimateScrollBarDimensions != 0;
			gridLayoutManager.UsingSpansToEstimateScrollbarDimensions = usingSpansToEstimateScrollbarDimensions;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetSpanSizeLookupHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSpanSizeLookup);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSpanSizeLookup(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSpanSizeLookup());
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getSpanSizeLookup", "()Landroidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup;", "GetGetSpanSizeLookupHandler")]
	public unsafe virtual SpanSizeLookup? GetSpanSizeLookup()
	{
		return Java.Lang.Object.GetObject<SpanSizeLookup>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSpanSizeLookup.()Landroidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_(nint jnienv, nint native__this, nint native_spanSizeLookup)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GridLayoutManager? gridLayoutManager = Java.Lang.Object.GetObject<GridLayoutManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SpanSizeLookup spanSizeLookup = Java.Lang.Object.GetObject<SpanSizeLookup>(native_spanSizeLookup, JniHandleOwnership.DoNotTransfer);
			gridLayoutManager.SetSpanSizeLookup(spanSizeLookup);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setSpanSizeLookup", "(Landroidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup;)V", "GetSetSpanSizeLookup_Landroidx_recyclerview_widget_GridLayoutManager_SpanSizeLookup_Handler")]
	public unsafe virtual void SetSpanSizeLookup(SpanSizeLookup? spanSizeLookup)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(spanSizeLookup?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSpanSizeLookup.(Landroidx/recyclerview/widget/GridLayoutManager$SpanSizeLookup;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(spanSizeLookup);
		}
	}
}
