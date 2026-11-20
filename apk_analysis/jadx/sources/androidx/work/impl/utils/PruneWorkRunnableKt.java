package androidx.work.impl.utils;

import androidx.work.Configuration;
import androidx.work.Operation;
import androidx.work.OperationKt;
import androidx.work.Tracer;
import androidx.work.impl.WorkDatabase;
import androidx.work.impl.utils.taskexecutor.SerialExecutor;
import androidx.work.impl.utils.taskexecutor.TaskExecutor;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: PruneWorkRunnable.kt */
/* JADX INFO: loaded from: classes.dex */
public final class PruneWorkRunnableKt {
    public static final Operation pruneWork(final WorkDatabase workDatabase, Configuration configuration, TaskExecutor executor) {
        Intrinsics.checkNotNullParameter(workDatabase, "<this>");
        Intrinsics.checkNotNullParameter(configuration, "configuration");
        Intrinsics.checkNotNullParameter(executor, "executor");
        Tracer tracer = configuration.getTracer();
        SerialExecutor serialTaskExecutor = executor.getSerialTaskExecutor();
        Intrinsics.checkNotNullExpressionValue(serialTaskExecutor, "executor.serialTaskExecutor");
        return OperationKt.launchOperation(tracer, "PruneWork", serialTaskExecutor, new Function0() { // from class: androidx.work.impl.utils.PruneWorkRunnableKt.pruneWork.1
            {
                super(0);
            }

            @Override // kotlin.jvm.functions.Function0
            public /* bridge */ /* synthetic */ Object invoke() {
                m167invoke();
                return Unit.INSTANCE;
            }

            /* JADX INFO: renamed from: invoke, reason: collision with other method in class */
            public final void m167invoke() {
                workDatabase.workSpecDao().pruneFinishedWorkWithZeroDependentsIgnoringKeepForAtLeast();
            }
        });
    }
}
