package com.scanflow.datacapture.barinternal.kotlin.time;

import androidx.core.location.LocationRequestCompat;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: compiled from: Duration.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class LongParser {
    private final boolean allowSign;
    private final long lastDigitMax;
    private final long overflowLimit;
    private final long overflowThreshold;
    public static final Companion Companion = new Companion(null);
    private static final LongParser iso = new LongParser(4611686018427387903L, true);

    /* JADX INFO: renamed from: default, reason: not valid java name */
    private static final LongParser f1default = new LongParser(LocationRequestCompat.PASSIVE_INTERVAL, false);

    private LongParser(long j, boolean z) {
        this.overflowLimit = j;
        this.allowSign = z;
        long j2 = 10;
        this.overflowThreshold = j / j2;
        this.lastDigitMax = j % j2;
    }

    /* JADX INFO: compiled from: Duration.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        public final LongParser getIso() {
            return LongParser.iso;
        }

        public final LongParser getDefault() {
            return LongParser.f1default;
        }
    }
}
