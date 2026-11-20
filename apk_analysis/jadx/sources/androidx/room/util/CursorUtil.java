package androidx.room.util;

import android.database.Cursor;
import android.database.CursorWrapper;
import android.database.MatrixCursor;
import android.util.Log;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.io.CloseableKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.coreutils.internal.services.telephony.CellularNetworkTypeExtractor;
import java.io.IOException;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.InlineMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: CursorUtil.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class CursorUtil {
    private static final int findColumnIndexBySuffix(Cursor cursor, String str) {
        return -1;
    }

    public static final int getColumnIndex(Cursor c, String name) {
        Intrinsics.checkNotNullParameter(c, "c");
        Intrinsics.checkNotNullParameter(name, "name");
        int columnIndex = c.getColumnIndex(name);
        if (columnIndex >= 0) {
            return columnIndex;
        }
        int columnIndex2 = c.getColumnIndex('`' + name + '`');
        return columnIndex2 >= 0 ? columnIndex2 : findColumnIndexBySuffix(c, name);
    }

    public static final int getColumnIndexOrThrow(Cursor c, String name) {
        String strJoinToString$default;
        Intrinsics.checkNotNullParameter(c, "c");
        Intrinsics.checkNotNullParameter(name, "name");
        int columnIndex = getColumnIndex(c, name);
        if (columnIndex >= 0) {
            return columnIndex;
        }
        try {
            String[] columnNames = c.getColumnNames();
            Intrinsics.checkNotNullExpressionValue(columnNames, "getColumnNames(...)");
            strJoinToString$default = ArraysKt.joinToString$default(columnNames, null, null, null, 0, null, null, 63, null);
        } catch (Exception e) {
            Log.d("RoomCursorUtil", "Cannot collect column names for debug purposes", e);
            strJoinToString$default = CellularNetworkTypeExtractor.UNKNOWN_NETWORK_TYPE_VALUE;
        }
        throw new IllegalArgumentException("column '" + name + "' does not exist. Available columns: " + strJoinToString$default);
    }

    public static final int findColumnIndexBySuffix(String[] columnNames, String name) {
        Intrinsics.checkNotNullParameter(columnNames, "columnNames");
        Intrinsics.checkNotNullParameter(name, "name");
        String str = '.' + name;
        String str2 = '.' + name + '`';
        int length = columnNames.length;
        int i = 0;
        int i2 = 0;
        while (i < length) {
            String str3 = columnNames[i];
            int i3 = i2 + 1;
            if (str3.length() >= name.length() + 2 && (StringsKt.endsWith$default(str3, str, false, 2, (Object) null) || (str3.charAt(0) == '`' && StringsKt.endsWith$default(str3, str2, false, 2, (Object) null)))) {
                return i2;
            }
            i++;
            i2 = i3;
        }
        return -1;
    }

    public static final Cursor copyAndClose(Cursor c) throws IOException {
        Intrinsics.checkNotNullParameter(c, "c");
        Cursor cursor = c;
        try {
            Cursor cursor2 = cursor;
            MatrixCursor matrixCursor = new MatrixCursor(cursor2.getColumnNames(), cursor2.getCount());
            while (cursor2.moveToNext()) {
                Object[] objArr = new Object[cursor2.getColumnCount()];
                int columnCount = c.getColumnCount();
                for (int i = 0; i < columnCount; i++) {
                    int type = cursor2.getType(i);
                    if (type == 0) {
                        objArr[i] = null;
                    } else if (type == 1) {
                        objArr[i] = Long.valueOf(cursor2.getLong(i));
                    } else if (type == 2) {
                        objArr[i] = Double.valueOf(cursor2.getDouble(i));
                    } else if (type == 3) {
                        objArr[i] = cursor2.getString(i);
                    } else if (type == 4) {
                        objArr[i] = cursor2.getBlob(i);
                    } else {
                        throw new IllegalStateException();
                    }
                }
                matrixCursor.addRow(objArr);
            }
            CloseableKt.closeFinally(cursor, null);
            return matrixCursor;
        } catch (Throwable th) {
            try {
                throw th;
            } catch (Throwable th2) {
                CloseableKt.closeFinally(cursor, th);
                throw th2;
            }
        }
    }

    public static final <R> R useCursor(Cursor cursor, Function1<? super Cursor, ? extends R> block) throws IOException {
        Intrinsics.checkNotNullParameter(cursor, "<this>");
        Intrinsics.checkNotNullParameter(block, "block");
        Cursor cursor2 = cursor;
        try {
            R rInvoke = block.invoke(cursor2);
            InlineMarker.finallyStart(1);
            CloseableKt.closeFinally(cursor2, null);
            InlineMarker.finallyEnd(1);
            return rInvoke;
        } catch (Throwable th) {
            try {
                throw th;
            } catch (Throwable th2) {
                InlineMarker.finallyStart(1);
                CloseableKt.closeFinally(cursor2, th);
                InlineMarker.finallyEnd(1);
                throw th2;
            }
        }
    }

    public static final Cursor wrapMappedColumns(Cursor cursor, final String[] columnNames, final int[] mapping) {
        Intrinsics.checkNotNullParameter(cursor, "cursor");
        Intrinsics.checkNotNullParameter(columnNames, "columnNames");
        Intrinsics.checkNotNullParameter(mapping, "mapping");
        if (columnNames.length != mapping.length) {
            throw new IllegalStateException("Expected columnNames.length == mapping.length");
        }
        return new CursorWrapper(cursor) { // from class: androidx.room.util.CursorUtil.wrapMappedColumns.2
            @Override // android.database.CursorWrapper, android.database.Cursor
            public int getColumnIndex(String columnName) {
                Intrinsics.checkNotNullParameter(columnName, "columnName");
                String[] strArr = columnNames;
                int[] iArr = mapping;
                int length = strArr.length;
                int i = 0;
                int i2 = 0;
                while (i < length) {
                    int i3 = i2 + 1;
                    if (StringsKt.equals(strArr[i], columnName, true)) {
                        return iArr[i2];
                    }
                    i++;
                    i2 = i3;
                }
                return super.getColumnIndex(columnName);
            }
        };
    }
}
