package androidx.room.paging;

import android.database.Cursor;
import androidx.sqlite.SQLiteStatement;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: CursorSQLiteStatement.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class CursorSQLiteStatement implements SQLiteStatement {
    public static final Companion Companion = new Companion(null);
    private final Cursor cursor;

    public CursorSQLiteStatement(Cursor cursor) {
        Intrinsics.checkNotNullParameter(cursor, "cursor");
        this.cursor = cursor;
    }

    public byte[] getBlob(int i) {
        byte[] blob = this.cursor.getBlob(i);
        Intrinsics.checkNotNullExpressionValue(blob, "getBlob(...)");
        return blob;
    }

    public double getDouble(int i) {
        return this.cursor.getDouble(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public long getLong(int i) {
        return this.cursor.getLong(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public String getText(int i) {
        String string = this.cursor.getString(i);
        Intrinsics.checkNotNullExpressionValue(string, "getString(...)");
        return string;
    }

    @Override // androidx.sqlite.SQLiteStatement
    public boolean isNull(int i) {
        return this.cursor.isNull(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public int getColumnCount() {
        return this.cursor.getColumnCount();
    }

    @Override // androidx.sqlite.SQLiteStatement
    public String getColumnName(int i) {
        String columnName = this.cursor.getColumnName(i);
        Intrinsics.checkNotNullExpressionValue(columnName, "getColumnName(...)");
        return columnName;
    }

    public int getColumnType(int i) {
        return Companion.getDataType(this.cursor, i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public boolean step() {
        return this.cursor.moveToNext();
    }

    @Override // androidx.sqlite.SQLiteStatement
    public void reset() {
        this.cursor.moveToPosition(-1);
    }

    @Override // androidx.sqlite.SQLiteStatement, java.lang.AutoCloseable
    public void close() {
        this.cursor.close();
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindBlob, reason: merged with bridge method [inline-methods] */
    public Void mo129bindBlob(int i, byte[] value) {
        Intrinsics.checkNotNullParameter(value, "value");
        throw new IllegalStateException("Only get*() calls are allowed on a Cursor backed SQLiteStatement");
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindDouble, reason: merged with bridge method [inline-methods] */
    public Void mo130bindDouble(int i, double d) {
        throw new IllegalStateException("Only get*() calls are allowed on a Cursor backed SQLiteStatement");
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindLong, reason: merged with bridge method [inline-methods] */
    public Void mo131bindLong(int i, long j) {
        throw new IllegalStateException("Only get*() calls are allowed on a Cursor backed SQLiteStatement");
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindText, reason: merged with bridge method [inline-methods] */
    public Void mo133bindText(int i, String value) {
        Intrinsics.checkNotNullParameter(value, "value");
        throw new IllegalStateException("Only get*() calls are allowed on a Cursor backed SQLiteStatement");
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindNull, reason: merged with bridge method [inline-methods] */
    public Void mo132bindNull(int i) {
        throw new IllegalStateException("Only get*() calls are allowed on a Cursor backed SQLiteStatement");
    }

    /* JADX INFO: renamed from: clearBindings, reason: merged with bridge method [inline-methods] */
    public Void m134clearBindings() {
        throw new IllegalStateException("Only get*() calls are allowed on a Cursor backed SQLiteStatement");
    }

    /* JADX INFO: compiled from: CursorSQLiteStatement.android.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        /* JADX INFO: Access modifiers changed from: private */
        public final int getDataType(Cursor cursor, int i) {
            int type = cursor.getType(i);
            int type2 = cursor.getType(i);
            if (type2 == 0) {
                return 5;
            }
            int i2 = 1;
            if (type2 != 1) {
                i2 = 2;
                if (type2 != 2) {
                    i2 = 3;
                    if (type2 != 3) {
                        if (type2 == 4) {
                            return 4;
                        }
                        throw new IllegalStateException(("Unknown field type: " + type).toString());
                    }
                }
            }
            return i2;
        }
    }
}
