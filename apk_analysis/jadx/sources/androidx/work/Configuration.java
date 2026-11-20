package androidx.work;

import androidx.core.util.Consumer;
import androidx.work.impl.DefaultRunnableScheduler;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Dispatchers;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.ExecutorsKt;
import java.util.concurrent.Executor;
import kotlin.coroutines.CoroutineContext;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Configuration.kt */
/* JADX INFO: loaded from: classes.dex */
public final class Configuration {
    public static final Companion Companion = new Companion(null);
    private final Clock clock;
    private final int contentUriTriggerWorkersLimit;
    private final String defaultProcessName;
    private final Executor executor;
    private final Consumer initializationExceptionHandler;
    private final InputMergerFactory inputMergerFactory;
    private final boolean isMarkingJobsAsImportantWhileForeground;
    private final boolean isUsingDefaultTaskExecutor;
    private final int maxJobSchedulerId;
    private final int maxSchedulerLimit;
    private final int minJobSchedulerId;
    private final int minimumLoggingLevel;
    private final RunnableScheduler runnableScheduler;
    private final Consumer schedulingExceptionHandler;
    private final Executor taskExecutor;
    private final Tracer tracer;
    private final CoroutineContext workerCoroutineContext;
    private final Consumer workerExecutionExceptionHandler;
    private final WorkerFactory workerFactory;
    private final Consumer workerInitializationExceptionHandler;

    /* JADX INFO: compiled from: Configuration.kt */
    public interface Provider {
        Configuration getWorkManagerConfiguration();
    }

    public Configuration(Builder builder) {
        Intrinsics.checkNotNullParameter(builder, "builder");
        CoroutineContext workerContext$work_runtime_release = builder.getWorkerContext$work_runtime_release();
        Executor executor$work_runtime_release = builder.getExecutor$work_runtime_release();
        if (executor$work_runtime_release == null) {
            executor$work_runtime_release = workerContext$work_runtime_release != null ? ConfigurationKt.asExecutor(workerContext$work_runtime_release) : null;
            if (executor$work_runtime_release == null) {
                executor$work_runtime_release = ConfigurationKt.createDefaultExecutor(false);
            }
        }
        this.executor = executor$work_runtime_release;
        if (workerContext$work_runtime_release == null) {
            workerContext$work_runtime_release = builder.getExecutor$work_runtime_release() != null ? ExecutorsKt.from(executor$work_runtime_release) : Dispatchers.getDefault();
        }
        this.workerCoroutineContext = workerContext$work_runtime_release;
        this.isUsingDefaultTaskExecutor = builder.getTaskExecutor$work_runtime_release() == null;
        Executor taskExecutor$work_runtime_release = builder.getTaskExecutor$work_runtime_release();
        this.taskExecutor = taskExecutor$work_runtime_release == null ? ConfigurationKt.createDefaultExecutor(true) : taskExecutor$work_runtime_release;
        Clock clock$work_runtime_release = builder.getClock$work_runtime_release();
        this.clock = clock$work_runtime_release == null ? new SystemClock() : clock$work_runtime_release;
        WorkerFactory workerFactory$work_runtime_release = builder.getWorkerFactory$work_runtime_release();
        this.workerFactory = workerFactory$work_runtime_release == null ? DefaultWorkerFactory.INSTANCE : workerFactory$work_runtime_release;
        InputMergerFactory inputMergerFactory$work_runtime_release = builder.getInputMergerFactory$work_runtime_release();
        this.inputMergerFactory = inputMergerFactory$work_runtime_release == null ? NoOpInputMergerFactory.INSTANCE : inputMergerFactory$work_runtime_release;
        RunnableScheduler runnableScheduler$work_runtime_release = builder.getRunnableScheduler$work_runtime_release();
        this.runnableScheduler = runnableScheduler$work_runtime_release == null ? new DefaultRunnableScheduler() : runnableScheduler$work_runtime_release;
        this.minimumLoggingLevel = builder.getLoggingLevel$work_runtime_release();
        this.minJobSchedulerId = builder.getMinJobSchedulerId$work_runtime_release();
        this.maxJobSchedulerId = builder.getMaxJobSchedulerId$work_runtime_release();
        this.maxSchedulerLimit = builder.getMaxSchedulerLimit$work_runtime_release();
        this.initializationExceptionHandler = builder.getInitializationExceptionHandler$work_runtime_release();
        this.schedulingExceptionHandler = builder.getSchedulingExceptionHandler$work_runtime_release();
        this.workerInitializationExceptionHandler = builder.getWorkerInitializationExceptionHandler$work_runtime_release();
        this.workerExecutionExceptionHandler = builder.getWorkerExecutionExceptionHandler$work_runtime_release();
        this.defaultProcessName = builder.getDefaultProcessName$work_runtime_release();
        this.contentUriTriggerWorkersLimit = builder.getContentUriTriggerWorkersLimit$work_runtime_release();
        this.isMarkingJobsAsImportantWhileForeground = builder.getMarkJobsAsImportantWhileForeground$work_runtime_release();
        Tracer tracer$work_runtime_release = builder.getTracer$work_runtime_release();
        this.tracer = tracer$work_runtime_release == null ? ConfigurationKt.createDefaultTracer() : tracer$work_runtime_release;
    }

    public final Executor getExecutor() {
        return this.executor;
    }

    public final CoroutineContext getWorkerCoroutineContext() {
        return this.workerCoroutineContext;
    }

    public final Executor getTaskExecutor() {
        return this.taskExecutor;
    }

    public final Clock getClock() {
        return this.clock;
    }

    public final WorkerFactory getWorkerFactory() {
        return this.workerFactory;
    }

    public final InputMergerFactory getInputMergerFactory() {
        return this.inputMergerFactory;
    }

    public final RunnableScheduler getRunnableScheduler() {
        return this.runnableScheduler;
    }

    public final Consumer<Throwable> getInitializationExceptionHandler() {
        return this.initializationExceptionHandler;
    }

    public final Consumer<Throwable> getSchedulingExceptionHandler() {
        return this.schedulingExceptionHandler;
    }

    public final Consumer<WorkerExceptionInfo> getWorkerInitializationExceptionHandler() {
        return this.workerInitializationExceptionHandler;
    }

    public final Consumer<WorkerExceptionInfo> getWorkerExecutionExceptionHandler() {
        return this.workerExecutionExceptionHandler;
    }

    public final String getDefaultProcessName() {
        return this.defaultProcessName;
    }

    public final int getMinimumLoggingLevel() {
        return this.minimumLoggingLevel;
    }

    public final int getMinJobSchedulerId() {
        return this.minJobSchedulerId;
    }

    public final int getMaxJobSchedulerId() {
        return this.maxJobSchedulerId;
    }

    public final int getContentUriTriggerWorkersLimit() {
        return this.contentUriTriggerWorkersLimit;
    }

    public final int getMaxSchedulerLimit() {
        return this.maxSchedulerLimit;
    }

    public final boolean isUsingDefaultTaskExecutor() {
        return this.isUsingDefaultTaskExecutor;
    }

    @ExperimentalConfigurationApi
    public final boolean isMarkingJobsAsImportantWhileForeground() {
        return this.isMarkingJobsAsImportantWhileForeground;
    }

    public final Tracer getTracer() {
        return this.tracer;
    }

    /* JADX INFO: compiled from: Configuration.kt */
    public static final class Builder {
        private Clock clock;
        private int contentUriTriggerWorkersLimit;
        private String defaultProcessName;
        private Executor executor;
        private Consumer initializationExceptionHandler;
        private InputMergerFactory inputMergerFactory;
        private int loggingLevel;
        private boolean markJobsAsImportantWhileForeground;
        private int maxJobSchedulerId;
        private int maxSchedulerLimit;
        private int minJobSchedulerId;
        private RunnableScheduler runnableScheduler;
        private Consumer schedulingExceptionHandler;
        private Executor taskExecutor;
        private Tracer tracer;
        private CoroutineContext workerContext;
        private Consumer workerExecutionExceptionHandler;
        private WorkerFactory workerFactory;
        private Consumer workerInitializationExceptionHandler;

        public final Executor getExecutor$work_runtime_release() {
            return this.executor;
        }

        public final CoroutineContext getWorkerContext$work_runtime_release() {
            return this.workerContext;
        }

        public final WorkerFactory getWorkerFactory$work_runtime_release() {
            return this.workerFactory;
        }

        public final InputMergerFactory getInputMergerFactory$work_runtime_release() {
            return this.inputMergerFactory;
        }

        public final Executor getTaskExecutor$work_runtime_release() {
            return this.taskExecutor;
        }

        public final Clock getClock$work_runtime_release() {
            return this.clock;
        }

        public final RunnableScheduler getRunnableScheduler$work_runtime_release() {
            return this.runnableScheduler;
        }

        public final Consumer getInitializationExceptionHandler$work_runtime_release() {
            return this.initializationExceptionHandler;
        }

        public final Consumer getSchedulingExceptionHandler$work_runtime_release() {
            return this.schedulingExceptionHandler;
        }

        public final Consumer getWorkerInitializationExceptionHandler$work_runtime_release() {
            return this.workerInitializationExceptionHandler;
        }

        public final Consumer getWorkerExecutionExceptionHandler$work_runtime_release() {
            return this.workerExecutionExceptionHandler;
        }

        public final String getDefaultProcessName$work_runtime_release() {
            return this.defaultProcessName;
        }

        public final int getLoggingLevel$work_runtime_release() {
            return this.loggingLevel;
        }

        public final int getMinJobSchedulerId$work_runtime_release() {
            return this.minJobSchedulerId;
        }

        public final int getMaxJobSchedulerId$work_runtime_release() {
            return this.maxJobSchedulerId;
        }

        public final int getMaxSchedulerLimit$work_runtime_release() {
            return this.maxSchedulerLimit;
        }

        public final int getContentUriTriggerWorkersLimit$work_runtime_release() {
            return this.contentUriTriggerWorkersLimit;
        }

        public final boolean getMarkJobsAsImportantWhileForeground$work_runtime_release() {
            return this.markJobsAsImportantWhileForeground;
        }

        public final Tracer getTracer$work_runtime_release() {
            return this.tracer;
        }

        public Builder() {
            this.loggingLevel = 4;
            this.maxJobSchedulerId = Integer.MAX_VALUE;
            this.maxSchedulerLimit = 20;
            this.contentUriTriggerWorkersLimit = 8;
            this.markJobsAsImportantWhileForeground = true;
        }

        public Builder(Configuration configuration) {
            Intrinsics.checkNotNullParameter(configuration, "configuration");
            this.loggingLevel = 4;
            this.maxJobSchedulerId = Integer.MAX_VALUE;
            this.maxSchedulerLimit = 20;
            this.contentUriTriggerWorkersLimit = 8;
            this.markJobsAsImportantWhileForeground = true;
            this.executor = configuration.getExecutor();
            this.workerFactory = configuration.getWorkerFactory();
            this.inputMergerFactory = configuration.getInputMergerFactory();
            this.taskExecutor = configuration.getTaskExecutor();
            this.clock = configuration.getClock();
            this.loggingLevel = configuration.getMinimumLoggingLevel();
            this.minJobSchedulerId = configuration.getMinJobSchedulerId();
            this.maxJobSchedulerId = configuration.getMaxJobSchedulerId();
            this.maxSchedulerLimit = configuration.getMaxSchedulerLimit();
            this.runnableScheduler = configuration.getRunnableScheduler();
            this.initializationExceptionHandler = configuration.getInitializationExceptionHandler();
            this.schedulingExceptionHandler = configuration.getSchedulingExceptionHandler();
            this.workerInitializationExceptionHandler = configuration.getWorkerInitializationExceptionHandler();
            this.workerExecutionExceptionHandler = configuration.getWorkerExecutionExceptionHandler();
            this.defaultProcessName = configuration.getDefaultProcessName();
            this.contentUriTriggerWorkersLimit = configuration.getContentUriTriggerWorkersLimit();
            this.markJobsAsImportantWhileForeground = configuration.isMarkingJobsAsImportantWhileForeground();
            this.tracer = configuration.getTracer();
        }

        public final Builder setWorkerFactory(WorkerFactory workerFactory) {
            Intrinsics.checkNotNullParameter(workerFactory, "workerFactory");
            this.workerFactory = workerFactory;
            return this;
        }

        public final Builder setInputMergerFactory(InputMergerFactory inputMergerFactory) {
            Intrinsics.checkNotNullParameter(inputMergerFactory, "inputMergerFactory");
            this.inputMergerFactory = inputMergerFactory;
            return this;
        }

        public final Builder setExecutor(Executor executor) {
            Intrinsics.checkNotNullParameter(executor, "executor");
            this.executor = executor;
            return this;
        }

        public final Builder setWorkerCoroutineContext(CoroutineContext context) {
            Intrinsics.checkNotNullParameter(context, "context");
            this.workerContext = context;
            return this;
        }

        public final Builder setTaskExecutor(Executor taskExecutor) {
            Intrinsics.checkNotNullParameter(taskExecutor, "taskExecutor");
            this.taskExecutor = taskExecutor;
            return this;
        }

        public final Builder setClock(Clock clock) {
            Intrinsics.checkNotNullParameter(clock, "clock");
            this.clock = clock;
            return this;
        }

        public final Builder setJobSchedulerJobIdRange(int i, int i2) {
            if (i2 - i < 1000) {
                throw new IllegalArgumentException("WorkManager needs a range of at least 1000 job ids.");
            }
            this.minJobSchedulerId = i;
            this.maxJobSchedulerId = i2;
            return this;
        }

        public final Builder setMaxSchedulerLimit(int i) {
            if (i < 20) {
                throw new IllegalArgumentException("WorkManager needs to be able to schedule at least 20 jobs in JobScheduler.");
            }
            this.maxSchedulerLimit = Math.min(i, 50);
            return this;
        }

        public final Builder setContentUriTriggerWorkersLimit(int i) {
            this.contentUriTriggerWorkersLimit = Math.max(i, 0);
            return this;
        }

        public final Builder setMinimumLoggingLevel(int i) {
            this.loggingLevel = i;
            return this;
        }

        public final Builder setRunnableScheduler(RunnableScheduler runnableScheduler) {
            Intrinsics.checkNotNullParameter(runnableScheduler, "runnableScheduler");
            this.runnableScheduler = runnableScheduler;
            return this;
        }

        public final Builder setInitializationExceptionHandler(Consumer<Throwable> exceptionHandler) {
            Intrinsics.checkNotNullParameter(exceptionHandler, "exceptionHandler");
            this.initializationExceptionHandler = exceptionHandler;
            return this;
        }

        public final Builder setSchedulingExceptionHandler(Consumer<Throwable> schedulingExceptionHandler) {
            Intrinsics.checkNotNullParameter(schedulingExceptionHandler, "schedulingExceptionHandler");
            this.schedulingExceptionHandler = schedulingExceptionHandler;
            return this;
        }

        public final Builder setWorkerInitializationExceptionHandler(Consumer<WorkerExceptionInfo> workerExceptionHandler) {
            Intrinsics.checkNotNullParameter(workerExceptionHandler, "workerExceptionHandler");
            this.workerInitializationExceptionHandler = workerExceptionHandler;
            return this;
        }

        public final Builder setWorkerExecutionExceptionHandler(Consumer<WorkerExceptionInfo> workerExceptionHandler) {
            Intrinsics.checkNotNullParameter(workerExceptionHandler, "workerExceptionHandler");
            this.workerExecutionExceptionHandler = workerExceptionHandler;
            return this;
        }

        public final Builder setDefaultProcessName(String processName) {
            Intrinsics.checkNotNullParameter(processName, "processName");
            this.defaultProcessName = processName;
            return this;
        }

        @ExperimentalConfigurationApi
        public final Builder setMarkingJobsAsImportantWhileForeground(boolean z) {
            this.markJobsAsImportantWhileForeground = z;
            return this;
        }

        public final Builder setTracer(Tracer tracer) {
            Intrinsics.checkNotNullParameter(tracer, "tracer");
            this.tracer = tracer;
            return this;
        }

        public final Configuration build() {
            return new Configuration(this);
        }
    }

    /* JADX INFO: compiled from: Configuration.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }
    }
}
