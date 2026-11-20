using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Database;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.CursorAdapter.Widget;

[Register("androidx/cursoradapter/widget/CursorAdapter", DoNotGenerateAcw = true)]
public abstract class CursorAdapter : BaseAdapter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/cursoradapter/widget/CursorAdapter", typeof(CursorAdapter));

	private static Delegate? cb_getCount_GetCount_I;

	private static Delegate? cb_getCursor_GetCursor_Landroid_database_Cursor_;

	private static Delegate? cb_getFilter_GetFilter_Landroid_widget_Filter_;

	private static Delegate? cb_getFilterQueryProvider_GetFilterQueryProvider_Landroid_widget_FilterQueryProvider_;

	private static Delegate? cb_setFilterQueryProvider_SetFilterQueryProvider_Landroid_widget_FilterQueryProvider__V;

	private static Delegate? cb_bindView_BindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor__V;

	private static Delegate? cb_changeCursor_ChangeCursor_Landroid_database_Cursor__V;

	private static Delegate? cb_convertToString_ConvertToString_Landroid_database_Cursor__Ljava_lang_CharSequence_;

	private static Delegate? cb_getItem_GetItem_I_Ljava_lang_Object_;

	private static Delegate? cb_getItemId_GetItemId_I_J;

	private static Delegate? cb_getView_GetView_ILandroid_view_View_Landroid_view_ViewGroup__Landroid_view_View_;

	private static Delegate? cb_init_Init_Landroid_content_Context_Landroid_database_Cursor_Z_V;

	private static Delegate? cb_newDropDownView_NewDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup__Landroid_view_View_;

	private static Delegate? cb_newView_NewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup__Landroid_view_View_;

	private static Delegate? cb_onContentChanged_OnContentChanged_V;

	private static Delegate? cb_runQueryOnBackgroundThread_RunQueryOnBackgroundThread_Ljava_lang_CharSequence__Landroid_database_Cursor_;

	private static Delegate? cb_swapCursor_SwapCursor_Landroid_database_Cursor__Landroid_database_Cursor_;

	[Register("mAutoRequery")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected bool MAutoRequery
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mAutoRequery.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mAutoRequery.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mContext")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected Context? MContext
	{
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceFields.GetObjectValue("mContext.Landroid/content/Context;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mContext.Landroid/content/Context;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mCursor")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected ICursor? MCursor
	{
		get
		{
			return Java.Lang.Object.GetObject<ICursor>(_members.InstanceFields.GetObjectValue("mCursor.Landroid/database/Cursor;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mCursor.Landroid/database/Cursor;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mDataSetObserver")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected DataSetObserver? MDataSetObserver
	{
		get
		{
			return Java.Lang.Object.GetObject<DataSetObserver>(_members.InstanceFields.GetObjectValue("mDataSetObserver.Landroid/database/DataSetObserver;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mDataSetObserver.Landroid/database/DataSetObserver;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mDataValid")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected bool MDataValid
	{
		get
		{
			return _members.InstanceFields.GetBooleanValue("mDataValid.Z", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mDataValid.Z", this, value ? ((sbyte)1) : ((sbyte)0));
		}
	}

	[Register("mFilterQueryProvider")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected IFilterQueryProvider? MFilterQueryProvider
	{
		get
		{
			return Java.Lang.Object.GetObject<IFilterQueryProvider>(_members.InstanceFields.GetObjectValue("mFilterQueryProvider.Landroid/widget/FilterQueryProvider;", this).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = JNIEnv.ToLocalJniHandle(value);
			try
			{
				_members.InstanceFields.SetValue("mFilterQueryProvider.Landroid/widget/FilterQueryProvider;", this, new JniObjectReference(num));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	[Register("mRowIDColumn")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected int MRowIDColumn
	{
		get
		{
			return _members.InstanceFields.GetInt32Value("mRowIDColumn.I", this);
		}
		set
		{
			_members.InstanceFields.SetValue("mRowIDColumn.I", this, value);
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

	public unsafe override int Count
	{
		[Register("getCount", "()I", "GetGetCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCount.()I", this, null);
		}
	}

	public unsafe virtual ICursor? Cursor
	{
		[Register("getCursor", "()Landroid/database/Cursor;", "GetGetCursorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICursor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCursor.()Landroid/database/Cursor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Filter? Filter
	{
		[Register("getFilter", "()Landroid/widget/Filter;", "GetGetFilterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Filter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFilter.()Landroid/widget/Filter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IFilterQueryProvider? FilterQueryProvider
	{
		[Register("getFilterQueryProvider", "()Landroid/widget/FilterQueryProvider;", "GetGetFilterQueryProviderHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IFilterQueryProvider>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFilterQueryProvider.()Landroid/widget/FilterQueryProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setFilterQueryProvider", "(Landroid/widget/FilterQueryProvider;)V", "GetSetFilterQueryProvider_Landroid_widget_FilterQueryProvider_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFilterQueryProvider.(Landroid/widget/FilterQueryProvider;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected CursorAdapter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/database/Cursor;)V", "")]
	[Obsolete("deprecated")]
	public unsafe CursorAdapter(Context? context, ICursor? c)
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
			ptr[1] = new JniArgumentValue((c == null) ? IntPtr.Zero : ((Java.Lang.Object)c).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(c);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/database/Cursor;Z)V", "")]
	public unsafe CursorAdapter(Context? context, ICursor? c, bool autoRequery)
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
			ptr[1] = new JniArgumentValue((c == null) ? IntPtr.Zero : ((Java.Lang.Object)c).Handle);
			ptr[2] = new JniArgumentValue(autoRequery ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(c);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/database/Cursor;I)V", "")]
	public unsafe CursorAdapter(Context? context, ICursor? c, int flags)
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
			ptr[1] = new JniArgumentValue((c == null) ? IntPtr.Zero : ((Java.Lang.Object)c).Handle);
			ptr[2] = new JniArgumentValue(flags);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetGetCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Count;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetCursorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCursor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCursor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cursor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetFilterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetFilter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFilter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Filter);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetFilterQueryProviderHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetFilterQueryProvider);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFilterQueryProvider(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FilterQueryProvider);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetFilterQueryProvider_Landroid_widget_FilterQueryProvider_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetFilterQueryProvider_Landroid_widget_FilterQueryProvider_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFilterQueryProvider_Landroid_widget_FilterQueryProvider_(nint jnienv, nint native__this, nint native_filterQueryProvider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFilterQueryProvider filterQueryProvider = Java.Lang.Object.GetObject<IFilterQueryProvider>(native_filterQueryProvider, JniHandleOwnership.DoNotTransfer);
			cursorAdapter.FilterQueryProvider = filterQueryProvider;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetBindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_BindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_BindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_(nint jnienv, nint native__this, nint native_view, nint native_context, nint native_cursor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			cursorAdapter.BindView(view, context, cursor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("bindView", "(Landroid/view/View;Landroid/content/Context;Landroid/database/Cursor;)V", "GetBindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_Handler")]
	public abstract void BindView(View? view, Context? context, ICursor? cursor);

	private static Delegate GetChangeCursor_Landroid_database_Cursor_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ChangeCursor_Landroid_database_Cursor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ChangeCursor_Landroid_database_Cursor_(nint jnienv, nint native__this, nint native_cursor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			cursorAdapter.ChangeCursor(cursor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("changeCursor", "(Landroid/database/Cursor;)V", "GetChangeCursor_Landroid_database_Cursor_Handler")]
	public unsafe virtual void ChangeCursor(ICursor? cursor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("changeCursor.(Landroid/database/Cursor;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cursor);
		}
	}

	private static Delegate GetConvertToString_Landroid_database_Cursor_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_ConvertToString_Landroid_database_Cursor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ConvertToString_Landroid_database_Cursor_(nint jnienv, nint native__this, nint native_cursor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			return CharSequence.ToLocalJniHandle(cursorAdapter.ConvertToStringFormatted(cursor));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("convertToString", "(Landroid/database/Cursor;)Ljava/lang/CharSequence;", "GetConvertToString_Landroid_database_Cursor_Handler")]
	public unsafe virtual ICharSequence? ConvertToStringFormatted(ICursor? cursor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("convertToString.(Landroid/database/Cursor;)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cursor);
		}
	}

	public string? ConvertToString(ICursor? cursor)
	{
		return ConvertToStringFormatted(cursor)?.ToString();
	}

	private static Delegate GetGetItem_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItem_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItem(position));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getItem", "(I)Ljava/lang/Object;", "GetGetItem_IHandler")]
	public unsafe override Java.Lang.Object? GetItem(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItem.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetItemId_IHandler()
	{
		return new global::_JniMarshal_PPI_J(n_GetItemId_I);
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
			return Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemId(position);
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
	public unsafe override long GetItemId(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members.InstanceMethods.InvokeVirtualInt64Method("getItemId.(I)J", this, ptr);
	}

	private static Delegate GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler()
	{
		return new global::_JniMarshal_PPILL_L(n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_(nint jnienv, nint native__this, int position, nint native_convertView, nint native_parent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View convertView = Java.Lang.Object.GetObject<View>(native_convertView, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.GetView(position, convertView, parent));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getView", "(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", "GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler")]
	public unsafe override View? GetView(int position, View? convertView, ViewGroup? parent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(convertView?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getView.(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(convertView);
			GC.KeepAlive(parent);
		}
	}

	[Obsolete]
	private static Delegate GetInit_Landroid_content_Context_Landroid_database_Cursor_ZHandler()
	{
		return new _JniMarshal_PPLLB_V(n_Init_Landroid_content_Context_Landroid_database_Cursor_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Init_Landroid_content_Context_Landroid_database_Cursor_Z(nint jnienv, nint native__this, nint native_context, nint native_c, sbyte native_autoRequery)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ICursor c = Java.Lang.Object.GetObject<ICursor>(native_c, JniHandleOwnership.DoNotTransfer);
			bool autoRequery = native_autoRequery != 0;
			cursorAdapter.Init(context, c, autoRequery);
		}
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
	[Register("init", "(Landroid/content/Context;Landroid/database/Cursor;Z)V", "GetInit_Landroid_content_Context_Landroid_database_Cursor_ZHandler")]
	protected unsafe virtual void Init(Context? context, ICursor? c, bool autoRequery)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((c == null) ? IntPtr.Zero : ((Java.Lang.Object)c).Handle);
			ptr[2] = new JniArgumentValue(autoRequery ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("init.(Landroid/content/Context;Landroid/database/Cursor;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(c);
		}
	}

	private static Delegate GetNewDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_NewDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NewDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_(nint jnienv, nint native__this, nint native_context, nint native_cursor, nint native_parent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.NewDropDownView(context, cursor, parent));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("newDropDownView", "(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", "GetNewDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler")]
	public unsafe virtual View? NewDropDownView(Context? context, ICursor? cursor, ViewGroup? parent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
			ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("newDropDownView.(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(cursor);
			GC.KeepAlive(parent);
		}
	}

	private static Delegate GetNewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler()
	{
		return new global::_JniMarshal_PPLLL_L(n_NewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_NewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_(nint jnienv, nint native__this, nint native_context, nint native_cursor, nint native_parent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.NewView(context, cursor, parent));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("newView", "(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", "GetNewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler")]
	public abstract View? NewView(Context? context, ICursor? cursor, ViewGroup? parent);

	private static Delegate GetOnContentChangedHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnContentChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnContentChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnContentChanged();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onContentChanged", "()V", "GetOnContentChangedHandler")]
	protected unsafe virtual void OnContentChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onContentChanged.()V", this, null);
	}

	private static Delegate GetRunQueryOnBackgroundThread_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_RunQueryOnBackgroundThread_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RunQueryOnBackgroundThread_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_constraint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence constraint = Java.Lang.Object.GetObject<ICharSequence>(native_constraint, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.RunQueryOnBackgroundThread(constraint));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("runQueryOnBackgroundThread", "(Ljava/lang/CharSequence;)Landroid/database/Cursor;", "GetRunQueryOnBackgroundThread_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual ICursor? RunQueryOnBackgroundThread(ICharSequence? constraint)
	{
		nint num = CharSequence.ToLocalJniHandle(constraint);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ICursor>(_members.InstanceMethods.InvokeVirtualObjectMethod("runQueryOnBackgroundThread.(Ljava/lang/CharSequence;)Landroid/database/Cursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(constraint);
		}
	}

	public ICursor? RunQueryOnBackgroundThread(string? constraint)
	{
		Java.Lang.String obj = ((constraint == null) ? null : new Java.Lang.String(constraint));
		ICursor? result = RunQueryOnBackgroundThread(obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetSwapCursor_Landroid_database_Cursor_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SwapCursor_Landroid_database_Cursor_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SwapCursor_Landroid_database_Cursor_(nint jnienv, nint native__this, nint native_newCursor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			CursorAdapter? cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICursor newCursor = Java.Lang.Object.GetObject<ICursor>(native_newCursor, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.SwapCursor(newCursor));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("swapCursor", "(Landroid/database/Cursor;)Landroid/database/Cursor;", "GetSwapCursor_Landroid_database_Cursor_Handler")]
	public unsafe virtual ICursor? SwapCursor(ICursor? newCursor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((newCursor == null) ? IntPtr.Zero : ((Java.Lang.Object)newCursor).Handle);
			return Java.Lang.Object.GetObject<ICursor>(_members.InstanceMethods.InvokeVirtualObjectMethod("swapCursor.(Landroid/database/Cursor;)Landroid/database/Cursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(newCursor);
		}
	}
}
