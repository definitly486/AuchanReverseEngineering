package com.scanflow.datacapture.barinternal.androidx.room.coroutines;

import androidx.collection.CircularArray;
import androidx.sqlite.SQLite;
import androidx.sqlite.SQLiteConnection;
import com.scanflow.datacapture.barinternal.kotlin.KotlinNothingValueException;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.sync.Semaphore;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.sync.SemaphoreKt;
import java.util.List;
import java.util.concurrent.locks.ReentrantLock;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.ContinuationImpl;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ConnectionPoolImpl.kt */
/* JADX INFO: loaded from: classes.dex */
final class Pool {
    private final CircularArray availableConnections;
    private final int capacity;
    private final Function0 connectionFactory;
    private final Semaphore connectionPermits;
    private final ConnectionWithLock[] connections;
    private boolean isClosed;
    private final ReentrantLock lock;
    private int size;

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool$acquire$1, reason: invalid class name */
    /* JADX INFO: compiled from: ConnectionPoolImpl.kt */
    static final class AnonymousClass1 extends ContinuationImpl {
        Object L$0;
        int label;
        /* synthetic */ Object result;

        AnonymousClass1(Continuation continuation) {
            super(continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) {
            this.result = obj;
            this.label |= Integer.MIN_VALUE;
            return Pool.this.acquire(this);
        }
    }

    public Pool(int i, Function0 connectionFactory) {
        Intrinsics.checkNotNullParameter(connectionFactory, "connectionFactory");
        this.capacity = i;
        this.connectionFactory = connectionFactory;
        this.lock = new ReentrantLock();
        this.connections = new ConnectionWithLock[i];
        this.connectionPermits = SemaphoreKt.Semaphore$default(i, 0, 2, null);
        this.availableConnections = new CircularArray(i);
    }

    /* JADX WARN: Code duplicated, block: B:22:0x0060 A[RETURN] */
    /* JADX WARN: Code duplicated, block: B:23:0x0061  */
    /* JADX WARN: Code duplicated, block: B:30:0x0076 A[Catch: all -> 0x007a, TryCatch #2 {all -> 0x007a, blocks: (B:28:0x0072, B:30:0x0076, B:34:0x007e, B:38:0x0085), top: B:47:0x0072 }] */
    /* JADX WARN: Code duplicated, block: B:33:0x007c  */
    /* JADX WARN: Code duplicated, block: B:34:0x007e A[Catch: all -> 0x007a, TryCatch #2 {all -> 0x007a, blocks: (B:28:0x0072, B:30:0x0076, B:34:0x007e, B:38:0x0085), top: B:47:0x0072 }] */
    /* JADX WARN: Code duplicated, block: B:36:0x0082 A[RETURN] */
    /* JADX WARN: Code duplicated, block: B:38:0x0085 A[Catch: all -> 0x007a, TRY_LEAVE, TryCatch #2 {all -> 0x007a, blocks: (B:28:0x0072, B:30:0x0076, B:34:0x007e, B:38:0x0085), top: B:47:0x0072 }] */
    /* JADX WARN: Code duplicated, block: B:7:0x0013  */
    /* JADX WARN: Unsupported multi-entry loop pattern (BACK_EDGE: B:23:0x0061 -> B:24:0x0063). Please report as a decompilation issue!!! */
    /*  JADX ERROR: JadxOverflowException in pass: RegionMakerVisitor
        jadx.core.utils.exceptions.JadxOverflowException: Regions stack size limit reached
        	at jadx.core.utils.ErrorsCounter.addError(ErrorsCounter.java:59)
        	at jadx.core.utils.ErrorsCounter.error(ErrorsCounter.java:31)
        	at jadx.core.dex.attributes.nodes.NotificationAttrNode.addError(NotificationAttrNode.java:19)
        */
    /* JADX INFO: renamed from: acquireWithTimeout-KLykuaI, reason: not valid java name */
    public final java.lang.Object m550acquireWithTimeoutKLykuaI(long r9, kotlin.jvm.functions.Function0 r11, kotlin.coroutines.Continuation r12) {
        /*
            r8 = this;
            boolean r0 = r12 instanceof com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool$acquireWithTimeout$1
            if (r0 == 0) goto L13
            r0 = r12
            com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool$acquireWithTimeout$1 r0 = (com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool$acquireWithTimeout$1) r0
            int r1 = r0.label
            r2 = -2147483648(0xffffffff80000000, float:-0.0)
            r3 = r1 & r2
            if (r3 == 0) goto L13
            int r1 = r1 - r2
            r0.label = r1
            goto L18
        L13:
            com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool$acquireWithTimeout$1 r0 = new com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool$acquireWithTimeout$1
            r0.<init>(r8, r12)
        L18:
            java.lang.Object r12 = r0.result
            java.lang.Object r1 = com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt.getCOROUTINE_SUSPENDED()
            int r2 = r0.label
            r3 = 1
            r4 = 0
            if (r2 == 0) goto L42
            if (r2 != r3) goto L3a
            long r9 = r0.J$0
            java.lang.Object r11 = r0.L$2
            kotlin.jvm.internal.Ref$ObjectRef r11 = (kotlin.jvm.internal.Ref$ObjectRef) r11
            java.lang.Object r2 = r0.L$1
            kotlin.jvm.functions.Function0 r2 = (kotlin.jvm.functions.Function0) r2
            java.lang.Object r5 = r0.L$0
            com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool r5 = (com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool) r5
            com.scanflow.datacapture.barinternal.kotlin.ResultKt.throwOnFailure(r12)     // Catch: java.lang.Throwable -> L38
            goto L63
        L38:
            r12 = move-exception
            goto L6d
        L3a:
            java.lang.IllegalStateException r9 = new java.lang.IllegalStateException
            java.lang.String r10 = "call to 'resume' before 'invoke' with coroutine"
            r9.<init>(r10)
            throw r9
        L42:
            com.scanflow.datacapture.barinternal.kotlin.ResultKt.throwOnFailure(r12)
            r5 = r8
        L46:
            kotlin.jvm.internal.Ref$ObjectRef r12 = new kotlin.jvm.internal.Ref$ObjectRef
            r12.<init>()
            com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool$acquireWithTimeout$2 r2 = new com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool$acquireWithTimeout$2     // Catch: java.lang.Throwable -> L68
            r2.<init>(r12, r5, r4)     // Catch: java.lang.Throwable -> L68
            r0.L$0 = r5     // Catch: java.lang.Throwable -> L68
            r0.L$1 = r11     // Catch: java.lang.Throwable -> L68
            r0.L$2 = r12     // Catch: java.lang.Throwable -> L68
            r0.J$0 = r9     // Catch: java.lang.Throwable -> L68
            r0.label = r3     // Catch: java.lang.Throwable -> L68
            java.lang.Object r2 = com.scanflow.datacapture.barinternal.kotlinx.coroutines.TimeoutKt.m829withTimeoutKLykuaI(r9, r2, r0)     // Catch: java.lang.Throwable -> L68
            if (r2 != r1) goto L61
            return r1
        L61:
            r2 = r11
            r11 = r12
        L63:
            r12 = r11
            r11 = r2
            r2 = r0
            r0 = r4
            goto L72
        L68:
            r2 = move-exception
            r7 = r2
            r2 = r11
            r11 = r12
            r12 = r7
        L6d:
            r7 = r12
            r12 = r11
            r11 = r2
            r2 = r0
            r0 = r7
        L72:
            boolean r6 = r0 instanceof com.scanflow.datacapture.barinternal.kotlinx.coroutines.TimeoutCancellationException     // Catch: java.lang.Throwable -> L7a
            if (r6 == 0) goto L7c
            r11.invoke()     // Catch: java.lang.Throwable -> L7a
            goto L83
        L7a:
            r9 = move-exception
            goto L86
        L7c:
            if (r0 != 0) goto L85
            java.lang.Object r12 = r12.element     // Catch: java.lang.Throwable -> L7a
            if (r12 == 0) goto L83
            return r12
        L83:
            r0 = r2
            goto L46
        L85:
            throw r0     // Catch: java.lang.Throwable -> L7a
        L86:
            java.lang.Object r10 = r12.element
            com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionWithLock r10 = (com.scanflow.datacapture.barinternal.androidx.room.coroutines.ConnectionWithLock) r10
            if (r10 == 0) goto L8f
            r5.recycle(r10)
        L8f:
            throw r9
        */
        throw new UnsupportedOperationException("Method not decompiled: com.scanflow.datacapture.barinternal.androidx.room.coroutines.Pool.m550acquireWithTimeoutKLykuaI(long, kotlin.jvm.functions.Function0, kotlin.coroutines.Continuation):java.lang.Object");
    }

    /* JADX WARN: Code duplicated, block: B:7:0x0013  */
    public final Object acquire(Continuation continuation) throws Throwable {
        AnonymousClass1 anonymousClass1;
        Pool pool;
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
            Semaphore semaphore = this.connectionPermits;
            anonymousClass1.L$0 = this;
            anonymousClass1.label = 1;
            if (semaphore.acquire(anonymousClass1) == coroutine_suspended) {
                return coroutine_suspended;
            }
            pool = this;
        } else {
            if (i2 != 1) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            pool = (Pool) anonymousClass1.L$0;
            ResultKt.throwOnFailure(obj);
        }
        try {
            ReentrantLock reentrantLock = pool.lock;
            reentrantLock.lock();
            try {
                if (pool.isClosed) {
                    SQLite.throwSQLiteException(21, "Connection pool is closed");
                    throw new KotlinNothingValueException();
                }
                if (pool.availableConnections.isEmpty()) {
                    pool.tryOpenNewConnectionLocked();
                }
                ConnectionWithLock connectionWithLock = (ConnectionWithLock) pool.availableConnections.popFirst();
                reentrantLock.unlock();
                return connectionWithLock;
            } catch (Throwable th) {
                reentrantLock.unlock();
                throw th;
            }
        } catch (Throwable th2) {
            pool.connectionPermits.release();
            throw th2;
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    private final void tryOpenNewConnectionLocked() {
        if (this.size >= this.capacity) {
            return;
        }
        ConnectionWithLock connectionWithLock = new ConnectionWithLock((SQLiteConnection) this.connectionFactory.invoke(), null, 2, 0 == true ? 1 : 0);
        ConnectionWithLock[] connectionWithLockArr = this.connections;
        int i = this.size;
        this.size = i + 1;
        connectionWithLockArr[i] = connectionWithLock;
        this.availableConnections.addLast(connectionWithLock);
    }

    public final void recycle(ConnectionWithLock connection) {
        Intrinsics.checkNotNullParameter(connection, "connection");
        ReentrantLock reentrantLock = this.lock;
        reentrantLock.lock();
        try {
            this.availableConnections.addLast(connection);
            Unit unit = Unit.INSTANCE;
            reentrantLock.unlock();
            this.connectionPermits.release();
        } catch (Throwable th) {
            reentrantLock.unlock();
            throw th;
        }
    }

    public final void close() {
        ReentrantLock reentrantLock = this.lock;
        reentrantLock.lock();
        try {
            this.isClosed = true;
            for (ConnectionWithLock connectionWithLock : this.connections) {
                if (connectionWithLock != null) {
                    connectionWithLock.close();
                }
            }
            Unit unit = Unit.INSTANCE;
        } finally {
            reentrantLock.unlock();
        }
    }

    public final void dump(StringBuilder builder) {
        Intrinsics.checkNotNullParameter(builder, "builder");
        ReentrantLock reentrantLock = this.lock;
        reentrantLock.lock();
        try {
            List listCreateListBuilder = CollectionsKt.createListBuilder();
            int size = this.availableConnections.size();
            for (int i = 0; i < size; i++) {
                listCreateListBuilder.add(this.availableConnections.get(i));
            }
            List listBuild = CollectionsKt.build(listCreateListBuilder);
            builder.append('\t' + super.toString() + " (");
            builder.append("capacity=" + this.capacity + ", ");
            builder.append("permits=" + this.connectionPermits.getAvailablePermits() + ", ");
            builder.append("queue=(size=" + listBuild.size() + ")[" + CollectionsKt.joinToString$default(listBuild, null, null, null, 0, null, null, 63, null) + "], ");
            builder.append(")");
            builder.append('\n');
            ConnectionWithLock[] connectionWithLockArr = this.connections;
            int length = connectionWithLockArr.length;
            int i2 = 0;
            for (int i3 = 0; i3 < length; i3++) {
                ConnectionWithLock connectionWithLock = connectionWithLockArr[i3];
                i2++;
                StringBuilder sb = new StringBuilder();
                sb.append("\t\t[");
                sb.append(i2);
                sb.append("] - ");
                sb.append(connectionWithLock != null ? connectionWithLock.toString() : null);
                builder.append(sb.toString());
                builder.append('\n');
                if (connectionWithLock != null) {
                    connectionWithLock.dump(builder);
                }
            }
            Unit unit = Unit.INSTANCE;
        } finally {
            reentrantLock.unlock();
        }
    }
}
