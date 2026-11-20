package com.google.mediapipe.framework;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.provider.BaseColumns;
import com.google.common.flogger.FluentLogger;
import java.io.File;

/* JADX INFO: loaded from: classes3.dex */
public class AssetCacheDbHelper extends SQLiteOpenHelper {
    private static final String COMMA_SEP = ",";
    public static final String DATABASE_NAME = "mediapipe.db";
    public static final int DATABASE_VERSION = 2;
    private static final String INT_TYPE = " INTEGER";
    private static final String SQL_CREATE_TABLE = "CREATE TABLE AssetVersion (_id INTEGER PRIMARY KEY,asset TEXT NOT NULL UNIQUE,cache_path TEXT,version INTEGER )";
    private static final String SQL_DELETE_TABLE = "DROP TABLE IF EXISTS AssetVersion";
    private static final String TEXT_TYPE = " TEXT";
    private static final String TEXT_UNIQUE_TYPE = " TEXT NOT NULL UNIQUE";
    private static final FluentLogger logger = FluentLogger.forEnclosingClass();

    public static abstract class AssetCacheEntry implements BaseColumns {
        public static final String COLUMN_NAME_ASSET = "asset";
        public static final String COLUMN_NAME_CACHE_PATH = "cache_path";
        public static final String COLUMN_NAME_VERSION = "version";
        public static final String TABLE_NAME = "AssetVersion";
    }

    public AssetCacheDbHelper(Context context) {
        super(context, DATABASE_NAME, (SQLiteDatabase.CursorFactory) null, 2);
    }

    public boolean checkVersion(String str, int i) {
        Cursor cursorQueryAssetCacheTable = queryAssetCacheTable(getReadableDatabase(), new String[]{AssetCacheEntry.COLUMN_NAME_VERSION}, "asset = ?", new String[]{str});
        if (cursorQueryAssetCacheTable.getCount() == 0) {
            return false;
        }
        cursorQueryAssetCacheTable.moveToFirst();
        int i2 = cursorQueryAssetCacheTable.getInt(cursorQueryAssetCacheTable.getColumnIndexOrThrow(AssetCacheEntry.COLUMN_NAME_VERSION));
        cursorQueryAssetCacheTable.close();
        return i2 == i;
    }

    public void invalidateCache(int i) {
        SQLiteDatabase writableDatabase = getWritableDatabase();
        String[] strArr = {Integer.toString(i)};
        removeCachedFiles(writableDatabase, "version != ?", strArr);
        writableDatabase.delete(AssetCacheEntry.TABLE_NAME, "version != ?", strArr);
    }

    public void insertAsset(String str, String str2, int i) {
        SQLiteDatabase writableDatabase = getWritableDatabase();
        removeCachedFiles(writableDatabase, "asset = ? and cache_path != ?", new String[]{str, str2});
        ContentValues contentValues = new ContentValues();
        contentValues.put(AssetCacheEntry.COLUMN_NAME_ASSET, str);
        contentValues.put(AssetCacheEntry.COLUMN_NAME_CACHE_PATH, str2);
        contentValues.put(AssetCacheEntry.COLUMN_NAME_VERSION, Integer.valueOf(i));
        if (writableDatabase.insertWithOnConflict(AssetCacheEntry.TABLE_NAME, null, contentValues, 5) == -1) {
            throw new RuntimeException("Can't insert entry into the mediapipe db.");
        }
    }

    @Override // android.database.sqlite.SQLiteOpenHelper
    public void onCreate(SQLiteDatabase sQLiteDatabase) {
        sQLiteDatabase.execSQL(SQL_CREATE_TABLE);
    }

    @Override // android.database.sqlite.SQLiteOpenHelper
    public void onUpgrade(SQLiteDatabase sQLiteDatabase, int i, int i2) {
        sQLiteDatabase.execSQL(SQL_DELETE_TABLE);
        onCreate(sQLiteDatabase);
    }

    @Override // android.database.sqlite.SQLiteOpenHelper
    public void onDowngrade(SQLiteDatabase sQLiteDatabase, int i, int i2) {
        onUpgrade(sQLiteDatabase, i, i2);
    }

    private Cursor queryAssetCacheTable(SQLiteDatabase sQLiteDatabase, String[] strArr, String str, String[] strArr2) {
        return sQLiteDatabase.query(AssetCacheEntry.TABLE_NAME, strArr, str, strArr2, null, null, null);
    }

    private void removeCachedFiles(SQLiteDatabase sQLiteDatabase, String str, String[] strArr) {
        Cursor cursorQueryAssetCacheTable = queryAssetCacheTable(sQLiteDatabase, new String[]{AssetCacheEntry.COLUMN_NAME_CACHE_PATH}, str, strArr);
        if (cursorQueryAssetCacheTable.moveToFirst()) {
            do {
                String string = cursorQueryAssetCacheTable.getString(cursorQueryAssetCacheTable.getColumnIndexOrThrow(AssetCacheEntry.COLUMN_NAME_CACHE_PATH));
                File file = new File(string);
                if (file.exists() && !file.delete()) {
                    logger.atWarning().log("Stale cached file: %s can't be deleted.", string);
                }
            } while (cursorQueryAssetCacheTable.moveToNext());
        }
        cursorQueryAssetCacheTable.close();
    }
}
