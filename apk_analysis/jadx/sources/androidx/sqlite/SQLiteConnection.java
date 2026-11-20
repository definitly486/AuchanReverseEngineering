package androidx.sqlite;

/* JADX INFO: compiled from: SQLiteConnection.kt */
/* JADX INFO: loaded from: classes.dex */
public interface SQLiteConnection extends AutoCloseable {
    @Override // java.lang.AutoCloseable
    void close();

    SQLiteStatement prepare(String str);
}
