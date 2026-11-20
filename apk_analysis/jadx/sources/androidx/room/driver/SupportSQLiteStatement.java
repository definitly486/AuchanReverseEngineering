package androidx.room.driver;

import android.database.Cursor;
import androidx.sqlite.SQLite;
import androidx.sqlite.SQLiteStatement;
import androidx.sqlite.db.SupportSQLiteDatabase;
import androidx.sqlite.db.SupportSQLiteProgram;
import androidx.sqlite.db.SupportSQLiteQuery;
import com.scanflow.datacapture.barinternal.kotlin.KotlinNothingValueException;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.io.IOException;
import java.util.Arrays;
import java.util.Locale;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SupportSQLiteStatement.android.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class SupportSQLiteStatement implements SQLiteStatement {
    public static final Companion Companion = new Companion(null);
    private final SupportSQLiteDatabase db;
    private boolean isClosed;
    private final String sql;

    public /* synthetic */ SupportSQLiteStatement(SupportSQLiteDatabase supportSQLiteDatabase, String str, DefaultConstructorMarker defaultConstructorMarker) {
        this(supportSQLiteDatabase, str);
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindBlob */
    public abstract /* synthetic */ void mo129bindBlob(int i, byte[] bArr);

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindDouble */
    public abstract /* synthetic */ void mo130bindDouble(int i, double d);

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindLong */
    public abstract /* synthetic */ void mo131bindLong(int i, long j);

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindNull */
    public abstract /* synthetic */ void mo132bindNull(int i);

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindText */
    public abstract /* synthetic */ void mo133bindText(int i, String str);

    public abstract /* synthetic */ void clearBindings();

    @Override // androidx.sqlite.SQLiteStatement, java.lang.AutoCloseable
    public abstract /* synthetic */ void close();

    public abstract /* synthetic */ byte[] getBlob(int i);

    @Override // androidx.sqlite.SQLiteStatement
    public abstract /* synthetic */ int getColumnCount();

    @Override // androidx.sqlite.SQLiteStatement
    public abstract /* synthetic */ String getColumnName(int i);

    public abstract /* synthetic */ int getColumnType(int i);

    public abstract /* synthetic */ double getDouble(int i);

    @Override // androidx.sqlite.SQLiteStatement
    public abstract /* synthetic */ long getLong(int i);

    @Override // androidx.sqlite.SQLiteStatement
    public abstract /* synthetic */ String getText(int i);

    @Override // androidx.sqlite.SQLiteStatement
    public abstract /* synthetic */ boolean isNull(int i);

    @Override // androidx.sqlite.SQLiteStatement
    public abstract /* synthetic */ void reset();

    @Override // androidx.sqlite.SQLiteStatement
    public abstract /* synthetic */ boolean step();

    private SupportSQLiteStatement(SupportSQLiteDatabase supportSQLiteDatabase, String str) {
        this.db = supportSQLiteDatabase;
        this.sql = str;
    }

    protected final SupportSQLiteDatabase getDb() {
        return this.db;
    }

    protected final String getSql() {
        return this.sql;
    }

    protected final boolean isClosed() {
        return this.isClosed;
    }

    protected final void setClosed(boolean z) {
        this.isClosed = z;
    }

    protected final void throwIfClosed() {
        if (this.isClosed) {
            SQLite.throwSQLiteException(21, "statement is closed");
            throw new KotlinNothingValueException();
        }
    }

    /* JADX INFO: compiled from: SupportSQLiteStatement.android.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        public final SupportSQLiteStatement create(SupportSQLiteDatabase db, String sql) {
            Intrinsics.checkNotNullParameter(db, "db");
            Intrinsics.checkNotNullParameter(sql, "sql");
            String upperCase = StringsKt.trim(sql).toString().toUpperCase(Locale.ROOT);
            Intrinsics.checkNotNullExpressionValue(upperCase, "toUpperCase(...)");
            String statementPrefix$room_runtime_release = getStatementPrefix$room_runtime_release(upperCase);
            if (statementPrefix$room_runtime_release == null) {
                return new SupportOtherAndroidSQLiteStatement(db, sql);
            }
            if (isRowStatement(statementPrefix$room_runtime_release)) {
                return new SupportAndroidSQLiteStatement(db, sql);
            }
            return new SupportOtherAndroidSQLiteStatement(db, sql);
        }

        private final boolean isRowStatement(String str) {
            int iHashCode = str.hashCode();
            if (iHashCode == 79487) {
                return str.equals("PRA");
            }
            if (iHashCode != 81978) {
                return iHashCode == 85954 && str.equals("WIT");
            }
            return str.equals("SEL");
        }

        public final String getStatementPrefix$room_runtime_release(String sql) {
            Intrinsics.checkNotNullParameter(sql, "sql");
            int statementPrefixIndex = getStatementPrefixIndex(sql);
            if (statementPrefixIndex < 0 || statementPrefixIndex > sql.length()) {
                return null;
            }
            String strSubstring = sql.substring(statementPrefixIndex, Math.min(statementPrefixIndex + 3, sql.length()));
            Intrinsics.checkNotNullExpressionValue(strSubstring, "substring(...)");
            return strSubstring;
        }

        private final int getStatementPrefixIndex(String str) {
            String str2;
            int i;
            int length = str.length() - 2;
            if (length < 0) {
                return -1;
            }
            int i2 = 0;
            while (i2 < length) {
                char cCharAt = str.charAt(i2);
                if (Intrinsics.compare((int) cCharAt, 32) <= 0) {
                    i2++;
                } else {
                    if (cCharAt != '-') {
                        str2 = str;
                        if (cCharAt == '/') {
                            int iIndexOf$default = i2 + 1;
                            if (str2.charAt(iIndexOf$default) == '*') {
                                do {
                                    String str3 = str2;
                                    iIndexOf$default = StringsKt.indexOf$default((CharSequence) str3, '*', iIndexOf$default + 1, false, 4, (Object) null);
                                    str2 = str3;
                                    if (iIndexOf$default >= 0) {
                                        i = iIndexOf$default + 1;
                                        if (i >= length) {
                                            break;
                                        }
                                    } else {
                                        return -1;
                                    }
                                } while (str2.charAt(i) != '/');
                                i2 = iIndexOf$default + 2;
                                str = str2;
                            }
                        }
                        return i2;
                    }
                    if (str.charAt(i2 + 1) != '-') {
                        return i2;
                    }
                    str2 = str;
                    int iIndexOf$default2 = StringsKt.indexOf$default((CharSequence) str2, '\n', i2 + 2, false, 4, (Object) null);
                    if (iIndexOf$default2 < 0) {
                        return -1;
                    }
                    i2 = iIndexOf$default2 + 1;
                    str = str2;
                }
            }
            return -1;
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX INFO: compiled from: SupportSQLiteStatement.android.kt */
    static final class SupportAndroidSQLiteStatement extends SupportSQLiteStatement {
        public static final Companion Companion = new Companion(null);
        private int[] bindingTypes;
        private byte[][] blobBindings;
        private Cursor cursor;
        private double[] doubleBindings;
        private long[] longBindings;
        private String[] stringBindings;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        public SupportAndroidSQLiteStatement(SupportSQLiteDatabase db, String sql) {
            super(db, sql, null);
            Intrinsics.checkNotNullParameter(db, "db");
            Intrinsics.checkNotNullParameter(sql, "sql");
            this.bindingTypes = new int[0];
            this.longBindings = new long[0];
            this.doubleBindings = new double[0];
            this.stringBindings = new String[0];
            this.blobBindings = new byte[0][];
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindBlob */
        public void mo129bindBlob(int i, byte[] value) {
            Intrinsics.checkNotNullParameter(value, "value");
            throwIfClosed();
            ensureCapacity(4, i);
            this.bindingTypes[i] = 4;
            this.blobBindings[i] = value;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindDouble */
        public void mo130bindDouble(int i, double d) {
            throwIfClosed();
            ensureCapacity(2, i);
            this.bindingTypes[i] = 2;
            this.doubleBindings[i] = d;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindLong */
        public void mo131bindLong(int i, long j) {
            throwIfClosed();
            ensureCapacity(1, i);
            this.bindingTypes[i] = 1;
            this.longBindings[i] = j;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindText */
        public void mo133bindText(int i, String value) {
            Intrinsics.checkNotNullParameter(value, "value");
            throwIfClosed();
            ensureCapacity(3, i);
            this.bindingTypes[i] = 3;
            this.stringBindings[i] = value;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindNull */
        public void mo132bindNull(int i) {
            throwIfClosed();
            ensureCapacity(5, i);
            this.bindingTypes[i] = 5;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement
        public byte[] getBlob(int i) {
            throwIfClosed();
            Cursor cursorThrowIfNoRow = throwIfNoRow();
            throwIfInvalidColumn(cursorThrowIfNoRow, i);
            byte[] blob = cursorThrowIfNoRow.getBlob(i);
            Intrinsics.checkNotNullExpressionValue(blob, "getBlob(...)");
            return blob;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement
        public double getDouble(int i) {
            throwIfClosed();
            Cursor cursorThrowIfNoRow = throwIfNoRow();
            throwIfInvalidColumn(cursorThrowIfNoRow, i);
            return cursorThrowIfNoRow.getDouble(i);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public long getLong(int i) {
            throwIfClosed();
            Cursor cursorThrowIfNoRow = throwIfNoRow();
            throwIfInvalidColumn(cursorThrowIfNoRow, i);
            return cursorThrowIfNoRow.getLong(i);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public String getText(int i) {
            throwIfClosed();
            Cursor cursorThrowIfNoRow = throwIfNoRow();
            throwIfInvalidColumn(cursorThrowIfNoRow, i);
            String string = cursorThrowIfNoRow.getString(i);
            Intrinsics.checkNotNullExpressionValue(string, "getString(...)");
            return string;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public boolean isNull(int i) {
            throwIfClosed();
            Cursor cursorThrowIfNoRow = throwIfNoRow();
            throwIfInvalidColumn(cursorThrowIfNoRow, i);
            return cursorThrowIfNoRow.isNull(i);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public int getColumnCount() {
            throwIfClosed();
            ensureCursor();
            Cursor cursor = this.cursor;
            if (cursor != null) {
                return cursor.getColumnCount();
            }
            return 0;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public String getColumnName(int i) {
            throwIfClosed();
            ensureCursor();
            Cursor cursor = this.cursor;
            if (cursor == null) {
                throw new IllegalStateException("Required value was null.");
            }
            throwIfInvalidColumn(cursor, i);
            String columnName = cursor.getColumnName(i);
            Intrinsics.checkNotNullExpressionValue(columnName, "getColumnName(...)");
            return columnName;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement
        public int getColumnType(int i) {
            throwIfClosed();
            ensureCursor();
            Cursor cursor = this.cursor;
            if (cursor == null) {
                throw new IllegalStateException("Required value was null.");
            }
            throwIfInvalidColumn(cursor, i);
            return Companion.getDataType(cursor, i);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public boolean step() {
            throwIfClosed();
            ensureCursor();
            Cursor cursor = this.cursor;
            if (cursor != null) {
                return cursor.moveToNext();
            }
            throw new IllegalStateException("Required value was null.");
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public void reset() {
            throwIfClosed();
            Cursor cursor = this.cursor;
            if (cursor != null) {
                cursor.close();
            }
            this.cursor = null;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement
        public void clearBindings() {
            throwIfClosed();
            this.bindingTypes = new int[0];
            this.longBindings = new long[0];
            this.doubleBindings = new double[0];
            this.stringBindings = new String[0];
            this.blobBindings = new byte[0][];
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement, java.lang.AutoCloseable
        public void close() {
            if (!isClosed()) {
                clearBindings();
                reset();
            }
            setClosed(true);
        }

        private final void ensureCapacity(int i, int i2) {
            int i3 = i2 + 1;
            int[] iArr = this.bindingTypes;
            if (iArr.length < i3) {
                int[] iArrCopyOf = Arrays.copyOf(iArr, i3);
                Intrinsics.checkNotNullExpressionValue(iArrCopyOf, "copyOf(...)");
                this.bindingTypes = iArrCopyOf;
            }
            if (i == 1) {
                long[] jArr = this.longBindings;
                if (jArr.length < i3) {
                    long[] jArrCopyOf = Arrays.copyOf(jArr, i3);
                    Intrinsics.checkNotNullExpressionValue(jArrCopyOf, "copyOf(...)");
                    this.longBindings = jArrCopyOf;
                    return;
                }
                return;
            }
            if (i == 2) {
                double[] dArr = this.doubleBindings;
                if (dArr.length < i3) {
                    double[] dArrCopyOf = Arrays.copyOf(dArr, i3);
                    Intrinsics.checkNotNullExpressionValue(dArrCopyOf, "copyOf(...)");
                    this.doubleBindings = dArrCopyOf;
                    return;
                }
                return;
            }
            if (i == 3) {
                String[] strArr = this.stringBindings;
                if (strArr.length < i3) {
                    Object[] objArrCopyOf = Arrays.copyOf(strArr, i3);
                    Intrinsics.checkNotNullExpressionValue(objArrCopyOf, "copyOf(...)");
                    this.stringBindings = (String[]) objArrCopyOf;
                    return;
                }
                return;
            }
            if (i != 4) {
                return;
            }
            byte[][] bArr = this.blobBindings;
            if (bArr.length < i3) {
                Object[] objArrCopyOf2 = Arrays.copyOf(bArr, i3);
                Intrinsics.checkNotNullExpressionValue(objArrCopyOf2, "copyOf(...)");
                this.blobBindings = (byte[][]) objArrCopyOf2;
            }
        }

        private final void ensureCursor() {
            if (this.cursor == null) {
                this.cursor = getDb().query(new SupportSQLiteQuery() { // from class: androidx.room.driver.SupportSQLiteStatement$SupportAndroidSQLiteStatement$ensureCursor$1
                    @Override // androidx.sqlite.db.SupportSQLiteQuery
                    public String getSql() {
                        return this.this$0.getSql();
                    }

                    @Override // androidx.sqlite.db.SupportSQLiteQuery
                    public void bindTo(SupportSQLiteProgram statement) {
                        Intrinsics.checkNotNullParameter(statement, "statement");
                        int length = this.this$0.bindingTypes.length;
                        for (int i = 1; i < length; i++) {
                            int i2 = this.this$0.bindingTypes[i];
                            if (i2 == 1) {
                                statement.bindLong(i, this.this$0.longBindings[i]);
                            } else if (i2 == 2) {
                                statement.bindDouble(i, this.this$0.doubleBindings[i]);
                            } else if (i2 == 3) {
                                String str = this.this$0.stringBindings[i];
                                Intrinsics.checkNotNull(str);
                                statement.bindString(i, str);
                            } else if (i2 == 4) {
                                byte[] bArr = this.this$0.blobBindings[i];
                                Intrinsics.checkNotNull(bArr);
                                statement.bindBlob(i, bArr);
                            } else if (i2 == 5) {
                                statement.bindNull(i);
                            }
                        }
                    }

                    @Override // androidx.sqlite.db.SupportSQLiteQuery
                    public int getArgCount() {
                        return this.this$0.bindingTypes.length;
                    }
                });
            }
        }

        private final Cursor throwIfNoRow() {
            Cursor cursor = this.cursor;
            if (cursor != null) {
                return cursor;
            }
            SQLite.throwSQLiteException(21, "no row");
            throw new KotlinNothingValueException();
        }

        private final void throwIfInvalidColumn(Cursor cursor, int i) {
            if (i < 0 || i >= cursor.getColumnCount()) {
                SQLite.throwSQLiteException(25, "column index out of range");
                throw new KotlinNothingValueException();
            }
        }

        /* JADX INFO: compiled from: SupportSQLiteStatement.android.kt */
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

    /* JADX INFO: compiled from: SupportSQLiteStatement.android.kt */
    private static final class SupportOtherAndroidSQLiteStatement extends SupportSQLiteStatement {
        private final androidx.sqlite.db.SupportSQLiteStatement delegate;

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public void reset() {
        }

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        public SupportOtherAndroidSQLiteStatement(SupportSQLiteDatabase db, String sql) {
            super(db, sql, null);
            Intrinsics.checkNotNullParameter(db, "db");
            Intrinsics.checkNotNullParameter(sql, "sql");
            this.delegate = db.compileStatement(sql);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindBlob */
        public void mo129bindBlob(int i, byte[] value) {
            Intrinsics.checkNotNullParameter(value, "value");
            throwIfClosed();
            this.delegate.bindBlob(i, value);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindDouble */
        public void mo130bindDouble(int i, double d) {
            throwIfClosed();
            this.delegate.bindDouble(i, d);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindLong */
        public void mo131bindLong(int i, long j) {
            throwIfClosed();
            this.delegate.bindLong(i, j);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindText */
        public void mo133bindText(int i, String value) {
            Intrinsics.checkNotNullParameter(value, "value");
            throwIfClosed();
            this.delegate.bindString(i, value);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindNull */
        public void mo132bindNull(int i) {
            throwIfClosed();
            this.delegate.bindNull(i);
        }

        @Override // androidx.room.driver.SupportSQLiteStatement
        public byte[] getBlob(int i) {
            throwIfClosed();
            SQLite.throwSQLiteException(21, "no row");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.room.driver.SupportSQLiteStatement
        public double getDouble(int i) {
            throwIfClosed();
            SQLite.throwSQLiteException(21, "no row");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public long getLong(int i) {
            throwIfClosed();
            SQLite.throwSQLiteException(21, "no row");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public String getText(int i) {
            throwIfClosed();
            SQLite.throwSQLiteException(21, "no row");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public boolean isNull(int i) {
            throwIfClosed();
            SQLite.throwSQLiteException(21, "no row");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public int getColumnCount() {
            throwIfClosed();
            return 0;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public String getColumnName(int i) {
            throwIfClosed();
            SQLite.throwSQLiteException(21, "no row");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.room.driver.SupportSQLiteStatement
        public int getColumnType(int i) {
            throwIfClosed();
            SQLite.throwSQLiteException(21, "no row");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement
        public boolean step() {
            throwIfClosed();
            this.delegate.execute();
            return false;
        }

        @Override // androidx.room.driver.SupportSQLiteStatement
        public void clearBindings() {
            throwIfClosed();
            this.delegate.clearBindings();
        }

        @Override // androidx.room.driver.SupportSQLiteStatement, androidx.sqlite.SQLiteStatement, java.lang.AutoCloseable
        public void close() throws IOException {
            this.delegate.close();
            setClosed(true);
        }
    }
}
