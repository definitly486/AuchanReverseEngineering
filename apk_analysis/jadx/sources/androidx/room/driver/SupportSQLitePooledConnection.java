package androidx.room.driver;

import androidx.room.TransactionScope;
import androidx.room.Transactor;
import androidx.sqlite.SQLiteConnection;
import androidx.sqlite.db.SupportSQLiteDatabase;
import com.scanflow.datacapture.barinternal.androidx.room.coroutines.RawConnectionAccessor;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlin.jdk7.AutoCloseableKt;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.Boxing;
import kotlin.coroutines.jvm.internal.ContinuationImpl;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SupportSQLiteConnectionPool.android.kt */
/* JADX INFO: loaded from: classes.dex */
final class SupportSQLitePooledConnection implements Transactor, RawConnectionAccessor {
    private Transactor.SQLiteTransactionType currentTransactionType;
    private final SupportSQLiteConnection delegate;

    /* JADX INFO: compiled from: SupportSQLiteConnectionPool.android.kt */
    public /* synthetic */ class WhenMappings {
        public static final /* synthetic */ int[] $EnumSwitchMapping$0;

        static {
            int[] iArr = new int[Transactor.SQLiteTransactionType.values().length];
            try {
                iArr[Transactor.SQLiteTransactionType.DEFERRED.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                iArr[Transactor.SQLiteTransactionType.IMMEDIATE.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                iArr[Transactor.SQLiteTransactionType.EXCLUSIVE.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            $EnumSwitchMapping$0 = iArr;
        }
    }

    /* JADX INFO: renamed from: androidx.room.driver.SupportSQLitePooledConnection$transaction$1, reason: invalid class name */
    /* JADX INFO: compiled from: SupportSQLiteConnectionPool.android.kt */
    static final class AnonymousClass1 extends ContinuationImpl {
        Object L$0;
        Object L$1;
        int label;
        /* synthetic */ Object result;

        AnonymousClass1(Continuation continuation) {
            super(continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) {
            this.result = obj;
            this.label |= Integer.MIN_VALUE;
            return SupportSQLitePooledConnection.this.transaction(null, null, this);
        }
    }

    public SupportSQLitePooledConnection(SupportSQLiteConnection delegate) {
        Intrinsics.checkNotNullParameter(delegate, "delegate");
        this.delegate = delegate;
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.room.coroutines.RawConnectionAccessor
    public SQLiteConnection getRawConnection() {
        return this.delegate;
    }

    @Override // androidx.room.PooledConnection
    public Object usePrepared(String str, Function1 function1, Continuation continuation) throws Exception {
        SupportSQLiteStatement supportSQLiteStatementPrepare = this.delegate.prepare(str);
        try {
            Object objInvoke = function1.invoke(supportSQLiteStatementPrepare);
            AutoCloseableKt.closeFinally(supportSQLiteStatementPrepare, null);
            return objInvoke;
        } catch (Throwable th) {
            try {
                throw th;
            } catch (Throwable th2) {
                AutoCloseableKt.closeFinally(supportSQLiteStatementPrepare, th);
                throw th2;
            }
        }
    }

    @Override // androidx.room.Transactor
    public Object withTransaction(Transactor.SQLiteTransactionType sQLiteTransactionType, Function2 function2, Continuation continuation) {
        return transaction(sQLiteTransactionType, function2, continuation);
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX WARN: Code duplicated, block: B:45:0x00a2  */
    /* JADX WARN: Code duplicated, block: B:7:0x0013  */
    public final Object transaction(Transactor.SQLiteTransactionType sQLiteTransactionType, Function2 function2, Continuation continuation) throws Throwable {
        AnonymousClass1 anonymousClass1;
        Throwable th;
        SupportSQLiteDatabase supportSQLiteDatabase;
        SupportSQLitePooledConnection supportSQLitePooledConnection;
        if (continuation instanceof AnonymousClass1) {
            anonymousClass1 = (AnonymousClass1) continuation;
            int i = anonymousClass1.label;
            if ((i & Integer.MIN_VALUE) != 0) {
                anonymousClass1.label = i - Integer.MIN_VALUE;
            } else {
                anonymousClass1 = new AnonymousClass1(continuation);
            }
        } else {
            anonymousClass1 = new AnonymousClass1(continuation);
        }
        Object obj = anonymousClass1.result;
        Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        int i2 = anonymousClass1.label;
        if (i2 == 0) {
            ResultKt.throwOnFailure(obj);
            SupportSQLiteDatabase db = this.delegate.getDb();
            if (!db.inTransaction()) {
                this.currentTransactionType = sQLiteTransactionType;
            }
            int i3 = WhenMappings.$EnumSwitchMapping$0[sQLiteTransactionType.ordinal()];
            if (i3 == 1) {
                db.beginTransactionReadOnly();
            } else if (i3 == 2) {
                db.beginTransactionNonExclusive();
            } else {
                if (i3 != 3) {
                    throw new NoWhenBranchMatchedException();
                }
                db.beginTransaction();
            }
            try {
                SupportSQLiteTransactor supportSQLiteTransactor = new SupportSQLiteTransactor();
                anonymousClass1.L$0 = this;
                anonymousClass1.L$1 = db;
                anonymousClass1.label = 1;
                Object objInvoke = function2.invoke(supportSQLiteTransactor, anonymousClass1);
                if (objInvoke == coroutine_suspended) {
                    return coroutine_suspended;
                }
                obj = objInvoke;
                supportSQLiteDatabase = db;
                supportSQLitePooledConnection = this;
            } catch (Throwable th2) {
                th = th2;
                supportSQLiteDatabase = db;
                supportSQLitePooledConnection = this;
                supportSQLiteDatabase.endTransaction();
                if (!supportSQLiteDatabase.inTransaction()) {
                    supportSQLitePooledConnection.currentTransactionType = null;
                }
                throw th;
            }
        } else {
            if (i2 != 1) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            supportSQLiteDatabase = (SupportSQLiteDatabase) anonymousClass1.L$1;
            supportSQLitePooledConnection = (SupportSQLitePooledConnection) anonymousClass1.L$0;
            try {
                ResultKt.throwOnFailure(obj);
            } catch (Throwable th3) {
                th = th3;
                supportSQLiteDatabase.endTransaction();
                if (!supportSQLiteDatabase.inTransaction()) {
                    supportSQLitePooledConnection.currentTransactionType = null;
                }
                throw th;
            }
        }
        supportSQLiteDatabase.setTransactionSuccessful();
        supportSQLiteDatabase.endTransaction();
        if (!supportSQLiteDatabase.inTransaction()) {
            supportSQLitePooledConnection.currentTransactionType = null;
        }
        return obj;
    }

    @Override // androidx.room.Transactor
    public Object inTransaction(Continuation continuation) {
        return Boxing.boxBoolean(this.delegate.getDb().inTransaction());
    }

    /* JADX INFO: compiled from: SupportSQLiteConnectionPool.android.kt */
    private final class SupportSQLiteTransactor implements TransactionScope, RawConnectionAccessor {
        public SupportSQLiteTransactor() {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.room.coroutines.RawConnectionAccessor
        public SQLiteConnection getRawConnection() {
            return SupportSQLitePooledConnection.this.getRawConnection();
        }

        @Override // androidx.room.PooledConnection
        public Object usePrepared(String str, Function1 function1, Continuation continuation) {
            return SupportSQLitePooledConnection.this.usePrepared(str, function1, continuation);
        }
    }
}
