package com.scanflow.datacapture.utils;

import android.annotation.SuppressLint;
import android.content.ContentResolver;
import android.content.ContentValues;
import android.content.Context;
import android.content.ContextWrapper;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Build;
import android.os.Environment;
import android.provider.MediaStore;
import com.scanflow.datacapture.barinternal.kotlin.io.FilesKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class StorageUtils {
    public static final StorageUtils INSTANCE = new StorageUtils();

    private StorageUtils() {
    }

    private final ContentValues contentValues() {
        ContentValues contentValues = new ContentValues();
        contentValues.put("mime_type", "image/png");
        contentValues.put("date_added", Long.valueOf(System.currentTimeMillis() / ((long) 1000)));
        contentValues.put("datetaken", Long.valueOf(System.currentTimeMillis()));
        return contentValues;
    }

    /* JADX WARN: Code duplicated, block: B:21:0x003c A[PHI: r9
      0x003c: PHI (r9v3 android.database.Cursor) = (r9v2 android.database.Cursor), (r9v4 android.database.Cursor) binds: [B:20:0x003a, B:12:0x002e] A[DONT_GENERATE, DONT_INLINE]] */
    private final String getDataColumn(Context context, Uri uri, String str, String[] strArr) throws Throwable {
        Throwable th;
        Cursor cursorQuery;
        String[] strArr2 = {"_data"};
        Cursor cursor = null;
        try {
            ContentResolver contentResolver = context.getContentResolver();
            Intrinsics.checkNotNull(uri);
            cursorQuery = contentResolver.query(uri, strArr2, str, strArr, null);
            if (cursorQuery != null) {
                try {
                    if (cursorQuery.moveToFirst()) {
                        String string = cursorQuery.getString(cursorQuery.getColumnIndexOrThrow("_data"));
                        cursorQuery.close();
                        return string;
                    }
                } catch (Exception unused) {
                    if (cursorQuery != null) {
                        cursorQuery.close();
                    }
                } catch (Throwable th2) {
                    th = th2;
                    cursor = cursorQuery;
                    if (cursor == null) {
                        throw th;
                    }
                    cursor.close();
                    throw th;
                }
            }
            if (cursorQuery != null) {
                cursorQuery.close();
            }
        } catch (Exception unused2) {
            cursorQuery = null;
        } catch (Throwable th3) {
            th = th3;
        }
        return null;
    }

    private final boolean isDownloadsDocument(Uri uri) {
        return Intrinsics.areEqual("com.android.providers.downloads.documents", uri.getAuthority());
    }

    private final boolean isExternalStorageDocument(Uri uri) {
        return Intrinsics.areEqual("com.android.externalstorage.documents", uri.getAuthority());
    }

    private final boolean isMediaDocument(Uri uri) {
        return Intrinsics.areEqual("com.android.providers.media.documents", uri.getAuthority());
    }

    private final void saveImageToStream(Bitmap bitmap, OutputStream outputStream) {
        if (outputStream != null) {
            try {
                bitmap.compress(Bitmap.CompressFormat.PNG, 100, outputStream);
                outputStream.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    public final Uri addBitmapToStorage(Bitmap bitmap, Context context, String folderName, String str) {
        Intrinsics.checkNotNullParameter(bitmap, "bitmap");
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(folderName, "folderName");
        if (Build.VERSION.SDK_INT >= 29) {
            ContentValues contentValues = contentValues();
            contentValues.put("relative_path", "Pictures/" + folderName);
            contentValues.put("is_pending", Boolean.TRUE);
            Uri uriInsert = context.getContentResolver().insert(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, contentValues);
            if (uriInsert != null) {
                saveImageToStream(bitmap, context.getContentResolver().openOutputStream(uriInsert));
                contentValues.put("is_pending", Boolean.FALSE);
                context.getContentResolver().update(uriInsert, contentValues, null, null);
            }
            return uriInsert;
        }
        File file = new File(Environment.getExternalStorageDirectory() + File.separator + folderName);
        if (!file.exists()) {
            file.mkdirs();
        }
        if (str == null) {
            str = System.currentTimeMillis() + ".png";
        }
        File file2 = new File(file, str);
        saveImageToStream(bitmap, new FileOutputStream(file2));
        if (file2.getAbsolutePath() != null) {
            ContentValues contentValues2 = contentValues();
            contentValues2.put("_data", file2.getAbsolutePath());
            context.getContentResolver().insert(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, contentValues2);
        }
        return Uri.fromFile(file2);
    }

    public final boolean deleteDirectory(Context context, String folderName) {
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(folderName, "folderName");
        try {
            if (Build.VERSION.SDK_INT >= 29) {
                ContentValues contentValues = contentValues();
                contentValues.put("relative_path", "Pictures/" + folderName);
                contentValues.put("is_pending", Boolean.TRUE);
                Uri uriInsert = context.getContentResolver().insert(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, contentValues);
                if (uriInsert != null) {
                    File file = new File(new File(getPath(context, uriInsert)).getParent());
                    if (file.exists()) {
                        FilesKt.deleteRecursively(file);
                    }
                }
            } else {
                File file2 = new File(Environment.getExternalStorageDirectory() + File.separator + folderName);
                if (file2.exists()) {
                    FilesKt.deleteRecursively(file2);
                }
            }
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return true;
        }
    }

    @SuppressLint({"NewApi"})
    public final String getPath(Context context, Uri uri) {
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(uri, "uri");
        if (StringsKt.equals("content", uri.getScheme(), true)) {
            return getDataColumn(context, uri, null, null);
        }
        if (StringsKt.equals("file", uri.getScheme(), true)) {
            return uri.getPath();
        }
        return null;
    }

    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Type inference failed for: r1v11 */
    /* JADX WARN: Type inference failed for: r1v12 */
    /* JADX WARN: Type inference failed for: r1v14 */
    /* JADX WARN: Type inference failed for: r1v15 */
    /* JADX WARN: Type inference failed for: r1v2 */
    /* JADX WARN: Type inference failed for: r1v3 */
    /* JADX WARN: Type inference failed for: r1v4 */
    /* JADX WARN: Type inference failed for: r1v5 */
    /* JADX WARN: Type inference failed for: r1v6, types: [java.io.FileOutputStream, java.lang.Object] */
    /* JADX WARN: Type inference failed for: r1v7 */
    /* JADX WARN: Type inference failed for: r1v8 */
    /* JADX WARN: Type inference failed for: r2v0 */
    /* JADX WARN: Type inference failed for: r2v1, types: [java.io.FileOutputStream, java.lang.Object] */
    /* JADX WARN: Type inference failed for: r2v2, types: [java.io.FileOutputStream, java.io.OutputStream] */
    /* JADX WARN: Type inference failed for: r4v0, types: [android.graphics.Bitmap] */
    public final String saveToInternalStorage(Bitmap bitmap, Context context) throws Throwable {
        ?? fileOutputStream;
        Intrinsics.checkNotNullParameter(context, "context");
        File dir = new ContextWrapper(context).getDir("imageDir", 0);
        ?? r1 = 0;
        char c = 0;
        ?? r2 = 0;
        r1 = 0;
        try {
            try {
                try {
                    fileOutputStream = new FileOutputStream(new File(dir, "profile.jpg"));
                    if (bitmap != 0) {
                        try {
                            c = 'd';
                            bitmap.compress(Bitmap.CompressFormat.PNG, 100, fileOutputStream);
                        } catch (Exception e) {
                            e = e;
                            r2 = fileOutputStream;
                            e.printStackTrace();
                            Intrinsics.checkNotNull(r2);
                            r2.close();
                            r1 = r2;
                        } catch (Throwable th) {
                            th = th;
                            try {
                                Intrinsics.checkNotNull(fileOutputStream);
                                fileOutputStream.close();
                            } catch (IOException e2) {
                                e2.printStackTrace();
                            }
                            throw th;
                        }
                    }
                    fileOutputStream.close();
                    r1 = c;
                } catch (Throwable th2) {
                    th = th2;
                    fileOutputStream = r1;
                }
            } catch (Exception e3) {
                e = e3;
            }
        } catch (IOException e4) {
            e4.printStackTrace();
        }
        return dir.getAbsolutePath();
    }
}
