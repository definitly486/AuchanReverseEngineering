package io.appmetrica.analytics.locationapi.internal;

import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class CacheArguments {
    private final long a;
    private final long b;

    public CacheArguments() {
        this(0L, 0L, 3, null);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!Intrinsics.areEqual(CacheArguments.class, obj != null ? obj.getClass() : null)) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type io.appmetrica.analytics.locationapi.internal.CacheArguments");
        CacheArguments cacheArguments = (CacheArguments) obj;
        return this.a == cacheArguments.a && this.b == cacheArguments.b;
    }

    public final long getOutdatedTimeInterval() {
        return this.b;
    }

    public final long getRefreshPeriod() {
        return this.a;
    }

    public int hashCode() {
        return Long.hashCode(this.b) + (Long.hashCode(this.a) * 31);
    }

    public String toString() {
        return "CacheArguments(refreshPeriod=" + this.a + ", outdatedTimeInterval=" + this.b + ')';
    }

    public CacheArguments(long j, long j2) {
        this.a = j;
        this.b = j2;
    }

    public /* synthetic */ CacheArguments(long j, long j2, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? TimeUnit.SECONDS.toMillis(10L) : j, (i & 2) != 0 ? TimeUnit.MINUTES.toMillis(2L) : j2);
    }
}
