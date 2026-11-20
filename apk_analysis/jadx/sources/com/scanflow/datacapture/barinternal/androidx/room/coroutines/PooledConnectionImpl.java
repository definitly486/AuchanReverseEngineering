package com.scanflow.datacapture.barinternal.androidx.room.coroutines;

import android.database.SQLException;
import androidx.room.TransactionScope;
import androidx.room.Transactor;
import androidx.room.concurrent.ThreadLocal_jvmAndroidKt;
import androidx.sqlite.SQLite;
import androidx.sqlite.SQLiteConnection;
import androidx.sqlite.SQLiteStatement;
import com.scanflow.datacapture.barinternal.kotlin.ExceptionsKt;
import com.scanflow.datacapture.barinternal.kotlin.KotlinNothingValueException;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArrayDeque;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlin.jdk7.AutoCloseableKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.sync.Mutex;
import java.util.concurrent.atomic.AtomicBoolean;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.Boxing;
import kotlin.coroutines.jvm.internal.ContinuationImpl;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ConnectionPoolImpl.kt */
/* JADX INFO: loaded from: classes.dex */
final class PooledConnectionImpl implements Transactor, RawConnectionAccessor {
    private final AtomicBoolean _isRecycled;
    private final ConnectionWithLock delegate;
    private final boolean isReadOnly;
    private final ArrayDeque transactionStack;

    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
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

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.coroutines.PooledConnectionImpl$beginTransaction$1, reason: invalid class name */
    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    static final class AnonymousClass1 extends ContinuationImpl {
        Object L$0;
        Object L$1;
        Object L$2;
        int label;
        /* synthetic */ Object result;

        AnonymousClass1(Continuation continuation) {
            super(continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) {
            this.result = obj;
            this.label |= Integer.MIN_VALUE;
            return PooledConnectionImpl.this.beginTransaction(null, this);
        }
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.coroutines.PooledConnectionImpl$endTransaction$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    static final class C00741 extends ContinuationImpl {
        Object L$0;
        Object L$1;
        boolean Z$0;
        int label;
        /* synthetic */ Object result;

        C00741(Continuation continuation) {
            super(continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) {
            this.result = obj;
            this.label |= Integer.MIN_VALUE;
            return PooledConnectionImpl.this.endTransaction(false, this);
        }
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.coroutines.PooledConnectionImpl$transaction$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    static final class C00751 extends ContinuationImpl {
        int I$0;
        Object L$0;
        Object L$1;
        int label;
        /* synthetic */ Object result;

        C00751(Continuation continuation) {
            super(continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) {
            this.result = obj;
            this.label |= Integer.MIN_VALUE;
            return PooledConnectionImpl.this.transaction(null, null, this);
        }
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.coroutines.PooledConnectionImpl$usePrepared$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    static final class C00761 extends ContinuationImpl {
        Object L$0;
        Object L$1;
        Object L$2;
        Object L$3;
        int label;
        /* synthetic */ Object result;

        C00761(Continuation continuation) {
            super(continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) {
            this.result = obj;
            this.label |= Integer.MIN_VALUE;
            return PooledConnectionImpl.this.usePrepared(null, null, this);
        }
    }

    public PooledConnectionImpl(ConnectionWithLock delegate, boolean z) {
        Intrinsics.checkNotNullParameter(delegate, "delegate");
        this.delegate = delegate;
        this.isReadOnly = z;
        this.transactionStack = new ArrayDeque();
        this._isRecycled = new AtomicBoolean(false);
    }

    public final ConnectionWithLock getDelegate() {
        return this.delegate;
    }

    public final boolean isReadOnly() {
        return this.isReadOnly;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public final boolean isRecycled() {
        return this._isRecycled.get();
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.room.coroutines.RawConnectionAccessor
    public SQLiteConnection getRawConnection() {
        return this.delegate;
    }

    /* JADX WARN: Code duplicated, block: B:7:0x0013  */
    @Override // androidx.room.PooledConnection
    public Object usePrepared(String str, Function1 function1, Continuation continuation) throws Throwable {
        C00761 c00761;
        Mutex mutex;
        PooledConnectionImpl pooledConnectionImpl;
        if (continuation instanceof C00761) {
            c00761 = (C00761) continuation;
            int i = c00761.label;
            if ((i & Integer.MIN_VALUE) != 0) {
                c00761.label = i - Integer.MIN_VALUE;
            } else {
                c00761 = new C00761(continuation);
            }
        } else {
            c00761 = new C00761(continuation);
        }
        Object obj = c00761.result;
        Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        int i2 = c00761.label;
        if (i2 == 0) {
            ResultKt.throwOnFailure(obj);
            if (isRecycled()) {
                SQLite.throwSQLiteException(21, "Connection is recycled");
                throw new KotlinNothingValueException();
            }
            ConnectionElement connectionElement = (ConnectionElement) c00761.getContext().get(ConnectionElement.Key);
            if (connectionElement != null && connectionElement.getConnectionWrapper() == this) {
                mutex = this.delegate;
                c00761.L$0 = this;
                c00761.L$1 = str;
                c00761.L$2 = function1;
                c00761.L$3 = mutex;
                c00761.label = 1;
                if (mutex.lock(null, c00761) == coroutine_suspended) {
                    return coroutine_suspended;
                }
                pooledConnectionImpl = this;
            } else {
                SQLite.throwSQLiteException(21, "Attempted to use connection on a different coroutine");
                throw new KotlinNothingValueException();
            }
        } else {
            if (i2 != 1) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            Mutex mutex2 = (Mutex) c00761.L$3;
            function1 = (Function1) c00761.L$2;
            String str2 = (String) c00761.L$1;
            pooledConnectionImpl = (PooledConnectionImpl) c00761.L$0;
            ResultKt.throwOnFailure(obj);
            mutex = mutex2;
            str = str2;
        }
        try {
            StatementWrapper statementWrapper = new StatementWrapper(pooledConnectionImpl, pooledConnectionImpl.delegate.prepare(str));
            try {
                Object objInvoke = function1.invoke(statementWrapper);
                AutoCloseableKt.closeFinally(statementWrapper, null);
                mutex.unlock(null);
                return objInvoke;
            } catch (Throwable th) {
                try {
                    throw th;
                } catch (Throwable th2) {
                    AutoCloseableKt.closeFinally(statementWrapper, th);
                    throw th2;
                }
            }
        } catch (Throwable th3) {
            mutex.unlock(null);
            throw th3;
        }
    }

    public final void markRecycled() throws Exception {
        if (this._isRecycled.compareAndSet(false, true)) {
            try {
                SQLite.execSQL(this.delegate, "ROLLBACK TRANSACTION");
            } catch (SQLException unused) {
            }
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX WARN: Code duplicated, block: B:43:0x009a  */
    /* JADX WARN: Code duplicated, block: B:47:0x00a6 A[RETURN] */
    /* JADX WARN: Code duplicated, block: B:58:0x00bf  */
    /* JADX WARN: Code duplicated, block: B:60:0x00c3  */
    /* JADX WARN: Code duplicated, block: B:7:0x0013  */
    public final Object transaction(Transactor.SQLiteTransactionType sQLiteTransactionType, Function2 function2, Continuation continuation) throws Throwable {
        C00751 c00751;
        PooledConnectionImpl pooledConnectionImpl;
        PooledConnectionImpl pooledConnectionImpl2;
        int i;
        SQLException e;
        Throwable th;
        boolean z;
        if (continuation instanceof C00751) {
            c00751 = (C00751) continuation;
            int i2 = c00751.label;
            if ((i2 & Integer.MIN_VALUE) != 0) {
                c00751.label = i2 - Integer.MIN_VALUE;
            } else {
                c00751 = new C00751(continuation);
            }
        } else {
            c00751 = new C00751(continuation);
        }
        Object objInvoke = c00751.result;
        Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        int i3 = c00751.label;
        try {
            if (i3 == 0) {
                ResultKt.throwOnFailure(objInvoke);
                if (sQLiteTransactionType == null) {
                    sQLiteTransactionType = Transactor.SQLiteTransactionType.DEFERRED;
                }
                c00751.L$0 = this;
                c00751.L$1 = function2;
                c00751.label = 1;
                if (beginTransaction(sQLiteTransactionType, c00751) != coroutine_suspended) {
                    pooledConnectionImpl = this;
                }
                return coroutine_suspended;
            }
            if (i3 == 1) {
                function2 = (Function2) c00751.L$1;
                pooledConnectionImpl = (PooledConnectionImpl) c00751.L$0;
                ResultKt.throwOnFailure(objInvoke);
            } else {
                if (i3 != 2) {
                    if (i3 == 3 || i3 == 4) {
                        Object obj = c00751.L$0;
                        ResultKt.throwOnFailure(objInvoke);
                        return obj;
                    }
                    if (i3 != 5) {
                        throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                    }
                    th = (Throwable) c00751.L$1;
                    th = (Throwable) c00751.L$0;
                    try {
                        ResultKt.throwOnFailure(objInvoke);
                        throw th;
                    } catch (SQLException e2) {
                        e = e2;
                        if (th != null) {
                            throw e;
                        }
                        ExceptionsKt.addSuppressed(th, e);
                        throw th;
                    }
                }
                i = c00751.I$0;
                pooledConnectionImpl2 = (PooledConnectionImpl) c00751.L$0;
                try {
                    ResultKt.throwOnFailure(objInvoke);
                    z = i != 0;
                    c00751.L$0 = objInvoke;
                    c00751.label = 3;
                    if (pooledConnectionImpl2.endTransaction(z, c00751) != coroutine_suspended) {
                        return coroutine_suspended;
                    }
                    return objInvoke;
                } catch (Throwable th2) {
                    th = th2;
                    pooledConnectionImpl = pooledConnectionImpl2;
                    try {
                        throw th;
                    } catch (Throwable th3) {
                        try {
                            c00751.L$0 = th;
                            c00751.L$1 = th3;
                            c00751.label = 5;
                            if (pooledConnectionImpl.endTransaction(false, c00751) != coroutine_suspended) {
                                throw th3;
                            }
                        } catch (SQLException e3) {
                            e = e3;
                            th = th3;
                            if (th != null) {
                                throw e;
                            }
                            ExceptionsKt.addSuppressed(th, e);
                            throw th;
                        }
                    }
                }
            }
            TransactionImpl transactionImpl = pooledConnectionImpl.new TransactionImpl();
            c00751.L$0 = pooledConnectionImpl;
            c00751.L$1 = null;
            c00751.I$0 = 1;
            c00751.label = 2;
            objInvoke = function2.invoke(transactionImpl, c00751);
            if (objInvoke != coroutine_suspended) {
                pooledConnectionImpl2 = pooledConnectionImpl;
                i = 1;
                if (i != 0) {
                }
                c00751.L$0 = objInvoke;
                c00751.label = 3;
                if (pooledConnectionImpl2.endTransaction(z, c00751) != coroutine_suspended) {
                    return objInvoke;
                }
            }
            return coroutine_suspended;
        } catch (Throwable th4) {
            th = th4;
            throw th;
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX WARN: Code duplicated, block: B:7:0x0013  */
    public final Object beginTransaction(Transactor.SQLiteTransactionType sQLiteTransactionType, Continuation continuation) throws Throwable {
        AnonymousClass1 anonymousClass1;
        Mutex mutex;
        PooledConnectionImpl pooledConnectionImpl;
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
            mutex = this.delegate;
            anonymousClass1.L$0 = this;
            anonymousClass1.L$1 = sQLiteTransactionType;
            anonymousClass1.L$2 = mutex;
            anonymousClass1.label = 1;
            if (mutex.lock(null, anonymousClass1) == coroutine_suspended) {
                return coroutine_suspended;
            }
            pooledConnectionImpl = this;
        } else {
            if (i2 != 1) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            Mutex mutex2 = (Mutex) anonymousClass1.L$2;
            Transactor.SQLiteTransactionType sQLiteTransactionType2 = (Transactor.SQLiteTransactionType) anonymousClass1.L$1;
            pooledConnectionImpl = (PooledConnectionImpl) anonymousClass1.L$0;
            ResultKt.throwOnFailure(obj);
            mutex = mutex2;
            sQLiteTransactionType = sQLiteTransactionType2;
        }
        try {
            int size = pooledConnectionImpl.transactionStack.size();
            if (pooledConnectionImpl.transactionStack.isEmpty()) {
                int i3 = WhenMappings.$EnumSwitchMapping$0[sQLiteTransactionType.ordinal()];
                if (i3 == 1) {
                    SQLite.execSQL(pooledConnectionImpl.delegate, "BEGIN DEFERRED TRANSACTION");
                } else if (i3 == 2) {
                    SQLite.execSQL(pooledConnectionImpl.delegate, "BEGIN IMMEDIATE TRANSACTION");
                } else {
                    if (i3 != 3) {
                        throw new NoWhenBranchMatchedException();
                    }
                    SQLite.execSQL(pooledConnectionImpl.delegate, "BEGIN EXCLUSIVE TRANSACTION");
                }
            } else {
                SQLite.execSQL(pooledConnectionImpl.delegate, "SAVEPOINT '" + size + '\'');
            }
            pooledConnectionImpl.transactionStack.addLast(new TransactionItem(size, false));
            Unit unit = Unit.INSTANCE;
            mutex.unlock(null);
            return unit;
        } catch (Throwable th) {
            mutex.unlock(null);
            throw th;
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX WARN: Code duplicated, block: B:7:0x0013  */
    public final Object endTransaction(boolean z, Continuation continuation) throws Throwable {
        C00741 c00741;
        PooledConnectionImpl pooledConnectionImpl;
        Mutex mutex;
        if (continuation instanceof C00741) {
            c00741 = (C00741) continuation;
            int i = c00741.label;
            if ((i & Integer.MIN_VALUE) != 0) {
                c00741.label = i - Integer.MIN_VALUE;
            } else {
                c00741 = new C00741(continuation);
            }
        } else {
            c00741 = new C00741(continuation);
        }
        Object obj = c00741.result;
        Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        int i2 = c00741.label;
        if (i2 == 0) {
            ResultKt.throwOnFailure(obj);
            ConnectionWithLock connectionWithLock = this.delegate;
            c00741.L$0 = this;
            c00741.L$1 = connectionWithLock;
            c00741.Z$0 = z;
            c00741.label = 1;
            if (connectionWithLock.lock(null, c00741) == coroutine_suspended) {
                return coroutine_suspended;
            }
            pooledConnectionImpl = this;
            mutex = connectionWithLock;
        } else {
            if (i2 != 1) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            z = c00741.Z$0;
            mutex = (Mutex) c00741.L$1;
            pooledConnectionImpl = (PooledConnectionImpl) c00741.L$0;
            ResultKt.throwOnFailure(obj);
        }
        try {
            if (pooledConnectionImpl.transactionStack.isEmpty()) {
                throw new IllegalStateException("Not in a transaction");
            }
            TransactionItem transactionItem = (TransactionItem) CollectionsKt.removeLast(pooledConnectionImpl.transactionStack);
            if (z && !transactionItem.getShouldRollback()) {
                if (pooledConnectionImpl.transactionStack.isEmpty()) {
                    SQLite.execSQL(pooledConnectionImpl.delegate, "END TRANSACTION");
                } else {
                    SQLite.execSQL(pooledConnectionImpl.delegate, "RELEASE SAVEPOINT '" + transactionItem.getId() + '\'');
                }
            } else if (pooledConnectionImpl.transactionStack.isEmpty()) {
                SQLite.execSQL(pooledConnectionImpl.delegate, "ROLLBACK TRANSACTION");
            } else {
                SQLite.execSQL(pooledConnectionImpl.delegate, "ROLLBACK TRANSACTION TO SAVEPOINT '" + transactionItem.getId() + '\'');
            }
            Unit unit = Unit.INSTANCE;
            mutex.unlock(null);
            return unit;
        } catch (Throwable th) {
            mutex.unlock(null);
            throw th;
        }
    }

    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    private static final class TransactionItem {
        private final int id;
        private boolean shouldRollback;

        public TransactionItem(int i, boolean z) {
            this.id = i;
            this.shouldRollback = z;
        }

        public final int getId() {
            return this.id;
        }

        public final boolean getShouldRollback() {
            return this.shouldRollback;
        }
    }

    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    private final class TransactionImpl implements TransactionScope, RawConnectionAccessor {
        public TransactionImpl() {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.room.coroutines.RawConnectionAccessor
        public SQLiteConnection getRawConnection() {
            return PooledConnectionImpl.this.getRawConnection();
        }

        @Override // androidx.room.PooledConnection
        public Object usePrepared(String str, Function1 function1, Continuation continuation) {
            return PooledConnectionImpl.this.usePrepared(str, function1, continuation);
        }
    }

    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    private final class StatementWrapper implements SQLiteStatement {
        private final SQLiteStatement delegate;
        final /* synthetic */ PooledConnectionImpl this$0;
        private final long threadId;

        public StatementWrapper(PooledConnectionImpl pooledConnectionImpl, SQLiteStatement delegate) {
            Intrinsics.checkNotNullParameter(delegate, "delegate");
            this.this$0 = pooledConnectionImpl;
            this.delegate = delegate;
            this.threadId = ThreadLocal_jvmAndroidKt.currentThreadId();
        }

        @Override // androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindBlob */
        public void mo129bindBlob(int i, byte[] value) {
            Intrinsics.checkNotNullParameter(value, "value");
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                this.delegate.mo129bindBlob(i, value);
            } else {
                SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
                throw new KotlinNothingValueException();
            }
        }

        @Override // androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindDouble */
        public void mo130bindDouble(int i, double d) {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                this.delegate.mo130bindDouble(i, d);
            } else {
                SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
                throw new KotlinNothingValueException();
            }
        }

        @Override // androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindLong */
        public void mo131bindLong(int i, long j) {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                this.delegate.mo131bindLong(i, j);
            } else {
                SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
                throw new KotlinNothingValueException();
            }
        }

        @Override // androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindText */
        public void mo133bindText(int i, String value) {
            Intrinsics.checkNotNullParameter(value, "value");
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                this.delegate.mo133bindText(i, value);
            } else {
                SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
                throw new KotlinNothingValueException();
            }
        }

        @Override // androidx.sqlite.SQLiteStatement
        /* JADX INFO: renamed from: bindNull */
        public void mo132bindNull(int i) {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                this.delegate.mo132bindNull(i);
            } else {
                SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
                throw new KotlinNothingValueException();
            }
        }

        @Override // androidx.sqlite.SQLiteStatement
        public long getLong(int i) {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                return this.delegate.getLong(i);
            }
            SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.sqlite.SQLiteStatement
        public String getText(int i) {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                return this.delegate.getText(i);
            }
            SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.sqlite.SQLiteStatement
        public boolean isNull(int i) {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                return this.delegate.isNull(i);
            }
            SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.sqlite.SQLiteStatement
        public int getColumnCount() {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                return this.delegate.getColumnCount();
            }
            SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.sqlite.SQLiteStatement
        public String getColumnName(int i) {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                return this.delegate.getColumnName(i);
            }
            SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.sqlite.SQLiteStatement
        public boolean step() {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                return this.delegate.step();
            }
            SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
            throw new KotlinNothingValueException();
        }

        @Override // androidx.sqlite.SQLiteStatement
        public void reset() {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                this.delegate.reset();
            } else {
                SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
                throw new KotlinNothingValueException();
            }
        }

        @Override // androidx.sqlite.SQLiteStatement, java.lang.AutoCloseable
        public void close() {
            if (this.this$0.isRecycled()) {
                SQLite.throwSQLiteException(21, "Statement is recycled");
                throw new KotlinNothingValueException();
            }
            if (this.threadId == ThreadLocal_jvmAndroidKt.currentThreadId()) {
                this.delegate.close();
            } else {
                SQLite.throwSQLiteException(21, "Attempted to use statement on a different thread");
                throw new KotlinNothingValueException();
            }
        }
    }

    @Override // androidx.room.Transactor
    public Object withTransaction(Transactor.SQLiteTransactionType sQLiteTransactionType, Function2 function2, Continuation continuation) {
        if (isRecycled()) {
            SQLite.throwSQLiteException(21, "Connection is recycled");
            throw new KotlinNothingValueException();
        }
        ConnectionElement connectionElement = (ConnectionElement) continuation.getContext().get(ConnectionElement.Key);
        if (connectionElement != null && connectionElement.getConnectionWrapper() == this) {
            return transaction(sQLiteTransactionType, function2, continuation);
        }
        SQLite.throwSQLiteException(21, "Attempted to use connection on a different coroutine");
        throw new KotlinNothingValueException();
    }

    @Override // androidx.room.Transactor
    public Object inTransaction(Continuation continuation) {
        if (isRecycled()) {
            SQLite.throwSQLiteException(21, "Connection is recycled");
            throw new KotlinNothingValueException();
        }
        ConnectionElement connectionElement = (ConnectionElement) continuation.getContext().get(ConnectionElement.Key);
        if (connectionElement != null && connectionElement.getConnectionWrapper() == this) {
            return Boxing.boxBoolean(!this.transactionStack.isEmpty());
        }
        SQLite.throwSQLiteException(21, "Attempted to use connection on a different coroutine");
        throw new KotlinNothingValueException();
    }
}
