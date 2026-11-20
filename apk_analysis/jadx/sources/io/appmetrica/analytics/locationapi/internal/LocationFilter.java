package io.appmetrica.analytics.locationapi.internal;

import androidx.lifecycle.CoroutineLiveDataKt;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class LocationFilter {
    private final long a;
    private final float b;

    public LocationFilter() {
        this(0L, 0.0f, 3, null);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!Intrinsics.areEqual(LocationFilter.class, obj != null ? obj.getClass() : null)) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type io.appmetrica.analytics.locationapi.internal.LocationFilter");
        LocationFilter locationFilter = (LocationFilter) obj;
        return this.a == locationFilter.a && this.b == locationFilter.b;
    }

    public final float getUpdateDistanceInterval() {
        return this.b;
    }

    public final long getUpdateTimeInterval() {
        return this.a;
    }

    public int hashCode() {
        return Float.hashCode(this.b) + (Long.hashCode(this.a) * 31);
    }

    public String toString() {
        return "LocationFilter(updateTimeInterval=" + this.a + ", updateDistanceInterval=" + this.b + ')';
    }

    public LocationFilter(long j, float f) {
        this.a = j;
        this.b = f;
    }

    public /* synthetic */ LocationFilter(long j, float f, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? CoroutineLiveDataKt.DEFAULT_TIMEOUT : j, (i & 2) != 0 ? 10.0f : f);
    }
}
