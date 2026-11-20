package com.google.common.flogger;

/* JADX INFO: loaded from: classes2.dex */
public final class LogSiteStackTrace extends Exception {
    @Override // java.lang.Throwable
    public Throwable fillInStackTrace() {
        return this;
    }

    LogSiteStackTrace(Throwable th, StackSize stackSize, StackTraceElement[] stackTraceElementArr) {
        super(stackSize.toString(), th);
        setStackTrace(stackTraceElementArr);
    }
}
