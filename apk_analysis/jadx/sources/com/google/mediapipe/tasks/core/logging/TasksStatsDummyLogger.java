package com.google.mediapipe.tasks.core.logging;

import android.content.Context;

/* JADX INFO: loaded from: classes3.dex */
public class TasksStatsDummyLogger implements TasksStatsLogger {
    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logInitError() {
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logInvocationReport(TasksStatsLogger.StatsSnapshot statsSnapshot) {
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logSessionClone() {
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logSessionEnd() {
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void logSessionStart() {
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void recordCpuInputArrival(long j) {
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void recordGpuInputArrival(long j) {
    }

    @Override // com.google.mediapipe.tasks.core.logging.TasksStatsLogger
    public void recordInvocationEnd(long j) {
    }

    public static TasksStatsDummyLogger create(Context context, String str, String str2) {
        return new TasksStatsDummyLogger();
    }

    private TasksStatsDummyLogger() {
    }
}
