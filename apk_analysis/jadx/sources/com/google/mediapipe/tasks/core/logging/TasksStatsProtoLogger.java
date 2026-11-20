package com.google.mediapipe.tasks.core.logging;

import android.content.Context;
import android.content.pm.PackageManager;
import android.util.Log;
import androidx.work.WorkRequest;
import com.google.mediapipe.proto.MediaPipeLoggingEnumsProto;
import com.google.mediapipe.proto.MediaPipeLoggingProto;
import java.time.Instant;
import java.util.Locale;
import java.util.concurrent.ConcurrentNavigableMap;
import java.util.concurrent.ConcurrentSkipListMap;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.concurrent.atomic.AtomicLong;

/* JADX INFO: loaded from: classes3.dex */
public class TasksStatsProtoLogger implements TasksStatsLogger {
    private static final String TAG = "TasksStatsProtoLogger";
    private static final String TASKS_MODE_PREFIX = "MODE_TASKS_";
    private static final String TASKS_NAME_PREFIX = "TASKS_";
    private final LoggingClient loggingClient;
    private long reportStartTimeMs;
    private TasksStatsLogger.StatsSnapshot statsSnapshot;
    private final MediaPipeLoggingProto.SystemInfo systemInfo;
    private final MediaPipeLoggingEnumsProto.SolutionName taskName;
    private final MediaPipeLoggingEnumsProto.SolutionMode taskRunningMode;
    private static final Long REPORT_INTERVAL_MS = Long.valueOf(WorkRequest.DEFAULT_BACKOFF_DELAY_MILLIS);
    private static final Long LATENCY_TIMEOUT_THRESHOLD_MS = 3000L;
    private final AtomicInteger cpuInputCount = new AtomicInteger(0);
    private final AtomicInteger gpuInputCount = new AtomicInteger(0);
    private final AtomicInteger finishedCount = new AtomicInteger(0);
    private final AtomicInteger droppedCount = new AtomicInteger(0);
    private final AtomicLong totalLatencyMs = new AtomicLong(0);
    private final AtomicLong latestPeakLatencyMs = new AtomicLong(0);
    private final AtomicLong lifetimePeakLatencyMs = new AtomicLong(0);
    private final ConcurrentNavigableMap<Long, Long> startTimeMap = new ConcurrentSkipListMap();
    private final long taskInitTimeMs = System.currentTimeMillis();

    public static TasksStatsProtoLogger create(Context context, String str, String str2) {
        String strValueOf;
        MediaPipeLoggingEnumsProto.SolutionName solutionName;
        MediaPipeLoggingEnumsProto.SolutionMode solutionMode;
        try {
            strValueOf = String.valueOf(context.getPackageManager().getPackageInfo(context.getPackageName(), 0).versionCode);
        } catch (PackageManager.NameNotFoundException e) {
            Log.e(TAG, "Exception thrown when trying to get app version " + e);
            strValueOf = "";
        }
        try {
            solutionName = (MediaPipeLoggingEnumsProto.SolutionName) Enum.valueOf(MediaPipeLoggingEnumsProto.SolutionName.class, TASKS_NAME_PREFIX + str.toUpperCase(Locale.ENGLISH));
        } catch (IllegalArgumentException unused) {
            solutionName = MediaPipeLoggingEnumsProto.SolutionName.SOLUTION_UNKNOWN;
        }
        try {
            solutionMode = (MediaPipeLoggingEnumsProto.SolutionMode) Enum.valueOf(MediaPipeLoggingEnumsProto.SolutionMode.class, TASKS_MODE_PREFIX + str2.toUpperCase(Locale.ENGLISH));
        } catch (IllegalArgumentException unused2) {
            solutionMode = MediaPipeLoggingEnumsProto.SolutionMode.MODE_TASKS_UNSPECIFIED;
        }
        return new TasksStatsProtoLogger(context, solutionName, solutionMode, MediaPipeLoggingProto.SystemInfo.newBuilder().setPlatform(MediaPipeLoggingEnumsProto.Platform.PLATFORM_ANDROID).setAppId(context.getPackageName()).setAppVersion(strValueOf).build());
    }

    private TasksStatsProtoLogger(Context context, MediaPipeLoggingEnumsProto.SolutionName solutionName, MediaPipeLoggingEnumsProto.SolutionMode solutionMode, MediaPipeLoggingProto.SystemInfo systemInfo) {
        this.loggingClient = new RemoteLoggingClient(context);
        this.taskName = solutionName;
        this.taskRunningMode = solutionMode;
        this.systemInfo = systemInfo;
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logSessionStart() {
        logTaskEvent(MediaPipeLoggingProto.SolutionEvent.newBuilder().setSolutionName(this.taskName).setEventName(MediaPipeLoggingEnumsProto.EventName.EVENT_START).setSessionStart(MediaPipeLoggingProto.SolutionSessionStart.newBuilder().setMode(this.taskRunningMode).setInitLatencyMs(Instant.now().minusMillis(this.taskInitTimeMs).toEpochMilli()).build()).build());
        this.reportStartTimeMs = System.currentTimeMillis();
        this.statsSnapshot = TasksStatsLogger.StatsSnapshot.createDefault();
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logSessionClone() {
        logTaskEvent(MediaPipeLoggingProto.SolutionEvent.newBuilder().setSolutionName(this.taskName).setEventName(MediaPipeLoggingEnumsProto.EventName.EVENT_START).setSessionClone(MediaPipeLoggingProto.SolutionSessionClone.newBuilder().setMode(this.taskRunningMode).setInitLatencyMs(Instant.now().minusMillis(this.taskInitTimeMs).toEpochMilli()).build()).build());
        this.reportStartTimeMs = System.currentTimeMillis();
        this.statsSnapshot = TasksStatsLogger.StatsSnapshot.createDefault();
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void recordCpuInputArrival(long j) {
        this.cpuInputCount.incrementAndGet();
        this.startTimeMap.put(Long.valueOf(j), Long.valueOf(System.currentTimeMillis()));
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void recordGpuInputArrival(long j) {
        this.gpuInputCount.incrementAndGet();
        this.startTimeMap.put(Long.valueOf(j), Long.valueOf(System.currentTimeMillis()));
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void recordInvocationEnd(long j) {
        boolean z;
        if (this.startTimeMap.containsKey(Long.valueOf(j))) {
            long jCurrentTimeMillis = System.currentTimeMillis() - this.startTimeMap.remove(Long.valueOf(j)).longValue();
            this.finishedCount.incrementAndGet();
            if (jCurrentTimeMillis > LATENCY_TIMEOUT_THRESHOLD_MS.longValue()) {
                return;
            }
            this.totalLatencyMs.addAndGet(jCurrentTimeMillis);
            AtomicLong atomicLong = this.latestPeakLatencyMs;
            atomicLong.set(Math.max(atomicLong.get(), jCurrentTimeMillis));
            AtomicLong atomicLong2 = this.lifetimePeakLatencyMs;
            atomicLong2.set(Math.max(atomicLong2.get(), jCurrentTimeMillis));
            TasksStatsLogger.StatsSnapshot statsSnapshotCreateDefault = TasksStatsLogger.StatsSnapshot.createDefault();
            synchronized (this) {
                try {
                    if (System.currentTimeMillis() > this.reportStartTimeMs + REPORT_INTERVAL_MS.longValue()) {
                        this.droppedCount.addAndGet(this.startTimeMap.headMap(Long.valueOf(j)).size());
                        this.startTimeMap.headMap(Long.valueOf(j)).clear();
                        statsSnapshotCreateDefault = TasksStatsLogger.StatsSnapshot.create(this.cpuInputCount.get(), this.gpuInputCount.get(), this.finishedCount.get(), this.droppedCount.get(), this.totalLatencyMs.get(), this.latestPeakLatencyMs.getAndSet(0L), System.currentTimeMillis() - this.reportStartTimeMs);
                        this.reportStartTimeMs = System.currentTimeMillis();
                        z = true;
                    } else {
                        z = false;
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
            if (z) {
                logInvocationReport(TasksStatsLogger.StatsSnapshot.create(statsSnapshotCreateDefault.cpuInputCount() - this.statsSnapshot.cpuInputCount(), statsSnapshotCreateDefault.gpuInputCount() - this.statsSnapshot.gpuInputCount(), statsSnapshotCreateDefault.finishedCount() - this.statsSnapshot.finishedCount(), statsSnapshotCreateDefault.droppedCount() - this.statsSnapshot.droppedCount(), statsSnapshotCreateDefault.totalLatencyMs() - this.statsSnapshot.totalLatencyMs(), statsSnapshotCreateDefault.peakLatencyMs(), statsSnapshotCreateDefault.elapsedTimeMs()));
                this.statsSnapshot = statsSnapshotCreateDefault;
            }
        }
    }

    private MediaPipeLoggingProto.SolutionInvocationReport produceInvocationReport(TasksStatsLogger.StatsSnapshot statsSnapshot) {
        MediaPipeLoggingProto.SolutionInvocationReport.Builder elapsedTimeMs = MediaPipeLoggingProto.SolutionInvocationReport.newBuilder().setMode(this.taskRunningMode).setDropped(statsSnapshot.droppedCount()).setPipelinePeakLatencyMs(statsSnapshot.peakLatencyMs()).setPipelineAverageLatencyMs(statsSnapshot.totalLatencyMs() / ((long) Math.max(1, statsSnapshot.finishedCount()))).setElapsedTimeMs(statsSnapshot.elapsedTimeMs());
        if (statsSnapshot.cpuInputCount() != 0) {
            elapsedTimeMs.addInvocationCount(MediaPipeLoggingProto.SolutionInvocationCount.newBuilder().setInputDataType(MediaPipeLoggingEnumsProto.InputDataType.INPUT_TYPE_TASKS_CPU).setCount(statsSnapshot.cpuInputCount()).build());
        }
        if (statsSnapshot.gpuInputCount() != 0) {
            elapsedTimeMs.addInvocationCount(MediaPipeLoggingProto.SolutionInvocationCount.newBuilder().setInputDataType(MediaPipeLoggingEnumsProto.InputDataType.INPUT_TYPE_TASKS_GPU).setCount(statsSnapshot.gpuInputCount()).build());
        }
        return elapsedTimeMs.build();
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logInvocationReport(TasksStatsLogger.StatsSnapshot statsSnapshot) {
        logTaskEvent(MediaPipeLoggingProto.SolutionEvent.newBuilder().setSolutionName(this.taskName).setEventName(MediaPipeLoggingEnumsProto.EventName.EVENT_INVOCATONS).setInvocationReport(produceInvocationReport(statsSnapshot)).build());
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logSessionEnd() {
        logTaskEvent(MediaPipeLoggingProto.SolutionEvent.newBuilder().setSolutionName(this.taskName).setEventName(MediaPipeLoggingEnumsProto.EventName.EVENT_END).setSessionEnd(MediaPipeLoggingProto.SolutionSessionEnd.newBuilder().setInvocationReport(produceInvocationReport(TasksStatsLogger.StatsSnapshot.create(this.cpuInputCount.get(), this.gpuInputCount.get(), this.finishedCount.get(), this.startTimeMap.size() + this.droppedCount.get(), this.totalLatencyMs.get(), this.lifetimePeakLatencyMs.get(), System.currentTimeMillis() - this.taskInitTimeMs))).build()).build());
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logInitError() {
        logTaskEvent(MediaPipeLoggingProto.SolutionEvent.newBuilder().setSolutionName(this.taskName).setEventName(MediaPipeLoggingEnumsProto.EventName.EVENT_ERROR).setErrorDetails(MediaPipeLoggingProto.SolutionError.newBuilder().setErrorCode(MediaPipeLoggingEnumsProto.ErrorCode.ERROR_INIT).build()).build());
    }

    private void logTaskEvent(MediaPipeLoggingProto.SolutionEvent solutionEvent) {
        this.loggingClient.logEvent(MediaPipeLoggingProto.MediaPipeLogExtension.newBuilder().setSystemInfo(this.systemInfo).setSolutionEvent(solutionEvent).build());
    }
}
