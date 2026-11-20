package androidx.work.impl.utils;

import androidx.work.ListenableFutureKt;
import androidx.work.WorkInfo;
import androidx.work.WorkQuery;
import androidx.work.impl.WorkDatabase;
import androidx.work.impl.model.WorkSpec;
import androidx.work.impl.model.WorkSpecDao;
import androidx.work.impl.utils.taskexecutor.SerialExecutor;
import androidx.work.impl.utils.taskexecutor.TaskExecutor;
import com.google.common.util.concurrent.ListenableFuture;
import java.util.List;
import java.util.UUID;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: StatusRunnable.kt */
/* JADX INFO: loaded from: classes.dex */
public final class StatusRunnable {
    public static final ListenableFuture<List<WorkInfo>> forStringIds(WorkDatabase workDatabase, TaskExecutor executor, final List<String> ids) {
        Intrinsics.checkNotNullParameter(workDatabase, "<this>");
        Intrinsics.checkNotNullParameter(executor, "executor");
        Intrinsics.checkNotNullParameter(ids, "ids");
        return loadStatusFuture(workDatabase, executor, new Function1() { // from class: androidx.work.impl.utils.StatusRunnable.forStringIds.1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            @Override // kotlin.jvm.functions.Function1
            public final List invoke(WorkDatabase db) {
                Intrinsics.checkNotNullParameter(db, "db");
                Object objApply = WorkSpec.WORK_INFO_MAPPER.apply(db.workSpecDao().getWorkStatusPojoForIds(ids));
                Intrinsics.checkNotNullExpressionValue(objApply, "WORK_INFO_MAPPER.apply(d…orkStatusPojoForIds(ids))");
                return (List) objApply;
            }
        });
    }

    public static final ListenableFuture<WorkInfo> forUUID(WorkDatabase workDatabase, TaskExecutor executor, final UUID id) {
        Intrinsics.checkNotNullParameter(workDatabase, "<this>");
        Intrinsics.checkNotNullParameter(executor, "executor");
        Intrinsics.checkNotNullParameter(id, "id");
        return loadStatusFuture(workDatabase, executor, new Function1() { // from class: androidx.work.impl.utils.StatusRunnable.forUUID.1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            @Override // kotlin.jvm.functions.Function1
            public final WorkInfo invoke(WorkDatabase db) {
                Intrinsics.checkNotNullParameter(db, "db");
                WorkSpecDao workSpecDao = db.workSpecDao();
                String string = id.toString();
                Intrinsics.checkNotNullExpressionValue(string, "id.toString()");
                WorkSpec.WorkInfoPojo workStatusPojoForId = workSpecDao.getWorkStatusPojoForId(string);
                if (workStatusPojoForId != null) {
                    return workStatusPojoForId.toWorkInfo();
                }
                return null;
            }
        });
    }

    public static final ListenableFuture<List<WorkInfo>> forTag(WorkDatabase workDatabase, TaskExecutor executor, final String tag) {
        Intrinsics.checkNotNullParameter(workDatabase, "<this>");
        Intrinsics.checkNotNullParameter(executor, "executor");
        Intrinsics.checkNotNullParameter(tag, "tag");
        return loadStatusFuture(workDatabase, executor, new Function1() { // from class: androidx.work.impl.utils.StatusRunnable.forTag.1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            @Override // kotlin.jvm.functions.Function1
            public final List invoke(WorkDatabase db) {
                Intrinsics.checkNotNullParameter(db, "db");
                Object objApply = WorkSpec.WORK_INFO_MAPPER.apply(db.workSpecDao().getWorkStatusPojoForTag(tag));
                Intrinsics.checkNotNullExpressionValue(objApply, "WORK_INFO_MAPPER.apply(d…orkStatusPojoForTag(tag))");
                return (List) objApply;
            }
        });
    }

    public static final ListenableFuture<List<WorkInfo>> forUniqueWork(WorkDatabase workDatabase, TaskExecutor executor, final String name) {
        Intrinsics.checkNotNullParameter(workDatabase, "<this>");
        Intrinsics.checkNotNullParameter(executor, "executor");
        Intrinsics.checkNotNullParameter(name, "name");
        return loadStatusFuture(workDatabase, executor, new Function1() { // from class: androidx.work.impl.utils.StatusRunnable.forUniqueWork.1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            @Override // kotlin.jvm.functions.Function1
            public final List invoke(WorkDatabase db) {
                Intrinsics.checkNotNullParameter(db, "db");
                Object objApply = WorkSpec.WORK_INFO_MAPPER.apply(db.workSpecDao().getWorkStatusPojoForName(name));
                Intrinsics.checkNotNullExpressionValue(objApply, "WORK_INFO_MAPPER.apply(d…kStatusPojoForName(name))");
                return (List) objApply;
            }
        });
    }

    public static final ListenableFuture<List<WorkInfo>> forWorkQuerySpec(WorkDatabase workDatabase, TaskExecutor executor, final WorkQuery querySpec) {
        Intrinsics.checkNotNullParameter(workDatabase, "<this>");
        Intrinsics.checkNotNullParameter(executor, "executor");
        Intrinsics.checkNotNullParameter(querySpec, "querySpec");
        return loadStatusFuture(workDatabase, executor, new Function1() { // from class: androidx.work.impl.utils.StatusRunnable.forWorkQuerySpec.1
            {
                super(1);
            }

            @Override // kotlin.jvm.functions.Function1
            public final List invoke(WorkDatabase db) {
                Intrinsics.checkNotNullParameter(db, "db");
                Object objApply = WorkSpec.WORK_INFO_MAPPER.apply(db.rawWorkInfoDao().getWorkInfoPojos(RawQueries.toRawQuery(querySpec)));
                Intrinsics.checkNotNullExpressionValue(objApply, "WORK_INFO_MAPPER.apply(d…(querySpec.toRawQuery()))");
                return (List) objApply;
            }
        });
    }

    private static final <T> ListenableFuture<T> loadStatusFuture(final WorkDatabase workDatabase, TaskExecutor taskExecutor, final Function1<? super WorkDatabase, ? extends T> function1) {
        SerialExecutor serialTaskExecutor = taskExecutor.getSerialTaskExecutor();
        Intrinsics.checkNotNullExpressionValue(serialTaskExecutor, "executor.serialTaskExecutor");
        return ListenableFutureKt.executeAsync(serialTaskExecutor, "loadStatusFuture", new Function0() { // from class: androidx.work.impl.utils.StatusRunnable.loadStatusFuture.1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(0);
            }

            @Override // kotlin.jvm.functions.Function0
            public final Object invoke() {
                return function1.invoke(workDatabase);
            }
        });
    }
}
