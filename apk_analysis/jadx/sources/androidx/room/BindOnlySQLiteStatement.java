package androidx.room;

import androidx.sqlite.SQLiteStatement;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: RoomRawQuery.kt */
/* JADX INFO: loaded from: classes.dex */
final class BindOnlySQLiteStatement implements SQLiteStatement {
    public static final Companion Companion = new Companion(null);
    private final /* synthetic */ SQLiteStatement $$delegate_0;

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindBlob */
    public void mo129bindBlob(int i, byte[] value) {
        Intrinsics.checkNotNullParameter(value, "value");
        this.$$delegate_0.mo129bindBlob(i, value);
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindDouble */
    public void mo130bindDouble(int i, double d) {
        this.$$delegate_0.mo130bindDouble(i, d);
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindLong */
    public void mo131bindLong(int i, long j) {
        this.$$delegate_0.mo131bindLong(i, j);
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindNull */
    public void mo132bindNull(int i) {
        this.$$delegate_0.mo132bindNull(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindText */
    public void mo133bindText(int i, String value) {
        Intrinsics.checkNotNullParameter(value, "value");
        this.$$delegate_0.mo133bindText(i, value);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public boolean getBoolean(int i) {
        return this.$$delegate_0.getBoolean(i);
    }

    public BindOnlySQLiteStatement(SQLiteStatement delegate) {
        Intrinsics.checkNotNullParameter(delegate, "delegate");
        this.$$delegate_0 = delegate;
    }

    @Override // androidx.sqlite.SQLiteStatement
    public long getLong(int i) {
        throw new IllegalStateException("Only bind*() calls are allowed on the RoomRawQuery received statement.");
    }

    @Override // androidx.sqlite.SQLiteStatement
    public String getText(int i) {
        throw new IllegalStateException("Only bind*() calls are allowed on the RoomRawQuery received statement.");
    }

    @Override // androidx.sqlite.SQLiteStatement
    public boolean isNull(int i) {
        throw new IllegalStateException("Only bind*() calls are allowed on the RoomRawQuery received statement.");
    }

    @Override // androidx.sqlite.SQLiteStatement
    public int getColumnCount() {
        throw new IllegalStateException("Only bind*() calls are allowed on the RoomRawQuery received statement.");
    }

    @Override // androidx.sqlite.SQLiteStatement
    public String getColumnName(int i) {
        throw new IllegalStateException("Only bind*() calls are allowed on the RoomRawQuery received statement.");
    }

    @Override // androidx.sqlite.SQLiteStatement
    public boolean step() {
        throw new IllegalStateException("Only bind*() calls are allowed on the RoomRawQuery received statement.");
    }

    @Override // androidx.sqlite.SQLiteStatement
    public void reset() {
        throw new IllegalStateException("Only bind*() calls are allowed on the RoomRawQuery received statement.");
    }

    @Override // androidx.sqlite.SQLiteStatement, java.lang.AutoCloseable
    public void close() {
        throw new IllegalStateException("Only bind*() calls are allowed on the RoomRawQuery received statement.");
    }

    /* JADX INFO: compiled from: RoomRawQuery.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }
    }
}
