package com.google.common.flogger;

import com.google.common.flogger.backend.Metadata;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.concurrent.atomic.AtomicInteger;

/* JADX INFO: loaded from: classes2.dex */
public abstract class RateLimitStatus {
    public static final RateLimitStatus DISALLOW = sentinel();
    public static final RateLimitStatus ALLOW = sentinel();

    protected abstract void reset();

    private static RateLimitStatus sentinel() {
        return new RateLimitStatus() { // from class: com.google.common.flogger.RateLimitStatus.1
            @Override // com.google.common.flogger.RateLimitStatus
            public void reset() {
            }
        };
    }

    private static final class LogGuard {
        private static final LogSiteMap<LogGuard> guardMap = new LogSiteMap<LogGuard>() { // from class: com.google.common.flogger.RateLimitStatus.LogGuard.1
            /* JADX WARN: Can't rename method to resolve collision */
            @Override // com.google.common.flogger.LogSiteMap
            public LogGuard initialValue() {
                return new LogGuard();
            }
        };
        private final AtomicInteger pendingLogCount;
        private final AtomicBoolean shouldReset;

        private LogGuard() {
            this.shouldReset = new AtomicBoolean();
            this.pendingLogCount = new AtomicInteger();
        }

        static int checkAndGetSkippedCount(RateLimitStatus rateLimitStatus, LogSiteKey logSiteKey, Metadata metadata) {
            LogGuard logGuard = guardMap.get(logSiteKey, metadata);
            int iIncrementAndGet = logGuard.pendingLogCount.incrementAndGet();
            if (rateLimitStatus == RateLimitStatus.DISALLOW || !logGuard.shouldReset.compareAndSet(false, true)) {
                return -1;
            }
            try {
                rateLimitStatus.reset();
                logGuard.shouldReset.set(false);
                logGuard.pendingLogCount.addAndGet(-iIncrementAndGet);
                return iIncrementAndGet - 1;
            } catch (Throwable th) {
                logGuard.shouldReset.set(false);
                throw th;
            }
        }
    }

    static RateLimitStatus combine(RateLimitStatus rateLimitStatus, final RateLimitStatus rateLimitStatus2) {
        RateLimitStatus rateLimitStatus3;
        RateLimitStatus rateLimitStatus4;
        if (rateLimitStatus == null) {
            return rateLimitStatus2;
        }
        if (rateLimitStatus2 == null || rateLimitStatus == (rateLimitStatus3 = DISALLOW) || rateLimitStatus2 == (rateLimitStatus4 = ALLOW)) {
            return rateLimitStatus;
        }
        return (rateLimitStatus2 == rateLimitStatus3 || rateLimitStatus == rateLimitStatus4) ? rateLimitStatus2 : new RateLimitStatus() { // from class: com.google.common.flogger.RateLimitStatus.2
            @Override // com.google.common.flogger.RateLimitStatus
            public void reset() {
                try {
                    RateLimitStatus.this.reset();
                } finally {
                    rateLimitStatus2.reset();
                }
            }
        };
    }

    static int checkStatus(RateLimitStatus rateLimitStatus, LogSiteKey logSiteKey, Metadata metadata) {
        return LogGuard.checkAndGetSkippedCount(rateLimitStatus, logSiteKey, metadata);
    }

    protected RateLimitStatus() {
    }
}
