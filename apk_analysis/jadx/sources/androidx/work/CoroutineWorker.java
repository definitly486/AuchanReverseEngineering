package androidx.work;

import android.content.Context;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Dispatchers;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobKt__JobKt;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.coroutines.CoroutineScope;

/* JADX INFO: compiled from: CoroutineWorker.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class CoroutineWorker extends ListenableWorker {
    private final CoroutineDispatcher coroutineContext;
    private final WorkerParameters params;

    public static /* synthetic */ void getCoroutineContext$annotations() {
    }

    public abstract Object doWork(Continuation<? super ListenableWorker.Result> continuation);

    public Object getForegroundInfo(Continuation<? super ForegroundInfo> continuation) {
        return getForegroundInfo$suspendImpl(this, continuation);
    }

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public CoroutineWorker(Context appContext, WorkerParameters params) {
        super(appContext, params);
        Intrinsics.checkNotNullParameter(appContext, "appContext");
        Intrinsics.checkNotNullParameter(params, "params");
        this.params = params;
        this.coroutineContext = DeprecatedDispatcher.INSTANCE;
    }

    public CoroutineDispatcher getCoroutineContext() {
        return this.coroutineContext;
    }

    @Override // androidx.work.ListenableWorker
    public final ListenableFuture<ListenableWorker.Result> startWork() {
        CoroutineContext workerContext;
        if (!Intrinsics.areEqual(getCoroutineContext(), DeprecatedDispatcher.INSTANCE)) {
            workerContext = getCoroutineContext();
        } else {
            workerContext = this.params.getWorkerContext();
        }
        Intrinsics.checkNotNullExpressionValue(workerContext, "if (coroutineContext != …rkerContext\n            }");
        return ListenableFutureKt.launchFuture$default(workerContext.plus(JobKt__JobKt.Job$default(null, 1, null)), null, new C00591(null), 2, null);
    }

    /* JADX INFO: renamed from: androidx.work.CoroutineWorker$startWork$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: CoroutineWorker.kt */
    static final class C00591 extends SuspendLambda implements Function2 {
        int label;

        C00591(Continuation continuation) {
            super(2, continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return CoroutineWorker.this.new C00591(continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((C00591) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
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
            CoroutineWorker coroutineWorker = CoroutineWorker.this;
            this.label = 1;
            Object objDoWork = coroutineWorker.doWork(this);
            return objDoWork == coroutine_suspended ? coroutine_suspended : objDoWork;
        }
    }

    static /* synthetic */ Object getForegroundInfo$suspendImpl(CoroutineWorker coroutineWorker, Continuation<? super ForegroundInfo> continuation) {
        throw new IllegalStateException("Not implemented");
    }

    public final Object setProgress(Data data, Continuation<? super Unit> continuation) throws Throwable {
        ListenableFuture<Void> progressAsync = setProgressAsync(data);
        Intrinsics.checkNotNullExpressionValue(progressAsync, "setProgressAsync(data)");
        Object objAwait = androidx.concurrent.futures.ListenableFutureKt.await(progressAsync, continuation);
        return objAwait == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objAwait : Unit.INSTANCE;
    }

    public final Object setForeground(ForegroundInfo foregroundInfo, Continuation<? super Unit> continuation) throws Throwable {
        ListenableFuture<Void> foregroundAsync = setForegroundAsync(foregroundInfo);
        Intrinsics.checkNotNullExpressionValue(foregroundAsync, "setForegroundAsync(foregroundInfo)");
        Object objAwait = androidx.concurrent.futures.ListenableFutureKt.await(foregroundAsync, continuation);
        return objAwait == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objAwait : Unit.INSTANCE;
    }

    /* JADX INFO: renamed from: androidx.work.CoroutineWorker$getForegroundInfoAsync$1, reason: invalid class name */
    /* JADX INFO: compiled from: CoroutineWorker.kt */
    static final class AnonymousClass1 extends SuspendLambda implements Function2 {
        int label;

        AnonymousClass1(Continuation continuation) {
            super(2, continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return CoroutineWorker.this.new AnonymousClass1(continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((AnonymousClass1) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
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
            CoroutineWorker coroutineWorker = CoroutineWorker.this;
            this.label = 1;
            Object foregroundInfo = coroutineWorker.getForegroundInfo(this);
            return foregroundInfo == coroutine_suspended ? coroutine_suspended : foregroundInfo;
        }
    }

    @Override // androidx.work.ListenableWorker
    public final ListenableFuture<ForegroundInfo> getForegroundInfoAsync() {
        return ListenableFutureKt.launchFuture$default(getCoroutineContext().plus(JobKt__JobKt.Job$default(null, 1, null)), null, new AnonymousClass1(null), 2, null);
    }

    @Override // androidx.work.ListenableWorker
    public final void onStopped() {
        super.onStopped();
    }

    /* JADX INFO: compiled from: CoroutineWorker.kt */
    private static final class DeprecatedDispatcher extends CoroutineDispatcher {
        public static final DeprecatedDispatcher INSTANCE = new DeprecatedDispatcher();
        private static final CoroutineDispatcher dispatcher = Dispatchers.getDefault();

        private DeprecatedDispatcher() {
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
        public void dispatch(CoroutineContext context, Runnable block) {
            Intrinsics.checkNotNullParameter(context, "context");
            Intrinsics.checkNotNullParameter(block, "block");
            dispatcher.dispatch(context, block);
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher
        public boolean isDispatchNeeded(CoroutineContext context) {
            Intrinsics.checkNotNullParameter(context, "context");
            return dispatcher.isDispatchNeeded(context);
        }
    }
}
