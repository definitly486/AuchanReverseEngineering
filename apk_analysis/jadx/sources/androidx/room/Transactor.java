package androidx.room;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.coroutines.Continuation;
import kotlin.enums.EnumEntries;
import kotlin.jvm.functions.Function2;

/* JADX INFO: compiled from: Transactor.kt */
/* JADX INFO: loaded from: classes.dex */
public interface Transactor extends PooledConnection {

    /* JADX INFO: compiled from: Transactor.kt */
    public enum SQLiteTransactionType {
        DEFERRED,
        IMMEDIATE,
        EXCLUSIVE;

        private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

        public static EnumEntries<SQLiteTransactionType> getEntries() {
            return $ENTRIES;
        }
    }

    Object inTransaction(Continuation continuation);

    Object withTransaction(SQLiteTransactionType sQLiteTransactionType, Function2 function2, Continuation continuation);
}
