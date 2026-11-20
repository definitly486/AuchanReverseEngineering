package androidx.room.util;

import androidx.sqlite.SQLiteStatement;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: StatementUtil.android.kt */
/* JADX INFO: loaded from: classes.dex */
abstract /* synthetic */ class SQLiteStatementUtil__StatementUtil_androidKt {
    private static final int findColumnIndexBySuffix$SQLiteStatementUtil__StatementUtil_androidKt(SQLiteStatement sQLiteStatement, String str) {
        return -1;
    }

    public static final int columnIndexOf(SQLiteStatement sQLiteStatement, String name) {
        Intrinsics.checkNotNullParameter(sQLiteStatement, "<this>");
        Intrinsics.checkNotNullParameter(name, "name");
        int iColumnIndexOfCommon = SQLiteStatementUtil.columnIndexOfCommon(sQLiteStatement, name);
        if (iColumnIndexOfCommon >= 0) {
            return iColumnIndexOfCommon;
        }
        int iColumnIndexOfCommon2 = SQLiteStatementUtil.columnIndexOfCommon(sQLiteStatement, '`' + name + '`');
        return iColumnIndexOfCommon2 >= 0 ? iColumnIndexOfCommon2 : findColumnIndexBySuffix$SQLiteStatementUtil__StatementUtil_androidKt(sQLiteStatement, name);
    }
}
