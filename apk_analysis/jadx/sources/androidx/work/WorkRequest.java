package androidx.work;

import android.annotation.SuppressLint;
import androidx.core.location.LocationRequestCompat;
import androidx.work.impl.model.WorkSpec;
import androidx.work.impl.utils.DurationApi26Impl;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.SetsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.time.Duration;
import java.util.List;
import java.util.Set;
import java.util.UUID;
import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: WorkRequest.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class WorkRequest {
    public static final Companion Companion = new Companion(null);
    public static final long DEFAULT_BACKOFF_DELAY_MILLIS = 30000;

    @SuppressLint({"MinMaxConstant"})
    public static final long MAX_BACKOFF_MILLIS = 18000000;
    private static final int MAX_TRACE_SPAN_LENGTH = 127;

    @SuppressLint({"MinMaxConstant"})
    public static final long MIN_BACKOFF_MILLIS = 10000;
    private final UUID id;
    private final Set<String> tags;
    private final WorkSpec workSpec;

    public WorkRequest(UUID id, WorkSpec workSpec, Set tags) {
        Intrinsics.checkNotNullParameter(id, "id");
        Intrinsics.checkNotNullParameter(workSpec, "workSpec");
        Intrinsics.checkNotNullParameter(tags, "tags");
        this.id = id;
        this.workSpec = workSpec;
        this.tags = tags;
    }

    public UUID getId() {
        return this.id;
    }

    public final WorkSpec getWorkSpec() {
        return this.workSpec;
    }

    public final Set<String> getTags() {
        return this.tags;
    }

    public final String getStringId() {
        String string = getId().toString();
        Intrinsics.checkNotNullExpressionValue(string, "id.toString()");
        return string;
    }

    /* JADX INFO: compiled from: WorkRequest.kt */
    public static abstract class Builder<B extends Builder<B, ?>, W extends WorkRequest> {
        private boolean backoffCriteriaSet;
        private UUID id;
        private final Set<String> tags;
        private WorkSpec workSpec;
        private final Class<? extends ListenableWorker> workerClass;

        public abstract WorkRequest buildInternal$work_runtime_release();

        public abstract Builder getThisObject$work_runtime_release();

        public Builder(Class workerClass) {
            Intrinsics.checkNotNullParameter(workerClass, "workerClass");
            this.workerClass = workerClass;
            UUID uuidRandomUUID = UUID.randomUUID();
            Intrinsics.checkNotNullExpressionValue(uuidRandomUUID, "randomUUID()");
            this.id = uuidRandomUUID;
            String string = this.id.toString();
            Intrinsics.checkNotNullExpressionValue(string, "id.toString()");
            String name = workerClass.getName();
            Intrinsics.checkNotNullExpressionValue(name, "workerClass.name");
            this.workSpec = new WorkSpec(string, name);
            String name2 = workerClass.getName();
            Intrinsics.checkNotNullExpressionValue(name2, "workerClass.name");
            this.tags = SetsKt.mutableSetOf(name2);
        }

        public final Class<? extends ListenableWorker> getWorkerClass$work_runtime_release() {
            return this.workerClass;
        }

        public final boolean getBackoffCriteriaSet$work_runtime_release() {
            return this.backoffCriteriaSet;
        }

        public final void setBackoffCriteriaSet$work_runtime_release(boolean z) {
            this.backoffCriteriaSet = z;
        }

        public final UUID getId$work_runtime_release() {
            return this.id;
        }

        public final void setId$work_runtime_release(UUID uuid) {
            Intrinsics.checkNotNullParameter(uuid, "<set-?>");
            this.id = uuid;
        }

        public final WorkSpec getWorkSpec$work_runtime_release() {
            return this.workSpec;
        }

        public final void setWorkSpec$work_runtime_release(WorkSpec workSpec) {
            Intrinsics.checkNotNullParameter(workSpec, "<set-?>");
            this.workSpec = workSpec;
        }

        public final Set<String> getTags$work_runtime_release() {
            return this.tags;
        }

        public final B setId(UUID id) {
            Intrinsics.checkNotNullParameter(id, "id");
            this.id = id;
            String string = id.toString();
            Intrinsics.checkNotNullExpressionValue(string, "id.toString()");
            this.workSpec = new WorkSpec(string, this.workSpec);
            return (B) getThisObject$work_runtime_release();
        }

        public final B setBackoffCriteria(BackoffPolicy backoffPolicy, long j, TimeUnit timeUnit) {
            Intrinsics.checkNotNullParameter(backoffPolicy, "backoffPolicy");
            Intrinsics.checkNotNullParameter(timeUnit, "timeUnit");
            this.backoffCriteriaSet = true;
            WorkSpec workSpec = this.workSpec;
            workSpec.backoffPolicy = backoffPolicy;
            workSpec.setBackoffDelayDuration(timeUnit.toMillis(j));
            return (B) getThisObject$work_runtime_release();
        }

        public final B setBackoffCriteria(BackoffPolicy backoffPolicy, Duration duration) {
            Intrinsics.checkNotNullParameter(backoffPolicy, "backoffPolicy");
            Intrinsics.checkNotNullParameter(duration, "duration");
            this.backoffCriteriaSet = true;
            WorkSpec workSpec = this.workSpec;
            workSpec.backoffPolicy = backoffPolicy;
            workSpec.setBackoffDelayDuration(DurationApi26Impl.toMillisCompat(duration));
            return (B) getThisObject$work_runtime_release();
        }

        public final B setConstraints(Constraints constraints) {
            Intrinsics.checkNotNullParameter(constraints, "constraints");
            this.workSpec.constraints = constraints;
            return (B) getThisObject$work_runtime_release();
        }

        public final B setInputData(Data inputData) {
            Intrinsics.checkNotNullParameter(inputData, "inputData");
            this.workSpec.input = inputData;
            return (B) getThisObject$work_runtime_release();
        }

        public final B addTag(String tag) {
            Intrinsics.checkNotNullParameter(tag, "tag");
            this.tags.add(tag);
            return (B) getThisObject$work_runtime_release();
        }

        public final B setTraceTag(String traceTag) {
            Intrinsics.checkNotNullParameter(traceTag, "traceTag");
            this.workSpec.setTraceTag(traceTag);
            return (B) getThisObject$work_runtime_release();
        }

        public final B keepResultsForAtLeast(long j, TimeUnit timeUnit) {
            Intrinsics.checkNotNullParameter(timeUnit, "timeUnit");
            this.workSpec.minimumRetentionDuration = timeUnit.toMillis(j);
            return (B) getThisObject$work_runtime_release();
        }

        public final B keepResultsForAtLeast(Duration duration) {
            Intrinsics.checkNotNullParameter(duration, "duration");
            this.workSpec.minimumRetentionDuration = DurationApi26Impl.toMillisCompat(duration);
            return (B) getThisObject$work_runtime_release();
        }

        public B setInitialDelay(long j, TimeUnit timeUnit) {
            Intrinsics.checkNotNullParameter(timeUnit, "timeUnit");
            this.workSpec.initialDelay = timeUnit.toMillis(j);
            if (LocationRequestCompat.PASSIVE_INTERVAL - System.currentTimeMillis() <= this.workSpec.initialDelay) {
                throw new IllegalArgumentException("The given initial delay is too large and will cause an overflow!");
            }
            return (B) getThisObject$work_runtime_release();
        }

        public B setInitialDelay(Duration duration) {
            Intrinsics.checkNotNullParameter(duration, "duration");
            this.workSpec.initialDelay = DurationApi26Impl.toMillisCompat(duration);
            if (LocationRequestCompat.PASSIVE_INTERVAL - System.currentTimeMillis() <= this.workSpec.initialDelay) {
                throw new IllegalArgumentException("The given initial delay is too large and will cause an overflow!");
            }
            return (B) getThisObject$work_runtime_release();
        }

        @SuppressLint({"MissingGetterMatchingBuilder"})
        public B setExpedited(OutOfQuotaPolicy policy) {
            Intrinsics.checkNotNullParameter(policy, "policy");
            WorkSpec workSpec = this.workSpec;
            workSpec.expedited = true;
            workSpec.outOfQuotaPolicy = policy;
            return (B) getThisObject$work_runtime_release();
        }

        public final W build() {
            W w = (W) buildInternal$work_runtime_release();
            Constraints constraints = this.workSpec.constraints;
            boolean z = constraints.hasContentUriTriggers() || constraints.requiresBatteryNotLow() || constraints.requiresCharging() || constraints.requiresDeviceIdle();
            WorkSpec workSpec = this.workSpec;
            if (workSpec.expedited) {
                if (z) {
                    throw new IllegalArgumentException("Expedited jobs only support network and storage constraints");
                }
                if (workSpec.initialDelay > 0) {
                    throw new IllegalArgumentException("Expedited jobs cannot be delayed");
                }
            }
            if (workSpec.getTraceTag() == null) {
                WorkSpec workSpec2 = this.workSpec;
                workSpec2.setTraceTag(WorkRequest.Companion.deriveTraceTagFromClassName(workSpec2.workerClassName));
            }
            UUID uuidRandomUUID = UUID.randomUUID();
            Intrinsics.checkNotNullExpressionValue(uuidRandomUUID, "randomUUID()");
            setId(uuidRandomUUID);
            return w;
        }

        public final B setInitialState(WorkInfo.State state) {
            Intrinsics.checkNotNullParameter(state, "state");
            this.workSpec.state = state;
            return (B) getThisObject$work_runtime_release();
        }

        public final B setInitialRunAttemptCount(int i) {
            this.workSpec.runAttemptCount = i;
            return (B) getThisObject$work_runtime_release();
        }

        public final B setLastEnqueueTime(long j, TimeUnit timeUnit) {
            Intrinsics.checkNotNullParameter(timeUnit, "timeUnit");
            this.workSpec.lastEnqueueTime = timeUnit.toMillis(j);
            return (B) getThisObject$work_runtime_release();
        }

        public final B setScheduleRequestedAt(long j, TimeUnit timeUnit) {
            Intrinsics.checkNotNullParameter(timeUnit, "timeUnit");
            this.workSpec.scheduleRequestedAt = timeUnit.toMillis(j);
            return (B) getThisObject$work_runtime_release();
        }
    }

    /* JADX INFO: compiled from: WorkRequest.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        /* JADX INFO: Access modifiers changed from: private */
        public final String deriveTraceTagFromClassName(String str) {
            String str2;
            List listSplit$default = StringsKt.split$default((CharSequence) str, new String[]{"."}, false, 0, 6, (Object) null);
            if (listSplit$default.size() == 1) {
                str2 = (String) listSplit$default.get(0);
            } else {
                str2 = (String) CollectionsKt.last(listSplit$default);
            }
            return str2.length() <= 127 ? str2 : StringsKt.take(str2, 127);
        }
    }
}
