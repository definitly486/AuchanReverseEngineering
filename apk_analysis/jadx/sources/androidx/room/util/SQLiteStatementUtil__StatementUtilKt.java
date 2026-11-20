package androidx.room.util;

import androidx.sqlite.SQLiteStatement;
import com.scanflow.datacapture.barinternal.androidx.room.util.MappedColumnsSQLiteStatementWrapper;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.ArrayList;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: StatementUtil.kt */
/* JADX INFO: loaded from: classes.dex */
abstract /* synthetic */ class SQLiteStatementUtil__StatementUtilKt {
    public static final int getColumnIndexOrThrow(SQLiteStatement stmt, String name) {
        Intrinsics.checkNotNullParameter(stmt, "stmt");
        Intrinsics.checkNotNullParameter(name, "name");
        int iColumnIndexOf = SQLiteStatementUtil.columnIndexOf(stmt, name);
        if (iColumnIndexOf >= 0) {
            return iColumnIndexOf;
        }
        int columnCount = stmt.getColumnCount();
        ArrayList arrayList = new ArrayList(columnCount);
        for (int i = 0; i < columnCount; i++) {
            arrayList.add(stmt.getColumnName(i));
        }
        throw new IllegalArgumentException("Column '" + name + "' does not exist. Available columns: [" + CollectionsKt.joinToString$default(arrayList, null, null, null, 0, null, null, 63, null) + ']');
    }

    public static final int columnIndexOfCommon(SQLiteStatement sQLiteStatement, String name) {
        Intrinsics.checkNotNullParameter(sQLiteStatement, "<this>");
        Intrinsics.checkNotNullParameter(name, "name");
        if (sQLiteStatement instanceof MappedColumnsSQLiteStatementWrapper) {
            return ((MappedColumnsSQLiteStatementWrapper) sQLiteStatement).getColumnIndex(name);
        }
        int columnCount = sQLiteStatement.getColumnCount();
        for (int i = 0; i < columnCount; i++) {
            if (Intrinsics.areEqual(name, sQLiteStatement.getColumnName(i))) {
                return i;
            }
        }
        return -1;
    }

    public static final int getColumnIndex(SQLiteStatement stmt, String name) {
        Intrinsics.checkNotNullParameter(stmt, "stmt");
        Intrinsics.checkNotNullParameter(name, "name");
        return SQLiteStatementUtil.columnIndexOf(stmt, name);
    }

    public static final SQLiteStatement wrapMappedColumns(SQLiteStatement statement, String[] columnNames, int[] mapping) {
        Intrinsics.checkNotNullParameter(statement, "statement");
        Intrinsics.checkNotNullParameter(columnNames, "columnNames");
        Intrinsics.checkNotNullParameter(mapping, "mapping");
        return new MappedColumnsSQLiteStatementWrapper(statement, columnNames, mapping);
    }
}
