package androidx.room.driver;

import com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPool;
import kotlin.coroutines.Continuation;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SupportSQLiteConnectionPool.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SupportSQLiteConnectionPool implements ConnectionPool {
    private final SupportSQLiteDriver supportDriver;

    public SupportSQLiteConnectionPool(SupportSQLiteDriver supportDriver) {
        Intrinsics.checkNotNullParameter(supportDriver, "supportDriver");
        this.supportDriver = supportDriver;
    }

    public final SupportSQLiteDriver getSupportDriver$room_runtime_release() {
        return this.supportDriver;
    }

    private final SupportSQLitePooledConnection getSupportConnection() {
        String databaseName = this.supportDriver.getOpenHelper().getDatabaseName();
        if (databaseName == null) {
            databaseName = ":memory:";
        }
        return new SupportSQLitePooledConnection(this.supportDriver.open(databaseName));
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPool
    public Object useConnection(boolean z, Function2 function2, Continuation continuation) {
        return function2.invoke(getSupportConnection(), continuation);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPool, java.lang.AutoCloseable
    public void close() {
        this.supportDriver.getOpenHelper().close();
    }
}
