package androidx.room.driver;

import androidx.sqlite.SQLiteConnection;
import androidx.sqlite.db.SupportSQLiteDatabase;
import java.io.IOException;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SupportSQLiteConnection.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SupportSQLiteConnection implements SQLiteConnection {
    private final SupportSQLiteDatabase db;

    public SupportSQLiteConnection(SupportSQLiteDatabase db) {
        Intrinsics.checkNotNullParameter(db, "db");
        this.db = db;
    }

    public final SupportSQLiteDatabase getDb() {
        return this.db;
    }

    @Override // androidx.sqlite.SQLiteConnection
    public SupportSQLiteStatement prepare(String sql) {
        Intrinsics.checkNotNullParameter(sql, "sql");
        return SupportSQLiteStatement.Companion.create(this.db, sql);
    }

    @Override // androidx.sqlite.SQLiteConnection, java.lang.AutoCloseable
    public void close() throws IOException {
        this.db.close();
    }
}
