using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace SQLitePCL;

[Preserve(AllMembers = true)]
public sealed class SQLite3Provider_e_sqlite3 : ISQLite3Provider
{
	private struct sqlite3_vfs
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate int SQLiteDeleteDelegate(IntPtr pVfs, byte* zName, int syncDir);

		public int iVersion;

		public int szOsFile;

		public int mxPathname;

		public IntPtr pNext;

		public IntPtr zName;

		public IntPtr pAppData;

		public IntPtr xOpen;

		public SQLiteDeleteDelegate xDelete;

		public IntPtr xAccess;

		public IntPtr xFullPathname;

		public IntPtr xDlOpen;

		public IntPtr xDlError;

		public IntPtr xDlSym;

		public IntPtr xDlClose;

		public IntPtr xRandomness;

		public IntPtr xSleep;

		public IntPtr xCurrentTime;

		public IntPtr xGetLastError;
	}

	private static class NativeMethods
	{
		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_close(IntPtr db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_close_v2(IntPtr db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_enable_shared_cache(int enable);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_interrupt(sqlite3 db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_finalize(IntPtr stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_reset(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_clear_bindings(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_stmt_status(sqlite3_stmt stm, int op, int resetFlg);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_bind_parameter_name(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_column_database_name(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_column_decltype(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_column_name(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_column_origin_name(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_column_table_name(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_column_text(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_errmsg(sqlite3 db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_db_readonly(sqlite3 db, byte* dbName);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_db_filename(sqlite3 db, byte* att);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_prepare_v2(sqlite3 db, byte* pSql, int nBytes, out IntPtr stmt, out byte* ptrRemain);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_prepare_v3(sqlite3 db, byte* pSql, int nBytes, uint flags, out IntPtr stmt, out byte* ptrRemain);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_db_status(sqlite3 db, int op, out int current, out int highest, int resetFlg);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_complete(byte* pSql);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_compileoption_used(byte* pSql);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_compileoption_get(int n);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_table_column_metadata(sqlite3 db, byte* dbName, byte* tblName, byte* colName, out byte* ptrDataType, out byte* ptrCollSeq, out int notNull, out int primaryKey, out int autoInc);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_value_text(IntPtr p);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_enable_load_extension(sqlite3 db, int enable);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_load_extension(sqlite3 db, byte* zFile, byte* zProc, out byte* pzErrMsg);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_limit(sqlite3 db, int id, int newVal);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_initialize();

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_shutdown();

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_libversion();

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_libversion_number();

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_threadsafe();

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_sourceid();

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_malloc(int n);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_malloc64(long n);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_free(IntPtr p);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_stricmp(IntPtr p, IntPtr q);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_strnicmp(IntPtr p, IntPtr q, int n);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_open(byte* filename, out IntPtr db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_open_v2(byte* filename, out IntPtr db, int flags, byte* vfs);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern IntPtr sqlite3_vfs_find(byte* vfs);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern long sqlite3_last_insert_rowid(sqlite3 db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_changes(sqlite3 db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_total_changes(sqlite3 db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern long sqlite3_memory_used();

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern long sqlite3_memory_highwater(int resetFlag);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern long sqlite3_soft_heap_limit64(long n);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern long sqlite3_hard_heap_limit64(long n);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_status(int op, out int current, out int highwater, int resetFlag);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_busy_timeout(sqlite3 db, int ms);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_bind_blob(sqlite3_stmt stmt, int index, byte* val, int nSize, IntPtr nTransient);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_bind_zeroblob(sqlite3_stmt stmt, int index, int size);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_bind_double(sqlite3_stmt stmt, int index, double val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_bind_int(sqlite3_stmt stmt, int index, int val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_bind_int64(sqlite3_stmt stmt, int index, long val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_bind_null(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_bind_text(sqlite3_stmt stmt, int index, byte* val, int nlen, IntPtr pvReserved);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_bind_text16(sqlite3_stmt stmt, int index, char* val, int nlen, IntPtr pvReserved);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_bind_parameter_count(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_bind_parameter_index(sqlite3_stmt stmt, byte* strName);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_column_count(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_data_count(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_step(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_sql(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern double sqlite3_column_double(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_column_int(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern long sqlite3_column_int64(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_column_blob(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_column_bytes(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_column_type(sqlite3_stmt stmt, int index);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_value_blob(IntPtr p);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_value_bytes(IntPtr p);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern double sqlite3_value_double(IntPtr p);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_value_int(IntPtr p);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern long sqlite3_value_int64(IntPtr p);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_value_type(IntPtr p);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_user_data(IntPtr context);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_result_blob(IntPtr context, IntPtr val, int nSize, IntPtr pvReserved);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_result_double(IntPtr context, double val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern void sqlite3_result_error(IntPtr context, byte* strErr, int nLen);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_result_int(IntPtr context, int val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_result_int64(IntPtr context, long val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_result_null(IntPtr context);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern void sqlite3_result_text(IntPtr context, byte* val, int nLen, IntPtr pvReserved);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_result_zeroblob(IntPtr context, int n);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_result_error_toobig(IntPtr context);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_result_error_nomem(IntPtr context);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_result_error_code(IntPtr context, int code);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_aggregate_context(IntPtr context, int nBytes);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_config", ExactSpelling = true)]
		public static extern int sqlite3_config_none(int op);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_config", ExactSpelling = true)]
		public static extern int sqlite3_config_int(int op, int val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_config", ExactSpelling = true)]
		public static extern int sqlite3_config_int_arm64cc(int op, IntPtr dummy1, IntPtr dummy2, IntPtr dummy3, IntPtr dummy4, IntPtr dummy5, IntPtr dummy6, IntPtr dummy7, int val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_config", ExactSpelling = true)]
		public static extern int sqlite3_config_log(int op, IntPtr func, hook_handle pvUser);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_config", ExactSpelling = true)]
		public static extern int sqlite3_config_log_arm64cc(int op, IntPtr dummy1, IntPtr dummy2, IntPtr dummy3, IntPtr dummy4, IntPtr dummy5, IntPtr dummy6, IntPtr dummy7, IntPtr func, hook_handle pvUser);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_db_config", ExactSpelling = true)]
		public unsafe static extern int sqlite3_db_config_charptr(sqlite3 db, int op, byte* val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_db_config", ExactSpelling = true)]
		public unsafe static extern int sqlite3_db_config_charptr_arm64cc(sqlite3 db, int op, IntPtr dummy2, IntPtr dummy3, IntPtr dummy4, IntPtr dummy5, IntPtr dummy6, IntPtr dummy7, byte* val);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_db_config", ExactSpelling = true)]
		public unsafe static extern int sqlite3_db_config_int_outint(sqlite3 db, int op, int val, int* result);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_db_config", ExactSpelling = true)]
		public unsafe static extern int sqlite3_db_config_int_outint_arm64cc(sqlite3 db, int op, IntPtr dummy2, IntPtr dummy3, IntPtr dummy4, IntPtr dummy5, IntPtr dummy6, IntPtr dummy7, int val, int* result);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_db_config", ExactSpelling = true)]
		public static extern int sqlite3_db_config_intptr_int_int(sqlite3 db, int op, IntPtr ptr, int int0, int int1);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sqlite3_db_config", ExactSpelling = true)]
		public static extern int sqlite3_db_config_intptr_int_int_arm64cc(sqlite3 db, int op, IntPtr dummy2, IntPtr dummy3, IntPtr dummy4, IntPtr dummy5, IntPtr dummy6, IntPtr dummy7, IntPtr ptr, int int0, int int1);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_create_collation(sqlite3 db, byte[] strName, int nType, hook_handle pvUser, IntPtr func);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_update_hook(sqlite3 db, IntPtr func, hook_handle pvUser);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_commit_hook(sqlite3 db, IntPtr func, hook_handle pvUser);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_profile(sqlite3 db, IntPtr func, hook_handle pvUser);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_progress_handler(sqlite3 db, int instructions, IntPtr func, hook_handle pvUser);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_trace(sqlite3 db, IntPtr func, hook_handle pvUser);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_rollback_hook(sqlite3 db, IntPtr func, hook_handle pvUser);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_db_handle(IntPtr stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern IntPtr sqlite3_next_stmt(sqlite3 db, IntPtr stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_stmt_isexplain(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_stmt_busy(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_stmt_readonly(sqlite3_stmt stmt);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_exec(sqlite3 db, byte* strSql, IntPtr cb, hook_handle pvParam, out IntPtr errMsg);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_get_autocommit(sqlite3 db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_extended_result_codes(sqlite3 db, int onoff);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_errcode(sqlite3 db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_extended_errcode(sqlite3 db);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern byte* sqlite3_errstr(int rc);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern void sqlite3_log(int iErrCode, byte* zFormat);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern sqlite3_backup sqlite3_backup_init(sqlite3 destDb, byte* zDestName, sqlite3 sourceDb, byte* zSourceName);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_backup_step(sqlite3_backup backup, int nPage);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_backup_remaining(sqlite3_backup backup);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_backup_pagecount(sqlite3_backup backup);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_backup_finish(IntPtr backup);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_snapshot_get(sqlite3 db, byte* schema, out IntPtr snap);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_snapshot_open(sqlite3 db, byte* schema, sqlite3_snapshot snap);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_snapshot_recover(sqlite3 db, byte* name);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_snapshot_cmp(sqlite3_snapshot p1, sqlite3_snapshot p2);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void sqlite3_snapshot_free(IntPtr snap);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_blob_open(sqlite3 db, byte* sdb, byte* table, byte* col, long rowid, int flags, out sqlite3_blob blob);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_blob_write(sqlite3_blob blob, byte* b, int n, int offset);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_blob_read(sqlite3_blob blob, byte* b, int n, int offset);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_blob_bytes(sqlite3_blob blob);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_blob_reopen(sqlite3_blob blob, long rowid);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_blob_close(IntPtr blob);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_wal_autocheckpoint(sqlite3 db, int n);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_wal_checkpoint(sqlite3 db, byte* dbName);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_wal_checkpoint_v2(sqlite3 db, byte* dbName, int eMode, out int logSize, out int framesCheckPointed);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_set_authorizer(sqlite3 db, IntPtr cb, hook_handle pvUser);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_create_function_v2(sqlite3 db, byte[] strName, int nArgs, int nType, hook_handle pvUser, IntPtr func, IntPtr fstep, IntPtr ffinal, IntPtr fdestroy);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern int sqlite3_keyword_count();

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_keyword_name(int i, out byte* name, out int length);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern IntPtr sqlite3_serialize(sqlite3 db, byte* schema, out long size, int flags);

		[DllImport("e_sqlite3", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public unsafe static extern int sqlite3_deserialize(sqlite3 db, byte* schema, IntPtr data, long szDb, long szBuf, int flags);
	}

	private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;

	private static readonly bool IsArm64cc;

	private static hook_handle disp_log_hook_handle;

	string ISQLite3Provider.GetNativeLibraryName()
	{
		return "e_sqlite3";
	}

	private bool my_streq(IntPtr p, IntPtr q, int len)
	{
		return NativeMethods.sqlite3_strnicmp(p, q, len) == 0;
	}

	private hook_handles get_hooks(sqlite3 db)
	{
		return db.GetOrCreateExtra(() => new hook_handles(my_streq));
	}

	int ISQLite3Provider.sqlite3_win32_set_directory(int typ, utf8z path)
	{
		return 1;
	}

	unsafe int ISQLite3Provider.sqlite3_open(utf8z filename, out IntPtr db)
	{
		fixed (byte* filename2 = filename)
		{
			return NativeMethods.sqlite3_open(filename2, out db);
		}
	}

	unsafe int ISQLite3Provider.sqlite3_open_v2(utf8z filename, out IntPtr db, int flags, utf8z vfs)
	{
		fixed (byte* filename2 = filename)
		{
			fixed (byte* vfs2 = vfs)
			{
				return NativeMethods.sqlite3_open_v2(filename2, out db, flags, vfs2);
			}
		}
	}

	unsafe int ISQLite3Provider.sqlite3__vfs__delete(utf8z vfs, utf8z filename, int syncDir)
	{
		fixed (byte* vfs2 = vfs)
		{
			fixed (byte* zName = filename)
			{
				IntPtr intPtr = NativeMethods.sqlite3_vfs_find(vfs2);
				return ((sqlite3_vfs)Marshal.PtrToStructure(intPtr, typeof(sqlite3_vfs))).xDelete(intPtr, zName, 1);
			}
		}
	}

	int ISQLite3Provider.sqlite3_close_v2(IntPtr db)
	{
		return NativeMethods.sqlite3_close_v2(db);
	}

	int ISQLite3Provider.sqlite3_close(IntPtr db)
	{
		return NativeMethods.sqlite3_close(db);
	}

	IntPtr ISQLite3Provider.sqlite3_malloc(int n)
	{
		return NativeMethods.sqlite3_malloc(n);
	}

	IntPtr ISQLite3Provider.sqlite3_malloc64(long n)
	{
		return NativeMethods.sqlite3_malloc64(n);
	}

	void ISQLite3Provider.sqlite3_free(IntPtr p)
	{
		NativeMethods.sqlite3_free(p);
	}

	int ISQLite3Provider.sqlite3_stricmp(IntPtr p, IntPtr q)
	{
		return NativeMethods.sqlite3_stricmp(p, q);
	}

	int ISQLite3Provider.sqlite3_strnicmp(IntPtr p, IntPtr q, int n)
	{
		return NativeMethods.sqlite3_strnicmp(p, q, n);
	}

	int ISQLite3Provider.sqlite3_enable_shared_cache(int enable)
	{
		return NativeMethods.sqlite3_enable_shared_cache(enable);
	}

	void ISQLite3Provider.sqlite3_interrupt(sqlite3 db)
	{
		NativeMethods.sqlite3_interrupt(db);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static int exec_hook_bridge_impl(IntPtr p, int n, IntPtr values_ptr, IntPtr names_ptr)
	{
		return exec_hook_info.from_ptr(p).call(n, values_ptr, names_ptr);
	}

	unsafe int ISQLite3Provider.sqlite3_exec(sqlite3 db, utf8z sql, delegate_exec func, object user_data, out IntPtr errMsg)
	{
		delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, IntPtr, int> delegate_002A;
		exec_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, IntPtr, int>)(delegate*<IntPtr, int, IntPtr, IntPtr, int>)(&exec_hook_bridge_impl);
			target = new exec_hook_info(func, user_data);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		int result;
		fixed (byte* strSql = sql)
		{
			result = NativeMethods.sqlite3_exec(db, strSql, (IntPtr)delegate_002A, hook_handle2, out errMsg);
		}
		hook_handle2.Dispose();
		return result;
	}

	unsafe int ISQLite3Provider.sqlite3_complete(utf8z sql)
	{
		fixed (byte* pSql = sql)
		{
			return NativeMethods.sqlite3_complete(pSql);
		}
	}

	unsafe utf8z ISQLite3Provider.sqlite3_compileoption_get(int n)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_compileoption_get(n));
	}

	unsafe int ISQLite3Provider.sqlite3_compileoption_used(utf8z s)
	{
		fixed (byte* pSql = s)
		{
			return NativeMethods.sqlite3_compileoption_used(pSql);
		}
	}

	unsafe int ISQLite3Provider.sqlite3_table_column_metadata(sqlite3 db, utf8z dbName, utf8z tblName, utf8z colName, out utf8z dataType, out utf8z collSeq, out int notNull, out int primaryKey, out int autoInc)
	{
		fixed (byte* dbName2 = dbName)
		{
			fixed (byte* tblName2 = tblName)
			{
				fixed (byte* colName2 = colName)
				{
					byte* ptrDataType;
					byte* ptrCollSeq;
					int result = NativeMethods.sqlite3_table_column_metadata(db, dbName2, tblName2, colName2, out ptrDataType, out ptrCollSeq, out notNull, out primaryKey, out autoInc);
					dataType = utf8z.FromPtr(ptrDataType);
					collSeq = utf8z.FromPtr(ptrCollSeq);
					return result;
				}
			}
		}
	}

	int ISQLite3Provider.sqlite3_key(sqlite3 db, ReadOnlySpan<byte> k)
	{
		return 1;
	}

	int ISQLite3Provider.sqlite3_key_v2(sqlite3 db, utf8z name, ReadOnlySpan<byte> k)
	{
		return 1;
	}

	int ISQLite3Provider.sqlite3_rekey(sqlite3 db, ReadOnlySpan<byte> k)
	{
		return 1;
	}

	int ISQLite3Provider.sqlite3_rekey_v2(sqlite3 db, utf8z name, ReadOnlySpan<byte> k)
	{
		return 1;
	}

	unsafe int ISQLite3Provider.sqlite3_prepare_v2(sqlite3 db, ReadOnlySpan<byte> sql, out IntPtr stm, out ReadOnlySpan<byte> tail)
	{
		fixed (byte* ptr = sql)
		{
			byte* ptrRemain;
			int result = NativeMethods.sqlite3_prepare_v2(db, ptr, sql.Length, out stm, out ptrRemain);
			int num = (int)(ptrRemain - ptr);
			int num2 = sql.Length - num;
			if (num2 > 0)
			{
				tail = sql.Slice(num, num2);
				return result;
			}
			tail = ReadOnlySpan<byte>.Empty;
			return result;
		}
	}

	unsafe int ISQLite3Provider.sqlite3_prepare_v2(sqlite3 db, utf8z sql, out IntPtr stm, out utf8z tail)
	{
		fixed (byte* pSql = sql)
		{
			byte* ptrRemain;
			int result = NativeMethods.sqlite3_prepare_v2(db, pSql, -1, out stm, out ptrRemain);
			tail = utf8z.FromPtr(ptrRemain);
			return result;
		}
	}

	unsafe int ISQLite3Provider.sqlite3_prepare_v3(sqlite3 db, ReadOnlySpan<byte> sql, uint flags, out IntPtr stm, out ReadOnlySpan<byte> tail)
	{
		fixed (byte* ptr = sql)
		{
			byte* ptrRemain;
			int result = NativeMethods.sqlite3_prepare_v3(db, ptr, sql.Length, flags, out stm, out ptrRemain);
			int num = (int)(ptrRemain - ptr);
			int num2 = sql.Length - num;
			if (num2 > 0)
			{
				tail = sql.Slice(num, num2);
				return result;
			}
			tail = ReadOnlySpan<byte>.Empty;
			return result;
		}
	}

	unsafe int ISQLite3Provider.sqlite3_prepare_v3(sqlite3 db, utf8z sql, uint flags, out IntPtr stm, out utf8z tail)
	{
		fixed (byte* pSql = sql)
		{
			byte* ptrRemain;
			int result = NativeMethods.sqlite3_prepare_v3(db, pSql, -1, flags, out stm, out ptrRemain);
			tail = utf8z.FromPtr(ptrRemain);
			return result;
		}
	}

	int ISQLite3Provider.sqlite3_db_status(sqlite3 db, int op, out int current, out int highest, int resetFlg)
	{
		return NativeMethods.sqlite3_db_status(db, op, out current, out highest, resetFlg);
	}

	unsafe utf8z ISQLite3Provider.sqlite3_sql(sqlite3_stmt stmt)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_sql(stmt));
	}

	IntPtr ISQLite3Provider.sqlite3_db_handle(IntPtr stmt)
	{
		return NativeMethods.sqlite3_db_handle(stmt);
	}

	unsafe int ISQLite3Provider.sqlite3_blob_open(sqlite3 db, utf8z db_utf8, utf8z table_utf8, utf8z col_utf8, long rowid, int flags, out sqlite3_blob blob)
	{
		fixed (byte* sdb = db_utf8)
		{
			fixed (byte* table = table_utf8)
			{
				fixed (byte* col = col_utf8)
				{
					return NativeMethods.sqlite3_blob_open(db, sdb, table, col, rowid, flags, out blob);
				}
			}
		}
	}

	int ISQLite3Provider.sqlite3_blob_bytes(sqlite3_blob blob)
	{
		return NativeMethods.sqlite3_blob_bytes(blob);
	}

	int ISQLite3Provider.sqlite3_blob_reopen(sqlite3_blob blob, long rowid)
	{
		return NativeMethods.sqlite3_blob_reopen(blob, rowid);
	}

	unsafe int ISQLite3Provider.sqlite3_blob_read(sqlite3_blob blob, Span<byte> b, int offset)
	{
		fixed (byte* b2 = b)
		{
			return NativeMethods.sqlite3_blob_read(blob, b2, b.Length, offset);
		}
	}

	unsafe int ISQLite3Provider.sqlite3_blob_write(sqlite3_blob blob, ReadOnlySpan<byte> b, int offset)
	{
		fixed (byte* b2 = b)
		{
			return NativeMethods.sqlite3_blob_write(blob, b2, b.Length, offset);
		}
	}

	int ISQLite3Provider.sqlite3_blob_close(IntPtr blob)
	{
		return NativeMethods.sqlite3_blob_close(blob);
	}

	unsafe int ISQLite3Provider.sqlite3_snapshot_get(sqlite3 db, utf8z schema, out IntPtr snap)
	{
		fixed (byte* schema2 = schema)
		{
			return NativeMethods.sqlite3_snapshot_get(db, schema2, out snap);
		}
	}

	int ISQLite3Provider.sqlite3_snapshot_cmp(sqlite3_snapshot p1, sqlite3_snapshot p2)
	{
		return NativeMethods.sqlite3_snapshot_cmp(p1, p2);
	}

	unsafe int ISQLite3Provider.sqlite3_snapshot_open(sqlite3 db, utf8z schema, sqlite3_snapshot snap)
	{
		fixed (byte* schema2 = schema)
		{
			return NativeMethods.sqlite3_snapshot_open(db, schema2, snap);
		}
	}

	unsafe int ISQLite3Provider.sqlite3_snapshot_recover(sqlite3 db, utf8z name)
	{
		fixed (byte* name2 = name)
		{
			return NativeMethods.sqlite3_snapshot_recover(db, name2);
		}
	}

	void ISQLite3Provider.sqlite3_snapshot_free(IntPtr snap)
	{
		NativeMethods.sqlite3_snapshot_free(snap);
	}

	unsafe sqlite3_backup ISQLite3Provider.sqlite3_backup_init(sqlite3 destDb, utf8z destName, sqlite3 sourceDb, utf8z sourceName)
	{
		fixed (byte* zDestName = destName)
		{
			fixed (byte* zSourceName = sourceName)
			{
				return NativeMethods.sqlite3_backup_init(destDb, zDestName, sourceDb, zSourceName);
			}
		}
	}

	int ISQLite3Provider.sqlite3_backup_step(sqlite3_backup backup, int nPage)
	{
		return NativeMethods.sqlite3_backup_step(backup, nPage);
	}

	int ISQLite3Provider.sqlite3_backup_remaining(sqlite3_backup backup)
	{
		return NativeMethods.sqlite3_backup_remaining(backup);
	}

	int ISQLite3Provider.sqlite3_backup_pagecount(sqlite3_backup backup)
	{
		return NativeMethods.sqlite3_backup_pagecount(backup);
	}

	int ISQLite3Provider.sqlite3_backup_finish(IntPtr backup)
	{
		return NativeMethods.sqlite3_backup_finish(backup);
	}

	IntPtr ISQLite3Provider.sqlite3_next_stmt(sqlite3 db, IntPtr stmt)
	{
		return NativeMethods.sqlite3_next_stmt(db, stmt);
	}

	long ISQLite3Provider.sqlite3_last_insert_rowid(sqlite3 db)
	{
		return NativeMethods.sqlite3_last_insert_rowid(db);
	}

	int ISQLite3Provider.sqlite3_changes(sqlite3 db)
	{
		return NativeMethods.sqlite3_changes(db);
	}

	int ISQLite3Provider.sqlite3_total_changes(sqlite3 db)
	{
		return NativeMethods.sqlite3_total_changes(db);
	}

	int ISQLite3Provider.sqlite3_extended_result_codes(sqlite3 db, int onoff)
	{
		return NativeMethods.sqlite3_extended_result_codes(db, onoff);
	}

	unsafe utf8z ISQLite3Provider.sqlite3_errstr(int rc)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_errstr(rc));
	}

	int ISQLite3Provider.sqlite3_errcode(sqlite3 db)
	{
		return NativeMethods.sqlite3_errcode(db);
	}

	int ISQLite3Provider.sqlite3_extended_errcode(sqlite3 db)
	{
		return NativeMethods.sqlite3_extended_errcode(db);
	}

	int ISQLite3Provider.sqlite3_busy_timeout(sqlite3 db, int ms)
	{
		return NativeMethods.sqlite3_busy_timeout(db, ms);
	}

	int ISQLite3Provider.sqlite3_get_autocommit(sqlite3 db)
	{
		return NativeMethods.sqlite3_get_autocommit(db);
	}

	unsafe int ISQLite3Provider.sqlite3_db_readonly(sqlite3 db, utf8z dbName)
	{
		fixed (byte* dbName2 = dbName)
		{
			return NativeMethods.sqlite3_db_readonly(db, dbName2);
		}
	}

	unsafe utf8z ISQLite3Provider.sqlite3_db_filename(sqlite3 db, utf8z att)
	{
		fixed (byte* att2 = att)
		{
			return utf8z.FromPtr(NativeMethods.sqlite3_db_filename(db, att2));
		}
	}

	unsafe utf8z ISQLite3Provider.sqlite3_errmsg(sqlite3 db)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_errmsg(db));
	}

	unsafe utf8z ISQLite3Provider.sqlite3_libversion()
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_libversion());
	}

	int ISQLite3Provider.sqlite3_libversion_number()
	{
		return NativeMethods.sqlite3_libversion_number();
	}

	int ISQLite3Provider.sqlite3_threadsafe()
	{
		return NativeMethods.sqlite3_threadsafe();
	}

	int ISQLite3Provider.sqlite3_config(int op)
	{
		return NativeMethods.sqlite3_config_none(op);
	}

	int ISQLite3Provider.sqlite3_config(int op, int val)
	{
		if (IsArm64cc)
		{
			return NativeMethods.sqlite3_config_int_arm64cc(op, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, val);
		}
		return NativeMethods.sqlite3_config_int(op, val);
	}

	unsafe int ISQLite3Provider.sqlite3_db_config(sqlite3 db, int op, utf8z val)
	{
		fixed (byte* val2 = val)
		{
			if (IsArm64cc)
			{
				return NativeMethods.sqlite3_db_config_charptr_arm64cc(db, op, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, val2);
			}
			return NativeMethods.sqlite3_db_config_charptr(db, op, val2);
		}
	}

	unsafe int ISQLite3Provider.sqlite3_db_config(sqlite3 db, int op, int val, out int result)
	{
		int num = 0;
		int result2 = ((!IsArm64cc) ? NativeMethods.sqlite3_db_config_int_outint(db, op, val, &num) : NativeMethods.sqlite3_db_config_int_outint_arm64cc(db, op, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, val, &num));
		result = num;
		return result2;
	}

	int ISQLite3Provider.sqlite3_db_config(sqlite3 db, int op, IntPtr ptr, int int0, int int1)
	{
		if (IsArm64cc)
		{
			return NativeMethods.sqlite3_db_config_intptr_int_int_arm64cc(db, op, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ptr, int0, int1);
		}
		return NativeMethods.sqlite3_db_config_intptr_int_int(db, op, ptr, int0, int1);
	}

	int ISQLite3Provider.sqlite3_limit(sqlite3 db, int id, int newVal)
	{
		return NativeMethods.sqlite3_limit(db, id, newVal);
	}

	int ISQLite3Provider.sqlite3_initialize()
	{
		return NativeMethods.sqlite3_initialize();
	}

	int ISQLite3Provider.sqlite3_shutdown()
	{
		return NativeMethods.sqlite3_shutdown();
	}

	int ISQLite3Provider.sqlite3_enable_load_extension(sqlite3 db, int onoff)
	{
		return NativeMethods.sqlite3_enable_load_extension(db, onoff);
	}

	unsafe int ISQLite3Provider.sqlite3_load_extension(sqlite3 db, utf8z zFile, utf8z zProc, out utf8z pzErrMsg)
	{
		fixed (byte* zFile2 = zFile)
		{
			fixed (byte* zProc2 = zProc)
			{
				byte* pzErrMsg2;
				int result = NativeMethods.sqlite3_load_extension(db, zFile2, zProc2, out pzErrMsg2);
				pzErrMsg = utf8z.FromPtr(pzErrMsg2);
				return result;
			}
		}
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static int commit_hook_bridge_impl(IntPtr p)
	{
		return commit_hook_info.from_ptr(p).call();
	}

	unsafe void ISQLite3Provider.sqlite3_commit_hook(sqlite3 db, delegate_commit func, object v)
	{
		hook_handles hook_handles2 = get_hooks(db);
		if (hook_handles2.commit != null)
		{
			hook_handles2.commit.Dispose();
			hook_handles2.commit = null;
		}
		delegate* unmanaged[Cdecl]<IntPtr, int> delegate_002A;
		commit_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, int>)(delegate*<IntPtr, int>)(&commit_hook_bridge_impl);
			target = new commit_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		NativeMethods.sqlite3_commit_hook(db, (IntPtr)delegate_002A, hook_handle2);
		hook_handles2.commit = hook_handle2.ForDispose();
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static void scalar_function_hook_bridge_impl(IntPtr context, int num_args, IntPtr argsptr)
	{
		function_hook_info.from_ptr(NativeMethods.sqlite3_user_data(context)).call_scalar(context, num_args, argsptr);
	}

	unsafe int ISQLite3Provider.sqlite3_create_function(sqlite3 db, byte[] name, int nargs, int flags, object v, delegate_function_scalar func)
	{
		hook_handles hook_handles2 = get_hooks(db);
		hook_handles2.RemoveScalarFunction(name, nargs);
		int nType = 1 | flags;
		delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void> delegate_002A;
		function_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void>)(delegate*<IntPtr, int, IntPtr, void>)(&scalar_function_hook_bridge_impl);
			target = new function_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		int num = NativeMethods.sqlite3_create_function_v2(db, name, nargs, nType, hook_handle2, (IntPtr)delegate_002A, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
		if (num == 0 && delegate_002A != (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void>)null)
		{
			hook_handles2.AddScalarFunction(name, nargs, hook_handle2.ForDispose());
		}
		return num;
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static void log_hook_bridge_impl(IntPtr p, int rc, IntPtr s)
	{
		log_hook_info.from_ptr(p).call(rc, utf8z.FromIntPtr(s));
	}

	unsafe int ISQLite3Provider.sqlite3_config_log(delegate_log func, object v)
	{
		if (disp_log_hook_handle != null)
		{
			disp_log_hook_handle.Dispose();
			disp_log_hook_handle = null;
		}
		delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void> delegate_002A;
		log_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void>)(delegate*<IntPtr, int, IntPtr, void>)(&log_hook_bridge_impl);
			target = new log_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle pvUser = (disp_log_hook_handle = new hook_handle(target));
		if (IsArm64cc)
		{
			return NativeMethods.sqlite3_config_log_arm64cc(16, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (IntPtr)delegate_002A, pvUser);
		}
		return NativeMethods.sqlite3_config_log(16, (IntPtr)delegate_002A, pvUser);
	}

	unsafe void ISQLite3Provider.sqlite3_log(int errcode, utf8z s)
	{
		fixed (byte* zFormat = s)
		{
			NativeMethods.sqlite3_log(errcode, zFormat);
		}
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static void agg_function_step_hook_bridge_impl(IntPtr context, int num_args, IntPtr argsptr)
	{
		IntPtr agg_context = NativeMethods.sqlite3_aggregate_context(context, 8);
		function_hook_info.from_ptr(NativeMethods.sqlite3_user_data(context)).call_step(context, agg_context, num_args, argsptr);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static void agg_function_final_hook_bridge_impl(IntPtr context)
	{
		IntPtr agg_context = NativeMethods.sqlite3_aggregate_context(context, 8);
		function_hook_info.from_ptr(NativeMethods.sqlite3_user_data(context)).call_final(context, agg_context);
	}

	unsafe int ISQLite3Provider.sqlite3_create_function(sqlite3 db, byte[] name, int nargs, int flags, object v, delegate_function_aggregate_step func_step, delegate_function_aggregate_final func_final)
	{
		hook_handles hook_handles2 = get_hooks(db);
		hook_handles2.RemoveAggFunction(name, nargs);
		int nType = 1 | flags;
		delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void> delegate_002A;
		delegate* unmanaged[Cdecl]<IntPtr, void> delegate_002A2;
		function_hook_info target;
		if (func_step != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void>)(delegate*<IntPtr, int, IntPtr, void>)(&agg_function_step_hook_bridge_impl);
			delegate_002A2 = (delegate* unmanaged[Cdecl]<IntPtr, void>)(delegate*<IntPtr, void>)(&agg_function_final_hook_bridge_impl);
			target = new function_hook_info(func_step, func_final, v);
		}
		else
		{
			delegate_002A = null;
			delegate_002A2 = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		int num = NativeMethods.sqlite3_create_function_v2(db, name, nargs, nType, hook_handle2, IntPtr.Zero, (IntPtr)delegate_002A, (IntPtr)delegate_002A2, IntPtr.Zero);
		if (num == 0 && delegate_002A != (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, void>)null)
		{
			hook_handles2.AddAggFunction(name, nargs, hook_handle2.ForDispose());
		}
		return num;
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private unsafe static int collation_hook_bridge_impl(IntPtr p, int len1, IntPtr pv1, int len2, IntPtr pv2)
	{
		collation_hook_info obj = collation_hook_info.from_ptr(p);
		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(pv1.ToPointer(), len1);
		ReadOnlySpan<byte> s2 = new ReadOnlySpan<byte>(pv2.ToPointer(), len2);
		return obj.call(s, s2);
	}

	unsafe int ISQLite3Provider.sqlite3_create_collation(sqlite3 db, byte[] name, object v, delegate_collation func)
	{
		hook_handles hook_handles2 = get_hooks(db);
		hook_handles2.RemoveCollation(name);
		delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, int, IntPtr, int> delegate_002A;
		collation_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, int, IntPtr, int>)(delegate*<IntPtr, int, IntPtr, int, IntPtr, int>)(&collation_hook_bridge_impl);
			target = new collation_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		int num = NativeMethods.sqlite3_create_collation(db, name, 1, hook_handle2, (IntPtr)delegate_002A);
		if (num == 0 && delegate_002A != (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, int, IntPtr, int>)null)
		{
			hook_handles2.AddCollation(name, hook_handle2.ForDispose());
		}
		return num;
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static void update_hook_bridge_impl(IntPtr p, int typ, IntPtr db, IntPtr tbl, long rowid)
	{
		update_hook_info.from_ptr(p).call(typ, utf8z.FromIntPtr(db), utf8z.FromIntPtr(tbl), rowid);
	}

	unsafe void ISQLite3Provider.sqlite3_update_hook(sqlite3 db, delegate_update func, object v)
	{
		hook_handles hook_handles2 = get_hooks(db);
		if (hook_handles2.update != null)
		{
			hook_handles2.update.Dispose();
			hook_handles2.update = null;
		}
		delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, IntPtr, long, void> delegate_002A;
		update_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, IntPtr, long, void>)(delegate*<IntPtr, int, IntPtr, IntPtr, long, void>)(&update_hook_bridge_impl);
			target = new update_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		hook_handles2.update = hook_handle2.ForDispose();
		NativeMethods.sqlite3_update_hook(db, (IntPtr)delegate_002A, hook_handle2);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static void rollback_hook_bridge_impl(IntPtr p)
	{
		rollback_hook_info.from_ptr(p).call();
	}

	unsafe void ISQLite3Provider.sqlite3_rollback_hook(sqlite3 db, delegate_rollback func, object v)
	{
		hook_handles hook_handles2 = get_hooks(db);
		if (hook_handles2.rollback != null)
		{
			hook_handles2.rollback.Dispose();
			hook_handles2.rollback = null;
		}
		delegate* unmanaged[Cdecl]<IntPtr, void> delegate_002A;
		rollback_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, void>)(delegate*<IntPtr, void>)(&rollback_hook_bridge_impl);
			target = new rollback_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		hook_handles2.rollback = hook_handle2.ForDispose();
		NativeMethods.sqlite3_rollback_hook(db, (IntPtr)delegate_002A, hook_handle2);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static void trace_hook_bridge_impl(IntPtr p, IntPtr s)
	{
		trace_hook_info.from_ptr(p).call(utf8z.FromIntPtr(s));
	}

	unsafe void ISQLite3Provider.sqlite3_trace(sqlite3 db, delegate_trace func, object v)
	{
		hook_handles hook_handles2 = get_hooks(db);
		if (hook_handles2.trace != null)
		{
			hook_handles2.trace.Dispose();
			hook_handles2.trace = null;
		}
		delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> delegate_002A;
		trace_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)(delegate*<IntPtr, IntPtr, void>)(&trace_hook_bridge_impl);
			target = new trace_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		hook_handles2.trace = hook_handle2.ForDispose();
		NativeMethods.sqlite3_trace(db, (IntPtr)delegate_002A, hook_handle2);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static void profile_hook_bridge_impl(IntPtr p, IntPtr s, long elapsed)
	{
		profile_hook_info.from_ptr(p).call(utf8z.FromIntPtr(s), elapsed);
	}

	unsafe void ISQLite3Provider.sqlite3_profile(sqlite3 db, delegate_profile func, object v)
	{
		hook_handles hook_handles2 = get_hooks(db);
		if (hook_handles2.profile != null)
		{
			hook_handles2.profile.Dispose();
			hook_handles2.profile = null;
		}
		delegate* unmanaged[Cdecl]<IntPtr, IntPtr, long, void> delegate_002A;
		profile_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr, long, void>)(delegate*<IntPtr, IntPtr, long, void>)(&profile_hook_bridge_impl);
			target = new profile_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		hook_handles2.profile = hook_handle2.ForDispose();
		NativeMethods.sqlite3_profile(db, (IntPtr)delegate_002A, hook_handle2);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static int progress_handler_hook_bridge_impl(IntPtr p)
	{
		return progress_hook_info.from_ptr(p).call();
	}

	unsafe void ISQLite3Provider.sqlite3_progress_handler(sqlite3 db, int instructions, delegate_progress func, object v)
	{
		hook_handles hook_handles2 = get_hooks(db);
		if (hook_handles2.progress != null)
		{
			hook_handles2.progress.Dispose();
			hook_handles2.progress = null;
		}
		delegate* unmanaged[Cdecl]<IntPtr, int> delegate_002A;
		progress_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, int>)(delegate*<IntPtr, int>)(&progress_handler_hook_bridge_impl);
			target = new progress_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		hook_handles2.progress = hook_handle2.ForDispose();
		NativeMethods.sqlite3_progress_handler(db, instructions, (IntPtr)delegate_002A, hook_handle2);
	}

	[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
	private static int authorizer_hook_bridge_impl(IntPtr p, int action_code, IntPtr param0, IntPtr param1, IntPtr dbName, IntPtr inner_most_trigger_or_view)
	{
		return authorizer_hook_info.from_ptr(p).call(action_code, utf8z.FromIntPtr(param0), utf8z.FromIntPtr(param1), utf8z.FromIntPtr(dbName), utf8z.FromIntPtr(inner_most_trigger_or_view));
	}

	unsafe int ISQLite3Provider.sqlite3_set_authorizer(sqlite3 db, delegate_authorizer func, object v)
	{
		hook_handles hook_handles2 = get_hooks(db);
		if (hook_handles2.authorizer != null)
		{
			hook_handles2.authorizer.Dispose();
			hook_handles2.authorizer = null;
		}
		delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr, int> delegate_002A;
		authorizer_hook_info target;
		if (func != null)
		{
			delegate_002A = (delegate* unmanaged[Cdecl]<IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr, int>)(delegate*<IntPtr, int, IntPtr, IntPtr, IntPtr, IntPtr, int>)(&authorizer_hook_bridge_impl);
			target = new authorizer_hook_info(func, v);
		}
		else
		{
			delegate_002A = null;
			target = null;
		}
		hook_handle hook_handle2 = new hook_handle(target);
		hook_handles2.authorizer = hook_handle2.ForDispose();
		return NativeMethods.sqlite3_set_authorizer(db, (IntPtr)delegate_002A, hook_handle2);
	}

	long ISQLite3Provider.sqlite3_memory_used()
	{
		return NativeMethods.sqlite3_memory_used();
	}

	long ISQLite3Provider.sqlite3_memory_highwater(int resetFlag)
	{
		return NativeMethods.sqlite3_memory_highwater(resetFlag);
	}

	long ISQLite3Provider.sqlite3_soft_heap_limit64(long n)
	{
		return NativeMethods.sqlite3_soft_heap_limit64(n);
	}

	long ISQLite3Provider.sqlite3_hard_heap_limit64(long n)
	{
		return NativeMethods.sqlite3_hard_heap_limit64(n);
	}

	int ISQLite3Provider.sqlite3_status(int op, out int current, out int highwater, int resetFlag)
	{
		return NativeMethods.sqlite3_status(op, out current, out highwater, resetFlag);
	}

	unsafe utf8z ISQLite3Provider.sqlite3_sourceid()
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_sourceid());
	}

	void ISQLite3Provider.sqlite3_result_int64(IntPtr ctx, long val)
	{
		NativeMethods.sqlite3_result_int64(ctx, val);
	}

	void ISQLite3Provider.sqlite3_result_int(IntPtr ctx, int val)
	{
		NativeMethods.sqlite3_result_int(ctx, val);
	}

	void ISQLite3Provider.sqlite3_result_double(IntPtr ctx, double val)
	{
		NativeMethods.sqlite3_result_double(ctx, val);
	}

	void ISQLite3Provider.sqlite3_result_null(IntPtr stm)
	{
		NativeMethods.sqlite3_result_null(stm);
	}

	unsafe void ISQLite3Provider.sqlite3_result_error(IntPtr ctx, ReadOnlySpan<byte> val)
	{
		fixed (byte* strErr = val)
		{
			NativeMethods.sqlite3_result_error(ctx, strErr, val.Length);
		}
	}

	unsafe void ISQLite3Provider.sqlite3_result_error(IntPtr ctx, utf8z val)
	{
		fixed (byte* strErr = val)
		{
			NativeMethods.sqlite3_result_error(ctx, strErr, -1);
		}
	}

	unsafe void ISQLite3Provider.sqlite3_result_text(IntPtr ctx, ReadOnlySpan<byte> val)
	{
		fixed (byte* val2 = val)
		{
			NativeMethods.sqlite3_result_text(ctx, val2, val.Length, new IntPtr(-1));
		}
	}

	unsafe void ISQLite3Provider.sqlite3_result_text(IntPtr ctx, utf8z val)
	{
		fixed (byte* val2 = val)
		{
			NativeMethods.sqlite3_result_text(ctx, val2, -1, new IntPtr(-1));
		}
	}

	unsafe void ISQLite3Provider.sqlite3_result_blob(IntPtr ctx, ReadOnlySpan<byte> blob)
	{
		fixed (byte* ptr = blob)
		{
			NativeMethods.sqlite3_result_blob(ctx, (IntPtr)ptr, blob.Length, new IntPtr(-1));
		}
	}

	void ISQLite3Provider.sqlite3_result_zeroblob(IntPtr ctx, int n)
	{
		NativeMethods.sqlite3_result_zeroblob(ctx, n);
	}

	void ISQLite3Provider.sqlite3_result_error_toobig(IntPtr ctx)
	{
		NativeMethods.sqlite3_result_error_toobig(ctx);
	}

	void ISQLite3Provider.sqlite3_result_error_nomem(IntPtr ctx)
	{
		NativeMethods.sqlite3_result_error_nomem(ctx);
	}

	void ISQLite3Provider.sqlite3_result_error_code(IntPtr ctx, int code)
	{
		NativeMethods.sqlite3_result_error_code(ctx, code);
	}

	unsafe ReadOnlySpan<byte> ISQLite3Provider.sqlite3_value_blob(IntPtr p)
	{
		IntPtr intPtr = NativeMethods.sqlite3_value_blob(p);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int length = NativeMethods.sqlite3_value_bytes(p);
		return new ReadOnlySpan<byte>(intPtr.ToPointer(), length);
	}

	int ISQLite3Provider.sqlite3_value_bytes(IntPtr p)
	{
		return NativeMethods.sqlite3_value_bytes(p);
	}

	double ISQLite3Provider.sqlite3_value_double(IntPtr p)
	{
		return NativeMethods.sqlite3_value_double(p);
	}

	int ISQLite3Provider.sqlite3_value_int(IntPtr p)
	{
		return NativeMethods.sqlite3_value_int(p);
	}

	long ISQLite3Provider.sqlite3_value_int64(IntPtr p)
	{
		return NativeMethods.sqlite3_value_int64(p);
	}

	int ISQLite3Provider.sqlite3_value_type(IntPtr p)
	{
		return NativeMethods.sqlite3_value_type(p);
	}

	unsafe utf8z ISQLite3Provider.sqlite3_value_text(IntPtr p)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_value_text(p));
	}

	int ISQLite3Provider.sqlite3_bind_int(sqlite3_stmt stm, int paramIndex, int val)
	{
		return NativeMethods.sqlite3_bind_int(stm, paramIndex, val);
	}

	int ISQLite3Provider.sqlite3_bind_int64(sqlite3_stmt stm, int paramIndex, long val)
	{
		return NativeMethods.sqlite3_bind_int64(stm, paramIndex, val);
	}

	unsafe int ISQLite3Provider.sqlite3_bind_text(sqlite3_stmt stm, int paramIndex, ReadOnlySpan<byte> t)
	{
		if (t.Length == 0)
		{
			byte b = 0;
			return NativeMethods.sqlite3_bind_text(stm, paramIndex, &b, 0, new IntPtr(-1));
		}
		fixed (byte* val = t)
		{
			return NativeMethods.sqlite3_bind_text(stm, paramIndex, val, t.Length, new IntPtr(-1));
		}
	}

	unsafe int ISQLite3Provider.sqlite3_bind_text16(sqlite3_stmt stm, int paramIndex, ReadOnlySpan<char> t)
	{
		if (t.Length == 0)
		{
			char c = '\0';
			return NativeMethods.sqlite3_bind_text16(stm, paramIndex, &c, 0, new IntPtr(-1));
		}
		fixed (char* val = t)
		{
			return NativeMethods.sqlite3_bind_text16(stm, paramIndex, val, t.Length * 2, new IntPtr(-1));
		}
	}

	unsafe int ISQLite3Provider.sqlite3_bind_text(sqlite3_stmt stm, int paramIndex, utf8z t)
	{
		fixed (byte* val = t)
		{
			return NativeMethods.sqlite3_bind_text(stm, paramIndex, val, -1, new IntPtr(-1));
		}
	}

	int ISQLite3Provider.sqlite3_bind_double(sqlite3_stmt stm, int paramIndex, double val)
	{
		return NativeMethods.sqlite3_bind_double(stm, paramIndex, val);
	}

	unsafe int ISQLite3Provider.sqlite3_bind_blob(sqlite3_stmt stm, int paramIndex, ReadOnlySpan<byte> blob)
	{
		if (blob.Length == 0)
		{
			byte b = 0;
			return NativeMethods.sqlite3_bind_blob(stm, paramIndex, &b, 0, new IntPtr(-1));
		}
		fixed (byte* val = blob)
		{
			return NativeMethods.sqlite3_bind_blob(stm, paramIndex, val, blob.Length, new IntPtr(-1));
		}
	}

	int ISQLite3Provider.sqlite3_bind_zeroblob(sqlite3_stmt stm, int paramIndex, int size)
	{
		return NativeMethods.sqlite3_bind_zeroblob(stm, paramIndex, size);
	}

	int ISQLite3Provider.sqlite3_bind_null(sqlite3_stmt stm, int paramIndex)
	{
		return NativeMethods.sqlite3_bind_null(stm, paramIndex);
	}

	int ISQLite3Provider.sqlite3_bind_parameter_count(sqlite3_stmt stm)
	{
		return NativeMethods.sqlite3_bind_parameter_count(stm);
	}

	unsafe utf8z ISQLite3Provider.sqlite3_bind_parameter_name(sqlite3_stmt stm, int paramIndex)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_bind_parameter_name(stm, paramIndex));
	}

	unsafe int ISQLite3Provider.sqlite3_bind_parameter_index(sqlite3_stmt stm, utf8z paramName)
	{
		fixed (byte* strName = paramName)
		{
			return NativeMethods.sqlite3_bind_parameter_index(stm, strName);
		}
	}

	int ISQLite3Provider.sqlite3_step(sqlite3_stmt stm)
	{
		return NativeMethods.sqlite3_step(stm);
	}

	int ISQLite3Provider.sqlite3_stmt_isexplain(sqlite3_stmt stm)
	{
		return NativeMethods.sqlite3_stmt_isexplain(stm);
	}

	int ISQLite3Provider.sqlite3_stmt_busy(sqlite3_stmt stm)
	{
		return NativeMethods.sqlite3_stmt_busy(stm);
	}

	int ISQLite3Provider.sqlite3_stmt_readonly(sqlite3_stmt stm)
	{
		return NativeMethods.sqlite3_stmt_readonly(stm);
	}

	int ISQLite3Provider.sqlite3_column_int(sqlite3_stmt stm, int columnIndex)
	{
		return NativeMethods.sqlite3_column_int(stm, columnIndex);
	}

	long ISQLite3Provider.sqlite3_column_int64(sqlite3_stmt stm, int columnIndex)
	{
		return NativeMethods.sqlite3_column_int64(stm, columnIndex);
	}

	unsafe utf8z ISQLite3Provider.sqlite3_column_text(sqlite3_stmt stm, int columnIndex)
	{
		byte* p = NativeMethods.sqlite3_column_text(stm, columnIndex);
		int len = NativeMethods.sqlite3_column_bytes(stm, columnIndex);
		return utf8z.FromPtrLen(p, len);
	}

	unsafe utf8z ISQLite3Provider.sqlite3_column_decltype(sqlite3_stmt stm, int columnIndex)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_column_decltype(stm, columnIndex));
	}

	double ISQLite3Provider.sqlite3_column_double(sqlite3_stmt stm, int columnIndex)
	{
		return NativeMethods.sqlite3_column_double(stm, columnIndex);
	}

	unsafe ReadOnlySpan<byte> ISQLite3Provider.sqlite3_column_blob(sqlite3_stmt stm, int columnIndex)
	{
		IntPtr intPtr = NativeMethods.sqlite3_column_blob(stm, columnIndex);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int length = NativeMethods.sqlite3_column_bytes(stm, columnIndex);
		return new ReadOnlySpan<byte>(intPtr.ToPointer(), length);
	}

	int ISQLite3Provider.sqlite3_column_type(sqlite3_stmt stm, int columnIndex)
	{
		return NativeMethods.sqlite3_column_type(stm, columnIndex);
	}

	int ISQLite3Provider.sqlite3_column_bytes(sqlite3_stmt stm, int columnIndex)
	{
		return NativeMethods.sqlite3_column_bytes(stm, columnIndex);
	}

	int ISQLite3Provider.sqlite3_column_count(sqlite3_stmt stm)
	{
		return NativeMethods.sqlite3_column_count(stm);
	}

	int ISQLite3Provider.sqlite3_data_count(sqlite3_stmt stm)
	{
		return NativeMethods.sqlite3_data_count(stm);
	}

	unsafe utf8z ISQLite3Provider.sqlite3_column_name(sqlite3_stmt stm, int columnIndex)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_column_name(stm, columnIndex));
	}

	unsafe utf8z ISQLite3Provider.sqlite3_column_origin_name(sqlite3_stmt stm, int columnIndex)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_column_origin_name(stm, columnIndex));
	}

	unsafe utf8z ISQLite3Provider.sqlite3_column_table_name(sqlite3_stmt stm, int columnIndex)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_column_table_name(stm, columnIndex));
	}

	unsafe utf8z ISQLite3Provider.sqlite3_column_database_name(sqlite3_stmt stm, int columnIndex)
	{
		return utf8z.FromPtr(NativeMethods.sqlite3_column_database_name(stm, columnIndex));
	}

	int ISQLite3Provider.sqlite3_reset(sqlite3_stmt stm)
	{
		return NativeMethods.sqlite3_reset(stm);
	}

	int ISQLite3Provider.sqlite3_clear_bindings(sqlite3_stmt stm)
	{
		return NativeMethods.sqlite3_clear_bindings(stm);
	}

	int ISQLite3Provider.sqlite3_stmt_status(sqlite3_stmt stm, int op, int resetFlg)
	{
		return NativeMethods.sqlite3_stmt_status(stm, op, resetFlg);
	}

	int ISQLite3Provider.sqlite3_finalize(IntPtr stm)
	{
		return NativeMethods.sqlite3_finalize(stm);
	}

	int ISQLite3Provider.sqlite3_wal_autocheckpoint(sqlite3 db, int n)
	{
		return NativeMethods.sqlite3_wal_autocheckpoint(db, n);
	}

	unsafe int ISQLite3Provider.sqlite3_wal_checkpoint(sqlite3 db, utf8z dbName)
	{
		fixed (byte* dbName2 = dbName)
		{
			return NativeMethods.sqlite3_wal_checkpoint(db, dbName2);
		}
	}

	unsafe int ISQLite3Provider.sqlite3_wal_checkpoint_v2(sqlite3 db, utf8z dbName, int eMode, out int logSize, out int framesCheckPointed)
	{
		fixed (byte* dbName2 = dbName)
		{
			return NativeMethods.sqlite3_wal_checkpoint_v2(db, dbName2, eMode, out logSize, out framesCheckPointed);
		}
	}

	int ISQLite3Provider.sqlite3_keyword_count()
	{
		return NativeMethods.sqlite3_keyword_count();
	}

	unsafe int ISQLite3Provider.sqlite3_keyword_name(int i, out string name)
	{
		byte* name2;
		int length;
		int result = NativeMethods.sqlite3_keyword_name(i, out name2, out length);
		name = Encoding.UTF8.GetString(name2, length);
		return result;
	}

	unsafe IntPtr ISQLite3Provider.sqlite3_serialize(sqlite3 db, utf8z schema, out long size, int flags)
	{
		fixed (byte* schema2 = schema)
		{
			return NativeMethods.sqlite3_serialize(db, schema2, out size, flags);
		}
	}

	unsafe int ISQLite3Provider.sqlite3_deserialize(sqlite3 db, utf8z schema, IntPtr data, long szDb, long szBuf, int flags)
	{
		fixed (byte* schema2 = schema)
		{
			return NativeMethods.sqlite3_deserialize(db, schema2, data, szDb, szBuf, flags);
		}
	}

	static SQLite3Provider_e_sqlite3()
	{
		_ = 3;
		IsArm64cc = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Create("IOS"));
	}
}
