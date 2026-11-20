package androidx.room;

import android.os.CancellationSignal;
import androidx.room.coroutines.FlowUtil;
import androidx.room.util.DBUtil;
import androidx.sqlite.SQLiteConnection;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CancellableContinuationImpl;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job;
import java.util.concurrent.Callable;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.jvm.internal.DebugProbesKt;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.coroutines.flow.Flow;

/* JADX INFO: compiled from: CoroutinesRoom.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class CoroutinesRoom {
    public static final Companion Companion = new Companion(null);

    public static final <R> Flow<R> createFlow(RoomDatabase roomDatabase, boolean z, String[] strArr, Callable<R> callable) {
        return Companion.createFlow(roomDatabase, z, strArr, callable);
    }

    public static final <R> Object execute(RoomDatabase roomDatabase, boolean z, CancellationSignal cancellationSignal, Callable<R> callable, Continuation<? super R> continuation) {
        return Companion.execute(roomDatabase, z, cancellationSignal, callable, continuation);
    }

    public static final <R> Object execute(RoomDatabase roomDatabase, boolean z, Callable<R> callable, Continuation<? super R> continuation) {
        return Companion.execute(roomDatabase, z, callable, continuation);
    }

    private CoroutinesRoom() {
    }

    /* JADX INFO: compiled from: CoroutinesRoom.android.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        /* JADX WARN: Code duplicated, block: B:7:0x0013  */
        public final <R> Object execute(RoomDatabase roomDatabase, boolean z, Callable<R> callable, Continuation<? super R> continuation) throws Throwable {
            CoroutinesRoom$Companion$execute$1 coroutinesRoom$Companion$execute$1;
            if (continuation instanceof CoroutinesRoom$Companion$execute$1) {
                coroutinesRoom$Companion$execute$1 = (CoroutinesRoom$Companion$execute$1) continuation;
                int i = coroutinesRoom$Companion$execute$1.label;
                if ((i & Integer.MIN_VALUE) != 0) {
                    coroutinesRoom$Companion$execute$1.label = i - Integer.MIN_VALUE;
                } else {
                    coroutinesRoom$Companion$execute$1 = new CoroutinesRoom$Companion$execute$1(this, continuation);
                }
            } else {
                coroutinesRoom$Companion$execute$1 = new CoroutinesRoom$Companion$execute$1(this, continuation);
            }
            Object coroutineContext = coroutinesRoom$Companion$execute$1.result;
            Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
            int i2 = coroutinesRoom$Companion$execute$1.label;
            if (i2 == 0) {
                ResultKt.throwOnFailure(coroutineContext);
                if (roomDatabase.isOpenInternal() && roomDatabase.inTransaction()) {
                    return callable.call();
                }
                coroutinesRoom$Companion$execute$1.L$0 = callable;
                coroutinesRoom$Companion$execute$1.label = 1;
                coroutineContext = DBUtil.getCoroutineContext(roomDatabase, z, coroutinesRoom$Companion$execute$1);
                if (coroutineContext != coroutine_suspended) {
                }
            }
            if (i2 != 1) {
                if (i2 != 2) {
                    throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                }
                ResultKt.throwOnFailure(coroutineContext);
                return coroutineContext;
            }
            callable = (Callable) coroutinesRoom$Companion$execute$1.L$0;
            ResultKt.throwOnFailure(coroutineContext);
            CoroutinesRoom$Companion$execute$2 coroutinesRoom$Companion$execute$2 = new CoroutinesRoom$Companion$execute$2(callable, null);
            coroutinesRoom$Companion$execute$1.L$0 = null;
            coroutinesRoom$Companion$execute$1.label = 2;
            Object objWithContext = BuildersKt.withContext((CoroutineContext) coroutineContext, coroutinesRoom$Companion$execute$2, coroutinesRoom$Companion$execute$1);
            return objWithContext == coroutine_suspended ? coroutine_suspended : objWithContext;
        }

        /* JADX WARN: Code duplicated, block: B:7:0x0019  */
        public final <R> Object execute(RoomDatabase roomDatabase, boolean z, CancellationSignal cancellationSignal, Callable<R> callable, Continuation<? super R> continuation) throws Throwable {
            CoroutinesRoom$Companion$execute$3 coroutinesRoom$Companion$execute$3;
            final CancellationSignal cancellationSignal2;
            Callable<R> callable2;
            Object coroutineContext;
            RoomDatabase roomDatabase2 = roomDatabase;
            if (continuation instanceof CoroutinesRoom$Companion$execute$3) {
                coroutinesRoom$Companion$execute$3 = (CoroutinesRoom$Companion$execute$3) continuation;
                int i = coroutinesRoom$Companion$execute$3.label;
                if ((i & Integer.MIN_VALUE) != 0) {
                    coroutinesRoom$Companion$execute$3.label = i - Integer.MIN_VALUE;
                } else {
                    coroutinesRoom$Companion$execute$3 = new CoroutinesRoom$Companion$execute$3(this, continuation);
                }
            } else {
                coroutinesRoom$Companion$execute$3 = new CoroutinesRoom$Companion$execute$3(this, continuation);
            }
            Object obj = coroutinesRoom$Companion$execute$3.result;
            Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
            int i2 = coroutinesRoom$Companion$execute$3.label;
            if (i2 == 0) {
                ResultKt.throwOnFailure(obj);
                if (roomDatabase2.isOpenInternal() && roomDatabase2.inTransaction()) {
                    return callable.call();
                }
                coroutinesRoom$Companion$execute$3.L$0 = roomDatabase2;
                cancellationSignal2 = cancellationSignal;
                coroutinesRoom$Companion$execute$3.L$1 = cancellationSignal2;
                callable2 = callable;
                coroutinesRoom$Companion$execute$3.L$2 = callable2;
                coroutinesRoom$Companion$execute$3.label = 1;
                coroutineContext = DBUtil.getCoroutineContext(roomDatabase2, z, coroutinesRoom$Companion$execute$3);
                if (coroutineContext != coroutine_suspended) {
                }
            }
            if (i2 != 1) {
                if (i2 != 2) {
                    throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                }
                ResultKt.throwOnFailure(obj);
                return obj;
            }
            Callable<R> callable3 = (Callable) coroutinesRoom$Companion$execute$3.L$2;
            CancellationSignal cancellationSignal3 = (CancellationSignal) coroutinesRoom$Companion$execute$3.L$1;
            RoomDatabase roomDatabase3 = (RoomDatabase) coroutinesRoom$Companion$execute$3.L$0;
            ResultKt.throwOnFailure(obj);
            callable2 = callable3;
            roomDatabase2 = roomDatabase3;
            coroutineContext = obj;
            cancellationSignal2 = cancellationSignal3;
            CoroutineContext coroutineContext2 = (CoroutineContext) coroutineContext;
            coroutinesRoom$Companion$execute$3.L$0 = roomDatabase2;
            coroutinesRoom$Companion$execute$3.L$1 = cancellationSignal2;
            coroutinesRoom$Companion$execute$3.L$2 = callable2;
            coroutinesRoom$Companion$execute$3.L$3 = coroutineContext2;
            coroutinesRoom$Companion$execute$3.label = 2;
            CancellableContinuationImpl cancellableContinuationImpl = new CancellableContinuationImpl(IntrinsicsKt.intercepted(coroutinesRoom$Companion$execute$3), 1);
            cancellableContinuationImpl.initCancellability();
            final Job jobLaunch$default = BuildersKt__Builders_commonKt.launch$default(roomDatabase2.getCoroutineScope(), coroutineContext2, null, new CoroutinesRoom$Companion$execute$4$job$1(callable2, cancellableContinuationImpl, null), 2, null);
            cancellableContinuationImpl.invokeOnCancellation(new Function1() { // from class: androidx.room.CoroutinesRoom$Companion$execute$4$1
                @Override // kotlin.jvm.functions.Function1
                public /* bridge */ /* synthetic */ Object invoke(Object obj2) {
                    invoke((Throwable) obj2);
                    return Unit.INSTANCE;
                }

                public final void invoke(Throwable th) {
                    CancellationSignal cancellationSignal4 = cancellationSignal2;
                    if (cancellationSignal4 != null) {
                        cancellationSignal4.cancel();
                    }
                    Job.DefaultImpls.cancel$default(jobLaunch$default, null, 1, null);
                }
            });
            Object result = cancellableContinuationImpl.getResult();
            if (result == IntrinsicsKt.getCOROUTINE_SUSPENDED()) {
                DebugProbesKt.probeCoroutineSuspended(coroutinesRoom$Companion$execute$3);
            }
            return result == coroutine_suspended ? coroutine_suspended : result;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public static final Object createFlow$lambda$1(Callable callable, SQLiteConnection it) {
            Intrinsics.checkNotNullParameter(it, "it");
            return callable.call();
        }

        public final <R> Flow<R> createFlow(RoomDatabase db, boolean z, String[] tableNames, final Callable<R> callable) {
            Intrinsics.checkNotNullParameter(db, "db");
            Intrinsics.checkNotNullParameter(tableNames, "tableNames");
            Intrinsics.checkNotNullParameter(callable, "callable");
            return FlowUtil.createFlow(db, z, tableNames, new Function1() { // from class: androidx.room.CoroutinesRoom$Companion$$ExternalSyntheticLambda0
                @Override // kotlin.jvm.functions.Function1
                public final Object invoke(Object obj) {
                    return CoroutinesRoom.Companion.createFlow$lambda$1(callable, (SQLiteConnection) obj);
                }
            });
        }
    }
}
