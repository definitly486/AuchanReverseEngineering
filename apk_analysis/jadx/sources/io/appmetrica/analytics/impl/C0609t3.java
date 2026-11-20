package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.t3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0609t3 {
    public final long a;

    public C0609t3(long j) {
        this.a = j;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        return obj != null && C0609t3.class == obj.getClass() && this.a == ((C0609t3) obj).a;
    }

    public final int hashCode() {
        long j = this.a;
        return (int) (j ^ (j >>> 32));
    }

    public final String toString() {
        return "CacheControl{lastKnownLocationTtl=" + this.a + '}';
    }
}
