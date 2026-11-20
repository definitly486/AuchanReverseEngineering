package androidx.room;

import androidx.room.util.SQLiteConnectionUtil;
import androidx.sqlite.SQLiteConnection;
import androidx.sqlite.SQLiteStatement;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.jdk7.AutoCloseableKt;
import java.util.Iterator;
import kotlin.jvm.internal.ArrayIteratorKt;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: EntityDeleteOrUpdateAdapter.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class EntityDeleteOrUpdateAdapter<T> {
    protected abstract void bind(SQLiteStatement sQLiteStatement, T t);

    protected abstract String createQuery();

    public final int handle(SQLiteConnection connection, T t) throws Exception {
        Intrinsics.checkNotNullParameter(connection, "connection");
        if (t == null) {
            return 0;
        }
        SQLiteStatement sQLiteStatementPrepare = connection.prepare(createQuery());
        try {
            bind(sQLiteStatementPrepare, t);
            sQLiteStatementPrepare.step();
            AutoCloseableKt.closeFinally(sQLiteStatementPrepare, null);
            return SQLiteConnectionUtil.getTotalChangedRows(connection);
        } catch (Throwable th) {
            try {
                throw th;
            } catch (Throwable th2) {
                AutoCloseableKt.closeFinally(sQLiteStatementPrepare, th);
                throw th2;
            }
        }
    }

    public final int handleMultiple(SQLiteConnection connection, Iterable<? extends T> iterable) throws Exception {
        Intrinsics.checkNotNullParameter(connection, "connection");
        int totalChangedRows = 0;
        if (iterable == null) {
            return 0;
        }
        SQLiteStatement sQLiteStatementPrepare = connection.prepare(createQuery());
        try {
            for (T t : iterable) {
                if (t != null) {
                    bind(sQLiteStatementPrepare, t);
                    sQLiteStatementPrepare.step();
                    sQLiteStatementPrepare.reset();
                    totalChangedRows += SQLiteConnectionUtil.getTotalChangedRows(connection);
                }
            }
            Unit unit = Unit.INSTANCE;
            AutoCloseableKt.closeFinally(sQLiteStatementPrepare, null);
            return totalChangedRows;
        } catch (Throwable th) {
            try {
                throw th;
            } catch (Throwable th2) {
                AutoCloseableKt.closeFinally(sQLiteStatementPrepare, th);
                throw th2;
            }
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final int handleMultiple(SQLiteConnection connection, T[] tArr) throws Exception {
        Intrinsics.checkNotNullParameter(connection, "connection");
        int totalChangedRows = 0;
        if (tArr == null) {
            return 0;
        }
        SQLiteStatement sQLiteStatementPrepare = connection.prepare(createQuery());
        try {
            Iterator it = ArrayIteratorKt.iterator(tArr);
            while (it.hasNext()) {
                Object next = it.next();
                if (next != null) {
                    bind(sQLiteStatementPrepare, next);
                    sQLiteStatementPrepare.step();
                    sQLiteStatementPrepare.reset();
                    totalChangedRows += SQLiteConnectionUtil.getTotalChangedRows(connection);
                }
            }
            Unit unit = Unit.INSTANCE;
            AutoCloseableKt.closeFinally(sQLiteStatementPrepare, null);
            return totalChangedRows;
        } catch (Throwable th) {
            try {
                throw th;
            } catch (Throwable th2) {
                AutoCloseableKt.closeFinally(sQLiteStatementPrepare, th);
                throw th2;
            }
        }
    }
}
