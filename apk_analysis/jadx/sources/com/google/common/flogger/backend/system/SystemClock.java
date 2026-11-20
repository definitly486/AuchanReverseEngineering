package com.google.common.flogger.backend.system;

import java.util.concurrent.TimeUnit;

/* JADX INFO: loaded from: classes2.dex */
public final class SystemClock extends Clock {
    private static final SystemClock INSTANCE = new SystemClock();

    public static SystemClock getInstance() {
        return INSTANCE;
    }

    private SystemClock() {
    }

    @Override // com.google.common.flogger.backend.system.Clock
    public long getCurrentTimeNanos() {
        return TimeUnit.MILLISECONDS.toNanos(System.currentTimeMillis());
    }

    public String toString() {
        return "Default millisecond precision clock";
    }
}
