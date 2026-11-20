package com.google.common.util.concurrent;

import androidx.core.location.LocationRequestCompat;
import com.google.common.annotations.GwtIncompatible;
import com.google.common.annotations.J2ktIncompatible;
import java.time.Duration;

/* JADX INFO: loaded from: classes2.dex */
@IgnoreJRERequirement
@J2ktIncompatible
@GwtIncompatible
final class Internal {
    static long toNanosSaturated(Duration duration) {
        try {
            return duration.toNanos();
        } catch (ArithmeticException unused) {
            if (duration.isNegative()) {
                return Long.MIN_VALUE;
            }
            return LocationRequestCompat.PASSIVE_INTERVAL;
        }
    }

    private Internal() {
    }
}
