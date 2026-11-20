package com.google.mediapipe.tasks.core.logging;

import android.content.Context;

/* JADX INFO: loaded from: classes3.dex */
public final class TasksStatsLoggerFactory {
    public static TasksStatsLogger create(Context context, String str, String str2) {
        return TasksStatsProtoLogger.create(context, str, str2);
    }
}
