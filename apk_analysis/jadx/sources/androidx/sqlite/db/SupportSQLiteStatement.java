package androidx.sqlite.db;

/* JADX INFO: compiled from: SupportSQLiteStatement.android.kt */
/* JADX INFO: loaded from: classes.dex */
public interface SupportSQLiteStatement extends SupportSQLiteProgram {
    void execute();

    long executeInsert();

    int executeUpdateDelete();
}
