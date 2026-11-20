package com.google.common.flogger;

import com.google.common.flogger.backend.Metadata;
import java.util.concurrent.atomic.AtomicLong;

/* JADX INFO: loaded from: classes2.dex */
final class CountingRateLimiter extends RateLimitStatus {
    private static final LogSiteMap<CountingRateLimiter> map = new LogSiteMap<CountingRateLimiter>() { // from class: com.google.common.flogger.CountingRateLimiter.1
        /* JADX INFO: Access modifiers changed from: protected */
        /* JADX WARN: Can't rename method to resolve collision */
        @Override // com.google.common.flogger.LogSiteMap
        public CountingRateLimiter initialValue() {
            return new CountingRateLimiter();
        }
    };
    private final AtomicLong invocationCount = new AtomicLong(2147483647L);

    static RateLimitStatus check(Metadata metadata, LogSiteKey logSiteKey) {
        Integer num = (Integer) metadata.findValue(LogContext.Key.LOG_EVERY_N);
        if (num == null) {
            return null;
        }
        return map.get(logSiteKey, metadata).incrementAndCheckLogCount(num.intValue());
    }

    CountingRateLimiter() {
    }

    RateLimitStatus incrementAndCheckLogCount(int i) {
        return this.invocationCount.incrementAndGet() >= ((long) i) ? this : RateLimitStatus.DISALLOW;
    }

    @Override // com.google.common.flogger.RateLimitStatus
    public void reset() {
        this.invocationCount.set(0L);
    }
}
