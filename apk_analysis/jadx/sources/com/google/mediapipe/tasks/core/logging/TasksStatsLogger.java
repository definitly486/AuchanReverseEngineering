package com.google.mediapipe.tasks.core.logging;

import com.google.auto.value.AutoValue;

/* JADX INFO: loaded from: classes3.dex */
public interface TasksStatsLogger {
    void logInitError();

    void logInvocationReport(StatsSnapshot statsSnapshot);

    void logSessionClone();

    void logSessionEnd();

    void logSessionStart();

    void recordCpuInputArrival(long j);

    void recordGpuInputArrival(long j);

    void recordInvocationEnd(long j);

    @AutoValue
    public static abstract class StatsSnapshot {
        abstract int cpuInputCount();

        abstract int droppedCount();

        abstract long elapsedTimeMs();

        abstract int finishedCount();

        abstract int gpuInputCount();

        abstract long peakLatencyMs();

        abstract long totalLatencyMs();

        static StatsSnapshot create(int i, int i2, int i3, int i4, long j, long j2, long j3) {
            return new AutoValue_TasksStatsLogger_StatsSnapshot(i, i2, i3, i4, j, j2, j3);
        }

        static StatsSnapshot createDefault() {
            return new AutoValue_TasksStatsLogger_StatsSnapshot(0, 0, 0, 0, 0L, 0L, 0L);
        }
    }
}
