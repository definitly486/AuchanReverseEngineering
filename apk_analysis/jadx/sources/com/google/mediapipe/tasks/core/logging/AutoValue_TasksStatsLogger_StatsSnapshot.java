package com.google.mediapipe.tasks.core.logging;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_TasksStatsLogger_StatsSnapshot extends TasksStatsLogger.StatsSnapshot {
    private final int cpuInputCount;
    private final int droppedCount;
    private final long elapsedTimeMs;
    private final int finishedCount;
    private final int gpuInputCount;
    private final long peakLatencyMs;
    private final long totalLatencyMs;

    AutoValue_TasksStatsLogger_StatsSnapshot(int i, int i2, int i3, int i4, long j, long j2, long j3) {
        this.cpuInputCount = i;
        this.gpuInputCount = i2;
        this.finishedCount = i3;
        this.droppedCount = i4;
        this.totalLatencyMs = j;
        this.peakLatencyMs = j2;
        this.elapsedTimeMs = j3;
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger.StatsSnapshot
    int cpuInputCount() {
        return this.cpuInputCount;
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger.StatsSnapshot
    int gpuInputCount() {
        return this.gpuInputCount;
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger.StatsSnapshot
    int finishedCount() {
        return this.finishedCount;
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger.StatsSnapshot
    int droppedCount() {
        return this.droppedCount;
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger.StatsSnapshot
    long totalLatencyMs() {
        return this.totalLatencyMs;
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger.StatsSnapshot
    long peakLatencyMs() {
        return this.peakLatencyMs;
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger.StatsSnapshot
    long elapsedTimeMs() {
        return this.elapsedTimeMs;
    }

    public String toString() {
        return "StatsSnapshot{cpuInputCount=" + this.cpuInputCount + ", gpuInputCount=" + this.gpuInputCount + ", finishedCount=" + this.finishedCount + ", droppedCount=" + this.droppedCount + ", totalLatencyMs=" + this.totalLatencyMs + ", peakLatencyMs=" + this.peakLatencyMs + ", elapsedTimeMs=" + this.elapsedTimeMs + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof TasksStatsLogger.StatsSnapshot) {
            TasksStatsLogger.StatsSnapshot statsSnapshot = (TasksStatsLogger.StatsSnapshot) obj;
            if (this.cpuInputCount == statsSnapshot.cpuInputCount() && this.gpuInputCount == statsSnapshot.gpuInputCount() && this.finishedCount == statsSnapshot.finishedCount() && this.droppedCount == statsSnapshot.droppedCount() && this.totalLatencyMs == statsSnapshot.totalLatencyMs() && this.peakLatencyMs == statsSnapshot.peakLatencyMs() && this.elapsedTimeMs == statsSnapshot.elapsedTimeMs()) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        int i = (((((((this.cpuInputCount ^ 1000003) * 1000003) ^ this.gpuInputCount) * 1000003) ^ this.finishedCount) * 1000003) ^ this.droppedCount) * 1000003;
        long j = this.totalLatencyMs;
        int i2 = (i ^ ((int) (j ^ (j >>> 32)))) * 1000003;
        long j2 = this.peakLatencyMs;
        long j3 = this.elapsedTimeMs;
        return ((i2 ^ ((int) (j2 ^ (j2 >>> 32)))) * 1000003) ^ ((int) (j3 ^ (j3 >>> 32)));
    }
}
