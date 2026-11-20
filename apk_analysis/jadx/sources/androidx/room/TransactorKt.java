package androidx.room;

import androidx.sqlite.SQLiteStatement;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import kotlin.coroutines.Continuation;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Transactor.kt */
/* JADX INFO: loaded from: classes.dex */
public final class TransactorKt {
    public static final Object execSQL(PooledConnection pooledConnection, String str, Continuation<? super Unit> continuation) {
        Object objUsePrepared = pooledConnection.usePrepared(str, new Function1() { // from class: androidx.room.TransactorKt$$ExternalSyntheticLambda0
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return Boolean.valueOf(TransactorKt.execSQL$lambda$0((SQLiteStatement) obj));
            }
        }, continuation);
        return objUsePrepared == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objUsePrepared : Unit.INSTANCE;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final boolean execSQL$lambda$0(SQLiteStatement it) {
        Intrinsics.checkNotNullParameter(it, "it");
        return it.step();
    }

    public static final <R> Object deferredTransaction(Transactor transactor, Function2<? super TransactionScope<R>, ? super Continuation<? super R>, ? extends Object> function2, Continuation<? super R> continuation) {
        return transactor.withTransaction(Transactor.SQLiteTransactionType.DEFERRED, function2, continuation);
    }

    public static final <R> Object immediateTransaction(Transactor transactor, Function2<? super TransactionScope<R>, ? super Continuation<? super R>, ? extends Object> function2, Continuation<? super R> continuation) {
        return transactor.withTransaction(Transactor.SQLiteTransactionType.IMMEDIATE, function2, continuation);
    }

    public static final <R> Object exclusiveTransaction(Transactor transactor, Function2<? super TransactionScope<R>, ? super Continuation<? super R>, ? extends Object> function2, Continuation<? super R> continuation) {
        return transactor.withTransaction(Transactor.SQLiteTransactionType.EXCLUSIVE, function2, continuation);
    }
}
