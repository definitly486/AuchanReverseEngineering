package com.google.common.flogger;

import com.google.common.flogger.backend.Metadata;
import java.util.Random;
import java.util.concurrent.atomic.AtomicInteger;

/* JADX INFO: loaded from: classes2.dex */
final class SamplingRateLimiter extends RateLimitStatus {
    private static final LogSiteMap<SamplingRateLimiter> map = new LogSiteMap<SamplingRateLimiter>() { // from class: com.google.common.flogger.SamplingRateLimiter.1
        /* JADX INFO: Access modifiers changed from: protected */
        /* JADX WARN: Can't rename method to resolve collision */
        @Override // com.google.common.flogger.LogSiteMap
        public SamplingRateLimiter initialValue() {
            return new SamplingRateLimiter();
        }
    };
    private static final ThreadLocal<Random> random = new ThreadLocal<Random>() { // from class: com.google.common.flogger.SamplingRateLimiter.2
        /* JADX INFO: Access modifiers changed from: protected */
        @Override // java.lang.ThreadLocal
        public Random initialValue() {
            return new Random();
        }
    };
    final AtomicInteger pendingCount = new AtomicInteger();

    static RateLimitStatus check(Metadata metadata, LogSiteKey logSiteKey) {
        Integer num = (Integer) metadata.findValue(LogContext.Key.LOG_SAMPLE_EVERY_N);
        if (num == null || num.intValue() <= 0) {
            return null;
        }
        return map.get(logSiteKey, metadata).sampleOneIn(num.intValue());
    }

    private static Random getRandom() {
        return random.get();
    }

    SamplingRateLimiter() {
    }

    RateLimitStatus sampleOneIn(int i) {
        int iIncrementAndGet;
        if (getRandom().nextInt(i) == 0) {
            iIncrementAndGet = this.pendingCount.incrementAndGet();
        } else {
            iIncrementAndGet = this.pendingCount.get();
        }
        return iIncrementAndGet > 0 ? this : RateLimitStatus.DISALLOW;
    }

    @Override // com.google.common.flogger.RateLimitStatus
    public void reset() {
        this.pendingCount.decrementAndGet();
    }
}
