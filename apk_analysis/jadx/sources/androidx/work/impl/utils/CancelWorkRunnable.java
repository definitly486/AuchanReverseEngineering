package androidx.work.impl.utils;

import androidx.work.Operation;
import androidx.work.OperationKt;
import androidx.work.Tracer;
import androidx.work.WorkInfo;
import androidx.work.impl.Processor;
import androidx.work.impl.Scheduler;
import androidx.work.impl.Schedulers;
import androidx.work.impl.WorkDatabase;
import androidx.work.impl.WorkManagerImpl;
import androidx.work.impl.model.DependencyDao;
import androidx.work.impl.model.WorkSpecDao;
import androidx.work.impl.utils.taskexecutor.SerialExecutor;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.Iterator;
import java.util.List;
import java.util.UUID;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: compiled from: CancelWorkRunnable.kt */
/* JADX INFO: loaded from: classes.dex */
public final class CancelWorkRunnable {
    /* JADX INFO: Access modifiers changed from: private */
    public static final void cancel(WorkManagerImpl workManagerImpl, String str) {
        WorkDatabase workDatabase = workManagerImpl.getWorkDatabase();
        Intrinsics.checkNotNullExpressionValue(workDatabase, "workManagerImpl.workDatabase");
        iterativelyCancelWorkAndDependents(workDatabase, str);
        Processor processor = workManagerImpl.getProcessor();
        Intrinsics.checkNotNullExpressionValue(processor, "workManagerImpl.processor");
        processor.stopAndCancelWork(str, 1);
        Iterator<Scheduler> it = workManagerImpl.getSchedulers().iterator();
        while (it.hasNext()) {
            it.next().cancel(str);
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final void reschedulePendingWorkers(WorkManagerImpl workManagerImpl) {
        Schedulers.schedule(workManagerImpl.getConfiguration(), workManagerImpl.getWorkDatabase(), workManagerImpl.getSchedulers());
    }

    private static final void iterativelyCancelWorkAndDependents(WorkDatabase workDatabase, String str) {
        WorkSpecDao workSpecDao = workDatabase.workSpecDao();
        DependencyDao dependencyDao = workDatabase.dependencyDao();
        List listMutableListOf = CollectionsKt.mutableListOf(str);
        while (!listMutableListOf.isEmpty()) {
            String str2 = (String) CollectionsKt.removeLast(listMutableListOf);
            WorkInfo.State state = workSpecDao.getState(str2);
            if (state != WorkInfo.State.SUCCEEDED && state != WorkInfo.State.FAILED) {
                workSpecDao.setCancelledState(str2);
            }
            listMutableListOf.addAll(dependencyDao.getDependentWorkIds(str2));
        }
    }

    /* JADX INFO: renamed from: androidx.work.impl.utils.CancelWorkRunnable$forId$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: CancelWorkRunnable.kt */
    static final class C00631 extends Lambda implements Function0 {
        final /* synthetic */ UUID $id;
        final /* synthetic */ WorkManagerImpl $workManagerImpl;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        C00631(WorkManagerImpl workManagerImpl, UUID uuid) {
            super(0);
            this.$workManagerImpl = workManagerImpl;
            this.$id = uuid;
        }

        @Override // kotlin.jvm.functions.Function0
        public /* bridge */ /* synthetic */ Object invoke() {
            m161invoke();
            return Unit.INSTANCE;
        }

        /* JADX INFO: renamed from: invoke, reason: collision with other method in class */
        public final void m161invoke() {
            WorkDatabase workDatabase = this.$workManagerImpl.getWorkDatabase();
            Intrinsics.checkNotNullExpressionValue(workDatabase, "workManagerImpl.workDatabase");
            final WorkManagerImpl workManagerImpl = this.$workManagerImpl;
            final UUID uuid = this.$id;
            workDatabase.runInTransaction(new Runnable() { // from class: androidx.work.impl.utils.CancelWorkRunnable$forId$1$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    CancelWorkRunnable.C00631.invoke$lambda$0(workManagerImpl, uuid);
                }
            });
            CancelWorkRunnable.reschedulePendingWorkers(this.$workManagerImpl);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public static final void invoke$lambda$0(WorkManagerImpl workManagerImpl, UUID uuid) {
            String string = uuid.toString();
            Intrinsics.checkNotNullExpressionValue(string, "id.toString()");
            CancelWorkRunnable.cancel(workManagerImpl, string);
        }
    }

    public static final Operation forId(UUID id, WorkManagerImpl workManagerImpl) {
        Intrinsics.checkNotNullParameter(id, "id");
        Intrinsics.checkNotNullParameter(workManagerImpl, "workManagerImpl");
        Tracer tracer = workManagerImpl.getConfiguration().getTracer();
        SerialExecutor serialTaskExecutor = workManagerImpl.getWorkTaskExecutor().getSerialTaskExecutor();
        Intrinsics.checkNotNullExpressionValue(serialTaskExecutor, "workManagerImpl.workTask…ecutor.serialTaskExecutor");
        return OperationKt.launchOperation(tracer, "CancelWorkById", serialTaskExecutor, new C00631(workManagerImpl, id));
    }

    /* JADX INFO: renamed from: androidx.work.impl.utils.CancelWorkRunnable$forTag$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: CancelWorkRunnable.kt */
    static final class C00651 extends Lambda implements Function0 {
        final /* synthetic */ String $tag;
        final /* synthetic */ WorkManagerImpl $workManagerImpl;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        C00651(WorkManagerImpl workManagerImpl, String str) {
            super(0);
            this.$workManagerImpl = workManagerImpl;
            this.$tag = str;
        }

        @Override // kotlin.jvm.functions.Function0
        public /* bridge */ /* synthetic */ Object invoke() {
            m164invoke();
            return Unit.INSTANCE;
        }

        /* JADX INFO: renamed from: invoke, reason: collision with other method in class */
        public final void m164invoke() {
            final WorkDatabase workDatabase = this.$workManagerImpl.getWorkDatabase();
            Intrinsics.checkNotNullExpressionValue(workDatabase, "workManagerImpl.workDatabase");
            final String str = this.$tag;
            final WorkManagerImpl workManagerImpl = this.$workManagerImpl;
            workDatabase.runInTransaction(new Runnable() { // from class: androidx.work.impl.utils.CancelWorkRunnable$forTag$1$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    CancelWorkRunnable.C00651.invoke$lambda$0(workDatabase, str, workManagerImpl);
                }
            });
            CancelWorkRunnable.reschedulePendingWorkers(this.$workManagerImpl);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public static final void invoke$lambda$0(WorkDatabase workDatabase, String str, WorkManagerImpl workManagerImpl) {
            Iterator<String> it = workDatabase.workSpecDao().getUnfinishedWorkWithTag(str).iterator();
            while (it.hasNext()) {
                CancelWorkRunnable.cancel(workManagerImpl, it.next());
            }
        }
    }

    public static final Operation forTag(String tag, WorkManagerImpl workManagerImpl) {
        Intrinsics.checkNotNullParameter(tag, "tag");
        Intrinsics.checkNotNullParameter(workManagerImpl, "workManagerImpl");
        Tracer tracer = workManagerImpl.getConfiguration().getTracer();
        String str = "CancelWorkByTag_" + tag;
        SerialExecutor serialTaskExecutor = workManagerImpl.getWorkTaskExecutor().getSerialTaskExecutor();
        Intrinsics.checkNotNullExpressionValue(serialTaskExecutor, "workManagerImpl.workTask…ecutor.serialTaskExecutor");
        return OperationKt.launchOperation(tracer, str, serialTaskExecutor, new C00651(workManagerImpl, tag));
    }

    public static final Operation forName(final String name, final WorkManagerImpl workManagerImpl) {
        Intrinsics.checkNotNullParameter(name, "name");
        Intrinsics.checkNotNullParameter(workManagerImpl, "workManagerImpl");
        Tracer tracer = workManagerImpl.getConfiguration().getTracer();
        String str = "CancelWorkByName_" + name;
        SerialExecutor serialTaskExecutor = workManagerImpl.getWorkTaskExecutor().getSerialTaskExecutor();
        Intrinsics.checkNotNullExpressionValue(serialTaskExecutor, "workManagerImpl.workTask…ecutor.serialTaskExecutor");
        return OperationKt.launchOperation(tracer, str, serialTaskExecutor, new Function0() { // from class: androidx.work.impl.utils.CancelWorkRunnable.forName.1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(0);
            }

            @Override // kotlin.jvm.functions.Function0
            public /* bridge */ /* synthetic */ Object invoke() {
                m162invoke();
                return Unit.INSTANCE;
            }

            /* JADX INFO: renamed from: invoke, reason: collision with other method in class */
            public final void m162invoke() {
                CancelWorkRunnable.forNameInline(name, workManagerImpl);
                CancelWorkRunnable.reschedulePendingWorkers(workManagerImpl);
            }
        });
    }

    public static final void forNameInline(final String name, final WorkManagerImpl workManagerImpl) {
        Intrinsics.checkNotNullParameter(name, "name");
        Intrinsics.checkNotNullParameter(workManagerImpl, "workManagerImpl");
        final WorkDatabase workDatabase = workManagerImpl.getWorkDatabase();
        Intrinsics.checkNotNullExpressionValue(workDatabase, "workManagerImpl.workDatabase");
        workDatabase.runInTransaction(new Runnable() { // from class: androidx.work.impl.utils.CancelWorkRunnable$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                CancelWorkRunnable.forNameInline$lambda$0(workDatabase, name, workManagerImpl);
            }
        });
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final void forNameInline$lambda$0(WorkDatabase workDatabase, String str, WorkManagerImpl workManagerImpl) {
        Iterator<String> it = workDatabase.workSpecDao().getUnfinishedWorkWithName(str).iterator();
        while (it.hasNext()) {
            cancel(workManagerImpl, it.next());
        }
    }

    /* JADX INFO: renamed from: androidx.work.impl.utils.CancelWorkRunnable$forAll$1, reason: invalid class name */
    /* JADX INFO: compiled from: CancelWorkRunnable.kt */
    static final class AnonymousClass1 extends Lambda implements Function0 {
        final /* synthetic */ WorkManagerImpl $workManagerImpl;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        AnonymousClass1(WorkManagerImpl workManagerImpl) {
            super(0);
            this.$workManagerImpl = workManagerImpl;
        }

        @Override // kotlin.jvm.functions.Function0
        public /* bridge */ /* synthetic */ Object invoke() {
            m160invoke();
            return Unit.INSTANCE;
        }

        /* JADX INFO: renamed from: invoke, reason: collision with other method in class */
        public final void m160invoke() {
            final WorkDatabase workDatabase = this.$workManagerImpl.getWorkDatabase();
            Intrinsics.checkNotNullExpressionValue(workDatabase, "workManagerImpl.workDatabase");
            final WorkManagerImpl workManagerImpl = this.$workManagerImpl;
            workDatabase.runInTransaction(new Runnable() { // from class: androidx.work.impl.utils.CancelWorkRunnable$forAll$1$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    CancelWorkRunnable.AnonymousClass1.invoke$lambda$0(workDatabase, workManagerImpl);
                }
            });
        }

        /* JADX INFO: Access modifiers changed from: private */
        public static final void invoke$lambda$0(WorkDatabase workDatabase, WorkManagerImpl workManagerImpl) {
            Iterator<String> it = workDatabase.workSpecDao().getAllUnfinishedWork().iterator();
            while (it.hasNext()) {
                CancelWorkRunnable.cancel(workManagerImpl, it.next());
            }
            new PreferenceUtils(workDatabase).setLastCancelAllTimeMillis(workManagerImpl.getConfiguration().getClock().currentTimeMillis());
        }
    }

    public static final Operation forAll(WorkManagerImpl workManagerImpl) {
        Intrinsics.checkNotNullParameter(workManagerImpl, "workManagerImpl");
        Tracer tracer = workManagerImpl.getConfiguration().getTracer();
        SerialExecutor serialTaskExecutor = workManagerImpl.getWorkTaskExecutor().getSerialTaskExecutor();
        Intrinsics.checkNotNullExpressionValue(serialTaskExecutor, "workManagerImpl.workTask…ecutor.serialTaskExecutor");
        return OperationKt.launchOperation(tracer, "CancelAllWork", serialTaskExecutor, new AnonymousClass1(workManagerImpl));
    }
}
