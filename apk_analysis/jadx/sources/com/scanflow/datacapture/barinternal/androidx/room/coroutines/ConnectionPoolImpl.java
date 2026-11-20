package com.scanflow.datacapture.barinternal.androidx.room.coroutines;

import android.database.SQLException;
import androidx.room.concurrent.ThreadLocal_jvmAndroidKt;
import androidx.sqlite.SQLite;
import androidx.sqlite.SQLiteConnection;
import androidx.sqlite.SQLiteDriver;
import com.scanflow.datacapture.barinternal.kotlin.ExceptionsKt;
import com.scanflow.datacapture.barinternal.kotlin.KotlinNothingValueException;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlin.time.Duration;
import com.scanflow.datacapture.barinternal.kotlin.time.DurationKt;
import com.scanflow.datacapture.barinternal.kotlin.time.DurationUnit;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt;
import java.util.concurrent.atomic.AtomicBoolean;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.jvm.internal.ContinuationImpl;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Ref$ObjectRef;
import kotlinx.coroutines.CoroutineScope;

/* JADX INFO: compiled from: ConnectionPoolImpl.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ConnectionPoolImpl implements ConnectionPool {
    private final AtomicBoolean _isClosed;
    private final SQLiteDriver driver;
    private final Pool readers;
    private final ThreadLocal threadLocal;
    private boolean throwOnTimeout;
    private long timeout;
    private final Pool writers;

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPoolImpl$useConnection$1, reason: invalid class name */
    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    static final class AnonymousClass1 extends ContinuationImpl {
        Object L$0;
        Object L$1;
        Object L$2;
        Object L$3;
        Object L$4;
        Object L$5;
        boolean Z$0;
        int label;
        /* synthetic */ Object result;

        AnonymousClass1(Continuation continuation) {
            super(continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) {
            this.result = obj;
            this.label |= Integer.MIN_VALUE;
            return ConnectionPoolImpl.this.useConnection(false, null, this);
        }
    }

    private final boolean isClosed() {
        return this._isClosed.get();
    }

    public ConnectionPoolImpl(final SQLiteDriver driver, final String fileName) {
        Intrinsics.checkNotNullParameter(driver, "driver");
        Intrinsics.checkNotNullParameter(fileName, "fileName");
        this.threadLocal = new ThreadLocal();
        this._isClosed = new AtomicBoolean(false);
        Duration.Companion companion = Duration.Companion;
        this.timeout = DurationKt.toDuration(30, DurationUnit.SECONDS);
        this.driver = driver;
        Pool pool = new Pool(1, new Function0() { // from class: com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPoolImpl$$ExternalSyntheticLambda2
            @Override // kotlin.jvm.functions.Function0
            public final Object invoke() {
                return driver.open(fileName);
            }
        });
        this.readers = pool;
        this.writers = pool;
    }

    public ConnectionPoolImpl(final SQLiteDriver driver, final String fileName, int i, int i2) {
        Intrinsics.checkNotNullParameter(driver, "driver");
        Intrinsics.checkNotNullParameter(fileName, "fileName");
        this.threadLocal = new ThreadLocal();
        this._isClosed = new AtomicBoolean(false);
        Duration.Companion companion = Duration.Companion;
        this.timeout = DurationKt.toDuration(30, DurationUnit.SECONDS);
        if (i <= 0) {
            throw new IllegalArgumentException("Maximum number of readers must be greater than 0");
        }
        if (i2 <= 0) {
            throw new IllegalArgumentException("Maximum number of writers must be greater than 0");
        }
        this.driver = driver;
        this.readers = new Pool(i, new Function0() { // from class: com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPoolImpl$$ExternalSyntheticLambda0
            @Override // kotlin.jvm.functions.Function0
            public final Object invoke() {
                return ConnectionPoolImpl._init_$lambda$4(driver, fileName);
            }
        });
        this.writers = new Pool(i2, new Function0() { // from class: com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPoolImpl$$ExternalSyntheticLambda1
            @Override // kotlin.jvm.functions.Function0
            public final Object invoke() {
                return driver.open(fileName);
            }
        });
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final SQLiteConnection _init_$lambda$4(SQLiteDriver sQLiteDriver, String str) throws Exception {
        SQLiteConnection sQLiteConnectionOpen = sQLiteDriver.open(str);
        SQLite.execSQL(sQLiteConnectionOpen, "PRAGMA query_only = 1");
        return sQLiteConnectionOpen;
    }

    /* JADX WARN: Code duplicated, block: B:67:0x0120  */
    /* JADX WARN: Code duplicated, block: B:70:0x012c A[Catch: all -> 0x0167, TRY_LEAVE, TryCatch #2 {all -> 0x0167, blocks: (B:63:0x0111, B:68:0x0121, B:70:0x012c, B:80:0x016c, B:81:0x0173, B:59:0x00ec), top: B:98:0x00ec }] */
    /* JADX WARN: Code duplicated, block: B:73:0x014c  */
    /* JADX WARN: Code duplicated, block: B:76:0x0155 A[Catch: all -> 0x0166, TRY_LEAVE, TryCatch #1 {all -> 0x0166, blocks: (B:74:0x014f, B:76:0x0155), top: B:96:0x014f }] */
    /* JADX WARN: Code duplicated, block: B:7:0x0013  */
    /* JADX WARN: Code duplicated, block: B:80:0x016c A[Catch: all -> 0x0167, TRY_ENTER, TryCatch #2 {all -> 0x0167, blocks: (B:63:0x0111, B:68:0x0121, B:70:0x012c, B:80:0x016c, B:81:0x0173, B:59:0x00ec), top: B:98:0x00ec }] */
    @Override // com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPool
    public Object useConnection(final boolean z, Function2 function2, Continuation continuation) throws Throwable {
        AnonymousClass1 anonymousClass1;
        Pool pool;
        Ref$ObjectRef ref$ObjectRef;
        Pool pool2;
        Throwable th;
        Ref$ObjectRef ref$ObjectRef2;
        CoroutineContext context;
        Object objM550acquireWithTimeoutKLykuaI;
        ConnectionPoolImpl connectionPoolImpl;
        Function2 function3;
        Ref$ObjectRef ref$ObjectRef3;
        Object obj;
        Object objWithContext;
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
        Object obj2 = anonymousClass1.result;
        Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        int i2 = anonymousClass1.label;
        boolean z2 = true;
        if (i2 != 0) {
            if (i2 == 1) {
                ResultKt.throwOnFailure(obj2);
                return obj2;
            }
            if (i2 == 2) {
                ResultKt.throwOnFailure(obj2);
                return obj2;
            }
            if (i2 == 3) {
                z = anonymousClass1.Z$0;
                ref$ObjectRef3 = (Ref$ObjectRef) anonymousClass1.L$5;
                CoroutineContext coroutineContext = (CoroutineContext) anonymousClass1.L$4;
                Ref$ObjectRef ref$ObjectRef4 = (Ref$ObjectRef) anonymousClass1.L$3;
                Pool pool3 = (Pool) anonymousClass1.L$2;
                function3 = (Function2) anonymousClass1.L$1;
                connectionPoolImpl = (ConnectionPoolImpl) anonymousClass1.L$0;
                try {
                    ResultKt.throwOnFailure(obj2);
                    objM550acquireWithTimeoutKLykuaI = obj2;
                    pool = pool3;
                    context = coroutineContext;
                    ref$ObjectRef = ref$ObjectRef4;
                    ConnectionWithLock connectionWithLockMarkAcquired = ((ConnectionWithLock) objM550acquireWithTimeoutKLykuaI).markAcquired(context);
                    if (connectionPoolImpl.readers != connectionPoolImpl.writers || !z) {
                        z2 = false;
                    }
                    ref$ObjectRef3.element = new PooledConnectionImpl(connectionWithLockMarkAcquired, z2);
                    obj = ref$ObjectRef.element;
                    if (obj != null) {
                        throw new IllegalArgumentException("Required value was null.");
                    }
                    CoroutineContext coroutineContextCreateConnectionContext = connectionPoolImpl.createConnectionContext((PooledConnectionImpl) obj);
                    AnonymousClass4 anonymousClass4 = new AnonymousClass4(function3, ref$ObjectRef, null);
                    anonymousClass1.L$0 = pool;
                    anonymousClass1.L$1 = ref$ObjectRef;
                    anonymousClass1.L$2 = null;
                    anonymousClass1.L$3 = null;
                    anonymousClass1.L$4 = null;
                    anonymousClass1.L$5 = null;
                    anonymousClass1.label = 4;
                    objWithContext = BuildersKt.withContext(coroutineContextCreateConnectionContext, anonymousClass4, anonymousClass1);
                    if (objWithContext != coroutine_suspended) {
                        pool2 = pool;
                        obj2 = objWithContext;
                        ref$ObjectRef2 = ref$ObjectRef;
                        pooledConnectionImpl = (PooledConnectionImpl) ref$ObjectRef2.element;
                        if (pooledConnectionImpl != null) {
                            pooledConnectionImpl.markRecycled();
                            pooledConnectionImpl.getDelegate().markReleased();
                            pool2.recycle(pooledConnectionImpl.getDelegate());
                        }
                        return obj2;
                    }
                    return coroutine_suspended;
                } catch (Throwable th2) {
                    th = th2;
                    ref$ObjectRef2 = ref$ObjectRef4;
                    pool2 = pool3;
                }
            } else {
                if (i2 != 4) {
                    throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                }
                ref$ObjectRef2 = (Ref$ObjectRef) anonymousClass1.L$1;
                pool2 = (Pool) anonymousClass1.L$0;
                try {
                    ResultKt.throwOnFailure(obj2);
                    try {
                        pooledConnectionImpl = (PooledConnectionImpl) ref$ObjectRef2.element;
                        if (pooledConnectionImpl != null) {
                            pooledConnectionImpl.markRecycled();
                            pooledConnectionImpl.getDelegate().markReleased();
                            pool2.recycle(pooledConnectionImpl.getDelegate());
                        }
                    } catch (Throwable unused) {
                    }
                    return obj2;
                } catch (Throwable th3) {
                    th = th3;
                }
            }
            try {
                throw th;
            } catch (Throwable th4) {
                try {
                    PooledConnectionImpl pooledConnectionImpl2 = (PooledConnectionImpl) ref$ObjectRef2.element;
                    if (pooledConnectionImpl2 != null) {
                        pooledConnectionImpl2.markRecycled();
                        pooledConnectionImpl2.getDelegate().markReleased();
                        pool2.recycle(pooledConnectionImpl2.getDelegate());
                    }
                } catch (Throwable th5) {
                    ExceptionsKt.addSuppressed(th, th5);
                }
                throw th4;
            }
        }
        ResultKt.throwOnFailure(obj2);
        if (isClosed()) {
            SQLite.throwSQLiteException(21, "Connection pool is closed");
            throw new KotlinNothingValueException();
        }
        PooledConnectionImpl connectionWrapper = (PooledConnectionImpl) this.threadLocal.get();
        if (connectionWrapper == null) {
            ConnectionElement connectionElement = (ConnectionElement) anonymousClass1.getContext().get(ConnectionElement.Key);
            connectionWrapper = connectionElement != null ? connectionElement.getConnectionWrapper() : null;
        }
        if (connectionWrapper != null) {
            if (!z && connectionWrapper.isReadOnly()) {
                SQLite.throwSQLiteException(1, "Cannot upgrade connection from reader to writer");
                throw new KotlinNothingValueException();
            }
            if (anonymousClass1.getContext().get(ConnectionElement.Key) == null) {
                CoroutineContext coroutineContextCreateConnectionContext2 = createConnectionContext(connectionWrapper);
                AnonymousClass2 anonymousClass2 = new AnonymousClass2(function2, connectionWrapper, null);
                anonymousClass1.label = 1;
                Object objWithContext2 = BuildersKt.withContext(coroutineContextCreateConnectionContext2, anonymousClass2, anonymousClass1);
                if (objWithContext2 != coroutine_suspended) {
                    return objWithContext2;
                }
            } else {
                anonymousClass1.label = 2;
                Object objInvoke = function2.invoke(connectionWrapper, anonymousClass1);
                if (objInvoke != coroutine_suspended) {
                    return objInvoke;
                }
            }
        } else {
            if (z) {
                pool = this.readers;
            } else {
                pool = this.writers;
            }
            ref$ObjectRef = new Ref$ObjectRef();
            try {
                context = anonymousClass1.getContext();
                long j = this.timeout;
                Function0 function0 = new Function0() { // from class: com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPoolImpl$$ExternalSyntheticLambda3
                    @Override // kotlin.jvm.functions.Function0
                    public final Object invoke() {
                        return ConnectionPoolImpl.useConnection$lambda$6(this.f$0, z);
                    }
                };
                anonymousClass1.L$0 = this;
                anonymousClass1.L$1 = function2;
                anonymousClass1.L$2 = pool;
                anonymousClass1.L$3 = ref$ObjectRef;
                anonymousClass1.L$4 = context;
                anonymousClass1.L$5 = ref$ObjectRef;
                anonymousClass1.Z$0 = z;
                anonymousClass1.label = 3;
                objM550acquireWithTimeoutKLykuaI = pool.m550acquireWithTimeoutKLykuaI(j, function0, anonymousClass1);
                if (objM550acquireWithTimeoutKLykuaI != coroutine_suspended) {
                    connectionPoolImpl = this;
                    function3 = function2;
                    ref$ObjectRef3 = ref$ObjectRef;
                    ConnectionWithLock connectionWithLockMarkAcquired2 = ((ConnectionWithLock) objM550acquireWithTimeoutKLykuaI).markAcquired(context);
                    if (connectionPoolImpl.readers != connectionPoolImpl.writers) {
                        z2 = false;
                    } else {
                        z2 = false;
                    }
                    ref$ObjectRef3.element = new PooledConnectionImpl(connectionWithLockMarkAcquired2, z2);
                    obj = ref$ObjectRef.element;
                    if (obj != null) {
                        throw new IllegalArgumentException("Required value was null.");
                    }
                    CoroutineContext coroutineContextCreateConnectionContext3 = connectionPoolImpl.createConnectionContext((PooledConnectionImpl) obj);
                    AnonymousClass4 anonymousClass5 = new AnonymousClass4(function3, ref$ObjectRef, null);
                    anonymousClass1.L$0 = pool;
                    anonymousClass1.L$1 = ref$ObjectRef;
                    anonymousClass1.L$2 = null;
                    anonymousClass1.L$3 = null;
                    anonymousClass1.L$4 = null;
                    anonymousClass1.L$5 = null;
                    anonymousClass1.label = 4;
                    objWithContext = BuildersKt.withContext(coroutineContextCreateConnectionContext3, anonymousClass5, anonymousClass1);
                    if (objWithContext != coroutine_suspended) {
                        pool2 = pool;
                        obj2 = objWithContext;
                        ref$ObjectRef2 = ref$ObjectRef;
                        pooledConnectionImpl = (PooledConnectionImpl) ref$ObjectRef2.element;
                        if (pooledConnectionImpl != null) {
                            pooledConnectionImpl.markRecycled();
                            pooledConnectionImpl.getDelegate().markReleased();
                            pool2.recycle(pooledConnectionImpl.getDelegate());
                        }
                        return obj2;
                    }
                }
            } catch (Throwable th6) {
                pool2 = pool;
                th = th6;
                ref$ObjectRef2 = ref$ObjectRef;
            }
        }
        return coroutine_suspended;
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPoolImpl$useConnection$2, reason: invalid class name */
    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    static final class AnonymousClass2 extends SuspendLambda implements Function2 {
        final /* synthetic */ Function2 $block;
        final /* synthetic */ PooledConnectionImpl $confinedConnection;
        int label;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        AnonymousClass2(Function2 function2, PooledConnectionImpl pooledConnectionImpl, Continuation continuation) {
            super(2, continuation);
            this.$block = function2;
            this.$confinedConnection = pooledConnectionImpl;
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return new AnonymousClass2(this.$block, this.$confinedConnection, continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((AnonymousClass2) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
            int i = this.label;
            if (i != 0) {
                if (i != 1) {
                    throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                }
                ResultKt.throwOnFailure(obj);
                return obj;
            }
            ResultKt.throwOnFailure(obj);
            Function2 function2 = this.$block;
            PooledConnectionImpl pooledConnectionImpl = this.$confinedConnection;
            this.label = 1;
            Object objInvoke = function2.invoke(pooledConnectionImpl, this);
            return objInvoke == coroutine_suspended ? coroutine_suspended : objInvoke;
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit useConnection$lambda$6(ConnectionPoolImpl connectionPoolImpl, boolean z) {
        connectionPoolImpl.onTimeout(z);
        return Unit.INSTANCE;
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPoolImpl$useConnection$4, reason: invalid class name */
    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    static final class AnonymousClass4 extends SuspendLambda implements Function2 {
        final /* synthetic */ Function2 $block;
        final /* synthetic */ Ref$ObjectRef $connection;
        int label;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        AnonymousClass4(Function2 function2, Ref$ObjectRef ref$ObjectRef, Continuation continuation) {
            super(2, continuation);
            this.$block = function2;
            this.$connection = ref$ObjectRef;
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return new AnonymousClass4(this.$block, this.$connection, continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((AnonymousClass4) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
            int i = this.label;
            if (i != 0) {
                if (i != 1) {
                    throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                }
                ResultKt.throwOnFailure(obj);
                return obj;
            }
            ResultKt.throwOnFailure(obj);
            Function2 function2 = this.$block;
            Object obj2 = this.$connection.element;
            this.label = 1;
            Object objInvoke = function2.invoke(obj2, this);
            return objInvoke == coroutine_suspended ? coroutine_suspended : objInvoke;
        }
    }

    private final CoroutineContext createConnectionContext(PooledConnectionImpl pooledConnectionImpl) {
        return new ConnectionElement(pooledConnectionImpl).plus(ThreadLocal_jvmAndroidKt.asContextElement(this.threadLocal, pooledConnectionImpl));
    }

    private final void onTimeout(boolean z) {
        String str = z ? "reader" : "writer";
        StringBuilder sb = new StringBuilder();
        sb.append("Timed out attempting to acquire a " + str + " connection.");
        sb.append('\n');
        sb.append('\n');
        sb.append("Writer pool:");
        sb.append('\n');
        this.writers.dump(sb);
        sb.append("Reader pool:");
        sb.append('\n');
        this.readers.dump(sb);
        try {
            SQLite.throwSQLiteException(5, sb.toString());
            throw new KotlinNothingValueException();
        } catch (SQLException e) {
            if (this.throwOnTimeout) {
                throw e;
            }
            e.printStackTrace();
        }
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionPool, java.lang.AutoCloseable
    public void close() {
        if (this._isClosed.compareAndSet(false, true)) {
            this.readers.close();
            this.writers.close();
        }
    }
}
