package com.google.common.flogger.backend.system;

import com.google.common.flogger.AbstractLogger;
import com.google.common.flogger.LogSite;
import com.google.common.flogger.LogSites;
import com.google.common.flogger.backend.Platform;
import com.google.common.flogger.util.CallerFinder;

/* JADX INFO: loaded from: classes2.dex */
public final class StackBasedCallerFinder extends Platform.LogCallerFinder {
    private static final Platform.LogCallerFinder INSTANCE = new StackBasedCallerFinder();

    public static Platform.LogCallerFinder getInstance() {
        return INSTANCE;
    }

    @Override // com.google.common.flogger.backend.Platform.LogCallerFinder
    public String findLoggingClass(Class<? extends AbstractLogger<?>> cls) {
        StackTraceElement stackTraceElementFindCallerOf = CallerFinder.findCallerOf(cls, 1);
        if (stackTraceElementFindCallerOf != null) {
            return stackTraceElementFindCallerOf.getClassName();
        }
        throw new IllegalStateException("no caller found on the stack for: " + cls.getName());
    }

    @Override // com.google.common.flogger.backend.Platform.LogCallerFinder
    public LogSite findLogSite(Class<?> cls, int i) {
        return LogSites.logSiteFrom(CallerFinder.findCallerOf(cls, i + 1));
    }

    public String toString() {
        return "Default stack-based caller finder";
    }

    private StackBasedCallerFinder() {
    }
}
