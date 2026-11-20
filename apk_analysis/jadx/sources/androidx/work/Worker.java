package androidx.work;

import android.content.Context;
import com.google.common.util.concurrent.ListenableFuture;
import java.util.concurrent.Executor;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Worker.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class Worker extends ListenableWorker {
    public abstract ListenableWorker.Result doWork();

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public Worker(Context context, WorkerParameters workerParams) {
        super(context, workerParams);
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(workerParams, "workerParams");
    }

    @Override // androidx.work.ListenableWorker
    public final ListenableFuture<ListenableWorker.Result> startWork() {
        Executor backgroundExecutor = getBackgroundExecutor();
        Intrinsics.checkNotNullExpressionValue(backgroundExecutor, "backgroundExecutor");
        return WorkerKt.future(backgroundExecutor, new Function0() { // from class: androidx.work.Worker.startWork.1
            {
                super(0);
            }

            @Override // kotlin.jvm.functions.Function0
            public final ListenableWorker.Result invoke() {
                return Worker.this.doWork();
            }
        });
    }

    @Override // androidx.work.ListenableWorker
    public ListenableFuture<ForegroundInfo> getForegroundInfoAsync() {
        Executor backgroundExecutor = getBackgroundExecutor();
        Intrinsics.checkNotNullExpressionValue(backgroundExecutor, "backgroundExecutor");
        return WorkerKt.future(backgroundExecutor, new Function0() { // from class: androidx.work.Worker.getForegroundInfoAsync.1
            {
                super(0);
            }

            @Override // kotlin.jvm.functions.Function0
            public final ForegroundInfo invoke() {
                return Worker.this.getForegroundInfo();
            }
        });
    }

    public ForegroundInfo getForegroundInfo() {
        throw new IllegalStateException("Expedited WorkRequests require a Worker to provide an implementation for `getForegroundInfo()`");
    }
}
