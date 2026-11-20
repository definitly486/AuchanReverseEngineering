package androidx.sqlite;

/* JADX INFO: compiled from: SQLiteStatement.kt */
/* JADX INFO: loaded from: classes.dex */
public interface SQLiteStatement extends AutoCloseable {
    /* JADX INFO: renamed from: bindBlob */
    void mo129bindBlob(int i, byte[] bArr);

    /* JADX INFO: renamed from: bindDouble */
    void mo130bindDouble(int i, double d);

    /* JADX INFO: renamed from: bindLong */
    void mo131bindLong(int i, long j);

    /* JADX INFO: renamed from: bindNull */
    void mo132bindNull(int i);

    /* JADX INFO: renamed from: bindText */
    void mo133bindText(int i, String str);

    @Override // java.lang.AutoCloseable
    void close();

    int getColumnCount();

    String getColumnName(int i);

    long getLong(int i);

    String getText(int i);

    boolean isNull(int i);

    void reset();

    boolean step();

    default boolean getBoolean(int i) {
        return getLong(i) != 0;
    }
}
