package androidx.work;

import android.content.ComponentName;
import androidx.work.impl.utils.EnqueueUtilsKt;
import java.util.UUID;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: WorkerParameters.kt */
/* JADX INFO: loaded from: classes.dex */
public final class WorkerParametersExtensions {
    public static final boolean isRemoteWorkRequest(WorkerParameters workerParameters) {
        Intrinsics.checkNotNullParameter(workerParameters, "<this>");
        Data inputData = workerParameters.getInputData();
        Intrinsics.checkNotNullExpressionValue(inputData, "inputData");
        return isRemoteWorkRequest(inputData);
    }

    public static final /* synthetic */ <T extends ListenableWorker> WorkerParameters usingRemoteService(WorkerParameters workerParameters, ComponentName componentName) {
        Intrinsics.checkNotNullParameter(workerParameters, "<this>");
        Intrinsics.checkNotNullParameter(componentName, "componentName");
        Intrinsics.reifiedOperationMarker(4, "T");
        String name = ListenableWorker.class.getName();
        Intrinsics.checkNotNullExpressionValue(name, "T::class.java.name");
        return usingRemoteService(workerParameters, name, componentName);
    }

    public static final WorkerParameters usingRemoteService(WorkerParameters workerParameters, String workerClassName, ComponentName componentName) {
        Intrinsics.checkNotNullParameter(workerParameters, "<this>");
        Intrinsics.checkNotNullParameter(workerClassName, "workerClassName");
        Intrinsics.checkNotNullParameter(componentName, "componentName");
        UUID id = workerParameters.getId();
        Data inputData = workerParameters.getInputData();
        Intrinsics.checkNotNullExpressionValue(inputData, "inputData");
        return new WorkerParameters(id, buildDelegatedRemoteRequestData(workerClassName, componentName, inputData), workerParameters.getTags(), workerParameters.getRuntimeExtras(), workerParameters.getRunAttemptCount(), workerParameters.getGeneration(), workerParameters.getBackgroundExecutor(), workerParameters.getWorkerContext(), workerParameters.getTaskExecutor(), workerParameters.getWorkerFactory(), workerParameters.getProgressUpdater(), workerParameters.getForegroundUpdater());
    }

    public static final Data buildDelegatedRemoteRequestData(String delegatedWorkerName, ComponentName componentName, Data inputData) {
        Intrinsics.checkNotNullParameter(delegatedWorkerName, "delegatedWorkerName");
        Intrinsics.checkNotNullParameter(componentName, "componentName");
        Intrinsics.checkNotNullParameter(inputData, "inputData");
        Data.Builder builder = new Data.Builder();
        builder.putAll(inputData).putString(EnqueueUtilsKt.ARGUMENT_SERVICE_PACKAGE_NAME, componentName.getPackageName()).putString(EnqueueUtilsKt.ARGUMENT_SERVICE_CLASS_NAME, componentName.getClassName()).putString(EnqueueUtilsKt.ARGUMENT_REMOTE_LISTENABLE_WORKER_NAME, delegatedWorkerName);
        return builder.build();
    }

    public static final boolean isRemoteWorkRequest(Data data) {
        Intrinsics.checkNotNullParameter(data, "<this>");
        return data.hasKeyWithValueOfType(EnqueueUtilsKt.ARGUMENT_SERVICE_PACKAGE_NAME, String.class) && data.hasKeyWithValueOfType(EnqueueUtilsKt.ARGUMENT_SERVICE_CLASS_NAME, String.class) && data.hasKeyWithValueOfType(EnqueueUtilsKt.ARGUMENT_REMOTE_LISTENABLE_WORKER_NAME, String.class);
    }
}
