package com.google.common.flogger;

import com.google.common.flogger.backend.Platform;

/* JADX INFO: loaded from: classes2.dex */
public final class LogSites {
    public static LogSite callerOf(Class<?> cls) {
        return Platform.getCallerFinder().findLogSite(cls, 0);
    }

    public static LogSite logSite() {
        return Platform.getCallerFinder().findLogSite(LogSites.class, 0);
    }

    public static LogSite logSiteFrom(StackTraceElement stackTraceElement) {
        return stackTraceElement != null ? new StackBasedLogSite(stackTraceElement) : LogSite.INVALID;
    }

    private LogSites() {
    }
}
