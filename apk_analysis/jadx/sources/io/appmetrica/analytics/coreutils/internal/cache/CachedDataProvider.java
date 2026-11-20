package io.appmetrica.analytics.coreutils.internal.cache;

import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;

/* JADX INFO: loaded from: classes3.dex */
public interface CachedDataProvider {

    public static class CachedData<T> {
        private final String b;
        private volatile long c;
        private volatile long d;
        private long e = 0;
        private Object f = null;
        private final SystemTimeProvider a = new SystemTimeProvider();

        public CachedData(long j, long j2, String str) {
            this.b = String.format("[CachedData-%s]", str);
            this.c = j;
            this.d = j2;
        }

        public T getData() {
            return (T) this.f;
        }

        public long getExpiryTime() {
            return this.d;
        }

        public long getRefreshTime() {
            return this.c;
        }

        public final boolean isEmpty() {
            return this.f == null;
        }

        public void setData(T t) {
            this.f = t;
            this.e = this.a.currentTimeMillis();
        }

        public void setExpirationPolicy(long j, long j2) {
            this.c = j;
            this.d = j2;
        }

        public final boolean shouldClearData() {
            if (this.e == 0) {
                return false;
            }
            long jCurrentTimeMillis = this.a.currentTimeMillis() - this.e;
            return jCurrentTimeMillis > this.d || jCurrentTimeMillis < 0;
        }

        public final boolean shouldUpdateData() {
            long jCurrentTimeMillis = this.a.currentTimeMillis() - this.e;
            return jCurrentTimeMillis > this.c || jCurrentTimeMillis < 0;
        }

        public String toString() {
            return "CachedData{tag='" + this.b + "', refreshTime=" + this.c + ", expiryTime=" + this.d + ", mCachedTime=" + this.e + ", mCachedData=" + this.f + '}';
        }
    }
}
