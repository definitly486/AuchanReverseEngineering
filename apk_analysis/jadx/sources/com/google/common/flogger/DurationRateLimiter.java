package com.google.common.flogger;

import com.google.common.flogger.backend.Metadata;
import com.google.common.flogger.util.Checks;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicLong;

/* JADX INFO: loaded from: classes2.dex */
final class DurationRateLimiter extends RateLimitStatus {
    private static final LogSiteMap<DurationRateLimiter> map = new LogSiteMap<DurationRateLimiter>() { // from class: com.google.common.flogger.DurationRateLimiter.1
        /* JADX INFO: Access modifiers changed from: protected */
        /* JADX WARN: Can't rename method to resolve collision */
        @Override // com.google.common.flogger.LogSiteMap
        public DurationRateLimiter initialValue() {
            return new DurationRateLimiter();
        }
    };
    private final AtomicLong lastTimestampNanos = new AtomicLong(-1);

    static RateLimitPeriod newRateLimitPeriod(int i, TimeUnit timeUnit) {
        return new RateLimitPeriod(i, timeUnit);
    }

    static RateLimitStatus check(Metadata metadata, LogSiteKey logSiteKey, long j) {
        RateLimitPeriod rateLimitPeriod = (RateLimitPeriod) metadata.findValue(LogContext.Key.LOG_AT_MOST_EVERY);
        if (rateLimitPeriod == null) {
            return null;
        }
        return map.get(logSiteKey, metadata).checkLastTimestamp(j, rateLimitPeriod);
    }

    static final class RateLimitPeriod {
        private final int n;
        private final TimeUnit unit;

        private RateLimitPeriod(int i, TimeUnit timeUnit) {
            if (i <= 0) {
                throw new IllegalArgumentException("time period must be positive: " + i);
            }
            this.n = i;
            this.unit = (TimeUnit) Checks.checkNotNull(timeUnit, "time unit");
        }

        /* JADX INFO: Access modifiers changed from: private */
        public long toNanos() {
            return this.unit.toNanos(this.n);
        }

        public String toString() {
            return this.n + " " + this.unit;
        }

        public int hashCode() {
            return (this.n * 37) ^ this.unit.hashCode();
        }

        public boolean equals(Object obj) {
            if (obj instanceof RateLimitPeriod) {
                RateLimitPeriod rateLimitPeriod = (RateLimitPeriod) obj;
                if (this.n == rateLimitPeriod.n && this.unit == rateLimitPeriod.unit) {
                    return true;
                }
            }
            return false;
        }
    }

    DurationRateLimiter() {
    }

    RateLimitStatus checkLastTimestamp(long j, RateLimitPeriod rateLimitPeriod) {
        Checks.checkArgument(j >= 0, "timestamp cannot be negative");
        long j2 = this.lastTimestampNanos.get();
        if (j2 >= 0) {
            long nanos = rateLimitPeriod.toNanos() + j2;
            if (nanos < 0 || j < nanos) {
                return RateLimitStatus.DISALLOW;
            }
        }
        this.lastTimestampNanos.compareAndSet(j2, -j);
        return this;
    }

    @Override // com.google.common.flogger.RateLimitStatus
    public void reset() {
        AtomicLong atomicLong = this.lastTimestampNanos;
        atomicLong.set(Math.max(-atomicLong.get(), 0L));
    }
}
