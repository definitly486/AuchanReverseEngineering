package androidx.room.coroutines;

import androidx.sqlite.SQLiteDriver;
import com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPool;
import com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPoolImpl;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ConnectionPool.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ConnectionPoolKt {
    public static final ConnectionPool newSingleConnectionPool(SQLiteDriver driver, String fileName) {
        Intrinsics.checkNotNullParameter(driver, "driver");
        Intrinsics.checkNotNullParameter(fileName, "fileName");
        return new ConnectionPoolImpl(driver, fileName);
    }

    public static final ConnectionPool newConnectionPool(SQLiteDriver driver, String fileName, int i, int i2) {
        Intrinsics.checkNotNullParameter(driver, "driver");
        Intrinsics.checkNotNullParameter(fileName, "fileName");
        return new ConnectionPoolImpl(driver, fileName, i, i2);
    }
}
